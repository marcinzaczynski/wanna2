using Microsoft.Reporting.WinForms;
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

namespace wanna2
{
    /// <summary>
    /// Interaction logic for WindowRaport.xaml
    /// </summary>
    public partial class WindowRaport : Window
    {

        public WindowRaport(string wykresBase64, string daneFirmy)
        {
            InitializeComponent();

            Raport.Reset();
            ReportParameter p1 = new ReportParameter("ReportParameterImage", wykresBase64);
            ReportParameter p2 = new ReportParameter("ReportParameterMimeType", "image/png");
            ReportParameter p3 = new ReportParameter("daneFirmy", daneFirmy);
            Raport.LocalReport.ReportEmbeddedResource = "wanna2.ReportBadanie.rdlc";
            Raport.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
            Raport.RefreshReport();
            
        }

        private void CommandZamknij_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
