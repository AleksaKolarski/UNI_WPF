using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace POP_SF27_2016_Projekat.Model
{
    public class Korisnik : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private int tipKorisnikaId;
        private bool obrisan;
        public static ObservableCollection<Korisnik> korisnikCollection;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }
        public string Lozinka
        {
            get
            {
                return lozinka;
            }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        public int TipKorisnikaId
        {
            get
            {
                return tipKorisnikaId;
            }
            set
            {
                tipKorisnikaId = value;
                OnPropertyChanged("TipKorisnikaId");
                OnPropertyChanged("TipKorisnika");
            }
        }
        public TipKorisnika TipKorisnika
        {
            get
            {
                return TipKorisnika.GetById(tipKorisnikaId);
            }
            set
            {
                TipKorisnikaId = value.Id;
                OnPropertyChanged("TipKorisnika");
            }
        }
        public bool Obrisan
        {
            get
            {
                return obrisan;
            }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }
        
        public static Korisnik Trenutni { get; private set; } = null;
        #endregion

        #region Constructors
        public Korisnik()
        {
            this.Ime = "";
            this.Prezime = "";
            this.KorisnickoIme = "";
            this.Lozinka = "";
            this.TipKorisnikaId = -1;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            korisnikCollection = GetAll();
        }

        public static Korisnik GetById(int id)
        {
            foreach (Korisnik item in korisnikCollection)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Korisnik GetByUsername(string username)
        {
            foreach(Korisnik korisnik in korisnikCollection)
            {
                if(korisnik.KorisnickoIme == username)
                {
                    return korisnik;
                }
            }
            return null;
        }

        public static void Add(Korisnik korisnikToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if (korisnikToAdd == null)
            {
                return;
            }
            korisnikCollection.Add(korisnikToAdd);
        }

        public void Copy(Korisnik source)
        {
            this.Id = source.Id;
            this.Ime = String.Copy(source.Ime);
            this.Prezime = String.Copy(source.Prezime);
            this.KorisnickoIme = String.Copy(source.KorisnickoIme);
            this.Lozinka = String.Copy(source.Lozinka);
            this.TipKorisnika = source.TipKorisnika;
            this.Obrisan = source.Obrisan;
        }

        public static bool Login(string username, string password)
        {
            foreach (Korisnik korisnik in korisnikCollection)
            {
                if(korisnik.KorisnickoIme == username && korisnik.Lozinka == password && korisnik.Obrisan == false)
                {
                    Trenutni = korisnik;
                    return true;
                }
            }
            return false;
        }

        public static void Logout()
        {
            Trenutni = null;
        }

        public override string ToString()
        {
            return $"{Id}, {Ime}, {Prezime}, {KorisnickoIme}, {Lozinka}, {TipKorisnika.Naziv}";
        }
        #endregion

        #region DataBinding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region DAO
        public static ObservableCollection<Korisnik> GetAll()
        {
            ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>();

            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Korisnik;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Korisnik");

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    Korisnik k = new Korisnik()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        TipKorisnikaId = Convert.ToInt32(row["TipKorisnikaId"]),
                        Ime = row["Ime"].ToString(),
                        Prezime = row["Prezime"].ToString(),
                        KorisnickoIme = row["KorisnickoIme"].ToString(),
                        Lozinka = row["Lozinka"].ToString(),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    korisnici.Add(k);
                }
            }
            return korisnici;
        }

        public static Korisnik Create(Korisnik k)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Korisnik (TipKorisnikaId, Ime, Prezime, KorisnickoIme, Lozinka, Obrisan) VALUES (@TipKorisnikaId, @Ime, @Prezime, @KorisnickoIme, @Lozinka, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("TipKorisnikaId", k.TipKorisnikaId);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                k.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Korisnik.Add(k);

            return k;
        }

        public static void Update(Korisnik k)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Korisnik SET TipKorisnikaId=@TipKorisnikaId, Ime=@Ime, Prezime=@Prezime, KorisnickoIme=@KorisnickoIme, Lozinka=@Lozinka, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("TipKorisnikaId", k.TipKorisnikaId);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            Korisnik.GetById(k.Id).Copy(k);
        }

        public static void Delete(Korisnik k)
        {
            if (k.Id != Trenutni.Id)
            {
                k.Obrisan = true;
                Update(k);
            }
            else
            {
                MessageBox.Show("Ne mozete obrisati trenutno ulogovanog korisnika!", "Greska pri brisanju korisnika.");
            }
        }
        #endregion
    }
}
