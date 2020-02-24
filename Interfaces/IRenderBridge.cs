namespace Pong.Interfaces
{
    public interface IRenderBridge
    {
        void ProcessGameUpdate();
        IDrawable[] GetRenderObjects(ICanvas canvas);
    }
}
