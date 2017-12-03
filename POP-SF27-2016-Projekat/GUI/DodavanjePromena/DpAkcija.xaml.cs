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
using System.Windows.Shapes;

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpAkcija : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        private Operacija operacija;

        Akcija tmp;
        public DpAkcija()
        {
            InitializeComponent();

            tblock.Text = "Nova akcija:";
            operacija = Operacija.DODAVANJE;
            tmp = new Akcija();
            InitTabela();
        }

        
        public DpAkcija(Akcija akcija)
        {
            InitializeComponent();
            if (akcija == null)
            {
                Close();
            }
            tmp = akcija;
            tblock.Text = "Izmena akcije:";

            InitTabela();

            operacija = Operacija.IZMENA;
        }

        void InitTabela()
        {
            dgNamestaj.ItemsSource = tmp.lista;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.Items.Count != 0)
            {
                if (dpStart != null && dpEnd != null)
                {
                    if (operacija == Operacija.DODAVANJE)
                    {
                        Akcija.Add(new Akcija(dpStart.SelectedDate, dpEnd.SelectedDate, tmp.Lista));
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        Akcija.Edit(tmp, dpStart.SelectedDate, dpEnd.SelectedDate, tmp.Lista);
                    }
                    Close();
                    return;
                }
                else
                {
                    dpStart.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpNamestajPopust dpNamestajPopust = new DpNamestajPopust(tmp);
            dpNamestajPopust.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpNamestajPopust dpNamestajPopust = new DpNamestajPopust((UredjeniPar)dgNamestaj.SelectedItem, tmp);
            dpNamestajPopust.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            tmp.Lista.Remove((UredjeniPar)dgNamestaj.SelectedItem);
        }
    }
}
