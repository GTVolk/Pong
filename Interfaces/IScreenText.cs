using System.Drawing;

namespace Pong.Interfaces
{
    interface IScreenText: IStaticObject {
        string Text { get; set; }
        SizeF GetTextSize(Graphics graphics);
    }
}
