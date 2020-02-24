using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Abstract class representing static (not moving) objects
    /// </summary>
    abstract class StaticObject: Object, IStaticObject
    {
        #region Fields
        /// <summary>
        /// Object background color
        /// </summary>
        public Color BackgroundColor { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Protected class constructor for static objects
        /// </summary>
        /// <param name="width">Object widht</param>
        /// <param name="height">Object height</param>
        /// <param name="position">Object initial position</param>
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

        #endregion

        #region Abstract methods

        /// <summary>
        /// Abstract draw method for self-drawing of object
        /// </summary>
        /// <param name="graphics">Graphics object</param>
        abstract public void Draw(
            Graphics graphics
        );

        #endregion
    }
}
