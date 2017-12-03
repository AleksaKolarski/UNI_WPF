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

        public DpNamestaj()
        {
            InitializeComponent();
            tblock.Text = "Nov namestaj:";
            operacija = Operacija.DODAVANJE;
            cbTip.ItemsSource = TipNamestaja.tipNamestajaCollection;
        }

        Namestaj tmp;
        public DpNamestaj(Namestaj namestaj)
        {
            InitializeComponent();
            if (namestaj == null)
            {
                Close();
            }
            tmp = namestaj;
            tblock.Text = "Izmena namestaja:";
            tbNaziv.Text = tmp.Naziv;
            tbSifra.Text = tmp.Sifra;
            tbJedinicnaCena.Text = tmp.JedinicnaCena.ToString();
            tbKolicinaUMagacinu.Text = tmp.KolicinaUMagacinu.ToString();
            cbTip.ItemsSource = TipNamestaja.tipNamestajaCollection;
            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text != "")
            {
                if (tbSifra.Text != "")
                {
                    double jedinicnaCena;
                    if (double.TryParse(tbJedinicnaCena.Text, out jedinicnaCena))
                    {
                        int kolicinaUMagacinu;
                        if (int.TryParse(tbKolicinaUMagacinu.Text, out kolicinaUMagacinu))
                        {
                            if (cbTip.SelectedItem != null)
                            {
                                if (operacija == Operacija.DODAVANJE)
                                {
                                    Namestaj.Add(new Namestaj(tbNaziv.Text, tbSifra.Text, jedinicnaCena, kolicinaUMagacinu, ((TipNamestaja)cbTip.SelectedItem).Id));
                                }
                                else if (operacija == Operacija.IZMENA)
                                {
                                    Namestaj.Edit(tmp, tbNaziv.Text, tbSifra.Text, jedinicnaCena, kolicinaUMagacinu, ((TipNamestaja)cbTip.SelectedItem).Id);
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
