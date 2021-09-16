using wanna2.Helpers;
using CsvHelper;
using Microsoft.Win32;
using OxyPlot;
using OxyPlot.Wpf;
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
using wanna2.Model;

namespace wanna2
{

    public delegate void AddLogDelegate(string logMessage);
    /// <summary>
    /// Interaction logic for WindowAnalizaBadan.xaml
    /// </summary>
    
    public partial class WindowAnalizaBadan : Window
    {
        private ConsoleLogger Logger;
        public WindowAnalizaBadan()
        {
            InitializeComponent();

            ConsoleLogger.AddLogEvent += new AddLogDelegate(AddLog);

            Logger = new ConsoleLogger();
            Logger.LogMessage("SYSTEM", "", "Start", LogLevel.Verbose);
        }

        private void AddLog(string logMessage)
        {
            BadanieVM.LogBody += logMessage + Environment.NewLine;
        }

        private void btnNoweBadanie_Click(object sender, RoutedEventArgs e)
        {
            BadanieVM.NoweBadanie();
        }

        private void btnWczytajCisnienie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Wynik badania (.csv)|*.csv";

            var result = (bool)dlg.ShowDialog();

            if (result)
            {
                try
                {
                    Logger.LogMessage("PLIK", "CIŚNIENIE", "Wczytany plik " + dlg.FileName, LogLevel.Debug);
                    using (var reader = new StreamReader(dlg.FileName))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.HasHeaderRecord = false;
                        csv.Configuration.Delimiter = "\t";
                        csv.Configuration.RegisterClassMap<CisnienieMap>();
                        csv.Configuration.MissingFieldFound = null; // nie bierze pod uwagę wpisów nie pasujących do mapowania, np. niepełne wpisy bo brakło prądu

                        //var records = csv.GetRecords<Cisnienie>().ToList();
                        var CisnienieLista = new List<Cisnienie>();
                        var j = 1;
                        try
                        {
                            while (csv.Read())
                            {
                                var CTmp = new CisnienieTmp();
                                CTmp = csv.GetRecord<CisnienieTmp>();
                                // omijam rekordy z jakąkolwiek pustą wartością
                                if ((String.IsNullOrEmpty(CTmp.Czas)) ||
                                    (String.IsNullOrEmpty(CTmp.Data)) ||
                                    (String.IsNullOrEmpty(CTmp.Wartosc))) { }
                                else 
                                {
                                    try
                                    {
                                        CisnienieLista.Add(csv.GetRecord<Cisnienie>());
                                    }
                                    catch 
                                    {
                                        Logger.LogMessage("PLIK", "CIŚNIENIE", "Niepoprawne wartości w linii " + j.ToString(), LogLevel.Error);
                                    }
                                }
                                j++;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogMessage("PLIK", "CIŚNIENIE", "W linii " + j.ToString() + " - " + ex.Message, LogLevel.Error);
                        }
                        
                        if (CisnienieLista.Count() > 0)
                        {
                            BadanieVM.ListaCisnien = CisnienieLista;
                            var i = 1;
                            foreach (var item in BadanieVM.ListaCisnien)
                            {
                                BadanieVM.ListaCisnienDateTime.Add(new CisnienieDateTime() {DataCzas=(item.Data + item.Czas),Wartosc=item.Wartosc });
                                BadanieVM.ListaCisnienDateTimeOxy.Add(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(item.Data + item.Czas), item.Wartosc));
                                BadanieVM.ListaCisnienInt.Add(new DataPoint(i, item.Wartosc));
                                i++;
                            }

                            BadanieVM.IloscProbek = BadanieVM.ListaCisnienDateTime.Count();

                            BadanieVM.StartBadania = (from d in BadanieVM.ListaCisnienDateTime select d.DataCzas).Min();
                            BadanieVM.StopBadania = (from d in BadanieVM.ListaCisnienDateTime select d.DataCzas).Max();
                            BadanieVM.CzasTrwania = (BadanieVM.StopBadania - BadanieVM.StartBadania).Hours;

                            BadanieVM.CisnienieMin = (from d in BadanieVM.ListaCisnienDateTime select d.Wartosc).Min();
                            BadanieVM.CisnienieMax = (from d in BadanieVM.ListaCisnienDateTime select d.Wartosc).Max();

                            //BadanieVM.StartBadaniaOxy = BadanieVM.ListaCisnienDateTimeOxy[0].
                        }
                        else
                        {
                            MessageBox.Show("Plik nie zawiera danych z badania.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        };
                    }
                    BadanieVM.CzyWgraneCisnienie = true;
                }
                catch ( Exception ex)
                {
                    Logger.LogMessage("PLIK", "CIŚNIENIE", ex.Message, LogLevel.Error);
                    
                }
            }
        }

        private void btnWczytajTemperature_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();


            dlg.DefaultExt = ".csv";
            dlg.Filter = "Wynik badania (.csv)|*.csv";

            var result = (bool)dlg.ShowDialog();

            if (result)
            {
                try
                {
                    Logger.LogMessage("PLIK", "TEMPERATURA", "Wczytany plik " + dlg.FileName, LogLevel.Debug);
                    using (var reader = new StreamReader(dlg.FileName))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Configuration.HasHeaderRecord = false;
                        csv.Configuration.Delimiter = "\t";
                        csv.Configuration.RegisterClassMap<TemperaturaMap>();
                        csv.Configuration.MissingFieldFound = null; // nie bierze pod uwagę wpisów nie pasujących do mapowania, np. niepełne wpisy bo brakło prądu

                        //var records = csv.GetRecords<Cisnienie>().ToList();
                        var TemperaturaLista = new List<Temperatura>();
                        var j = 1;
                        try
                        { 
                            while (csv.Read())
                            {
                                var CTmp = new TemperaturaTmp();
                                CTmp = csv.GetRecord<TemperaturaTmp>();
                                // omijam rekordy z jakąkolwiek pustą wartością
                                if ((String.IsNullOrEmpty(CTmp.Czas)) ||
                                    (String.IsNullOrEmpty(CTmp.Data)) ||
                                    (String.IsNullOrEmpty(CTmp.Wartosc))) { }
                                else 
                                {
                                    try
                                    {
                                        TemperaturaLista.Add(csv.GetRecord<Temperatura>());
                                    }
                                    catch
                                    {
                                        Logger.LogMessage("PLIK", "TEMPERATURA", "Niepoprawne wartości w linii " + j.ToString(), LogLevel.Error);
                                    }
                                    
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogMessage("PLIK", "TEMPERATURA", "W linii " + j.ToString() + " - " + ex.Message, LogLevel.Error);
                        }
                        if (TemperaturaLista.Count() > 0)
                        {
                            BadanieVM.ListaTemperatur = TemperaturaLista;
                            var i = 1;
                            foreach (var item in BadanieVM.ListaTemperatur)
                            {
                                var tempWartosc = item.Wartosc;

                                BadanieVM.ListaTemperaturDateTime.Add(new TemperaturaDateTime() { DataCzas = (item.Data + item.Czas), Wartosc = item.Wartosc });
                                BadanieVM.ListaTemperaturDateTimeOxy.Add(new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(item.Data + item.Czas), item.Wartosc));
                                BadanieVM.ListaTemperaturInt.Add(new DataPoint(i, item.Wartosc));
                                i++;
                            }

                            BadanieVM.TemperaturaMin = (from d in BadanieVM.ListaTemperaturDateTime select d.Wartosc).Min();
                            BadanieVM.TemperaturaMax = (from d in BadanieVM.ListaTemperaturDateTime select d.Wartosc).Max();
                        }
                        else
                        {
                            MessageBox.Show("Plik nie zawiera danych z badania.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                        };
                    }
                    BadanieVM.CzyWgranaTemperatura = true;
                }
                catch (Exception ex)
                {
                    Logger.LogMessage("PLIK", "TEMPERATURA", ex.Message, LogLevel.Error);
                }
            }
        }

        private void CommandZapiszBadanieWBazie_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandZapiszBadanieWBazie_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PokazRaport_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var memStream = new MemoryStream();
            var pngExporter = new PngExporter { Width = 2400, Height = 600, Background = OxyColors.White };
            pngExporter.Export(oxyWykres.ActualModel, memStream);

            byte[] imageArray;
            imageArray = new byte[memStream.Length];
            memStream.Seek(0, System.IO.SeekOrigin.Begin);
            memStream.Read(imageArray, 0, (int)memStream.Length);
            var wykresBase64 = Convert.ToBase64String(imageArray);

            var WindowRaport = new WindowRaport(wykresBase64, BadanieVM.DaneFirmy);
            WindowRaport.ShowDialog();
        }

        private void PokazRaport_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (BadanieVM.CzyWgraneCisnienie && BadanieVM.CzyWgranaTemperatura)
            {
                e.CanExecute = true;
            } else
            {
                e.CanExecute = false;
            }
        }

        private void CommandZamknij_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
    
}
