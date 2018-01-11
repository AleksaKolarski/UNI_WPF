using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcAkcija : UserControl
    {
        ICollectionView view;

        public UcAkcija()
        {
            view = CollectionViewSource.GetDefaultView(Akcija.akcijaCollection);
            InitializeComponent();
            
            view.Filter = Filter;
            dgAkcija.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        #region Filters
        private bool Filter(object obj)
        {
            if (((Akcija)obj).Obrisan == false)
            {
                if (cbAktivne.IsChecked == true)
                {
                    if (((Akcija)obj).DatumPocetka > DateTime.Now || ((Akcija)obj).DatumKraja < DateTime.Now)
                    {
                        return false;
                    }
                }
                var text = ((ComboBoxItem)cbPretraga.SelectedItem).Content.ToString();
                if (text.Equals("Id"))
                {
                    return ((Akcija)obj).Id.ToString().IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                else if (text.Equals("Naziv"))
                {
                    return ((Akcija)obj).Naziv.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                return false;
            }
            return false;
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpAkcija dpAkcija = new DpAkcija();
            dpAkcija.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                DpAkcija dpAkcija = new DpAkcija((Akcija)dgAkcija.SelectedItem);
                dpAkcija.ShowDialog();
                view.Refresh();
                dgAkcija_SelectionChanged(this, null);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                if (MessageBox.Show("Da li ste sigurni da hocete da obrisete akciju?", "Brisanje akcije.", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Akcija.Delete((Akcija)dgAkcija.SelectedItem);
                    view.Refresh();
                    dgNamestaj.ItemsSource = new ObservableCollection<UredjeniPar>();
                }
            }
        }

        private void dgAkcija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                ICollectionView view = new CollectionViewSource { Source = ((Akcija)dgAkcija.SelectedItem).Lista }.View;
                view.Filter = FilterNamestaja;
                dgNamestaj.ItemsSource = view;
            }
        }
        #region Filters2
        private bool FilterNamestaja(object obj)
        {
            return !(((UredjeniPar)obj).Namestaj.Obrisan);
        }
        #endregion

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            view.Refresh();
        }

        private void cbPretraga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.Refresh();
        }

        private void cbAktivne_Changed(object sender, RoutedEventArgs e)
        {
            view.Refresh();
        }
    }
}
