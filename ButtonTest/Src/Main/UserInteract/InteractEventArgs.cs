using System;
using System.Collections.Generic;
using System.Text;

namespace ButtonTest.Src.Main.UserInteract
{
    class InteractEventArgs : EventArgs
    {
        public object Information;

        public InteractEventArgs(object information)
        {
            this.Information = information;
        }
    }
}
