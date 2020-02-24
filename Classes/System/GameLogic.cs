using System.Collections.Generic;
using Pong.Interfaces;

namespace Pong.Classes
{
    class GameLogic: IGameLogic
    {
        #region Fields

        /// <summary>
        /// User input object holder
        /// </summary>
        public IUserInput UserInput { get; set; }
        /// <summary>
        /// Renderer object holder
        /// </summary>
        public IRenderer Renderer { get; set; }
        /// <summary>
        /// Game players list
        /// </summary>
        private List<IPlayer> Players { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Game logic class constructor
        /// </summary>
        /// <param name="userInput">User input object</param>
        /// <param name="renderer">Renderer object</param>
        public GameLogic(
            IUserInput userInput,
            IRenderer renderer
        )
        {
            this.UserInput = userInput;
            this.Renderer = renderer;

            this.Players = new List<IPlayer>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Check is ball now must bounce border
        /// </summary>
        /// <param name="zone">Game zone object</param>
        /// <param name="ball">Ball object</param>
        /// <returns></returns>
        public bool IsBallBounceBorder(
            IGameZone zone,
            IBall ball
        )
        {
            return !Utils.GetInstance().IsFirstObjectInsideSecond(ball, zone);
        }

        /// <summary>
        /// Check is ball now must bounce paddle
        /// </summary>
        /// <param name="zone">Paddle object</param>
        /// <param name="ball">Ball object</param>
        /// <returns></returns>
        public bool IsBallBouncePaddle(
            IPaddle paddle,
            IBall ball
        )
        {
            Utils utils = Utils.GetInstance();
            return (
                utils.IsFirstObjectTouchesSecond(paddle, ball)
                || utils.IsFirstObjectTouchesSecond(ball, paddle)
            );
        }

        /// <summary>
        /// Check is ball now must out from left side
        /// </summary>
        /// <param name="zone">Game zone object</param>
        /// <param name="ball">Ball object</param>
        /// <returns></returns>
        public bool IsBallOutOnLeft(
            IGameZone zone,
            IBall ball
        )
        {
            return Utils.GetInstance().IsFirstObjectOutsideLeftSecond(zone, ball);
        }

        /// <summary>
        /// Check is ball now must out from right side
        /// </summary>
        /// <param name="zone">Game zone object</param>
        /// <param name="ball">Ball object</param>
        /// <returns></returns>
        public bool IsBallOutOnRight(
            IGameZone zone,
            IBall ball
        )
        {
            return Utils.GetInstance().IsFirstObjectOutsideRightSecond(zone, ball);
        }

        /// <summary>
        /// Add human player to the game with paddle
        /// </summary>
        /// <param name="paddle">Paddle object</param>
        /// <returns></returns>
        public IPlayerHuman AddHumanPlayer(
            IPaddle paddle
        )
        {
            IPlayerHuman player = new PlayerHuman(paddle);
            this.Players.Add(player);

            return player;
        }

        /// <summary>
        /// Add AI player to the game with paddle and watch for desired ball
        /// </summary>
        /// <param name="paddle">Paddle object</param>
        /// <param name="ball">Ball object</param>
        /// <returns>AI player object</returns>
        public IPlayerAI AddAIPlayer(
            IPaddle paddle,
            IBall ball
        )
        {
            IPlayerAI player = new PlayerAI(paddle, ball);
            this.Players.Add(player);

            return player;
        }

        /// <summary>
        /// Add amount points to the player score
        /// </summary>
        /// <param name="player">Player object</param>
        /// <param name="amount">Amount of the score to add</param>
        public void AddScore(
            IPlayer player,
            int amount
        )
        {
            if (this.Players.Contains(player)) {
                player.Score += amount;
            }
        }

        /// <summary>
        /// Resets player score to zero
        /// </summary>
        /// <param name="player">Player object</param>
        public void ResetScore(
            IPlayer player
        )
        {
            if (this.Players.Contains(player))
            {
                player.Score = 0;
            }
        }

        /// <summary>
        /// Move ball to desired vector with limits
        /// </summary>
        /// <param name="zone">Game zone object</param>
        /// <param name="ball">Ball object</param>
        public void MoveBall(
            IGameZone zone,
            IBall ball
        )
        {
            IPoint newVector = new Point(ball.Vector.X, ball.Vector.Y);
            double newBallSpeed = ball.Speed;

            if (this.IsBallBounceBorder(zone, ball))
            {
                newVector.Y = -newVector.Y;
                newBallSpeed *= Constants.BALL_BOUNCE_BORDER_SPEED_MULT;
            }

            if (this.IsBallOutOnLeft(zone, ball))
            {
                ball.Position.X = zone.Position.X;
            }

            if (this.IsBallOutOnRight(zone, ball))
            {
                ball.Position.X = (zone.Position.X + zone.Width);
            }

            foreach (IPlayer player in this.Players)
            {
                if (this.IsBallBouncePaddle(player.Paddle, ball))
                {
                    newVector.X = -newVector.X;
                    newBallSpeed *= Constants.BALL_BOUNCE_PADDLE_SPEED_MULT;
                }
            }

            ball.Vector = newVector;
            ball.Speed = newBallSpeed;
            ball.Move();
        }

        /// <summary>
        /// Move paddle to desired vector with limits
        /// </summary>
        /// <param name="zone">Game zone object</param>
        /// <param name="paddle">Paddle object</param>
        public void MovePaddle(
            IGameZone zone,
            IPaddle paddle
        )
        {
            paddle.Vector.X = 0;
            bool isPaddleInsideView = Utils.GetInstance().IsFirstObjectInsideSecond(paddle, zone);
            if (isPaddleInsideView
                || (paddle.Position.Y <= zone.Position.Y && paddle.Vector.Y > 0)
                || ((paddle.Position.Y + paddle.Height) >= (zone.Position.Y + zone.Height) && paddle.Vector.Y < 0)
            )
            {
                paddle.Move();
            }
        }

        /// <summary>
        /// Processes AI next move
        /// </summary>
        public void ProcessAIMovement()
        {
            foreach(IPlayer player in Players)
            {
                if (player is IPlayerAI)
                {
                    ((IPlayerAI)player).DecideMove();
                }
            }
        }

        /// <summary>
        /// Starts new game
        /// </summary>
        public void NewGame()
        {
            foreach(IPlayer player in this.Players)
            {
                this.ResetScore(player);
            }
        }

        /// <summary>
        /// Resets game round
        /// </summary>
        public void RestartGame()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
