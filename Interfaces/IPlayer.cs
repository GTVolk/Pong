namespace Pong.Interfaces
{
    public interface IPlayer
    {
        IPaddle Paddle { get; set; }
        int Score { get; set; }
    }
}
