using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Abstract class representing static (not moving) objects
    /// </summary>
    abstract class StaticObject: Object, IStaticObject
    {
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// Protected class constructor for static objects
        /// </summary>
        /// <param name="width">Object widht</param>
        /// <param name="height">Object height</param>
        /// <param name="position">Object position</param>
        protected StaticObject(double width, double height, IPoint position): base(width, height, position)
        {
            this.BackgroundColor = Color.Black;
        }

        /// <summary>
        /// Abstract draw method for self-drawing of object
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        abstract public void Draw(Graphics graphics);
    }
}
