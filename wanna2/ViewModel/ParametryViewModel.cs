using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wanna2.ViewModel
{
    public class ParametryViewModel : INotifyPropertyChanged
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

        private string firmaNazwa = "Ecoplastol Sp. z o.o.";
        private string firmaAdres1 = "ul. Szkolna 48a";
        private string firmaAdres2 = "42-512 Malinowice";
        private string dokumentyOdniesienia1 = "PN-EN 1555-3:2004, PN-EN 12201-3:2004, PN-EN 13244-3:2004, PN-EN ISO 1167-1:2007";
        private string dokumentyOdniesienia2 = "PN-EN ISO 1167-2:2007, PN-EN ISO 1167-3:2007, PN-EN ISO 1167-4:2007";
        private string osobaPrzeprowadzajacaBadanie = "Marcin Stolarski";

        public string FirmaNazwa { get { return firmaNazwa; } set { firmaNazwa = value; OnPropertyChanged("FirmaNazwa"); } }
        public string FirmaAdres1 { get { return firmaAdres1; } set { firmaAdres1 = value; OnPropertyChanged("FirmaAdres1"); } }
        public string FirmaAdres2 { get { return firmaAdres2; } set { firmaAdres2 = value; OnPropertyChanged("FirmaAdres2"); } }
        public string DokumentyOdniesienia1 { get { return dokumentyOdniesienia1; } set { dokumentyOdniesienia1 = value; OnPropertyChanged("DokumentyOdniesienia1"); } }
        public string DokumentyOdniesienia2 { get { return dokumentyOdniesienia2; } set { dokumentyOdniesienia2 = value; OnPropertyChanged("DokumentyOdniesienia2"); } }
        public string OsobaPrzeprowadzajacaBadanie { get { return osobaPrzeprowadzajacaBadanie; } set { osobaPrzeprowadzajacaBadanie = value; OnPropertyChanged("OsobaPrzeprowadzajacaBadanie"); } }
        #endregion
    }
}
