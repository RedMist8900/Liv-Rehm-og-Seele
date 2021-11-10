using DataModels;
using FunctionsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Liv__Rehm_og_Seele
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Function func = new Function();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = func;
        }

        private void btnOpretKunde_Click(object sender, RoutedEventArgs e)
        {
            func.OpretKunde(tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, Convert.ToInt32(tbPostnummer.Text), Convert.ToInt32(tbTelefon.Text));
        }

        private void dgKundeOversigt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Kunde kunde = (e.AddedItems[0] as Kunde);
                tbFornavn.Text = kunde.Fornavn;
                tbEfternavn.Text = kunde.Efternavn;
                tbAdresse.Text = kunde.Adresse;
                tbPostnummer.Text = kunde.Postnummer.ToString();
                tbTelefon.Text = kunde.Telefon.ToString();
            }
            else
            {
                tbFornavn.Text = "";
                tbEfternavn.Text = "";
                tbAdresse.Text = "";
                tbPostnummer.Text = "";
                tbTelefon.Text = "";
            }
        }

        private void btnSletKunde_Click(object sender, RoutedEventArgs e)
        {
            func.DeleteKunde(dgKundeOversigt.SelectedItem as Kunde);
        }

        private void btnOpdaterKunde_Click(object sender, RoutedEventArgs e)
        {
            func.OpdaterKunde(dgKundeOversigt.SelectedItem as Kunde, tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, Convert.ToInt32(tbPostnummer.Text), Convert.ToInt32(tbTelefon.Text));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            func.OpretBilModel(tbBilMærke.Text, tbBilModel.Text, Convert.ToDateTime(tbBilStartår.Text), Convert.ToDateTime(tbBilSlutår.Text), Convert.ToDecimal(tbBilPris.Text), Convert.ToDecimal(tbBilForsikring.Text));
        }

        private void dgBilModelOversigt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                BilModel model = (e.AddedItems[0] as BilModel);
                tbBilMærke.Text = model.Mærke;
                tbBilModel.Text = model.Model;
                tbBilStartår.Text = model.Begyndelsesår.Year.ToString();
                tbBilSlutår.Text = model.Slutår.Year.ToString();
                tbBilPris.Text = model.Pris.ToString();
                tbBilForsikring.Text = model.Forsikringssum.ToString();
            }
            else
            {
                tbBilMærke.Text = "";
                tbBilModel.Text = "";
                tbBilStartår.Text = "";
                tbBilSlutår.Text = "";
                tbBilPris.Text = "";
                tbBilForsikring.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Forsikring Tab
            // Oprettelse af Forsikring
            func.OpretForsikring(cbKunde.SelectedItem as Kunde, cbBilmodel.SelectedItem as BilModel, tbForsikringReg.Text, Convert.ToDecimal(tbForPris.Text), Convert.ToDecimal(tbForForsiknum.Text), tbForBetingelser.Text, Convert.ToDateTime(tbForBegyndelsesår.Text));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // BilModel
            // Kun til Testning
            // Opdatering af BilModel
            func.OpdaterBilModel(dgBilModelOversigt.SelectedItem as BilModel, tbBilMærke.Text, tbBilModel.Text, Convert.ToDateTime(tbBilStartår.Text), Convert.ToDateTime(tbBilSlutår.Text), Convert.ToDecimal(tbBilPris.Text), Convert.ToDecimal(tbBilForsikring.Text));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // BilModel
            // Sletning af Bilmodel
            func.DeleteBilModel(dgBilModelOversigt.SelectedItem as BilModel);
        }

        private void dgForsikringsOversigt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Forsikring forsik = (e.AddedItems[0] as Forsikring);
                cbKunde.SelectedItem = forsik.KundeId;
                cbBilmodel.SelectedItem = forsik.BilModelId;
                tbForsikringReg.Text = forsik.Registreringsnummer;
                tbForPris.Text = forsik.Præmie.ToString();
                tbForForsiknum.Text = forsik.Forsikringssum.ToString();
                tbForBegyndelsesår.Text = forsik.Begyndelsesår.Year.ToString();
                tbForBetingelser.Text = forsik.Betingelser;
            }
            else
            {
                cbKunde.SelectedItem = "";
                cbBilmodel.SelectedItem = "";
                tbForsikringReg.Text = "";
                tbForPris.Text = "";
                tbForForsiknum.Text = "";
                tbForBegyndelsesår.Text = "";
                tbForBetingelser.Text = "";
            }
        }
    }
}
