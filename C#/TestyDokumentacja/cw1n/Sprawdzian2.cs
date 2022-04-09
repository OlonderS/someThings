using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1n
{
    class Sprawdzian2
    {
        public enum EMaterial { drewno, płyta, bambus }
        public abstract class Mebel
        {
            string producent;
            public Mebel(string producent)
            {
                this.producent = producent;
            }
            public override string ToString()
            {
                return $"{producent}";
            }
        }
        public class Szafa : Mebel
        {
            EMaterial material;
            public Szafa(string producent, EMaterial material) : base(producent)
            {
                this.material = material;
            }
            public override string ToString()
            {
                return $"Szafa({base.ToString()}), {material}";
            }
        }
        public class Komoda : Mebel
        {
            byte liczbaSzuflad;
            public Komoda(string producent, byte liczbaSzuflad) : base(producent)
            {
                this.liczbaSzuflad = liczbaSzuflad;
            }
            public override string ToString()
            {
                return $"Komoda({base.ToString()}), szuflad: {liczbaSzuflad}";
            }
        }
        public class Sklep
        {
            string nazwa;
            List<Mebel> meble;
            public Sklep(string nazwa)
            {
                this.nazwa = nazwa;
                meble = new List<Mebel>();
            }
            public void DodajMebel(Mebel mebel)
            {
                meble.Add(mebel);
            }
            public override string ToString()
            {
                string s = $"Sklep \"{nazwa}\"", ss = "";
                meble.ForEach(m => ss = $"{ss}\n{m}");
                return $"{s}{ss}";
            }
        }
        public static void Test()
        {
            Sklep s = new Sklep("WARTEX");
            s.DodajMebel(new Szafa("KOLOM", EMaterial.drewno));
            s.DodajMebel(new Szafa("TYTAN", EMaterial.bambus));
            s.DodajMebel(new Komoda("GIGAN", 7));
            s.DodajMebel(new Szafa("PŁYTEX", EMaterial.płyta));
            s.DodajMebel(new Komoda("JINTEK", 5));
            Console.WriteLine(s);
        }
    }
}
