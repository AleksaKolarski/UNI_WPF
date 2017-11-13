using POP_SF27_2016.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
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
    }
}
