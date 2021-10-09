using SAE_Search_Tool_Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Client.views.Logic
{
    static class Datakernel
    {
        public static MainViewModel MainVM = _mainVM = _mainVM ?? new MainViewModel();

        public static DashboardViewModel DashboardViewModel = _dashboardVM ?? new DashboardViewModel();

        public static TitelbarViewModel TitelbarViewModel = _titelbarViewModel ?? new TitelbarViewModel();



        private static MainViewModel _mainVM;
        private static DashboardViewModel _dashboardVM;
        private static TitelbarViewModel _titelbarViewModel;

    }
}
