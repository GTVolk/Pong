using Pong.Interfaces;

namespace Pong.Classes
{
    class Point: IPoint
    {
        /// <summary>
        /// 
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// 
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
    }
}
