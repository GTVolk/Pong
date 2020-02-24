using System.Drawing;
using System.Threading;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing game renderer object
    /// Pattern: Bridge
    /// </summary>
    class Renderer: IRenderer
    {
        #region Fields

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
        private bool IsExit { get; set; }
        /// <summary>
        /// Bridge pattern implementation
        /// </summary>
        private IRenderBridge RenderImplementation { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Renderer class constructor
        /// </summary>
        /// <param name="canvas">Canvas object</param>
        public Renderer(
            ICanvas canvas
        )
        {
            this.Canvas = canvas;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Set bridge pattern implementation holder
        /// </summary>
        /// <param name="implementation">Render implementation object</param>
        public void SetRenderImplementation(IRenderBridge implementation)
        {
            this.RenderImplementation = implementation;
        }

        /// <summary>
        /// Main game thread render loop
        /// </summary>
        private void RenderProcedure()
        {
            while (!this.IsExit && this.RenderImplementation != null)
            {
                this.RenderImplementation.ProcessGameUpdate();
                Graphics graphics = this.Canvas.GetGraphics();

                if (graphics != null)
                {
                    foreach (IDrawable drawable in this.RenderImplementation.GetRenderObjects(this.Canvas))
                    {
                        drawable.Draw(graphics);
                    }

                    Thread.Sleep(Constants.RENDER_PERIOD);
                }
                else
                {
                    this.IsExit = true;
                }
            }
        }

        /// <summary>
        /// Starts rendering procedure
        /// </summary>
        public void StartRendering()
        {
            this.RenderThread = new Thread(new ThreadStart(this.RenderProcedure));

            this.RenderThread.Start();
        }

        /// <summary>
        /// Stops rendering procedure
        /// </summary>
        public void StopRendering()
        {
            this.IsExit = true;
        }

        #endregion
    }
}
