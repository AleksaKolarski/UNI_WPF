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

namespace POP_SF27_2016_Projekat.GUI
{
    /// <summary>
    /// Interaction logic for UcDodatnaUsluga.xaml
    /// </summary>
    public partial class UcDodatnaUsluga : UserControl
    {
        public DodatnaUsluga IzabranaUsluga { get; set; }

        public UcDodatnaUsluga()
        {
            InitializeComponent();


            // Inicijalizacija Grid-a

            ObservableCollection<DodatnaUsluga> dodatneUsluge = DodatnaUsluga.DodatnaUslugaCollection;
            ObservableCollection<DodatnaUsluga> filteredDodatneUsluge = new ObservableCollection<DodatnaUsluga>();

            foreach(DodatnaUsluga dodatnaUsluga in dodatneUsluge)
            {
                if(dodatnaUsluga.Obrisan == false)
                {
                    filteredDodatneUsluge.Add(dodatnaUsluga);
                }
            }

            DataGridTextColumn column1 = new DataGridTextColumn
            {
                Header = "Id",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                Binding = new Binding("Id")
            };

            DataGridTextColumn column2 = new DataGridTextColumn
            {
                Header = "Naziv",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                Binding = new Binding("Naziv")
            };

            DataGridTextColumn column3 = new DataGridTextColumn
            {
                Header = "Cena",
                Width = new DataGridLength(1, DataGridLengthUnitType.Star),
                Binding = new Binding("Cena")
            };

            dgDodatnaUsluga.Columns.Add(column1);
            dgDodatnaUsluga.Columns.Add(column2);
            dgDodatnaUsluga.Columns.Add(column3);

            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
            dgDodatnaUsluga.DataContext = this;
            dgDodatnaUsluga.ItemsSource = filteredDodatneUsluge;
        }
    }
}
