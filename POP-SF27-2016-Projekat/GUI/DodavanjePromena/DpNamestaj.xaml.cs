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
    public partial class DpNamestaj : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }
        private Operacija operacija;

        Namestaj namestajCopy;
        Namestaj namestajReal;

        public DpNamestaj()
        {
            InitializeComponent();
            tblock.Text = "Nov namestaj:";
            operacija = Operacija.DODAVANJE;

            namestajCopy = new Namestaj("","",0,0,new TipNamestaja());

            tbNaziv.DataContext = namestajCopy;
            tbSifra.DataContext = namestajCopy;
            tbJedinicnaCena.DataContext = namestajCopy;
            tbKolicinaUMagacinu.DataContext = namestajCopy;
            cbTip.DataContext = namestajCopy;
        }

        public DpNamestaj(Namestaj namestaj)
        {
            InitializeComponent();
            tblock.Text = "Izmena namestaja:";
            operacija = Operacija.IZMENA;

            namestajCopy = new Namestaj();
            namestajCopy.Copy(namestaj);
            namestajReal = namestaj;

            tbNaziv.DataContext = namestajCopy;
            tbSifra.DataContext = namestajCopy;
            tbJedinicnaCena.DataContext = namestajCopy;
            tbKolicinaUMagacinu.DataContext = namestajCopy;
            cbTip.DataContext = namestajCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (namestajCopy.Naziv != "")
            {
                if (namestajCopy.Sifra != "")
                {
                    double jedinicnaCena;
                    if (double.TryParse(tbJedinicnaCena.Text, out jedinicnaCena))
                    {
                        int kolicinaUMagacinu;
                        if (int.TryParse(tbKolicinaUMagacinu.Text, out kolicinaUMagacinu))
                        {
                            if (namestajCopy.TipNamestaja != null)
                            {
                                if (operacija == Operacija.DODAVANJE)
                                {
                                    Namestaj.Add(namestajCopy);
                                }
                                else if (operacija == Operacija.IZMENA)
                                {
                                    namestajReal.Copy(namestajCopy);
                                }
                                Close();
                                return;
                            }
                            else
                            {
                                cbTip.Focus();
                            }
                        }
                        else
                        {
                            tbJedinicnaCena.Focus();
                        }
                    }
                    else
                    {
                        tbJedinicnaCena.Focus();
                    }
                }
                else
                {
                    tbSifra.Focus();
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
