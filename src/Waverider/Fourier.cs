using System;
using System.Numerics;


namespace Waverider
{
    /* This class contains static methods for doing Fourier transformations.
     */
    public static class Fourier
    {
        /* Applies DFT to the array x of complex numbers and returns the
         * array of resulting Fourier coefficients.
         */
        public static Complex[] DFT(Complex[] x)
        {
            int N = x.Length;
            
            Complex[] X = new Complex[N];
            
            for (int n = 0; n < N; n++)
            {
                X[n] = 0;

                for (int t = 0; t < N; t++)
                {
                    X[n] += x[t] * cis2pi(-1.0 * n * t / N);
                }
            }

            return X;
        }


        /* Applies inverse DFT to the array X of complex numbers and returns
         * the array of resulting complex numbers.
         */
        public static Complex[] InverseDFT(Complex[] X)
        {
            int N = X.Length;
            
            Complex[] x = new Complex[N];

            for (int t = 0; t < N; t++)
            {
                x[t] = 0;

                for (int n = 0; n < N; n++)
                {
                    x[t] += X[n] * cis2pi(+1.0 * n * t / N);
                }

                x[t] /= N;
            }

            return x;
        }


        /* Applies Fast Fourier to the array x of complex numbers and returns
         * the array of resulting Fourier coefficients.
         */
        public static Complex[] FFT(Complex[] x)
        {
            int N = x.Length;

            if (!isPowerOfTwo(N))
            {
                throw new ArgumentException(
                    "array length must be power of two");
            }

            return FFT(x, N, 0, 1);
        }


        /* Implementation of the Cooley–Tukey FFT algorithm (radix-2 DIT).
         */
        private static Complex[] FFT(Complex[] x, int N, int p, int s)
        {
            Complex[] X = new Complex[N];
            
            if (N == 1)
            {
                X[0] = x[p];
            }
            else
            {
                Array.Copy(FFT(x, N / 2, p,     2 * s), 0, X, 0,     N / 2);
                Array.Copy(FFT(x, N / 2, p + s, 2 * s), 0, X, N / 2, N / 2);

                for (int n = 0; n < N/2; n++)
                {
                    Complex temp = X[n];

                    X[n]         = temp + cis2pi(-1.0 * n / N) * X[n + N / 2];
                    X[n + N / 2] = temp - cis2pi(-1.0 * n / N) * X[n + N / 2];
                }
            }

            return X;
        }


        /* Returns whether n is a power of 2.
         */
        private static bool isPowerOfTwo(int n)
        {
            return (n & (n - 1)) == 0;
        }


        /* Returns the complex number cos(2*pi*phi) + i*sin(2*pi*phi).
         */
        private static Complex cis2pi(double phi)
        {
            return Complex.Exp(2 * Math.PI * Complex.ImaginaryOne * phi);
        }
    }
}