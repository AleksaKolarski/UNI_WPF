using System.Windows;

namespace POP_SF27_2016_Projekat.GUI
{
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            tbHeader.Text = "Salon namestaja";
            tbAutor.Text = "Aleksa Kolarski SF 27/2016";
            tbOpis.Text = "Projekat iz predmeta Platforme za objektno programiranje.";
            tbFooter.Text = "2017/2018 \n Novi Sad";
        }
    }
}
