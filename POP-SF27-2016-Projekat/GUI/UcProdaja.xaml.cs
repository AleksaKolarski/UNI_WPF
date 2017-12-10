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

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcProdaja : UserControl
    {
        ICollectionView view;
        ICollectionView viewNamestaj;
        ICollectionView viewDodatnaUsluga;

        public UcProdaja()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(ProdajaNamestaja.prodajaNamestajaCollection);
            dgProdaja.ItemsSource = view;
            dgProdaja.IsSynchronizedWithCurrentItem = true;
        }


        private void dgProdaja_GotFocus(object sender, RoutedEventArgs e)
        {
            viewNamestaj = CollectionViewSource.GetDefaultView(((ProdajaNamestaja)dgProdaja.CurrentItem).listUredjeniPar);
            dgNamestaj.ItemsSource = viewNamestaj;
            viewDodatnaUsluga = CollectionViewSource.GetDefaultView(((ProdajaNamestaja)dgProdaja.CurrentItem).ListDodatnaUsluga);
            dgDodatneUsluge.ItemsSource = viewDodatnaUsluga;
            tbPDV.DataContext = (ProdajaNamestaja)dgProdaja.CurrentItem;
            tbUkupnaCena.DataContext = (ProdajaNamestaja)dgProdaja.CurrentItem;
        }

        private void btnAddAkcija_Click(object sender, RoutedEventArgs e)
        {
            DpProdaja dpProdaja = new DpProdaja();
            dpProdaja.ShowDialog();
        }
    }
}
