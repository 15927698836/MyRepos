using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.ViewModels
{
    /// <summary>
    /// セル描画用のモデルを提供します。
    /// </summary>
    public class CellViewModel
    {
        #region プロパティ
        /// <summary>
        /// 色を取得します。
        /// </summary>
        public ReactiveProperty<Color> Color { get; } = new ReactiveProperty<Color>();
        #endregion
    }
}
