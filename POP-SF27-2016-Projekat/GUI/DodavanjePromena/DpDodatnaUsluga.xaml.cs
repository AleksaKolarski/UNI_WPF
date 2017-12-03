﻿using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpDodatnaUsluga : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }

        private Operacija operacija;

        public DpDodatnaUsluga()
        {
            InitializeComponent();
            tblock.Text = "Nova dodatna usluga:";
            operacija = Operacija.DODAVANJE;
        }

        DodatnaUsluga tmp;
        public DpDodatnaUsluga(DodatnaUsluga dodatnaUsluga)
        {
            InitializeComponent();
            if(dodatnaUsluga == null)
            {
                Close();
            }
            tmp = dodatnaUsluga;
            tblock.Text = "Izmena dodatne usluge:";
            tbNaziv.Text = tmp.Naziv;
            tbCena.Text = tmp.Cena.ToString();

            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if(tbNaziv.Text != "")
            {
                double cena;
                if (double.TryParse(tbCena.Text, out cena))
                {
                    if (operacija == Operacija.DODAVANJE)
                    {
                        DodatnaUsluga.Add(new DodatnaUsluga(tbNaziv.Text, double.Parse(tbCena.Text)));
                    }
                    else if (operacija == Operacija.IZMENA)
                    {
                        DodatnaUsluga.Edit(tmp, tbNaziv.Text, double.Parse(tbCena.Text));
                    }
                    Close();
                    return;
                }
                else
                {
                    tbCena.Focus();
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
    }
}
