using static POP_SF27_2016_Projekat.Utils.GenericSerializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace POP_SF27_2016_Projekat.Model
{
    public class TipKorisnika : INotifyPropertyChanged
    {
        #region Fields
        private int id;
        private string naziv;
        private Dozvole dozvole;
        private bool obrisan;
        public static ObservableCollection<TipKorisnika> tipKorisnikaCollection;
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
        public Dozvole Dozvole
        {
            get
            {
                return dozvole;
            }
            set
            {
                dozvole = value;
                OnPropertyChanged("Dozvole");
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

        public static ObservableCollection<TipKorisnika> TipKorisnikaCollectionProperty
        {
            get => DeSerializeObservableCollection<TipKorisnika>("tip_korisnika.xml");
            set => SerializeObservableCollection<TipKorisnika>("tip_korisnika.xml", value);
        }
        #endregion

        #region Constructors
        public TipKorisnika()
        {
            this.Dozvole = new Dozvole();
        }
        public TipKorisnika(string naziv, Dozvole dozvole)
        {
            this.Id = tipKorisnikaCollection.Count;
            this.Naziv = naziv;
            this.Dozvole = dozvole;
            this.Obrisan = false;
        }
        #endregion

        #region Methods
        public static void Init()
        {
            tipKorisnikaCollection = TipKorisnikaCollectionProperty;
        }

        public static TipKorisnika GetById(int id)
        {
            foreach (TipKorisnika item in tipKorisnikaCollection)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void Add(TipKorisnika tipKorisnikaToAdd)
        {
            /* Kada predjemo na rad sa bazom podataka ovde se nece ucitavati 
             * cela lista vec ce se samo slati komanda za dodavanje novog. */
            if(tipKorisnikaToAdd == null)
            {
                return;
            }
            tipKorisnikaCollection.Add(tipKorisnikaToAdd);
        }

        public static void Edit(TipKorisnika tipKorisnikaToEdit, string naziv, Dozvole dozvole)
        {
            if(tipKorisnikaToEdit == null || dozvole == null)
            {
                return;
            }
            tipKorisnikaToEdit.Naziv = naziv;
            tipKorisnikaToEdit.Dozvole = dozvole;
        }

        public static void Remove(TipKorisnika tipKorisnikaToRemove)
        {
            if(tipKorisnikaToRemove == null)
            {
                return;
            }
            tipKorisnikaToRemove.Obrisan = true;
        }

        public void Copy(TipKorisnika source)
        {
            this.Id = source.Id;
            this.Naziv = String.Copy(source.Naziv);
            this.Dozvole.Copy(source.Dozvole);
            this.Obrisan = source.Obrisan;
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
    }
}
