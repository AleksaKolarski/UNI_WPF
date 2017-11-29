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
    public class Akcija : INotifyPropertyChanged
    {
        #region Properties
        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public List<string> NamestajIdList { get; set; }
        public List<double> PopustList { get; set; }

        public bool Obrisan { get; set; }

        public static ObservableCollection<Akcija> AkcijaCollection
        {
            get => DeSerializeObservableCollection<Akcija>("akcija.xml");
            set => SerializeObservableCollection<Akcija>("akcija.xml", value);
        }
        #endregion

        #region Constructors
        public Akcija() { }
        public Akcija(DateTime datumPocetka, DateTime datumKraja, List<string> namestajIdList, List<double> popustList)
        {
            this.Id = AkcijaCollection.Count();
            this.DatumPocetka = datumPocetka;
            this.DatumKraja = datumKraja;
            this.NamestajIdList = namestajIdList;
            this.PopustList = popustList;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static Akcija GetById(int id)
        {
            if (id >= 0)
            {
                foreach (Akcija akcija in AkcijaCollection)
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
            ObservableCollection<Akcija> tempList = AkcijaCollection;
            tempList.Add(akcijaToAdd);
            AkcijaCollection = tempList;
        }

        public static void Remove(Akcija akcijaToRemove)
        {
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
}
