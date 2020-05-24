using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.ViewModels
{
    [Export(typeof(StartViewModel))]
    public class StartViewModel : Conductor<object>
    {



        protected override void OnViewLoaded(object view)
        {
            ActivateItem(new HomeViewModel());
        }

        public void Start()
        { 
              ActivateItem(new HomeViewModel());
        }
    }
}
