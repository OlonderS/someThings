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
    /// Interaction logic for PoWybraniuKanapy.xaml
    /// </summary>
    public partial class PoWybraniuKanapy : Window
    {
        public PoWybraniuKanapy()
        {
            InitializeComponent();
            ComboBoxMaterialy.ItemsSource = Enum.GetValues(typeof(Materialy)).Cast<Materialy>();

            ComboBoxProducenci.ItemsSource = Enum.GetValues(typeof(Producenci)).Cast<Producenci>();

            ComboTypKanapy.ItemsSource = Enum.GetValues(typeof(TypKanapy)).Cast<TypKanapy>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool ROz;
            if(RozkladanaCheckBox.IsChecked == true)
            {
                ROz = true;
            }
            else
            {
                ROz = false;
            }

            try
            {
                Sklep.ListaProduktow.Add(new Kanapa((Producenci)ComboBoxProducenci.SelectedItem, NazwaModeluBox.Text, int.Parse(CenaBox.Text), float.Parse(WysokoscBox.Text), float.Parse(SzerokoscBox.Text), float.Parse(GlebokoscBox.Text), (Materialy)ComboBoxMaterialy.SelectedItem, ROz, (TypKanapy)ComboTypKanapy.SelectedItem));
                MessageBox.Show("Pomyślnie dodano do listy", "Dodano", MessageBoxButton.OK);
            }
            catch (Exception exception)
            {
                MessageBoxResult result = MessageBox.Show("Wprowdzono niepoprawne dane", "Błąd", MessageBoxButton.OK);
            }
        }

        private void NazwaModeluBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
