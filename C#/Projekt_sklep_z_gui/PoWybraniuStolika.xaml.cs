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
    /// Interaction logic for PoWybraniuStolika.xaml
    /// </summary>
    public partial class PoWybraniuStolika : Window
    {
        public PoWybraniuStolika()
        {
            InitializeComponent();

            ComboBoxMaterialy.ItemsSource = Enum.GetValues(typeof(Materialy)).Cast<Materialy>();

            ComboBoxProducenci.ItemsSource = Enum.GetValues(typeof(Producenci)).Cast<Producenci>();
            ComboKsztalt.ItemsSource = Enum.GetValues(typeof(Ksztalty)).Cast<Ksztalty>();
        }



        private void ComboMaterac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sklep.ListaProduktow.Add(new Stolik((Producenci)ComboBoxProducenci.SelectedItem, NazwaModeluBox.Text, int.Parse(CenaBox.Text), float.Parse(WysokoscBox.Text), float.Parse(SzerokoscBox.Text), float.Parse(GlebokoscBox.Text), (Materialy)ComboBoxMaterialy.SelectedItem, (Ksztalty)ComboKsztalt.SelectedItem));
                MessageBox.Show("Pomyślnie dodano do listy", "Dodano", MessageBoxButton.OK);
            }
            catch (Exception exception)
            {


                MessageBoxResult result = MessageBox.Show("Wprowdzono niepoprawne dane", "Błąd", MessageBoxButton.OK);


            }
        }
    }
}
