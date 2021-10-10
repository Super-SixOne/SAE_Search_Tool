using GalaSoft.MvvmLight.Command;
using SAE_Search_Tool_Client.Models.BusinessLogic;
using SAE_Search_Tool_Client.Views.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views
{
    public class TitelbarViewModel : ViewModelBase
    {
        #region properties: public

        public ICommand StartSearchCommand => _startSearchCommand = _startSearchCommand ?? new RelayCommand(SearchWordInFiles);

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

        private void SearchWordInFiles()
        {
            if (Datakernel.ExplorerVM.SelectedFiles != null && Datakernel.ExplorerVM.SelectedFiles.Count > 0)
            {
                JsonParser.WriteSearchPaths(Datakernel.ExplorerVM.SelectedFiles);
            }
            else
            {
                MessageBox.Show("Keine Dateien ausgewählt. Diese MessageBox wird ersetzt");
            }
        }

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

        private ICommand _startSearchCommand;

        private ICommand _maximizeWindowCommand;

        private ICommand _minimizeWindowCommand;

        #endregion properties: private
    }
}
