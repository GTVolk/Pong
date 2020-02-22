using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class Paddle: MovingObject, IPaddle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
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
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(
            Graphics graphics
        )
        {
            this.DrawPaddle(graphics);
        }
    }
}
