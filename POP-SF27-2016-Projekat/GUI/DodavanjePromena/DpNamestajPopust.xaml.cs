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
    public partial class DpNamestajPopust : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        private Operacija operacija;

        Akcija akcija;
        UredjeniPar uredjeniParCopy;
        UredjeniPar uredjeniParReal;

        public DpNamestajPopust(Akcija akcijaT)
        {
            InitializeComponent();
            tblock.Text = "Nov popust za namestaj:";
            operacija = Operacija.DODAVANJE;

            akcija = akcijaT;

            uredjeniParCopy = new UredjeniPar();

            cbNamestaj.DataContext = uredjeniParCopy;
            tbPopust.DataContext = uredjeniParCopy;
        }

        public DpNamestajPopust(UredjeniPar par, Akcija akcijaT)
        {
            InitializeComponent();
            tblock.Text = "Izmena popusta za namestaj:";
            operacija = Operacija.IZMENA;

            akcija = akcijaT;

            uredjeniParReal = par;
            uredjeniParCopy = new UredjeniPar();
            uredjeniParCopy.Copy(par);

            cbNamestaj.DataContext = uredjeniParCopy;
            tbPopust.DataContext = uredjeniParCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            double popust;
            if (double.TryParse(tbPopust.Text, out popust))
            {
                if (cbNamestaj.SelectedItem != null)
                {
                    if (operacija == Operacija.DODAVANJE)
                    {
                        akcija.Lista.Add(uredjeniParCopy);
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        uredjeniParReal.Copy(uredjeniParCopy);
                    }
                    Close();
                    return;
                }
                cbNamestaj.Focus();
            }
            else
            {
                tbPopust.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
