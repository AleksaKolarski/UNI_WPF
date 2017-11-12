using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016.Model
{
    public class DodatnaUsluga
    {
        #region Properties
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int Cena { get; set; }

        public bool Obrisan { get; set; }
        #endregion
    }
}
