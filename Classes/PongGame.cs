using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Class representing pong game object
    /// </summary>
    class PongGame: IPongGame
    {
        #region Fields

        /// <summary>
        /// Game type object holder
        /// </summary>
        private IGameType GameType { get; set; }
        /// <summary>
        /// Game user input controller object holder
        /// </summary>
        private IUserInput UserInput { get; set; }
        /// <summary>
        /// Game logic object holder
        /// </summary>
        private IGameLogic GameLogic { get; set; }
        /// <summary>
        /// Game renderer object holder
        /// </summary>
        private IRenderer Renderer { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Pong game class constructor
        /// </summary>
        /// <param name="canvas">Canvas object</param>
        public PongGame(
            ICanvas canvas
        )
        {
            this.UserInput = new UserInput(canvas.GetParent());
            this.Renderer = new Renderer(canvas);
            this.GameLogic = new GameLogic(this.UserInput, this.Renderer);
            this.GameType = new DemoGame(this.GameLogic);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts game
        /// </summary>
        public void StartGame()
        {
            this.GameType.StartGame();
        }

        /// <summary>
        /// Stops game
        /// </summary>
        public void StopGame()
        {
            this.GameType.StopGame();
        }

        #endregion
    }
}
