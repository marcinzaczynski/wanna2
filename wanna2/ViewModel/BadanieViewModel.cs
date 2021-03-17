using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wanna2.Model;

namespace wanna2.ViewModel
{
    public class BadanieViewModel : INotifyPropertyChanged
    {
        // ========================= PROPERTY CHANGE ===========================
        #region region PROPERTY CHANGE
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        // ========================= PROPERTIES ================================
        #region region PROPERTIES
        private int idBadania;
        public int IdBadania { get { return idBadania; } set { idBadania = value; OnPropertyChanged("IdBadania"); } }

        private string nazwaBadania;
        public string NazwaBadania { get { return nazwaBadania; } set { nazwaBadania = value; OnPropertyChanged("NazwaBadania"); } }

        private int iloscProbek;
        /// <summary>
        /// Ilość próbek wczytanych z pliku z zapisem badania.
        /// </summary>
        public int IloscProbek { get { return iloscProbek; } set { iloscProbek = value; OnPropertyChanged("IloscProbek"); } }

        private int czasTrwania;
        public int CzasTrwania {  get { return czasTrwania; } set { czasTrwania = value; OnPropertyChanged("CzasTrwania"); } }

        private double startBadaniaOxy;
        public double StartBadaniaOxy { get { return startBadaniaOxy; } set { startBadaniaOxy = value; OnPropertyChanged("StartBadaniaOxy"); } }

        private DateTime startBadania = DateTime.Now;
        public DateTime StartBadania { get { return startBadania; } set { startBadania = value; OnPropertyChanged("StartBadania"); StartBadaniaOxy = OxyPlot.Axes.DateTimeAxis.ToDouble(value); } }

        private double stopBadaniaOxy;
        public double StopBadaniaOxy { get { return stopBadaniaOxy; } set { stopBadaniaOxy = value; OnPropertyChanged("StopBadaniaOxy"); } }

        private DateTime stopBadania = DateTime.Now;
        public DateTime StopBadania { get { return stopBadania; } set { stopBadania = value; OnPropertyChanged("StopBadania"); StopBadaniaOxy = OxyPlot.Axes.DateTimeAxis.ToDouble(value); } }

        private int zadanaTemperatura;
        public int ZadanaTemperatura { get { return zadanaTemperatura; } set { zadanaTemperatura = value; OnPropertyChanged("ZadanaTemperatura"); } }

        private double temperaturaMin;
        public double TemperaturaMin { get { return temperaturaMin; } set { temperaturaMin = value; OnPropertyChanged("TemperaturaMin"); } }

        private double temperaturaMax;
        public double TemperaturaMax { get { return temperaturaMax; } set { temperaturaMax = value; OnPropertyChanged("TemperaturaMax"); } }

        private int zadaneCisnienie;
        public int ZadaneCisnienie { get { return zadaneCisnienie; } set { zadaneCisnienie = value; OnPropertyChanged("ZadaneCisnienie"); } }

        private double cisnienieMin;
        public double CisnienieMin { get { return cisnienieMin; } set { cisnienieMin = value; OnPropertyChanged("CisnienieMin"); } }

        private double cisnienieMax;
        public double CisnienieMax { get { return cisnienieMax; } set { cisnienieMax = value; OnPropertyChanged("CisnienieMax"); } }

        private bool czyWgraneCisnienie = false;
        public bool CzyWgraneCisnienie { get { return czyWgraneCisnienie; } set { czyWgraneCisnienie = value; OnPropertyChanged("CzyWgraneCisnienie"); } }

        private bool czyWgranaTemperatura = false;
        public bool CzyWgranaTemperatura { get { return czyWgranaTemperatura; } set { czyWgranaTemperatura = value; OnPropertyChanged("CzyWgranaTemperatura"); } }

        #region Dane do raportu
        private string daneFirmy;
        public string DaneFirmy {  get { return daneFirmy; } set { daneFirmy = value; OnPropertyChanged("DaneFirmy"); } }
        #endregion
        #region Listy Ciśnienie
        private List<Cisnienie> listaCisnien;
        public List<Cisnienie> ListaCisnien { get { return listaCisnien; } set { listaCisnien = value; OnPropertyChanged("ListaCisnien"); } }

        private List<CisnienieDateTime> listaCisnienDateTime;
        /// <summary>
        /// Lista zawierająca próbki w postaci klasy CisnienieDateTime(DateTime, float)
        /// Trzymam po to żeby mieć dostęp do czasów, które można wygodnie odczytać
        /// </summary>
        public List<CisnienieDateTime> ListaCisnienDateTime { get { return listaCisnienDateTime; } set { listaCisnienDateTime = value; OnPropertyChanged("ListaCisnienDateTime"); } }

        private IList<DataPoint> listaCisnienDateTimeOxy;
        /// <summary>
        /// Lista zawierająca próbki w postaci DataPoint(data i czas próbki, wartość) potrzebnej dla wykresu OxyPlot
        /// </summary>
        public IList<DataPoint> ListaCisnienDateTimeOxy { get { return listaCisnienDateTimeOxy; } set { listaCisnienDateTimeOxy = value; OnPropertyChanged("ListaCisnienDateTimeOxy"); } }

        private IList<DataPoint> listaCisnienInt;
        /// <summary>
        /// Lista zawierająca próbki w postaci DataPoint(id kolejnej próbki, wartość) potrzebnej dla wykresu OxyPlot
        /// </summary>
        public IList<DataPoint> ListaCisnienInt { get { return listaCisnienInt; } set { listaCisnienInt = value; OnPropertyChanged("ListaCisnienInt"); } }
        #endregion
        #region Listy Temperatura
        private List<Temperatura> listaTemperatur;
        public List<Temperatura> ListaTemperatur { get { return listaTemperatur; } set { listaTemperatur = value; OnPropertyChanged("ListaTemperatur"); } }

        private List<TemperaturaDateTime> listaTemperaturDateTime;
        public List<TemperaturaDateTime> ListaTemperaturDateTime { get { return listaTemperaturDateTime; } set { listaTemperaturDateTime = value; OnPropertyChanged("ListaTemperaturDateTime"); } }

        private IList<DataPoint> listaTemperaturDateTimeOxy;
        public IList<DataPoint> ListaTemperaturDateTimeOxy { get { return listaTemperaturDateTimeOxy; } set { listaTemperaturDateTimeOxy = value; OnPropertyChanged("ListaTemperaturDateTimeOxy"); } }

        private IList<DataPoint> listaTemperaturInt;
        public IList<DataPoint> ListaTemperaturInt { get { return listaTemperaturInt; } set { listaTemperaturInt = value; OnPropertyChanged("ListaTemperaturInt"); } }
        #endregion

        #endregion
        public BadanieViewModel()
        {
            this.listaCisnien = new List<Cisnienie>();
            this.listaCisnienDateTime = new List<CisnienieDateTime>();
            this.listaCisnienDateTimeOxy = new List<DataPoint>();
            this.listaCisnienInt = new List<DataPoint>();

            this.listaTemperatur = new List<Temperatura>();
            this.listaTemperaturDateTime = new List<TemperaturaDateTime>();
            this.listaTemperaturDateTimeOxy = new List<DataPoint>();
            this.listaTemperaturInt = new List<DataPoint>();
        }

        public void NoweBadanie()
        {
            this.IdBadania = UstawIdBadania();
            this.NazwaBadania = "";
            this.IloscProbek = 0;
            this.CzasTrwania = 0;
            this.StartBadania = DateTime.Now;
            this.StopBadania = DateTime.Now;
            this.ZadanaTemperatura = 0;
            this.TemperaturaMin = 0;
            this.TemperaturaMax = 0;
            this.ZadaneCisnienie = 0;
            this.CisnienieMin = 0;
            this.CisnienieMax = 0;
            this.CzyWgraneCisnienie = false;
            this.CzyWgranaTemperatura = false;
            this.ListaCisnien.Clear();
            this.ListaCisnienDateTime.Clear();
            this.ListaCisnienDateTimeOxy.Clear();
            this.ListaCisnienInt.Clear();
            this.ListaTemperatur.Clear();
            this.ListaTemperaturDateTime.Clear();
            this.ListaTemperaturDateTimeOxy.Clear();
            this.ListaTemperaturInt.Clear();

        }

        private int UstawIdBadania()
        {
            return 0;
        }
    }
}
