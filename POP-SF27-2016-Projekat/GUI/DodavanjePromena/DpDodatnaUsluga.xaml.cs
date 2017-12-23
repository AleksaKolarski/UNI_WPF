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
    public partial class DpDodatnaUsluga : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }
        private Operacija operacija;

        DodatnaUsluga dodatnaUslugaCopy;
        DodatnaUsluga dodatnaUslugaReal;

        public DpDodatnaUsluga()
        {
            InitializeComponent();
            tblock.Text = "Nova dodatna usluga:";
            operacija = Operacija.DODAVANJE;

            dodatnaUslugaCopy = new DodatnaUsluga("", 0);

            tbNaziv.DataContext = dodatnaUslugaCopy;
            tbCena.DataContext = dodatnaUslugaCopy;
        }

        public DpDodatnaUsluga(DodatnaUsluga dodatnaUsluga)
        {
            InitializeComponent();
            tblock.Text = "Izmena dodatne usluge:";
            operacija = Operacija.IZMENA;

            dodatnaUslugaReal = dodatnaUsluga;
            dodatnaUslugaCopy = new DodatnaUsluga();
            dodatnaUslugaCopy.Copy(dodatnaUsluga);

            tbNaziv.DataContext = dodatnaUslugaCopy;
            tbCena.DataContext = dodatnaUslugaCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(dodatnaUslugaCopy.Naziv != "")
            {
                double cena;
                if (double.TryParse(tbCena.Text, out cena))
                {
                    if (operacija == Operacija.DODAVANJE)
                    {
                        DodatnaUsluga.Add(dodatnaUslugaCopy);
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        dodatnaUslugaReal.Copy(dodatnaUslugaCopy);
                    }
                    Close();
                    return;
                }
                else
                {
                    tbCena.Focus();
                }
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
