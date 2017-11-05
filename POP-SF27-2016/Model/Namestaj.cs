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
        /* ==== Fields ==== */
        private static List<Namestaj> namestaj = NamestajList;

        /* ==== Properties ==== */
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public int TipNamestajaId { get; set; }

        public bool Obrisan { get; set; }

        private static List<Namestaj> NamestajList
        {
            get => GenericSerializer.DeSerializeList<Namestaj>("namestaj.xml");
            set => GenericSerializer.SerializeList<Namestaj>("namestaj.xml", value);
        }


        /* ==== Methods ==== */
        public static Namestaj getById(int id)
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

        public static void IspisiMeniNamestaja()
        {
            int izbor = 0;
            do
            {
                do
                {
                    Console.WriteLine("====Meni namestaja====");
                    Console.WriteLine("1. Izlistaj namestaj");
                    Console.WriteLine("2. Dodaj novi namestaj");
                    Console.WriteLine("3. Izmeni postojeci namestaj");
                    Console.WriteLine("4. Obrisi postojeci");
                    Console.WriteLine("0. Povratak na glavni meni");
                    izbor = int.Parse(Console.ReadLine());
                } while (izbor < 0 || izbor > 4);

                switch (izbor)
                {
                    case 1:
                        IzlistajNamestaj();
                        break;
                    case 2:
                        DodajNoviNamestaj();
                        break;
                    case 3:
                        IzmeniPostojeciNamestaj();
                        break;
                    case 4:
                        ObrisiPostojeciNamestaj();
                        break;
                    default:
                        break;
                }
            } while (izbor != 0);
            return;
        }

        public static void IzlistajNamestaj()
        {
            Console.WriteLine("====Izlistavanje namestaja====");
            for (int i = 0; i < namestaj.Count; ++i)
            {
                if (namestaj[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. {namestaj[i].Naziv}, cena: {namestaj[i].JedinicnaCena}, tip: {TipNamestaja.getById(namestaj[i].TipNamestajaId).Naziv}");
                }
            }
        }

        public static void DodajNoviNamestaj()
        {
            Namestaj novi = new Namestaj();
            Console.WriteLine("Unesite naziv namestaja: ");
            novi.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite sifru namestaja: ");
            novi.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite jedinicnu cenu namestaja: ");
            novi.JedinicnaCena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite kolicinu namestaja: ");
            novi.KolicinaUMagacinu = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite tip namestaja: ");
            string unosTmp = Console.ReadLine();

            TipNamestaja tipTmp = TipNamestaja.getByName(unosTmp);
            if(tipTmp != null)
            {
                novi.TipNamestajaId = tipTmp.Id;
            }
            else
            {
                Console.WriteLine("Greska, tip namestaja ne postoji!");
                return;
            }

            novi.Id = novi.GetHashCode();
            namestaj.Add(novi);
            NamestajList = namestaj;
        }

        public static void IzmeniPostojeciNamestaj()
        {
            Console.WriteLine("Unesite ime namestaja kojeg ocete da izmenite: ");
            string unosTmp = Console.ReadLine();
            Namestaj namestajTmp = namestaj.SingleOrDefault(x => x.Naziv == unosTmp);
            if (namestajTmp == null)
            {
                Console.WriteLine("Greska, namestaj nije pronadjen!");
                return;
            }
            Console.WriteLine("Unesite novo ime: ");
            namestajTmp.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite novu sifru: ");
            namestajTmp.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite novu cenu: ");
            namestajTmp.JedinicnaCena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novu kolicinu: ");
            namestajTmp.KolicinaUMagacinu = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novi tip: ");
            unosTmp = Console.ReadLine();
            TipNamestaja tipTmp = TipNamestaja.getByName(unosTmp);
            if (tipTmp != null)
            {
                namestajTmp.TipNamestajaId = tipTmp.Id;
            }
            else
            {
                Console.WriteLine("Greska, tip namestaja ne postoji");
                return;
            }
            NamestajList = namestaj;
        }

        public static void ObrisiPostojeciNamestaj()
        {
            Console.WriteLine("Unesite ime namestaja kojeg zelite da obrisete: ");
            string unosTmp = Console.ReadLine();
            Namestaj namestajTmp = namestaj.SingleOrDefault(x => x.Naziv == unosTmp);
            if (namestajTmp == null)
            {
                Console.WriteLine("Greska, namestaj nije pronadjen!");
                return;
            }
            namestajTmp.Obrisan = true;
            NamestajList = namestaj;
        }
    }
}
