using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Interfaces
{
    public delegate void RenderEvent(object sender, ICanvas canvas);

    interface IRenderer
    {
        event RenderEvent OnRender;
        ICanvas Canvas { get; set; }
        List<IDrawable> ObjectsToDraw { get; set; }

        void Start();
        void Stop();
    }
}
