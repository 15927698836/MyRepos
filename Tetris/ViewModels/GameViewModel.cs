using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;

namespace Tetris.ViewModels
{
    /// <summary>
    /// ゲーム全体を描画するためのモデルを提供します。
    /// </summary>
    public class GameViewModel
    {
        #region プロパティ
        /// <summary>
        /// ゲーム本体を取得します。
        /// </summary>
        private Game Game { get; } = new Game();


        /// <summary>
        /// ゲーム結果を取得します。
        /// </summary>
        public GameResultViewModel Result { get; }


        /// <summary>
        /// フィールドの描画用モデルを取得します。
        /// </summary>
        public FieldViewModel Field { get; }


        /// <summary>
        /// 次のテトリミノフィールドの描画用モデルを取得します。
        /// </summary>
        public NextFieldViewModel NextField { get; }


        /// <summary>
        /// プレイ中かどうかを取得します。
        /// </summary>
        public IReadOnlyReactiveProperty<bool> IsPlaying => this.Game.IsPlaying;


        /// <summary>
        /// ゲームオーバー状態になっているかどうかを取得します。
        /// </summary>
        public IReadOnlyReactiveProperty<bool> IsOver => this.Game.IsOver;
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public GameViewModel()
        {
            this.Result = new GameResultViewModel(this.Game.Result);
            this.Field = new FieldViewModel(this.Game.Field);
            this.NextField = new NextFieldViewModel(this.Game.NextTetrimino);
        }
        #endregion


        #region 操作
        /// <summary>
        /// ゲームを開始します。
        /// </summary>
        public void Play() => this.Game.Play();
        #endregion
    }
}
