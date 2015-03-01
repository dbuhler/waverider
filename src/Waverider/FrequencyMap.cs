using System.Collections.Generic;


namespace Waverider
{
    /* This class defines a key-value map for storing frequency bins and their
     * amplitudes. The key is the frequency bin number and the value is the
     * amplitude for this bin.
     */
    public class FrequencyMap : Dictionary<int, double>
    {
        /* Returns the maximum value in the dictionary or zero if there are no
         * entries in the dictionary.
         */
        public double MaxAmplitude
        {
            get
            {
                double max = 0.0;
                
                foreach (int key in this.Keys)
                {
                    if (this[key] > max)
                    {
                        max = this[key];
                    }
                }

                return max;
            }
        }
    }
}