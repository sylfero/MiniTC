using MiniTC.ViewModel.BaseClasses;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class PanelTCViewModel : ViewModelBase
    {
        public PanelTCViewModel()
        {
            Drives = Directory.GetLogicalDrives();
            CurrentDrive = Drives[0];
        }

        private string[] _drives;
        public string[] Drives 
        {
            get => _drives;
            set
            {
                SetProperty(ref _drives, value);
            }
        } 

        private string _curentDrive;
        public string CurrentDrive
        {
            get => _curentDrive;
            set
            {
                SetProperty(ref _curentDrive, value ?? Drives[0]);
                CurrentDirectory = new DataStructure(new DirectoryInfo(value ?? Drives[0]));
            }
        }

        private DataStructure _selectedDirectory;
        public DataStructure SelectedDirectory
        {
            get => _selectedDirectory;
            set
            {
                SetProperty(ref _selectedDirectory, value);
            }
        }

        private DataStructure _currentDirectory;
        public DataStructure CurrentDirectory
        {
            get => _currentDirectory;
            set
            {
                SetProperty(ref _currentDirectory, value);
                UpdateDirectories();
            }
        }

        private ObservableCollection<DataStructure> _directories = new ObservableCollection<DataStructure>();
        public ObservableCollection<DataStructure> Directories
        {
            get => _directories;
            set => SetProperty(ref _directories, value);
        }

        private ICommand _changeDirectory;
        public ICommand ChangeDirectory
        {
            get
            {
                if (_changeDirectory == null)
                {
                    _changeDirectory = new RelayCommand( x => CurrentDirectory = SelectedDirectory, x => SelectedDirectory.Type == Type.Directory );
                }
                return _changeDirectory;
            }
        }

        private void UpdateDirectories()
        {
            try
            {
                string[] directories = Directory.GetDirectories(CurrentDirectory.Path);
                string[] files = Directory.GetFiles(CurrentDirectory.Path);

                Directories.Clear();

                if (CurrentDirectory.Path != CurrentDrive)
                {
                    Directories.Add(new DataStructure(new DirectoryInfo(Directory.GetParent(CurrentDirectory.Path).FullName)) { Name = "...", Base = true });
                }

                foreach (string directory in directories)
                {
                    Directories.Add(new DataStructure(new DirectoryInfo(directory)));
                }
                foreach (string file in files)
                {
                    Directories.Add(new DataStructure(new FileInfo(file)));
                }
            }
            catch (UnauthorizedAccessException) 
            {
                CurrentDirectory = new DataStructure(new DirectoryInfo(Directory.GetParent(CurrentDirectory.Path).FullName));
            }
            catch (IOException) 
            {
                CurrentDirectory = new DataStructure(new DirectoryInfo(Directory.GetParent(CurrentDirectory.Path).FullName));
            }
        }

        public void UpdateDrives()
        {
            Drives = Directory.GetLogicalDrives();
        }
    }
}
