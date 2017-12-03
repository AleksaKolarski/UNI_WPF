using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public DpTipNamestaja()
        {
            InitializeComponent();
            tblock.Text = "Nov tip namestaja:";
            operacija = Operacija.DODAVANJE;
        }

        TipNamestaja tmp;
        public DpTipNamestaja(TipNamestaja tipNamestaja)
        {
            InitializeComponent();
            if(tipNamestaja == null)
            {
                Close();
                return;
            }
            tmp = tipNamestaja;
            tblock.Text = "Izmena namestaja:";
            tbNaziv.Text = tmp.Naziv;
            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text != "")
            {
                if (operacija == Operacija.DODAVANJE)
                {
                    TipNamestaja.Add(new TipNamestaja(tbNaziv.Text));
                }
                else if (operacija == Operacija.IZMENA)
                {
                    TipNamestaja.Edit(tmp, tbNaziv.Text);
                }
                Close();
                return;
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
