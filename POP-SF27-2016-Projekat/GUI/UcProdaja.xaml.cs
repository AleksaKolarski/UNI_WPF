using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcProdaja : UserControl
    {
        ICollectionView view;

        public UcProdaja()
        {
            view = CollectionViewSource.GetDefaultView(ProdajaNamestaja.prodajaNamestajaCollection);
            InitializeComponent();

            view.Filter = Filter;
            dgProdaja.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        #region Filters
        private bool Filter(object obj)
        {
            var text = ((ComboBoxItem)cbPretraga.SelectedItem).Content.ToString();
            if (text.Equals("Id"))
            {
                return ((ProdajaNamestaja)obj).Id.ToString().IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            else if (text.Equals("Kupac"))
            {
                return ((ProdajaNamestaja)obj).Kupac.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            else if (text.Equals("Broj racuna"))
            {
                return ((ProdajaNamestaja)obj).BrojRacuna.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            else if (text.Equals("Namestaj"))
            {
                foreach(UredjeniParRacunNamestaj par in ((ProdajaNamestaja)obj).ListProdatiNamestaji)
                {
                    if(par.NazivNamestaja.IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (text.Equals("Datum"))
            {
                return ((ProdajaNamestaja)obj).DatumProdaje.Value.ToString("dd.MM.yyyy. HH:mm:ss").IndexOf(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return false;
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpProdaja dpProdaja = new DpProdaja();
            dpProdaja.ShowDialog();
        }

        private void dgProdaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProdaja.SelectedItem != null)
            {
                dgNamestaj.ItemsSource = ((ProdajaNamestaja)dgProdaja.SelectedItem).ListProdatiNamestaji;
                dgDodatneUsluge.ItemsSource = ((ProdajaNamestaja)dgProdaja.SelectedItem).ListProdateDodatneUsluge;
                tbPDV.DataContext = (ProdajaNamestaja)dgProdaja.SelectedItem;
                tbUkupnaCena.DataContext = (ProdajaNamestaja)dgProdaja.SelectedItem;
            }
        }

        private void cbPretraga_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.Refresh();
        }

        private void tbPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            view.Refresh();
        }
    }
}
