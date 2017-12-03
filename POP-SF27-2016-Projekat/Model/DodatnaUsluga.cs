using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public static ObservableCollection<DodatnaUsluga> DodatnaUslugaCollectionProperty
        {
            get => DeSerializeObservableCollection<DodatnaUsluga>("dodatna_usluga.xml");
            set => SerializeObservableCollection<DodatnaUsluga>("dodatna_usluga.xml", value);
        }
        
        #endregion

        #region Constructors
        public DodatnaUsluga() { }
        public DodatnaUsluga(string naziv, double cena)
        {
            this.Id = DodatnaUslugaCollectionProperty.Count();
            this.Naziv = naziv;
            this.Cena = cena;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            dodatnaUslugaCollection = DodatnaUslugaCollectionProperty;
        }

        public static DodatnaUsluga GetById(int id)
        {
            if (id >= 0)
            {
                foreach (DodatnaUsluga dodatnaUsluga in dodatnaUslugaCollection)
                {
                    if (dodatnaUsluga.Id == id)
                    {
                        return dodatnaUsluga;
                    }
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
            //DodatnaUslugaCollection = dodatnaUslugaCollection;
        }

        public static void Edit(DodatnaUsluga dodatnaUslugaToEdit, string naziv, double cena)
        {
            if(dodatnaUslugaToEdit == null)
            {
                return;
            }
            dodatnaUslugaToEdit.Naziv = naziv;
            dodatnaUslugaToEdit.Cena = cena;
            //DodatnaUslugaCollection = dodatnaUslugaCollection;
        }

        public static void Remove(DodatnaUsluga dodatnaUslugaToRemove)
        {
            if(dodatnaUslugaToRemove == null)
            {
                return;
            }
            dodatnaUslugaToRemove.Obrisan = true;
            //DodatnaUslugaCollection = dodatnaUslugaCollection;
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
    }
}
