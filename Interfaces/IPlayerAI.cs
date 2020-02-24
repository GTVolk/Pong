namespace Pong.Interfaces
{
    public interface IPlayerAI: IPlayer
    {
        IBall Ball { get; set; }
        void DecideMove();
    }
}
