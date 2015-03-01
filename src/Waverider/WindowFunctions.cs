using System;


namespace Waverider
{
    public delegate double WindowFunction(int n);


    /* This class contains windowing functions.
     */
    public static class WindowFunctions
    {
        /* Returns an array of functions that each return a different windowing
         * functions for a window of size N.
         */
        public static Func<int, WindowFunction>[] Functions =
        {
            N => Rectangular(),
            N => Triangular(N),
            N => Hanning(N),
            N => Hamming(N)
        };
        
        
        /* Returns the rectangular window function.
         */
        public static WindowFunction Rectangular()
        {
            return n => 1.0;
        }

        
        /* Returns the triangular window function for window size N.
         */
        public static WindowFunction Triangular(int N)
        {
           return n => 1.0 - Math.Abs((n - (N - 1) / 2.0) / (N / 2.0));
        }


        /* Returns the Hanning window function for window size N.
         */
        public static WindowFunction Hanning(int N)
        {
            return n => 0.5 * (1 - Math.Cos((2 * Math.PI * n) / (N - 1)));
        }


        /* Returns the Hamming window function for window size N.
         */
        public static WindowFunction Hamming(int N)
        {
            return n => 0.54 - 0.46 * Math.Cos((2 * Math.PI * n) / (N - 1));
        }
    }
}