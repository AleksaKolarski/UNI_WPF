using POP_SF27_2016_Projekat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POP_SF27_2016_Projekat.Model
{
    public class TipKorisnika
    {
        #region Properties
        public string Id { get; set; }
        public string Naziv { get; set; }
        public Dozvole Dozvole { get; set; }

        public bool Obrisan { get; set; }

        public static List<TipKorisnika> TipKorisnikaList
        {
            get => GenericSerializer.DeSerializeList<TipKorisnika>("tip_korisnika.xml");
            set => GenericSerializer.SerializeList<TipKorisnika>("tip_korisnika.xml", value);
        }
        #endregion

        #region Constructors
        public TipKorisnika() {}
        public TipKorisnika(string naziv, Dozvole dozvole)
        {
            this.Id = naziv + dozvole.ToString() + DateTime.Now.Ticks + TipKorisnikaList.Count;
            this.Naziv = naziv;
            this.Dozvole = dozvole;
        }
        #endregion

        #region Methods
        public static void Add(TipKorisnika tipKorisnikaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            List<TipKorisnika> tempList = TipKorisnikaList;
            tempList.Add(tipKorisnikaToAdd);
            TipKorisnikaList = tempList;
        }

        public static void Remove(TipKorisnika tipKorisnikaToRemove)
        {
            tipKorisnikaToRemove.Obrisan = true;
        }

        public static TipKorisnika GetById(string id)
        {
            foreach (TipKorisnika item in TipKorisnikaList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Id}, {Naziv}, {Dozvole.ToString()}";
        }
        #endregion
    }
}
