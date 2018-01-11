using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF27_2016_Projekat.GUI.UcNamestaj
{
    public partial class UcRadSaTipomNamestaja : UserControl
    {
        ICollectionView view;

        public UcRadSaTipomNamestaja()
        {
            view = new CollectionViewSource { Source = TipNamestaja.tipNamestajaCollection }.View;
            InitializeComponent();

            view.Filter = Filter;
            dgTipNamestaja.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        #region Filters
        private bool Filter(object obj)
        {
            if (((TipNamestaja)obj).Obrisan == false)
            {
                var text = ((ComboBoxItem)cbPretraga.SelectedItem).Content.ToString();
                if (text.Equals("Id"))
                {
                    return ((TipNamestaja)obj).Id.ToString().IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Naziv"))
                {
                    return ((TipNamestaja)obj).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpTipNamestaja dpTipNamestaja = new DpTipNamestaja();
            dpTipNamestaja.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipNamestaja.SelectedItem != null)
            {
                DpTipNamestaja dpTipNamestaja = new DpTipNamestaja((TipNamestaja)dgTipNamestaja.SelectedItem);
                dpTipNamestaja.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipNamestaja.SelectedItem != null)
            {
                if (MessageBox.Show("Da li ste sigurni da hocete da obrisete tip namestaja? Ovo ce obrisati i sve namestaje ovog tipa!", "Brisanje tipa namestaja.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TipNamestaja.Delete((TipNamestaja)dgTipNamestaja.SelectedItem);
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
