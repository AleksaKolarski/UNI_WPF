using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private double cena;
        private bool obrisan;
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

        
        public static ObservableCollection<DodatnaUsluga> DodatnaUslugaCollection
        {
            get => DeSerializeObservableCollection<DodatnaUsluga>("dodatna_usluga.xml");
            set => SerializeObservableCollection<DodatnaUsluga>("dodatna_usluga.xml", value);
        }
        
        #endregion

        #region Constructors
        public DodatnaUsluga() { }
        public DodatnaUsluga(string naziv, double cena)
        {
            this.Id = DodatnaUslugaCollection.Count();
            this.Naziv = naziv;
            this.Cena = cena;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static DodatnaUsluga GetById(int id)
        {
            if (id >= 0)
            {
                foreach (DodatnaUsluga dodatnaUsluga in DodatnaUslugaCollection)
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
            ObservableCollection<DodatnaUsluga> tempList = DodatnaUslugaCollection;
            tempList.Add(dodatnaUslugaToAdd);
            DodatnaUslugaCollection = tempList;
        }

        public static void Remove(DodatnaUsluga dodatnaUslugaToRemove)
        {
            dodatnaUslugaToRemove.Obrisan = true;
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
