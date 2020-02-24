using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing point in game
    /// </summary>
    class Point: IPoint
    {
        #region Fields

        /// <summary>
        /// Point X coordinate
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Point Y coordinate
        /// </summary>
        public double Y { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Point class constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(
            double x = 0,
            double y = 0
        )
        {
            this.X = x;
            this.Y = y;
        }

        #endregion
    }
}
