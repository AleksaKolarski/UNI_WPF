using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace POP_SF27_2016_Projekat.Model
{ 
    public class TipNamestaja : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private bool obrisan;
        public static ObservableCollection<TipNamestaja> tipNamestajaCollection;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public bool Obrisan
        {
            get
            {
                return obrisan;
            }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        public static ObservableCollection<TipNamestaja> TipNamestajaCollectionProperty
        {
            get => DeSerializeObservableCollection<TipNamestaja>("tip_namestaja.xml");
            set => SerializeObservableCollection<TipNamestaja>("tip_namestaja.xml", value);
        }
        #endregion

        #region Constructors
        public TipNamestaja() { }
        public TipNamestaja(string naziv)
        {
            this.Id = tipNamestajaCollection.Count;
            this.Naziv = naziv;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            tipNamestajaCollection = TipNamestajaCollectionProperty;
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (TipNamestaja tip in tipNamestajaCollection)
            {
                if (tip.Id == id)
                {
                    return tip;
                }
            }
            return null;
        }

        public static void Add(TipNamestaja tipNamestajaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(tipNamestajaToAdd == null)
            {
                return;
            }
            tipNamestajaCollection.Add(tipNamestajaToAdd);
        }

        public static void Edit(TipNamestaja tipNamestajaToEdit, string naziv)
        {
            if (tipNamestajaToEdit == null)
            {
                return;
            }
            tipNamestajaToEdit.Naziv = naziv;
        }

        public static void Remove(TipNamestaja tipNamestajaToRemove)
        {
            if (tipNamestajaToRemove == null)
            {
                return;
            }
            tipNamestajaToRemove.Obrisan = true;
        }

        public override string ToString()
        {
            return $"{Naziv}";
        }
        #endregion

        #region DataBinding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Baze podataka
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();

            using (var sc = new SqlConnection())
            {

            }
        }
        #endregion
    }
}
