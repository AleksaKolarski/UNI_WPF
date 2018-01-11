using POP_SF27_2016_Projekat.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpNamestajPopust : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        private Operacija operacija;

        Akcija akcija;
        UredjeniPar uredjeniParCopy;
        UredjeniPar uredjeniParReal;

        ICollectionView view;

        public DpNamestajPopust(Akcija akcijaParam)
        {
            InitializeComponent();
            tblock.Text = "Nov popust za namestaj:";
            operacija = Operacija.DODAVANJE;

            akcija = akcijaParam;

            uredjeniParCopy = new UredjeniPar();

            InitFields();
        }

        public DpNamestajPopust(UredjeniPar par, Akcija akcijaParam)
        {
            InitializeComponent();
            tblock.Text = "Izmena popusta za namestaj:";
            operacija = Operacija.IZMENA;

            akcija = akcijaParam;

            uredjeniParReal = par;
            uredjeniParCopy = new UredjeniPar();
            uredjeniParCopy.Copy(par);

            InitFields();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbPopust.Text, out var popust) && popust > 0 && popust < 100)
            {
                if (cbNamestaj.SelectedItem != null)
                {
                    if (operacija == Operacija.DODAVANJE)
                    {
                        akcija.Lista.Add(uredjeniParCopy);
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        uredjeniParReal.Copy(uredjeniParCopy);
                    }
                    Close();
                    return;
                }
                cbNamestaj.Focus();
            }
            else
            {
                tbPopust.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        void InitFields()
        {
            cbNamestaj.DataContext = uredjeniParCopy;
            tbPopust.DataContext = uredjeniParCopy;

            view = new CollectionViewSource { Source = Namestaj.namestajCollection }.View;
            view.Filter = Filter;
            cbNamestaj.ItemsSource = view;
        }

        #region Filters
        private bool Filter(object obj)
        {
            return !(((Namestaj)obj).Obrisan);
        }
        #endregion
    }
}
