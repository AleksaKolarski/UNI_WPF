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
        //private static List<Namestaj> namestaj = NamestajList;
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public string TipNamestajaId { get; set; }

        public bool Obrisan { get; set; }

        public static List<Namestaj> NamestajList
        {
            get => GenericSerializer.DeSerializeList<Namestaj>("namestaj.xml");
            set => GenericSerializer.SerializeList<Namestaj>("namestaj.xml", value);
        }
        #endregion

        #region Constructors
        public Namestaj() { }
        public Namestaj(string naziv, string sifra, double jedinicnaCena, int kolicinaUMagacinu, string tipNamestajaId)
        {
            this.Id = naziv + sifra + jedinicnaCena + kolicinaUMagacinu + tipNamestajaId + '|' + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            this.Naziv = naziv;
            this.Sifra = sifra;
            this.JedinicnaCena = jedinicnaCena;
            this.KolicinaUMagacinu = kolicinaUMagacinu;
            this.TipNamestajaId = tipNamestajaId;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Add(Namestaj namestajToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            List<Namestaj> tempList = NamestajList;
            tempList.Add(namestajToAdd);
            NamestajList = tempList;
        }
        
        public static void Remove(Namestaj namestajToRemove)
        {
            namestajToRemove.Obrisan = true;
        }

        public static Namestaj GetById(string id)
        {
            foreach (Namestaj item in NamestajList)
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
            return $"{Id}, {Naziv}, {Sifra}, {JedinicnaCena}, {KolicinaUMagacinu}, {((TipNamestajaId == null) ? "NULL":TipNamestaja.GetById(TipNamestajaId).Naziv)}";
        }
        #endregion
    }
}
