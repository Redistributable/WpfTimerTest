using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTimerTest.ViewModels.Base
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        // 非公開フィールド


        // 公開プロパティ


        // 非公開イベント
        private event PropertyChangedEventHandler propertyChanged;

        
        // 公開イベント

        /// <summary>
        /// プロパティが変化した際に発生します．
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => this.propertyChanged += value;
            remove => this.propertyChanged -= value;
        }


        // コンストラクタ

        /// <summary>
        /// 新しいViewModelBaseクラスのインスタンスを初期化します．
        /// </summary>
        public ViewModelBase()
        {
            this.propertyChanged = delegate { };
        }


        // 限定公開メソッド

        protected void RaisePropertyChanged(string propertyName)
        {
            this.propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
