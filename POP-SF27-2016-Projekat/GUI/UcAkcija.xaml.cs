using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcAkcija : UserControl
    {
        ICollectionView view;
        ICollectionView viewNamestaj;

        public UcAkcija()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Akcija.akcijaCollection);
            view.Filter = HideDeletedFilter;
            dgAkcija.ItemsSource = view;
            dgAkcija.IsSynchronizedWithCurrentItem = true;
        }


        private bool HideDeletedFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpAkcija dpAkcija = new DpAkcija();
            dpAkcija.ShowDialog(); // Cekamo da se zatvori prozor za dodavanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpAkcija dpAkcija = new DpAkcija((Akcija)view.CurrentItem);
            dpAkcija.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (view.CurrentItem is Akcija tmp)    // kastujemo obj u DodatnaUsluga
            {
                Akcija.Remove(tmp);
                view.Refresh();
            }
        }
        private void dgAkcija_GotFocus(object sender, RoutedEventArgs e)
        {
            viewNamestaj = CollectionViewSource.GetDefaultView(((Akcija)dgAkcija.CurrentItem).lista);
            dgNamestaj.ItemsSource = viewNamestaj;
        }
    }
}
