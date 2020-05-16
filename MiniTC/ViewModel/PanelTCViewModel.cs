﻿using MiniTC.ViewModel.BaseClasses;
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
            SelectedDrive = Drives[0];
        }

        public string[] Drives { get; } = Directory.GetLogicalDrives();

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

                if (CurrentDirectory.Path != SelectedDrive)
                {
                    Directories.Add(new DataStructure(new DirectoryInfo(Directory.GetParent(CurrentDirectory.Path).FullName)) { Name = "..." });
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
    }
}
