using POP_SF27_2016_Projekat.GUI.UcKorisnici;
using POP_SF27_2016_Projekat.GUI.UcNamestaj;
using POP_SF27_2016_Projekat.Model;
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
using System.Windows.Shapes;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class MainWindow : Window
    {
        private UcProdaja ucProdaja;
        private UcRadSaNamestajem ucRadSaNamestajem;
        private UcRadSaTipomNamestaja ucRadSaTipomNamestaja;
        private UcAkcija ucAkcija;
        private UcDodatnaUsluga ucDodatnaUsluga;
        private UcRadSaKorisnikom ucRadSaKorisnikom;
        private UcRadSaTipomKorisnika ucRadSaTipomKorisnika;
        private UcSalon ucSalon;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = $"Salon namestaja: {Salon.SalonProperty.Naziv} | Ulogovani ste kao: {Korisnik.Trenutni.Ime} {Korisnik.Trenutni.Prezime} | {Korisnik.Trenutni.TipKorisnika.Naziv}";


            /* Inicijalizacija prozora */
            ucProdaja = new UcProdaja();
            ucRadSaNamestajem = new UcRadSaNamestajem();
            ucRadSaTipomNamestaja = new UcRadSaTipomNamestaja();
            ucAkcija = new UcAkcija();
            ucDodatnaUsluga = new UcDodatnaUsluga();
            ucRadSaKorisnikom = new UcRadSaKorisnikom();
            ucRadSaTipomKorisnika = new UcRadSaTipomKorisnika();
            ucSalon = new UcSalon();


            btnSalon_Click(this, null); // Pri otvaranju prozora nek se prikazu informacije o salonu
        }

        #region Prodaja
        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Prodaja";
            MainArea.Content = ucProdaja;
            HideAllTempButtons();
        }
        #endregion

        #region Namestaj
        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
            btnRadSaNamestajem.Visibility = Visibility.Visible;
            btnRadSaTipomNamestaja.Visibility = Visibility.Visible;
        }

        private void btnRadSaNamestajem_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Rad sa namestajem";
            MainArea.Content = ucRadSaNamestajem;
            ucRadSaNamestajem.view.Refresh();
            HideAllTempButtons();
        }

        private void btnRadSaTipomNamestaja_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Rad sa tipom namestaja";
            MainArea.Content = ucRadSaTipomNamestaja;
            HideAllTempButtons();
        }
        #endregion

        #region Akcije
        private void btnAkcije_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Akcije";
            MainArea.Content = ucAkcija;
            HideAllTempButtons();
        }
        #endregion

        #region Dodatne usluge
        private void btnDodatneUsluge_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Dodatne usluge";
            MainArea.Content = ucDodatnaUsluga;
            HideAllTempButtons();
        }
        #endregion

        #region Korisnici
        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
            btnRadSaKorisnicima.Visibility = Visibility.Visible;
            btnRadSaTipomKorisnika.Visibility = Visibility.Visible;
        }

        private void btnRadSaKorisnicima_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Rad sa korisnicima";
            MainArea.Content = ucRadSaKorisnikom;
            HideAllTempButtons();
        }

        private void btnRadSaTipomKorisnika_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Rad sa tipom korisnika";
            MainArea.Content = ucRadSaTipomKorisnika;
            HideAllTempButtons();
        }
        #endregion

        #region Salon
        private void btnSalon_Click(object sender, RoutedEventArgs e)
        {
            gbMainArea.Header = "Salon";
            MainArea.Content = ucSalon;
            HideAllTempButtons();
        }
        #endregion

        #region Logout
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Korisnik.Logout();
            this.Close();
        }
        #endregion

        #region Misc
        private void HideAllTempButtons()
        {
            btnRadSaNamestajem.Visibility = Visibility.Hidden;
            btnRadSaTipomNamestaja.Visibility = Visibility.Hidden;
            btnRadSaKorisnicima.Visibility = Visibility.Hidden;
            btnRadSaTipomKorisnika.Visibility = Visibility.Hidden;
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HideAllTempButtons();
        }
        #endregion
    }
}
