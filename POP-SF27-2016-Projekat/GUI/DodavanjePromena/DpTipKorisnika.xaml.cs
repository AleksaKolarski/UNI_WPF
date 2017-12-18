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

        TipKorisnika tipKorisnikaCopy;
        TipKorisnika tipKorisnikaReal;

        public DpTipKorisnika()
        {
            InitializeComponent();
            tblock.Text = "Nov tip korisnika:";

            tipKorisnikaCopy = new TipKorisnika();

            InitFields();

            operacija = Operacija.DODAVANJE;
        }

        public DpTipKorisnika(TipKorisnika tipKorisnika)
        {
            InitializeComponent();
            if (tipKorisnika == null)
            {
                Close();
                return;
            }
            tblock.Text = "Izmena dodatne usluge:";

            tipKorisnikaReal = tipKorisnika;
            tipKorisnikaCopy = new TipKorisnika();
            tipKorisnikaCopy.Copy(tipKorisnika);

            InitFields();

            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text != "")
            {
                if (operacija == Operacija.DODAVANJE)
                {
                    TipKorisnika.Add(tipKorisnikaCopy);
                }
                else if (operacija == Operacija.IZMENA)
                {
                    //TipKorisnika.Edit(tmp, tbNaziv.Text, GetDozvoleField());
                    tipKorisnikaReal.Copy(tipKorisnikaCopy);
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
            tbNaziv.DataContext = tipKorisnikaCopy;

            cbAkcijaRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbAkcijaAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbAkcijaEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbAkcijaDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbDodatnaUslugaRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbDodatnaUslugaAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbDodatnaUslugaEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbDodatnaUslugaDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbKorisnikRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbKorisnikAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbKorisnikEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbKorisnikDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbNamestajRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbNamestajAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbNamestajEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbNamestajDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbProdajaRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbProdajaAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbProdajaEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbProdajaDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbSalonRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbSalonAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbSalonEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbSalonDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbTipKorisnikaRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbTipKorisnikaAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbTipKorisnikaEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbTipKorisnikaDelete.DataContext = tipKorisnikaCopy.Dozvole;

            cbTipNamestajaRead.DataContext = tipKorisnikaCopy.Dozvole;
            cbTipNamestajaAdd.DataContext = tipKorisnikaCopy.Dozvole;
            cbTipNamestajaEdit.DataContext = tipKorisnikaCopy.Dozvole;
            cbTipNamestajaDelete.DataContext = tipKorisnikaCopy.Dozvole;
        }
    }
}
