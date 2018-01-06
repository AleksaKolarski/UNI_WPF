using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    public class Salon : INotifyPropertyChanged
    {
        #region Fields
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string adresaSajta;
        private int pib;
        private int maticniBroj;
        private string ziroRacun;
        public static Salon salon;
        #endregion

        #region Properties
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
        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string AdresaSajta
        {
            get
            {
                return adresaSajta;
            }
            set
            {
                adresaSajta = value;
                OnPropertyChanged("AdresaSajta");
            }
        }
        public int PIB
        {
            get
            {
                return pib;
            }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }
        public int MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }
        public string ZiroRacun
        {
            get
            {
                return ziroRacun;
            }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
            }
        }
        #endregion

        #region Constructors
        public Salon() { }
        public Salon(string naziv, string adresa, string telefon, string email, string adresaSajta, int pIB, int maticniBroj, string ziroRacun)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Telefon = telefon;
            this.Email = email;
            this.AdresaSajta = adresaSajta;
            this.PIB = pIB;
            this.MaticniBroj = maticniBroj;
            this.ZiroRacun = ziroRacun;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            salon = Get();
        }

        public void Copy(Salon source)
        {
            this.Naziv = source.Naziv;
            this.Adresa = source.Adresa;
            this.Telefon = source.Telefon;
            this.Email = source.Email;
            this.AdresaSajta = source.AdresaSajta;
            this.PIB = source.PIB;
            this.MaticniBroj = source.MaticniBroj;
            this.ZiroRacun = source.ZiroRacun;
        }

        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Telefon}, {Email}, {AdresaSajta}, {PIB}, {MaticniBroj}, {ZiroRacun}";
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
        public static Salon Get()
        {
 
            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Salon;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Salon");

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    return new Salon()
                    {
                        Naziv = row["Naziv"].ToString(),
                        Adresa = row["Adresa"].ToString(),
                        Telefon = row["Telefon"].ToString(),
                        Email = row["Email"].ToString(),
                        AdresaSajta = row["AdresaSajta"].ToString(),
                        PIB = Convert.ToInt32(row["PIB"]),
                        MaticniBroj = Convert.ToInt32(row["MaticniBroj"]),
                        ZiroRacun = row["ZiroRacun"].ToString()
                    };
                }
            }
            return null;
        }

        public static void Update(Salon salonTmp)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Salon SET Naziv=@Naziv, Adresa=@Adresa, Telefon=@Telefon, Email=@Email, AdresaSajta=@AdresaSajta, PIB=@PIB, MaticniBroj=@MaticniBroj, ZiroRacun=@ZiroRacun WHERE Id=0;";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Naziv", salonTmp.Naziv);
                cmd.Parameters.AddWithValue("Adresa", salonTmp.Adresa);
                cmd.Parameters.AddWithValue("Telefon", salonTmp.Telefon);
                cmd.Parameters.AddWithValue("Email", salonTmp.Email);
                cmd.Parameters.AddWithValue("AdresaSajta", salonTmp.AdresaSajta);
                cmd.Parameters.AddWithValue("PIB", salonTmp.PIB);
                cmd.Parameters.AddWithValue("MaticniBroj", salonTmp.MaticniBroj);
                cmd.Parameters.AddWithValue("ZiroRacun", salonTmp.ZiroRacun);

                cmd.ExecuteNonQuery();
            }

            // Update model
            Salon.salon.Copy(salonTmp);
        }
        #endregion
    }
}
