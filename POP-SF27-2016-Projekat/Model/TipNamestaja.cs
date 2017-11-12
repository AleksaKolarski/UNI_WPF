﻿using POP_SF27_2016.util;
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
        //private static List<TipNamestaja> tipNamestaja = TipNamestajaList;
        #endregion

        #region Properties
        public string Id { get; set; }
        public string Naziv { get; set; }

        public bool Obrisan { get; set; }

        private static List<TipNamestaja> TipNamestajaList
        {
            get => GenericSerializer.DeSerializeList<TipNamestaja>("tip_namestaja.xml");
            set => GenericSerializer.SerializeList<TipNamestaja>("tip_namestaja.xml", value);
        }
        #endregion

        #region Constructors
        public TipNamestaja() { }
        public TipNamestaja(string naziv)
        {
            this.Id = naziv + '|' + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
            this.Naziv = Naziv;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Add(TipNamestaja tipNamestajaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            List<TipNamestaja> tempList = TipNamestajaList;
            tempList.Add(tipNamestajaToAdd);
            TipNamestajaList = tempList;
        }

        public static void Remove(TipNamestaja tipNamestajaToRemove)
        {
            tipNamestajaToRemove.Obrisan = true;
        }

        public static TipNamestaja GetById(string id)
        {
            if (id != null)
            {
                foreach (TipNamestaja tip in TipNamestajaList)
                {
                    if (tip.Id == id)
                    {
                        return tip;
                    }
                }
            }
            return null;
        }

        public static TipNamestaja GetByName(string naziv)
        {
            foreach (TipNamestaja tip in TipNamestajaList)
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