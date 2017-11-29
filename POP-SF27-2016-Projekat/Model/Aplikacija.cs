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
        public static Aplikacija Instance { get; private set; } = new Aplikacija();

        public ObservableCollection<Akcija> Akcija {
            //get => DeSerializeObservableCollection<Akcija>("akcija.xml");
            get; set;
        }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<TipKorisnika> TipKorisnika { get; set; }
        public ObservableCollection<Dozvole> Dozvole { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }

        private Aplikacija()
        {

        }
    }
}
