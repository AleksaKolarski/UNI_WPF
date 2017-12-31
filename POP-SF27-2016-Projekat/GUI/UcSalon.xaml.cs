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
        Salon salon;

        public UcSalon()
        {
            InitializeComponent();

            salon = new Salon();
            salon.Copy(Salon.salon);

            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbEmail.DataContext = salon;
            tbAdresaSajta.DataContext = salon;
            tbPIB.DataContext = salon;
            tbMaticniBroj.DataContext = salon;
            tbZiroRacun.DataContext = salon;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(salon.Naziv != "")
            {
                if (salon.Adresa != "")
                {
                    if(salon.Telefon != "")
                    {
                        if(salon.Email != "")
                        {
                            if(salon.AdresaSajta != "")
                            {
                                Salon.Update(salon);
                            }
                        }
                    }
                }
            }
        }
    }
}
