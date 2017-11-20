using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    #region Enums
    [System.Flags]
    public enum Dozvola : byte
    {
        None = 0,
        Read = 1,
        Add = 1 << 1,
        Edit = 1 << 2,
        Delete = 1 << 3
    }
    #endregion

    public class Dozvole
    {
        #region Properties
        public Dozvola Akcija; // Dozvola za upravljanje akcijama
        public Dozvola DodatnaUsluga; // Dozvola za upravljanje dodatnim uslugama
        public Dozvola Korisnik; // Dozvola za upravljanje korisnicima
        public Dozvola Namestaj; // Dozvola za upravljanje namestajem
        public Dozvola ProdajaNamestaja; // Dozvola za upravljanje prodajama
        public Dozvola Salon; // Dozvola za upravljanje informacijama o salonu
        public Dozvola TipKorisnika; // Dozvola za upravljanjem tipovima korisnika
        public Dozvola TipNamestaja; // Dozvola za upravljanjem tipovima namestaja
        #endregion

        #region Constructors
        public Dozvole()
        {
            this.Akcija = Dozvola.None;
            this.DodatnaUsluga = Dozvola.None;
            this.Korisnik = Dozvola.None;
            this.Namestaj = Dozvola.None;
            this.ProdajaNamestaja = Dozvola.None;
            this.Salon = Dozvola.None;
            this.TipKorisnika = Dozvola.None;
            this.TipNamestaja = Dozvola.None;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return Akcija.ToString() + DodatnaUsluga.ToString()
                + Korisnik.ToString() + Namestaj.ToString()
                + TipNamestaja.ToString() + Salon.ToString()
                + TipKorisnika.ToString() + TipNamestaja.ToString();
        }
        #endregion
    }
}
