using System;
using System.ComponentModel;
using System.Windows;

namespace POP_SF27_2016_Projekat.Model
{
    #region Enums
    [System.Flags]
    public enum Dozvola : byte
    {
        None = 0,
        Delete = 1,
        Edit = 1 << 1,
        Add = 1 << 2,
        Read = 1 << 3
    }
    #endregion

    public class Dozvole : INotifyPropertyChanged
    {
        #region Fields
        private Dozvola akcija; // Dozvola za upravljanje akcijama
        private Dozvola dodatnaUsluga; // Dozvola za upravljanje dodatnim uslugama
        private Dozvola korisnik; // Dozvola za upravljanje korisnicima
        private Dozvola namestaj; // Dozvola za upravljanje namestajem
        private Dozvola prodajaNamestaja; // Dozvola za upravljanje prodajama
        private Dozvola salon; // Dozvola za upravljanje informacijama o salonu
        private Dozvola tipKorisnika; // Dozvola za upravljanjem tipovima korisnika
        private Dozvola tipNamestaja; // Dozvola za upravljanjem tipovima namestaja
        #endregion

        #region Properties
        #region Akcija
        public Dozvola Akcija
        {
            get
            {
                return akcija;
            }
            set
            {
                akcija = value;
                OnPropertyChanged("Akcija");
                OnPropertyChanged("Dozvole");
            }
        }
        public Visibility AkcijaReadVisibility
        {
            get
            {
                if ((akcija & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        public Boolean AkcijaRead
        {
            get
            {
                return (akcija & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    Akcija = akcija | Dozvola.Read;
                }
                else
                {
                    Akcija = akcija & ~Dozvola.Read;
                }
                OnPropertyChanged("AkcijaRead");
                OnPropertyChanged("AkcijaReadVisibility");
            }
        }
        public Boolean AkcijaAdd
        {
            get
            {
                return (akcija & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    Akcija = akcija | Dozvola.Add;
                }
                else
                {
                    Akcija = akcija & ~Dozvola.Add;
                }
                OnPropertyChanged("AkcijaAdd");
            }
        }
        public Boolean AkcijaEdit
        {
            get
            {
                return (akcija & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if (value == true)
                {
                    Akcija = akcija | Dozvola.Edit;
                }
                else
                {
                    Akcija = akcija & ~Dozvola.Edit;
                }
                OnPropertyChanged("AkcijaEdit");
            }
        }
        public Boolean AkcijaDelete
        {
            get
            {
                return (akcija & Dozvola.Delete) == Dozvola.Delete;
            }
            set
            {
                if (value == true)
                {
                    Akcija = akcija | Dozvola.Delete;
                }
                else
                {
                    Akcija = akcija & ~Dozvola.Delete;
                }
                OnPropertyChanged("AkcijaDelete");
            }
        }
        #endregion
        #region DodatnaUsluga
        public Dozvola DodatnaUsluga
        {
            get
            {
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
                OnPropertyChanged("Dozvole");
            }
        }
        public Visibility DodatnaUslugaReadVisibility
        {
            get
            {
                if ((dodatnaUsluga & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        public Boolean DodatnaUslugaRead
        {
            get
            {
                return (dodatnaUsluga & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    DodatnaUsluga = dodatnaUsluga | Dozvola.Read;
                }
                else
                {
                    DodatnaUsluga = dodatnaUsluga & ~Dozvola.Read;
                }
                OnPropertyChanged("DodatnaUslugaRead");
                OnPropertyChanged("DodatnaUslugaReadVisibility");
            }
        }
        public Boolean DodatnaUslugaAdd
        {
            get
            {
                return (dodatnaUsluga & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    DodatnaUsluga = dodatnaUsluga | Dozvola.Add;
                }
                else
                {
                    DodatnaUsluga = dodatnaUsluga & ~Dozvola.Add;
                }
                OnPropertyChanged("DodatnaUslugaAdd");
            }
        }
        public Boolean DodatnaUslugaEdit
        {
            get
            {
                return (dodatnaUsluga & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if (value == true)
                {
                    DodatnaUsluga = dodatnaUsluga | Dozvola.Edit;
                }
                else
                {
                    DodatnaUsluga = dodatnaUsluga & ~Dozvola.Edit;
                }
                OnPropertyChanged("DodatnaUslugaEdit");
            }
        }
        public Boolean DodatnaUslugaDelete
        {
            get
            {
                return (dodatnaUsluga & Dozvola.Delete) == Dozvola.Delete;
            }
            set
            {
                if (value == true)
                {
                    DodatnaUsluga = dodatnaUsluga | Dozvola.Delete;
                }
                else
                {
                    DodatnaUsluga = dodatnaUsluga & ~Dozvola.Delete;
                }
                OnPropertyChanged("DodatnaUslugaDelete");
            }
        }
        #endregion
        #region Korisnik
        public Dozvola Korisnik
        {
            get
            {
                return korisnik;
            }
            set
            {
                korisnik = value;
                OnPropertyChanged("Korisnik");
                OnPropertyChanged("Dozvole");
            }
        }
        
        public Visibility KorisnikReadVisibility
        {
            get
            {
                if ((korisnik & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        
        public Boolean KorisnikRead
        {
            get
            {
                return (korisnik & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    Korisnik = korisnik | Dozvola.Read;
                }
                else
                {
                    Korisnik = korisnik & ~Dozvola.Read;
                }
                OnPropertyChanged("KorisnikRead");
                OnPropertyChanged("KorisnikReadVisibility");
            }
        }
        
        public Boolean KorisnikAdd
        {
            get
            {
                return (korisnik & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    Korisnik = korisnik | Dozvola.Add;
                }
                else
                {
                    Korisnik = korisnik & ~Dozvola.Add;
                }
                OnPropertyChanged("KorisnikAdd");
            }
        }
        
        public Boolean KorisnikEdit
        {
            get
            {
                return (korisnik & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if (value == true)
                {
                    Korisnik = korisnik | Dozvola.Edit;
                }
                else
                {
                    Korisnik = korisnik & ~Dozvola.Edit;
                }
                OnPropertyChanged("KorisnikEdit");
            }
        }
        
        public Boolean KorisnikDelete
        {
            get
            {
                return (korisnik & Dozvola.Delete) == Dozvola.Delete;
            }
            set
            {
                if (value == true)
                {
                    Korisnik = korisnik | Dozvola.Delete;
                }
                else
                {
                    Korisnik = korisnik & ~Dozvola.Delete;
                }
                OnPropertyChanged("KorisnikDelete");
            }
        }
        #endregion
        #region Namestaj
        public Dozvola Namestaj
        {
            get
            {
                return namestaj;
            }
            set
            {
                namestaj = value;
                OnPropertyChanged("Namestaj");
                OnPropertyChanged("Dozvole");
            }
        }
        
        public Visibility NamestajReadVisibility
        {
            get
            {
                if ((namestaj & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        
        public Boolean NamestajRead
        {
            get
            {
                return (namestaj & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    Namestaj = namestaj | Dozvola.Read;
                }
                else
                {
                    Namestaj = namestaj & ~Dozvola.Read;
                }
                OnPropertyChanged("NamestajRead");
                OnPropertyChanged("NamestajReadVisibility");
            }
        }
        
        public Boolean NamestajAdd
        {
            get
            {
                return (namestaj & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    Namestaj = namestaj | Dozvola.Add;
                }
                else
                {
                    Namestaj = namestaj & ~Dozvola.Add;
                }
                OnPropertyChanged("NamestajAdd");
            }
        }
        
        public Boolean NamestajEdit
        {
            get
            {
                return (namestaj & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if (value == true)
                {
                    Namestaj = namestaj | Dozvola.Edit;
                }
                else
                {
                    Namestaj = namestaj & ~Dozvola.Edit;
                }
                OnPropertyChanged("NamestajEdit");
            }
        }
        
        public Boolean NamestajDelete
        {
            get
            {
                return (namestaj & Dozvola.Delete) == Dozvola.Delete;
            }
            set
            {
                if (value == true)
                {
                    Namestaj = namestaj | Dozvola.Delete;
                }
                else
                {
                    Namestaj = namestaj & ~Dozvola.Delete;
                }
                OnPropertyChanged("NamestajDelete");
            }
        }
        #endregion
        #region Prodaja
        public Dozvola ProdajaNamestaja
        {
            get
            {
                return prodajaNamestaja;
            }
            set
            {
                prodajaNamestaja = value;
                OnPropertyChanged("ProdajaNamestaja");
                OnPropertyChanged("Dozvole");
            }
        }
        
        public Visibility ProdajaNamestajaReadVisibility
        {
            get
            {
                if ((prodajaNamestaja & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        
        public Boolean ProdajaNamestajaRead
        {
            get
            {
                return (prodajaNamestaja & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    ProdajaNamestaja = prodajaNamestaja | Dozvola.Read;
                }
                else
                {
                    ProdajaNamestaja = prodajaNamestaja & ~Dozvola.Read;
                }
                OnPropertyChanged("ProdajaNamestajaRead");
                OnPropertyChanged("ProdajaNamestajaReadVisibility");
            }
        }
        
        public Boolean ProdajaNamestajaAdd
        {
            get
            {
                return (prodajaNamestaja & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    ProdajaNamestaja = prodajaNamestaja | Dozvola.Add;
                }
                else
                {
                    ProdajaNamestaja = prodajaNamestaja & ~Dozvola.Add;
                }
                OnPropertyChanged("ProdajaNamestajaAdd");
            }
        }
        #endregion
        #region Salon
        public Dozvola Salon
        {
            get
            {
                return salon;
            }
            set
            {
                salon = value;
                OnPropertyChanged("Salon");
                OnPropertyChanged("Dozvole");
            }
        }
        
        public Visibility SalonReadVisibility
        {
            get
            {
                if((salon & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        
        public Boolean SalonRead
        {
            get
            {
                return (salon & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    Salon = salon | Dozvola.Read;
                }
                else
                {
                    Salon = salon & ~Dozvola.Read;
                }
                OnPropertyChanged("SalonRead");
                OnPropertyChanged("SalonReadVisibility");
            }
        }
        
        public Boolean SalonEdit
        {
            get
            {
                return (salon & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if(value == true)
                {
                    Salon = salon | Dozvola.Edit;
                }
                else
                {
                    Salon = salon & ~Dozvola.Edit;
                }
                OnPropertyChanged("SalonEdit");
                OnPropertyChanged("SalonEditInverse");
            }
        }
        
        public Boolean SalonEditInverse
        {
            get
            {
                // Vracamo obrnuto jer se uvek koristi u IsReadOnly propertiju
                return (salon & Dozvola.Edit) != Dozvola.Edit;
            }
        }
        #endregion
        #region TipKorisnika
        public Dozvola TipKorisnika
        {
            get
            {
                return tipKorisnika;
            }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
                OnPropertyChanged("Dozvole");
            }
        }
        
        public Visibility TipKorisnikaReadVisibility
        {
            get
            {
                if ((tipKorisnika & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        
        public Boolean TipKorisnikaRead
        {
            get
            {
                return (tipKorisnika & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    TipKorisnika = tipKorisnika | Dozvola.Read;
                }
                else
                {
                    TipKorisnika = tipKorisnika & ~Dozvola.Read;
                }
                OnPropertyChanged("TipKorisnikaRead");
                OnPropertyChanged("TipKorisnikaReadVisibility");

            }
        }
        
        public Boolean TipKorisnikaAdd
        {
            get
            {
                return (tipKorisnika & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    TipKorisnika = tipKorisnika | Dozvola.Add;
                }
                else
                {
                    TipKorisnika = tipKorisnika & ~Dozvola.Add;
                }
                OnPropertyChanged("TipKorisnikaAdd");
            }
        }
        
        public Boolean TipKorisnikaEdit
        {
            get
            {
                return (tipKorisnika & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if (value == true)
                {
                    TipKorisnika = tipKorisnika | Dozvola.Edit;
                }
                else
                {
                    TipKorisnika = tipKorisnika & ~Dozvola.Edit;
                }
                OnPropertyChanged("TipKorisnikaEdit");
            }
        }
        
        public Boolean TipKorisnikaDelete
        {
            get
            {
                return (tipKorisnika & Dozvola.Delete) == Dozvola.Delete;
            }
            set
            {
                if (value == true)
                {
                    TipKorisnika = tipKorisnika | Dozvola.Delete;
                }
                else
                {
                    TipKorisnika = tipKorisnika & ~Dozvola.Delete;
                }
                OnPropertyChanged("TipKorisnikaDelete");
            }
        }
        #endregion
        #region TipNamestaja
        public Dozvola TipNamestaja
        {
            get
            {
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                OnPropertyChanged("TipNamestaja");
                OnPropertyChanged("Dozvole");
            }
        }
        
        public Visibility TipNamestajaReadVisibility
        {
            get
            {
                if ((tipNamestaja & Dozvola.Read) == Dozvola.Read)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        
        public Boolean TipNamestajaRead
        {
            get
            {
                return (tipNamestaja & Dozvola.Read) == Dozvola.Read;
            }
            set
            {
                if (value)
                {
                    TipNamestaja = tipNamestaja | Dozvola.Read;
                }
                else
                {
                    TipNamestaja = tipNamestaja & ~Dozvola.Read;
                }
                OnPropertyChanged("TipNamestajaRead");
                OnPropertyChanged("TipNamestajaReadVisibility");
            }
        }
        
        public Boolean TipNamestajaAdd
        {
            get
            {
                return (tipNamestaja & Dozvola.Add) == Dozvola.Add;
            }
            set
            {
                if (value == true)
                {
                    TipNamestaja = tipNamestaja | Dozvola.Add;
                }
                else
                {
                    TipNamestaja = tipNamestaja & ~Dozvola.Add;
                }
                OnPropertyChanged("TipNamestajaAdd");
            }
        }
        
        public Boolean TipNamestajaEdit
        {
            get
            {
                return (tipNamestaja & Dozvola.Edit) == Dozvola.Edit;
            }
            set
            {
                if (value == true)
                {
                    TipNamestaja = tipNamestaja | Dozvola.Edit;
                }
                else
                {
                    TipNamestaja = tipNamestaja & ~Dozvola.Edit;
                }
                OnPropertyChanged("TipNamestajaEdit");
            }
        }
        
        public Boolean TipNamestajaDelete
        {
            get
            {
                return (tipNamestaja & Dozvola.Delete) == Dozvola.Delete;
            }
            set
            {
                if (value == true)
                {
                    TipNamestaja = tipNamestaja | Dozvola.Delete;
                }
                else
                {
                    TipNamestaja = tipNamestaja & ~Dozvola.Delete;
                }
                OnPropertyChanged("TipNamestajaDelete");
            }
        }
        #endregion
        #endregion

        #region Constructors
        public Dozvole()
        {
            this.Akcija = Dozvola.None;
            this.DodatnaUsluga = Dozvola.None;
            this.Korisnik = Dozvola.None;
            this.Namestaj = Dozvola.None;
            this.ProdajaNamestaja = Dozvola.None;
            this.Salon = Dozvola.None;
            this.TipKorisnika = Dozvola.None;
            this.TipNamestaja = Dozvola.None;
        }
        #endregion

        #region Methods
        public void Copy(Dozvole source)
        {
            this.AkcijaRead = source.AkcijaRead;
            this.AkcijaAdd = source.AkcijaAdd;
            this.AkcijaEdit = source.AkcijaEdit;
            this.AkcijaDelete = source.AkcijaDelete;

            this.DodatnaUslugaRead = source.DodatnaUslugaRead;
            this.DodatnaUslugaAdd = source.DodatnaUslugaAdd;
            this.DodatnaUslugaEdit = source.DodatnaUslugaEdit;
            this.DodatnaUslugaDelete = source.DodatnaUslugaDelete;

            this.KorisnikRead = source.KorisnikRead;
            this.KorisnikAdd = source.KorisnikAdd;
            this.KorisnikEdit = source.KorisnikEdit;
            this.KorisnikDelete = source.KorisnikDelete;

            this.NamestajRead = source.NamestajRead;
            this.NamestajAdd = source.NamestajAdd;
            this.NamestajEdit = source.NamestajEdit;
            this.NamestajDelete = source.NamestajDelete;

            this.ProdajaNamestajaRead = source.ProdajaNamestajaRead;
            this.ProdajaNamestajaAdd = source.ProdajaNamestajaAdd;

            this.SalonRead = source.SalonRead;
            this.SalonEdit = source.SalonEdit;

            this.TipKorisnikaRead = source.TipKorisnikaRead;
            this.TipKorisnikaAdd = source.TipKorisnikaAdd;
            this.TipKorisnikaEdit = source.TipKorisnikaEdit;
            this.TipKorisnikaDelete = source.TipKorisnikaDelete;

            this.TipNamestajaRead = source.TipNamestajaRead;
            this.TipNamestajaAdd = source.TipNamestajaAdd;
            this.TipNamestajaEdit = source.TipNamestajaEdit;
            this.TipNamestajaDelete = source.TipNamestajaDelete;
        }

        public override string ToString()
        {
            return Akcija.ToString() + DodatnaUsluga.ToString()
                + Korisnik.ToString() + Namestaj.ToString()
                + TipNamestaja.ToString() + Salon.ToString()
                + TipKorisnika.ToString() + TipNamestaja.ToString();
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
