using GalaSoft.MvvmLight.Command;
using SAE_Search_Tool_Client.Views.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views
{
    public class DashboardViewModel : ViewModelBase
    {
        #region ctor

        public DashboardViewModel() { }

        #endregion ctor


        #region Commands: public

        public ICommand LoadDrivesCommand => _loadDrivesCommand = _loadDrivesCommand ?? new RelayCommand(ScanDrives);

        #endregion Commands: public


        private void ScanDrives() => Datakernel.ExplorerVM.Drives = new ObservableCollection<string>(Directory.GetLogicalDrives().ToList());
        //private void ScanDrives() => Datakernel.DirectoriesVM.Drives = new ObservableCollection<string>(Directory.GetLogicalDrives().ToList());
        

        #region methods: private

        private void ScanDirectories()
        {
            // Alle Laufwerke
            Datakernel.DirectoriesVM.Drives = new ObservableCollection<string>(Directory.GetLogicalDrives().ToList());

            // Infos der Laufwerke ermitteln
            DriveInfo info = null;
            string driveName = string.Empty;

            foreach (string drive in Datakernel.DirectoriesVM.Drives)
            {
                info = new DriveInfo(drive);
                driveName = info.Name;
            }

            List<string> directories = Directory.GetDirectories(driveName).ToList();
            string[] files = null;

            foreach (string directory in directories)
            {
                try
                {
                    files = Directory.GetFiles(directory);
                }
                catch (Exception ex)
                {

                }
            }


            MessageBox.Show("Klappt");
        }

        #endregion methods: private


        #region commands: private

        private ICommand _loadDrivesCommand;

        #endregion commands: private

    }
}
