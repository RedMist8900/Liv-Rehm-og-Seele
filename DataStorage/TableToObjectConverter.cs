using DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataStorage
{
    public class TableToObjectConverter
    {
        SqlAccess sqlAccess;

        public TableToObjectConverter(SqlAccess sqlAccess)
        {
            this.sqlAccess = sqlAccess;
        }

        public ObservableCollection<Kunde> GetKundeListe(DataTable table)
        {
            ObservableCollection<Kunde> liste = new ObservableCollection<Kunde>();
            foreach (DataRow row in table.Rows)
            {
                Kunde kunde = GetKunde(row);
                liste.Add(kunde);
            }
            return liste;
        }

        private Kunde GetKunde(DataRow row)
        {
            Kunde kunde = new Kunde();
            kunde.Fornavn = (string)row["Fornavn"];
            kunde.Efternavn = (string)row["Efternavn"];
            kunde.Adresse = (string)row["Adresse"];
            kunde.Postnummer = (int)row["Postnummer"];
            kunde.Telefon = (int)row["Telefon"];
            kunde.Id = (int)row["Id"];
            return kunde;
        }

        public ObservableCollection<BilModel> GetBilModelListe(DataTable table)
        {
            ObservableCollection<BilModel> liste = new ObservableCollection<BilModel>();
            foreach (DataRow row in table.Rows)
            {
                BilModel model = GetBilModel(row);
                liste.Add(model);
            }
            return liste;
        }

        private BilModel GetBilModel(DataRow row)
        {
            BilModel model = new BilModel();
            model.Mærke = (string)row["Mærke"];
            model.Model = (string)row["Model"];
            model.Begyndelsesår = (int)row["Startår"];
            model.Slutår = (int)row["Slutår"];
            model.Pris = (decimal)row["Pris"];
            model.Forsikringssum = (decimal)row["Forsikringssum"];
            model.Id = (int)row["Id"];
            return model;
        }

        public ObservableCollection<Forsikring> GetForsikringsListe(DataTable table)
        {
            ObservableCollection<Forsikring> liste = new ObservableCollection<Forsikring>();
            foreach (DataRow row in table.Rows)
            {
                Forsikring forsikring = GetForsikring(row);
                liste.Add(forsikring);
            }
            return liste;
        }

        private DataRow GetKundeRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from Kunde where Id = " + id).Rows[0];
        }

        private DataRow GetBilmodelRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from Bilmodel where Id = " + id).Rows[0];
        }

        private Forsikring GetForsikring(DataRow row)
        {
            Forsikring forsikring = new Forsikring();
            //forsikring.KundeId = (int)row["KundeId"];
            GetKunde(GetKundeRow(row["KundeId"].ToString()));
            GetBilModel(GetBilmodelRow(row["BilModelId"].ToString()));
            forsikring.Registreringsnummer = (string)row["Registreringsnummer"];
            forsikring.Præmie = (decimal)row["Pris"];
            forsikring.Forsikringssum = (decimal)row["Forsikringssum"];
            forsikring.Begyndelsesår = (int)row["Begyndelsesår"];
            forsikring.Betingelser = (string)row["Betingelser"];
            forsikring.Id = (int)row["Id"];
            return forsikring;
        }
    }
}
