using POP_SF27_2016.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
{
    public class Namestaj
    {
        #region Fields
        private static List<Namestaj> namestaj = NamestajList;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public int TipNamestajaId { get; set; }

        public bool Obrisan { get; set; }

        public static List<Namestaj> NamestajList
        {
            get => GenericSerializer.DeSerializeList<Namestaj>("namestaj.xml");
            set => GenericSerializer.SerializeList<Namestaj>("namestaj.xml", value);
        }
        #endregion

        #region Methods
        public static Namestaj getById(int id)
        {
            foreach (Namestaj item in namestaj)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void Add(Namestaj novi)
        {
            namestaj.Add(novi);
            NamestajList = namestaj;
        }

        public static void Edit(Namestaj stari, string naziv)
        {
            stari.Naziv = naziv;
            NamestajList = namestaj;
        }

        public override string ToString()
        {
            return $"{Naziv}, {JedinicnaCena}, {TipNamestaja.getById(TipNamestajaId).Naziv}";
        }
        #endregion
    }
}
