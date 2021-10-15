using GalaSoft.MvvmLight.Command;
using SAE_Search_Tool_Client.Models.DataAccess;
using SAE_Search_Tool_Client.Views.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SAE_Search_Tool_Client.Models.BusinessLogic.Models;

namespace SAE_Search_Tool_Client.Views.ViewModels
{
    public class SearchResultsViewModel : ViewModelBase
    {
        public ObservableCollection<Models.BusinessLogic.Models.FileReaderResult> FileReaderResults { get => _fileReaderResults; set => SetProperty(ref _fileReaderResults, value); }

        public Models.BusinessLogic.Models.FileReaderResult SelectedPath { get => _selectedPath; set => SetProperty(ref _selectedPath, value); }

        public string SelectedContent { get => _selectedContent; set => SetProperty(ref _selectedContent, value); }

        public ICommand SelectedPathChangedCommand => _selectedPathChangedCommand = _selectedPathChangedCommand ?? new RelayCommand(GetSelectedItemContent);


        private void GetSelectedItemContent()
        {
            if (SelectedPath != null)
            {
                SelectedContent = SelectedPath.Content;
            }
        }

        private ObservableCollection<Models.BusinessLogic.Models.FileReaderResult> _fileReaderResults;
        private string _selectedContent;
        private Models.BusinessLogic.Models.FileReaderResult _selectedPath;
        private ICommand _selectedPathChangedCommand;

    }
}
