using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Forsikring
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public int BilModelId { get; set; }
        public string Registreringsnummer { get; set; }
        public decimal Præmie { get; set; }
        public decimal Forsikringssum { get; set; }
        public string Betingelser { get; set; }
        public int Begyndelsesår { get; set; }
        public Kunde Kunde { get; set; }
        public BilModel Model { get; set; }

        public Forsikring()
        {
        }

        public Forsikring(Kunde kunde, BilModel model, string registreringsnummer, decimal præmie, decimal forsikringssum, string betingelser, int begyndelsesår)
        {
            this.Kunde = kunde;
            this.Model = model;
            this.Registreringsnummer = registreringsnummer;
            this.Præmie = præmie;
            this.Forsikringssum = forsikringssum;
            this.Betingelser = betingelser;
            this.Begyndelsesår = begyndelsesår;
        }
    }
}
