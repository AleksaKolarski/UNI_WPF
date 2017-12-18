using POP_SF27_2016_Projekat.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF27_2016_Projekat.Model
{
    public class Salon : INotifyPropertyChanged
    {
        #region Fields
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string adresaSajta;
        private int pib;
        private int maticniBroj;
        private string ziroRacun;
        public static Salon salon;
        #endregion

        #region Properties
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
        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string AdresaSajta
        {
            get
            {
                return adresaSajta;
            }
            set
            {
                adresaSajta = value;
                OnPropertyChanged("AdresaSajta");
            }
        }
        public int PIB
        {
            get
            {
                return pib;
            }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }
        public int MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }
        public string ZiroRacun
        {
            get
            {
                return ziroRacun;
            }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
            }
        }

        public static Salon SalonProperty
        {
            get => GenericSerializer.DeSerializeObject <Salon>("salon.xml");
            set => GenericSerializer.SerializeObject<Salon>("salon.xml", value);
        }
        #endregion

        #region Constructors
        private Salon() { }
        public Salon(string naziv, string adresa, string telefon, string email, string adresaSajta, int pIB, int maticniBroj, string ziroRacun)
        {
            //this.Id = naziv + adresa + telefon + email + adresaSajta + PIB + maticniBroj + ziroRacun + '|' + DateTime.Now.Ticks;
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Telefon = telefon;
            this.Email = email;
            this.AdresaSajta = adresaSajta;
            this.PIB = pIB;
            this.MaticniBroj = maticniBroj;
            this.ZiroRacun = ziroRacun;
            //this.Obrisan = false;
        }
        #endregion

        #region methods
        public static void Init()
        {
            salon = SalonProperty;
        }

        public override string ToString()
        {
            return $"{Naziv}, {Adresa}, {Telefon}, {Email}, {AdresaSajta}, {PIB}, {MaticniBroj}, {ZiroRacun}";
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
