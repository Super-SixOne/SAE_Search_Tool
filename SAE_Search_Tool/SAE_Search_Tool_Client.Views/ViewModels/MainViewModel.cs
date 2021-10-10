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
            get => _switchView;
            set => SetProperty(ref _switchView, value);
        }

        public string DirectoryOfExe
        {
            get => _directoryOfExe;
            set => SetProperty(ref _directoryOfExe, value);
        }

        #endregion properties: public


        #region Commands: public


        #endregion Commands: public


        #region ctor

        public MainViewModel()
        {

        }

        #endregion ctor


        #region methods: private

        private void GetCurrentDirectory() => DirectoryOfExe = Directory.GetCurrentDirectory();


        #endregion methods: private


        #region properties: private


        private string _directoryOfExe;
        private int _switchView;

        #endregion properties: private

    }
}
