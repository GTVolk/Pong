using System;
using System.Collections.Generic;
using Pong.Interfaces;

namespace Pong.Classes
{
    /// <summary>
    /// Base game type class, parent for all game types
    /// </summary>
    abstract class GameType : IGameType
    {
        protected IGameLogic GameLogic { get; set; }
        /// <summary>
        /// Randomizer object
        /// </summary>
        protected Random Randomizer { get; set; }

        /// <summary>
        /// Protected class constructor
        /// </summary>
        /// <param name="control"></param>
        protected GameType(
            IGameLogic gameLogic
        )
        {
            this.Randomizer = new Random();
            this.GameLogic = gameLogic;

            this.CreateGameObjects();
            this.PrepareGame();
        }

        /// <summary>
        /// Abstract method for creation game objects
        /// </summary>
        abstract protected void CreateGameObjects();
        /// <summary>
        /// Abstract method for disposing created game objects
        /// </summary>
        abstract protected void DisposeGameObjects();
        protected abstract void SetGameObjectsByCanvas(ICanvas canvas);
        protected abstract void ProcessGame(object sender, ICanvas canvas);
        /// <summary>
        /// Method for initializing new game
        /// </summary>
        void PrepareGame()
        {
            this.SetGameObjectsByCanvas(this.GameLogic.Renderer.Canvas);
            this.GameLogic.SetRenderingFunction(this.ProcessGame);
        }
        /// <summary>
        /// Abstract method for resseting game
        /// </summary>
        abstract public void RestartGame();

        public void StartGame()
        {
            this.GameLogic.Renderer.Start();
            this.GameLogic.UserInput.StartListening();
        }

        public void StopGame()
        {
            this.GameLogic.Renderer.Stop();
            this.GameLogic.UserInput.StopListening();
        }

        /// <summary>
        /// Class destructor
        /// Dispose Graphics and fonts and game objects
        /// Stop working threads
        /// </summary>
        ~GameType()
        {
            this.DisposeGameObjects();
        }
    }
}
