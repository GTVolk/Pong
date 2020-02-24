using System.Drawing;

namespace Pong.Interfaces
{
    public interface IDrawable: IObject
    {
        Color BackgroundColor { get; set; }
        void Draw(Graphics graphics);
    }
}
