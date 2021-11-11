using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataStorage
{
    public class Data
    {
        SqlAccess sqlAccess;
        TableToObjectConverter converter;
        public ObservableCollection<Kunde> Kundeoversigt
        {
            get
            {
                return converter.GetKundeListe(sqlAccess.ExecuteSql("select * from Kunde"));
            }
        }

        public ObservableCollection<BilModel> BilModeloversigt
        {
            get
            {
                return converter.GetBilModelListe(sqlAccess.ExecuteSql("select * from BilModel"));
            }
        }

        public ObservableCollection<Forsikring> Forsikringsoversigt
        {
            get
            {
                return converter.GetForsikringsListe(sqlAccess.ExecuteSql("select * from Forsikring"));
            }
        }

        public Data()
        {
            sqlAccess = new SqlAccess();
            converter = new TableToObjectConverter(sqlAccess);
        }

        public void OpretKunde(string fornavn, string efternavn, string addresse, int postnummer, int telefon)
        {
            sqlAccess.ExecuteSql($"insert into Kunde (Fornavn, Efternavn, Adresse, Postnummer, Telefon) values ('{fornavn}', '{efternavn}', '{addresse}', {postnummer}, {telefon})");
        }

        public void DeleteKunde(Kunde kunde)
        {
            sqlAccess.ExecuteSql($"delete from Kunde where Id={kunde.Id}");
        }

        public void OpdaterKunde(Kunde kunde, string fornavn, string efternavn, string adresse, int postnummer, int telefon)
        {
            sqlAccess.ExecuteSql($"update Kunde set Fornavn='{fornavn}', Efternavn='{efternavn}', Adresse='{adresse}', Postnummer={postnummer}, Telefon={telefon} where Id={kunde.Id}");
        }

        public void OpretBilModel(string mærke, string model, DateTime startår, DateTime slutår, decimal pris, decimal forsikring)
        {
            sqlAccess.ExecuteSql($"insert into BilModel (Mærke, Model, Startår, Slutår, Pris, Forsikringssum) values ('{mærke}', '{model}', {startår.Year}, {slutår.Year}, {pris}, {forsikring})");
        }

        public void OpdaterBilModel(BilModel bilmodel, string mærke, string model, DateTime startår, DateTime slutår, decimal pris, decimal forsikringssum)
        {
            sqlAccess.ExecuteSql($"update BilModel set Mærke='{mærke}', Model='{model}', Startår={startår.Year}, Slutår={slutår.Year}, Pris={pris}, Forsikringssum={forsikringssum} where Id={bilmodel.Id}");
        }

        public void DeleteBilModel(BilModel model)
        {
            sqlAccess.ExecuteSql($"delete from BilModel where Id={model.Id}");
        }

        public void OpretForsikring(Kunde kunde, BilModel model, string regnum, decimal pris, decimal forsikringssum, string betingelser, DateTime begyndelsesår)
        {
            sqlAccess.ExecuteSql($"insert into Forsikring (KundeId, BilModelId, Registreringsnummer, Pris, Forsikringssum, Begyndelsesår, Betingelser) values ({kunde.Id}, {model.Id}, '{regnum}', {pris}, {forsikringssum}, {begyndelsesår.Year}, '{betingelser}')");
        }

        public void DeleteForsikring(Forsikring forsikring)
        {
            sqlAccess.ExecuteSql($"delete from Forsikring where Id={forsikring.Id}");
        }

        public void OpdaterForsikring(Forsikring forsikring, string regnum, DateTime startår, decimal pris, decimal forsikringssum, string betingelser)
        {
            sqlAccess.ExecuteSql($"update Forsikring set Registreringsnummer='{regnum}', Pris={pris}, Begyndelsesår={startår.Year}, Forsikringssum={forsikringssum}, Betingelser='{betingelser}' where Id={forsikring.Id}");
        }
    }
}
