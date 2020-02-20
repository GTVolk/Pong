using System.Drawing;

namespace Pong.Interfaces
{
    interface IDrawable: IObject
    {
        Color BackgroundColor { get; set; }

        void Draw(Graphics graphics);
    }
}
