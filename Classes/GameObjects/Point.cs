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
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
