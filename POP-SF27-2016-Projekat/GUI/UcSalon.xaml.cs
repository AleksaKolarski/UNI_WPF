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

            tbNaziv.DataContext = Salon.salon;
            tbAdresa.DataContext = Salon.salon;
            tbTelefon.DataContext = Salon.salon;
            tbEmail.DataContext = Salon.salon;
            tbAdresaSajta.DataContext = Salon.salon;
            tbPIB.DataContext = Salon.salon;
            tbMaticniBroj.DataContext = Salon.salon;
            tbZiroRacun.DataContext = Salon.salon;
        }
    }
}
