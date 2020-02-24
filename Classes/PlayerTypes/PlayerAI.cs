using System;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing AI player with paddle and watchin' for specific ball
    /// </summary>
    class PlayerAI: Player, IPlayerAI
    {
        #region Fields

        /// <summary>
        /// Ball to watch for
        /// </summary>
        public IBall Ball { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// AI player class constructor
        /// </summary>
        /// <param name="paddle">Paddle object</param>
        /// <param name="ball">Ball object</param>
        public PlayerAI(
            IPaddle paddle,
            IBall ball
        ) : base(
            paddle
        )
        {
            this.Ball = ball;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Decide AI next moving position vector
        /// </summary>
        public void DecideMove()
        {
            double yStep = (this.Ball.Position.Y - (this.Paddle.Position.Y + this.Paddle.Height / 2)) * this.Ball.Speed;
            if (Math.Abs(yStep) > 30)
            {
                this.Paddle.Vector = new Point(this.Paddle.Vector.X, yStep);
            } else
            {
                this.Paddle.Vector = new Point();
            }
        }

        #endregion
    }
}
