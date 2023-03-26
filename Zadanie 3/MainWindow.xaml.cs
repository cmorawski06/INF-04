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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie_3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> listaStanowisk = new List<string>();
        static List<Pracownik> pracownicy = new List<Pracownik>();
        private string noweHaslo = "";
        public MainWindow()
        {
            string[] stanowiska =
            {
                "CEO",
                "Menadżer",
                "Tester",
                "Programista"
            };
            listaStanowisk.AddRange(stanowiska);
            InitializeComponent();
            WczytajStanowiska();
            WczytajPracownikow();
        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (imie.Text != null && nazwisko.Text != null && ComboBox.Text != null && noweHaslo != "")
            {
                pracownicy.Add(new Pracownik(imie.Text, nazwisko.Text, ComboBox.Text, noweHaslo));
                int najnowszyPracownikId = pracownicy.Count()-1;
                WczytajPracownikow();
            }
        }

        private void LiczbaZnakow_TextChanged(object sender, TextChangedEventArgs e)
        {
            Generuj.IsEnabled = true;
        }

        private void Generuj_Click(object sender, RoutedEventArgs e)
        {
            noweHaslo = "";
            if (int.TryParse(LiczbaZnakow.Text, out int ingnorMe) == true)
            {
                LiczbaZnakow.BorderBrush = Brushes.Gray;
                HasloInfo.Text = "";
                int liczbaZnakow = int.Parse(LiczbaZnakow.Text);
                string znaki = "abcdefghijklmnopqrstuvwxyz";
                if (DuzeLitery.IsChecked == true)
                {
                    znaki += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                }
                if (Cyfry.IsChecked == true)
                {
                    znaki += "0123456789";
                }
                if (ZnakiSpecjalne.IsChecked == true)
                {
                    znaki += "!@#$%^&*";
                }
                Random rnd = new Random();
                for (int i = 0; i < liczbaZnakow; i++)
                {
                    int randomIndex = rnd.Next(znaki.Length);
                    noweHaslo += znaki[randomIndex];
                }
                HasloInfo.Foreground = Brushes.Green;
                HasloInfo.Text = "Hasło poprawnie wygenerowane!";
                PrintHaslo.Text = noweHaslo;
            }
            else
            {
                HasloInfo.Foreground = Brushes.Red;
                LiczbaZnakow.BorderBrush = Brushes.Red;
                HasloInfo.Text = "Podaj poprawną wartość.";
            }
        }

        private void WczytajStanowiska()
        {
            ComboBox.Items.Clear();
            foreach (string s in listaStanowisk)
            {
                ComboBox.Items.Add(s);
            }
        }

        private void WczytajPracownikow()
        {
            ListaPracownikow.Items.Clear();
            foreach (var pracownik in pracownicy)
            {
                ListaPracownikow.Items.Add(String.Concat(pracownik.imie, " ", pracownik.nazwisko, " [", pracownik.stanowisko, "]")); ;
            }
        }
    }
    class Pracownik
    {
        public string imie;
        public string nazwisko;
        public string stanowisko;
        private string haslo;
        public Pracownik(string imie, string nazwisko, string stanowisko, string haslo)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.stanowisko = stanowisko;
            this.haslo = haslo;
        }
    }
}
