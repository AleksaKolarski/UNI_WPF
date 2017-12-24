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
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class UcAkcija : UserControl
    {
        ICollectionView view;

        public UcAkcija()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Akcija.akcijaCollection);
            view.Filter = HideDeletedFilter;
            dgAkcija.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpAkcija dpAkcija = new DpAkcija();
            dpAkcija.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                DpAkcija dpAkcija = new DpAkcija((Akcija)dgAkcija.SelectedItem);
                dpAkcija.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                Akcija.Remove((Akcija)dgAkcija.SelectedItem);
                view.Refresh();
                dgNamestaj.ItemsSource = new ObservableCollection<UredjeniPar>();
            }
        }

        private void dgAkcija_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAkcija.SelectedItem != null)
            {
                dgNamestaj.ItemsSource = ((Akcija)dgAkcija.SelectedItem).lista;
            }
        }
    }
}
