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
    public partial class DpProdajaDodatnaUsluga : Window
    {
        DodatnaUsluga dodatnaUsluga;
        ProdajaNamestaja prodaja;
        public DpProdajaDodatnaUsluga(ProdajaNamestaja prodaja)
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
                prodaja.ListDodatnaUsluga.Add(dodatnaUsluga);
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
