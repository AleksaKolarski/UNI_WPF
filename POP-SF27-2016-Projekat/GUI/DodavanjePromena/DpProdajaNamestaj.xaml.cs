using POP_SF27_2016_Projekat.Model;
using System.Windows;

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

            this.prodaja = prodaja;

            cbNamestaj.DataContext = uredjeniParCopy;
            tbKolicina.DataContext = uredjeniParCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(operacija == Operacija.DODAVANJE)
            {
                prodaja.AddNamestajPar(uredjeniParCopy);
            }
            else if(operacija == Operacija.IZMENA)
            {
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
