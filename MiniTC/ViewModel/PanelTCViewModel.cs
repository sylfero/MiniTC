using MiniTC.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class PanelTCViewModel : ViewModelBase
    {
        public PanelTCViewModel()
        {
            SelectedDrive = Drives[0];
        }

        public string[] Drives { get; }  = Directory.GetLogicalDrives();

        private string _selectedDrive;
        public string SelectedDrive
        {
            get => _selectedDrive;
            set
            {
                SetProperty(ref _selectedDrive, value);
                CurrentDirectory = new DataStructure(new DirectoryInfo(value));
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
                    _changeDirectory = new RelayCommand( x => CurrentDirectory = SelectedDirectory, x => SelectedDirectory != null && SelectedDirectory.Type == Type.Drive );
                }
                return _changeDirectory;
            }
        }

        private void UpdateDirectories()
        {
            try
            {
                Directories.Clear();

                if (CurrentDirectory.Path != SelectedDrive)
                {
                    Directories.Add(new DataStructure(new DirectoryInfo(Directory.GetParent(CurrentDirectory.Path).FullName)) { Name = "..." });
                }


                foreach (string directory in Directory.GetDirectories(CurrentDirectory.Path))
                {
                    Directories.Add(new DataStructure(new DirectoryInfo(directory)));
                }
                foreach (string file in Directory.GetFiles(CurrentDirectory.Path))
                {
                    Directories.Add(new DataStructure(new FileInfo(file)));
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
        }
    }
}
