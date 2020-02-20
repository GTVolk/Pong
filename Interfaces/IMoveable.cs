namespace Pong.Interfaces
{
    interface IMoveable: IObject
    {
        void Move(IPoint vector);
    }
}
