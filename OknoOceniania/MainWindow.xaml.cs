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
using GUI_Admina;
using ProjektPO;

namespace OknoOceniania
{

    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sciezkaFilmy = @"C:\Users\Hubert\source\repos\ProjektPO - poprawiony\ProjektPO (2)\GUI_Admina\bin\Debug\bazaFilmow.xml";
        string sciezkaSeriale = @"C:\Users\Hubert\source\repos\ProjektPO - poprawiony\ProjektPO (2)\GUI_Admina\bin\Debug\bazaSeriali.xml";
        BazaFilmow bazaFilmow = new BazaFilmow();
        BazaSeriali bazaSeriali = new BazaSeriali();
        ObservableCollection<Film> listaFilmow;
        ObservableCollection<Serial> listaSeriali;
        ObservableCollection<Sezon> listaSezonow;

        public MainWindow()
        {
            InitializeComponent();
            listaFilmow = new ObservableCollection<Film>();
            listaSeriali = new ObservableCollection<Serial>();
            listaSezonow = new ObservableCollection<Sezon>();
            bazaFilmow = (BazaFilmow)BazaFilmow.OdczytajXML(sciezkaFilmy);
            bazaSeriali = (BazaSeriali)BazaSeriali.OdczytajXML(sciezkaSeriale);
            listaFilmow = new ObservableCollection<Film>(bazaFilmow.bazaFilmow);
            listaSeriali = new ObservableCollection<Serial>(bazaSeriali.bazaSeriali);
            
        }

        private void Btn_WyswietlFilmy_Click(object sender, RoutedEventArgs e)
        {
            bazaFilmow = (BazaFilmow)BazaFilmow.OdczytajXML(sciezkaFilmy);
            listaFilmow = new ObservableCollection<Film>(bazaFilmow.bazaFilmow);
            listBox_Tabela.ItemsSource = listaFilmow;
        }

        private void Btn_WyswietlSeriale_Click(object sender, RoutedEventArgs e)
        {
            bazaSeriali = (BazaSeriali)BazaSeriali.OdczytajXML(sciezkaSeriale);
            listaSeriali = new ObservableCollection<Serial>(bazaSeriali.bazaSeriali);
            listBox_Tabela.ItemsSource = listaSeriali;
        }

        private void Btn_RankingF_Click(object sender, RoutedEventArgs e)
        {
            bazaFilmow.Ranking();
            listaFilmow = new ObservableCollection<Film>(bazaFilmow.bazaFilmow);
            listBox_Tabela.ItemsSource = listaFilmow;
        }

        private void Btn_WgNazwyF_Click(object sender, RoutedEventArgs e)
        {
            bazaFilmow.SortujNazwa();
            listaFilmow = new ObservableCollection<Film>(bazaFilmow.bazaFilmow);
            listBox_Tabela.ItemsSource = listaFilmow;
        }

        private void Btn_RankingS_Click(object sender, RoutedEventArgs e)
        {
            bazaSeriali.Ranking();
            listaSeriali = new ObservableCollection<Serial>(bazaSeriali.bazaSeriali);
            listBox_Tabela.ItemsSource = listaSeriali;
        }

        private void Btn_WgNazwyS_Click(object sender, RoutedEventArgs e)
        {
            bazaSeriali.SortujNazwa();
            listaSeriali = new ObservableCollection<Serial>(bazaSeriali.bazaSeriali);
            listBox_Tabela.ItemsSource = listaSeriali;
        }

        private void Btn_Ocen_Click(object sender, RoutedEventArgs e)
        {
            int czyDobra = Convert.ToInt16(txtBox_Ocena.Text);
            if(czyDobra<0 | czyDobra > 10)
            {
                MessageBox.Show("Skala ocen to 0-10!");
                txtBox_Ocena.Text = "";
            }
            else
            {
                int ocena = czyDobra;
                if (listBox_Tabela.ItemsSource == listaFilmow)
                {
                    Film zaznaczony = (Film)listBox_Tabela.SelectedItem;
                    zaznaczony.DodajOcene(ocena);
                    bazaFilmow.ZapiszXML(sciezkaFilmy);
                    MessageBox.Show("Dziękujemy za ocenę! Oceniłeś film na " + ocena);
                    txtBox_Ocena.Text = "";
                } else if (listBox_Tabela.ItemsSource == listaSeriali)
                {
                    Serial zaznaczony = (Serial)listBox_Tabela.SelectedItem;
                    zaznaczony.DodajOcene(ocena);
                    bazaSeriali.ZapiszXML(sciezkaSeriale);
                    MessageBox.Show("Dziękujemy za ocenę! Oceniłeś serial na " + ocena);
                    txtBox_Ocena.Text = "";
                } else if(listBox_Tabela.ItemsSource == listaSezonow)
                {
                    Sezon zaznaczony = (Sezon)listBox_Tabela.SelectedItem;
                    zaznaczony.DodajOcene(ocena);
                    bazaSeriali.ZapiszXML(sciezkaSeriale);
                    MessageBox.Show("Dziękujemy za ocenę! Oceniłeś sezon na " + ocena);
                    txtBox_Ocena.Text = "";
                }
            }
            
            
        }

        private void Btn_RozwinSerial_Click(object sender, RoutedEventArgs e)
        {

            if(listBox_Tabela.ItemsSource == listaSeriali)
            {
                if (listBox_Tabela.SelectedItem == null)
                {
                    MessageBox.Show("Wybierz serial!");
                }
                else
                {
                    Serial zaznaczony = (Serial)listBox_Tabela.SelectedItem;
                    listaSezonow = new ObservableCollection<Sezon>(zaznaczony.sezony);
                    listBox_Tabela.ItemsSource = listaSezonow;
                    btn_RozwinSerial.Content = "Wróć";
                }
            } else if((string)btn_RozwinSerial.Content == "Wróć")
            {
                listBox_Tabela.ItemsSource = listaSeriali;
                btn_RozwinSerial.Content = "Pokaż sezony";
            } 
            else
            {
                MessageBox.Show("Należy wybrać serial.");
            }
        }
    }
}
