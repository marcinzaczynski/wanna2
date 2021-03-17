using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wanna2.Model
{
    public class ParametryXml
    {
        private string firmaNazwa = "Ecoplastol Sp. z o.o.";
        private string firmaAdres1 = "ul. Szkolna 48a";
        private string firmaAdres2 = "42-512 Malinowice";
        private string dokumentyOdniesienia1 = "PN-EN 1555-3:2004, PN-EN 12201-3:2004, PN-EN 13244-3:2004, PN-EN ISO 1167-1:2007";
        private string dokumentyOdniesienia2 = "PN-EN ISO 1167-2:2007, PN-EN ISO 1167-3:2007, PN-EN ISO 1167-4:2007";
        private string osobaPrzeprowadzajacaBadanie = "Marcin Stolarski";

        public string FirmaNazwa { get { return firmaNazwa; } set { firmaNazwa = value; } }
        public string FirmaAdres1 { get { return firmaAdres1; } set { firmaAdres1 = value; } }
        public string FirmaAdres2 { get { return firmaAdres2; } set { firmaAdres2 = value; } }
        public string DokumentyOdniesienia1 { get { return dokumentyOdniesienia1; } set { dokumentyOdniesienia1 = value; } }
        public string DokumentyOdniesienia2 { get { return dokumentyOdniesienia2; } set { dokumentyOdniesienia2 = value; } }
        public string OsobaPrzeprowadzajacaBadanie { get { return osobaPrzeprowadzajacaBadanie; } set { osobaPrzeprowadzajacaBadanie = value; } }

        public ParametryXml (string _firmaNazwa,
                                string _firmaAdres1,
                                string _firmaAdres2,
                                string _dokumentyOdniesienia1,
                                string _dokumentyOdniesienia2,
                                string _osobaPrzeprowadzajacaBadanie)
        {
            this.FirmaNazwa = _firmaNazwa;
            this.FirmaAdres1 = _firmaAdres1;
            this.FirmaAdres2 = _firmaAdres2;
            this.DokumentyOdniesienia1 = _dokumentyOdniesienia1;
            this.DokumentyOdniesienia2 = _dokumentyOdniesienia2;
            this.OsobaPrzeprowadzajacaBadanie = _osobaPrzeprowadzajacaBadanie;
        }

        public ParametryXml()
        { 
        }

    }
}
