using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IView
    {
        int ShowMoveCount();
        string ShowTimer();
        string End();
        void Start();
    }
}
