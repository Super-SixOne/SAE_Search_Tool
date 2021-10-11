using SAE_Search_Tool_Client.Models.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Client.Views.ViewModels
{
    public class SearchResultsViewModel : ViewModelBase
    {
        private ObservableCollection<string> _searchResults = new ObservableCollection<string>();
        public ObservableCollection<string> SearchResultPaths { get => _searchResults; set => SetProperty(ref _searchResults, value); }

        public ObservableCollection<Models.BusinessLogic.Models.FileReaderResult> FileReaderResults { get => _fileReaderResults; set => SetProperty(ref _fileReaderResults, value); }

        private ObservableCollection<Models.BusinessLogic.Models.FileReaderResult> _fileReaderResults;

        public SearchResultsViewModel()
        {
            FileReaderResults = new ObservableCollection<Models.BusinessLogic.Models.FileReaderResult>();
            FileReaderResults.Add(new Models.BusinessLogic.Models.FileReaderResult("Path", "content"));
        }
    }
}
