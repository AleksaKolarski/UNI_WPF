using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace POP_SF27_2016_Projekat.Model
{
    public class Namestaj : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private string sifra; // prva dva slova naziva, id, prva dva slova naziva tipa
        private double jedinicnaCena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;
        private bool obrisan;
        public static ObservableCollection<Namestaj> namestajCollection;
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
        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public string Sifra
        {
            get
            {
                return sifra;
            }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }
        public double JedinicnaCena
        {
            get
            {
                return jedinicnaCena;
            }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }
        public int KolicinaUMagacinu
        {
            get
            {
                return kolicinaUMagacinu;
            }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
            }
        }
        public int TipNamestajaId
        {
            get
            {
                return tipNamestajaId;
            }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
            }
        }
        public TipNamestaja TipNamestaja
        {
            get
            {
                return TipNamestaja.GetById(TipNamestajaId);
            }
            set
            {
                TipNamestajaId = value.Id;
                OnPropertyChanged("TipNamestaja");
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
        #endregion

        #region Constructors
        public Namestaj()
        {
            this.Naziv = "";
            this.Sifra = "";
            this.JedinicnaCena = 0;
            this.KolicinaUMagacinu = 0;
            this.TipNamestajaId = -1;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            namestajCollection = GetAll();
        }

        public static Namestaj GetById(int id)
        {
            foreach (Namestaj item in namestajCollection)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void Add(Namestaj namestajToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(namestajToAdd == null)
            {
                return;
            }
            namestajCollection.Add(namestajToAdd);
        }

        public void Copy(Namestaj source)
        {
            this.Id = source.Id;
            this.Naziv = String.Copy(source.Naziv);
            this.Sifra = String.Copy(source.Sifra);
            this.JedinicnaCena = source.JedinicnaCena;
            this.KolicinaUMagacinu = source.KolicinaUMagacinu;
            this.TipNamestaja = source.TipNamestaja;
            this.Obrisan = source.Obrisan;
        }

        public override string ToString()
        {
            return $"{Id}, {Naziv}, {Sifra}, {JedinicnaCena}, {KolicinaUMagacinu}, {TipNamestaja.Naziv}";
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
        public static ObservableCollection<Namestaj> GetAll()
        {
            ObservableCollection<Namestaj> namestaj = new ObservableCollection<Namestaj>();

            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Namestaj;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    Namestaj n = new Namestaj()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Sifra = row["Sifra"].ToString(),
                        JedinicnaCena = Convert.ToDouble(row["JedinicnaCena"]),
                        KolicinaUMagacinu = Convert.ToInt32(row["KolicinaUMagacinu"]),
                        TipNamestajaId = Convert.ToInt32(row["TipNamestajaId"]), 
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    namestaj.Add(n);
                }
            }
            return namestaj;
        }

        public static Namestaj Create(Namestaj n)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, JedinicnaCena, KolicinaUMagacinu, Obrisan) VALUES (@TipNamestajaId, @Naziv, @Sifra, @JedinicnaCena, @KolicinaUMagacinu, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("JedinicnaCena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("KolicinaUMagacinu", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Namestaj.Add(n);

            return n;
        }

        public static void Update(Namestaj n)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId=@TipNamestajaId, Naziv=@Naziv, Sifra=@Sifra, JedinicnaCena=@JedinicnaCena, KolicinaUMagacinu=@KolicinaUMagacinu, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("JedinicnaCena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("KolicinaUMagacinu", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            Namestaj.GetById(n.Id).Copy(n);
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion
    }
}
