using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WpfAnimationDemo.Views;

namespace WpfAnimationDemo.ViewModels
{
    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : Screen
    {
        private Rectangle myVar;

        public Rectangle MyRectangle
        {
            get
            {
                return myVar;
            }
            set
            {
                myVar = value;
                NotifyOfPropertyChange("MyRectangle");
            }
        }

        public ShellViewModel()
        {

        }

        public void Loaded(ShellView view)
        {
           

        }
    }
}
