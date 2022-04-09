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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for WindowDodajProdukt.xaml
    /// </summary>
    public partial class WindowDodajProdukt : Window
    {
        public WindowDodajProdukt()
        {
            InitializeComponent();
            ListaDoWyboru.ItemsSource = Sklep.ListaProduktow;
            
        }

        private void button_Wybierz_Click(object sender, RoutedEventArgs e)
        {
            if (ListaDoWyboru.SelectedIndex > -1)
            {
                try
                {
                    Klient.listaZakupow.Add(new Zakup((Produkt)ListaDoWyboru.SelectedItem, (int.Parse(PodajIlosc.Text))));
                    MessageBox.Show("Pomyślnie dodano do listy", "Dodano", MessageBoxButton.OK);

                }
                catch(Exception exception)
                {
                    // tutaj wyswietlic komunikat w labelu 
                    MessageBoxResult result = MessageBox.Show("Wprowdzono niepoprawne dane", "Błąd", MessageBoxButton.OK);
                    return;
                }
                
            }
        }


        private void PosortowanaListaProduktów_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListaKategorii_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
