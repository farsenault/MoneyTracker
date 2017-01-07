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
using System.Windows.Shapes;

namespace WpfApplication.UserControls
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public static readonly DependencyProperty WindowContentsProperty = DependencyProperty.Register("WindowContents", typeof(object), typeof(MainWindow), new UIPropertyMetadata(null));
        public object WindowContents
        {
            get { return (object)GetValue(WindowContentsProperty); }
            set { SetValue(WindowContentsProperty, value); }
        }

        public SaveWindow()
        {
            InitializeComponent();
        }
    }
}
