using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSafeTest.Util
{
    public class CheckLibrary : CheckerBase
    {
        public CheckLibrary()
        {
            
        }

        public override void Check()
        {
            Console.WriteLine("检测....");
            base.Check();
        }
    }
}
