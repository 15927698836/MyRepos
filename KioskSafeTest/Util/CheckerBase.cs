using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KioskSafeTest.Util
{
    public abstract class CheckerBase : Icheker
    {
        public event EventHandler CheckComplete;


        public virtual void Check()
        {
            OnCheckComplete(new MyEventArgs(/*arguments*/));
        }

        public virtual void OnCheckComplete(MyEventArgs e)
        {
            CheckComplete?.Invoke(this, e);
        }
        public class MyEventArgs : EventArgs
        {
            // class members  
        }
    }

}
