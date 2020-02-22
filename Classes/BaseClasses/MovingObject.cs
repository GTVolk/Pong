using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class for graphical objects that can move
    /// </summary>
    abstract class MovingObject : StaticObject, IMovingObject
    {
        /// <summary>
        /// Object moving vector
        /// </summary>
        public IPoint Vector { get; set; }
        /// <summary>
        /// Object speed
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        /// <param name="width">Object width</param>
        /// <param name="height">Object height</param>
        /// <param name="speed">Object speed</param>
        /// <param name="position">Object position</param>
        protected MovingObject(
            double width = 0,
            double height = 0,
            IPoint vector = null,
            double speed = 0,
            IPoint position = null,
            Color backgroundColor = default
        ) : base(
            width,
            height,
            position,
            backgroundColor
        )
        {
            this.Vector = vector ?? new Point();
            this.Speed = speed;
        }

        /// <summary>
        /// Method for moving object to vector
        /// </summary>
        public void Move()
        {
            var length = Math.Sqrt(this.Vector.X * this.Vector.X + this.Vector.Y * this.Vector.Y);
            if (length > 0 && this.Speed > 0)
            {
                double xStep = this.Vector.X / length;
                double yStep = this.Vector.Y / length;
                this.Position = new Point(this.Position.X + (xStep * this.Speed), this.Position.Y + (yStep * this.Speed));
            }
        }
    }
}
