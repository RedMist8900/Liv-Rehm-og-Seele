using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class BilModel
    {
        public int Id { get; set; }
        public string Mærke { get; set; }
        public string Model { get; set; }
        public int Begyndelsesår { get; set; }
        public int Slutår { get; set; }
        public decimal Pris { get; set; }
        public decimal Forsikringssum { get; set; }
        public string Bil { get { return Mærke + " " + Model; } }

        public BilModel()
        {
        }

        public BilModel(string mærke, string model, int begyndelsesår, int slutår, decimal pris, decimal forsikringssum)
        {
            this.Mærke = mærke;
            this.Model = model;
            this.Begyndelsesår = begyndelsesår;
            this.Slutår = slutår;
            this.Pris = pris;
            this.Forsikringssum = forsikringssum;
        }
    }
}
