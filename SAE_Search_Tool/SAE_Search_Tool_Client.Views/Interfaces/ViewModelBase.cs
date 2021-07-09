using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views
{
    public abstract class ViewModelBase : NotificationBase
    {

        #region properties: public

        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(Close);
                }
                return _closeCommand;
            }
        }

        public ICommand MoveCommand
        {
            get
            {
                if (_moveCommand == null)
                {
                    _moveCommand = new RelayCommand(MoveWindow);
                }
                return _moveCommand;
            }
        }

        #endregion properties: public



        #region methods: private

        private void Close()
        {
            Application.Current.Shutdown();
        }

        private void MoveWindow()
        {
            Application.Current.MainWindow.DragMove();
        }

        #endregion methods: private



        #region properties: private

        private ICommand _closeCommand;

        private ICommand _moveCommand;

        #endregion properties: private
    }
}