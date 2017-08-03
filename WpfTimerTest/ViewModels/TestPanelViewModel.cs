using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

using WpfTimerTest.ViewModels.Base;

namespace WpfTimerTest.ViewModels
{
    class TestPanelViewModel : ViewModelBase
    {
        // 非公開フィールド
        private string testButtonText;
        private CommandBase testButtonClickCommand;
        private DispatcherTimer timer;


        // 公開プロパティ

        public string TestButtonText
        {
            get => this._getTestButtonText();
            set => this._setTestButtonText(value);
        }

        public CommandBase TestButtonClickCommand
        {
            get => this.testButtonClickCommand;
        }


        // コンストラクタ

        /// <summary>
        /// 新しいTestPanelViewModelクラスのインスタンスを初期化します．
        /// </summary>
        public TestPanelViewModel()
        {
            this.testButtonText = "テスト";
            this.testButtonClickCommand = new CommandBase(this._testButtonClickProc);

            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Tick += (sender, e) => this.TestButtonText = DateTime.Now.ToLongTimeString();
        }


        // 非公開メソッド


        // 非公開メソッド :: プロパティ

        private string _getTestButtonText()
        {
            return this.testButtonText;
        }

        private void _setTestButtonText(string value)
        {
            this.testButtonText = value;
            this.RaisePropertyChanged("TestButtonText");
        }


        // 非公開メソッド :: コマンド
        
        private void _testButtonClickProc(Object parameter)
        {
            if (this.timer.IsEnabled)
                this.timer.Stop();
            else
                this.timer.Start();
        }


        // 非公開メソッド :: イベント


        // 公開メソッド

    }
}
