using System;
using System.Collections.Generic;
using Pong.Interfaces;

namespace Pong.Classes
{
    class PlayerAI: Player, IPlayerAI
    {
        private List<IBall> WatchedBalls { get; set; }
        public PlayerAI(
            IPaddle paddle
        ) : base(
            paddle
        )
        {
            this.WatchedBalls = new List<IBall>();
        }

        public void AddBallToWatch(IBall ball)
        {
            if (!this.WatchedBalls.Contains(ball))
            {
                this.WatchedBalls.Add(ball);
            }
        }

        public void DecideMove()
        {
            double lengthSum = 0;

            foreach(IBall ball in this.WatchedBalls)
            {
                lengthSum += (ball.Position.Y - (this.Paddle.Position.Y + this.Paddle.Height / 2)) * ball.Speed;
            }

            if (Math.Abs(lengthSum) > 1)
            {
                this.Paddle.Vector = new Point(0, lengthSum / this.WatchedBalls.Count);
            } else
            {
                this.Paddle.Vector = new Point();
            }
        }
    }
}
