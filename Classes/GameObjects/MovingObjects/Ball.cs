using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class Ball : MovingObject, IBall
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public Ball(
            IPoint position = null
        ) : base(
            Constants.DEFAULT_BALL_RADIUS,
            Constants.DEFAULT_BALL_RADIUS,
            null,
            Constants.DEFAULT_BALL_SPEED,
            position,
            Color.White
        ) {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawBall(
            Graphics graphics
        )
        {
            using (Brush drawBrush = new SolidBrush(this.BackgroundColor))
            {
                Utils utils = Utils.GetInstance();
                utils.FillEllipse(graphics, drawBrush, this.Position.X, this.Position.Y, this.Width, this.Height);
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
            this.DrawBall(graphics);
        }
    }
}
