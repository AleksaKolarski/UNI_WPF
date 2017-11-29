using POP_SF27_2016_Projekat.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    public class ProdajaNamestaja
    {
        #region Properties
        public string Id { get; set; }
        public List<string> ProdatNamestajIDList { get; set; }
        public List<int> BrojNamestajaList { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string Kupac { get; set; }
        public string BrojRacuna { get; set; }
        public List<string> DodatnaUslugaIDList { get; set; }
        public const double PDV = 20.0;
        // konacnu cenu cemo racunati u runtime-u

        public static List<ProdajaNamestaja> ProdajaNamestajaList
        {
            get => GenericSerializer.DeSerializeList<ProdajaNamestaja>("prodaja.xml");
            set => GenericSerializer.SerializeList<ProdajaNamestaja>("prodaja.xml", value);
        }
        #endregion

        #region Constructors
        public ProdajaNamestaja() { }
        public ProdajaNamestaja(List<string> prodatNamestajList, List<int> brojNamestajaList, DateTime datumProdaje, string kupac, string brojRacuna, List<string> dodatnaUslugaIDList)
        {
            this.Id = datumProdaje.ToString() + kupac + brojRacuna + DateTime.Now.Ticks + ProdajaNamestajaList.Count;
            this.ProdatNamestajIDList = prodatNamestajList;
            this.BrojNamestajaList = brojNamestajaList;
            this.DatumProdaje = datumProdaje;
            this.Kupac = kupac;
            this.BrojRacuna = brojRacuna;
            this.DodatnaUslugaIDList = dodatnaUslugaIDList;
        }
        #endregion

        #region Methods
        public static ProdajaNamestaja GetById(string id)
        {
            if (id != null)
            {
                foreach (ProdajaNamestaja prodaja in ProdajaNamestajaList)
                {
                    if (prodaja.Id == id)
                    {
                        return prodaja;
                    }
                }
            }
            return null;
        }

        public static void Add(ProdajaNamestaja prodajaNamestajaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            List<ProdajaNamestaja> tempList = ProdajaNamestajaList;
            tempList.Add(prodajaNamestajaToAdd);
            ProdajaNamestajaList = tempList;
        }

        public double GetPrice()
        {
            double cena = 0;
            for (int i = 0; i < ProdatNamestajIDList.Count; ++i)
            {
                string tmpNamestajId = ProdatNamestajIDList[i];
                cena += Namestaj.GetById(ProdatNamestajIDList[i]).JedinicnaCena * BrojNamestajaList[i];
                foreach(Akcija akcija in Akcija.AkcijaCollection)
                {
                    if (akcija.Obrisan == false)
                    {
                        DateTime tempDateTime = new DateTime();
                        if (tempDateTime > akcija.DatumPocetka && tempDateTime < akcija.DatumKraja)
                        {
                            for (int j = 0; j < akcija.NamestajIdList.Count; ++j)
                            {
                                if (akcija.NamestajIdList[j] == tmpNamestajId)
                                {
                                    cena -= akcija.PopustList[j];
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < DodatnaUslugaIDList.Count; ++i)
            {
                cena += DodatnaUsluga.GetById(DodatnaUslugaIDList[i]).Cena;
            }
            cena = cena + cena * PDV/100;
            return cena;
        }

        public override string ToString()
        { 
            return $"{Id}, {DatumProdaje}, {Kupac}, {BrojRacuna}, {GetPrice()}";
        }
        #endregion
    }
}
