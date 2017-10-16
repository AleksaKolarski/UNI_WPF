using ProstorImena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Tests
{
    class test1
    {
        public test1()
        {
            klasa a = new klasa();
            a.SetNaziv("Naziv svih naziva");
            Console.WriteLine("Naziv je : " + a.GetNaziv());

            a.Ime = "ime svih imena";
            Console.WriteLine("Ime je: " + a.Ime);


            Console.ReadLine();
        }
    }
}
