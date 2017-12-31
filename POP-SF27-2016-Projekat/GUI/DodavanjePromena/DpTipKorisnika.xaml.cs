using POP_SF27_2016_Projekat.Model;
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

namespace POP_SF27_2016_Projekat.GUI.DodavanjePromena
{
    public partial class DpTipKorisnika : Window
    {
        private enum Operacija
        {
            DODAVANJE,
            IZMENA
        }
        private Operacija operacija;

        private TipKorisnika tipKorisnika;

        public DpTipKorisnika()
        {
            InitializeComponent();
            tblock.Text = "Nov tip korisnika:";
            operacija = Operacija.DODAVANJE;

            tipKorisnika = new TipKorisnika();

            InitFields();
        }

        public DpTipKorisnika(TipKorisnika tipKorisnikaParam)
        {
            InitializeComponent();
            tblock.Text = "Izmena dodatne usluge:";
            operacija = Operacija.IZMENA;

            tipKorisnika = new TipKorisnika();
            tipKorisnika.Copy(tipKorisnikaParam);

            InitFields();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tipKorisnika.Naziv != "")
            {
                if (operacija == Operacija.DODAVANJE)
                {
                    TipKorisnika.Create(tipKorisnika);
                }
                else if (operacija == Operacija.IZMENA)
                {
                    TipKorisnika.Update(tipKorisnika);
                }
                Close();
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

        private void InitFields()
        {
            tbNaziv.DataContext = tipKorisnika;

            cbAkcijaRead.DataContext = tipKorisnika.Dozvole;
            cbAkcijaAdd.DataContext = tipKorisnika.Dozvole;
            cbAkcijaEdit.DataContext = tipKorisnika.Dozvole;
            cbAkcijaDelete.DataContext = tipKorisnika.Dozvole;

            cbDodatnaUslugaRead.DataContext = tipKorisnika.Dozvole;
            cbDodatnaUslugaAdd.DataContext = tipKorisnika.Dozvole;
            cbDodatnaUslugaEdit.DataContext = tipKorisnika.Dozvole;
            cbDodatnaUslugaDelete.DataContext = tipKorisnika.Dozvole;

            cbKorisnikRead.DataContext = tipKorisnika.Dozvole;
            cbKorisnikAdd.DataContext = tipKorisnika.Dozvole;
            cbKorisnikEdit.DataContext = tipKorisnika.Dozvole;
            cbKorisnikDelete.DataContext = tipKorisnika.Dozvole;

            cbNamestajRead.DataContext = tipKorisnika.Dozvole;
            cbNamestajAdd.DataContext = tipKorisnika.Dozvole;
            cbNamestajEdit.DataContext = tipKorisnika.Dozvole;
            cbNamestajDelete.DataContext = tipKorisnika.Dozvole;

            cbProdajaRead.DataContext = tipKorisnika.Dozvole;
            cbProdajaAdd.DataContext = tipKorisnika.Dozvole;
            cbProdajaEdit.DataContext = tipKorisnika.Dozvole;
            cbProdajaDelete.DataContext = tipKorisnika.Dozvole;

            cbSalonRead.DataContext = tipKorisnika.Dozvole;
            cbSalonAdd.DataContext = tipKorisnika.Dozvole;
            cbSalonEdit.DataContext = tipKorisnika.Dozvole;
            cbSalonDelete.DataContext = tipKorisnika.Dozvole;

            cbTipKorisnikaRead.DataContext = tipKorisnika.Dozvole;
            cbTipKorisnikaAdd.DataContext = tipKorisnika.Dozvole;
            cbTipKorisnikaEdit.DataContext = tipKorisnika.Dozvole;
            cbTipKorisnikaDelete.DataContext = tipKorisnika.Dozvole;

            cbTipNamestajaRead.DataContext = tipKorisnika.Dozvole;
            cbTipNamestajaAdd.DataContext = tipKorisnika.Dozvole;
            cbTipNamestajaEdit.DataContext = tipKorisnika.Dozvole;
            cbTipNamestajaDelete.DataContext = tipKorisnika.Dozvole;
        }
    }
}
