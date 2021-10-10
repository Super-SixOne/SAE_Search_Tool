using GalaSoft.MvvmLight.Command;
using SAE_Search_Tool_Client.Models.BusinessLogic;
using SAE_Search_Tool_Client.Views.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SAE_Search_Tool_Client.Views.ViewModels
{
    public class ExplorerViewModel : ViewModelBase
    {
        /// <summary>
        /// List of all logical drives
        /// </summary>
        public ObservableCollection<string> Drives { get => _drives; set => SetProperty(ref _drives, value); }

        /// <summary>
        /// List of all directories in current drive
        /// </summary>
        public ObservableCollection<string> CurrentDriveDirectories { get => _currentDriveDirectories; set => SetProperty(ref _currentDriveDirectories, value); }

        /// <summary>
        /// List of all files in current drive
        /// </summary>
        public ObservableCollection<string> CurrentDriveFiles { get => _currentDriveFiles; set => SetProperty(ref _currentDriveFiles, value); }

        /// <summary>
        /// Binding to ListView Selected Item -> Selected logical drive
        /// </summary>
        public string SelectedDrive { get => _selectedDrive; set => SetProperty(ref _selectedDrive, value); }

        /// <summary>
        /// Binding to ListView Selected Item -> Selected directory
        /// </summary>
        public string SelectedDirectory { get => _selectedDirectory; set => SetProperty(ref _selectedDirectory, value); }

        /// <summary>
        /// Binding to ListView Selected Item -> Selected file
        /// </summary>
        public string SelectedFile { get => _selectedDirectory; set => SetProperty(ref _selectedDirectory, value); }

        /// <summary>
        /// Binding to ListVIew Selected Item -> Selected Item will be removed
        /// </summary>
        public string RemoveItem { get => _removeItem; set => SetProperty(ref _removeItem, value); }

        /// <summary>
        /// Binding to ListView ItemSource -> Selected files
        /// </summary>
        public ObservableCollection<string> SelectedFiles { get => _selectedFiles; set => _selectedFiles = value; }

        /// <summary>
        /// Current path
        /// </summary>
        public string CurrentPath { get => _currentPath; set => SetProperty(ref _currentPath, value); }

        public List<string> CurrentPathTimeline { get => _currentPathTimeline; set => SetProperty(ref _currentPathTimeline, value); }

        private void GetPrevious()
        {
            if (CurrentPathTimeline.Count > 0)
            {
                CurrentPathTimeline.RemoveAt(CurrentPathTimeline.Count - 1);

                if (CurrentPathTimeline.Count == 0)
                {
                    return;
                }
                else
                {
                    CurrentPath = CurrentPathTimeline.ElementAt(CurrentPathTimeline.Count - 1);
                }

                CurrentDriveDirectories = new ObservableCollection<string>(Directory.GetDirectories(CurrentPath));
                CurrentDriveFiles = new ObservableCollection<string>(Directory.GetFiles(CurrentPath));

                if (SelectedFiles != null)
                {
                    foreach (string selItem in SelectedFiles)
                    {
                        if (CurrentDriveFiles.Contains(selItem))
                        {
                            CurrentDriveFiles.Remove(selItem);
                        }
                    }

                }
            }
        }


        #region Commands

        public ICommand ReturnPathCommand => _returnPathCommand = _returnPathCommand ?? new RelayCommand(GetPrevious);

        public ICommand SelectedDriveChangedCommand => _selectedDriveChangedCommand = _selectedDriveChangedCommand ?? new RelayCommand(GetDriveContent);

        public ICommand SelectedDirectoryChangedCommand => _selectedDirectoryChangedCommand = _selectedDirectoryChangedCommand ?? new RelayCommand(GetDirectoryContent);

        public ICommand SelectedFileChangedCommand => _selectedFileChangedCommand = _selectedFileChangedCommand ?? new RelayCommand(AddFileToSelectedFiles);

        public ICommand SelectedFilesRemoveCommand => _selectedFilesRemoveCommand = _selectedFilesRemoveCommand ?? new RelayCommand(RemoveSelectedItem);

        public ICommand SaveJsonCommand => _saveJsonCommand = _saveJsonCommand ?? new RelayCommand(SaveJsonFile);




        #endregion Commands


        #region commands: logic

        private void GetDriveContent()
        {
            if (SelectedDrive is null)
            {
                return;
            }

            CurrentPath = SelectedDrive;
            CurrentPathTimeline.Add(CurrentPath);

            DriveInfo info = new DriveInfo(SelectedDrive);
            string driveName = info.Name;

            CurrentDriveDirectories = new ObservableCollection<string>(Directory.GetDirectories(driveName).ToList());
            CurrentDriveFiles = new ObservableCollection<string>(Directory.GetFiles(driveName).ToList());

            if (SelectedFiles != null)
            {
                foreach (string selItem in SelectedFiles)
                {
                    if (CurrentDriveFiles.Contains(selItem))
                    {
                        CurrentDriveFiles.Remove(selItem);
                    }
                }

            }

        }

        private void GetDirectoryContent()
        {
            if (SelectedDirectory != null)
            {
                CurrentPath = SelectedDirectory;
                CurrentPathTimeline.Add(CurrentPath);
            }

            try
            {
                CurrentDriveDirectories = new ObservableCollection<string>(Directory.GetDirectories(CurrentPath).ToList());
                CurrentDriveFiles = new ObservableCollection<string>(Directory.GetFiles(CurrentPath).ToList());
            }
            catch (Exception ex)
            {
            }

        }

        private void AddFileToSelectedFiles()
        {
            if (SelectedFile is null)
            {
                return;
            }

            SelectedFiles.Add(SelectedFile);
            CurrentDriveFiles.Remove(SelectedFile);


        }

        private void RemoveSelectedItem()
        {
            if (RemoveItem is null)
            {
                return;
            }

            if (RemoveItem.Contains(CurrentPath))
            {
                CurrentDriveFiles.Add(RemoveItem);
            }

            SelectedFiles.Remove(RemoveItem);


        }

        private void SaveJsonFile()
        {
            if (Datakernel.ExplorerVM.SelectedFiles != null && Datakernel.ExplorerVM.SelectedFiles.Count > 0)
            {
                JsonCreation.UpdateJson(Datakernel.ExplorerVM.SelectedFiles);
            }
            else
            {
                MessageBox.Show("Keine Dateien ausgewählt. Diese MessageBox wird ersetzt");
            }
        }

        #endregion commands: logic


        #region properties: private

        private ObservableCollection<string> _drives;
        private ObservableCollection<string> _currentDriveContent = new ObservableCollection<string>();
        private ObservableCollection<string> _currentDriveDirectories = new ObservableCollection<string>();
        private ObservableCollection<string> _currentDriveFiles;
        private ObservableCollection<string> _selectedContent;
        private ObservableCollection<string> _selectedFiles = new ObservableCollection<string>();

        private string _selectedDrive;
        private string _selectedDirectory;
        private string _selectedFile;
        private string _removeItem;

        private string _selectedDriveContent;
        private string _currentPath;
        private List<string> _currentPathTimeline = new List<string>();

        #endregion properties: private


        #region commands: private

        private ICommand _returnPathCommand;

        private ICommand _selectedDriveChangedCommand;
        private ICommand _selectedDirectoryChangedCommand;
        private ICommand _selectedFileChangedCommand;
        private ICommand _selectedFilesRemoveCommand;
        private ICommand _saveJsonCommand;

        #endregion commands: private
    }
}
