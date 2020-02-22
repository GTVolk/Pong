using System.Collections.Generic;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// 
    /// </summary>
    class DemoGame: GameType
    {
        /// <summary>
        /// Game background object
        /// </summary>
        protected IBackground Background { get; set; }
        /// <summary>
        /// Game zone object
        /// </summary>
        protected IGameZone GameZone { get; set; }
        /// <summary>
        /// Ball object
        /// </summary>
        protected IBall Ball { get; set; }
        /// <summary>
        /// Left racket pad object
        /// </summary>
        protected IPaddle LeftPaddle { get; set; }
        /// <summary>
        /// Right racket pad object
        /// </summary>
        protected IPaddle RightPaddle { get; set; }
        protected IPlayerAI LeftPlayer { get; set; }
        protected IPlayerAI RightPlayer { get; set; }
        protected System.Drawing.Font CounterFont { get; set; }
        /// <summary>
        /// Left score counter object
        /// </summary>
        protected IScreenText LeftCounter { get; set; }
        /// <summary>
        /// Right score counter object
        /// </summary>
        protected IScreenText RightCounter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public DemoGame(
            IGameLogic gameLogic
        ): base(
            gameLogic
        ) {}

        /// <summary>
        /// 
        /// </summary>
        protected override void CreateGameObjects()
        {
            this.Background = new Background();
            this.GameZone = new GameZone();
            this.LeftPaddle = new Paddle();
            this.RightPaddle = new Paddle();
            this.RightPaddle = new Paddle();
            this.Ball = new Ball();

            this.CounterFont = new System.Drawing.Font(Constants.DEFAULT_COUNTER_FONT, Constants.DEFAULT_COUNTER_FONT_SIZE);
            this.LeftCounter = new StaticText(null, this.CounterFont);
            this.RightCounter = new StaticText(null, this.CounterFont);

            this.LeftPlayer = this.GameLogic.AddAIPlayer(this.LeftPaddle);
            this.RightPlayer = this.GameLogic.AddAIPlayer(this.RightPaddle);

            this.LeftPlayer.AddBallToWatch(this.Ball);
            this.RightPlayer.AddBallToWatch(this.Ball);
        }

        protected override void SetGameObjectsByCanvas(
            ICanvas canvas
        )
        {
            double canvasWidth = canvas.GetWidth();
            double canvasHeight = canvas.GetHeight();

            double gameZoneShrink = Constants.DEFAULT_BORDER_PADDING + Constants.DEFAULT_BORDER_WIDTH;
            this.GameZone.Width = canvasWidth;
            this.GameZone.Height = canvasHeight - (gameZoneShrink * 2);
            this.GameZone.Position.Y = gameZoneShrink;

            this.Background.Width = canvasWidth;
            this.Background.Height = canvasHeight;

            this.LeftPaddle.Position.X = Constants.DEFAULT_PAD_WIDTH;
            this.LeftPaddle.Position.Y = canvasHeight / 2;

            this.RightPaddle.Position.X = canvasWidth - (Constants.DEFAULT_PAD_WIDTH * 2);
            this.RightPaddle.Position.Y = canvasHeight / 2;

            this.Ball.Position.X = canvasWidth / 2;
            this.Ball.Position.Y = canvasHeight / 2;

            this.LeftCounter.Text = this.LeftPlayer.Score.ToString();
            System.Drawing.SizeF leftCounterSize = this.LeftCounter.GetTextSize(canvas.GetGraphics());
            this.LeftCounter.Position.X = (canvasWidth / 2) - (leftCounterSize.Width * 1.5f);
            this.LeftCounter.Position.Y = (leftCounterSize.Height / 2) - Constants.DEFAULT_BORDER_PADDING;

            this.RightCounter.Text = this.RightPlayer.Score.ToString();
            System.Drawing.SizeF rightCounterSize = this.RightCounter.GetTextSize(canvas.GetGraphics());
            this.RightCounter.Position.X = (canvasWidth / 2) + (rightCounterSize.Width * 0.5f);
            this.RightCounter.Position.Y = (rightCounterSize.Height / 2) - Constants.DEFAULT_BORDER_PADDING;

            this.Ball.Speed = Constants.DEFAULT_BALL_SPEED;
            this.Ball.Vector = new Point();
            while (this.Ball.Vector.X == 0 || this.Ball.Vector.Y == 0)
            {
                this.Ball.Vector.X = this.Randomizer.Next(-(int)(canvasWidth / 2), (int)(canvasWidth / 2));
                this.Ball.Vector.Y = this.Randomizer.Next(-(int)(canvasHeight / 8), (int)(canvasHeight / 8));
            }
        }

        protected override void ProcessGame(object sender, ICanvas canvas)
        {
            List<IDrawable> objectsList = new List<IDrawable>();

            objectsList.Add(this.Background);
            objectsList.Add(this.LeftPaddle);
            objectsList.Add(this.RightPaddle);
            objectsList.Add(this.Ball);
            objectsList.Add(this.LeftCounter);
            objectsList.Add(this.RightCounter);

            ((IRenderer)sender).ObjectsToDraw = objectsList;

            this.GameLogic.ProcessAIMovement();

            this.GameLogic.MoveBall(this.GameZone, this.Ball);
            this.GameLogic.MovePaddle(this.GameZone, this.LeftPaddle);
            this.GameLogic.MovePaddle(this.GameZone, this.RightPaddle);

            if (this.GameLogic.CheckBallOutLeft(this.GameZone, this.Ball))
            {
                this.GameLogic.AddScore(this.RightPlayer, 1);
                this.SetGameObjectsByCanvas(canvas);
            }

            if (this.GameLogic.CheckBallOutRight(this.GameZone, this.Ball))
            {
                this.GameLogic.AddScore(this.LeftPlayer, 1);
                this.SetGameObjectsByCanvas(canvas);
            }
        }

        public void NewGame()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void RestartGame()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Method for disposing disposable game objects
        /// </summary>
        protected override void DisposeGameObjects()
        {
            this.CounterFont.Dispose();
        }
    }
}
