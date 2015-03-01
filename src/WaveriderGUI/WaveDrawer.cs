using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI
{
    /* Provides functionality for drawing and selecting singals in both time
     * and frequency domain.
     */
    public static class WaveDrawer
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(int color);

        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern bool PatBlt(IntPtr hdc, int left, int top,
            int width, int height, int rop);


        private const int MAX_RESOLUTION = 20;
        private const int SELECT_COLOR   = 0x66CC66;
        private const int XOR_MODE       = 0x005A0049;
        public  const int RECT_WIDTH     = 10;
        public  const int RECT_SPACING   = 2;
        public  const int MARGIN         = 10;



        /* Invalidates the control from left to right (inclusive).
         */
        public static void Invalidate(Control control, int left, int right)
        {
            control.Invalidate(new Rectangle(
                left, 0, right - left + 1, control.Height));
        }
        

        /* Draws a rectangle with the given coordinates in XOR mode on the
         * given graphics object.
         */
        public static void DrawXorRange(Graphics g, int left, int right,
            int height)
        {
            IntPtr hdc   = g.GetHdc();
            IntPtr brush = CreateSolidBrush(SELECT_COLOR);
            SelectObject(hdc, brush);
            PatBlt(hdc, left, 0, right - left + 1, height, XOR_MODE);
            g.ReleaseHdc();
        }

        
        /* Draws the given signal on the given graphics object of given width
         * and height, using the scroll position and sample resolution.
         */
        public static void DrawSignal(Graphics g, Rectangle rect, Signal signal,
            int width, int height, int pos, double samplesPerPixel)
        {
            double resolution = Math.Min(samplesPerPixel, MAX_RESOLUTION);
            double yScale     = (double) height
                              / Math.Pow(2, 8 * signal.BytesPerSample)
                              / signal.NumChannels;

            for (int k = 0; k < signal.NumChannels; k++)
            {
                GraphicsPath path = new GraphicsPath();

                double y0 = (double)height * (2 * k + 1)
                          / (2 * signal.NumChannels);

                if (signal.BytesPerSample == 1)
                {
                    y0 += (double)height / (2 * signal.NumChannels);
                }

                int x0 = Math.Max(rect.Left - 1, 0);
                int x1 = Math.Min(
                    Math.Min(rect.Right + 1, width),
                    signal.Samples[k].Length);

                int n = Math.Min(
                    (int)((x1 - x0) * resolution),
                    signal.Samples[k].Length);

                PointF[] points = new PointF[n];

                for (int i = 0; i < points.Length; i++)
                {
                    double x = i / resolution;
                    
                    points[i] = new PointF(
                        (float)(x0 + x),
                        (float)(y0 - yScale * signal.Samples[k][
                            (int)((pos + x0 + x) * samplesPerPixel)]));
                }

                for (int i = 1; i < points.Length; i++)
                {
                    path.AddLine(points[i - 1], points[i]);
                }

                g.DrawPath(Pens.Lime, path);
            }
        }


        /* Draws the given amplitudes as frequency bins on the given graphics
         * object of given width and height, using the scroll position and
         * highlighting currently selected bins.
         */
        public static void DrawFourier(Graphics g, Rectangle rect,
            FrequencyMap amplitudes, int width, int height, int pos,
            Range selection)
        {
            RectangleF[] rects = new RectangleF[amplitudes.Count];
            double yScale = (double)(height - 2 * MARGIN)
                          / amplitudes.MaxAmplitude;

            int i = 0;

            foreach (int key in amplitudes.Keys)
            {
                double amplitude = amplitudes[key];

                rects[i] = new RectangleF(
                    (float) (MARGIN + (RECT_WIDTH + RECT_SPACING) * i - pos),
                    (float) (height - MARGIN - yScale * amplitude),
                    (float) RECT_WIDTH,
                    (float) (yScale * amplitude));

                if (selection != null && 
                    selection.Start <= (i + 1) &&
                    selection.End   >  (i + 1))
                {
                    g.FillRectangle(Brushes.OrangeRed, rects[i]);
                }
                else
                {
                    g.FillRectangle(Brushes.Lime, rects[i]);
                }

                ++i;
            }
        }
    }
}