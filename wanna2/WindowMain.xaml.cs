using CsvHelper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using System.Xml.Serialization;
using wanna2.Model;
using wanna2.Helpers;

namespace wanna2
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    /// 
    public delegate void ZapiszParametryXMLDelegat(ParametryXml parametry);

    public partial class WindowMain : Window
    {   

        /// <summary>
        /// Connection string utworzony na podstawie danych zapisanych w pliku xml
        /// </summary>
        public static string WannaCS; 

        ParametryXml parametryXml = new ParametryXml();
        public WindowMain()
        {
            InitializeComponent();

            WannaCS = @"metadata=res://*/ModelEco.csdl|res://*/ModelEco.ssdl|res://*/ModelEco.msl;provider=Npgsql;provider connection string=""Host=192.168.20.206;Port=5432;Database=ecoplastol;Username=postgres""";
            //WannaCS = @"metadata=res://*/ModelEco.csdl|res://*/ModelEco.ssdl|res://*/ModelEco.msl;provider=Npgsql;provider connection string=""Host=193.32.180.162;Port=5555;Database=ecoplastol;Username=postgres;Password=postgres;Persist Security Info=True"""
            //globals.CzyJestPolaczenieZBazaDanych = CzyJestPolaczenieZBazaDanych();

            WindowParametry.ZapiszEvent += new ZapiszParametryXMLDelegat(ZapiszParametryXML);

            // sprawdzam czy jet plik z parametrami
            if (File.Exists("parametry.xml"))
            {
                // jak istnieje to wczytuję parametry
                //MessageBox.Show("plik istnieje");
                var serializer = new XmlSerializer(typeof(ParametryXml));
                parametryXml = serializer.Deserialize(File.OpenText("parametry.xml")) as ParametryXml;
            } else
            {
                //MessageBox.Show("plik NIE istnieje");
                //parametryXml.OsobaPrzeprowadzajacaBadanie = "Marcin Zaczyński";
                var serializer = new XmlSerializer(parametryXml.GetType());

                serializer.Serialize(File.CreateText("parametry.xml"), parametryXml);
            }
        }

        private bool CzyJestPolaczenieZBazaDanych()
        {
            using (var db = new ecoplastolEntities())
            {
                return db.Database.Exists();
            }
        }

        private void Command_OtworzAnalizaBadania(object sender, ExecutedRoutedEventArgs e)
        {
            WindowAnalizaBadan wab = new WindowAnalizaBadan();
            wab.BadanieVM.DaneFirmy = String.Format(@"{0}{1}{2}", 
                                                    parametryXml.FirmaNazwa + Environment.NewLine,
                                                    parametryXml.FirmaAdres1 + Environment.NewLine,
                                                    parametryXml.FirmaAdres2 + Environment.NewLine
                                                    );
            wab.ShowDialog();
        }
        private void Command_OtworzParametry(object sender, ExecutedRoutedEventArgs e)
        {

            WindowParametry wp = new WindowParametry(parametryXml);
            wp.ShowDialog();
        }
        private void Command_Zamknij(object sender, ExecutedRoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ZapiszParametryXML(ParametryXml parametry)
        {
            var serializer = new XmlSerializer(parametry.GetType());

            serializer.Serialize(File.CreateText("parametry.xml"), parametry);
            parametryXml = parametry;
        }
    }
}
