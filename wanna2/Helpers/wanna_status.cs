using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace wanna2.Helpers
{
    class wanna_status
    {
        private int id;
        private string opis;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }

        public wanna_status(int _id, string _opis)
        {
            Id = _id;
            Opis = _opis;
        }
    }
}
