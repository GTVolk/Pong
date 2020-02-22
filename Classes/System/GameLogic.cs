using System.Collections.Generic;
using Pong.Interfaces;

namespace Pong.Classes
{
    class GameLogic: IGameLogic
    {
        public IUserInput UserInput { get; set; }
        public IRenderer Renderer { get; set; }
        private List<IPlayer> PlayersList { get; set; }

        public GameLogic(
            IUserInput userInput,
            IRenderer renderer
        )
        {
            this.UserInput = userInput;
            this.Renderer = renderer;

            this.PlayersList = new List<IPlayer>();
        }

        private bool IsObjectCollideWithObject(
            IObject firstObj,
            IObject secondObj
        )
        {
            return (
                (firstObj.Position.X > secondObj.Position.X) && (firstObj.Position.X < (secondObj.Position.X + secondObj.Width))
                || (((firstObj.Position.X + firstObj.Width) > secondObj.Position.X) && ((firstObj.Position.X + firstObj.Width) < (secondObj.Position.X + secondObj.Width)))
              ) && (
                (firstObj.Position.Y > secondObj.Position.Y) && (firstObj.Position.Y < (secondObj.Position.Y + secondObj.Height))
                || (((firstObj.Position.Y + firstObj.Height) > secondObj.Position.Y) && ((firstObj.Position.Y + firstObj.Height) < (secondObj.Position.Y + secondObj.Height)))
              );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsObjectsCollideWithEachOther(
            IObject firstObj,
            IObject secondObj
        )
        {
            return (
                this.IsObjectCollideWithObject(firstObj, secondObj)
                || this.IsObjectCollideWithObject(secondObj, firstObj)
            );
        }

        public bool CheckBallBounceBorder(
            IGameZone zone,
            IBall ball
        )
        {
            return zone.IsObjectOutsideTop(ball) || zone.IsObjectOutsideBottom(ball);
        }

        public bool CheckBallOutLeft(
            IGameZone zone,
            IBall ball
        )
        {
            return zone.IsObjectOutsideLeft(ball);
        }

        public bool CheckBallOutRight(
            IGameZone zone,
            IBall ball
        )
        {
            return zone.IsObjectOutsideRight(ball);
        }

        public bool CheckBallBouncePaddle(
            IPaddle paddle,
            IBall ball
        )
        {
            return this.IsObjectsCollideWithEachOther(paddle, ball);
        }

        public IPlayerHuman AddHumanPlayer(
            IPaddle paddle
        )
        {
            IPlayerHuman player = new PlayerHuman(paddle);
            this.PlayersList.Add(player);

            return player;
        }

        public IPlayerAI AddAIPlayer(
            IPaddle paddle
        )
        {
            IPlayerAI player = new PlayerAI(paddle);
            this.PlayersList.Add(player);

            return player;
        }

        public void AddScore(
            IPlayer player,
            int amount
        )
        {
            if (this.PlayersList.Contains(player)) {
                player.Score += amount;
            }
        }

        /// <summary>
        /// Method for processing ball move on tick
        /// </summary>
        public void MoveBall(
            IGameZone zone,
            IBall ball
        )
        {
            IPoint newVector = new Point(ball.Vector.X, ball.Vector.Y);
            double newBallSpeed = ball.Speed;

            if (this.CheckBallBounceBorder(zone, ball))
            {
                newVector.Y = -newVector.Y;
                newBallSpeed *= 1.01f;
            }

            foreach (IPlayer player in this.PlayersList)
            {
                if (this.CheckBallBouncePaddle(player.Paddle, ball))
                {
                    newVector.X = -newVector.X;
                    newBallSpeed *= 1.05f;
                }
            }

            if (
                this.CheckBallOutLeft(zone, ball)
                || this.CheckBallOutRight(zone, ball)
            )
            {
                return;
            }

            ball.Vector = newVector;
            ball.Speed = newBallSpeed;
            ball.Move();
        }

        public void MovePaddle(
            IGameZone zone,
            IPaddle paddle
        )
        {
            paddle.Vector.X = 0;
            if (
                (paddle.Vector.Y < 0 && !zone.IsObjectOutsideTop(paddle))
                || (paddle.Vector.Y > 0 && !zone.IsObjectOutsideBottom(paddle))
            )
            {
                paddle.Move();
            }
        }

        public void SetRenderingFunction(RenderEvent renderEvent)
        {
            this.Renderer.OnRender += renderEvent;
        }

        public void ProcessAIMovement()
        {
            foreach(IPlayer player in PlayersList)
            {
                if (player is IPlayerAI)
                {
                    ((IPlayerAI)player).DecideMove();
                }
            }
        }
    }
}
