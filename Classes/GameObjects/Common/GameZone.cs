using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Game zone object for representing limited game area
    /// </summary>
    class GameZone: Object, IGameZone
    {
        #region Constructor

        /// <summary>
        /// Game zone class constructor
        /// </summary>
        /// <param name="width">Zone width</param>
        /// <param name="height">Zone height</param>
        /// <param name="position">Zone start position</param>
        public GameZone(
            double width = 0,
            double height = 0,
            IPoint position = null
        ): base(
            width,
            height,
            position
        ) {}

        #endregion
    }
}
