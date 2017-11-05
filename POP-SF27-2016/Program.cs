using POP_SF27_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POP_SF27_2016
{
    class Program
    {
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

            Console.WriteLine($"Dobrodosli u salon {s1.Naziv}");
            IspisGlavnogMenija();
        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
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
                        Namestaj.IspisiMeniNamestaja();
                        break;
                    case 2:
                        TipNamestaja.IspisiMeniTipNamestaja();
                        break;
                    default:

                        break;
                }
            } while (izbor != 0);
        }
    }
}