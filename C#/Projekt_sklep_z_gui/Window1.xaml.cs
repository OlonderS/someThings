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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {    

        public Window1( )
        {
            InitializeComponent();
            StanKasyLabel.Content = Sklep.kasa;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DodajdoMagBut_Click(object sender, RoutedEventArgs e)
        {
            DodajDoMagazynu magazyn = new DodajDoMagazynu();
            magazyn.Show();
        }

        private void ObsłużKlientaBut_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SprawdzStanBut_Click(object sender, RoutedEventArgs e)
        {
            WindowSprawdzStan StanOkno = new WindowSprawdzStan();
            StanOkno.Show();
        }
    }
}
