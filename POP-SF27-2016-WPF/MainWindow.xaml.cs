using POP_SF27_2016.Model;
using POP_SF27_2016_WPF.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF27_2016_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.SelectedIndex = 0;
            lbNamestaj.Items.Clear();
            foreach (Namestaj namestaj in Namestaj.NamestajList)
            {
                lbNamestaj.Items.Add(namestaj);
            }
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj();
            
            var NamestajProzor = new NamestajWindow(noviNamestaj.Id, NamestajWindow.Operacija.DODAVANJE);
            NamestajProzor.Show();
            OsveziPrikaz();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var NamestajProzor = new NamestajWindow(izabraniNamestaj.Id, NamestajWindow.Operacija.IZMENA);
            NamestajProzor.Show();
            OsveziPrikaz();
        }

        private void Zatvori(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
