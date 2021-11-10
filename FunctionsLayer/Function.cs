using DataModels;
using DataStorage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FunctionsLayer
{
    public class Function : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propName));
            }
        }

        public Data data = new Data();
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return data.Kundeoversigt;
            }
        }

        public ObservableCollection<BilModel> BilModeloversigt
        {
            get
            {
                return data.BilModeloversigt;
            }
        }

        public ObservableCollection<Forsikring> Forsikringsoversigt
        {
            get
            {
                return data.Forsikringsoversigt;
            }
        }

        public void OpretKunde(string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            foreach (Kunde k in Kundeoversigt)
            {
                if (k.Telefon == telefon)
                {
                    throw new Exception($"Der findes allerede en kunde med dette telefonnummer : {telefon}");
                }
            }
            data.OpretKunde(fornavn, efternavn, adresse, postnummer, telefon);
            RaisePropertyChanged("Kundeoversigt");
        }

        public void DeleteKunde(Kunde kunde)
        {
            data.DeleteKunde(kunde);
            RaisePropertyChanged("Kundeoversigt");
        }

        public void OpdaterKunde(Kunde kunde, string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            data.OpdaterKunde(kunde, fornavn, efternavn, adresse, postnummer, telefon);
            RaisePropertyChanged("Kundeoversigt");
        }

        public void OpretBilModel(string mærke, string model, DateTime startår, DateTime slutår, decimal pris, decimal forsikring)
        {
            data.OpretBilModel(mærke, model, startår, slutår, pris, forsikring);
            RaisePropertyChanged("BilModeloversigt");
        }

        public void OpdaterBilModel(BilModel bilmodel, string mærke, string model, DateTime startår, DateTime slutår, decimal pris, decimal forsikringssum)
        {
            data.OpdaterBilModel(bilmodel, mærke, model, startår, slutår, pris, forsikringssum);
            RaisePropertyChanged("BilModeloversigt");
        }

        public void DeleteBilModel(BilModel model)
        {
            data.DeleteBilModel(model);
            RaisePropertyChanged("BilModeloversigt");
        }

        public void OpretForsikring(Kunde kunde, BilModel model, string regnum, decimal pris, decimal forsikringssum, DateTime begyndelsesår, string betingelser = "")
        {
            foreach (Forsikring f in Forsikringsoversigt)
            {
                if (f.Registreringsnummer == regnum)
                {
                    throw new Exception($"Der findes allerede en Forsikring med dette Registreringsnummer : {regnum}");
                }
            }
            data.OpretForsikring(kunde, model, regnum, pris, forsikringssum, betingelser, begyndelsesår);
            RaisePropertyChanged("Forsikringsoversigt");
        }

        public void DeleteForsikring(Forsikring forsikring)
        {
            data.DeleteForsikring(forsikring);
            RaisePropertyChanged("Forsikringsoversigt");
        }
    }
}
