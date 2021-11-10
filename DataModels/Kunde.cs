using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Adresse { get; set; }
        public int Postnummer { get; set; }
        public int Telefon { get; set; }
        public string Navn { get { return Fornavn + " " + Efternavn; } }

        public Kunde() {}

        public Kunde(string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            this.Fornavn = fornavn;
            this.Efternavn = efternavn;
            this.Adresse = adresse;
            this.Postnummer = postnummer;
            this.Telefon = telefon;
        }
    }
}
