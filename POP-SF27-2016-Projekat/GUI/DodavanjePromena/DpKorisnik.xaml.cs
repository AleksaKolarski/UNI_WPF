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

        Korisnik korisnik;

        public DpKorisnik()
        {
            InitializeComponent();
            tblock.Text = "Nov korisnik:";
            operacija = Operacija.DODAVANJE;

            korisnik = new Korisnik();

            InitFields();
        }

        public DpKorisnik(Korisnik korisnikParam)
        {
            InitializeComponent();
            tblock.Text = "Izmena korisnika:";
            operacija = Operacija.IZMENA;

            korisnik = new Korisnik();
            korisnik.Copy(korisnikParam);

            InitFields();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (korisnik.Ime != "")
            {
                if(korisnik.Prezime != "")
                {
                    if(korisnik.KorisnickoIme != "")
                    {
                        if(korisnik.Lozinka != "")
                        {
                            if(korisnik.TipKorisnika != null)
                            {
                                if(operacija == Operacija.DODAVANJE)
                                {
                                    Korisnik.Create(korisnik);
                                }
                                else if(operacija == Operacija.IZMENA)
                                {
                                    Korisnik.Update(korisnik);
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

        private void InitFields()
        {
            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            cbTip.DataContext = korisnik;
        }
    }
}