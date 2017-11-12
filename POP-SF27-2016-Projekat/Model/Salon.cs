using POP_SF27_2016.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
{
    public class Salon
    {
        #region Properties
        /* Propertije Id i Obrisan necu koristiti jer se aplikacija pokrece po jednom salonu. */
        //public string Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string AdresaSajta { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public string ZiroRacun { get; set; }

        //public bool Obrisan { get; set; }

        public static Salon SalonProperty
        {
            get => GenericSerializer.DeSerializeObject <Salon>("salon.xml");
            set => GenericSerializer.SerializeObject<Salon>("salon.xml", value);
        }
        #endregion

        #region Constructors
        private Salon() { }
        public Salon(string naziv, string adresa, string telefon, string email, string adresaSajta, int pIB, int maticniBroj, string ziroRacun)
        {
            //this.Id = naziv + adresa + telefon + email + adresaSajta + PIB + maticniBroj + ziroRacun + '|' + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Telefon = telefon;
            this.Email = email;
            this.AdresaSajta = adresaSajta;
            this.PIB = pIB;
            this.MaticniBroj = maticniBroj;
            this.ZiroRacun = ziroRacun;
            //this.Obrisan = false;
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Telefon}, {Email}, {AdresaSajta}, {PIB}, {MaticniBroj}, {ZiroRacun}";
        }
        #endregion
    }
}
