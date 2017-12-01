using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    class Aplikacija
    {
        #region Fields
        private ObservableCollection<Akcija> akcija;
        private ObservableCollection<DodatnaUsluga> dodatnaUsluga;
        private ObservableCollection<Korisnik> korisnik;
        private ObservableCollection<TipKorisnika> tipKorisnika;
        private ObservableCollection<Dozvole> dozvole;
        private ObservableCollection<Namestaj> namestaj;
        private ObservableCollection<TipNamestaja> tipNamestaja;
        private ObservableCollection<ProdajaNamestaja> prodajaNamestaja;
        private ObservableCollection<Salon> salon;
        #endregion

        #region Properties
        //public static Aplikacija Instance { get; private set; } = new Aplikacija();

        //public ObservableCollection<Akcija> Akcija {
        //    get
        //    {
        //        akcija = DeSerializeObservableCollection<Akcija>("akcija.xml");
        //        return akcija;
        //    }
        //    set
        //    {
        //        this.akcija = value;
        //         SerializeObservableCollection<Akcija>("akcija.xml", value);
        //    }
        //}
        //public ObservableCollection<DodatnaUsluga> DodatnaUsluga
        //{
        //    get
        //    {
        //        dodatnaUsluga = DeSerializeObservableCollection<DodatnaUsluga>("dodatna_usluga.xml");
        //        return dodatnaUsluga;
        //    }
        //    set
        //    {
        //        this.dodatnaUsluga = value;
        //        SerializeObservableCollection<DodatnaUsluga>("dodatna_usluga.xml", value);
        //    }
        //}
        //public ObservableCollection<Korisnik> Korisnik { get; set; }
        //public ObservableCollection<TipKorisnika> TipKorisnika { get; set; }
        //public ObservableCollection<Dozvole> Dozvole { get; set; }
        //public ObservableCollection<Namestaj> Namestaj { get; set; }
        //public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }
        //public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        //public ObservableCollection<Salon> Salon { get; set; }
        #endregion

        #region Constructors
        private Aplikacija()
        {
            
        }
        #endregion
    }
}
