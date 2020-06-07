using Caliburn.Micro;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Tetris.Extensions;
using Tetris.Models;
using Tetris.Views;

namespace Tetris.ViewModels
{
    [Export(typeof(HomeViewModel))]
    public class HomeViewModel : Screen, INotifyPropertyChanged, IHandle<object>
    {
        private readonly IEventAggregator _event;

        private GameViewModel game;
        public GameViewModel Game
        {
            get { return game; }
            set { game = value; }
        }


        [ImportingConstructor]
        public HomeViewModel()
        {
            _event = IoC.Get<IEventAggregator>();
            _event.Subscribe(this);
        }
        /// <summary>
        /// 界面加载完毕
        /// </summary>
        /// <param name="view"></param>
        protected override void OnViewLoaded(object view)
        {
            HomeView home = view as HomeView;

            this.Game = new GameViewModel();

            Grid field = home.field;
            Grid nextField = home.nextField;
            this.SetupField(field, this.Game.Field.Cells, 30);
            this.SetupField(nextField, this.Game.NextField.Cells, 18);
            this.Game.Play();
        }


        #region 初始化
        /// <summary>
        /// フィールド準備を行います。
        /// </summary>
        /// <param name="field">フィールドとなる Grid</param>
        /// <param name="cells">セルの描画用モデル</param>
        /// <param name="blockSize">ブロックサイズ</param>
        private void SetupField(Grid field, CellViewModel[,] cells, byte blockSize)
        {
            //--- 行/列の定義
            for (int r = 0; r < cells.GetLength(0); r++)
                field.RowDefinitions.Add(new RowDefinition { Height = new GridLength(blockSize, GridUnitType.Pixel) });

            for (int c = 0; c < cells.GetLength(1); c++)
                field.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(blockSize, GridUnitType.Pixel) });

            //--- セル設定
            foreach (var item in cells.WithIndex())
            {
                //--- 背景色をバインド
                var brush = new SolidColorBrush();
                var control = new TextBlock
                {
                    DataContext = item.Element,
                    Background = brush,
                    Margin = new Thickness(1),
                };
                BindingOperations.SetBinding(brush, SolidColorBrush.ColorProperty, new Binding("Color.Value"));

                //--- 确定位置作为子元素添加
                Grid.SetRow(control, item.X);
                Grid.SetColumn(control, item.Y);
                field.Children.Add(control);
            }
        }
        #endregion


        /// <summary>
        /// 接收按键事件
        /// </summary>
        public void Handle(object par)
        {
            switch (((KeyEventArgs)par).Key)
            {
                case Key.Z: this.Game.Field.RotationTetrimino(RotationDirection.Left); break;
                case Key.X: this.Game.Field.RotationTetrimino(RotationDirection.Right); break;
                case Key.Up: this.Game.Field.RotationTetrimino(RotationDirection.Right); break;
                case Key.Right: this.Game.Field.MoveTetrimino(MoveDirection.Right); break;
                case Key.Down: this.Game.Field.MoveTetrimino(MoveDirection.Down); break;
                case Key.Left: this.Game.Field.MoveTetrimino(MoveDirection.Left); break;
                case Key.Escape: this.Game.Play(); break;
                case Key.Space: this.Game.Field.ForceFixTetrimino(); break;
            }
        }
    }
}