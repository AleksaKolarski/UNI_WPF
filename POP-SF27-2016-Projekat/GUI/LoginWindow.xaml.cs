using POP_SF27_2016_Projekat.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System;


namespace POP_SF27_2016_Projekat.GUI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            /*
            ObservableCollection<UredjeniPar> obs1 = new ObservableCollection<UredjeniPar>();
            obs1.Add(new UredjeniPar(0, 20));
            obs1.Add(new UredjeniPar(1, 30));
            Akcija akcija1 = new Akcija(new DateTime(), new DateTime(), obs1);

            ObservableCollection<UredjeniPar> obs2 = new ObservableCollection<UredjeniPar>();
            obs2.Add(new UredjeniPar(1, 40));
            obs2.Add(new UredjeniPar(2, 50));
            Akcija akcija2 = new Akcija(new DateTime(), new DateTime(), obs2);

            ObservableCollection<Akcija> akcije = new ObservableCollection<Akcija>();
            akcije.Add(akcija1);
            akcije.Add(akcija2);

            Akcija.AkcijaCollectionProperty = akcije;
            */
            /*
            ObservableCollection<UredjeniParRacun> obs1 = new ObservableCollection<UredjeniParRacun>();
            obs1.Add(new UredjeniParRacun(0, 3));
            obs1.Add(new UredjeniParRacun(1, 1));
            ObservableCollection<int> obsD1 = new ObservableCollection<int>();

            ObservableCollection<UredjeniParRacun> obs2 = new ObservableCollection<UredjeniParRacun>();
            obs2.Add(new UredjeniParRacun(1, 3));
            obs2.Add(new UredjeniParRacun(2, 4));
            obs2.Add(new UredjeniParRacun(0, 1));
            ObservableCollection<int> obsD2 = new ObservableCollection<int>();
            obsD2.Add(1);
            obsD2.Add(0);

            ObservableCollection<ProdajaNamestaja> prodaja = new ObservableCollection<ProdajaNamestaja>();
            prodaja.Add(new ProdajaNamestaja(obs1, new DateTime(), "Neko Nekic", "123-123-123", obsD1));
            prodaja.Add(new ProdajaNamestaja(obs2, new DateTime(), "Pera Peric", "321-321-321", obsD2));

            ProdajaNamestaja.ProdajaNamestajaCollectionProperty = prodaja;
            */

            DodatnaUsluga.Init();
            TipKorisnika.Init();
            Korisnik.Init();
            TipNamestaja.Init();
            Namestaj.Init();
            Akcija.Init();
            ProdajaNamestaja.Init();
            Salon.Init();

            tbWelcome.Text = "Welcome to\n" + Salon.SalonProperty.Naziv;
            tbUsername.Focus();
            tbUsername.Text = "username1";
            pbPassword.Password = "password1";
            this.KeyDown += LoginEnterKeyDown; // Izvrsi metod na okidanje KeyDown eventa
        }

        /* Kada pritisnemo Enter na tastaturi simuliramo pritiskanje Login dugmeta */
        private void LoginEnterKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                btnLogin_Click(this, null);
            }
        }

        /* Na pritiskanje Login dugmeta */
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Korisnik.Login(tbUsername.Text, pbPassword.Password);
            if(Korisnik.Trenutni != null)
            {
                this.tbUsername.Text = "";
                this.pbPassword.Password = "";
                this.Hide(); // Sakrijemo Login prozor dok je glavni otvoren
                MainWindow mainProzor = new MainWindow();
                mainProzor.ShowDialog(); // Cekamo da se zatvori mainProzor
                Korisnik.Logout(); // Za svaki slucaj kad god se vratimo u ovaj prozor izlogovati korisnika
                this.Show(); // Prikazemo opet login prozor koji bi trebao da bude ociscen
                this.Activate(); // Nekad prozor ode u pozadinu
                this.Topmost = true;  // important
                this.Topmost = false; // important
                this.Focus(); // Nece vala
                tbUsername.Focus();
            }
        }
    }
}
