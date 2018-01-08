using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF27_2016_Projekat.GUI.UcKorisnici
{
    public partial class UcRadSaTipomKorisnika : UserControl
    {
        ICollectionView view;

        public UcRadSaTipomKorisnika()
        {
            view = CollectionViewSource.GetDefaultView(TipKorisnika.tipKorisnikaCollection);
            InitializeComponent();
            
            view.Filter = Filter;
            dgTipKorisnika.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        #region Filters
        private bool Filter(object obj)
        {
            if (((TipKorisnika)obj).Obrisan == false)
            {
                var text = ((ComboBoxItem)cbPretraga.SelectedItem).Content.ToString();
                if (text.Equals("Id"))
                {
                    return ((TipKorisnika)obj).Id.ToString().IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Naziv"))
                {
                    return ((TipKorisnika)obj).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpTipKorisnika dpTipKorisnika = new DpTipKorisnika();
            dpTipKorisnika.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipKorisnika.SelectedItem != null)
            {
                DpTipKorisnika dpTipKorisnika = new DpTipKorisnika((TipKorisnika)dgTipKorisnika.SelectedItem);
                dpTipKorisnika.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipKorisnika.SelectedItem != null)
            {
                if (MessageBox.Show("Da li ste sigurni da hocete da obrisete tip korisnika?", "Brisanje tipa korisnika.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TipKorisnika.Delete((TipKorisnika)dgTipKorisnika.SelectedItem);
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
