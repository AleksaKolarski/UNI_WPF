using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
{
    class Akcija
    {
        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumKraja { get; set; }
        public List<Namestaj> ListaNamestaja { get; set; }
        public List<double> ListaPopusta { get; set; }

        public bool Obrisan { get; set; }
    }
}
