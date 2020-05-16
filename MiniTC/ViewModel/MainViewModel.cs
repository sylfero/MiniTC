using MiniTC.DataOperations;
using MiniTC.ViewModel.BaseClasses;
using System;
using System.IO;
using System.Management;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            To = new PanelTCViewModel();
            From = new PanelTCViewModel();
            new Watcher(UpdateDrives, UpdateDrives);
        }

        private PanelTCViewModel _to;
        public PanelTCViewModel To
        {
            get => _to;
            set => SetProperty(ref _to, value);
        }

        private PanelTCViewModel _from;
        public PanelTCViewModel From
        {
            get => _from;
            set => SetProperty(ref _from, value);
        }

        private ICommand _copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new RelayCommand(x => Copy(), x => _from.SelectedDirectory != null && !_from.SelectedDirectory.Base);
                }
                return _copyCommand;
            }
        }

        private void Copy()
        {
            try
            {
                if (_from.SelectedDirectory.Type == Type.File)
                {
                    DataCopy.CopyFile(_from.SelectedDirectory.Path, _to.CurrentDirectory.Path);
                }
                else if (_from.SelectedDirectory.Type == Type.Directory)
                {
                    DataCopy.CopyDirectory(_from.SelectedDirectory.Path, _to.CurrentDirectory.Path);
                }

                _from.CurrentDirectory = _from.CurrentDirectory;
                _to.CurrentDirectory = _to.CurrentDirectory;
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
        }

        private void UpdateDrives(object sender, EventArrivedEventArgs e)
        {
            _from.UpdateDrives();
            _to.UpdateDrives();
        }
    }
}
