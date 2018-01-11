using POP_SF27_2016_Projekat.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

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
            ICollectionView view = new CollectionViewSource { Source = akcija.lista }.View;
            view.Filter = FilterNamestaja;
            dgNamestaj.ItemsSource = view;

            dpStart.DataContext = akcija;
            dpEnd.DataContext = akcija;
            tbNaziv.DataContext = akcija;
        }

        #region Filters2
        private bool FilterNamestaja(object obj)
        {
            return !(((UredjeniPar)obj).Namestaj.Obrisan);
        }
        #endregion

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (akcija.Naziv != "")
            {
                if (dgNamestaj.Items.Count != 0)
                {
                    // provera dobro unetog datuma
                    if ((dpStart != null && dpEnd != null) && (akcija.DatumPocetka < akcija.DatumKraja))
                    {
                        bool namestajVecNaAkciji = false;
                        foreach (Akcija ak in Akcija.akcijaCollection)
                        {
                            if (ak.Obrisan == false && ak.Id != akcija.Id)
                            {
                                // proveravamo da li se preklapaju datumi
                                if (ak.DatumPocetka < akcija.DatumKraja && ak.DatumKraja > akcija.DatumPocetka) {

                                    // uporedjujemo da li se preklapaju neki namestaji
                                    foreach (UredjeniPar parAk in ak.Lista)
                                    {
                                        foreach (UredjeniPar parAkcija in akcija.Lista)
                                        {
                                            if (parAk.NamestajId == parAkcija.NamestajId)
                                            {
                                                namestajVecNaAkciji = true;
                                                break;
                                            }
                                        }
                                        if (namestajVecNaAkciji == true)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            if (namestajVecNaAkciji == true)
                            {
                                break;
                            }
                        }


                        if (namestajVecNaAkciji == false)
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
                            // neki od namestaja je vec na akciji u isto vreme
                            MessageBox.Show("Neki od namestaja u ovoj akciji su u istom periodu vec na nekoj akciji.", "Greska!");
                        }
                    }
                    else
                    {
                        dpStart.Focus();
                        MessageBox.Show("Greska pri unosu datuma pocetka i kraja akcije.\nPocetak mora biti pre kraja.", "Greska.");
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
            dpNamestajPopust.ShowDialog();
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
