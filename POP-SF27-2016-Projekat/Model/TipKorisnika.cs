using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Resources;

namespace POP_SF27_2016_Projekat.Model
{
    public class TipKorisnika : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private Dozvole dozvole;
        private bool obrisan;
        public static ObservableCollection<TipKorisnika> tipKorisnikaCollection;
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
        public Dozvole Dozvole
        {
            get
            {
                return dozvole;
            }
            set
            {
                dozvole = value;
                OnPropertyChanged("Dozvole");
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
        public TipKorisnika()
        {
            this.Dozvole = new Dozvole();
        }
        public TipKorisnika(string naziv, Dozvole dozvole)
        {
            this.Id = -1;
            this.Naziv = naziv;
            this.Dozvole = dozvole;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            //tipKorisnikaCollection = TipKorisnikaCollectionProperty;
            tipKorisnikaCollection = GetAll();
        }

        public static TipKorisnika GetById(int id)
        {
            foreach (TipKorisnika item in tipKorisnikaCollection)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void Add(TipKorisnika tipKorisnikaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(tipKorisnikaToAdd == null)
            {
                return;
            }
            tipKorisnikaCollection.Add(tipKorisnikaToAdd);
        }

        public void Copy(TipKorisnika source)
        {
            this.Id = source.Id;
            this.Naziv = String.Copy(source.Naziv);
            this.Dozvole.Copy(source.Dozvole);
            this.Obrisan = source.Obrisan;
        }

        public override string ToString()
        {
            return $"{Naziv}";
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
        public static ObservableCollection<TipKorisnika> GetAll()
        {
            ObservableCollection<TipKorisnika> tipoviKorisnika = new ObservableCollection<TipKorisnika>();

            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM TipKorisnika;";
                da.SelectCommand = cmd;
                da.Fill(ds, "TipKorisnika");

                foreach (DataRow row in ds.Tables["TipKorisnika"].Rows)
                {
                    TipKorisnika tk = new TipKorisnika()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Dozvole = new Dozvole(),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    tk.Dozvole.Akcija = (Dozvola)Convert.ToByte(row["DozvolaAkcija"]);
                    tk.Dozvole.DodatnaUsluga = (Dozvola)Convert.ToByte(row["DozvolaDodatnaUsluga"]);
                    tk.Dozvole.Korisnik = (Dozvola)Convert.ToByte(row["DozvolaKorisnik"]);
                    tk.Dozvole.Namestaj = (Dozvola)Convert.ToByte(row["DozvolaNamestaj"]);
                    tk.Dozvole.ProdajaNamestaja = (Dozvola)Convert.ToByte(row["DozvolaProdajaNamestaja"]);
                    tk.Dozvole.Salon = (Dozvola)Convert.ToByte(row["DozvolaSalon"]);
                    tk.Dozvole.TipKorisnika = (Dozvola)Convert.ToByte(row["DozvolaTipKorisnika"]);
                    tk.Dozvole.TipNamestaja = (Dozvola)Convert.ToByte(row["DozvolaTipNamestaja"]);
                    tipoviKorisnika.Add(tk);
                }
            }
            return tipoviKorisnika;
        }

        public static TipKorisnika Create(TipKorisnika tk)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO TipKorisnika (Naziv, DozvolaAkcija, DozvolaDodatnaUsluga, DozvolaKorisnik, DozvolaNamestaj, DozvolaProdajaNamestaja, DozvolaSalon, DozvolaTipKorisnika, DozvolaTipNamestaja, Obrisan) VALUES (@Naziv, @DozvolaAkcija, @DozvolaDodatnaUsluga, @DozvolaKorisnik, @DozvolaNamestaj, @DozvolaProdajaNamestaja, @DozvolaSalon, @DozvolaTipKorisnika, @DozvolaTipNamestaja, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", tk.Naziv);
                cmd.Parameters.AddWithValue("DozvolaAkcija", tk.Dozvole.Akcija);
                cmd.Parameters.AddWithValue("DozvolaDodatnaUsluga", tk.Dozvole.DodatnaUsluga);
                cmd.Parameters.AddWithValue("DozvolaKorisnik", tk.Dozvole.Korisnik);
                cmd.Parameters.AddWithValue("DozvolaNamestaj", tk.Dozvole.Namestaj);
                cmd.Parameters.AddWithValue("DozvolaProdajaNamestaja", tk.Dozvole.ProdajaNamestaja);
                cmd.Parameters.AddWithValue("DozvolaSalon", tk.Dozvole.Salon);
                cmd.Parameters.AddWithValue("DozvolaTipKorisnika", tk.Dozvole.TipKorisnika);
                cmd.Parameters.AddWithValue("DozvolaTipNamestaja", tk.Dozvole.TipNamestaja);
                cmd.Parameters.AddWithValue("Obrisan", tk.Obrisan);

                tk.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            TipKorisnika.Add(tk);

            return tk;
        }

        public static void Update(TipKorisnika tk)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE TipKorisnika SET Naziv=@Naziv, DozvolaAkcija=@DozvolaAkcija, DozvolaDodatnaUsluga=@DozvolaDodatnaUsluga, DozvolaKorisnik=@DozvolaKorisnik, DozvolaNamestaj=@DozvolaNamestaj, DozvolaProdajaNamestaja=@DozvolaProdajaNamestaja, DozvolaSalon=@DozvolaSalon, DozvolaTipKorisnika=@DozvolaTipKorisnika, DozvolaTipNamestaja=@DozvolaTipNamestaja, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", tk.Id);
                cmd.Parameters.AddWithValue("Naziv", tk.Naziv);
                cmd.Parameters.AddWithValue("DozvolaAkcija", tk.Dozvole.Akcija);
                cmd.Parameters.AddWithValue("DozvolaDodatnaUsluga", tk.Dozvole.DodatnaUsluga);
                cmd.Parameters.AddWithValue("DozvolaKorisnik", tk.Dozvole.Korisnik);
                cmd.Parameters.AddWithValue("DozvolaNamestaj", tk.Dozvole.Namestaj);
                cmd.Parameters.AddWithValue("DozvolaProdajaNamestaja", tk.Dozvole.ProdajaNamestaja);
                cmd.Parameters.AddWithValue("DozvolaSalon", tk.Dozvole.Salon);
                cmd.Parameters.AddWithValue("DozvolaTipKorisnika", tk.Dozvole.TipKorisnika);
                cmd.Parameters.AddWithValue("DozvolaTipNamestaja", tk.Dozvole.TipNamestaja);
                cmd.Parameters.AddWithValue("Obrisan", tk.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            TipKorisnika.GetById(tk.Id).Copy(tk);
        }

        public static void Delete(TipKorisnika tk)
        {
            tk.Obrisan = true;
            Update(tk);
        }
        #endregion
    }
}
