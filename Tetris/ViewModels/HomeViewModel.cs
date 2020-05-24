using Caliburn.Micro;
using Tetris.Views;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System;
using System.Windows.Media.Animation;
using System.Windows.Input;

namespace Tetris.ViewModels
{
    [Export(typeof(HomeViewModel))]
    public class HomeViewModel : Screen, INotifyPropertyChanged, IHandle<string>
    {
        readonly IEventAggregator _event;
        //画板,用来放置俄罗斯方块
        Canvas _canvas;

        private RotateTransform rt_FanRotate = new RotateTransform();   //做旋转动
        private DoubleAnimation da_FanRotate = new DoubleAnimation();   //数值类型
        private Storyboard _storyboard = new Storyboard();             //故事板

        [ImportingConstructor]
        public HomeViewModel()
        {
            //events.Subscribe(this);

            _event = IoC.Get<IEventAggregator>();
            _event.Subscribe(this);
        }

        protected override void OnViewLoaded(object view)
        {
            HomeView home = view as HomeView;
            _canvas = new Canvas();
            home.activeArea.Child = _canvas;


            //canvas.Children.Add(GetBlock("T", new Point(0, 0)));
            Init();
        }

        /// <summary>
        /// 绘制基本方块
        /// </summary>
        /// <param name="point">坐标</param>
        /// <returns></returns>
        public Rectangle GetRect(Point point)
        {
            Rectangle rect = new Rectangle
            {
                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEEEEEE")),
                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8444B6")),
                StrokeThickness = 1,
                Width = 38,
                Height = 38,
            };
            Canvas.SetLeft(rect, point.X * 40);
            Canvas.SetBottom(rect, point.Y * 40);
            return rect;
        }

        /// <summary>
        /// 组装方块，七种类型 O,I,S,Z,L,J,T
        /// </summary> 
        /// <param name="type">方块类型</param>
        /// <param name="point">坐标</param>
        /// <returns></returns>
        public Canvas GetBlock(string type, Point point)
        {
            Canvas block = new Canvas();
            switch (type)
            {
                case "O":
                    block.Children.Add(GetRect(new Point(0, 0)));
                    block.Children.Add(GetRect(new Point(0, 1)));
                    block.Children.Add(GetRect(new Point(1, 0)));
                    block.Children.Add(GetRect(new Point(1, 1)));
                    break;
                case "I":
                    block.Children.Add(GetRect(new Point(0, 0)));
                    block.Children.Add(GetRect(new Point(0, 1)));
                    block.Children.Add(GetRect(new Point(0, 2)));
                    block.Children.Add(GetRect(new Point(0, 3)));
                    break;
                case "S":
                    block.Children.Add(GetRect(new Point(0, 0)));
                    block.Children.Add(GetRect(new Point(1, 0)));
                    block.Children.Add(GetRect(new Point(1, 1)));
                    block.Children.Add(GetRect(new Point(2, 1)));
                    break;
                case "Z":
                    block.Children.Add(GetRect(new Point(0, 1)));
                    block.Children.Add(GetRect(new Point(1, 1)));
                    block.Children.Add(GetRect(new Point(1, 0)));
                    block.Children.Add(GetRect(new Point(2, 0)));
                    break;
                case "L":
                    block.Children.Add(GetRect(new Point(0, 1)));
                    block.Children.Add(GetRect(new Point(1, 1)));
                    block.Children.Add(GetRect(new Point(1, 0)));
                    block.Children.Add(GetRect(new Point(2, 0)));
                    break;
                case "J":
                    block.Children.Add(GetRect(new Point(0, 0)));
                    block.Children.Add(GetRect(new Point(1, 0)));
                    block.Children.Add(GetRect(new Point(1, 1)));
                    block.Children.Add(GetRect(new Point(1, 2)));
                    break;
                case "T":
                    block.Children.Add(GetRect(new Point(0, 1)));
                    block.Children.Add(GetRect(new Point(1, 1)));
                    block.Children.Add(GetRect(new Point(2, 1)));
                    block.Children.Add(GetRect(new Point(1, 0)));
                    break;
                default:

                    break;
            }
            Canvas.SetLeft(block, point.X);
            Canvas.SetBottom(block, point.Y);
            return block;
        }


        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            //方块初始位置
            Point p = new Point(4 * 40, 17 * 40);
            //生成初始方块方块
            Canvas canvas = GetBlock(GetRandomType(), p);
            _canvas.Children.Add(canvas);
            StartAutoMove(canvas, p);

        }
        /// <summary>
        /// 开始自动X轴移动方块
        /// </summary>
        public void StartAutoMove(Canvas canvas, Point point)
        {
            //创建x轴动画
            DoubleAnimation da = new DoubleAnimation();
            da.From = point.Y;
            da.To = 0;
            da.Duration = TimeSpan.FromSeconds(5);
            Storyboard.SetTarget(da, canvas);
            Storyboard.SetTargetProperty(da, new PropertyPath(Canvas.BottomProperty));
            _storyboard.Children.Add(da);

            //动画播放 
            _storyboard.Begin();
        }

        public string GetRandomType()
        {
            string[] s = new string[] { "O", "I", "S", "Z", "L", "J", "T" };
            return s[new Random().Next(0, 6)];
        }
     

        public void Handle(string message)
        {
            
        }

    
    }
}
