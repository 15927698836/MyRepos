using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSafe.Unity.Util
{
    interface Icheker
    {
        event EventHandler CheckComplete;

        void Check();
    }

    public class MyEventArgs : EventArgs
    {
        // class members
    }
}
