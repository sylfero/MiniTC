using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace MiniTC
{
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl, IPanelTC
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DrivesProperty = DependencyProperty.Register("Drives", typeof(string[]), typeof(PanelTC), new PropertyMetadata(null));

        public string[] Drives
        {
            get => (string[])GetValue(DrivesProperty);
            set => SetValue(DrivesProperty, value);
        }

        public static readonly DependencyProperty ComboSelectedItemProperty = DependencyProperty.Register("ComboSelectedItem", typeof(string), typeof(PanelTC), new PropertyMetadata(null));

        public string ComboSelectedItem
        {
            get => (string)GetValue(ComboSelectedItemProperty);
            set => SetValue(ComboSelectedItemProperty, value);
        }

        public static readonly DependencyProperty PathContentProperty = DependencyProperty.Register("PathContent", typeof(IEnumerable<object>), typeof(PanelTC), new PropertyMetadata(null));

        public IEnumerable<object> PathContent
        {
            get => (IEnumerable<object>)GetValue(PathContentProperty);
            set => SetValue(PathContentProperty, value);
        }

        public static readonly DependencyProperty ListSelectedItemProperty = DependencyProperty.Register("ListSelectedItem", typeof(DataStructure), typeof(PanelTC), new PropertyMetadata(null));

        public DataStructure ListSelectedItem
        {
            get => (DataStructure)GetValue(ListSelectedItemProperty);
            set => SetValue(ListSelectedItemProperty, value);
        }

        public static readonly DependencyProperty CurrentPathProperty = DependencyProperty.Register("CurrentPath", typeof(string), typeof(PanelTC), new PropertyMetadata(null));

        public string CurrentPath
        {
            get => (string)GetValue(CurrentPathProperty);
            set => SetValue(CurrentPathProperty, value);
        }

        public static readonly DependencyProperty DoubleClickProperty = DependencyProperty.Register("DoubleClick", typeof(ICommand), typeof(PanelTC), new PropertyMetadata(null));

        public ICommand DoubleClick
        {
            get => (ICommand)GetValue(DoubleClickProperty);
            set => SetValue(DoubleClickProperty, value);
        }
    }
}
