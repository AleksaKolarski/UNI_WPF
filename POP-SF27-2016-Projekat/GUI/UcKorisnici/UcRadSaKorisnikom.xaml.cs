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
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Korisnik.korisnikCollection);
            view.Filter = HideDeletedFilter;
            dgKorisnik.ItemsSource = view;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpKorisnik dpKorisnik = new DpKorisnik();
            dpKorisnik.ShowDialog(); // Cekamo da se zatvori prozor za dodavanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpKorisnik dpKorisnik = new DpKorisnik((Korisnik)view.CurrentItem);
            dpKorisnik.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (view.CurrentItem is Korisnik tmp)    // kastujemo obj u DodatnaUsluga
            {
                Korisnik.Remove(tmp);
                view.Refresh();
            }
        }
    }
}
