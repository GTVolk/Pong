using System.Drawing;

namespace Pong.Interfaces
{
    public interface IScreenText: IStaticObject {
        string Text { get; set; }
        SizeF GetTextSize(Graphics graphics);
    }
}
