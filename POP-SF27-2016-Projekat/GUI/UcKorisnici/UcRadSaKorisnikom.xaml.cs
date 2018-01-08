using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace POP_SF27_2016_Projekat.GUI.UcKorisnici
{
    public partial class UcRadSaKorisnikom : UserControl
    {
        ICollectionView view;

        public UcRadSaKorisnikom()
        {
            view = CollectionViewSource.GetDefaultView(Korisnik.korisnikCollection);
            InitializeComponent();

            
            view.Filter = Filter;
            dgKorisnik.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        #region Filters
        private bool Filter(object obj)
        {
            if (((Korisnik)obj).Obrisan == false)
            {
                var text = ((ComboBoxItem)cbPretraga.SelectedItem).Content.ToString();
                if (text.Equals("Id"))
                {
                    return ((Korisnik)obj).Id.ToString().IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Ime"))
                {
                    return ((Korisnik)obj).Ime.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Prezime"))
                {
                    return ((Korisnik)obj).Prezime.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Korisnicko ime"))
                {
                    return ((Korisnik)obj).KorisnickoIme.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Tip korisnika"))
                {
                    return ((Korisnik)obj).TipKorisnika.Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpKorisnik dpKorisnik = new DpKorisnik();
            dpKorisnik.ShowDialog(); // Cekamo da se zatvori prozor za dodavanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnik.SelectedItem != null)
            {
                DpKorisnik dpKorisnik = new DpKorisnik((Korisnik)dgKorisnik.SelectedItem);
                dpKorisnik.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgKorisnik.SelectedItem != null)
            {
                if (MessageBox.Show("Da li ste sigurni da hocete da obrisete korisnika?", "Brisanje korisnika.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Korisnik.Delete((Korisnik)dgKorisnik.SelectedItem);
                    view.Refresh();
                }
            }
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            view.Refresh();
        }

        private void cbPretraga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.Refresh();
        }
    }
}
