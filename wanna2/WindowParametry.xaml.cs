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
using wanna2.Model;
using wanna2.ViewModel;

namespace wanna2
{
    /// <summary>
    /// Interaction logic for WindowParametry.xaml
    /// </summary>
    public partial class WindowParametry : Window
    {
        public static event ZapiszParametryXMLDelegat ZapiszEvent;
        public ParametryXml parametryXml;
        public WindowParametry(ParametryXml parametry)
        {
            InitializeComponent();
            ParametryVM.FirmaNazwa = parametry.FirmaNazwa;
            ParametryVM.FirmaAdres1 = parametry.FirmaAdres1;
            ParametryVM.FirmaAdres2 = parametry.FirmaAdres2;
            ParametryVM.DokumentyOdniesienia1 = parametry.DokumentyOdniesienia1;
            ParametryVM.DokumentyOdniesienia2 = parametry.DokumentyOdniesienia2;
            ParametryVM.OsobaPrzeprowadzajacaBadanie = parametry.OsobaPrzeprowadzajacaBadanie;
        }

        private void CommandOk_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            parametryXml = new ParametryXml();
            parametryXml.FirmaNazwa = ParametryVM.FirmaNazwa;
            parametryXml.FirmaAdres1 = ParametryVM.FirmaAdres1;
            parametryXml.FirmaAdres2 = ParametryVM.FirmaAdres2;
            parametryXml.DokumentyOdniesienia1 = ParametryVM.DokumentyOdniesienia1;
            parametryXml.DokumentyOdniesienia2 = ParametryVM.DokumentyOdniesienia2;
            parametryXml.OsobaPrzeprowadzajacaBadanie = ParametryVM.OsobaPrzeprowadzajacaBadanie;
            ZapiszEvent?.Invoke(parametryXml);
            Close();
        }

        private void CommandOk_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           
            e.CanExecute = true;
        }

        private void CommandAnuluj_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            parametryXml = null;
            Close();
        }

        private void CommandAnuluj_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
