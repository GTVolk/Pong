using Pong.Interfaces;

namespace Pong.Classes
{
    class PlayerHuman: Player, IPlayerHuman
    {
        public PlayerHuman(
            IPaddle paddle
        ) : base(
            paddle
        ) {}
    }
}
