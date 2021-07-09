﻿using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views
{
    class DashboardViewModel : ViewModelBase
    {
        #region properties: public

        public string CurrentDirectory
        {
            get => _currentDirectory;
            set => SetProperty(ref _currentDirectory, value);
        }

        public List<string> Drives
        {
            get => _drives;
            set => SetProperty(ref _drives, value);
        }

        public List<string> Directories
        {
            get => _directories;
            set => SetProperty(ref _directories, value);
        }

        #endregion properties: public

        public DashboardViewModel()
        {

        }

        #region commands: public

        public ICommand LoadDirectoriesCommand
        {
            get
            {
                if (_loadDirectories == null)
                {
                    _loadDirectories = new RelayCommand(ScanDirectories);
                }
                return _loadDirectories;
            }
        }

        #endregion commands: public



        #region methods: private

        private void ScanDirectories()
        {
            // Pfad zur exe -> Pfad für Json
            CurrentDirectory = Directory.GetCurrentDirectory();

            // Alle Laufwerke
            Drives = Directory.GetLogicalDrives().ToList();

            // Infos der Laufwerke ermitteln
            DriveInfo info = null;
            string driveName = string.Empty;

            foreach (string drive in Drives)
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



        #region properties: private

        private string _currentDirectory;

        private List<string> _drives;

        private List<string> _directories;


        #endregion properties: private



        #region commands: private

        private ICommand _loadDirectories;

        #endregion commands: private

    }
}