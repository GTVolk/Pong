namespace Pong.Interfaces
{
    interface IGameZone: IObject {
        bool IsObjectOutsideTop(IObject obj);
        bool IsObjectOutsideBottom(IObject obj);
        bool IsObjectOutsideLeft(IObject obj);
        bool IsObjectOutsideRight(IObject obj);
    }
}
