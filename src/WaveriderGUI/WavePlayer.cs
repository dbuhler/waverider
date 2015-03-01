using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI
{
    /* This class represents an audio player for wave data.
     */
    public class WavePlayer
    {
        // Available sampling rates.
        public static SamplingRate[] SAMPLING_RATES = { 8000, 11025, 16000, 22050, 32000, 44100, 48000 };

        // Possible states the player can be in.
        public enum PlayerState
        {
            IDLE,
            PLAYING,
            PAUSED,
            RECORDING
        }

        // Pre-defined messages in Win32.
        private const int MM_WOM_OPEN  = 0x3BB;
        private const int MM_WOM_CLOSE = 0x3BC;
        private const int MM_WOM_DONE  = 0x3BD;
        private const int MM_WIM_OPEN  = 0x3BE;
        private const int MM_WIM_CLOSE = 0x3BF;
        private const int MM_WIM_DATA  = 0x3C0;
        private const int WM_USER      = 0x400;
        
        // Custom messages.
        private const int WAV_INIT       = WM_USER + 0;
        private const int WAV_TERM       = WM_USER + 1;
        private const int WAV_RECORD_BEG = WM_USER + 2;
        private const int WAV_RECORD_END = WM_USER + 3;
        private const int WAV_PLAY_BEG   = WM_USER + 4;
        private const int WAV_PLAY_END   = WM_USER + 5;
        private const int WAV_PLAY_PAUSE = WM_USER + 6;

        /* This structure contains wave header information.
         */
        [StructLayout(LayoutKind.Sequential)]
        private struct WaveInfo
        {
            public int    SamplingRate;
            public short  BytesPerSample;
            public short  NumChannels;    
            public int    DataLength;
            public IntPtr SaveBuffer;
        }

        private IntPtr   handle;
        private WaveInfo waveInfo;
        private bool     playing;
        private bool     paused;
        private bool     recording;


        [DllImport("waveio.dll")]
        private static extern IntPtr WaveProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("waveio.dll")]
        private static extern void SendWaveMsg(IntPtr handle, int message, ref WaveInfo waveInfo);


        /* Creates a new player instance for the window with the given handle.
         */
        public WavePlayer(IntPtr handle)
        {
            this.handle = handle;
        }


        /* Returns the wave player's current state.
         */
        public PlayerState State
        {
            get
            {
                if (playing)
                {
                    if (paused)
                    {
                        return PlayerState.PAUSED;
                    }
                    else
                    {
                        return PlayerState.PLAYING;
                    }
                }
                else if (recording)
                {
                    return PlayerState.RECORDING;
                }
                else
                {
                    return PlayerState.IDLE;
                }
            }
        }


        public bool IsPlaying   { get { return playing; } }


        /* Gets or sets the player's sampling rate.
         */
        public int SamplingRate
        {
            get { return waveInfo.SamplingRate; }
            set { waveInfo.SamplingRate = value; }
        }


        /* Gets or sets the player's bytes per sample.
         */
        public int BytesPerSample
        {
            get { return waveInfo.BytesPerSample; }
            set { waveInfo.SamplingRate = value; }
        }


        /* Returns the recorded samples as an array of shorts.
         */
        public short[] Samples
        {
            get
            {
                byte[] bytes = new byte[waveInfo.DataLength];
                Marshal.Copy(waveInfo.SaveBuffer, bytes, 0, waveInfo.DataLength);

                short[] data = new short[bytes.Length / waveInfo.BytesPerSample];
                for (int i = 0; i < data.Length; i++)
                {
                    if (waveInfo.BytesPerSample == 1)
                    {
                        data[i] = bytes[i];
                    }
                    else
                    {
                        data[i] = BitConverter.ToInt16(bytes, 2 * i);
                    }
                }
                return data;
            }
        }


        /* Processes the given message and returns true if the player's has
         * stopped playing.
         */
        public bool ProcessMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case MM_WOM_DONE:
                    Terminate();
                    return true;
            }

            WaveProc(m.HWnd, m.Msg, m.WParam, m.LParam);

            return false;
        }


        /* Plays the given samples with the given parameters.
         */
        public void Play(short[][] samples, int samplingRate, int bytesPerSample)
        {
            playing = true;
            paused  = false;

            waveInfo.SamplingRate   = samplingRate;
            waveInfo.BytesPerSample = (short)bytesPerSample;
            waveInfo.NumChannels    = (short)samples.Length;
            waveInfo.DataLength     = samples[0].Length * bytesPerSample
                                    * waveInfo.NumChannels;

            byte[] bytes = new byte[waveInfo.DataLength];

            for (int i = 0; i < waveInfo.NumChannels; i++)
            {
                if (bytesPerSample == 1)
                {
                    for (int j = 0; j < samples[0].Length; j++)
                    {
                        bytes[waveInfo.NumChannels * j + i]
                            = (byte)samples[i][j];
                    }
                }
                else
                {
                    for (int j = 0; j < samples[0].Length; j++)
                    {
                        bytes[2 * waveInfo.NumChannels * j + 2 * i]
                            = BitConverter.GetBytes(samples[i][j])[0];
                        bytes[2 * waveInfo.NumChannels * j + 2 * i + 1]
                            = BitConverter.GetBytes(samples[i][j])[1];
                    }
                }
            }

            waveInfo.SaveBuffer = Marshal.AllocHGlobal(waveInfo.DataLength);
            Marshal.Copy(bytes, 0, waveInfo.SaveBuffer, waveInfo.DataLength);

            SendWaveMsg(handle, WAV_INIT, ref waveInfo);
            SendWaveMsg(handle, WAV_PLAY_BEG, ref waveInfo);
        }


        /* Toggles the wave player's play/pause state.
         */
        public void TogglePause()
        {
            paused = !paused;
            SendWaveMsg(handle, WAV_PLAY_PAUSE, ref waveInfo);
        }


        /* Stops playing.
         */
        public void Stop()
        {
            SendWaveMsg(handle, WAV_PLAY_END, ref waveInfo);
        }


        /* Resets the wave player's state and frees the save buffer.
         */
        private void Terminate()
        {
            playing   = false;
            paused    = false;

            Marshal.FreeHGlobal(waveInfo.SaveBuffer);
        }


        /* Starts recording with the given parameters (mono only).
         */
        public void StartRecord(int samplingRate, int bytesPerSample)
        {
            recording = true;

            waveInfo.SamplingRate   = samplingRate;
            waveInfo.BytesPerSample = (short)bytesPerSample;
            waveInfo.NumChannels    = 1;
            waveInfo.DataLength     = 0;
            waveInfo.SaveBuffer     = IntPtr.Zero;

            SendWaveMsg(handle, WAV_INIT, ref waveInfo);
            SendWaveMsg(handle, WAV_RECORD_BEG, ref waveInfo);
        }


        /* Stops recording.
         */
        public void StopRecord()
        {
            recording = false;

            SendWaveMsg(handle, WAV_RECORD_END, ref waveInfo);
        }
    }
}