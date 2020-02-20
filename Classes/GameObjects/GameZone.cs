using System.Windows.Forms;
using System.Drawing;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class GameZone: Object, IGameZone
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="position"></param>
        public GameZone(double width, double height, IPoint position): base(width, height, position) {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsObjectOutsideLeft(IObject obj)
        {
            return this.Position.X >= obj.Position.X
                || this.Position.X >= (obj.Position.X + obj.Width);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsObjectOutsideRight(IObject obj)
        {
            return (this.Position.X + this.Width) <= obj.Position.X
                || (this.Position.X + this.Width) <= (obj.Position.X + obj.Width);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsObjectOutsideTop(IObject obj)
        {
            return this.Position.Y >= obj.Position.Y
                || this.Position.Y >= (obj.Position.Y + obj.Height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool IsObjectOutsideBottom(IObject obj)
        {
            return (this.Position.Y + this.Height) <= obj.Position.Y
                || (this.Position.Y + this.Height) <= (obj.Position.Y + obj.Height);
        }
    }
}
