using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Generator
{

    static class Program
    {

        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Instancje
    {
        public int size_P;
        public int max;
        public int k;
        public int size_D;
        public int bledy;
        public int Ile;
        public List<Instancja> Instancje_lista;
        public Instancje(int K, int m, int b, int ile)
        {
            size_P = K + 2;
            max = m;
            k = K;
            bledy = b;
            Ile = ile;

            Instancje_lista = new List<Instancja>();
            for (int i = 0; i < Ile; i++)
            {
                Instancja ins = new Instancja(k, max, bledy);
                Instancje_lista.Add(ins);
            }

        }

    }
    public class Instancja
    {
        public List<int> P;
        public List<int> D;
        public List<int> D_mis;
        public int size_P;
        public int max;
        public int k;
        public int size_D;
        public int bledy;
        public int Ile;
        public Instancja(int K, int m, int b)
        {
            size_P = K + 2;
            max = m;
            k = K;
            bledy = b;
            P = new List<int>();
            Miejsca_Restrykcyjne();
            CalculateSize_D();
            Instancja_Bezbledna_Generator();
            Instancja_Z_Bledami_Generator();
        }
        public void Instancja_Z_Bledami_Generator()
        {
            D_mis = new List<int>(D);
            Random rnd = new Random();
            for (int j = 0; j < bledy; j++)
            {
                int i = rnd.Next(1, size_D);
                int m = rnd.Next(1, max + 1);
                while (m == D_mis[i])
                {
                    m = rnd.Next(1, max + 1);
                }
                D_mis[i] = m;
            }
            D_mis.Sort();

        }
        public void Instancja_Bezbledna_Generator()
        {
            D = new List<int>();
            int d;
            for (int i = 0; i < size_P - 1; i++)
            {
                for (int j = i + 1; j < size_P; j++)
                {
                    d = P[j] - P[i];
                    D.Add(d);
                }
            }
            D.Sort();
        }
        public void Miejsca_Restrykcyjne()
        {
            Random rnd = new Random();
            int m;
            P.Add(0);
            for (int n = size_P - 1; n > 0; n--)
            {
                m = rnd.Next(1, max + 1);
                while (P.Contains(m))
                {
                    m = rnd.Next(1, max + 1);
                }
                P.Add(m);
            }
            P.Sort();

        }
        public void CalculateSize_D()
        {
            size_D = (k + 2) * (k + 1) / 2;
        }



    }
    public static class Saver
    {
        public static void Zapisz_wszystkie(Instancje instancje, string nazwa)
        {
            for(int i=0; i<instancje.Instancje_lista.Count(); i++)
            {
                Zapisz_instancje(instancje.Instancje_lista[i], i, nazwa);
            }
        }
        public static void Zapisz_instancje(Instancja instancja, int id, string nazwa)
        {
            string path = Directory.GetCurrentDirectory();
            string substr = "generator";
            int index = path.IndexOf(substr);
            path = path.Substring(0, index);
            path += "Instancje\\";
            path += nazwa + id.ToString();
            path+=".txt";

            TextWriter tw = new StreamWriter(path);

            foreach (int d in instancja.D_mis)
                tw.WriteLine(d.ToString());

            tw.Close();
        }
    }
}
