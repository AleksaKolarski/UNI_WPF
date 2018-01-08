using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF27_2016_Projekat.GUI.UcNamestaj
{
    public partial class UcRadSaNamestajem : UserControl
    {
        public ICollectionView view;

        public UcRadSaNamestajem()
        {
            view = CollectionViewSource.GetDefaultView(Namestaj.namestajCollection);
            InitializeComponent();

            view.Filter = Filter;
            dgNamestaj.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        #region Filters
        private bool Filter(object obj)
        {
            if (((Namestaj)obj).Obrisan == false)
            {
                var text = ((ComboBoxItem)cbPretraga.SelectedItem).Content.ToString();
                if (text.Equals("Id"))
                {
                    return ((Namestaj)obj).Id.ToString().IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Naziv"))
                {
                    return ((Namestaj)obj).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Sifra"))
                {
                    return ((Namestaj)obj).Sifra.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Tip namestaja"))
                {
                    return ((Namestaj)obj).TipNamestaja.Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpNamestaj dpNamestaj = new DpNamestaj();
            dpNamestaj.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.SelectedItem != null)
            {
                DpNamestaj dpNamestaj = new DpNamestaj((Namestaj)dgNamestaj.SelectedItem);
                dpNamestaj.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.SelectedItem != null)
            {
                if (MessageBox.Show("Da li ste sigurni da hocete da obrisete namestaj?", "Brisanje namestaja.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Namestaj.Delete((Namestaj)dgNamestaj.SelectedItem);
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
