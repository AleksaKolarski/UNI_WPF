using POP_SF27_2016_Projekat.Model;
using System.Windows;

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpProdajaDodatnaUsluga : Window
    {
        DodatnaUsluga dodatnaUsluga;
        ProdajaNamestajaRuntime prodaja;

        public DpProdajaDodatnaUsluga(ProdajaNamestajaRuntime prodaja)
        {
            InitializeComponent();
            tblock.Text = "Dodatna usluga:";

            this.prodaja = prodaja;
            this.dodatnaUsluga = new DodatnaUsluga();

            cbDodatnaUsluga.DataContext = dodatnaUsluga;
        }

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
