namespace Pong.Interfaces
{
    interface IPlayer
    {
        IPaddle Paddle { get; set; }
        int Score { get; set; }
    }
}
