using System;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Utils class.
    /// Pattern: Singleton
    /// </summary>
    class Utils
    {
        #region Fields

        /// <summary>
        /// Class instance holder
        /// </summary>
        private static Utils Instance { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Private class constructor for utils
        /// </summary>
        private Utils() { }

        #endregion

        #region Methods

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
        public int GetPixel(
            double coordinate = 0
        )
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
        public Rectangle GetRectangle(
            double x = 0,
            double y = 0,
            double width = 0,
            double height = 0
        )
        {
            return new Rectangle(this.GetPixel(x), this.GetPixel(y), this.GetPixel(width), this.GetPixel(height));
        }

        /// <summary>
        /// Graphics draw line wrapper
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawLine(
            Graphics graphics,
            Pen pen = default,
            double x = 0,
            double y = 0,
            double width = 0,
            double height = 0
        )
        {
            graphics.DrawLine(pen, this.GetPixel(x), this.GetPixel(y), this.GetPixel(width), this.GetPixel(height));
        }

        /// <summary>
        /// Graphics fill rectangle wrapper
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillRectangle(
            Graphics graphics,
            Brush brush = default,
            double x = 0,
            double y = 0,
            double width = 0,
            double height = 0
        )
        {
            graphics.FillRectangle(brush, this.GetRectangle(x, y, width, height));
        }
        
        /// <summary>
        /// Graphics fill ellipse wrapper
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void FillEllipse(
            Graphics graphics,
            Brush brush = default,
            double x = 0,
            double y = 0,
            double width = 0,
            double height = 0
        )
        {
            graphics.FillEllipse(brush, this.GetRectangle(x, y, width, height));
        }

        /// <summary>
        /// Graphics draw string wrapper
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="brush"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DrawString(
            Graphics graphics,
            string text = "",
            Font font = default,
            Brush brush = default,
            double x = 0,
            double y = 0
        )
        {
            graphics.DrawString(text, font, brush, this.GetPixel(x), this.GetPixel(y));
        }

        /// <summary>
        /// Check is first object out bounds of second from left
        /// </summary>
        /// <param name="firstObj"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public bool IsFirstObjectOutsideLeftSecond(
            IObject firstObj,
            IObject secondObj
        )
        {
            return firstObj.Position.X >= secondObj.Position.X
                || firstObj.Position.X >= (secondObj.Position.X + secondObj.Width);
        }

        /// <summary>
        /// Check is first object out bounds of second from right
        /// </summary>
        /// <param name="firstObj"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public bool IsFirstObjectOutsideRightSecond(
            IObject firstObj,
            IObject secondObj
        )
        {
            return (firstObj.Position.X + firstObj.Width) <= secondObj.Position.X
                || (firstObj.Position.X + firstObj.Width) <= (secondObj.Position.X + secondObj.Width);
        }

        /// <summary>
        /// Check is first object inside second
        /// </summary>
        /// <param name="firstObj"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public bool IsFirstObjectInsideSecond(
            IObject firstObj,
            IObject secondObj
        )
        {
            bool isInsideX = (
                firstObj.Position.X >= secondObj.Position.X
                && (firstObj.Position.X + firstObj.Width) <= (secondObj.Position.X + secondObj.Width)
            );
            bool isInsideY = (
                firstObj.Position.Y >= secondObj.Position.Y
                && (firstObj.Position.Y + firstObj.Height) <= (secondObj.Position.Y + secondObj.Height)
            );
            return isInsideX && isInsideY;
        }

        /// <summary>
        /// Check is first object touches second
        /// </summary>
        /// <param name="firstObj"></param>
        /// <param name="secondObj"></param>
        /// <returns></returns>
        public bool IsFirstObjectTouchesSecond(
            IObject firstObj,
            IObject secondObj
        )
        {
            bool isInside = this.IsFirstObjectInsideSecond(firstObj, secondObj);
            bool isTouchX = firstObj.Position.X > secondObj.Position.X
                ? firstObj.Position.X <= (secondObj.Position.X + secondObj.Width)
                : (firstObj.Position.X + firstObj.Width) >= secondObj.Position.X;
            bool isTouchY = firstObj.Position.Y > secondObj.Position.Y
                ? firstObj.Position.Y <= (secondObj.Position.Y + secondObj.Height)
                : (firstObj.Position.Y + firstObj.Height) >= secondObj.Position.Y;
            bool isTouched = isTouchX && isTouchY;
            return isInside || isTouched;
        }

        #endregion
    }
}
