using Caliburn.Micro;
using Snake.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {

        }

        public void StartGame()
        {
            ActivateItem(new HomeViewModel());
        }

        public void Loaded()
        {

        }

  
    }
}
