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
    /// Interaction logic for PoWybraniuLozka.xaml
    /// </summary>
    public partial class PoWybraniuLozka : Window
    {
        public PoWybraniuLozka()
        {
            InitializeComponent();

            ComboBoxMaterialy.ItemsSource = Enum.GetValues(typeof(Materialy)).Cast<Materialy>();

            ComboBoxProducenci.ItemsSource = Enum.GetValues(typeof(Producenci)).Cast<Producenci>();


            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { bool Mat;
            if (MateracCHeckBox.IsChecked == true)
            {
                Mat = true;
            }
            else
            {
                Mat = false;
            }

            try
            {

                Sklep.ListaProduktow.Add(new Lozko((Producenci)ComboBoxProducenci.SelectedItem, NazwaModeluBox.Text, int.Parse(CenaBox.Text), float.Parse(WysokoscBox.Text), float.Parse(SzerokoscBox.Text), float.Parse(GlebokoscBox.Text), (Materialy)ComboBoxMaterialy.SelectedItem, Mat));
                MessageBox.Show("Pomyślnie dodano do listy", "Dodano", MessageBoxButton.OK);
            }
            catch (Exception exception)
            {


                MessageBoxResult result = MessageBox.Show("Wprowdzono niepoprawne dane", "Błąd", MessageBoxButton.OK);
                

            }
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
