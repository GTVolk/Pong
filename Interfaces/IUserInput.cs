using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.Interfaces
{
    interface IUserInput
    {
        void StartListening();
        void StopListening();
    }
}
