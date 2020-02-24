using System;
using System.Windows.Forms;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing paintable canvas adapter
    /// </summary>
    class Canvas: ICanvas
    {
        #region Fields

        /// <summary>
        /// Canvas control to paint on
        /// </summary>
        private Control Control { get; set; }
        /// <summary>
        /// Canvas graphics object
        /// </summary>
        private Graphics Graphics { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Canvas class constructor
        /// </summary>
        /// <param name="ctrl"></param>
        public Canvas(
            Control ctrl
        )
        {
            this.Control = ctrl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check is canvas control drawable
        /// </summary>
        /// <returns>Control is drawable</returns>
        private bool IsDrawableControl()
        {
            return this.Control.GetType().GetMethod("CreateGraphics") != null;
        }

        /// <summary>
        /// Get canvas control parent
        /// </summary>
        /// <returns>Control object (parent)</returns>
        public Control GetParent()
        {
            return this.Control.Parent;
        }

        /// <summary>
        /// Get canvas Graphics object instance
        /// </summary>
        /// <returns>Graphics object</returns>
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

        /// <summary>
        /// Get canvas width
        /// </summary>
        /// <returns>Canvas width</returns>
        public double GetWidth()
        {
            return this.Control.Width;
        }

        /// <summary>
        /// Get canvas height
        /// </summary>
        /// <returns>Canvas height</returns>
        public double GetHeight()
        {
            return this.Control.Height;
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Canvas class destructor
        /// </summary>
        ~Canvas()
        {
            if (this.Graphics != null)
            {
                this.Graphics.Dispose();
                this.Graphics = null;
            }
        }

        #endregion
    }
}
