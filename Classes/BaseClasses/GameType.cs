using System;
using System.Windows.Forms;
using System.Threading;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Base game type class, parent for all game types
    /// </summary>
    abstract class GameType : IGameType
    {
        /// <summary>
        /// Control on what we will draw game
        /// </summary>
        protected Control MainControl { get; set; }
        /// <summary>
        /// Control Graphics object
        /// </summary>
        protected System.Drawing.Graphics Graphics { get; set; }
        /// <summary>
        /// Font for score counter
        /// </summary>
        protected System.Drawing.Font CounterFont { get; set; }
        /// <summary>
        /// Game background object
        /// </summary>
        protected IBackground Background { get; set; }
        /// <summary>
        /// Game zone object
        /// </summary>
        protected IGameZone GameZone { get; set; }
        /// <summary>
        /// Left racket pad object
        /// </summary>
        protected IPaddle LeftPaddle { get; set; }
        /// <summary>
        /// Right racket pad object
        /// </summary>
        protected IPaddle RightPaddle { get; set; }
        /// <summary>
        /// Ball object
        /// </summary>
        protected IBall Ball { get; set; }
        /// <summary>
        /// Left score counter object
        /// </summary>
        protected IScreenText LeftCounter { get; set; }
        /// <summary>
        /// Right score counter object
        /// </summary>
        protected IScreenText RightCounter { get; set; }

        /// <summary>
        /// Randomizer object
        /// </summary>
        protected Random Randomizer { get; set; }
        /// <summary>
        /// Left side wins counter
        /// </summary>
        protected int LeftWins { get; set; }
        /// <summary>
        /// Right side wins counter
        /// </summary>
        protected int RightWins { get; set; }
        /// <summary>
        /// Ball move vector
        /// </summary>
        protected IPoint BallVector { get; set; }

        /// <summary>
        /// Game thread exit flag
        /// </summary>
        private bool IsExit { get; set; }
        /// <summary>
        /// Main render thread
        /// </summary>
        private Thread RenderThread { get; set; }

        /// <summary>
        /// Protected class constructor
        /// </summary>
        /// <param name="control"></param>
        protected GameType(Control control)
        {
            this.MainControl = control;
            this.Randomizer = new Random();

            this.CreateGameObjects();
            this.CreateGameThreads();

            this.NewGame();
        }

        /// <summary>
        /// Abstract method for creation game objects
        /// </summary>
        abstract protected void CreateGameObjects();
        /// <summary>
        /// Abstract method for resseting game
        /// </summary>
        abstract protected void RestartGame();
        /// <summary>
        /// Abstract method for process moving of left pad
        /// </summary>
        abstract protected void ProcessLeftPaddleMove();
        /// <summary>
        /// Abstract method for process moving of right pad
        /// </summary>
        abstract protected void ProcessRightPaddleMove();
        /// <summary>
        /// Abstract method for disposing created game objects
        /// </summary>
        abstract protected void DisposeGameObjects();

        /// <summary>
        /// Method for initializing new game
        /// </summary>
        protected void NewGame()
        {
            this.LeftWins = 0;
            this.RightWins = 0;
            this.RestartGame();
        }

        /// <summary>
        /// Method for creating game threads
        /// </summary>
        private void CreateGameThreads()
        {
            this.IsExit = false;
            this.RenderThread = new Thread(new ThreadStart(this.Render));
        }

        /// <summary>
        /// Method for check is control has drawing capabilities
        /// </summary>
        /// <returns></returns>
        private bool IsDrawableControl()
        {
            return this.MainControl.GetType().GetMethod("CreateGraphics") != null;
        }

        /// <summary>
        /// Method for getting Graphics instance of drawing control
        /// </summary>
        /// <returns></returns>
        private System.Drawing.Graphics GetGraphics()
        {
            if (!this.IsDrawableControl())
            {
                throw new Exception("Non graphics control");
            }
            if (this.MainControl.IsDisposed)
            {
                throw new Exception("Control is disposed");
            }

            if (this.Graphics == null)
            {
                this.Graphics = this.MainControl.CreateGraphics();
            }

            return this.Graphics;
        }

        /// <summary>
        /// Method for getting score counter font
        /// </summary>
        /// <returns></returns>
        private System.Drawing.Font GetCounterFont()
        {
            if (this.CounterFont == null)
            {
                this.CounterFont = new System.Drawing.Font(Constants.DEFAULT_COUNTER_FONT, Constants.DEFAULT_COUNTER_FONT_SIZE);
            }

            return this.CounterFont;
        }

        /// <summary>
        /// Main game thread render loop
        /// </summary>
        private void Render()
        {
            while (!this.IsExit)
            {
                this.ProcessBallMove();
                this.ProcessLeftPaddleMove();
                this.ProcessRightPaddleMove();

                if (!this.MainControl.IsDisposed)
                {
                    System.Drawing.Graphics graphics = this.GetGraphics();

                    this.Background.Draw(graphics);

                    System.Drawing.Font counterFont = this.GetCounterFont();

                    if (this.LeftCounter == null || this.LeftCounter.Text != this.LeftWins.ToString())
                    {
                        this.LeftCounter = new ScreenText(new Point(0, 0), counterFont, this.LeftWins.ToString());

                        System.Drawing.SizeF leftCounterSize = this.LeftCounter.GetTextSize(graphics);
                        this.LeftCounter.Position.X = (this.MainControl.Width / 2) - (leftCounterSize.Width * 1.5f);
                        this.LeftCounter.Position.Y = (leftCounterSize.Height / 2) - Constants.DEFAULT_BORDER_PADDING;

                    }

                    this.LeftCounter.Draw(graphics);

                    if (this.RightCounter == null || this.RightCounter.Text != this.RightWins.ToString())
                    {
                        this.RightCounter = new ScreenText(new Point(0, 0), counterFont, this.RightWins.ToString());

                        System.Drawing.SizeF rightCounterSize = this.RightCounter.GetTextSize(graphics);
                        this.RightCounter.Position.X = (this.MainControl.Width / 2) + (rightCounterSize.Width * 0.5f);
                        this.RightCounter.Position.Y = (rightCounterSize.Height / 2) - Constants.DEFAULT_BORDER_PADDING;
                    }

                    this.RightCounter.Draw(graphics);

                    this.LeftPaddle.Draw(graphics);
                    this.RightPaddle.Draw(graphics);
                    this.Ball.Draw(graphics);

                    Thread.Sleep(Constants.RENDER_PERIOD);
                }
                else
                {
                    this.IsExit = true;
                }
            }
        }

        /// <summary>
        /// Method for processing ball move on tick
        /// </summary>
        private void ProcessBallMove()
        {
            if (this.GameZone.IsObjectOutsideTop(this.Ball) || this.GameZone.IsObjectOutsideBottom(this.Ball))
            {
                this.BallVector.Y = -this.BallVector.Y;
                this.Ball.Speed *= 1.1f;
            }

            if (this.LeftPaddle.IsPointCollide(this.Ball.Position) || this.RightPaddle.IsPointCollide(this.Ball.Position))
            {
                this.BallVector.X = -this.BallVector.X;
                this.Ball.Speed += 1;
            }

            if (this.GameZone.IsObjectOutsideLeft(this.Ball))
            {
                this.RightWins += 1;
                this.RestartGame();
            }

            if (this.GameZone.IsObjectOutsideRight(this.Ball))
            {
                this.LeftWins += 1;
                this.RestartGame();
            }

            if (this.Ball.Speed > 100)
            {
                this.RestartGame();
            }

            if (this.LeftWins > 99 || this.RightWins > 99)
            {
                this.NewGame();
            }

            this.Ball.Move(this.BallVector);
        }

        /// <summary>
        /// Starts game threads
        /// </summary>
        private void StartThreads()
        {
            this.RenderThread.Start();
        }

        /// <summary>
        /// Game starting, starts game threads
        /// </summary>
        public void Start()
        {
            this.StartThreads();
        }

        /// <summary>
        /// Stops game threads and exits on next tick
        /// </summary>
        private void StopThreads()
        {
            this.IsExit = true;
        }

        /// <summary>
        /// Shutdown game and stop all drawing
        /// </summary>
        public void Stop()
        {
            this.StopThreads();
        }

        /// <summary>
        /// Disposing working game threads
        /// </summary>
        private void DisposeGameThreads()
        {
            this.IsExit = true;
            this.RenderThread.Abort();
        }

        /// <summary>
        /// Class destructor
        /// Dispose Graphics and fonts and game objects
        /// Stop working threads
        /// </summary>
        ~GameType()
        {
            if (this.Graphics != null)
            {
                this.Graphics.Dispose();
            }
            if (this.CounterFont != null)
            {
                this.CounterFont.Dispose();
            }
            this.DisposeGameObjects();
            this.DisposeGameThreads();
        }
    }
}
