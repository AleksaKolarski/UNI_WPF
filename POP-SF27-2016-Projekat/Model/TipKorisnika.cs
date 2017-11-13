using POP_SF27_2016_Projekat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Dozvole_s
{
    public bool dozvolaAkcija; // Dozvola za upravljanje akcijama
    public bool dozvolaDodatnaUsluga; // Dozvola za upravljanje dodatnim uslugama
    public bool dozvolaKorisnik; // Dozvola za upravljanje korisnicima
    public bool dozvolaNamestaj; // Dozvola za upravljanje namestajem
    public bool dozvolaProdajaNamestaja; // Dozvola za upravljanje prodajama
    public bool dozvolaSalon; // Dozvola za upravljanje informacijama o salonu
    public bool dozvolaTipKorisnika; // Dozvola za upravljanjem tipovima korisnika
    public bool dozvolaTipNamestaja; // Dozvola za upravljanjem tipovima namestaja
    
    public void Init()
    {
        this.dozvolaAkcija = false;
        this.dozvolaDodatnaUsluga = false;
        this.dozvolaKorisnik = false;
        this.dozvolaNamestaj = false;
        this.dozvolaProdajaNamestaja = false;
        this.dozvolaSalon = false;
        this.dozvolaTipKorisnika = false;
        this.dozvolaTipNamestaja = false;
    }
    public override string ToString()
    {
        return dozvolaAkcija.ToString() + dozvolaDodatnaUsluga.ToString() 
            + dozvolaKorisnik.ToString() + dozvolaNamestaj.ToString() 
            + dozvolaProdajaNamestaja.ToString() + dozvolaSalon.ToString() 
            + dozvolaTipKorisnika.ToString() + dozvolaTipNamestaja.ToString();
    }

}

namespace POP_SF27_2016_Projekat.Model
{
    public class TipKorisnika
    {
        #region Properties
        public string Id { get; set; }
        public string Naziv { get; set; }
        public Dozvole_s Dozvole { get; set; }

        public bool Obrisan { get; set; }

        public static List<TipKorisnika> TipKorisnikaList
        {
            get => GenericSerializer.DeSerializeList<TipKorisnika>("tip_korisnika.xml");
            set => GenericSerializer.SerializeList<TipKorisnika>("tip_korisnika.xml", value);
        }
        #endregion

        #region Constructors
        public TipKorisnika() {}
        public TipKorisnika(string naziv, Dozvole_s dozvole)
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
