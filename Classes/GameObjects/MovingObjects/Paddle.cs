using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing player moving paddle object
    /// </summary>
    class Paddle: MovingObject, IPaddle
    {
        #region Constructor

        /// <summary>
        /// Paddle object class constructor
        /// </summary>
        /// <param name="position">Object initial position</param>
        public Paddle(
            IPoint position = null
        ) : base(
            Constants.DEFAULT_PAD_WIDTH,
            Constants.DEFAULT_PAD_HEIGHT,
            null,
            Constants.DEFAULT_PADDLE_SPEED,
            position,
            Color.White
        ) {}

        #endregion

        #region Methods

        /// <summary>
        /// Draw paddle rectangle
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        public void DrawPaddle(
            Graphics graphics
        )
        {
            using (Brush drawBrush = new SolidBrush(this.BackgroundColor))
            {
                Utils utils = Utils.GetInstance();
                utils.FillRectangle(graphics, drawBrush, this.Position.X, this.Position.Y, this.Width, this.Height);
            }
        }

        /// <summary>
        /// Draw method for self-drawing of object
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        public override void Draw(
            Graphics graphics
        )
        {
            this.DrawPaddle(graphics);
        }

        #endregion
    }
}
