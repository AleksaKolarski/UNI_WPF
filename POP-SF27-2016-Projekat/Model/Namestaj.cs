using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        private TipNamestaja tipNamestaja;
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
        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                return TipNamestaja.GetById(TipNamestajaId);
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
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

        public static ObservableCollection<Namestaj> NamestajCollectionProperty
        {
            get => DeSerializeObservableCollection<Namestaj>("namestaj.xml");
            set => SerializeObservableCollection<Namestaj>("namestaj.xml", value);
        }
        #endregion

        #region Constructors
        public Namestaj() { }
        public Namestaj(string naziv, string sifra, double jedinicnaCena, int kolicinaUMagacinu, TipNamestaja tipNamestaja)
        {
            this.Id = namestajCollection.Count;
            this.Naziv = naziv;
            this.Sifra = sifra;
            this.JedinicnaCena = jedinicnaCena;
            this.KolicinaUMagacinu = kolicinaUMagacinu;
            this.TipNamestajaId = tipNamestaja.Id;
            this.TipNamestaja = tipNamestaja;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            namestajCollection = NamestajCollectionProperty;
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
            //List<Namestaj> tempList = NamestajList;
            if(namestajToAdd == null)
            {
                return;
            }
            namestajCollection.Add(namestajToAdd);
            //NamestajList = tempList;
        }

        public static void Edit(Namestaj namestajToEdit, string naziv, string sifra, double jedinicnaCena, int kolicinaUMagacinu, TipNamestaja tipNamestaja)
        {
            if (namestajToEdit == null)
            {
                return;
            }
            namestajToEdit.Naziv = naziv;
            namestajToEdit.Sifra = sifra;
            namestajToEdit.JedinicnaCena = jedinicnaCena;
            namestajToEdit.KolicinaUMagacinu = kolicinaUMagacinu;
            namestajToEdit.TipNamestajaId = tipNamestaja.Id;
            namestajToEdit.TipNamestaja = tipNamestaja;
        }

        public static void Remove(Namestaj namestajToRemove)
        {
            if(namestajToRemove == null)
            {
                return;
            }
            namestajToRemove.Obrisan = true;
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
    }
}
