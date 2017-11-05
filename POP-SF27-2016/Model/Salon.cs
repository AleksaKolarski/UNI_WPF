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
        /* ==== Properties ==== */
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string AdresaSajta { get; set; }
        public int PIB { get; set; }
        public int MaticniBroj { get; set; }
        public string ZiroRacun { get; set; }

        public bool Obrisan { get; set; }
    }
}
