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
    public partial class DpProdajaNamestaj : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        Operacija operacija;

        UredjeniParRacun uredjeniParReal;
        UredjeniParRacun uredjeniParCopy;
        ProdajaNamestajaRuntime prodaja;
        public DpProdajaNamestaj(ProdajaNamestajaRuntime prodaja)
        {
            InitializeComponent();
            tblock.Text = "Nova stavka:";
            operacija = Operacija.DODAVANJE;

            uredjeniParCopy = new UredjeniParRacun();

            this.prodaja = prodaja;

            cbNamestaj.DataContext = uredjeniParCopy;
            tbKolicina.DataContext = uredjeniParCopy;
        }
        public DpProdajaNamestaj(UredjeniParRacun uredjeniPar, ProdajaNamestajaRuntime prodaja)
        {
            InitializeComponent();
            tblock.Text = "Izmena stavke:";
            operacija = Operacija.IZMENA;

            this.uredjeniParReal = uredjeniPar;

            this.uredjeniParCopy = new UredjeniParRacun();
            this.uredjeniParCopy.Copy(uredjeniPar);

            cbNamestaj.SelectedItem = uredjeniParCopy.Namestaj;

            this.prodaja = prodaja;

            cbNamestaj.DataContext = uredjeniParCopy;
            tbKolicina.DataContext = uredjeniParCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(operacija == Operacija.DODAVANJE)
            {
                //prodaja.ListUredjeniPar.Add(uredjeniParCopy);
                prodaja.AddNamestajPar(uredjeniParCopy);
            }
            else if(operacija == Operacija.IZMENA)
            {
                //uredjeniParReal.Copy(uredjeniParCopy);
                prodaja.EditNamestajPar(uredjeniParCopy, uredjeniParReal);
            }
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
