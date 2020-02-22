using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using Pong.Interfaces;

namespace Pong.Classes
{
    class Renderer: IRenderer
    {
        /// <summary>
        /// Control on what we will draw game
        /// </summary>
        public ICanvas Canvas { get; set; }
        /// <summary>
        /// Main render thread
        /// </summary>
        private Thread RenderThread { get; set; }

        /// <summary>
        /// Game thread exit flag
        /// </summary>
        private bool StopRendering { get; set; }

        public List<IDrawable> ObjectsToDraw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public event RenderEvent OnRender;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="renderObj"></param>
        public Renderer(
            ICanvas canvas
        )
        {
            this.Canvas = canvas;
        }

        /// <summary>
        /// Main game thread render loop
        /// </summary>
        private void RenderProcedure()
        {
            while (!this.StopRendering)
            {
                Graphics graphics = this.Canvas.GetGraphics();

                if (graphics != null)
                {
                    this.OnRender(this, this.Canvas);
                    foreach (IDrawable drawable in this.ObjectsToDraw)
                    {
                        drawable.Draw(graphics);
                    }

                    Thread.Sleep(Constants.RENDER_PERIOD);
                }
                else
                {
                    this.StopRendering = true;
                }
            }
        }

        public void Start()
        {
            this.RenderThread = new Thread(new ThreadStart(this.RenderProcedure));
            this.RenderThread.Start();
        }

        public void Stop()
        {
            this.StopRendering = true;
            this.RenderThread.Abort();
        }
    }
}
