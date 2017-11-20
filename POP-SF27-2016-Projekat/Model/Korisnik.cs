using POP_SF27_2016_Projekat.Utils;
using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    public class Korisnik
    {
        #region Properties
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string TipKorisnikaId { get; set; }

        public bool Obrisan { get; set; }

        public static List<Korisnik> KorisnikList
        {
            get => GenericSerializer.DeSerializeList<Korisnik>("korisnik.xml");
            set => GenericSerializer.SerializeList<Korisnik>("korisnik.xml", value);
        }
        
        public static Korisnik Trenutni { get; private set; } = null;
        #endregion

        #region Constructors
        public Korisnik() { }
        public Korisnik(string ime, string prezime, string korisnickoIme, string lozinka, string tipKorisnikaId)
        {
            this.Id = ime + prezime + korisnickoIme + lozinka + tipKorisnikaId + DateTime.Now.Ticks + KorisnikList.Count;
            this.Ime = ime;
            this.Prezime = prezime;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.TipKorisnikaId = tipKorisnikaId;
        }
        #endregion

        #region Methods
        public static void Add(Korisnik korisnikToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            List<Korisnik> tempList = KorisnikList;
            tempList.Add(korisnikToAdd);
            KorisnikList = tempList;
        }

        public static void Remove(Korisnik korisnikToRemove)
        {
            korisnikToRemove.Obrisan = true;
        }

        public static Korisnik GetById(string id)
        {
            foreach (Korisnik item in KorisnikList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static bool Login(string username, string password)
        {
            foreach (Korisnik korisnik in KorisnikList)
            {
                if(korisnik.KorisnickoIme == username && korisnik.Lozinka == password)
                {
                    Trenutni = korisnik;
                    return true;
                }
            }
            return false;
        }

        public static void Logout()
        {
            Trenutni = null;
        }

        public override string ToString()
        {
            return $"{Id}, {Ime}, {Prezime}, {KorisnickoIme}, {Lozinka}, {TipKorisnika.GetById(TipKorisnikaId).Naziv}";
        }
        #endregion
    }
}
