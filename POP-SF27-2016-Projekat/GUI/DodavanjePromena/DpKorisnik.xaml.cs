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
    public partial class DpKorisnik : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        private Operacija operacija;

        public DpKorisnik()
        {
            InitializeComponent();
            tblock.Text = "Nov korisnik:";
            operacija = Operacija.DODAVANJE;
        }

        Korisnik tmp;
        public DpKorisnik(Korisnik korisnik)
        {
            InitializeComponent();
            if (korisnik == null)
            {
                Close();
            }
            tmp = korisnik;
            tblock.Text = "Izmena korisnika:";
            tbIme.Text = tmp.Ime;
            tbPrezime.Text = tmp.Prezime;
            tbKorisnickoIme.Text = tmp.KorisnickoIme;
            tbLozinka.Text = tmp.Lozinka;
            cbTip.SelectedItem = tmp.TipKorisnika;

            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbIme.Text != "")
            {
                if(tbPrezime.Text != "")
                {
                    if(tbKorisnickoIme.Text != "")
                    {
                        if(tbLozinka.Text != "")
                        {
                            if(cbTip.SelectedItem != null)
                            {
                                if(operacija == Operacija.DODAVANJE)
                                {
                                    Korisnik.Add(new Korisnik(tbIme.Text, tbPrezime.Text, tbKorisnickoIme.Text, tbLozinka.Text, (TipKorisnika)cbTip.SelectedItem));
                                }
                                else if(operacija == Operacija.IZMENA)
                                {
                                    Korisnik.Edit(tmp, tbIme.Text, tbPrezime.Text, tbKorisnickoIme.Text, tbLozinka.Text, (TipKorisnika)cbTip.SelectedItem);
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
                            tbLozinka.Focus();
                        }
                    }
                    else
                    {
                        tbKorisnickoIme.Focus();
                    }
                }
                else
                {
                    tbPrezime.Focus();
                }
            }
            else
            {
                tbIme.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}