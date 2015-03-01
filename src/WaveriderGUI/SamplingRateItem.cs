using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI
{
    /* This class defines a ToolStripMenuItem that contains a sampling rate.
     */
    public class SamplingRateItem : ToolStripMenuItem
    {
        public SamplingRate Value { get; private set; }


        public SamplingRateItem(SamplingRate samplingRate)
        {
            Text  = samplingRate.ToString();
            Value = samplingRate;
        }
    }


    /* This class adds a select functionality to ToolStripItemCollections.
     */
    public static class ToolStripItemCollectionExtension
    {
        /* Selects the item that contains the given sampling rate.
         */
        public static void Select(this ToolStripItemCollection items,
            SamplingRate value)
        {
            foreach (SamplingRateItem item in items)
            {
                item.Checked = (item.Value == value);
            }
        }


        /* Returns the sampling rate of the selected value.
         */
        public static SamplingRate Selected(this ToolStripItemCollection items)
        {
            foreach (SamplingRateItem item in items)
            {
                if (item.Checked)
                {
                    return item.Value;
                }
            }

            return 0;
        }
    }
}