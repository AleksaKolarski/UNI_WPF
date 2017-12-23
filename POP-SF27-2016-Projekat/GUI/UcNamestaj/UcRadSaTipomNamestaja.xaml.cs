using POP_SF27_2016_Projekat.GUI.DodavanjePromena;
using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
    public partial class UcRadSaTipomNamestaja : UserControl
    {
        ICollectionView view;

        public UcRadSaTipomNamestaja()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(TipNamestaja.tipNamestajaCollection);
            view.Filter = HideDeletedFilter;
            dgTipNamestaja.ItemsSource = view;

            btnAdd.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnEdit.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
            btnDelete.DataContext = Korisnik.Trenutni.TipKorisnika.Dozvole;
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpTipNamestaja dpTipNamestaja = new DpTipNamestaja();
            dpTipNamestaja.ShowDialog(); // Cekamo da se zatvori prozor za dodavanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipNamestaja.SelectedItem != null)
            {
                DpTipNamestaja dpTipNamestaja = new DpTipNamestaja((TipNamestaja)dgTipNamestaja.SelectedItem);
                dpTipNamestaja.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgTipNamestaja.SelectedItem != null)    // kastujemo obj u DodatnaUsluga
            {
                TipNamestaja.Remove((TipNamestaja)dgTipNamestaja.SelectedItem);
                view.Refresh();
            }
        }
    }
}
