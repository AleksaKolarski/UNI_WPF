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

        DodatnaUsluga dodatnaUsluga;

        public DpDodatnaUsluga()
        {
            InitializeComponent();
            tblock.Text = "Nova dodatna usluga:";
            operacija = Operacija.DODAVANJE;

            dodatnaUsluga = new DodatnaUsluga();

            InitFields();
        }

        public DpDodatnaUsluga(DodatnaUsluga dodatnaUslugaParam)
        {
            InitializeComponent();
            tblock.Text = "Izmena dodatne usluge:";
            operacija = Operacija.IZMENA;

            dodatnaUsluga = new DodatnaUsluga();
            dodatnaUsluga.Copy(dodatnaUslugaParam);

            InitFields();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(dodatnaUsluga.Naziv != "")
            {
                double cena;
                if (double.TryParse(tbCena.Text, out cena))
                {
                    if (operacija == Operacija.DODAVANJE)
                    {
                        DodatnaUsluga.Create(dodatnaUsluga);
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        DodatnaUsluga.Update(dodatnaUsluga);
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

        private void InitFields()
        {
            tbNaziv.DataContext = dodatnaUsluga;
            tbCena.DataContext = dodatnaUsluga;
        }
    }
}
