using POP_SF27_2016.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
{
    public class TipNamestaja
    {
        /* ==== Fields ==== */
        private static List<TipNamestaja> tipNamestaja = TipNamestajaList;


        /* ==== Properties ==== */
        public int Id { get; set; }
        public string Naziv { get; set; }

        public bool Obrisan { get; set; }

        private static List<TipNamestaja> TipNamestajaList
        {
            get => GenericSerializer.DeSerialize<TipNamestaja>("tip_namestaja.xml");
            set => GenericSerializer.Serialize<TipNamestaja>("tip_namestaja.xml", value);
        }

        
        /* ==== Methods ==== */
        public static TipNamestaja getById(int id)
        {
            foreach (TipNamestaja tip in tipNamestaja)
            {
                if(tip.Id == id)
                {
                    return tip;
                }
            }
            return null;
        }

        public static TipNamestaja getByName(string naziv)
        {
            foreach (TipNamestaja tip in tipNamestaja)
            {
                if (tip.Naziv == naziv)
                {
                    return tip;
                }
            }
            return null;
        }

        public static void IspisiMeniTipNamestaja()
        {
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("====Meni tipa namestaja====");
                    Console.WriteLine("1. Izlistaj tipove namestaja");
                    Console.WriteLine("2. Dodaj novi tip namestaja");
                    Console.WriteLine("3. Izmeni postojeci tip namestaja");
                    Console.WriteLine("4. Obrisi postojeci");
                    Console.WriteLine("0. Povratak na glavni meni");
                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        IzlistajTipNamestaja();
                        break;
                    case 2:
                        DodajNoviTipNamestaja();
                        break;
                    case 3:
                        IzmeniPostojeciTipNamestaja();
                        break;
                    case 4:
                        ObrisiPostojeciTipNamestaja();
                        break;
                    default:
                        break;
                }
            } while (izbor != 0);
        }

        public static void IzlistajTipNamestaja()
        {
            Console.WriteLine("====Izlistavanje tipa namestaja====");
            for (int i = 0; i < tipNamestaja.Count; ++i)
            {
                if (tipNamestaja[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. {tipNamestaja[i].Naziv}");
                }
            }
        }

        public static void DodajNoviTipNamestaja()
        {
            TipNamestaja noviTip = new TipNamestaja();
            Console.WriteLine("Unesite naziv tipa namestaja: ");
            noviTip.Naziv = Console.ReadLine();
            noviTip.Id = noviTip.GetHashCode();
            tipNamestaja.Add(noviTip);
            TipNamestajaList = tipNamestaja;
        }

        public static void IzmeniPostojeciTipNamestaja()
        {
            Console.WriteLine("Unesite ime tipa namestaja kojeg ocete da izmenite: ");
            string unosTmp = Console.ReadLine();
            TipNamestaja tipTmp = tipNamestaja.SingleOrDefault(x => x.Naziv == unosTmp);
            if (tipTmp == null)
            {
                Console.WriteLine("Greska, tip namestaja ne postoji!");
                return;
            }
            Console.WriteLine("Unesite novo ime: ");
            tipTmp.Naziv = Console.ReadLine();
            TipNamestajaList = tipNamestaja;
        }

        public static void ObrisiPostojeciTipNamestaja()
        {
            Console.WriteLine("Unesite ime tipa namestaja koji zelite da obrisete: ");
            string unosTmp = Console.ReadLine();
            TipNamestaja tipTmp = tipNamestaja.SingleOrDefault(x => x.Naziv == unosTmp);
            if (tipTmp == null)
            {
                Console.WriteLine("Greska, tip namestaja ne postoji!");
                return;
            }
            tipTmp.Obrisan = true;
            TipNamestajaList = tipNamestaja;
        }
    }
}
