using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class Paddle: ActiveObject, IPaddle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        public Paddle(IPoint position) : base(Constants.DEFAULT_PAD_WIDTH, Constants.DEFAULT_PAD_HEIGHT, Constants.DEFAULT_PADDLE_SPEED, position)
        {
            this.BackgroundColor = Color.White;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsPointCollide(IPoint point)
        {
            return (
                (point.X > this.Position.X && point.X < (this.Position.X + this.Width))
                && (point.Y > this.Position.Y && point.Y < (this.Position.Y + this.Height))
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public override void Move(IPoint point)
        {
            this.Position = new Point(this.Position.X,  this.Position.Y + Math.Sign(point.Y) * this.Speed);
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
                utils.FillRectangle(graphics, drawBrush, this.Position.X, this.Position.Y, this.Width, this.Height);
            }
        }
    }
}
