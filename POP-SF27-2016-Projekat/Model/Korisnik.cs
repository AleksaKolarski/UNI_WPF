using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

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
        private TipKorisnika tipKorisnika;
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
            }
        }
        [XmlIgnore]
        public TipKorisnika TipKorisnika
        {
            get
            {
                return TipKorisnika.GetById(tipKorisnikaId);
            }
            set
            {
                tipKorisnika = value;
                TipKorisnikaId = tipKorisnika.Id;
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

        public static ObservableCollection<Korisnik> KorisnikCollectionProperty
        {
            get => DeSerializeObservableCollection<Korisnik>("korisnik.xml");
            set => SerializeObservableCollection<Korisnik>("korisnik.xml", value);
        }
        
        public static Korisnik Trenutni { get; private set; } = null;
        #endregion

        #region Constructors
        public Korisnik() { }
        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka, TipKorisnika tipKorisnika)
        {
            this.Id = korisnikCollection.Count;
            this.Ime = ime;
            this.Prezime = prezime;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.TipKorisnikaId = tipKorisnika.Id;
            this.TipKorisnika = tipKorisnika;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            korisnikCollection = KorisnikCollectionProperty;
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

        public static void Add(Korisnik korisnikToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if (korisnikToAdd == null)
            {
                return;
            }
            //List<Korisnik> tempList = KorisnikList;
            korisnikCollection.Add(korisnikToAdd);
            //KorisnikList = tempList;
        }

        public static void Edit(Korisnik korisnikToEdit, string ime, string prezime, string korisnickoIme, string lozinka, TipKorisnika tipKorisnika)
        {
            if (korisnikToEdit == null)
            {
                return;
            }
            korisnikToEdit.Ime = ime;
            korisnikToEdit.Prezime = prezime;
            korisnikToEdit.KorisnickoIme = korisnickoIme;
            korisnikToEdit.Lozinka = lozinka;
            korisnikToEdit.TipKorisnikaId = tipKorisnika.Id;
            korisnikToEdit.TipKorisnika = tipKorisnika;
        }

        public static void Remove(Korisnik korisnikToRemove)
        {
            if(korisnikToRemove == null)
            {
                return;
            }
            korisnikToRemove.Obrisan = true;
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
    }
}
