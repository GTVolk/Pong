using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class for graphical objects that can move
    /// </summary>
    abstract class ActiveObject : StaticObject, IActiveObject
    {
        /// <summary>
        /// Object speed
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        /// <param name="width">Object width</param>
        /// <param name="height">Object height</param>
        /// <param name="speed">Object speed</param>
        /// <param name="position">Object position</param>
        protected ActiveObject(double width, double height, double speed, IPoint position) : base(width, height, position)
        {
            this.Speed = speed;
        }

        /// <summary>
        /// Abstract moving method
        /// </summary>
        /// <param name="vector">Moving vector</param>
        abstract public void Move(IPoint vector);
    }
}
