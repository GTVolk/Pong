using System;
using System.Windows.Forms;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    class Canvas: ICanvas
    {
        private Control Control { get; set; }
        private Graphics Graphics { get; set; }

        public Canvas(
            Control ctrl
        )
        {
            this.Control = ctrl;
        }

        private bool IsDrawableControl()
        {
            return this.Control.GetType().GetMethod("CreateGraphics") != null;
        }

        public Control GetParent()
        {
            return this.Control.Parent;
        }

        public Graphics GetGraphics()
        {
            if (!this.IsDrawableControl())
            {
                throw new Exception("Non graphics control");
            }

            if (this.Graphics == null)
            {
                this.Graphics = this.Control.CreateGraphics();
            }

            if (this.Control.IsDisposed && this.Graphics != null)
            {
                this.Graphics.Dispose();
                this.Graphics = null;
            }

            return this.Graphics;
        }

        public double GetWidth()
        {
            return this.Control.Width;
        }

        public double GetHeight()
        {
            return this.Control.Height;
        }

        ~Canvas()
        {
            if (this.Graphics != null)
            {
                this.Graphics.Dispose();
                this.Graphics = null;
            }
        }
    }
}
