using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI
{
    public partial class RecordDialog : Form
    {
        [DllImport("waveio.dll")]
        public static extern IntPtr WaveProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);


        private WavePlayer player;
        private bool recorded = false;


        public RecordDialog()
        {
            InitializeComponent();

            player = new WavePlayer(this.Handle);

            comboBoxSamplingRate.DataSource = WavePlayer.SAMPLING_RATES;
            comboBoxSamplingRate.SelectedIndex = 5;
        }


        public Signal Signal { get; set; }


        /* Add custom wave proc to form's window proc.
         */
        protected override void WndProc(ref Message m)
        {
            WaveProc(m.HWnd, m.Msg, m.WParam, m.LParam);
            base.WndProc(ref m);
        }


        /* Starts recording with the current parameters.
         */
        private void buttonRecord_Click(object sender, EventArgs e)
        {
            if (player.State != WavePlayer.PlayerState.RECORDING)
            {
                recorded = false;
                buttonBegRecord.Visible = false;
                buttonEndRecord.Visible = true;

                player.StartRecord(
                    (SamplingRate) comboBoxSamplingRate.SelectedValue,
                    radioButton8.Checked ? 1 : 2);
            }
        }


        /* Stops recording.
         */
        private void buttonEndRecord_Click(object sender, EventArgs e)
        {
            if (player.State == WavePlayer.PlayerState.RECORDING)
            {
                player.StopRecord();

                recorded = true;
                buttonBegRecord.Visible = true;
                buttonEndRecord.Visible = false;
            }
        }


        /* Creates a signal from the recorded data and closes the dialog.
         */
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (recorded)
            {
                Signal = new Signal(
                    player.Samples,
                    player.SamplingRate,
                    player.BytesPerSample,
                    1);

                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}