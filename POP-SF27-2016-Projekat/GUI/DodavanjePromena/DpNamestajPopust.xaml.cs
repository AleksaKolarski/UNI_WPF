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
        public DpNamestajPopust(Akcija akcijaT)
        {
            InitializeComponent();
            tblock.Text = "Nov popust za namestaj:";
            operacija = Operacija.DODAVANJE;
            cbNamestaj.ItemsSource = Namestaj.namestajCollection;
            akcija = akcijaT;
        }

        UredjeniPar tmp;
        public DpNamestajPopust(UredjeniPar par, Akcija akcijaT)
        {
            InitializeComponent();
            if (par == null)
            {
                return;
            }
            tmp = par;
            tblock.Text = "Izmena popusta za namestaj:";
            tbPopust.Text = tmp.Popust.ToString();
            cbNamestaj.ItemsSource = Namestaj.namestajCollection;
            operacija = Operacija.IZMENA;
            akcija = akcijaT;
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
                        akcija.Lista.Add(new UredjeniPar(((Namestaj)cbNamestaj.SelectedItem).Id, double.Parse(tbPopust.Text)));
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        tmp.NamestajId = ((Namestaj)cbNamestaj.SelectedItem).Id;
                        tmp.Popust = double.Parse(tbPopust.Text);
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
