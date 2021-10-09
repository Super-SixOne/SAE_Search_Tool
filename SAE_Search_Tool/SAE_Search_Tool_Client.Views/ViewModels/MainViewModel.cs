using GalaSoft.MvvmLight.Command;
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
    public class MainViewModel : ViewModelBase
    {

        #region properties: public

        public ObservableCollection<string> GetAllFiles()
        {
            return Files;
        }

        public int CurrentView { get; set; }

        /// <summary>
        /// Viewansichten
        /// </summary>
        public enum Views
        {
            ViewDirectory,
        }

        public int SwitchView
        {
            get => switchView;
            set => SetProperty(ref switchView, value);
        }

        // TODO nur für Steven -> Json Speicherort
        public string DirectoryOfExe
        {
            get => _directoryOfExe;
            set => SetProperty(ref _directoryOfExe, value);
        }

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


        #region Commands: public

        public ICommand LoadDrivesCommand => _loadDrivesCommand = _loadDrivesCommand ?? new RelayCommand(ScanDrives);

        public ICommand SelectedDriveChangedCommand => _selectedDriveChangedCommand = _selectedDriveChangedCommand ?? new RelayCommand(GetDirectoriesFromDrive);

        public ICommand SelectedDirectoryChangedCommand => _selectedDirectoryChangedCommand = _selectedDirectoryChangedCommand ?? new RelayCommand(GetFilesFromDirectories);

        #endregion Commands: public


        #region ctor

        public MainViewModel()
        {

        }

        #endregion ctor


        #region methods: private

        private void ScanDrives()
        {
            Drives = new ObservableCollection<string>(Directory.GetLogicalDrives().ToList());
        }

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
                Files = new ObservableCollection<string>(Directory.GetFiles(SelectedDirectory));
            }
            catch (Exception ex)
            {
                // TODO Steven logging
            }
        }

        private void GetCurrentDirectory()
        {
            // TODO Steven
            // Pfad zur exe -> Pfad für Json
            DirectoryOfExe = Directory.GetCurrentDirectory();
        }

        // TODO Steven: Was passiert mit den ausgewählten Dateien?

        #endregion methods: private


        #region properties: private

        private ICommand _loadDrivesCommand;
        private ICommand _selectedDriveChangedCommand;
        private ICommand _selectedDirectoryChangedCommand;

        // TODO Steven -> Json Speicherort
        private string _directoryOfExe;

        private ObservableCollection<string> _drives;
        private ObservableCollection<string> _directories;
        private ObservableCollection<string> _files;
        private ObservableCollection<string> _selectedFiles;

        private string _selectedDrive;
        private string _selectedDirectory;
        private int switchView;


        #endregion properties: private

    }
}
