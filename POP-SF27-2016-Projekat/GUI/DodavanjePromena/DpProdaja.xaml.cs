using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ProdajaNamestajaRuntime prodaja;

        public DpProdaja()
        {
            InitializeComponent();

            prodaja = new ProdajaNamestajaRuntime();
            dgNamestaj.ItemsSource = prodaja.ListUredjeniPar;
            dgDodatneUsluge.ItemsSource = prodaja.ListDodatnaUsluga;
            tbPDV.DataContext = prodaja;
            tbUkupnaCena.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            tbRacun.DataContext = prodaja;
        }

        private void btnAddNamestaj_Click(object sender, RoutedEventArgs e)
        {
            DpProdajaNamestaj dpProdajaNamestaj = new DpProdajaNamestaj(prodaja);
            dpProdajaNamestaj.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnEditNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.SelectedItem != null)
            {
                DpProdajaNamestaj dpProdajaNamestaj = new DpProdajaNamestaj((UredjeniParRacun)dgNamestaj.SelectedItem, prodaja);
                dpProdajaNamestaj.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
            }
        }

        private void btnDeleteNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.SelectedItem != null)
            {
                prodaja.DeleteNamestajPar((UredjeniParRacun)dgNamestaj.SelectedItem);
            }
        }

        private void btnAddUsluga_Click(object sender, RoutedEventArgs e)
        {
            DpProdajaDodatnaUsluga dpProdajaDodatnaUsluga = new DpProdajaDodatnaUsluga(prodaja);
            dpProdajaDodatnaUsluga.ShowDialog();
        }

        private void btnDeleteUsluga_Click(object sender, RoutedEventArgs e)
        {
            if (dgDodatneUsluge.SelectedItem != null)
            {
                prodaja.DeleteDodatnaUsluga((DodatnaUsluga)dgDodatneUsluge.SelectedItem);
            }
        }

        private void btnPotvrda_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(prodaja.Kupac) && !string.IsNullOrEmpty(prodaja.BrojRacuna))
            {
                if (prodaja.ListUredjeniPar.Count > 0)
                {
                    prodaja.DatumProdaje = DateTime.Now;
                    //ProdajaNamestajaRuntime.prodajaNamestajaCollection.Add(prodaja);
                    // prodaja runtime -> prodaja storage
                    ObservableCollection<UredjeniParRacunNamestaj> listaNamestaja = new ObservableCollection<UredjeniParRacunNamestaj>();
                    foreach(UredjeniParRacun par in prodaja.ListUredjeniPar)
                    {
                        listaNamestaja.Add(new UredjeniParRacunNamestaj(par.Namestaj.Naziv, par.Namestaj.JedinicnaCena, par.BrojNamestaja, par.Popust));
                    }

                    ObservableCollection<UredjeniParRacunDodatnaUsluga> listaUsluga = new ObservableCollection<UredjeniParRacunDodatnaUsluga>();
                    foreach(DodatnaUsluga usluga in prodaja.ListDodatnaUsluga)
                    {
                        listaUsluga.Add(new UredjeniParRacunDodatnaUsluga(usluga.Naziv, usluga.Cena));
                    }

                    ProdajaNamestaja prodajaStorage = new ProdajaNamestaja(listaNamestaja, listaUsluga, prodaja.DatumProdaje, prodaja.Kupac, prodaja.BrojRacuna, prodaja.PDV);

                    ProdajaNamestaja.Create(prodajaStorage);
                    Close();
                }
            }
        }
    }
}
