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

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpProdaja : Window
    {
        ProdajaNamestaja prodaja;

        public DpProdaja()
        {
            InitializeComponent();

            prodaja = new ProdajaNamestaja();
            dgNamestaj.ItemsSource = prodaja.ListUredjeniPar;
            dgDodatneUsluge.ItemsSource = prodaja.ListDodatnaUsluga;
            tbPDV.DataContext = prodaja;
            tbUkupnaCena.DataContext = prodaja;
        }

        private void btnAddNamestaj_Click(object sender, RoutedEventArgs e)
        {
            DpProdajaNamestaj dpProdajaNamestaj = new DpProdajaNamestaj(prodaja);
            dpProdajaNamestaj.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnEditNamestaj_Click(object sender, RoutedEventArgs e)
        {
            DpProdajaNamestaj dpProdajaNamestaj = new DpProdajaNamestaj((UredjeniParRacun)dgNamestaj.SelectedItem, prodaja);
            dpProdajaNamestaj.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDeleteNamestaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddUsluga_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteUsluga_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
