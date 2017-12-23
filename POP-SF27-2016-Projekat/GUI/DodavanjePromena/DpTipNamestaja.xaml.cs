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
    public partial class DpTipNamestaja : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }
        private Operacija operacija;

        private TipNamestaja tipNamestajaCopy;
        private TipNamestaja tipNamestajaReal;

        public DpTipNamestaja()
        {
            InitializeComponent();
            tblock.Text = "Nov tip namestaja:";
            operacija = Operacija.DODAVANJE;

            tipNamestajaCopy = new TipNamestaja("");

            tbNaziv.DataContext = tipNamestajaCopy;
        }

        public DpTipNamestaja(TipNamestaja tipNamestaja)
        {
            InitializeComponent();
            tblock.Text = "Izmena namestaja:";
            operacija = Operacija.IZMENA;

            tipNamestajaReal = tipNamestaja;
            tipNamestajaCopy = new TipNamestaja();
            tipNamestajaCopy.Copy(tipNamestaja);

            tbNaziv.DataContext = tipNamestajaCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tipNamestajaCopy.Naziv != "")
            {
                if (operacija == Operacija.DODAVANJE)
                {
                    TipNamestaja.Add(tipNamestajaCopy);
                }
                else if (operacija == Operacija.IZMENA)
                {
                    tipNamestajaReal.Copy(tipNamestajaCopy);
                }
                Close();
            }
            else
            {
                tbNaziv.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
