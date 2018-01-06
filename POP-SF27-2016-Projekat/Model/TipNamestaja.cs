using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POP_SF27_2016_Projekat.Model
{ 
    public class TipNamestaja : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private bool obrisan;
        public static ObservableCollection<TipNamestaja> tipNamestajaCollection;
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
        public TipNamestaja() { }
        public TipNamestaja(string naziv)
        {
            this.Id = -1;
            this.Naziv = naziv;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            tipNamestajaCollection = GetAll();
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (TipNamestaja tip in tipNamestajaCollection)
            {
                if (tip.Id == id)
                {
                    return tip;
                }
            }
            return null;
        }

        public static void Add(TipNamestaja tipNamestajaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(tipNamestajaToAdd == null)
            {
                return;
            }
            tipNamestajaCollection.Add(tipNamestajaToAdd);
        }

        public void Copy(TipNamestaja source)
        {
            this.Id = source.Id;
            this.Naziv = String.Copy(source.Naziv);
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
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            ObservableCollection<TipNamestaja> tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM TipNamestaja;";
                da.SelectCommand = cmd;
                da.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    TipNamestaja tn = new TipNamestaja()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };
                    tipoviNamestaja.Add(tn);
                }
            }
            return tipoviNamestaja;
        }

        public static TipNamestaja Create(TipNamestaja tn)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES (@Naziv, @Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString());
            }

            TipNamestaja.Add(tn);

            return tn;
        }

        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv, Obrisan=@Obrisan WHERE Id=@Id;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();
            }

            // Update model
            TipNamestaja.GetById(tn.Id).Copy(tn);
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            foreach (Namestaj namestaj in Namestaj.namestajCollection)
            {
                if (namestaj.TipNamestajaId == tn.Id)
                {
                    Namestaj.Delete(namestaj);
                }
            }
            Update(tn);
        }
        #endregion
    }
}
