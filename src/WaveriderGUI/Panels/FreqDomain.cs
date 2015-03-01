using System;
using System.Drawing;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI.Panels
{
    public class FreqDomain : GraphicsPanel
    {
        public FreqDomain() : base()
        {
            Frequencies = null;
        }


        public FrequencyMap Frequencies { get; set; }


        /* Returns the currently selected bin number.
         */
        public int BinNumber
        {
            get
            {
                int start = Math.Max(getBinNumber(cursorCurrentPos, 1), 0) + 1;
                int end   = Math.Min(getBinNumber(cursorCurrentPos, 0) + 1,
                    Frequencies.Count) + 1;

                if (start >= end)
                {
                    return 0;
                }

                return start;
            }
        }


        /* Returns the currently selected bin range.
         */
        public Range BinRange
        {
            get
            {
                if (selection == null)
                {
                    return null;
                }

                int start = Math.Max(getBinNumber(selection.Start, 1), 0) + 1;
                int end   = Math.Min(getBinNumber(selection.End,  0) + 1,
                    Frequencies.Count) + 1;

                if (start >= end)
                {
                    return null;
                }

                return new Range(start, end - start);
            }
        }


        /* Starts selecting.
         */
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Frequencies != null)
            {
                selecting = false;
                selection = null;
                Refresh();

                if (e.Button == MouseButtons.Left)
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
            if (Frequencies != null)
            {
                cursorPreviousPos = cursorCurrentPos;
                cursorCurrentPos  = Math.Min(Math.Max(e.X, 0), Width - 1);

                if (selecting)
                {
                    selection.SetLeft(Math.Min(cursorInitialPos,
                        cursorCurrentPos));
                    selection.SetRight(Math.Max(cursorInitialPos,
                        cursorCurrentPos));

                    WaveDrawer.Invalidate(this, 0, Width - 1);
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
                WaveDrawer.Invalidate(this, 0, Width - 1);
            }

            base.OnMouseUp(e);
        }


        /* Draws the frequency bins and highlights the selected ones.
        */
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, 0,
                Height - SCROLL_BAR_SIZE - WaveDrawer.MARGIN,
                Width - 1, Height - SCROLL_BAR_SIZE - WaveDrawer.MARGIN);
            
            if (Frequencies == null)
            {
                return;
            }

            AutoScroll = true;
            AutoScrollMinSize = new Size(
                2 * WaveDrawer.MARGIN + Frequencies.Count
                * (WaveDrawer.RECT_WIDTH + WaveDrawer.RECT_SPACING), 0);

            WaveDrawer.DrawFourier(
                e.Graphics, e.ClipRectangle, Frequencies,
                Width, Height - SCROLL_BAR_SIZE,
                -AutoScrollPosition.X, BinRange);

            base.OnPaint(e);
        }


        /* Returns the number of the frequency bin at the given position.
         */
        private int getBinNumber(int position, int delta)
        {
            int left = (int)Math.Floor(
                1.0 * (position - AutoScrollPosition.X - WaveDrawer.MARGIN)
                / (WaveDrawer.RECT_WIDTH + WaveDrawer.RECT_SPACING));

            int right = left
                * (WaveDrawer.RECT_WIDTH + WaveDrawer.RECT_SPACING)
                + WaveDrawer.RECT_WIDTH + WaveDrawer.MARGIN;

            if (position - AutoScrollPosition.X <= right)
            {
                return left;
            }
            else
            {
                return left + delta;
            }
        }


        /* Clears and resets the panel.
         */
        public override void Clear()
        {
            AutoScroll  = false;
            Frequencies = null;
            base.Clear();
        }


        /* Draws the given frequencies on the panel.
         */
        public void DrawFourier(FrequencyMap frequencies)
        {
            this.Frequencies = frequencies;
            Refresh();
        }
    }
}