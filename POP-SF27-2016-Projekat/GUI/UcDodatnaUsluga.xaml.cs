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
        public static ObservableCollection<DodatnaUsluga> dodatnaUslugaCollection;
        ICollectionView view;

        public UcDodatnaUsluga()
        {
            InitializeComponent();

            dodatnaUslugaCollection = DodatnaUsluga.DodatnaUslugaCollection;

            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            dgDodatnaUsluga.AutoGenerateColumns = false;

            dgDodatnaUsluga.Columns.Add(new DataGridTextColumn
            {
                Header = "Id",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                Binding = new Binding("Id")
            });

            dgDodatnaUsluga.Columns.Add(new DataGridTextColumn
            {
                Header = "Naziv",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                Binding = new Binding("Naziv")
            });

            dgDodatnaUsluga.Columns.Add(new DataGridTextColumn
            {
                Header = "Cena",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                Binding = new Binding("Cena")
            });

            view = CollectionViewSource.GetDefaultView(dodatnaUslugaCollection);
            view.Filter = HideDeletedFilter;
            dgDodatnaUsluga.ItemsSource = view;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;

            dgDodatnaUsluga.AllowDrop = false;
            dgDodatnaUsluga.CanUserAddRows = false;
            dgDodatnaUsluga.CanUserDeleteRows = false;
            dgDodatnaUsluga.CanUserReorderColumns = false;
            dgDodatnaUsluga.CanUserResizeColumns = false;
            dgDodatnaUsluga.CanUserResizeRows = false;
            dgDodatnaUsluga.SelectionMode = DataGridSelectionMode.Single;
            dgDodatnaUsluga.IsReadOnly = true;
        }

        private bool HideDeletedFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;   // nemoj prikazati ako je obrisan
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //dodatnaUslugaCollection.Add(new DodatnaUsluga("naziv", 350.0));
            DpDodatnaUsluga dpDodatnaUsluga = new DpDodatnaUsluga();
            dpDodatnaUsluga.ShowDialog(); // Cekamo da se zatvori mainProzor
            /* ovo dole radi u odnosu na povratnu vrednost dijaloga da ne bi deo ispisivanja u fajl bio u malom prozoru a deo u delete dugmetu, isto tako za edit */
            //DodatnaUsluga.DodatnaUslugaCollection = dodatnaUslugaCollection;    // ispisi u fajl
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpDodatnaUsluga dpDodatnaUsluga = new DpDodatnaUsluga((DodatnaUsluga)view.CurrentItem);
            dpDodatnaUsluga.ShowDialog(); // Cekamo da se zatvori mainProzor
            //DodatnaUsluga.DodatnaUslugaCollection = dodatnaUslugaCollection;  // ispisi u fajl
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(view.CurrentItem is DodatnaUsluga tmp)    // kastujemo obj u DodatnaUsluga
            {
                tmp.Obrisan = true;
                view.Refresh();
                DodatnaUsluga.DodatnaUslugaCollection = dodatnaUslugaCollection;    // ispisi u fajl
            }
        }
    }
}
