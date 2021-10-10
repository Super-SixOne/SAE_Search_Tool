using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views.ViewModels
{
    public class DirectoriesViewModel : ViewModelBase
    {
        #region properties: public

        public ObservableCollection<string> Drives
        {
            get => _drives;
            set => SetProperty(ref _drives, value);
        }

        public ObservableCollection<string> Directories
        {
            get => _directories;
            set => SetProperty(ref _directories, value);
        }

        public ObservableCollection<string> SubDirectories
        {
            get => _subDirectories;
            set => SetProperty(ref _subDirectories, value);
        }

        public ObservableCollection<string> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        public ObservableCollection<string> SelectedFiles
        {
            get { return _selectedFiles; }
            set => SetProperty(ref _selectedFiles, value);
        }

        public string SelectedDrive
        {
            get => _selectedDrive;
            set => SetProperty(ref _selectedDrive, value);
        }

        public string SelectedDirectory
        {
            get => _selectedDirectory;
            set => SetProperty(ref _selectedDirectory, value);
        }

        #endregion properties: public


        #region Commands

        public ICommand SelectedDriveChangedCommand => _selectedDriveChangedCommand = _selectedDriveChangedCommand ?? new RelayCommand(GetDirectoriesFromDrive);

        public ICommand SelectedDirectoryChangedCommand => _selectedDirectoryChangedCommand = _selectedDirectoryChangedCommand ?? new RelayCommand(GetFilesFromDirectories);

        #endregion Commands


        #region commands: logic

        private void GetDirectoriesFromDrive()
        {
            if (SelectedDrive == null)
            {
                return;
            }

            DriveInfo info = new DriveInfo(SelectedDrive);
            string driveName = info.Name;

            Directories = new ObservableCollection<string>(Directory.GetDirectories(driveName).ToList());

        }

        private void GetFilesFromDirectories()
        {
            if (SelectedDirectory == null)
            {
                return;
            }

            if (Files != null)
            {
                Files.Clear();
            }

            try
            {
                SubDirectories = new ObservableCollection<string>(Directory.GetDirectories(SelectedDirectory));

                foreach (string item in SubDirectories)
                {
                    ObservableCollection<string> subSub = new ObservableCollection<string>(Directory.GetDirectories(item));

                    if (subSub.Count > 0)
                    {
                        int stop = 5;
                    }

                }

                Files = new ObservableCollection<string>(Directory.GetFiles(SelectedDirectory));
            }
            catch (Exception ex)
            {
                // TODO Steven logging
            }
        }

        #endregion commands: logic


        #region properties: private

        private ObservableCollection<string> _drives;
        private ObservableCollection<string> _directories;
        private ObservableCollection<string> _subDirectories;
        private ObservableCollection<string> _files;
        private ObservableCollection<string> _selectedFiles;

        private string _selectedDrive;
        private string _selectedDirectory;

        #endregion properties: private


        #region commands: private

        private ICommand _selectedDriveChangedCommand;
        private ICommand _selectedDirectoryChangedCommand;

        #endregion commands: private
    }
}
