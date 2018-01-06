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

        Akcija akcija;

        public DpAkcija()
        {
            InitializeComponent();
            tblock.Text = "Nova akcija:";
            operacija = Operacija.DODAVANJE;

            akcija = new Akcija();

            InitTabela();
        }
        
        public DpAkcija(Akcija akcijaParam)
        {
            InitializeComponent();
            tblock.Text = "Izmena akcije:";
            operacija = Operacija.IZMENA;

            akcija = new Akcija();
            akcija.Copy(akcijaParam);

            InitTabela();
        }

        void InitTabela()
        {
            dgNamestaj.ItemsSource = akcija.lista;

            dpStart.DataContext = akcija;
            dpEnd.DataContext = akcija;
            tbNaziv.DataContext = akcija;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (akcija.Naziv != "")
            {
                if (dgNamestaj.Items.Count != 0)
                {
                    if (dpStart != null && dpEnd != null)
                    {
                        if (operacija == Operacija.DODAVANJE)
                        {
                            Akcija.Create(akcija);
                        }
                        else if (operacija == Operacija.IZMENA)
                        {
                            Akcija.Update(akcija);
                        }
                        Close();
                    }
                    else
                    {
                        dpStart.Focus();
                    }
                }
                else
                {
                    btnAdd.Focus();
                }
            }
            else
            {
                tbNaziv.Focus();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DpNamestajPopust dpNamestajPopust = new DpNamestajPopust(akcija);
            dpNamestajPopust.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.SelectedItem != null)
            {
                DpNamestajPopust dpNamestajPopust = new DpNamestajPopust((UredjeniPar)dgNamestaj.SelectedItem, akcija);
                dpNamestajPopust.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgNamestaj.SelectedItem != null)
            {
                akcija.Lista.Remove((UredjeniPar)dgNamestaj.SelectedItem);
            }
        }
    }
}
