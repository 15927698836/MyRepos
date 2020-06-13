using Caliburn.Micro;
using Snake.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

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

        protected override void OnViewLoaded(object view)
        {
            HomeView home = view as HomeView;
            home.container.Children.Add(GetCircle());
        }
        public UIElement GetCircle()
        {

            Path path = new Path();
            path.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF7F7F7"));
            path.Fill= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF885DE7"));
            path.Data = new EllipseGeometry(new Point(100,100),30,30);
            path.StrokeThickness = 3;

            Canvas.SetTop(path, 0);
            Canvas.SetLeft(path, 0);
            return path;
        }



    }
}
