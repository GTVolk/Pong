namespace Pong.Interfaces
{
    interface IObject
    {
        double Width { get; set; }
        double Height { get; set; }
        IPoint Position { get; set; }
    }
}
