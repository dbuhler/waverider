using System;
namespace Waverider
{
    /* This class describes a range of integers, defined by a starting value
     * and the number of values (range width).
     */
    public class Range
    {
        /* Create a new range with the given starting value and length.
         */
        public Range(int start, int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("count must be positive");
            }
            
            Start = start;
            Count = count;
        }


        public int Start { get; private set; }
        public int Count { get; private set; }


        /* Returns the value after the last value in the range.
         */
        public int End
        {
            get { return Start + Count; }
        }


        /* Sets the left-most value of the range.
         */
        public void SetLeft(int left)
        {
            Start = left;
        }


        /* Sets the right-most value of the range.
         */
        public void SetRight(int right)
        {
            Count = right - Start + 1;

            if (Count < 1)
            {
                throw new ArgumentException("count must be positive");
            }
        }
    }
}
