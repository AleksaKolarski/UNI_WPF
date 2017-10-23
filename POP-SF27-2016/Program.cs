using POP_SF27_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016
{
    class Program
    {
        static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg FTN-a",
                ZiroRacun = "840-00073555082-13",
                Email = "kontakt@ftn.uns.ac.rs",
                MaticniBroj = 231231,
                PIB = 123,
                Telefon = "021/123123",
                AdresaSajta = "www.ftn.com"
            };

            var tn1 = new TipNamestaja(){
                Id = 1,
                Naziv = "Sofa"
            };

            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "SuperSofa",
                Sifra = "sifra12",
                JedinicnaCena = 1099,
                TipNamestaja = tn1,
                KolicinaUMagacinu = 12
            };

            Namestaj.Add(n1);

            Console.WriteLine($"Dobrodosli u salon {s1.Naziv}");
            IspisGlavnogMenija();
        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("====Glavni meni====");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz iz programa");
                // Zavrsiti listing za ostale entitete
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);

            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    // rad sa tipom namestaja
                    break;
                default:

                    break;
            }
        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;

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
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IzlistajNamstaj();
                    break;
                default:
                    break;
            }
        }

        private static void IzlistajNamstaj()
        {
            Console.WriteLine("====Izlistavanje namestaja====");
            for( int i = 0; i < Namestaj.Count; ++i)
            {
                Console.WriteLine($"{i + 1}. {Namestaj[i].Naziv}, cena: {Namestaj[i].JedinicnaCena}");
            }
            IspisiMeniNamestaja();
        }
    }
}
