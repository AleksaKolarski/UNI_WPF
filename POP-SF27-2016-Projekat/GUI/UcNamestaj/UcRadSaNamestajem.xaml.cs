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

namespace POP_SF27_2016_Projekat.GUI.UcNamestaj
{
    public partial class UcRadSaNamestajem : UserControl
    {
        ICollectionView view;

        public UcRadSaNamestajem()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Namestaj.namestajCollection);
            view.Filter = HideDeletedFilter;
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpNamestaj dpNamestaj = new DpNamestaj();
            dpNamestaj.ShowDialog(); // Cekamo da se zatvori prozor za dodavanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpNamestaj dpNamestaj = new DpNamestaj((Namestaj)view.CurrentItem);
            dpNamestaj.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (view.CurrentItem is Namestaj tmp)    // kastujemo obj u DodatnaUsluga
            {
                Namestaj.Remove(tmp);
                view.Refresh();
            }
        }
    }
}
