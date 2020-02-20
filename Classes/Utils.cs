using System;
using System.Drawing;

namespace Pong.Classes
{
    /// <summary>
    /// Utils class.
    /// Pattern: Singleton
    /// </summary>
    class Utils
    {
        /// <summary>
        /// Class instance holder
        /// </summary>
        private static Utils Instance { get; set; }

        /// <summary>
        /// Private class constructor for utils
        /// </summary>
        private Utils() { }

        /// <summary>
        /// Method for getting single class instance
        /// </summary>
        /// <returns>Utils class instance</returns>
        public static Utils GetInstance()
        {
            if (Utils.Instance == null)
            {
                return new Utils();
            }

            return Utils.Instance;
        }

        /// <summary>
        /// Unified method for getting pixel of float coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>Integer pixel</returns>
        public int GetPixel(double coordinate)
        {
            return (int)Math.Round(coordinate);
        }

        /// <summary>
        /// Unified method for getting Graphics rectangle object
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>Rectangle object</returns>
        public Rectangle GetRectangle(double x, double y, double width, double height)
        {
            return new Rectangle(this.GetPixel(x), this.GetPixel(y), this.GetPixel(width), this.GetPixel(height));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawLine(Graphics graphics, Pen pen, double x, double y, double width, double height)
        {
            graphics.DrawLine(pen, this.GetPixel(x), this.GetPixel(y), this.GetPixel(width), this.GetPixel(height));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillRectangle(Graphics graphics, Brush brush, double x, double y, double width, double height)
        {
            graphics.FillRectangle(brush, this.GetRectangle(x, y, width, height));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillEllipse(Graphics graphics, Brush brush, double x, double y, double width, double height)
        {
            graphics.FillEllipse(brush, this.GetRectangle(x, y, width, height));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawString(Graphics graphics, string text, Font font, Brush brush, double x, double y)
        {
            graphics.DrawString(text, font, brush, this.GetPixel(x), this.GetPixel(y));
        }
    }
}
