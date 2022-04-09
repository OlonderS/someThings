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
    /// Interaction logic for WindowSprawdzStan.xaml
    /// </summary>
    public partial class WindowSprawdzStan : Window
    {
        public WindowSprawdzStan()
        {
            InitializeComponent();
            ListaAsortymentu.ItemsSource = Sklep.ListaProduktow;
        }

        private void Button_Odswiez_Click(object sender, RoutedEventArgs e)
        {
            ListaAsortymentu.ItemsSource = new ObservableCollection<Produkt>(Sklep.ListaProduktow);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ListaAsortymentu.SelectedIndex > -1)
            {
                Sklep.UsunZeSklepu((Produkt)ListaAsortymentu.SelectedItem);

                ListaAsortymentu.ItemsSource = new ObservableCollection<Produkt>(Sklep.ListaProduktow);

            }
        }
    }
}
