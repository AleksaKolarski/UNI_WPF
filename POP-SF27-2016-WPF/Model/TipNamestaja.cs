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
        #region Fields
        private static List<TipNamestaja> tipNamestaja = TipNamestajaList;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Naziv { get; set; }

        public bool Obrisan { get; set; }

        private static List<TipNamestaja> TipNamestajaList
        {
            get => GenericSerializer.DeSerializeList<TipNamestaja>("tip_namestaja.xml");
            set => GenericSerializer.SerializeList<TipNamestaja>("tip_namestaja.xml", value);
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
