namespace Pong.Interfaces
{
    interface IMoveable: IObject
    {
        IPoint Vector { get; set; }
        double Speed { get; set; }
        void Move();
    }
}
