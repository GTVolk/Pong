namespace Pong.Interfaces
{
    public interface IGameLogic
    {
        IUserInput UserInput { get; set; }
        IRenderer Renderer { get; set; }
        void MoveBall(IGameZone zone, IBall ball);
        void MovePaddle(IGameZone zone, IPaddle paddle);
        void AddScore(IPlayer player, int amount);
        IPlayerHuman AddHumanPlayer(IPaddle paddle);
        IPlayerAI AddAIPlayer(IPaddle paddle, IBall ball);
        bool IsBallOutOnLeft(IGameZone zone, IBall ball);
        bool IsBallOutOnRight(IGameZone zone, IBall ball);
        void ProcessAIMovement();
        void NewGame();
        void RestartGame();
    }
}
