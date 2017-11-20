using POP_SF27_2016_Projekat.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    //public class Akcija : INotifyPropertyChanged
    public class Akcija
    {
        #region Properties
        public string Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public List<string> NamestajIdList { get; set; }
        public List<double> PopustList { get; set; }

        public bool Obrisan { get; set; }

        public static List<Akcija> AkcijaList
        {
            get => GenericSerializer.DeSerializeList<Akcija>("akcija.xml");
            set => GenericSerializer.SerializeList<Akcija>("akcija.xml", value);
        }
        #endregion

        #region Constructors
        public Akcija() { }
        public Akcija(DateTime datumPocetka, DateTime datumKraja, List<string> namestajIdList, List<double> popustList)
        {
            this.Id = datumPocetka.ToString() + datumKraja.ToString() + DateTime.Now.Ticks + AkcijaList.Count;
            this.DatumPocetka = datumPocetka;
            this.DatumKraja = datumKraja;
            this.NamestajIdList = namestajIdList;
            this.PopustList = popustList;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static Akcija GetById(string id)
        {
            if (id != null)
            {
                foreach (Akcija akcija in AkcijaList)
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
            List<Akcija> tempList = AkcijaList;
            tempList.Add(akcijaToAdd);
            AkcijaList = tempList;
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
    }
}
