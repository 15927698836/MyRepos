using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.ViewModels
{
    [Export(typeof(HomeViewModel))]
    public class HomeViewModel : Screen, INotifyPropertyChanged
    {
        private int count;

        /// <summary>
        /// 蛇身长度
        /// </summary>
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                NotifyOfPropertyChange();
            }
        }

        public HomeViewModel()
        {

        }
        public void Loaded()
        {

        }
    }
}
