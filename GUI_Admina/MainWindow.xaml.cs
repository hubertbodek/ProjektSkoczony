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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektPO;

namespace GUI_Admina
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        BazaFilmow bazaFilmow = new BazaFilmow();
        BazaSeriali bazaSeriali = new BazaSeriali();
        //ObservableCollection<Serial> listaSeriali;
        ObservableCollection<string> listaNazwSeriali;
        ObservableCollection<string> listaNrSezonow;
        public MainWindow()
        {
            InitializeComponent();
            //listaSeriali = new ObservableCollection<Serial>();
            listaNazwSeriali = new ObservableCollection<string>();
            listaNrSezonow = new ObservableCollection<string>();
            bazaFilmow = (BazaFilmow)BazaFilmow.OdczytajXML("bazaFilmow.xml");
            bazaSeriali = (BazaSeriali)BazaSeriali.OdczytajXML("bazaSeriali.xml");
            //listaSeriali = new ObservableCollection<Serial>(bazas.bazaSeriali);
            if(bazaSeriali != null)
            {
                foreach (Serial s in bazaSeriali.bazaSeriali)
                {
                    listaNazwSeriali.Add(s.Nazwa);
                    foreach(Sezon se in s.sezony)
                    {
                        listaNrSezonow.Add(s.Nazwa + ": " + se.NrSezonu);
                    }                     
                }
            }
            listaNazwSeriali = new ObservableCollection<string>(listaNazwSeriali);
            listaNrSezonow = new ObservableCollection<string>(listaNrSezonow);
            combo_SezonSerial.ItemsSource = listaNazwSeriali;
            //listaFilmow = new ObservableCollection<Film>();

            //listaFilmow = new ObservableCollection<Film>(bazaf.bazaFilmow);
            combo_SezonSerial.ItemsSource = listaNazwSeriali;
            combo_OdcinekSezon.ItemsSource = listaNrSezonow;

        }


        private void Btn_DodajFilm_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = txtBox_NazwaFilm.Text;
            Gatunek g;
            if(combo_FilmGatunek.Text == "horror")
            {
                g = Gatunek.horror;
            } else if (combo_FilmGatunek.Text == "komedia")
            {
                g = Gatunek.komedia;
            }
            else if (combo_FilmGatunek.Text == "thriller")
            {
                g = Gatunek.thriller;
            }
            else if (combo_FilmGatunek.Text == "biograficzny")
            {
                g = Gatunek.biograficzny;
            }
            else if (combo_FilmGatunek.Text == "akcji")
            {
                g = Gatunek.akcji;
            }
            else if (combo_FilmGatunek.Text == "fantasy")
            {
                g = Gatunek.fantasy;
            }
            else
            {
                g = Gatunek.sciencefiction;
            }
            int rok = Convert.ToInt32(txtBox_FilmRok.Text);
            string czas = txtBox_FilmCzas.Text;
            bazaFilmow.DodajFilm(new Film(nazwa, g, rok, czas));
            bazaFilmow.ZapiszXML("bazaFilmow.xml");
            MessageBox.Show("Dodano film!");
            txtBox_NazwaFilm.Text = "";
            txtBox_FilmRok.Text = "";
            combo_FilmGatunek.Text = "";
            txtBox_FilmCzas.Text = "";
            
        }

        private void Btn_DodajSerial_Click(object sender, RoutedEventArgs e)
        {
            string nazwa = txtBox_NazwaSerial.Text;
            Gatunek g;
            if (combo_SerialGatunek.Text == "horror")
            {
                g = Gatunek.horror;
            }
            else if (combo_SerialGatunek.Text == "komedia")
            {
                g = Gatunek.komedia;
            }
            else if (combo_SerialGatunek.Text == "thriller")
            {
                g = Gatunek.thriller;
            }
            else if (combo_SerialGatunek.Text == "biograficzny")
            {
                g = Gatunek.biograficzny;
            }
            else if (combo_SerialGatunek.Text == "akcji")
            {
                g = Gatunek.akcji;
            }
            else if (combo_SerialGatunek.Text == "fantasy")
            {
                g = Gatunek.fantasy;
            }
            else
            {
                g = Gatunek.sciencefiction;
            }
            int rok = Convert.ToInt32(txtBox_SerialRok.Text);
            bazaSeriali.DodajSerial(new Serial(nazwa, g, rok));
            bazaSeriali.ZapiszXML("bazaSeriali.xml");
            MessageBox.Show("Dodano serial!");
            txtBox_NazwaSerial.Text = "";
            txtBox_SerialRok.Text = "";
            combo_SerialGatunek.Text = "";
        }

        private void Btn_DodajSezon_Click(object sender, RoutedEventArgs e)
        {
            int nrSezonu = Convert.ToInt32(txtBox_NumerSezon.Text);
            int rokPowstania = Convert.ToInt32(txtBox_SezonRok.Text);
            foreach(Serial s in bazaSeriali.bazaSeriali)
            {
                if(combo_SezonSerial.Text == s.Nazwa)
                {
                    s.DodajSezon(new Sezon(rokPowstania, nrSezonu));
                }
            }
            bazaSeriali.ZapiszXML("bazaSeriali.xml");
            MessageBox.Show("Dodano sezon do serialu!");
            txtBox_NumerSezon.Text = "";
            txtBox_SezonRok.Text = "";
        }

        private void Btn_DodajOdcinek_Click(object sender, RoutedEventArgs e)
        {
            int nrOdcinka = Convert.ToInt32(txtBox_NumerOdcinek.Text);
            string czasTrwania = txtBox_OdcinekCzas.Text;
            foreach(Serial s in bazaSeriali.bazaSeriali)
            {
                foreach(Sezon se in s.sezony)
                {
                    if(combo_OdcinekSezon.Text.Equals(s.Nazwa + ": " + se.NrSezonu))
                    {
                        se.DodajOdcinek(new Odcinek(nrOdcinka, czasTrwania));
                    }
                }
            }
            bazaSeriali.ZapiszXML("bazaSeriali.xml");
            MessageBox.Show("Dodano odcinek do sezonu!");
            txtBox_NumerOdcinek.Text = "";
        }
    }
}
