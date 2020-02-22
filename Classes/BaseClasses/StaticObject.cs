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
        protected StaticObject(
            double width = 0,
            double height = 0,
            IPoint position = null,
            Color backgroundColor = default
        ): base(
            width,
            height,
            position
        )
        {
            this.BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Abstract draw method for self-drawing of object
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        abstract public void Draw(
            Graphics graphics
        );
    }
}
