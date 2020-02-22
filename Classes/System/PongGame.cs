using System.Windows.Forms;
using Pong.Interfaces;

namespace Pong.Classes
{
    class PongGame: IPongGame
    {
        private IGameType GameType { get; set; }
        private IUserInput UserInput { get; set; }
        private IGameLogic GameLogic { get; set; }
        private IRenderer Renderer { get; set; }

        public PongGame(
            ICanvas canvas
        )
        {
            this.UserInput = new UserInput(canvas.GetParent());
            this.Renderer = new Renderer(canvas);
            this.GameLogic = new GameLogic(this.UserInput, this.Renderer);
            this.GameType = new DemoGame(this.GameLogic);
        }

        public void StartGame()
        {
            this.GameType.StartGame();
        }

        public void StopGame()
        {
            this.GameType.StopGame();
        }
    }
}
