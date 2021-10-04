using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views
{
    class TitelbarViewModel : ViewModelBase
    {
        #region properties: public

        

        public ICommand MaximizeWindowCommand
        {
            get
            {
                if (_maximizeWindowCommand == null)
                {
                    _maximizeWindowCommand = new RelayCommand(MaximizeWindow);
                }
                return _maximizeWindowCommand;
            }
        }

        public ICommand MinimizeWindowCommand
        {
            get
            {
                if (_minimizeWindowCommand == null)
                {
                    _minimizeWindowCommand = new RelayCommand(MinimizeWindow);
                }
                return _minimizeWindowCommand;
            }
        }

        #endregion properties: public



        #region methods: private

        private void MaximizeWindow()
        {
            //Application.Current.MainWindow.Height = 
        }

        private void MinimizeWindow()
        {
            //Application.Current.MainWindow.Height = 
        }

        #endregion methods: private



        #region properties: private

        private ICommand _maximizeWindowCommand;

        private ICommand _minimizeWindowCommand;

        #endregion properties: private
    }
}
