using KioskSafeTest.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskSafeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Icheker icheker = new CheckLibrary();
            icheker.CheckComplete += Icheker_CheckComplete;

            icheker.Check();
            Console.ReadKey();
        }

        private static void Icheker_CheckComplete(object sender, EventArgs e)
        {
            Console.WriteLine("检测完毕");
        }
    }
}
