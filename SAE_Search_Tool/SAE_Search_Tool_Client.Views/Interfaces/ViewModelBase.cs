using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views
{
    public abstract class ViewModelBase : NotificationBase
    {

        #region properties: public

        public ICommand CloseCommand => _closeCommand = _closeCommand ?? new RelayCommand(Close);

        public ICommand MoveCommand => _moveCommand = _moveCommand ?? new RelayCommand(MoveWindow);

        #endregion properties: public



        #region methods: private

        private void Close() => Application.Current.Shutdown();

        private void MoveWindow() => Application.Current.MainWindow.DragMove();

        #endregion methods: private



        #region properties: private

        private ICommand _closeCommand;

        private ICommand _moveCommand;

        #endregion properties: private
    }
}