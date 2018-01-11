using POP_SF27_2016_Projekat.Model;
using System.Windows;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            /* Ucitavanje iz baze */
            DodatnaUsluga.Init();
            TipKorisnika.Init();
            Korisnik.Init();
            TipNamestaja.Init();
            Namestaj.Init();
            Akcija.Init();
            ProdajaNamestaja.Init();
            Salon.Init();

            tbWelcome.Text = "Welcome to\n" + Salon.salon.Naziv;
            tbUsername.Focus();
            //tbUsername.Text = "username1";
            //pbPassword.Password = "password1";
            this.KeyDown += LoginEnterKeyDown; // Izvrsi metodu na okidanje KeyDown eventa
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
                Korisnik.Logout(); // Kad god se vratimo u ovaj prozor izlogovati korisnika
                this.Show(); // Prikazemo opet login prozor koji bi trebao da bude ociscen

                /* Nekad prozor ostane u pozadini, ovo mozda pomogne da se prikaze na vrhu, a mozda i ne pomogne */
                this.Activate();
                this.Topmost = true;
                this.Topmost = false;
                this.Focus();

                tbUsername.Focus();
            }
            else
            {
                MessageBox.Show("Uneli ste pogresne kredencijale. Pokusajte ponovo.", "Greska pri loginu.");
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutProzor = new AboutWindow();
            aboutProzor.ShowDialog();
        }
    }
}
