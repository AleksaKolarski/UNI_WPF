﻿using POP_SF27_2016_Projekat.Model;
using System;
using System.Collections.Generic;
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

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            tbWelcome.Text = "Welcome to\n" + Salon.SalonProperty.Naziv;


        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Korisnik.Login(tbUsername.Text, pbPassword.Password);
            if(Korisnik.Trenutni != null)
            {
                this.tbUsername.Text = "";
                this.pbPassword.Password = "";
                this.Hide(); // Sakrijemo Login prozor dok je glavni otvoren
                var mainProzor = new MainWindow();
                mainProzor.ShowDialog(); // Cekamo da se zatvori mainProzor
                Korisnik.Logout(); // Za svaki slucaj kad god se vratimo u ovaj prozor izlogovati korisnika
                this.Show(); // Prikazemo opet login prozor koji bi trebao da bude ociscen
            }
        }
    }
}