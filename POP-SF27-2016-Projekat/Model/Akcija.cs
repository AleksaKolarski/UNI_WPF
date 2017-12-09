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
    public class Akcija : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private DateTime? datumPocetka;
        private DateTime? datumKraja;
        [XmlIgnore]
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

        public static ObservableCollection<Akcija> AkcijaCollectionProperty
        {
            get => DeSerializeObservableCollection<Akcija>("akcija.xml");
            set => SerializeObservableCollection<Akcija>("akcija.xml", value);
        }
        #endregion

        #region Constructors
        public Akcija()
        {
            this.Lista = new ObservableCollection<UredjeniPar>();
        }
        public Akcija(string naziv, DateTime? datumPocetka, DateTime? datumKraja, ObservableCollection<UredjeniPar> lista)
        {
            this.Id = akcijaCollection.Count;
            this.Naziv = naziv;
            this.DatumPocetka = datumPocetka;
            this.DatumKraja = datumKraja;
            this.Lista = lista;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            akcijaCollection = AkcijaCollectionProperty;
        }

        public static Akcija GetById(int id)
        {
            if (id >= 0)
            {
                foreach (Akcija akcija in akcijaCollection)
                {
                    if (akcija.Id == id)
                    {
                        return akcija;
                    }
                }
            }
            return null;
        }

        public static void Add(Akcija akcijaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            //ObservableCollection<Akcija> tempList = AkcijaCollection;
            if(akcijaCollection == null)
            {
                return;
            }
            akcijaCollection.Add(akcijaToAdd);
            //AkcijaCollection = tempList;
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
    }


    public class UredjeniPar : INotifyPropertyChanged
    {
        #region Fields
        private int namestajId;
        private Namestaj namestaj;
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
        [XmlIgnore]
        public Namestaj Namestaj
        {
            get
            {
                return Namestaj.GetById(NamestajId);
            }
            set
            {
                namestaj = value;
                namestajId = namestaj.Id;
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
            this.NamestajId = namestaj.Id;
            this.Namestaj = namestaj;
            this.Popust = popust;
        }
        #endregion

        #region Methods
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
