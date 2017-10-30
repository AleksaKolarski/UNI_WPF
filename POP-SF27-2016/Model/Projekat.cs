using POP_SF27_2016.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF27_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        /* NAMESTAJ */
        private List<Namestaj> namestaj;
        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.DeSerialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }

        /* TIP NAMESTAJA */
        private List<TipNamestaja> tipNamestaja;
        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipNamestaja = GenericSerializer.DeSerialize<TipNamestaja>("tip_namestaja.xml");
                return this.tipNamestaja;
            }
            set
            {
                this.tipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tip_namestaja.xml", tipNamestaja);
            }
        }
    }
}
