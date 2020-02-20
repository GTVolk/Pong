using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class Ball : ActiveObject, IBall
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public Ball(IPoint position) : base(Constants.DEFAULT_BALL_RADIUS, Constants.DEFAULT_BALL_RADIUS, Constants.DEFAULT_BALL_SPEED, position)
        {
            this.BackgroundColor = Color.White;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        public override void Move(IPoint vector)
        {
            var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            this.Position = new Point(this.Position.X + ((vector.X / length) * this.Speed), this.Position.Y + ((vector.Y / length) * this.Speed));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(Graphics graphics)
        {
            using (Brush drawBrush = new SolidBrush(this.BackgroundColor))
            {
                Utils utils = Utils.GetInstance();
                utils.FillEllipse(graphics, drawBrush, this.Position.X, this.Position.Y, this.Width, this.Height);
            }
        }
    }
}
