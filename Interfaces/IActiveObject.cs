namespace Pong.Interfaces
{
    interface IActiveObject: IDrawable, IMoveable {
        double Speed { get; set; }
    }
}
