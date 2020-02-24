namespace Pong.Interfaces
{
    public interface IRenderer
    {
        ICanvas Canvas { get; set; }
        void SetRenderImplementation(IRenderBridge implementation);
        void StartRendering();
        void StopRendering();
    }
}
