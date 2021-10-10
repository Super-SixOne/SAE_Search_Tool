using SAE_Search_Tool_Client.Views;
using SAE_Search_Tool_Client.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Client.Views.Logic
{
    public static class Datakernel
    {
        #region Properties

        public static MainViewModel MainVM = _mainVM = _mainVM ?? new MainViewModel();

        public static DashboardViewModel DashboardViewModel = _dashboardVM = _dashboardVM ?? new DashboardViewModel();

        public static SearchResultsViewModel SearchResultsVM = _searchResultsVM = _searchResultsVM ?? new SearchResultsViewModel();

        public static TitelbarViewModel TitelbarViewModel = _titelbarViewModel = _titelbarViewModel ?? new TitelbarViewModel();

        public static DirectoriesViewModel DirectoriesVM = _directoriesVM = _directoriesVM ?? new DirectoriesViewModel();

        public static ExplorerViewModel ExplorerVM = _explorerVM = _explorerVM ?? new ExplorerViewModel();

        #endregion Properties


        #region members

        private static MainViewModel _mainVM;

        private static DashboardViewModel _dashboardVM;

        private static SearchResultsViewModel _searchResultsVM;

        private static DirectoriesViewModel _directoriesVM;

        private static TitelbarViewModel _titelbarViewModel;

        private static ExplorerViewModel _explorerVM;

        #endregion members
    }
}
