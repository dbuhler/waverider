using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI
{
    public partial class MainForm : Form
    {
        private const string  APP_NAME           = "Waverider";
        private const int     DEFAULT_RESOLUTION = 1000;
        private const int     MAX_RESOLUTION     = 99999;
        
        private WavePlayer player;
        private Signal     signal;
        private string     filename;
        private short[][]  clipboard;
        private int        selectedWindowFunction = 0;


        public MainForm()
        {
            InitializeComponent();
            InitializeSamplingRates();
            ClearAll();

            player = new WavePlayer(this.Handle);
        }


        /* Gets or sets the current sampling rate.
         */
        private int SamplingRate
        {
            get
            {
                return menuItemSamplingRate.DropDownItems.Selected();
            }

            set
            {
                menuItemSamplingRate.DropDownItems.Select(value);
                buttonPlayPause.DropDownItems.Select(value);
            }
        }


        /* Gets or sets the current resolution (number of bins).
         */
        private int Resolution
        {
            get
            {
                int value;

                if (int.TryParse(textBoxResolution.Text, out value))
                {
                    return value;
                }

                return 0;
            }

            set
            {
                textBoxResolution.Text
                    = Math.Min(MAX_RESOLUTION, value).ToString();
            }
        }


        /* Adds the custom wave proc to the form's window proc.
         */
        protected override void WndProc(ref Message m)
        {
            if (player != null && player.ProcessMessage(ref m))
            {
                TogglePlayerButtons(player.State);
            }

            base.WndProc(ref m);
        }


        /* Resets everything.
         */
        private void menuItemNew_Click(object sender, EventArgs e)
        {
            ClearAll();
        }


        /* Triggers an open file dialog.
         */
        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            if ((filename = WaveFiles.OpenFileDialog()) != null)
            {
                LoadSignal(WaveFiles.Open(filename));
            }
        }


        /* Saves a wave file (triggers save file dialog if necessary).
         */
        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (signal == null)
            {
                return;
            }

            if (filename == null)
            {
                filename = WaveFiles.SaveFileDialog();
            }

            if (filename != null)
            {
                WaveFiles.SaveFile(filename, signal);
                UpdateTitleText();
            }
        }


        /* Triggers a save file dialog.
         */
        private void menuItemSaveAs_Click(object sender, EventArgs e)
        {
            if (signal == null)
            {
                return;
            }

            if ((filename = WaveFiles.SaveFileDialog()) != null)
            {
                WaveFiles.SaveFile(filename, signal);
                UpdateTitleText();
            }
        }


        /* Exits the application.
         */
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        /* Cuts the selected samples.
         */
        private void menuItemCut_Click(object sender, EventArgs e)
        {
            if (timeDomain.SampleRange != null)
            {
                clipboard = signal.RemoveSamples(timeDomain.SampleRange);
                timeDomain.UpdateSignal(signal);
                UpdateSignalInfoLabel();
                UpdateTimeHoverLabel();
                UpdateTimeSelectionLabel();
            }
        }


        /* Copies the selected samples.
         */
        private void menuItemCopy_Click(object sender, EventArgs e)
        {
            if (timeDomain.SampleRange != null)
            {
                clipboard = signal.GetSamples(timeDomain.SampleRange);
            }
        }


        /* Pastes the selected samples.
         */
        private void menuItemPaste_Click(object sender, EventArgs e)
        {
            if (timeDomain.SampleRange != null)
            {
                signal.RemoveSamples(timeDomain.SampleRange);
                signal.AddSamples(clipboard, timeDomain.SampleRange.Start);
                timeDomain.UpdateSignal(signal);
                UpdateSignalInfoLabel();
                UpdateTimeHoverLabel();
                UpdateTimeSelectionLabel();
            }
        }


        /* Deletes the selected samples.
         */
        private void menuItemDelete_Click(object sender, EventArgs e)
        {
            if (timeDomain.SampleRange != null)
            {
                signal.RemoveSamples(timeDomain.SampleRange);
                timeDomain.UpdateSignal(signal);
                UpdateSignalInfoLabel();
                UpdateTimeHoverLabel();
                UpdateTimeSelectionLabel();

                if (signal.NumSamples == 0)
                {
                    ClearAll();
                }
            }
        }


        /* Zooms out.
         */
        private void menuItemZoomOut_Click(object sender, EventArgs e)
        {
            if (signal != null)
            {
                timeDomain.ZoomOut();
            }
        }


        /* Zoom in.
         */
        private void menuItemZoomIn_Click(object sender, EventArgs e)
        {
            if (signal != null)
            {
                timeDomain.ZoomIn();
            }
        }


        /* Zooms to width.
         */
        private void menuItemZoomFit_Click(object sender, EventArgs e)
        {
            if (signal != null)
            {
                timeDomain.ZoomToFit();
            }
        }


        /* Zooms to max zoom level.
         */
        private void menuItemZoomMax_Click(object sender, EventArgs e)
        {
            if (signal != null)
            {
                timeDomain.ZoomToMax();
            }
        }


        /* Triggers record dialog.
         */
        private void menuItemRecord_Click(object sender, EventArgs e)
        {
            RecordDialog dlg = new RecordDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filename = null;
                LoadSignal(dlg.Signal);
            }
        }


        /* Plays or pauses the current wave signal.
         */
        private void menuItemPlayPause_Click(object sender, EventArgs e)
        {
            if (signal != null)
            {
                if (!player.IsPlaying)
                {
                    if (timeDomain.SampleRange == null)
                    {
                        player.Play(signal.Samples, SamplingRate, signal.BytesPerSample);
                    }
                    else
                    {
                        player.Play(signal.GetSamples(timeDomain.SampleRange), SamplingRate, signal.BytesPerSample);
                    }
                }
                else
                {
                    player.TogglePause();
                }
                
                TogglePlayerButtons(player.State);
            }
        }


        /* Selects a sampling rate and plays the signal.
         */
        private void menuItemSamplingRate_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SamplingRate = ((SamplingRateItem)e.ClickedItem).Value;

            if (sender == buttonPlayPause)
            {
                menuItemPlayPause.PerformClick();
            }
        }


        /* Stops playback of the signal.
         */
        private void menuItemStop_Click(object sender, EventArgs e)
        {
            if (player.IsPlaying)
            {
                player.Stop();
                TogglePlayerButtons(player.State);
            }
        }


        /* Performs Fourier transformation on the signal.
         */
        private async void buttonFourier_ButtonClick(object sender, EventArgs e)
        {
            if (signal != null)
            {
                await RunFourierAsync((string)buttonFourier.Tag);
            }
        }


        /* Performs the selected Fourier transformation on the signal.
         */
        private async void buttonFourier_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            buttonFourier.Text = e.ClickedItem.Text;
            buttonFourier.Tag  = e.ClickedItem.Tag;

            if (signal != null)
            {
                await RunFourierAsync((string)buttonFourier.Tag);
            }
        }


        /* Filters the signal.
         */
        private async void menuItemFilter_Click(object sender, EventArgs e)
        {
            if (signal != null && freqDomain.BinRange != null)
            {
                await signal.FilterAsync(Resolution, freqDomain.BinRange);
                timeDomain.UpdateSignal(signal);
                await RunFourierAsync((string)buttonFourier.Tag);
            }
        }


        /* Applies the selected windowing function.
         */
        private void menuItemWindow_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SelectWindowFunction(e.ClickedItem);
        }


        /* Disable entry of invalid characters for resolution text box.
         */
        private void textBoxResolution_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift || (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete &&
                e.KeyCode != Keys.Left && e.KeyCode != Keys.Right  &&
                (e.KeyCode < Keys.D0      || e.KeyCode > Keys.D9)  &&
                (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)))

            {
                e.SuppressKeyPress = true;
            }
        }


        /* Clears selection and updates status bar with time domain information.
         */
        private void panelTimeDomain_MouseDown(object sender, MouseEventArgs e)
        {
            if (signal != null)
            {
                freqDomain.ClearSelection();
                UpdateTimeSelectionLabel();
            }
        }


        /* Updates status bar with time domain information.
         */
        private void panelTimeDomain_MouseMove(object sender, MouseEventArgs e)
        {
            if (signal != null)
            {
                UpdateTimeHoverLabel();

                if (timeDomain.IsSelecting())
                {
                    Resolution = timeDomain.SampleRange.Count;
                    UpdateTimeSelectionLabel();
                }
            }
        }


        /* Clears status bar.
         */
        private void panelTimeDomain_MouseLeave(object sender, EventArgs e)
        {
            statusLabelNum.Text   = string.Empty;
            statusLabelValue.Text = string.Empty;
        }


        /* Clears selection and updates status bar with frequency domain information.
         */
        private void freqDomain_MouseDown(object sender, MouseEventArgs e)
        {
            if (freqDomain.Frequencies != null)
            {
                timeDomain.ClearSelection();
                UpdateFreqSelectionLabel();
            }
        }


        /* Updates status bar with frequency domain information.
         */
        private void freqDomain_MouseMove(object sender, MouseEventArgs e)
        {
            if (freqDomain.Frequencies != null)
            {
                UpdateFreqHoverLabel();

                if (freqDomain.IsSelecting())
                {
                    UpdateFreqSelectionLabel();
                }
            }
        }


        /* Clears status bar.
         */
        private void freqDomain_MouseLeave(object sender, EventArgs e)
        {
            statusLabelNum.Text   = string.Empty;
            statusLabelValue.Text = string.Empty;
        }


        /* Unselect the splitter.
         */
        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            timeDomain.Focus();
        }


        /* Load all available sampling rates.
         */
        private void InitializeSamplingRates()
        {
            for (int i = 0; i < WavePlayer.SAMPLING_RATES.Length; i++)
            {
                buttonPlayPause.DropDownItems.Add(
                    new SamplingRateItem(WavePlayer.SAMPLING_RATES[i]));

                menuItemSamplingRate.DropDownItems.Add(
                    new SamplingRateItem(WavePlayer.SAMPLING_RATES[i]));
            }
        }


        /* Reset everything.
         */
        private void ClearAll()
        {
            signal      = null;
            filename    = null;
            clipboard   = null;
            DisableOptions();
            timeDomain.Clear();
            freqDomain.Clear();
            Text = APP_NAME;
            Resolution = DEFAULT_RESOLUTION;
            statusLabelSignalInfo.Text = string.Empty;
            statusLabelNum.Text  = string.Empty;
            statusLabelValue.Text  = string.Empty;
            statusLabelSelection.Text  = string.Empty;
            SamplingRate = 0;
        }


        /* Load the given signal.
         */
        private void LoadSignal(Signal signal)
        {
            if (signal != null)
            {
                this.signal = signal;
                SamplingRate = signal.SamplingRate;
                timeDomain.DrawSignal(signal);
                EnableOptions();
                menuItemFilter.Enabled = false;
                buttonFilter.Enabled   = false;
                UpdateTitleText();
                UpdateSignalInfoLabel();
                statusLabelSelection.Text = string.Empty;
                clipboard = null;
            }
        }


        /* Adjust the player buttons to current player state.
         */
        private void TogglePlayerButtons(WavePlayer.PlayerState state)
        {
            switch (state)
            {
                case WavePlayer.PlayerState.PLAYING:

                    menuItemPlayPause.Enabled = true;
                    menuItemPlayPause.Checked = false;
                    menuItemPlayPause.Text    = "Pause";
                    menuItemPlayPause.Image   = Properties.Resources.IconPause24;
                    menuItemStop.Enabled      = true;
                    buttonPlayPause.Enabled   = true;
                    buttonPlayPause.Text      = "Pause";
                    buttonPlayPause.Image     = Properties.Resources.IconPause24;
                    buttonStop.Enabled        = true;
                    break;

                case WavePlayer.PlayerState.PAUSED:

                    menuItemPlayPause.Enabled = true;
                    menuItemPlayPause.Checked = true;
                    menuItemPlayPause.Text    = "Paused";
                    menuItemPlayPause.Image   = Properties.Resources.IconPause24;
                    menuItemStop.Enabled      = true;
                    buttonPlayPause.Enabled   = true;
                    buttonPlayPause.Text      = "Play";
                    buttonPlayPause.Image     = Properties.Resources.IconPlay24;
                    buttonStop.Enabled        = true;
                    break;

                case WavePlayer.PlayerState.IDLE:

                    menuItemPlayPause.Enabled = true;
                    menuItemPlayPause.Checked = false;
                    menuItemPlayPause.Text    = "Play";
                    menuItemPlayPause.Image   = Properties.Resources.IconPlay24;
                    menuItemStop.Enabled      = false;
                    buttonPlayPause.Enabled   = true;
                    buttonPlayPause.Text      = "Play";
                    buttonPlayPause.Image     = Properties.Resources.IconPlay24;
                    buttonStop.Enabled        = false;
                    break;

                default:

                    break;
            }
        }


        /* Enable menu itmes and tool bar buttons.
         */
        private void EnableOptions()
        {
            menuItemSave.Enabled         = true;
            menuItemSaveAs.Enabled       = true;
            menuItemCut.Enabled          = true;
            menuItemCopy.Enabled         = true;
            menuItemPaste.Enabled        = true;
            menuItemDelete.Enabled       = true;
            menuItemZoomOut.Enabled      = true;
            menuItemZoomIn.Enabled       = true;
            menuItemZoomFit.Enabled      = true;
            menuItemZoomMax.Enabled      = true;
            menuItemPlayPause.Enabled    = true;
            menuItemSamplingRate.Enabled = true;
            menuItemWindow.Enabled       = true;
            menuItemDFT.Enabled          = true;
            menuItemFFT.Enabled          = true;

            buttonSave.Enabled           = true;
            buttonCut.Enabled            = true;
            buttonCopy.Enabled           = true;
            buttonPaste.Enabled          = true;
            buttonDelete.Enabled         = true;
            buttonZoomOut.Enabled        = true;
            buttonZoomIn.Enabled         = true;
            buttonZoomFit.Enabled        = true;
            buttonZoomMax.Enabled        = true;
            buttonPlayPause.Enabled      = true;
            buttonWindow.Enabled         = true;
            buttonFourier.Enabled        = true;
            
            labelResolution.Enabled      = true;
            textBoxResolution.Enabled    = true;
        }


        /* Disable menu items and tool bar buttons.\
         */
        private void DisableOptions()
        {
            menuItemSave.Enabled         = false;
            menuItemSaveAs.Enabled       = false;
            menuItemCut.Enabled          = false;
            menuItemCopy.Enabled         = false;
            menuItemPaste.Enabled        = false;
            menuItemDelete.Enabled       = false;
            menuItemZoomIn.Enabled       = false;
            menuItemZoomOut.Enabled      = false;
            menuItemZoomFit.Enabled      = false;
            menuItemZoomMax.Enabled      = false;
            menuItemPlayPause.Enabled    = false;
            menuItemStop.Enabled         = false;
            menuItemSamplingRate.Enabled = false;
            menuItemWindow.Enabled       = false;
            menuItemDFT.Enabled          = false;
            menuItemFFT.Enabled          = false;
            menuItemFilter.Enabled       = false;

            buttonSave.Enabled           = false;
            buttonCut.Enabled            = false;
            buttonCopy.Enabled           = false;
            buttonPaste.Enabled          = false;
            buttonDelete.Enabled         = false;
            buttonZoomIn.Enabled         = false;
            buttonZoomOut.Enabled        = false;
            buttonZoomFit.Enabled        = false;
            buttonZoomMax.Enabled        = false;
            buttonPlayPause.Enabled      = false;
            buttonStop.Enabled           = false;
            buttonWindow.Enabled         = false;
            buttonFourier.Enabled        = false;
            buttonFilter.Enabled         = false;

            labelResolution.Enabled      = false;
            textBoxResolution.Enabled    = false;
        }


        /* Set the current file's name in the application title bar.
         */
        private void UpdateTitleText()
        {
            Text = String.Format("{0} - {1}",
                APP_NAME,
                filename != null ? Path.GetFileName(filename) : "(unnamed)");
        }


        /* Update status bar label.
         */
        private void UpdateSignalInfoLabel()
        {
            statusLabelSignalInfo.Text = string.Format(
                "{0}, {1}-bit {2} | {3:N0} samples ({4:N3}s)",
                new SamplingRate(signal.SamplingRate),
                signal.BytesPerSample * 8,
                signal.NumChannels == 1 ? "Mono" : "Stereo",
                signal.NumSamples,
                signal.GetSecondsForSample(signal.NumSamples));
        }


        /* Update status bar label.
         */
        private void UpdateTimeHoverLabel()
        {
            int sampleNumber = timeDomain.SampleNumber;

            if (sampleNumber < 0 || sampleNumber >= signal.NumSamples)
            {
                statusLabelNum.Text   = string.Empty;
                statusLabelValue.Text = string.Empty;
                return;
            }

            statusLabelNum.Text = string.Format(
                "Sample: {0:N0} ({1:N3}s)",
                sampleNumber + 1,
                signal.GetSecondsForSample(sampleNumber));

            statusLabelValue.Text = string.Format(
                "Amplitude: {0:N0}",
                signal.Samples[0][sampleNumber]);
        }


        /* Update status bar label.
         */
        private void UpdateFreqHoverLabel()
        {
            int freqBin = freqDomain.BinNumber;

            if (freqDomain.Frequencies.ContainsKey(freqBin))
            {
                double freq = 1.0 * freqBin * signal.SamplingRate / Resolution;

                statusLabelNum.Text = string.Format(
                    "Bin: {0:N0} ({1:N1} Hz)",
                    freqBin,
                    freq);

                statusLabelValue.Text = string.Format(
                    "Amplitude: {0:N1}",
                    freqDomain.Frequencies[freqBin]);
            }
        }


        /* Update status bar label.
         */
        private void UpdateTimeSelectionLabel()
        {
            if (timeDomain.SampleRange == null)
            {
                statusLabelSelection.Text = string.Empty;
            }
            else
            {
                int begin = timeDomain.SampleRange.Start + 1;
                int end   = timeDomain.SampleRange.End;

                statusLabelSelection.Text = string.Format(
                    "Selection: {0:N0}{1}",
                    begin,
                    begin == end ? string.Empty : string.Format(" - {0:N0}", end));
            }
        }


        /* Update status bar label.
         */
        private void UpdateFreqSelectionLabel()
        {
            if (freqDomain.BinRange == null)
            {
                statusLabelSelection.Text = string.Empty;
            }
            else
            {
                int begin = freqDomain.BinRange.Start;
                int end   = freqDomain.BinRange.End - 1;

                statusLabelSelection.Text = string.Format(
                    "Selection: {0:N0}{1}",
                    begin,
                    begin == end ? string.Empty : string.Format(" - {0:N0}", end));
            }
        }


        /* Synchronize selection of windowing function.
         */
        private void SelectWindowFunction(ToolStripItem selectedItem)
        {
            buttonWindow.Text = selectedItem.Text;
            int index         = int.Parse(selectedItem.Tag.ToString());

            foreach (ToolStripMenuItem item in buttonWindow.DropDownItems)
            {
                item.Checked = false;
            }

            foreach (ToolStripMenuItem item in menuItemWindow.DropDownItems)
            {
                item.Checked = false;
            }

            ((ToolStripMenuItem)menuItemWindow.DropDownItems[index]).Checked = true;
            ((ToolStripMenuItem)buttonWindow.DropDownItems[index]).Checked = true;

            selectedWindowFunction = index;
        }


        /* Perform Fourier transformation.
         */
        private async Task RunFourierAsync(string fourierTag)
        {
            if (Resolution == 0)
            {
                return;
            }

            freqDomain.Clear();
            freqDomain.ClearSelection();
            statusLabelSelection.Text = string.Empty;
            
            labelLoading.Visible = true;

            Range range = timeDomain.SampleRange ?? new Range(0, signal.NumSamples);

            Resolution = Math.Min(Resolution, range.Count);

            if (fourierTag.Equals("FFT"))
            {
                Resolution = (int)Math.Pow(2, Math.Floor(Math.Log(Resolution, 2)));
            }

            signal.Window = WindowFunctions.Functions[selectedWindowFunction](Resolution);
            
            freqDomain.DrawFourier(await signal.GetFrequenciesAsync(
                Resolution, range, fourierTag.Equals("FFT")));

            labelLoading.Visible   = false;
            menuItemFilter.Enabled = true;
            buttonFilter.Enabled   = true;
        }


        /* Update and validate resolution.
         */
        private void UpdateResolution()
        {
            int maximum = MAX_RESOLUTION;

            if (signal != null && maximum > signal.NumSamples)
            {
                maximum = signal.NumSamples;
            }

            if (Resolution > maximum)
            {
                Resolution = maximum;
            }
        }
    }
}