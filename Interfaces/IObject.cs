namespace Pong.Interfaces
{
    public interface IObject
    {
        double Width { get; set; }
        double Height { get; set; }
        IPoint Position { get; set; }
    }
}
