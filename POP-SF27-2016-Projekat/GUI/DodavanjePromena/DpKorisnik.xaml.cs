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

        Korisnik korisnikCopy;
        Korisnik korisnikReal;

        public DpKorisnik()
        {
            InitializeComponent();
            tblock.Text = "Nov korisnik:";
            operacija = Operacija.DODAVANJE;

            korisnikCopy = new Korisnik("","","","",new TipKorisnika());

            tbIme.DataContext = korisnikCopy;
            tbPrezime.DataContext = korisnikCopy;
            tbKorisnickoIme.DataContext = korisnikCopy;
            tbLozinka.DataContext = korisnikCopy;
            cbTip.DataContext = korisnikCopy;
        }

        public DpKorisnik(Korisnik korisnik)
        {
            InitializeComponent();
            tblock.Text = "Izmena korisnika:";
            operacija = Operacija.IZMENA;

            korisnikCopy = new Korisnik();
            korisnikCopy.Copy(korisnik);
            korisnikReal = korisnik;

            tbIme.DataContext = korisnikCopy;
            tbPrezime.DataContext = korisnikCopy;
            tbKorisnickoIme.DataContext = korisnikCopy;
            tbLozinka.DataContext = korisnikCopy;
            cbTip.DataContext = korisnikCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (korisnikCopy.Ime != "")
            {
                if(korisnikCopy.Prezime != "")
                {
                    if(korisnikCopy.KorisnickoIme != "")
                    {
                        if(korisnikCopy.Lozinka != "")
                        {
                            if(korisnikCopy.TipKorisnika != null)
                            {
                                if(operacija == Operacija.DODAVANJE)
                                {
                                    Korisnik.Add(korisnikCopy);
                                }
                                else if(operacija == Operacija.IZMENA)
                                {
                                    korisnikReal.Copy(korisnikCopy);
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