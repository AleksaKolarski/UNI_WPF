using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcSalon : UserControl
    {
        public UcSalon()
        {
            InitializeComponent();
            Salon tmpSalon = Salon.SalonProperty;
            tbNaziv.Text = tmpSalon.Naziv;
            tbAdresa.Text = tmpSalon.Adresa;
            tbTelefon.Text = tmpSalon.Telefon;
            tbEmail.Text = tmpSalon.Email;
            tbAdresaSajta.Text = tmpSalon.AdresaSajta;
            tbPIB.Text = tmpSalon.PIB.ToString();
            tbMaticniBroj.Text = tmpSalon.MaticniBroj.ToString();
            tbZiroRacun.Text = tmpSalon.ZiroRacun;

            bool tmpDozvola = !((TipKorisnika.GetById(Korisnik.Trenutni.TipKorisnikaId).Dozvole.Salon & Dozvola.Edit) == Dozvola.Edit);
            tbNaziv.IsReadOnly = tmpDozvola;
            tbAdresa.IsReadOnly = tmpDozvola;
            tbAdresa.IsReadOnly = tmpDozvola;
            tbEmail.IsReadOnly = tmpDozvola;
            tbAdresaSajta.IsReadOnly = tmpDozvola;
            tbPIB.IsReadOnly = tmpDozvola;
            tbMaticniBroj.IsReadOnly = tmpDozvola;
            tbZiroRacun.IsReadOnly = tmpDozvola;
        }
    }
}
