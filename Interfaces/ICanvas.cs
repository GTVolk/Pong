using System.Windows.Forms;
using System.Drawing;

namespace Pong.Interfaces
{
    public interface ICanvas
    {
        double GetWidth();
        double GetHeight();
        Graphics GetGraphics();
        Control GetParent();
    }
}
