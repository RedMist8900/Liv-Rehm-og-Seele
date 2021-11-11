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

        public void OpretKunde(string fornavn, string efternavn, string adresse, string postnummer, string telefon)
        {
            try
            {
                foreach (Kunde k in Kundeoversigt)
                {
                    if (k.Telefon == Convert.ToInt32(telefon))
                    {
                        throw new Exception($"Der findes allerede en kunde med dette telefonnummer : {telefon}");
                    }
                }
                data.OpretKunde(fornavn, efternavn, adresse, Convert.ToInt32(postnummer), Convert.ToInt32(telefon));
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            RaisePropertyChanged("Kundeoversigt");
        }

        public void DeleteKunde(Kunde kunde)
        {
            if(kunde == null)
            {
                throw new Exception("Ingen Kunde Valgt Til Sletning");
            }
            data.DeleteKunde(kunde);
            RaisePropertyChanged("Kundeoversigt");
        }

        public void OpdaterKunde(Kunde kunde, string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            data.OpdaterKunde(kunde, fornavn, efternavn, adresse, postnummer, telefon);
            RaisePropertyChanged("Kundeoversigt");
        }

        public void OpretBilModel(string mærke, string model, DateTime startår, DateTime slutår, string pris, string forsikring)
        {
            try
            {
                //DateTime Startår = new DateTime(Convert.ToInt32(startår));
                //DateTime Slutår = new DateTime(Convert.ToInt32(slutår));
                foreach(BilModel bilmodel in BilModeloversigt)
                {
                    if(bilmodel.Mærke == mærke && bilmodel.Model == model && bilmodel.Begyndelsesår == startår.Year && bilmodel.Slutår == slutår.Year)
                    {
                        throw new Exception("Der findes allerede en BilModel med samme Mærke, Model, Startår og Slutår");
                    }
                }
                data.OpretBilModel(mærke, model, startår, slutår, Convert.ToDecimal(pris), Convert.ToDecimal(forsikring));
                RaisePropertyChanged("BilModeloversigt");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            RaisePropertyChanged("BilModeloversigt");
        }

        public void OpdaterBilModel(BilModel bilmodel, string mærke, string model, DateTime startår, DateTime slutår, decimal pris, decimal forsikringssum)
        {
            try
            {
                data.OpdaterBilModel(bilmodel, mærke, model, startår, slutår, pris, forsikringssum);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            RaisePropertyChanged("BilModeloversigt");
        }

        public void DeleteBilModel(BilModel model)
        {
            try
            {
                data.DeleteBilModel(model);
                RaisePropertyChanged("BilModeloversigt");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void OpretForsikring(Kunde kunde, BilModel model, string regnum, decimal pris, decimal forsikringssum, DateTime begyndelsesår, string betingelser = "")
        {
            foreach (Forsikring f in Forsikringsoversigt)
            {
                if (f.Registreringsnummer.Equals(regnum))
                {
                    throw new Exception($"Der findes allerede en Forsikring med dette Registreringsnummer : {regnum}");
                }
            }
            try
            {
                data.OpretForsikring(kunde, model, regnum, pris, forsikringssum, betingelser, begyndelsesår);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
            RaisePropertyChanged("Forsikringsoversigt");
        }

        public void DeleteForsikring(Forsikring forsikring)
        {
            if(forsikring == null) { throw new Exception("Ingen forsikring Valgt ved slettelse"); }
            data.DeleteForsikring(forsikring);
            RaisePropertyChanged("Forsikringsoversigt");
        }

        public void OpdaterForsikring(Forsikring forsik, string regnum, DateTime startår, string pris, string forsikringssum, string betingelser = "")
        {
            try
            {
                if(startår == null) { throw new Exception("forsikring skal have begyndelsesår"); }
                data.OpdaterForsikring(forsik, regnum, startår, Convert.ToDecimal(pris), Convert.ToDecimal(forsikringssum), betingelser);
            }
            catch(Exception)
            {
                throw new Exception("Fejl ved opdatering af Forsikring");
            }
            RaisePropertyChanged("Forsikringsoversigt");
        }
    }
}
