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

        Akcija akcijaCopy;
        Akcija akcijaReal;

        public DpAkcija()
        {
            InitializeComponent();
            tblock.Text = "Nova akcija:";
            operacija = Operacija.DODAVANJE;

            akcijaCopy = new Akcija("", DateTime.Now, DateTime.Now.AddDays(1), new ObservableCollection<UredjeniPar>());

            InitTabela();
        }
        
        public DpAkcija(Akcija akcija)
        {
            InitializeComponent();
            tblock.Text = "Izmena akcije:";
            operacija = Operacija.IZMENA;

            akcijaReal = akcija;
            akcijaCopy = new Akcija();
            akcijaCopy.Copy(akcija);

            InitTabela();
        }

        void InitTabela()
        {
            dgNamestaj.ItemsSource = akcijaCopy.lista;

            dpStart.DataContext = akcijaCopy;
            dpEnd.DataContext = akcijaCopy;
            tbNaziv.DataContext = akcijaCopy;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (akcijaCopy.Naziv != "")
            {
                if (dgNamestaj.Items.Count != 0)
                {
                    if (dpStart != null && dpEnd != null)
                    {
                        if (operacija == Operacija.DODAVANJE)
                        {
                            Akcija.Add(akcijaCopy);
                        }
                        else if (operacija == Operacija.IZMENA)
                        {
                            akcijaReal.Copy(akcijaCopy);
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
            DpNamestajPopust dpNamestajPopust = new DpNamestajPopust(akcijaCopy);
            dpNamestajPopust.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DpNamestajPopust dpNamestajPopust = new DpNamestajPopust((UredjeniPar)dgNamestaj.SelectedItem, akcijaCopy);
            dpNamestajPopust.ShowDialog(); // Cekamo da se zatvori prozor za menjanje
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            akcijaCopy.Lista.Remove((UredjeniPar)dgNamestaj.SelectedItem);
        }
    }
}
