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
using wanna2.ViewModel;

namespace wanna2
{
    /// <summary>
    /// Interaction logic for WindowPomiar.xaml
    /// </summary>
    public partial class WindowPomiar : Window
    {
        public WindowPomiar()
        {
            InitializeComponent();
            WannaViewModel wvm = new WannaViewModel();
            wvm.Kolor = new SolidColorBrush(System.Windows.Media.Colors.Red);
        }

        private void btnZamknij_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
