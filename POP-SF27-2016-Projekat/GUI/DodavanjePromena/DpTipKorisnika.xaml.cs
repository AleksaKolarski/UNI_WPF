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

        public DpTipKorisnika()
        {
            InitializeComponent();
            tblock.Text = "Nov tip korisnika:";

            InitDozvoleField(new Dozvole());
            operacija = Operacija.DODAVANJE;
        }

        TipKorisnika tmp;
        public DpTipKorisnika(TipKorisnika tipKorisnika)
        {
            InitializeComponent();
            if (tipKorisnika == null)
            {
                Close();
            }
            tmp = tipKorisnika;
            tblock.Text = "Izmena dodatne usluge:";
            tbNaziv.Text = tmp.Naziv;

            InitDozvoleField(tmp.Dozvole);

            operacija = Operacija.IZMENA;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text != "")
            {
                if (operacija == Operacija.DODAVANJE)
                {
                    TipKorisnika.Add(new TipKorisnika(tbNaziv.Text, GetDozvoleField()));
                }
                else if (operacija == Operacija.IZMENA)
                {
                    TipKorisnika.Edit(tmp, tbNaziv.Text, GetDozvoleField());
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

        private void InitDozvoleField(Dozvole dozvole)
        {
            cbAkcijaAdd.IsChecked = (dozvole.Akcija & Dozvola.Add) == Dozvola.Add;
            cbAkcijaRead.IsChecked = (dozvole.Akcija & Dozvola.Read) == Dozvola.Read;
            cbAkcijaEdit.IsChecked = (dozvole.Akcija & Dozvola.Edit) == Dozvola.Edit;
            cbAkcijaDelete.IsChecked = (dozvole.Akcija & Dozvola.Delete) == Dozvola.Delete;

            cbDodatnaUslugaAdd.IsChecked = (dozvole.DodatnaUsluga & Dozvola.Add) == Dozvola.Add;
            cbDodatnaUslugaRead.IsChecked = (dozvole.DodatnaUsluga & Dozvola.Read) == Dozvola.Read;
            cbDodatnaUslugaEdit.IsChecked = (dozvole.DodatnaUsluga & Dozvola.Edit) == Dozvola.Edit;
            cbDodatnaUslugaDelete.IsChecked = (dozvole.DodatnaUsluga & Dozvola.Delete) == Dozvola.Delete;

            cbKorisnikAdd.IsChecked = (dozvole.Korisnik & Dozvola.Add) == Dozvola.Add;
            cbKorisnikRead.IsChecked = (dozvole.Korisnik & Dozvola.Read) == Dozvola.Read;
            cbKorisnikEdit.IsChecked = (dozvole.Korisnik & Dozvola.Edit) == Dozvola.Edit;
            cbKorisnikDelete.IsChecked = (dozvole.Korisnik & Dozvola.Delete) == Dozvola.Delete;

            cbNamestajAdd.IsChecked = (dozvole.Namestaj & Dozvola.Add) == Dozvola.Add;
            cbNamestajRead.IsChecked = (dozvole.Namestaj & Dozvola.Read) == Dozvola.Read;
            cbNamestajEdit.IsChecked = (dozvole.Namestaj & Dozvola.Edit) == Dozvola.Edit;
            cbNamestajDelete.IsChecked = (dozvole.Namestaj & Dozvola.Delete) == Dozvola.Delete;

            cbProdajaAdd.IsChecked = (dozvole.ProdajaNamestaja & Dozvola.Add) == Dozvola.Add;
            cbProdajaRead.IsChecked = (dozvole.ProdajaNamestaja & Dozvola.Read) == Dozvola.Read;
            cbProdajaEdit.IsChecked = (dozvole.ProdajaNamestaja & Dozvola.Edit) == Dozvola.Edit;
            cbProdajaDelete.IsChecked = (dozvole.ProdajaNamestaja & Dozvola.Delete) == Dozvola.Delete;

            cbSalonAdd.IsChecked = (dozvole.Salon & Dozvola.Add) == Dozvola.Add;
            cbSalonRead.IsChecked = (dozvole.Salon & Dozvola.Read) == Dozvola.Read;
            cbSalonEdit.IsChecked = (dozvole.Salon & Dozvola.Edit) == Dozvola.Edit;
            cbSalonDelete.IsChecked = (dozvole.Salon & Dozvola.Delete) == Dozvola.Delete;

            cbTipKorisnikaAdd.IsChecked = (dozvole.TipKorisnika & Dozvola.Add) == Dozvola.Add;
            cbTipKorisnikaRead.IsChecked = (dozvole.TipKorisnika & Dozvola.Read) == Dozvola.Read;
            cbTipKorisnikaEdit.IsChecked = (dozvole.TipKorisnika & Dozvola.Edit) == Dozvola.Edit;
            cbTipKorisnikaDelete.IsChecked = (dozvole.TipKorisnika & Dozvola.Delete) == Dozvola.Delete;

            cbTipNamestajaAdd.IsChecked = (dozvole.TipNamestaja & Dozvola.Add) == Dozvola.Add;
            cbTipNamestajaRead.IsChecked = (dozvole.TipNamestaja & Dozvola.Read) == Dozvola.Read;
            cbTipNamestajaEdit.IsChecked = (dozvole.TipNamestaja & Dozvola.Edit) == Dozvola.Edit;
            cbTipNamestajaDelete.IsChecked = (dozvole.TipNamestaja & Dozvola.Delete) == Dozvola.Delete;
        }

        private Dozvole GetDozvoleField()
        {
            Dozvole dozvole = new Dozvole();
            dozvole.Akcija = ((cbAkcijaAdd.IsChecked == true)? Dozvola.Add: Dozvola.None) | ((cbAkcijaRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbAkcijaEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbAkcijaDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.DodatnaUsluga = ((cbDodatnaUslugaAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbDodatnaUslugaRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbDodatnaUslugaEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbDodatnaUslugaDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.Korisnik = ((cbKorisnikAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbKorisnikRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbKorisnikEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbKorisnikDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.Namestaj = ((cbNamestajAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbNamestajRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbNamestajEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbNamestajDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.ProdajaNamestaja = ((cbProdajaAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbProdajaRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbProdajaEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbProdajaDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.Salon = ((cbSalonAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbSalonRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbSalonEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbSalonDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.TipKorisnika = ((cbTipKorisnikaAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbTipKorisnikaRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbTipKorisnikaEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbTipKorisnikaDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            dozvole.TipNamestaja = ((cbTipNamestajaAdd.IsChecked == true) ? Dozvola.Add : Dozvola.None) | ((cbTipNamestajaRead.IsChecked == true) ? Dozvola.Read : Dozvola.None) | ((cbTipNamestajaEdit.IsChecked == true) ? Dozvola.Edit : Dozvola.None) | ((cbTipNamestajaDelete.IsChecked == true) ? Dozvola.Delete : Dozvola.None);
            return dozvole;
        }
    }
}
