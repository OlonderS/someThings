using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw1n
{
    class Sprawdzian2B
    {
        enum ETworzywo { metal, szkło, kamień }
        class Naczynie
        {
            DateTime dataProdukcji;

            public Naczynie(DateTime dataProdukcji)
            {
                this.dataProdukcji = dataProdukcji;
            }

            public override string ToString()
            {
                return $"{dataProdukcji:dd-MMM-yyyy}";
            }
        }
        class Garnek:Naczynie
        {
            float pojemosc;

            public Garnek(DateTime dataProdukcji, float pojemosc):
                base(dataProdukcji)
            {
                this.pojemosc = pojemosc;
            }

            public override string ToString()
            {
                return $"Garnek({pojemosc:F1}L), wyprodukowano: {base.ToString()}";
            }
        }
        class Wazon : Naczynie
        {
            ETworzywo tworzywo;

            public Wazon(DateTime dataProdukcji, ETworzywo tworzywo):
                base(dataProdukcji)
            {
                this.tworzywo = tworzywo;
            }
            public override string ToString()
            {
                return $"Wazon({tworzywo}), wyprodukowano: {base.ToString()}";
            }
        }
        class Wystawa
        {
            string tytul;
            List<Naczynie> naczynia;
            public Wystawa(string tytul)
            {
                this.tytul = tytul;
                naczynia = new List<Naczynie>();
            }
            public void DodajNaczynie(Naczynie naczynie)
            {
                naczynia.Add(naczynie);
            }
            public override string ToString()
            {
                string s = $"Wystawa \"{tytul}\"", ss = "";
                naczynia.ForEach(na => ss = $"{ss}\n{na}");
                return s + ss;
            }
        }
        public static void Test()
        {
            Wystawa s = new Wystawa("GARNIX");
            s.DodajNaczynie(new Wazon(new DateTime(2021, 01, 10), ETworzywo.kamień));
            s.DodajNaczynie(new Garnek(new DateTime(2021, 01, 10), 4.5f));
            s.DodajNaczynie(new Wazon(new DateTime(2021, 05, 09), ETworzywo.kamień));
            s.DodajNaczynie(new Garnek(new DateTime(2020, 12, 31), 6.0f));
            s.DodajNaczynie(new Wazon(new DateTime(2021, 08, 22), ETworzywo.szkło));
            Console.WriteLine(s);
        }
    }
}
