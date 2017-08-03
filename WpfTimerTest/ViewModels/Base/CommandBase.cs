using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTimerTest.ViewModels.Base
{
    class CommandBase : ICommand
    {
        // 非公開フィールド
        private Action<Object> execute;
        private Func<Object, bool> checkCanExecute;


        // 公開プロパティ

        // 公開イベント

        /// <summary>
        /// CanExecuteの状態が変化したときに発生します．
        /// </summary>
        public event EventHandler CanExecuteChanged;


        // コンストラクタ

        /// <summary>
        /// 新しいCommandクラスのインスタンスを初期化します．
        /// </summary>
        /// <param name="execute">実行内容を示すAction</param>
        /// <param name="checkCanExecute">実行可能な状態であるかどうかを示すFunc</param>
        public CommandBase(Action<Object> execute, Func<Object, bool> checkCanExecute)
        {
            this.execute = execute;
            this.checkCanExecute = checkCanExecute;

            this.CanExecuteChanged += delegate { };
        }

        /// <summary>
        /// 新しいCommandクラスのインスタンスを初期化します．
        /// </summary>
        /// <param name="execute">実行内容を示すAction</param>
        public CommandBase(Action<Object> execute)
            : this(execute, param => true)
        {
        }


        // 限定公開メソッド

        /// <summary>
        /// 実行可能であるかどうかを示す値が変化したことを通知します．
        /// </summary>
        protected void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged(this, new EventArgs());
        }


        // 公開メソッド

        /// <summary>
        /// コマンドを実行します．
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            var action = this.execute;
            if (action != null)
                action(parameter);
        }

        /// <summary>
        /// コマンドが利用可能であるかどうかを示す値を取得します．
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return this.checkCanExecute(parameter);
        }
    }
}
