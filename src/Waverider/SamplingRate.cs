namespace Waverider
{
    /* This struct represents a sampling rate value.
     */
    public struct SamplingRate
    {
        private int value;


        /* Creates a new sampling rate struct with the given value.
         */
        public SamplingRate(int value)
        {
            this.value = value;
        }


        /* Implicitly casts an int to a sampling rate.
         */
        public static implicit operator SamplingRate(int value)
        {
            return new SamplingRate(value);
        }


        /* Implicitly casts a sampling rate to an int.
         */
        public static implicit operator int(SamplingRate s)
        {
            return s.value;
        }


        /* Returns the sampling rate's string representation.
         */
        public override string ToString()
        {
            return string.Format("{0:N0} Hz", value);
        }
    }
}