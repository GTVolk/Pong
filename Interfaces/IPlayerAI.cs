namespace Pong.Interfaces
{
    interface IPlayerAI: IPlayer
    {
        void AddBallToWatch(IBall ball);

        void DecideMove();
    }
}
