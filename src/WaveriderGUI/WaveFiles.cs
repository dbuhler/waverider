using System;
using System.IO;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI
{
    /* This class provides the GUI functionality for opening and saving wave
     * files.
     */
    public static class WaveFiles
    {
        public const string FILTER =
            "Waveform audio files (*.wav)|*.wav|All files (*.*)|*.*";


        /* Triggers an open file dialog and returns the chosen filename.
         */
        public static string OpenFileDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = FILTER;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }

            return null;
        }


        /* Triggers a save file dialog and returns the chosen filename.
         */
        public static string SaveFileDialog()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = FILTER;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.FileName;
            }

            return null;
        }
        
        
        /* Reads and returns the signal the specified wave file.
         */
        public static Signal Open(string filename)
        {
            Stream stream = null;
            Signal signal = null;

            try
            {
                stream = new FileStream(filename, FileMode.Open);
                signal = WaveFile.Read(stream);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return signal;
        }


        /* Writes the given signal to the specified wave file.
         */
        public static bool SaveFile(string filename, Signal signal)
        {
            Stream stream = null;

            try
            {
                stream = new FileStream(filename, FileMode.Create);
                WaveFile.Write(stream, signal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return true;
        }
    }
}