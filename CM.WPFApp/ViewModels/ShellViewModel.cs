using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WPFApp.ViewModels
{
    [Export(typeof(ShellViewModel))]
    class ShellViewModel : Conductor<object>
    {

    }
}
