using POP_SF27_2016_Projekat.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

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

        ICollectionView view;

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
                                if (operacija == Operacija.DODAVANJE)
                                {
                                    // proveravamo da li postoji vec korisnik sa istim korisnickim imenom
                                    if (Korisnik.GetByUsername(korisnik.KorisnickoIme) == null)
                                    {
                                        Korisnik.Create(korisnik);
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vec postoji korisnik sa istim korisnickim imenom!\nUnesite drugacije korisnicko ime.", "Greska!");
                                    }
                                }
                                else if(operacija == Operacija.IZMENA)
                                {
                                    // proveravamo da li postoji vec korisnik sa istim korisnickim imenom
                                    if (Korisnik.GetByUsername(korisnik.KorisnickoIme) == null)
                                    {
                                        Korisnik.Update(korisnik);
                                        Close();
                                    }
                                    // ako vec postoji korisnik sa tim korisnickim imenom onda proveravamo da li je to zapravo isti ovaj korisnik (moze da se desi pri editu) 
                                    // i tada prihvatamo promenu
                                    else if((Korisnik.GetByUsername(korisnik.KorisnickoIme)).Id == korisnik.Id)
                                    {
                                        Korisnik.Update(korisnik);
                                        Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Vec postoji korisnik sa istim korisnickim imenom!\nUnesite drugacije korisnicko ime.", "Greska!");
                                    }
                                }
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

            view = new CollectionViewSource { Source = TipKorisnika.tipKorisnikaCollection }.View;
            view.Filter = Filter;
            cbTip.ItemsSource = view;
        }

        #region Filters
        private bool Filter(object obj)
        {
            return !(((TipKorisnika)obj).Obrisan);
        }
        #endregion
    }
}