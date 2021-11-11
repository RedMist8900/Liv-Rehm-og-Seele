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
            try
            {
                func.OpretKunde(tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, tbPostnummer.Text, tbTelefon.Text);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl ved oprettelse af Kunde");
            }
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
            try
            {
                func.DeleteKunde(dgKundeOversigt.SelectedItem as Kunde);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Fejl ved slettelse af Kunde");
            }
        }

        private void btnOpdaterKunde_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                func.OpdaterKunde(dgKundeOversigt.SelectedItem as Kunde, tbFornavn.Text, tbEfternavn.Text, tbAdresse.Text, Convert.ToInt32(tbPostnummer.Text), Convert.ToInt32(tbTelefon.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl ved opdatering af Kunde");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Oprettelse af BilModel
            try
            {
                func.OpretBilModel(tbBilMærke.Text, tbBilModel.Text, dpBilStartår.SelectedDate.Value, dpBilSlutår.SelectedDate.Value, tbBilPris.Text, tbBilForsikring.Text);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Fejl Ved Oprettelse af BilModel");
            }
        }

        private void dgBilModelOversigt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                BilModel model = (e.AddedItems[0] as BilModel);
                tbBilMærke.Text = model.Mærke;
                tbBilModel.Text = model.Model;
                //dpBilStartår.SelectedDate = model.Begyndelsesår.Year.ToString();
                //tbBilSlutår.Text = model.Slutår.Year.ToString();
                tbBilPris.Text = model.Pris.ToString();
                tbBilForsikring.Text = model.Forsikringssum.ToString();
            }
            else
            {
                tbBilMærke.Text = "";
                tbBilModel.Text = "";
                //tbBilStartår.Text = "";
                //tbBilSlutår.Text = "";
                tbBilPris.Text = "";
                tbBilForsikring.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Forsikring Tab
            // Oprettelse af Forsikring
            try
            {
                func.OpretForsikring(cbKunde.SelectedItem as Kunde, cbBilmodel.SelectedItem as BilModel, tbForsikringReg.Text, Convert.ToDecimal(tbForPris.Text), Convert.ToDecimal(tbForForsiknum.Text), dpForBegyndelsesår.SelectedDate.Value, tbForBetingelser.Text);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Fejl Ved Oprettelse af Forsikring");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // BilModel
            // Kun til Testning
            // Opdatering af BilModel
            func.OpdaterBilModel(dgBilModelOversigt.SelectedItem as BilModel, tbBilMærke.Text, tbBilModel.Text, dpBilStartår.SelectedDate.Value, dpBilSlutår.SelectedDate.Value, Convert.ToDecimal(tbBilPris.Text), Convert.ToDecimal(tbBilForsikring.Text));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // BilModel
            // Sletning af Bilmodel
            try
            {
                func.DeleteBilModel(dgBilModelOversigt.SelectedItem as BilModel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl Ved Slettelse af BilModel");
            }
        }

        private void dgForsikringsOversigt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Forsikring forsik = (e.AddedItems[0] as Forsikring);
                cbKunde.SelectedItem = forsik.KundeId;
                //cbBilmodel.SelectedItem = forsik.BilModelId;
                tbForsikringReg.Text = forsik.Registreringsnummer;
                tbForPris.Text = forsik.Præmie.ToString();
                tbForForsiknum.Text = forsik.Forsikringssum.ToString();
                //tbForBegyndelsesår.Text = forsik.Begyndelsesår.ToString();
                tbForBetingelser.Text = forsik.Betingelser;
            }
            else
            {
                //cbKunde.SelectedItem = "";
                //cbBilmodel.SelectedItem = "";
                tbForsikringReg.Text = "";
                tbForPris.Text = "";
                tbForForsiknum.Text = "";
                //tbForBegyndelsesår.Text = "";
                tbForBetingelser.Text = "";
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Forsikring
            // Opdatering af forsikring
            try
            {
                func.OpdaterForsikring(dgForsikringsOversigt.SelectedItem as Forsikring, tbForsikringReg.Text, dpForBegyndelsesår.SelectedDate.Value, tbForPris.Text, tbForForsiknum.Text, tbForBetingelser.Text);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl ved opdatering af Forsikring");
            }
        }

        public Vejr vejr = new Vejr();
        private void btnweather_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbxCity.Text == null || cbxCity.SelectedIndex.Equals(null))
                vejr.City = "København";
                vejr.City = cbxCity.Text;
                vejr.CurrentURL = $"https://api.openweathermap.org/data/2.5/weather?q=" + vejr.City + "&mode=xml&units=metric&appid=" + vejr.APIKEY;

                // Temperature Set
                tempGnsnt.Text = vejr.GetTemperature(vejr.Accesss());
                tempMin.Text = vejr.GetTemperatureMin(vejr.Accesss());
                tempMax.Text = vejr.GetTemperatureMax(vejr.Accesss());

                // Wind
                // Speed Set
                tbSpeed.Text = vejr.GetWindValue(vejr.Accesss());
                tbSpeedName.Text = vejr.GetWindName(vejr.Accesss());

                // Direction Set
                tbDirection.Text = vejr.GetWindDirection(vejr.Accesss());
                tbDirectionName.Text = vejr.GetWindDirectionName(vejr.Accesss());
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
