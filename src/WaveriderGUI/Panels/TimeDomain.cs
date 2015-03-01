using System;
using System.Drawing;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI.Panels
{
    public class TimeDomain : GraphicsPanel
    {
        private Signal signal;
        private double currentZoomLevel;

        private const double SMALL_ZOOM_STEP = 1.05;
        private const double LARGE_ZOOM_STEP = 2.00;
        private const double MAX_ZOOM_LEVEL  = 1.0;


        public TimeDomain()
            : base()
        {
            signal = null;
            currentZoomLevel = MaxZoomLevel;
        }


        /* Gets the minimum zoom level (zoom to fit width).
         */
        private double MinZoomLevel
        {
            get
            {
                if (signal == null ||
                    signal.NumSamples < Width)
                {
                    return 1.0;
                }

                return (double)Width / signal.NumSamples;
            }
        }


        /* Gets the maximum zoom level.
         */
        private double MaxZoomLevel { get { return MAX_ZOOM_LEVEL; } }


        /* Returns the currently selected sample number.
         */
        public int SampleNumber
        {
            get { return getSampleNumber(cursorCurrentPos); }
        }


        /* Returns the currently selected sample range.
         */
        public Range SampleRange
        {
            get
            {
                if (selection == null)
                {
                    return null;
                }

                int left  = getSampleNumber(selection.Start);
                int right = getSampleNumber(selection.Start + selection.Count);

                if (left == right)
                {
                    return null;
                }

                return new Range(left, right - left);
            }
        }


        /* Starts selecting.
         */
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (signal != null)
            {
                selecting = false;
                selection = null;
                Refresh();

                if (e.Button == MouseButtons.Left &&
                    e.X < signal.NumSamples)
                {
                    selecting = true;

                    cursorInitialPos  = e.X;
                    cursorPreviousPos = e.X;
                    cursorCurrentPos  = e.X;

                    selection = new Range(e.X, 1);
                }
            }

            base.OnMouseDown(e);
        }


        /* Updates selecting.
         */
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (signal != null)
            {
                cursorPreviousPos = cursorCurrentPos;
                cursorCurrentPos  = Math.Min(Math.Max(e.X, 0),
                    Math.Min(signal.NumSamples, Width) - 1);

                if (selecting)
                {
                    selection.SetLeft(
                        Math.Min(cursorInitialPos, cursorCurrentPos));
                    selection.SetRight(
                        Math.Max(cursorInitialPos, cursorCurrentPos));

                    WaveDrawer.Invalidate(this,
                        Math.Min(cursorPreviousPos, cursorCurrentPos),
                        Math.Max(cursorPreviousPos, cursorCurrentPos));
                }
            }

            base.OnMouseMove(e);
        }


        /* Ends selecting.
         */
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (selecting)
            {
                selecting = false;
                WaveDrawer.Invalidate(this,
                    selection.Start, selection.End - 1);
            }

            base.OnMouseUp(e);
        }


        /* Zooms in or out by SMALL_ZOOM_STEP.
         */
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (signal != null)
            {
                if (e.Delta > 0)
                {
                    setZoomLevel(currentZoomLevel * SMALL_ZOOM_STEP);
                }
                else
                {
                    setZoomLevel(currentZoomLevel / SMALL_ZOOM_STEP);
                }
            }
        }


        /* Draws the signal and XOR selection.
         */
        protected override void OnPaint(PaintEventArgs e)
        {
            if (signal == null)
            {
                return;
            }

            WaveDrawer.DrawSignal(
                e.Graphics, e.ClipRectangle, signal,
                Width,
                Height - SCROLL_BAR_SIZE,
                -AutoScrollPosition.X,
                1.0 / currentZoomLevel);

            if (selection != null)
            {
                WaveDrawer.DrawXorRange(e.Graphics,
                    selection.Start, selection.End - 1, Height);
            }

            base.OnPaint(e);
        }


        /* Adjust zoom level on resize.
         */
        protected override void OnResize(EventArgs e)
        {
            setZoomLevel(currentZoomLevel);
            base.OnResize(e);
        }


        /* Clears and resets the panel.
         */
        public override void Clear()
        {
            AutoScroll       = false;
            signal           = null;
            currentZoomLevel = 1.0;
            base.Clear();
        }


        /* Draws the given signal on the panel.
         */
        public void DrawSignal(Signal signal)
        {
            AutoScroll  = true;
            this.signal = signal;
            ZoomToFit();
            Refresh();
        }


        /* Updates the signal and adjusts zoom level and scroll position if
         * necessary.
         */
        public void UpdateSignal(Signal signal)
        {
            this.signal = signal;
            selection   = null;

            if (currentZoomLevel < MinZoomLevel)
            {
                ZoomToFit();
            }

            AutoScrollMinSize = new Size(
                (int)(currentZoomLevel * signal.NumSamples), 0);
            Refresh();
        }


        /* Zooms in by LARGE_ZOOM_STEP.
         */
        public void ZoomIn()
        {
            setZoomLevel(currentZoomLevel * LARGE_ZOOM_STEP);
        }


        /* Zooms out by LARGE_ZOOM_STEP.
         */
        public void ZoomOut()
        {
            setZoomLevel(currentZoomLevel / LARGE_ZOOM_STEP);
        }


        /* Zooms to minimum zoom level (to fit width).
         */
        public void ZoomToFit()
        {
            setZoomLevel(MinZoomLevel);
        }


        /* Zoom to maximum zoom level.
         */
        public void ZoomToMax()
        {
            setZoomLevel(MaxZoomLevel);
        }


        /* Sets the zoom level to the given amount (if possible).
         */
        private void setZoomLevel(double newZoomLevel)
        {
            if (newZoomLevel > MaxZoomLevel)
            {
                newZoomLevel = MaxZoomLevel;
            }

            if (newZoomLevel < MinZoomLevel)
            {
                newZoomLevel = MinZoomLevel;
            }

            if (signal != null && currentZoomLevel != newZoomLevel)
            {
                selection = null;
                
                double factor = newZoomLevel / currentZoomLevel;
                double offset = ((double)Width) / 2;

                currentZoomLevel = newZoomLevel;
                double scrollPosition = (-AutoScrollPosition.X + offset)
                                      * factor - offset;

                AutoScrollMinSize  = new Size(
                    (int)(currentZoomLevel * signal.NumSamples), 0);
                AutoScrollPosition = new Point((int)scrollPosition, 0);
                Refresh();
            }
        }


        /* Returns the sample number at the given position.
         */
        private int getSampleNumber(int position)
        {
            int sampleNumber = (int)((position - AutoScrollPosition.X)
                             / currentZoomLevel);

            if (sampleNumber < 0)
            {
                return 0;
            }
            
            if (sampleNumber > signal.NumSamples)
            {
                return signal.NumSamples;
            }

            return sampleNumber;
        }
    }
}