namespace Pong.Interfaces
{
    interface IPaddle: IActiveObject
    {
        bool IsPointCollide(IPoint point);
    }
}
