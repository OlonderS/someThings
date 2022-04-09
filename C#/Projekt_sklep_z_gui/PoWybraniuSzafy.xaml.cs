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
    /// Interaction logic for PoWybraniuSzafy.xaml
    /// </summary>
    public partial class PoWybraniuSzafy : Window
    {
        public PoWybraniuSzafy()
        {
            InitializeComponent();

            ComboBoxMaterialy.ItemsSource = Enum.GetValues(typeof(Materialy)).Cast<Materialy>();

            ComboBoxProducenci.ItemsSource = Enum.GetValues(typeof(Producenci)).Cast<Producenci>();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_DodajDoAsortymentu(object sender, RoutedEventArgs e)
        {
            bool ROz;
            if (RozsuwanaCheckBox.IsChecked == true)
            {
                ROz = true;
            }
            else
            {
                ROz = false;
            }


            try
            {
                

                Sklep.ListaProduktow.Add(new Szafa(
                    (Producenci)ComboBoxProducenci.SelectedItem,
                    NazwaModeluBox.Text, int.Parse(CenaBox.Text),
                    float.Parse(WysokoscBox.Text),
                    float.Parse(SzerokoscBox.Text),
                    float.Parse(GlebokoscBox.Text),
                    (Materialy)ComboBoxMaterialy.SelectedItem,
                    int.Parse(liczbaDrzwiBox.Text),
                    ROz));

                MessageBox.Show("Pomyślnie dodano do listy", "Dodano", MessageBoxButton.OK);
            }
            catch (NullReferenceException error)
            {
                MessageBoxResult result = MessageBox.Show("Wprowdzono niepoprawne dane", "Błąd", MessageBoxButton.OK);
            }
            catch (Exception exception)
            {


                MessageBoxResult result = MessageBox.Show("Wprowdzono niepoprawne dane", "Błąd", MessageBoxButton.OK);


            }
        }

            private void ComboBoxProducenci_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
        }
    }

