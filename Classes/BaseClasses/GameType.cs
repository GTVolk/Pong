using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Base game type class, parent for all game types
    /// </summary>
    abstract class GameType : IGameType, IRenderBridge
    {
        #region Fields

        /// <summary>
        /// Game logic object holder for game type logic
        /// </summary>
        protected IGameLogic GameLogic { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Protected class constructor
        /// </summary>
        /// <param name="control"></param>
        protected GameType(
            IGameLogic gameLogic
        )
        {
            this.GameLogic = gameLogic;

            this.GameLogic.Renderer.SetRenderImplementation(this);
        }

        #endregion

        #region Abstract methods

        /// <summary>
        ///  Abstract game update on tick function for BRIDGE pattern
        /// </summary>
        public abstract void ProcessGameUpdate();
        /// <summary>
        /// Abstract render function for BRIDGE pattern
        /// </summary>
        /// <param name="canvas">Canvas on which we will render game</param>
        /// <returns>Objects to render</returns>
        public abstract IDrawable[] GetRenderObjects(ICanvas canvas);

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public void StartGame()
        {
            this.GameLogic.Renderer.StartRendering();
            this.GameLogic.UserInput.StartListening();

            this.GameLogic.NewGame();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopGame()
        {
            this.GameLogic.Renderer.StopRendering();
            this.GameLogic.UserInput.StopListening();
        }

        #endregion
    }
}
