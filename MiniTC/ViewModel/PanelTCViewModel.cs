using MiniTC.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.ViewModel
{
    class PanelTCViewModel : ViewModelBase
    {
        public PanelTCViewModel()
        {
            SelectedDrive = Directory.GetLogicalDrives()[0];
        }

        public string[] Drives => Directory.GetLogicalDrives();

        private string _selectedDrive;
        public string SelectedDrive
        {
            get => _selectedDrive;
            set
            {
                SetProperty(ref _selectedDrive, value);
                CurrentDirectory = value;
            }
        }

        private string _currentDirectory;
        public string CurrentDirectory
        {
            get => _currentDirectory;
            set
            {
                SetProperty(ref _currentDirectory, value);
                UpdateDirectories();
            }
        }

        private ObservableCollection<string> _directories = new ObservableCollection<string>();
        public ObservableCollection<string> Directories
        {
            get => _directories;
            set => SetProperty(ref _directories, value);
        }

        private void UpdateDirectories()
        {
            Directories.Clear();

            if (CurrentDirectory != SelectedDrive)
            {
                Directories.Add("...");
            }

            foreach (string directory in Directory.GetDirectories(CurrentDirectory))
            {
                Directories.Add("<D>" + Path.GetFileName(directory));
            }
            foreach (string file in Directory.GetFiles(CurrentDirectory))
            {
                Directories.Add(Path.GetFileName(file));
            }
        }
    }
}
