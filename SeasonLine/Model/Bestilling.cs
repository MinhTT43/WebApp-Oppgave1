using System;
namespace SeasonLine.Model
{
    public class Bestilling
    {
        public int ID { get; set; }

        // Kunde-info
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telefon { get; set; }
        public string Epost { get; set; }

        // Bestilling-info
        public string Ankomst { get; set; }
        public string AvreiseSted { get; set; }
        public string AvreiseKlokkeslett { get; set; }
        public string AvreiseDato { get; set; }
        public int AntallBarn { get; set; }
        public int AntallVokse { get; set; }
        public int AntallLugarer { get; set; }

        // Reise-info
        public int PrisBarn { get; set; }
        public int PrisVoksen { get; set; }
        public int PrisLugar { get; set; }

    }
}
