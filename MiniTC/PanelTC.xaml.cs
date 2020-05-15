using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC
{
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ComboItemsSourceProperty = DependencyProperty.Register("ComboItemsSource", typeof(string[]), typeof(PanelTC), new PropertyMetadata(null));

        public string[] ComboItemsSource
        {
            get => (string[])GetValue(ComboItemsSourceProperty);
            set => SetValue(ComboItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ComboSelectedItemProperty = DependencyProperty.Register("ComboSelectedItem", typeof(string), typeof(PanelTC), new PropertyMetadata(null));

        public string ComboSelectedItem
        {
            get => (string)GetValue(ComboSelectedItemProperty);
            set => SetValue(ComboSelectedItemProperty, value);
        }

        public static readonly DependencyProperty ListItemsSourceProperty = DependencyProperty.Register("ListItemsSource", typeof(IEnumerable<object>), typeof(PanelTC), new PropertyMetadata(null));

        public IEnumerable<object> ListItemsSource
        {
            get => (IEnumerable<object>)GetValue(ListItemsSourceProperty);
            set => SetValue(ListItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ListSelectedItemProperty = DependencyProperty.Register("ListSelectedItem", typeof(DataStructure), typeof(PanelTC), new PropertyMetadata(null));

        public DataStructure ListSelectedItem
        {
            get => (DataStructure)GetValue(ListSelectedItemProperty);
            set => SetValue(ListSelectedItemProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(PanelTC), new PropertyMetadata(null));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty DoubleClickProperty = DependencyProperty.Register("DoubleClick", typeof(ICommand), typeof(PanelTC), new PropertyMetadata(null));

        public ICommand DoubleClick
        {
            get => (ICommand)GetValue(DoubleClickProperty);
            set => SetValue(DoubleClickProperty, value);
        }
    }
}
