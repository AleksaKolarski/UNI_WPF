using POP_SF27_2016_Projekat.Model;
using System.Windows;
using System.Windows.Controls;

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
                                if (int.TryParse(tbPIB.Text, out var x))
                                {
                                    if (int.TryParse(tbMaticniBroj.Text, out var y))
                                    {
                                        if (salon.ZiroRacun != "")
                                        {
                                            Salon.Update(salon);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("Neispravno popunjena polja za salon!", "Greska.");
        }
    }
}
