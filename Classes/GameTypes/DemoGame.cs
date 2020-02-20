using System.Windows.Forms;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class DemoGame: GameType
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public DemoGame(Control control): base(control) { }

        /// <summary>
        /// 
        /// </summary>
        protected override void CreateGameObjects()
        {
            this.Background = new Background((double)this.MainControl.Width, (double)this.MainControl.Height, new Point(0, 0));
            this.GameZone = new GameZone(this.MainControl.Width, this.MainControl.Height - ((Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH) * 2), new Point(0, (Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH) - 5));
            this.LeftPaddle = new Paddle(new Point(Constants.DEFAULT_PAD_WIDTH, this.MainControl.Height / 2));
            this.RightPaddle = new Paddle(new Point(this.MainControl.Width - (Constants.DEFAULT_PAD_WIDTH * 2), this.MainControl.Height / 2));
            this.Ball = new Ball(new Point((this.MainControl.Width / 2), (this.MainControl.Height / 2)));

            this.RestartGame();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void RestartGame()
        {
            this.Ball.Position.X = (this.MainControl.Width / 2);
            this.Ball.Position.Y = (this.MainControl.Height / 2);
            this.Ball.Speed = Constants.DEFAULT_BALL_SPEED;

            this.BallVector = new Point(this.Randomizer.Next(-100, 100), this.Randomizer.Next(-50, 50));
            this.LeftPaddle.Position.Y = this.MainControl.Height / 2;
            this.RightPaddle.Position.Y = this.MainControl.Height / 2;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ProcessLeftPaddleMove()
        {
            if (this.BallVector.Y < 0 && !this.GameZone.IsObjectOutsideTop(this.LeftPaddle))
            {
                this.LeftPaddle.Move(this.BallVector);
            }

            if (this.BallVector.Y > 0 && !this.GameZone.IsObjectOutsideBottom(this.LeftPaddle))
            {
                this.LeftPaddle.Move(this.BallVector);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ProcessRightPaddleMove()
        {
            if (this.BallVector.Y < 0 && !this.GameZone.IsObjectOutsideTop(this.RightPaddle))
            {
                this.RightPaddle.Move(this.BallVector);
            }

            if (this.BallVector.Y > 0 && !this.GameZone.IsObjectOutsideBottom(this.RightPaddle))
            {
                this.RightPaddle.Move(this.BallVector);
            }
        }

        /// <summary>
        /// Method for disposing disposable game objects
        /// </summary>
        protected override void DisposeGameObjects()
        {
            // Nothing to dispose for now...
        }
    }
}
