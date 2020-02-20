using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Abstract class representing player of any type
    /// </summary>
    abstract class Player : IPlayer
    {
        /// <summary>
        /// Player controlled paddle
        /// </summary>
        public IPaddle Paddle { get; set; }

        /// <summary>
        /// Protected class constructor for player
        /// </summary>
        /// <param name="paddle">Player paddle</param>
        protected Player(IPaddle paddle)
        {
            this.Paddle = paddle;
        }
    }
}
