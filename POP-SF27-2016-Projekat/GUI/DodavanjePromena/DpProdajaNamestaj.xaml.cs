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
        ProdajaNamestaja prodaja;
        public DpProdajaNamestaj(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            tblock.Text = "Nova stavka:";
            operacija = Operacija.DODAVANJE;

            uredjeniParCopy = new UredjeniParRacun();

            this.prodaja = prodaja;

            tbKolicina.DataContext = uredjeniParCopy;
        }
        public DpProdajaNamestaj(UredjeniParRacun uredjeniPar, ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            tblock.Text = "Izmena stavke:";
            operacija = Operacija.IZMENA;

            this.uredjeniParReal = uredjeniPar;
            this.uredjeniParCopy = uredjeniPar.Copy();
            cbNamestaj.SelectedItem = uredjeniParCopy.Namestaj;

            this.prodaja = prodaja;

            cbNamestaj.DataContext = uredjeniParCopy;
            tbKolicina.DataContext = uredjeniParCopy;
        }
    }
}
