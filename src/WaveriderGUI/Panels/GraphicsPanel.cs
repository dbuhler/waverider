using System;
using System.Drawing;
using System.Windows.Forms;
using Waverider;


namespace WaveriderGUI.Panels
{
    public class GraphicsPanel : Panel
    {
        protected int   cursorInitialPos;
        protected int   cursorPreviousPos;
        protected int   cursorCurrentPos;
        protected bool  selecting;
        protected Range selection;

        protected const int SCROLL_BAR_SIZE = 19;

        
        public GraphicsPanel()
            : base()
        {
            BackColor      = Color.Black;
            DoubleBuffered = true;
            selecting      = false;
            selection      = null;
        }


        protected override void OnMouseEnter(EventArgs e)
        {
            Focus();
            base.OnMouseEnter(e);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            Parent.Focus();
            base.OnMouseLeave(e);
        }


        protected override void OnResize(EventArgs e)
        {
            Refresh();
            base.OnResize(e);
        }


        protected override void OnScroll(ScrollEventArgs e)
        {
            ClearSelection();
            base.OnScroll(e);
        }


        public virtual void Clear()
        {
            Refresh();
        }


        public virtual void ClearSelection()
        {
            selection = null;
            Refresh();
        }


        public bool IsSelecting()
        {
            return selecting;
        }
    }
}