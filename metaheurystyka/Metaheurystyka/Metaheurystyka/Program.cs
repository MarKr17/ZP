using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Metaheurystyka
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
    public static class Global
    {
        public static Instancja instancja;
        public static string[] dirs;
       
    }
    public class Test
    {
        //parametry dla danego testu
        public int populacja; //wielkość p[opulacji
        public int iteracje; //cykle reprodukcyjne
        public double mutation_prob; //prawdopodobieństwo mutacji;
        public double cross_prob; //prawdopodobieństwo krzyżowania;
        public string folder; //podstawowa ścieżka do pliku

        public int iteracja;

        public List<double> wyniki=new List<double>(); //uśrednione wyniki dla danego folderu
        public List<double> czasy= new List<double>(); //uśredniony czas dla danego folderu

        public Test(int p, int it, double m, double c, string s)
        {
            populacja = p;
            iteracje = it;
            mutation_prob = m;
            cross_prob = c;
            folder = s;
            iteracja = 0;
        }
        public void Obliczenia()
        {
            double wynik=0;//średni wynik
            double czas=0;//średni czas;
            for (int i=0; i<20; i++)
            {
                string nazwa = folder + "\\instancja" + i.ToString();
                Instancja ins = new Instancja(nazwa);
                ins.population_size = populacja;
                ins.iteracje_max = iteracje;
                ins.mutation_prob = mutation_prob;
                ins.crossing_prob = cross_prob;
                ins.populacja.Gen_pierwsza(ins);
                for (int j=0; j<iteracje; j++)
                {
                    ins.Obliczanie();
                }
                wynik += ins.Najlepsze.fitnes;
                czas += ins.czas;
                

            }
            wyniki.Add(wynik/20);
            czasy.Add(czas/20);

            Zapisywanie();
            
        }
        public void Zapisywanie() //funkcja zapisująca uśrednienione wyniki dla instancji w folderze
        {
            string folder_w ="p"+populacja.ToString()+"_i"+iteracje.ToString()+"_m"+mutation_prob.ToString()+"_c"+cross_prob.ToString();
            string path = Directory.GetCurrentDirectory();
            string substr = "metaheurystyka";
            int index = path.IndexOf(substr);
            path = path.Substring(0, index);
            path += "Wyniki\\";
            path += folder_w + "\\";
            Directory.CreateDirectory(path);
            path += folder;
            path += ".txt";

            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(wyniki[0].ToString());
            tw.WriteLine(czasy[0].ToString());
            tw.Close();
        }
    }
    
}
