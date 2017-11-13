using POP_SF27_2016.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
{
    public class DodatnaUsluga
    {
        #region Properties
        public string Id { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }

        public bool Obrisan { get; set; }

        public static List<DodatnaUsluga> DodatnaUslugaList
        {
            get => GenericSerializer.DeSerializeList<DodatnaUsluga>("dodatna_usluga.xml");
            set => GenericSerializer.SerializeList<DodatnaUsluga>("dodatna_usluga.xml", value);
        }
        #endregion

        #region Constructors
        public DodatnaUsluga() { }
        public DodatnaUsluga(string naziv, double cena)
        {
            this.Id = naziv + cena + DateTime.Now.Ticks + DodatnaUslugaList.Count;
            this.Naziv = naziv;
            this.Cena = cena;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static DodatnaUsluga GetById(string id)
        {
            if (id != null)
            {
                foreach (DodatnaUsluga dodatnaUsluga in DodatnaUslugaList)
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
            List<DodatnaUsluga> tempList = DodatnaUslugaList;
            tempList.Add(dodatnaUslugaToAdd);
            DodatnaUslugaList = tempList;
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
    }
}
