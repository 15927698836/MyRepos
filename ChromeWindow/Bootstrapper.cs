using Caliburn.Micro;
using ChromeWindow.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChromeWindow
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //new Summary.Controls.AppBootstrapper().Initialize();
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
