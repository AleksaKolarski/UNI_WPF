using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Diagnostics;
using System.ComponentModel;
using POP_SF27_2016_Projekat.GUI.DodavanjePromena;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcDodatnaUsluga : UserControl
    {
        ICollectionView view;

        public UcDodatnaUsluga()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(DodatnaUsluga.dodatnaUslugaCollection);
            view.Filter = HideDeletedFilter;
            dgDodatnaUsluga.ItemsSource = view;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpDodatnaUsluga dpDodatnaUsluga = new DpDodatnaUsluga();
            dpDodatnaUsluga.ShowDialog(); // Cekamo da se zatvori prozor za dodavanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpDodatnaUsluga dpDodatnaUsluga = new DpDodatnaUsluga((DodatnaUsluga)view.CurrentItem);
            dpDodatnaUsluga.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(view.CurrentItem is DodatnaUsluga tmp)    // kastujemo obj u DodatnaUsluga
            {
                DodatnaUsluga.Remove(tmp);
                view.Refresh();
            }
        }
    }
}
