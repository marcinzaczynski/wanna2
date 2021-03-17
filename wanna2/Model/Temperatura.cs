using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;

namespace wanna2.Model
{
    public class Temperatura
    {
        [Index(0)]
        public TimeSpan Czas { get; set; }
        [Index(1)]
        public DateTime Data { get; set; }
        [Index(2)]
        public float Wartosc { get; set; }
    }
    public class TemperaturaDateTime
    {
        public DateTime DataCzas { get; set; }
        public float Wartosc { get; set; }
    }

    public class TemperaturaInt
    {
        public int Id { get; set; }
        public float Wartosc { get; set; }
    }

    public sealed class TemperaturaMap : ClassMap<Temperatura>
    {
        public TemperaturaMap()
        {
            //Map(member => member.Czas).Index(0).TypeConverterOption.Format("h:mm:ss");
            Map(member => member.Czas).Index(0);
            Map(member => member.Data).Index(1).TypeConverterOption.Format("dd.MM.yyyy");
            Map(member => member.Wartosc).Index(2);
        }
    }
    public class TemperaturaTmp
    {
        [Index(0)]
        public string Czas { get; set; }
        [Index(1)]
        public string Data { get; set; }
        [Index(2)]
        public string Wartosc { get; set; }
    }
}
