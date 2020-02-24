using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing ball object in game
    /// </summary>
    class Ball : MovingObject, IBall
    {
        #region Constructor

        /// <summary>
        /// Ball class constructor
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

        #endregion

        #region Methods

        /// <summary>
        /// Draw ball ellipse procedure
        /// </summary>
        /// <param name="graphics">Graphics object</param>
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
        /// Draw method for self-drawing of object
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        public override void Draw(
            Graphics graphics
        )
        {
            this.DrawBall(graphics);
        }

        #endregion
    }
}
