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
    public class ProdajaNamestaja : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        [XmlIgnore]
        public ObservableCollection<UredjeniParRacun> listUredjeniPar;
        private DateTime? datumProdaje;
        private string kupac;
        private string brojRacuna;
        [XmlIgnore]
        public ObservableCollection<int> listDodatnaUslugaId;
        [XmlIgnore]
        public double pdv = 20.0;
        public static ObservableCollection<ProdajaNamestaja> prodajaNamestajaCollection;
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
        public ObservableCollection<UredjeniParRacun> ListUredjeniPar
        {
            get
            {
                return listUredjeniPar;
            }
            set
            {
                listUredjeniPar = value;
                OnPropertyChanged("ListUredjeniPar");
            }
        }
        public DateTime? DatumProdaje
        {
            get
            {
                return datumProdaje;
            }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }
        public string Kupac
        {
            get
            {
                return kupac;
            }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }
        public string BrojRacuna
        {
            get
            {
                return brojRacuna;
            }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }
        public ObservableCollection<int> ListDodatnaUslugaId
        {
            get
            {
                return listDodatnaUslugaId;
            }
            set
            {
                listDodatnaUslugaId = value;
                OnPropertyChanged("ListDodatnaUslugaId");
            }
        }
        [XmlIgnore]
        public ObservableCollection<DodatnaUsluga> ListDodatnaUsluga
        {
            get
            {
                ObservableCollection<DodatnaUsluga> collection = new ObservableCollection<DodatnaUsluga>();
                foreach(int id in listDodatnaUslugaId)
                {
                    collection.Add(DodatnaUsluga.GetById(id));
                }
                return collection;
            }
        }
        [XmlIgnore]
        public double PDV
        {
            get
            {
                return pdv;
            }
            set
            {
                pdv = value;
                OnPropertyChanged("PDV");
            }
        }
        [XmlIgnore]
        public double UkupnaCena
        {
            get
            {
                double cena = 0;
                foreach(DodatnaUsluga dodatnaUsluga in ListDodatnaUsluga)
                {
                    cena += dodatnaUsluga.Cena;
                }
                foreach(UredjeniParRacun uredjeniPar in ListUredjeniPar)
                {
                    cena += uredjeniPar.UkupnaCena;
                }
                return cena * (100 + PDV)/100;
            }
        }

        public static ObservableCollection<ProdajaNamestaja> ProdajaNamestajaCollectionProperty
        {
            get => DeSerializeObservableCollection<ProdajaNamestaja>("prodaja.xml");
            set => SerializeObservableCollection<ProdajaNamestaja>("prodaja.xml", value);
        }
        #endregion

        #region Constructors
        public ProdajaNamestaja()
        {
            ListUredjeniPar = new ObservableCollection<UredjeniParRacun>();
            listDodatnaUslugaId = new ObservableCollection<int>();
        }
        public ProdajaNamestaja(ObservableCollection<UredjeniParRacun> listUredjeniPar, DateTime? datumProdaje, string kupac, string brojRacuna, ObservableCollection<int> listDodatnaUslugaId)
        {
            this.Id = prodajaNamestajaCollection.Count;
            this.ListUredjeniPar = listUredjeniPar;
            this.DatumProdaje = datumProdaje;
            this.Kupac = kupac;
            this.BrojRacuna = brojRacuna;
            this.ListDodatnaUslugaId = listDodatnaUslugaId;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            prodajaNamestajaCollection = ProdajaNamestajaCollectionProperty;
        }

        public static ProdajaNamestaja GetById(int id)
        {
            foreach (ProdajaNamestaja prodaja in prodajaNamestajaCollection)
            {
                if (prodaja.Id == id)
                {
                    return prodaja;
                }
            }
            return null;
        }

        public static void Add(ProdajaNamestaja prodajaNamestajaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            //List<ProdajaNamestaja> tempList = ProdajaNamestajaList;
            if(prodajaNamestajaToAdd == null)
            {
                return;
            }
            prodajaNamestajaCollection.Add(prodajaNamestajaToAdd);
            //ProdajaNamestajaList = tempList;
        }

        /*
        public double GetPrice()
        {
            double cena = 0;
            for (int i = 0; i < ProdatNamestajIDList.Count; ++i)
            {
                int tmpNamestajId = ProdatNamestajIDList[i];
                cena += Namestaj.GetById(ProdatNamestajIDList[i]).JedinicnaCena * BrojNamestajaList[i];
                foreach(Akcija akcija in Akcija.akcijaCollection)
                {
                    if (akcija.Obrisan == false)
                    {
                        DateTime tempDateTime = new DateTime();
                        if (tempDateTime > akcija.DatumPocetka && tempDateTime < akcija.DatumKraja)
                        {
                            
                            for (int j = 0; j < akcija.NamestajIdList.Count; ++j)
                            {
                                if (akcija.NamestajIdList[j] == tmpNamestajId)
                                {
                                    cena -= akcija.PopustList[j];
                                }
                            }
                            
                        }
                    }
                }
            }
            for (int i = 0; i < DodatnaUslugaIDList.Count; ++i)
            {
                cena += DodatnaUsluga.GetById(DodatnaUslugaIDList[i]).Cena;
            }
            cena = cena + cena * PDV/100;
            return cena;
        }
        */
        public override string ToString()
        { 
            return $"{Id}, {DatumProdaje}, {Kupac}, {BrojRacuna}";
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

    public class UredjeniParRacun : INotifyPropertyChanged
    {
        #region Fields
        private int namestajId;
        private Namestaj namestaj;
        private int brojNamestaja;
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
                return Namestaj.GetById(namestajId);
            }
            set
            {
                namestaj = value;
                NamestajId = namestaj.Id;
                OnPropertyChanged("Namestaj");
            }
        }
        public int BrojNamestaja
        {
            get
            {
                return brojNamestaja;
            }
            set
            {
                brojNamestaja = value;
                OnPropertyChanged("BrojNamestaja");
            }
        }
        [XmlIgnore]
        public double Cena
        {
            get
            {
                return Namestaj.JedinicnaCena * BrojNamestaja;
            }
        }
        [XmlIgnore]
        public double UkupnaCena
        {
            get
            {
                return Namestaj.JedinicnaCena * BrojNamestaja * (1.0 - (Akcija.GetPopustByNamestaj(Namestaj))/100);
            }
        }
        [XmlIgnore]
        public double Popust
        {
            get
            {
                return Akcija.GetPopustByNamestaj(Namestaj);
            }
        }

        #endregion

        #region Constructors
        public UredjeniParRacun()
        {
            //brojNamestaja = 0;
        }
        public UredjeniParRacun(int namestajId, int brojNamestaja)
        {
            this.NamestajId = namestajId;
            this.BrojNamestaja = brojNamestaja;
        }
        #endregion

        #region Methods
        public UredjeniParRacun Copy()
        {
            UredjeniParRacun tmp = new UredjeniParRacun();
            tmp.NamestajId = this.NamestajId;
            tmp.BrojNamestaja = this.BrojNamestaja;
            return tmp;
        }

        public override string ToString()
        {
            return $"{NamestajId}, {BrojNamestaja}";
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
