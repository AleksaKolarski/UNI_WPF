using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace POP_SF27_2016_Projekat.Model
{
    public class Akcija : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private DateTime? datumPocetka;
        private DateTime? datumKraja;
        public ObservableCollection<UredjeniPar> lista;
        private bool obrisan;
        public static ObservableCollection<Akcija> akcijaCollection;
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
        public DateTime? DatumPocetka
        {
            get
            {
                return datumPocetka;
            }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }
        public DateTime? DatumKraja
        {
            get
            {
                return datumKraja;
            }
            set
            {
                datumKraja = value;
                OnPropertyChanged("DatumKraja");
            }
        }
        public ObservableCollection<UredjeniPar> Lista
        {
            get
            {
                return lista;
            }
            set
            {
                lista = value;
                OnPropertyChanged("Lista");
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
        public Akcija()
        {
            this.Naziv = "";
            this.datumPocetka = DateTime.Now;
            this.DatumKraja = DateTime.Now.AddDays(1);
            this.Lista = new ObservableCollection<UredjeniPar>();
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            akcijaCollection = GetAll();
        }

        public static Akcija GetById(int id)
        {
            foreach (Akcija akcija in akcijaCollection)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        public static Akcija GetByNamestaj(Namestaj namestaj)
        {
            foreach(Akcija akcija in akcijaCollection)
            {
                if (akcija.Obrisan == false)
                {
                    foreach (UredjeniPar uredjeniPar in akcija.Lista)
                    {
                        if (uredjeniPar.Namestaj.Id == namestaj.Id)
                        {
                            return akcija;
                        }
                    }
                }
            }
            return null;
        }
        
        public static double GetPopustByNamestaj(Namestaj namestaj)
        {
            foreach (Akcija akcija in akcijaCollection)
            {
                if (akcija.Obrisan == false)
                {
                    foreach (UredjeniPar uredjeniPar in akcija.Lista)
                    {
                        if (uredjeniPar.Namestaj.Id == namestaj.Id)
                        {
                            return uredjeniPar.Popust;
                        }
                    }
                }
            }
            return 0;
        }

        public static void Add(Akcija akcijaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(akcijaCollection == null)
            {
                return;
            }
            akcijaCollection.Add(akcijaToAdd);
        }

        public static void Edit(Akcija akcijaToEdit, string naziv, DateTime? datumPocetka, DateTime? datumKraja, ObservableCollection<UredjeniPar> lista)
        {
            if (akcijaToEdit == null)
            {
                return;
            }
            akcijaToEdit.Naziv = naziv;
            akcijaToEdit.DatumPocetka = datumPocetka;
            akcijaToEdit.DatumKraja = datumKraja;
            akcijaToEdit.Lista = lista;
        }

        public static void Remove(Akcija akcijaToRemove)
        {
            if(akcijaToRemove == null)
            {
                return;
            }
            akcijaToRemove.Obrisan = true;
        }

        public void Copy(Akcija source)
        {
            this.Id = source.Id;
            this.Naziv = String.Copy(source.Naziv);
            this.DatumPocetka = source.DatumPocetka;
            this.DatumKraja = source.DatumKraja;
            this.Lista = new ObservableCollection<UredjeniPar>();
            foreach(UredjeniPar par in source.Lista)
            {
                UredjeniPar tmp = new UredjeniPar();
                tmp.Copy(par);
                this.Lista.Add(tmp);
            }
            this.Obrisan = source.Obrisan;
        }

        public override string ToString()
        {
            return $"{Id}, {DatumPocetka}, {DatumKraja}";
        }
        #endregion

        #region Data binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region DAO
        public static ObservableCollection<Akcija> GetAll()
        {
            ObservableCollection<Akcija> akcije = new ObservableCollection<Akcija>();

            using (SqlConnection con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM Akcija;";
                da.SelectCommand = cmd;
                da.Fill(ds, "Akcija");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    Akcija akcija = new Akcija()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Naziv = row["Naziv"].ToString(),
                        DatumPocetka = Convert.ToDateTime(row["DatumPocetka"].ToString()),
                        DatumKraja = Convert.ToDateTime(row["DatumKraja"].ToString()),
                        Obrisan = bool.Parse(row["Obrisan"].ToString())
                    };

                    SqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandText = "SELECT * FROM NaAkciji WHERE IdAkcije=" + akcija.Id +";";
                    da.SelectCommand = cmd2;
                    da.Fill(ds, "NaAkciji");

                    foreach (DataRow row2 in ds.Tables["NaAkciji"].Rows)
                    {
                        UredjeniPar par = new UredjeniPar()
                        {
                            NamestajId = Convert.ToInt32(row2["IdNamestaja"]),
                            Popust = Convert.ToDouble(row2["Popust"])
                        };
                        akcija.lista.Add(par);
                    }
                    ds.Tables["NaAkciji"].Clear();

                    akcije.Add(akcija);
                }
            }
            return akcije;
        }
        
        public static void Create(Akcija akcijaParam)
        {
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "INSERT INTO Akcija (Naziv, DatumPocetka, DatumKraja, Obrisan) VALUES (@Naziv, @DatumPocetka, @DatumKraja, 0);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", akcijaParam.Naziv);
                cmd.Parameters.AddWithValue("DatumPocetka", akcijaParam.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumKraja", akcijaParam.DatumKraja);

                akcijaParam.Id = int.Parse(cmd.ExecuteScalar().ToString());

                foreach(UredjeniPar par in akcijaParam.lista)
                {
                    cmd.CommandText = "INSERT INTO NaAkciji (IdAkcije, IdNamestaja, Popust) VALUES (" + akcijaParam.Id + ", " + par.NamestajId + ", " + par.Popust + ");";
                    cmd.ExecuteNonQuery();
                }
            }

            Akcija akcijaNew = new Akcija();
            akcijaNew.Copy(akcijaParam);
            akcijaNew.Obrisan = false;

            Akcija.Add(akcijaNew);
        }
        
        public static void Update(Akcija akcija)
        {
            Delete(akcija);
            Create(akcija);
        }
        
        public static void Delete(Akcija akcija)
        {
            Akcija.GetById(akcija.Id).Obrisan = true;
            using (var con = new SqlConnection(Properties.Resources.connectionString))
            {
                con.Open();

                SqlCommand cmd = con.CreateCommand();

                cmd.CommandText = "UPDATE Akcija SET Obrisan=1 WHERE Id=" + akcija.Id + ";";

                cmd.ExecuteNonQuery();
            }
        }
        #endregion
    }


    public class UredjeniPar : INotifyPropertyChanged
    {
        #region Fields
        private int namestajId;
        private double popust;
        #endregion

        #region Property
        public int NamestajId
        {
            get
            {
                return namestajId;
            }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }
        
        public Namestaj Namestaj
        {
            get
            {
                return Namestaj.GetById(NamestajId);
            }
            set
            {
                NamestajId = value.Id;
                OnPropertyChanged("Namestaj");
            }
        }
        public double Popust
        {
            get
            {
                return popust;
            }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }
        #endregion

        #region Constructors
        public UredjeniPar(){}
        public UredjeniPar(Namestaj namestaj, double popust)
        {
            this.Namestaj = namestaj;
            this.Popust = popust;
        }
        #endregion

        #region Methods
        public void Copy(UredjeniPar source)
        {
            this.Namestaj = source.Namestaj;
            this.Popust = source.Popust;
        }

        public override string ToString()
        {
            return $"{NamestajId}, {Popust}";
        }
        #endregion

        #region Data binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
