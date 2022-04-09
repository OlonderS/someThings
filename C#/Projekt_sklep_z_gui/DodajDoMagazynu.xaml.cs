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
    /// Interaction logic for DodajDoMagazynu.xaml
    /// </summary>
    public partial class DodajDoMagazynu : Window
    {
        public DodajDoMagazynu()
        {
            InitializeComponent();

           KategoriaComboBox.ItemsSource =  Enum.GetValues(typeof(Kategorie)).Cast<Kategorie>();

        }

        private void WprowadzDaneButton_Click(object sender, RoutedEventArgs e)
        {

            if (KategoriaComboBox.SelectedItem.Equals(Kategorie.Szafa))
            {
                PoWybraniuSzafy DDm = new  PoWybraniuSzafy();
                DDm.Show();
            }
            else if (KategoriaComboBox.SelectedItem.Equals(Kategorie.Łóżko))
            {
                PoWybraniuLozka DodajLozko = new PoWybraniuLozka();
                DodajLozko.Show();
            }
            else if (KategoriaComboBox.SelectedItem.Equals(Kategorie.Stolik))
            {
                PoWybraniuStolika DodajStolik = new PoWybraniuStolika();
                DodajStolik.Show();
            }
            else if (KategoriaComboBox.SelectedItem.Equals(Kategorie.Kanapa))
            {
                PoWybraniuKanapy DodajKanape = new PoWybraniuKanapy();
                DodajKanape.Show();
            }
        }


        // rozbicie na przypadki   


    }
}
