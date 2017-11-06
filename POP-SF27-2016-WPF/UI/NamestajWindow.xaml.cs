using POP_SF27_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF27_2016_WPF.UI
{
    public partial class NamestajWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE, 
            IZMENA
        };
        private Namestaj namestaj;
        private Operacija operacija;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            // ovo nece biti tako
            this.namestaj = namestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
        }

        private void Sacuvaj(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    // ovde bre nista ne valja
                    Namestaj.Add(namestaj);
                    break;
                case Operacija.IZMENA:
                    Namestaj.Edit(namestaj, tbNaziv.Text);
                    break;
                default:
                    break;
            }
            this.Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
