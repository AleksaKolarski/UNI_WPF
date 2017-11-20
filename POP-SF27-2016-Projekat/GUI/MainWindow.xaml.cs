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
        public MainWindow()
        {
            InitializeComponent();
            this.Title = $"Salon namestaja: {Salon.SalonProperty.Naziv} | Ulogovani ste kao: {Korisnik.Trenutni.Ime} {Korisnik.Trenutni.Prezime}";
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Korisnik.Logout();
            this.Close();
        }

        private void btnNamestaj_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
            btnRadSaNamestajem.Visibility = Visibility.Visible;
            btnRadSaTipomNamestaja.Visibility = Visibility.Visible;
            btnRadSaAkcijama.Visibility = Visibility.Visible;
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
            btnRadSaKorisnicima.Visibility = Visibility.Visible;
            btnRadSaTipomKorisnika.Visibility = Visibility.Visible;
        }

        private void btnProdaja_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
        }

        private void btnDodatneUsluge_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
        }

        private void btnSalon_Click(object sender, RoutedEventArgs e)
        {
            HideAllTempButtons();
        }

        private void HideAllTempButtons()
        {
            btnRadSaNamestajem.Visibility = Visibility.Hidden;
            btnRadSaTipomNamestaja.Visibility = Visibility.Hidden;
            btnRadSaAkcijama.Visibility = Visibility.Hidden;
            btnRadSaKorisnicima.Visibility = Visibility.Hidden;
            btnRadSaTipomKorisnika.Visibility = Visibility.Hidden;
        }
    }
}
