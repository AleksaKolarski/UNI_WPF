using POP_SF27_2016_Projekat.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpProdajaDodatnaUsluga : Window
    {
        DodatnaUsluga dodatnaUsluga;
        ProdajaNamestajaRuntime prodaja;

        ICollectionView view;

        public DpProdajaDodatnaUsluga(ProdajaNamestajaRuntime prodaja)
        {
            InitializeComponent();
            tblock.Text = "Dodatna usluga:";

            this.prodaja = prodaja;
            this.dodatnaUsluga = new DodatnaUsluga();

            view = new CollectionViewSource { Source = DodatnaUsluga.dodatnaUslugaCollection }.View;
            view.Filter = Filter;
            cbDodatnaUsluga.ItemsSource = view;

            cbDodatnaUsluga.DataContext = dodatnaUsluga;
        }

        #region Filters
        private bool Filter(object obj)
        {
            return !(((DodatnaUsluga)obj).Obrisan);
        }
        #endregion

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(cbDodatnaUsluga.SelectedItem != null)
            {
                dodatnaUsluga.Copy((DodatnaUsluga)cbDodatnaUsluga.SelectedItem);
                prodaja.AddDodatnaUsluga(dodatnaUsluga);
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
