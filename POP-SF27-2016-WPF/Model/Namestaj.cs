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
        // Napravi mapu umesto liste mozda
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

        #region Constructors
        public Namestaj()
        {
            this.Naziv = "";
            this.Sifra = "";
            this.JedinicnaCena = 0;
            this.KolicinaUMagacinu = 0;
            this.TipNamestajaId = 0;
            this.Id = this.GetHashCode();
        }
        public Namestaj(string naziv, string sifra, double jedinicnaCena, int kolicinaUMagacinu, int tipNamestajaId)
        {
            this.Naziv = naziv;
            this.Sifra = sifra;
            this.JedinicnaCena = jedinicnaCena;
            this.KolicinaUMagacinu = kolicinaUMagacinu;
            this.TipNamestajaId = tipNamestajaId;
            this.Id = this.GetHashCode();
        }
        #endregion

        #region Methods
        public static Namestaj GetById(int id)
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

        public static void Edit(Namestaj stari, Namestaj novi)
        {
            stari.Naziv = novi.Naziv;
            stari.Sifra = novi.Sifra;
            stari.JedinicnaCena = novi.JedinicnaCena;
            stari.KolicinaUMagacinu = novi.KolicinaUMagacinu;
            stari.TipNamestajaId = novi.TipNamestajaId;

            NamestajList = namestaj;
        }

        public override string ToString()
        {
            return $"{Naziv}, {JedinicnaCena}, {((TipNamestajaId == 0) ? "NULL":TipNamestaja.getById(TipNamestajaId).Naziv)}";
        }
        #endregion
    }
}
