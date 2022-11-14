using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class FormView : IView
    {
        public string End()
        {
            return "";
        }

        public int ShowMoveCount()
        {
            return 1;
        }

        public string ShowTimer()
        {
            return "";
        }

        public void Start()
        {
            // Should be happy with just being blank
        }
    }
}
