using System;
using System.IO;
using System.Text;


namespace Waverider
{
    /* This class provides functionality to read and write wave files.
     */
    public static class WaveFile
    {
        private const string RIFF_ID   = "RIFF";
        private const string WAVE_ID   = "WAVE";
        private const string FORMAT_ID = "fmt ";
        private const string DATA_ID   = "data";

        private const string INVALID_FORMAT     = "Invalid file format.";
        private const string UNSUPPORTED_FORMAT = "Unsupported file format.";


        /* Reads a wave file and returns the content as a signal.
         */
        public static Signal Read(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            
            byte[] buffer;
            int    length;

            buffer = reader.ReadBytes(16);

            if (buffer.Length < 16                                       ||
                !Encoding.ASCII.GetString(buffer,  0, 4).Equals(RIFF_ID) ||
                !Encoding.ASCII.GetString(buffer,  8, 4).Equals(WAVE_ID) ||
                !Encoding.ASCII.GetString(buffer, 12, 4).Equals(FORMAT_ID))
            {
                throw new Exception(INVALID_FORMAT);
            }

            length = reader.ReadInt32();
            buffer = reader.ReadBytes(16);

            short audioFormat   = BitConverter.ToInt16(buffer,  0);
            short numChannels   = BitConverter.ToInt16(buffer,  2);
            int   samplingRate  = BitConverter.ToInt32(buffer,  4);
            short bitsPerSample = BitConverter.ToInt16(buffer, 14);

            if ((audioFormat   != 1)                        ||
                (numChannels   != 1 && numChannels   !=  2) ||
                (bitsPerSample != 8 && bitsPerSample != 16))
            {
                throw new Exception(UNSUPPORTED_FORMAT);
            }

            buffer = reader.ReadBytes(4);

            if (!Encoding.ASCII.GetString(buffer, 0, 4).Equals(DATA_ID))
            {
                throw new Exception(UNSUPPORTED_FORMAT);
            }

            length = reader.ReadInt32();

            short   bytesPerSample = (short)(bitsPerSample / 8);
            short[] samples        = new short[length / bytesPerSample];
            
            for (int i = 0; i < samples.Length; i++)
            {
                samples[i] = bytesPerSample == 1
                    ? reader.ReadByte()
                    : reader.ReadInt16();
            }

            reader.Dispose();

            return new Signal(samples, samplingRate, bytesPerSample, numChannels);
        }


        /* Writes the given signal to a wave file.
         */
        public static void Write(Stream stream, Signal signal)
        {
            BinaryWriter writer = new BinaryWriter(stream);

            short sampleSize = (short)(signal.NumChannels * signal.BytesPerSample);
            int   dataLength = signal.NumSamples * sampleSize;

            writer.Write(RIFF_ID.ToCharArray());
            writer.Write(dataLength + 36);
            writer.Write(WAVE_ID.ToCharArray());
            writer.Write(FORMAT_ID.ToCharArray());
            writer.Write(0x10);
            writer.Write((short)0x01);
            writer.Write((short)signal.NumChannels);
            writer.Write(signal.SamplingRate);
            writer.Write(signal.SamplingRate * sampleSize);
            writer.Write(sampleSize);
            writer.Write((short)(signal.BytesPerSample * 8));
            writer.Write(DATA_ID.ToCharArray());
            writer.Write(dataLength);

            for (int j = 0; j < signal.NumSamples; j++)
            {
                for (int i = 0; i < signal.NumChannels; i++)
                {
                    if (signal.BytesPerSample == 1)
                    {
                        writer.Write((byte)signal.Samples[i][j]);
                    }
                    else
                    {
                        writer.Write((short)signal.Samples[i][j]);
                    }
                }
            }

            writer.Dispose();
        }
    }
}