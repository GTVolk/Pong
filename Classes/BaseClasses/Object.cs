using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Base object class
    /// </summary>
    abstract class Object: IObject
    {
        #region Fields

        /// <summary>
        /// Object width
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Object height
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Object position
        /// </summary>
        public IPoint Position { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Protected class constructor for object
        /// </summary>
        /// <param name="width">Object width</param>
        /// <param name="height">Object height</param>
        /// <param name="position">Object initial position</param>
        protected Object(
            double width = 0,
            double height = 0,
            IPoint position = null
        )
        {
            this.Width = width;
            this.Height = height;
            this.Position = position ?? new Point();
        }

        #endregion
    }
}
