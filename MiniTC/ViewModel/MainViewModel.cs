using MiniTC.ViewModel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MiniTC.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            To = new PanelTCViewModel();
            From = new PanelTCViewModel();
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
    }
}
