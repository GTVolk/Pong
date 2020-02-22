using System.Collections.Generic;

namespace Pong.Interfaces
{
    interface IGameLogic
    {
        IUserInput UserInput { get; set; }
        IRenderer Renderer { get; set; }
        void MoveBall(IGameZone zone, IBall ball);
        void MovePaddle(IGameZone zone, IPaddle paddle);
        void AddScore(IPlayer player, int amount);
        IPlayerHuman AddHumanPlayer(IPaddle paddle);
        IPlayerAI AddAIPlayer(IPaddle paddle);
        void SetRenderingFunction(RenderEvent renderEvent);
        bool CheckBallOutLeft(IGameZone zone, IBall ball);
        bool CheckBallOutRight(IGameZone zone, IBall ball);
        void ProcessAIMovement();
    }
}
