using System;
using System.Numerics;
using System.Threading.Tasks;


namespace Waverider
{
    /* This class defines a signal, consisting of samples and other information
     * such as sampling rate. The class also allows to modify the signal in
     * certain ways.
     */ 
    public class Signal
    {
        /* Creates a new signal with the given samples, sampling rate, and
         * bytes per sample. The samples are given as an array of sample arrays
         * for each channel.
         */
        public Signal(short[][] samples, int samplingRate, int bytesPerSample)
        {
            Samples        = samples;
            SamplingRate   = samplingRate;
            BytesPerSample = bytesPerSample;
            Window = WindowFunctions.Rectangular();
        }


        /* Creates a new signal with the given samples, sampling rate, bytes
         * per sample, and number of channels. The samples are given as one
         * array of samples, alternating for the channels.
         */
        public Signal(short[] samples, int samplingRate, int bytesPerSample,
            int numChannels)
        {
            Samples        = new short[numChannels][];
            SamplingRate   = samplingRate;
            BytesPerSample = bytesPerSample;
            Window = WindowFunctions.Rectangular();

            int numSamples = samples.Length / numChannels;

            for (int i = 0; i < numChannels; i++)
            {
                Samples[i] = new short[numSamples];

                for (int j = 0; j < numSamples; j++)
                {
                    Samples[i][j] = samples[numChannels * j + i];
                }
            }
        }


        public short[][]      Samples        { get; private set; }
        public int            SamplingRate   { get; private set; }
        public int            BytesPerSample { get; private set; }
        public WindowFunction Window         { get; set; }


        /* Returns the number of channels.
         */
        public int NumChannels
        {
            get
            {
                if (Samples == null)
                {
                    return 0;
                }

                return Samples.Length;
            }
        }


        /* Returns the number of samples (per channel).
         */
        public int NumSamples
        {
            get
            {
                if (Samples == null || Samples[0] == null)
                {
                    return 0;
                }

                return Samples[0].Length;
            }
        }


        /* Returns the temporal position of a sample in seconds.
         */
        public double GetSecondsForSample(int sampleNumber)
        {
            return 1.0 * sampleNumber / SamplingRate;
        }


        /* Returns the samples from the given range.
         */
        public short[][] GetSamples(Range range)
        {
            return GetSamples(range.Start, range.End);
        }


        /* Returns the samples from the range t1 (inclusive) to t2 (exclusive).
         */
        public short[][] GetSamples(int t1, int t2)
        {
            short[][] samples = new short[NumChannels][];

            for (int i = 0; i < NumChannels; i++)
            {
                samples[i] = new short[t2 - t1];

                Array.Copy(Samples[i], t1, samples[i], 0, t2 - t1);
            }

            return samples;
        }


        /* Inserts the given samples at the given position.
         */
        public void AddSamples(short[][] samples, int position)
        {
            short[][] newSamples = new short[NumChannels][];

            for (int i = 0; i < NumChannels; i++)
            {
                int n = samples[i].Length;
                
                newSamples[i] = new short[NumSamples + n];

                Array.Copy(Samples[i], 0, newSamples[i], 0, position);
                Array.Copy(samples[i], 0, newSamples[i], position, n);
                Array.Copy(Samples[i], position, newSamples[i],
                    position + n, NumSamples - position);
            }

            Samples = newSamples;
        }


        /* Removes the given range from the samples.
         */
        public short[][] RemoveSamples(Range range)
        {
            return RemoveSamples(range.Start, range.Start + range.Count);
        }


        /* Removes the samples t1 (inclusive) to t2 (exclusive).
         */
        public short[][] RemoveSamples(int t1, int t2)
        {
            short[][] newSamples     = new short[NumChannels][];
            short[][] removedSamples = new short[NumChannels][];

            int n = NumSamples - (t2 - t1);

            for (int i = 0; i < NumChannels; i++)
            {
                removedSamples[i] = new short[t2 - t1];
                newSamples[i]     = new short[NumSamples - (t2 - t1)];

                Array.Copy(Samples[i], 0, newSamples[i], 0, t1);
                Array.Copy(Samples[i], t1, removedSamples[i], 0, t2 - t1);
                Array.Copy(Samples[i], t2, newSamples[i], t1, NumSamples - t2);
            }

            Samples = newSamples;

            return removedSamples;
        }


        /* Returns the Fourier coefficients for each window of length n in the
         * given sample range for the given channel, using either DFT or FFT.
         */
        public async Task<Complex[][]> GetFourierAsync(int n, Range range,
            int channel, bool fastFourier)
        {
            int m = range.Count;

            Complex[]   samples = new Complex[n];
            Complex[][] fourier = new Complex[m / n][];

            for (int f = 0; f < m / n; f++)
            {
                for (int t = 0; t < n; t++)
                {
                    samples[t] = Window(t) *
                        Samples[channel][range.Start + f * n + t];
                }

                if (fastFourier)
                {
                    fourier[f] = await Task.Factory.StartNew(
                        () => Fourier.FFT(samples));
                }
                else
                {
                    fourier[f] = await Task.Factory.StartNew(
                        () => Fourier.DFT(samples));
                }
            }

            return fourier;
        }


        /* Returns the bin-amplitude map of all frequencies, taking the maximum
         * over all windows and channels, using the given window size over the
         * given sample range, and using either DFT or FFT.
         */
        public async Task<FrequencyMap> GetFrequenciesAsync(int n, Range range,
            bool fastFourier)
        {
            int m = range.Count;

            FrequencyMap[] maps = new FrequencyMap[m / n * NumChannels];

            for (int k = 0; k < NumChannels; k++)
            {
                Complex[][] fourier = await GetFourierAsync(n, range, k,
                    fastFourier);

                for (int i = 0; i < m / n; i++)
                {
                    maps[i + m / n * k] = GetFrequencyMap(fourier[i]);
                }
            }

            FrequencyMap map = new FrequencyMap();

            for (int f = 1; f <= n / 2; f++)
            {
                map.Add(f, 0.0);

                for (int i = 0; i < maps.Length; i++)
                {
                    map[f] = Math.Max(map[f], maps[i][f]);
                }
            }

            return map;
        }


        /* Returns the bin-amplitude map of all frequencies from the given
         * array of Fourier coefficients.
         */
        public FrequencyMap GetFrequencyMap(Complex[] fourier)
        {
            FrequencyMap map = new FrequencyMap();

            int n = fourier.Length;

            for (int f = 1; f <= (n - 1) / 2; f++)
            {
                map.Add(f, 2 * fourier[f].Magnitude / n);
            }

            if (n % 2 == 0)
            {
                map.Add(n / 2, fourier[n / 2].Magnitude / n);
            }

            return map;
        }


        /* Filters the signal using convolution with a filter of size n that
         * keeps the given range of frequency bins.
         */
        public async Task FilterAsync(int n, Range binRange)
        {
            short[][] filteredSamples = new short[NumChannels][];

            Complex[] filter = new Complex[n];

            for (int f = 0; f < filter.Length; f++)
            {
                if (f >= binRange.Start && f < binRange.End)
                {
                    filter[f] = Complex.One + Complex.ImaginaryOne;
                }
                else
                {
                    filter[f] = Complex.Zero;
                }
            }
            
            for (int i = 0; i < NumChannels; i++)
            {
                filteredSamples[i] = await Task.Factory.StartNew(
                    () => Convolve(Samples[i], Fourier.InverseDFT(filter)));
            }

            Samples = filteredSamples;
        }


        /* Convolves the given samples with the given filter.
         */
        private short[] Convolve(short[] samples, Complex[] filter)
        {
            for (int t = 0; t < samples.Length; t++)
            {
                double filteredValue = 0.0;

                for (int i = 0; i < filter.Length && t + i < samples.Length; i++)
                {
                    filteredValue += filter[i].Real * samples[t + i];
                }

                samples[t] = (short)filteredValue;
            }

            return samples;
        }
    }
}