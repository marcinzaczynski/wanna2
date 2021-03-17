using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wanna2.Model
{
    /// <summary>
    /// Klasa opisująca jeden wpis ciśnienia.
    /// </summary>
    public class Cisnienie
    {
        [Index(0)]
        public TimeSpan Czas { get; set; }
        [Index(1)]
        public DateTime Data { get; set; }
        [Index(2)]
        public float Wartosc { get; set; }
    }
    /// <summary>
    /// Klasa pomocnicza, bazująca na klacie Cisnienie.
    /// </summary>
    public class CisnienieTmp
    {
        [Index(0)]
        public string Czas { get; set; }
        [Index(1)]
        public string Data { get; set; }
        [Index(2)]
        public string Wartosc { get; set; }
    }

    public class CisnienieDateTime
    {
        public DateTime DataCzas { get; set; }
        public float Wartosc { get; set; }
    }

    public class CisnienieInt
    {
        public int Id { get; set; }
        public float Wartosc { get; set; }
    }

    /// <summary>
    /// Klasa ustalająca mapowanie kolumn w pliku csv.
    /// </summary>
    public sealed class CisnienieMap : ClassMap<Cisnienie>
    {
        public CisnienieMap()
        {
            //Map(member => member.Czas).Index(0).TypeConverterOption.Format("h:mm:ss");
            Map(member => member.Czas).Index(0);
            Map(member => member.Data).Index(1).TypeConverterOption.Format("dd.MM.yyyy");
            Map(member => member.Wartosc).Index(2);
        }
    }


}
