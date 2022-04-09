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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        
        public MainWindow()
        {
            InitializeComponent();

            Stolik stolikSzwedzki = new Stolik(Producenci.Alfa, "Stolik Szwedzki", 400, 90, 120, 80, Materialy.dąb, Ksztalty.prostokątny);
            Sklep.ListaProduktow.Add(stolikSzwedzki);
            Lozko wyspa = new Lozko(Producenci.Beta, "Wyspa", 1200, 60, 200, 140, Materialy.sosna, true);
            Sklep.ListaProduktow.Add(wyspa);
            Szafa narnia = new Szafa(Producenci.Gamma, "Marnia", 1100, 200, 90, 40, Materialy.olcha, 2, false);
            Sklep.ListaProduktow.Add(narnia);

            nazwasklepuText.Text = Sklep.nazwa;
    
        }

        private void Button_ClickPracownik(object sender, RoutedEventArgs e)
        {
            Window1 okno = new Window1();
            okno.Show();
        }

        private void Button_ClickKlient(object sender, RoutedEventArgs e)
        {
            WindowKlient oknoklient = new WindowKlient();
            oknoklient.Show();
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Sklep.ZapiszXml(filename);
            }
        }
        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                Sklep.OdcztytajXml(filename);
            }
        }
        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
