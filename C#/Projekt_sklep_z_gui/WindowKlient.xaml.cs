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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for WindowKlient.xaml
    /// </summary>
    public partial class WindowKlient : Window
    {

        public WindowKlient()
        {

            InitializeComponent();
  
            ListaZakupowOFF.ItemsSource = Klient.listaZakupow;
            KwotaLabel.Content = Klient.WartoscZakupow();
        }

        private void DodajProduktButton_Click(object sender, RoutedEventArgs e)
        {
            WindowDodajProdukt oknodod = new WindowDodajProdukt();
            oknodod.Show();
            KwotaLabel.Content = Klient.WartoscZakupow();
            
        }

        private void IdzDKasyButton_Click(object sender, RoutedEventArgs e)
        {
            WindowIdzDOKasy oknoKasa = new WindowIdzDOKasy();
            oknoKasa.Show();
            ListaZakupowOFF.ItemsSource = new ObservableCollection<Zakup>(Klient.listaZakupow);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Usun_Click(object sender, RoutedEventArgs e)
        {
            if (ListaZakupowOFF.SelectedIndex > -1)
            {
                Klient.UsunZListy((Zakup)ListaZakupowOFF.SelectedItem);

                ListaZakupowOFF.ItemsSource = new ObservableCollection<Zakup>(Klient.listaZakupow);
                KwotaLabel.Content = Klient.WartoscZakupow();


            }
        }

        private void Button_Click_Odswiez(object sender, RoutedEventArgs e)
        {
            ListaZakupowOFF.ItemsSource = new ObservableCollection<Zakup>(Klient.listaZakupow);
            KwotaLabel.Content = Klient.WartoscZakupow();
        }

        private void przyciskSortuj_Click(object sender, RoutedEventArgs e)
        {
            Klient.SortujPoCenie();
            ListaZakupowOFF.ItemsSource = new ObservableCollection<Zakup>(Klient.listaZakupow);

        }

        private void ZmienIloscButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Klient.ZmienIlosc((Zakup)ListaZakupowOFF.SelectedItem, int.Parse(IloscTextBox.Text));
                ListaZakupowOFF.ItemsSource = new ObservableCollection<Zakup>(Klient.listaZakupow);
                MessageBox.Show("Pomyślnie zmieniono ilość", "Zmiana", MessageBoxButton.OK);
            }
            catch(Exception except)
            {
                MessageBox.Show("Podano Błędną ilość", "Błąd", MessageBoxButton.OK);
            }
        }
    }
}
