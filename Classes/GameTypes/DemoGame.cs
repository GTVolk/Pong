using System;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing demo game type object
    /// </summary>
    class DemoGame: GameType
    {
        #region Fields

        /// <summary>
        /// Game background object holder
        /// </summary>
        protected IBackground Background { get; set; }
        /// <summary>
        /// Game zone object holder
        /// </summary>
        protected IGameZone GameZone { get; set; }
        /// <summary>
        /// Ball object holder
        /// </summary>
        protected IBall Ball { get; set; }
        /// <summary>
        /// Left racket pad object holder
        /// </summary>
        protected IPaddle LeftPaddle { get; set; }
        /// <summary>
        /// Right racket pad object holder
        /// </summary>
        protected IPaddle RightPaddle { get; set; }
        /// <summary>
        /// Left side player object holder
        /// </summary>
        protected IPlayerAI LeftPlayer { get; set; }
        /// <summary>
        /// Right side player object holder
        /// </summary>
        protected IPlayerAI RightPlayer { get; set; }
        protected System.Drawing.Font CounterFont { get; set; }
        /// <summary>
        /// Left score counter object holder
        /// </summary>
        protected IScreenText LeftCounter { get; set; }
        /// <summary>
        /// Right score counter object holder
        /// </summary>
        protected IScreenText RightCounter { get; set; }
        /// <summary>
        /// Scene prepared for rendering flag
        /// </summary>
        protected bool IsScenePrepared { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Demo game class constructor
        /// </summary>
        /// <param name="control"></param>
        public DemoGame(
            IGameLogic gameLogic
        ): base(
            gameLogic
        )
        {
            this.CreateGameObjects();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creating game type objects
        /// </summary>
        protected void CreateGameObjects()
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

            this.LeftPlayer = this.GameLogic.AddAIPlayer(this.LeftPaddle, this.Ball);
            this.RightPlayer = this.GameLogic.AddAIPlayer(this.RightPaddle, this.Ball);

            this.IsScenePrepared = false;
        }

        /// <summary>
        /// Preparing game objects for rendering
        /// </summary>
        /// <param name="canvas"></param>
        protected void PrepareGameObjectsForRendering(
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

            Random randomizer = new Random();
            while (this.Ball.Vector.X == 0 || this.Ball.Vector.Y == 0)
            {
                this.Ball.Vector.X = randomizer.Next(-(int)(canvasWidth / 2), (int)(canvasWidth / 2));
                this.Ball.Vector.Y = randomizer.Next(-(int)(canvasHeight / 8), (int)(canvasHeight / 8));
            }

            this.IsScenePrepared = true;
        }

        /// <summary>
        /// Game update on tick function for bridge pattern
        /// </summary>
        public override void ProcessGameUpdate()
        {
            if (this.IsScenePrepared)
            {
                this.GameLogic.ProcessAIMovement();

                this.GameLogic.MovePaddle(this.GameZone, this.LeftPaddle);
                this.GameLogic.MovePaddle(this.GameZone, this.RightPaddle);

                if (this.GameLogic.IsBallOutOnLeft(this.GameZone, this.Ball))
                {
                    this.GameLogic.AddScore(this.RightPlayer, 1);
                    this.IsScenePrepared = false;
                }

                if (this.GameLogic.IsBallOutOnRight(this.GameZone, this.Ball))
                {
                    this.GameLogic.AddScore(this.LeftPlayer, 1);
                    this.IsScenePrepared = false;
                }

                this.GameLogic.MoveBall(this.GameZone, this.Ball);
            }
        }

        /// <summary>
        /// Render function for bridge pattern
        /// </summary>
        /// <param name="canvas">Canvas on which we will render game</param>
        /// <returns>Objects to render</returns>
        public override IDrawable[] GetRenderObjects(ICanvas canvas)
        {
            if (!this.IsScenePrepared)
            {
                this.PrepareGameObjectsForRendering(canvas);
            }

            IDrawable[] drawables =
            {
                this.Background,
                this.LeftPaddle,
                this.RightPaddle,
                this.Ball,
                this.LeftCounter,
                this.RightCounter,
            };

            return drawables;
        }

        /// <summary>
        /// Method for disposing disposable game objects
        /// </summary>
        protected void DisposeGameObjects()
        {
            this.CounterFont.Dispose();
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Class destructor
        /// </summary>
        ~DemoGame()
        {
            this.DisposeGameObjects();
        }

        #endregion
    }
}
