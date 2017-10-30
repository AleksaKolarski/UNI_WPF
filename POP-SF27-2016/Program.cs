﻿using POP_SF27_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POP_SF27_2016
{
    class Program
    {
        //static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>(); // obicna lista ako ocemo sami da upisujemo i ucitavamo u fajl
        static List<Namestaj> namestaj = Projekat.Instance.Namestaj; // Ucita se u listu namestaja iz fajla, pozivamo na pocetku
        // Projekat.Instance.Namestaj = namestaja; // Upisuje u fajl listu namestaja, pozivamo posle svake promene
        // onda se koristi namestaj kao obicna lista

        //static List<TipNamestaja> TipNamestaja { get; set; } = new List<TipNamestaja>();
        static List<TipNamestaja> tipNamestaja = Projekat.Instance.TipNamestaja;
        // Projekat.Instance.TipNamestaja = tipNamestaja;

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

            /*
            var tn1 = new TipNamestaja(){
                Id = 1,
                Naziv = "Sofa"
            };
            var tn2 = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Polica"
            };
            var tn3 = new TipNamestaja()
            {
                Id = 3,
                Naziv = "Regal"
            };
            */

            /*
            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "SuperSofa",
                Sifra = "sifra12",
                JedinicnaCena = 1099,
                TipNamestaja = tn1,
                KolicinaUMagacinu = 12
            };
            */
            /*
            tipNamestaja.Add(tn1);
            tipNamestaja.Add(tn2);
            tipNamestaja.Add(tn3);
            listaNamestaja.Add(n1);
            */

            //Projekat.Instance.TipNamestaja = tipNamestaja;
            //Projekat.Instance.Namestaj = listaNamestaja;
            //GenericSerializer.Serialize<Namestaj>("namestaj.xml", Namestaj);

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
                        IspisiMeniNamestaja();
                        break;
                    case 2:
                        IspisiMeniTipNamestaja();
                        break;
                    default:

                        break;
                }
            } while (izbor != 0);
        }

        private static void IspisiMeniNamestaja()
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

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("====Izlistavanje namestaja====");
            for( int i = 0; i < namestaj.Count; ++i)
            {
                if (namestaj[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. {namestaj[i].Naziv}, cena: {namestaj[i].JedinicnaCena}");
                }
            }
        }

        private static void DodajNoviNamestaj()
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
            /*
            string tipTmp = Console.ReadLine();
            for(int i = 0; i < TipNamestaja.Count; ++i)
            {
                if (TipNamestaja[i].Naziv == tipTmp)
                {
                    novi.TipNamestaja = TipNamestaja[i];
                }
            }
            */
            string unosTmp = Console.ReadLine();
            novi.TipNamestaja = tipNamestaja.SingleOrDefault(x => x.Naziv == unosTmp);
            if (novi.TipNamestaja == null)
            {
                Console.WriteLine("Greska, tip je null");
                Environment.Exit(1);

            }
            novi.Id = novi.GetHashCode();
            namestaj.Add(novi);
            Projekat.Instance.Namestaj = namestaj;
        }

        private static void IzmeniPostojeciNamestaj()
        {
            Console.WriteLine("Unesite ime namestaja kojeg ocete da izmenite: ");
            string unosTmp = Console.ReadLine();
            Namestaj namestajTmp = namestaj.SingleOrDefault(x => x.Naziv == unosTmp);
            if(namestajTmp == null)
            {
                Console.WriteLine("Greska, namestaj je null");
                Environment.Exit(1);
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
            namestajTmp.TipNamestaja = tipNamestaja.SingleOrDefault(x => x.Naziv == unosTmp);
            Projekat.Instance.Namestaj = namestaj;
        }

        private static void ObrisiPostojeciNamestaj()
        {
            Console.WriteLine("Unesite ime namestaja kojeg zelite da obrisete: ");
            string unosTmp = Console.ReadLine();
            Namestaj namestajTmp = namestaj.SingleOrDefault(x => x.Naziv == unosTmp);
            if (namestajTmp == null)
            {
                Console.WriteLine("Greska, namestaj je null!");
                Environment.Exit(0);
            }
            namestajTmp.Obrisan = true;
            Projekat.Instance.Namestaj = namestaj;
        }

        private static void IspisiMeniTipNamestaja()
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

        private static void IzlistajTipNamestaja()
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

        private static void DodajNoviTipNamestaja()
        {
            TipNamestaja noviTip = new TipNamestaja();
            Console.WriteLine("Unesite naziv tipa namestaja: ");
            noviTip.Naziv = Console.ReadLine();
            tipNamestaja.Add(noviTip);
            Projekat.Instance.TipNamestaja = tipNamestaja;
        }

        private static void IzmeniPostojeciTipNamestaja()
        {
            Console.WriteLine("Unesite ime tipa namestaja kojeg ocete da izmenite: ");
            string unosTmp = Console.ReadLine();
            TipNamestaja tipTmp = tipNamestaja.SingleOrDefault(x => x.Naziv == unosTmp);
            if (tipTmp == null)
            {
                Console.WriteLine("Greska, tip namestaja je null");
                Environment.Exit(1);
            }
            Console.WriteLine("Unesite novo ime: ");
            tipTmp.Naziv = Console.ReadLine();
            Projekat.Instance.TipNamestaja = tipNamestaja;
        }

        private static void ObrisiPostojeciTipNamestaja()
        {
            Console.WriteLine("Unesite ime tipa namestaja koji zelite da obrisete: ");
            string unosTmp = Console.ReadLine();
            TipNamestaja tipTmp = tipNamestaja.SingleOrDefault(x => x.Naziv == unosTmp);
            if (tipTmp == null)
            {
                Console.WriteLine("Greska, tip namestaja je null!");
                Environment.Exit(0);
            }
            tipTmp.Obrisan = true;
            Projekat.Instance.TipNamestaja = tipNamestaja;
        }
    }
}