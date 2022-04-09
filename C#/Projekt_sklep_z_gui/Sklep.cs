using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp2
{

    static class Sklep  
    {
        public static float kasa;
        public static string nazwa;
        
        public static List<Produkt> listaProduktow;
        internal static List<Produkt> ListaProduktow { get => listaProduktow; set => listaProduktow = value; }
        static Sklep()
        {
            nazwa = "Sklep Meblowy NaszaPaka";
         
            ListaProduktow = new List<Produkt>();
        }

        public static void UsunZeSklepu(Produkt p)
        {
            listaProduktow.Remove(p);
        }

        public static void ZapiszXml(string lista)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Produkt>));
            using (StreamWriter sw = new StreamWriter(lista))
            {
                xs.Serialize(sw, listaProduktow);
            }
        }

        public static void OdcztytajXml(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Produkt>));
            if (!File.Exists(nazwa))
                return;
            using (StreamReader sr = new StreamReader(nazwa))
            {
                listaProduktow = (List<Produkt>)serializer.Deserialize(sr);
            }
        }
    }
}
