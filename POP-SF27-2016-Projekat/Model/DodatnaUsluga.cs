using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace POP_SF27_2016_Projekat.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private double cena;
        private bool obrisan;
        public static ObservableCollection<DodatnaUsluga> dodatnaUslugaCollection;
        #endregion

        #region Properties
        public int Id {
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
        public string Naziv {
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
        public double Cena {
            get
            {
                return cena;
            }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
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
        public DodatnaUsluga() { }
        public DodatnaUsluga(string naziv, double cena)
        {
            this.Id = -1;
            this.Naziv = naziv;
            this.Cena = cena;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            dodatnaUslugaCollection = GetAll();
        }

        public static DodatnaUsluga GetById(int id)
        {
            foreach (DodatnaUsluga dodatnaUsluga in dodatnaUslugaCollection)
            {
                if (dodatnaUsluga.Id == id)
                {
                    return dodatnaUsluga;
                }
            }
            return null;
        }

        public static void Add(DodatnaUsluga dodatnaUslugaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(dodatnaUslugaToAdd == null)
            {
                return;
            }
            dodatnaUslugaCollection.Add(dodatnaUslugaToAdd);
        }

        public void Copy(DodatnaUsluga source)
        {
            this.Id = source.Id;
            this.Naziv = String.Copy(source.Naziv);
            this.Cena = source.Cena;
            this.Obrisan = source.Obrisan;
        }

        public override string ToString()
        {
            return $"{Id}, {Naziv}, {Cena}";
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
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            ObservableCollection<DodatnaUsluga> dodatneUsluge = new ObservableCollection<DodatnaUsluga>();

            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM DodatnaUsluga;";
                da.SelectCommand = cmd;
                da.Fill(ds, "DodatnaUsluga");

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    DodatnaUsluga du = new DodatnaUsluga()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Cena = Convert.ToDouble(row["Cena"]),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    dodatneUsluge.Add(du);
                }
            }
            return dodatneUsluge;
        }

        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO DodatnaUsluga (Naziv, Cena, Obrisan) VALUES (@Naziv, @Cena, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                du.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            DodatnaUsluga.Add(du);

            return du;
        }

        public static void Update(DodatnaUsluga du)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE DodatnaUsluga SET Naziv=@Naziv, Cena=@Cena, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", du.Id);
                cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                cmd.Parameters.AddWithValue("Cena", du.Cena);
                cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            DodatnaUsluga.GetById(du.Id).Copy(du);
        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }
        #endregion
    }
}
