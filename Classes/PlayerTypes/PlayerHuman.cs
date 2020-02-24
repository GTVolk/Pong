using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing human player object with paddle
    /// </summary>
    class PlayerHuman: Player, IPlayerHuman
    {
        #region Constructor

        /// <summary>
        /// Human player class constructor
        /// </summary>
        /// <param name="paddle">Paddle object</param>
        public PlayerHuman(
            IPaddle paddle
        ) : base(
            paddle
        ) {}

        #endregion
    }
}
