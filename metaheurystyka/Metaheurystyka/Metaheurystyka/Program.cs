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
        public static List<Rozwiazanie> Populacja; //Populacja jest listą rozwiązań
        public static List<Rozwiazanie> Populacja_stara;
        public static int Dlugosc_rozwiazania;
        public static int iteracje_max; //maksymalna ilośc iteracji
        public static int population_size; //rozmiar populacji
        public static double mutation_prob; //prawdopodobieństwo mutacji
        public static double crossing_prob; //prawdopodobieństwo krzyżowania
        public static List<Rozwiazanie> Rodzice_list; //lista par rodziców
        public static int iteracja; //zmienna przechowująca nr iteracji
    }
    public class Instancja
    {
        public List<int> Lista;

        public Instancja()
        {
            Lista = new List<int>();
        }
    }
    public class Rozwiazanie
    {
        public List<int> Lista; //Lista przechowując wierzchołki rozwiązania
        public double fitnes; //Wartość funckcji przystosowania dla danego rozwiązania
        public  int id;

        public Rozwiazanie(int ID)
        {
            Lista = new List<int>();
            id = ID;
        }
        public void FitnesFunction() //Funkcja obliczająca wartość funkcji przystosowania dla każdego rozwiązania
        {
            List<int> roznice = new List<int>();
            int r;
            int x = 0;
            for(int i=0; i<Lista.Count(); i++) //Obliczanie wszystkich możliwych ,,odcinków'' uzyskanych z rozwiązania
            {
                for(int j=i+1; j<Lista.Count(); j++)
                {
                    r = Lista[j] - Lista[i];
                    roznice.Add(r); //Odcinki zapisywane są do listy roznice
                }
            }
            foreach(int p in roznice) //Liczymy, ile z obliczonych odcinków znajduje się w instancji wejściowej
            {
                if (Lista.Contains(p))
                {
                    x++;
                }
            }

            fitnes = x * Convert.ToDouble(Global.Dlugosc_rozwiazania) / Convert.ToDouble(Lista.Count()); //Przyjęta funkcja przystosowania
            fitnes=Math.Round(fitnes, 2);
        }
    }
    static class Wczytywanie_instancji
    {
       public static void Obliczenie_dlugosci_rozwiazania()
        {//Funkcja oblicza jaka jest prawidłowa długość rozwiązania

            for(double x=1; x<Global.instancja.Lista.Count(); x++)
            {
                double y = Math.Pow(x, 2) - x;

                if(y==2*Global.instancja.Lista.Count())
                {
                    Global.Dlugosc_rozwiazania = (int)x;
                    Console.WriteLine("x: " + x.ToString());
                }
                Console.WriteLine("y: " + y.ToString());
                Console.WriteLine("count: " + Global.instancja.Lista.Count().ToString());
            }
        }
       public static void Wczytywanie(string nazwa) //Funkcja wczytująca instancję o podanej nazwie, znajdującej się w folderze Instancje
        {
            string path = Directory.GetCurrentDirectory();
            string substr = "metaheurystyka";
            int index = path.IndexOf(substr);
            path = path.Substring(0, index);
            path += "Instancje\\";
            path += nazwa;
            path += ".txt";
            
            string line;
            try
            {
                StreamReader reader = new StreamReader(path);
                Global.instancja = new Instancja();
                while ((line = reader.ReadLine()) != null)
                {
                    
                    Global.instancja.Lista.Add(Int32.Parse(line));
                    
                }
                Obliczenie_dlugosci_rozwiazania();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            
        }
    }
    static class Pierwsza_populacja //Klasa do generowania pierwszej populacji
    {
        //pierwsza populacja generowana jest w sposób losowy
        public static void Generuj()
        {
            Global.Populacja = new List<Rozwiazanie>();

            Random rnd = new Random();
            int m;
            for(int i=0; i<Global.population_size; i++)
            {
                Rozwiazanie r = new Rozwiazanie(i);
               
                r.Lista.Add(0);
                m = rnd.Next(1, Global.instancja.Lista.Last());

                for(int j=1; j<Global.instancja.Lista.Count(); j++)
                {
                    while(r.Lista.Contains(m))
                    {
                        m = rnd.Next(1, Global.instancja.Lista.Last());
                    }
                    r.Lista.Add(m);
                }
                r.Lista.Add(Global.instancja.Lista.Last());
                r.Lista.Sort();
                r.FitnesFunction();

                Global.Populacja.Add(r);
                Console.WriteLine(i.ToString() + ": " + string.Join(",", Global.Populacja[i].Lista.ToArray()));
            }

        }
    }
    static class Rodzice
    {
        public static void Wybor()
        {
            //Ruletka 
            //Najpierw znajdujemy, minimum, maximum oraz sumę wszystkich fitness dla każdego rozwiązania
            double min=Global.Populacja[0].fitnes;
            double max=Global.Populacja[0].fitnes;
            double sum=0;

            List<double> lista=new List<double>(); //Lista w której zapisane zostają obliczone wartości fitness/suma dla każdego rozwiązania
            double[][] table = new double[Global.population_size][]; //Lista znormalizowana od 0-1, pomnożone razy 100 i zamienione na int
            double[][] prob= new double[Global.population_size][];
            int[][] probabilities = new int[Global.population_size][]; //Lista obliczonych prawdopodobieństw do ruletki wyrażona w procentach
            foreach(Rozwiazanie r in Global.Populacja)
            {
                if(r.fitnes<min)
                {
                    min = r.fitnes;
                }
                if(r.fitnes>max)
                {
                    max = r.fitnes;
                }
                sum += r.fitnes;
            }
            min = min / sum;
            max = max / sum;
            
            //Obliczanie fitness/suma dla każdego rozwiązania
            for(int i=0; i<Global.Populacja.Count(); i++)
            {
                double x = Global.Populacja[i].fitnes / sum;
                lista.Add(x);
            }
            //Normalizacja wartości od 0-1
            for(int i=0; i<Global.Populacja.Count(); i++)
            {
                double y = (lista[i] - min) / (max - min); //Wartość znormalizowana
                
                table[i] = new double[] {i,y};
            }

            //sortowanie tablicy znormalizowanych wartości rosnąco
            Comparer<double> comparer = Comparer<double>.Default;
            Array.Sort<double[]>(table, (x, y) => comparer.Compare(x[1], y[1]));

            for(int i=0; i<Global.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(",", table[i]));
            }

            prob[0] = table[0];
            for(int i=1; i < Global.population_size; i++)
            {
                double x = prob[i - 1][1] + table[i][1];
                prob[i] = new double[] {table[i][0],x };
            }
           
            Console.WriteLine("------------Probabilities-----------");
            for (int i = 0; i < Global.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(", ", prob[i]));
            }
            //converting probabilities *100 and to int
            for (int i = 0; i < Global.population_size; i++)
            {
                int y = Convert.ToInt32(prob[i][1] * 100);
                int x = Convert.ToInt32(prob[i][0]);
                probabilities[i] = new int[] { x, y };
            }
            Console.WriteLine("------------Probabilities*100-----------");
            for (int i = 0; i < Global.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(", ", probabilities[i]));
            }
            //Normalizing converted probabilities from 0-100
            int minimum = probabilities[0][1];
            int maksimum = probabilities[Global.population_size - 1][1];
            for(int i=0; i<Global.population_size; i++)
            {
                probabilities[i][1] = (probabilities[i][1] - minimum)*100 / (maksimum - minimum);
            }
            Console.WriteLine("------------Probabilities*100 normalized-----------");
            for (int i = 0; i < Global.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(", ", probabilities[i]));
            }
            //Losowanie rodziców
            Random rnd = new Random();
            int l = 0;
            double rliczba = Convert.ToDouble(Global.population_size) * Global.crossing_prob;
            int rodzice_liczba = Convert.ToInt32(Math.Ceiling(rliczba));
            if (rodzice_liczba % 2 == 1) rodzice_liczba++;

            Global.Rodzice_list = new List<Rozwiazanie>();
            List<int> indexes = new List<int>();
            for(int i=0; i<rodzice_liczba; i++)
            {
                int a = rnd.Next(1, 10);
                for(int j=0; j<Global.population_size; j++)
                {
                    if(a<probabilities[j][1])
                    {
                        int index = probabilities[j][0];
                        if(indexes.Count()==0 || !indexes.Contains(index))
                        Global.Rodzice_list.Add(Global.Populacja[index]);
                        break;
                    }
                }
            }
            Console.WriteLine("------------Rodzice-----------");
            for (int i = 0; i < rodzice_liczba; i++)
            {
                Console.WriteLine(Global.Rodzice_list[i].id.ToString() + ": " + string.Join(", ", Global.Rodzice_list[i].Lista));
            }

        }
        
    }
    static class CrossingOver
    {
        public static void Wykonaj()
        {
            string a1;
            string a2;
            string b1;
            string b2;
            string potomek1;
            string potomek2;
            string rodzic1;
            string rodzic2;
            int x;
            Random rnd = new Random();
            for (int i = 0; i < Global.Rodzice_list.Count(); i += 2)
            {
                rodzic1 = string.Join(" ", Global.Rodzice_list[i].Lista.ToArray());
                rodzic2 = string.Join(" ", Global.Rodzice_list[i+1].Lista.ToArray());
                x = rnd.Next(1, rodzic1.Length-2);
                a1 = rodzic1.Substring(0,x);
                a2 = rodzic2.Substring(0, x);
                b1 = rodzic1.Substring(x);
                b2 = rodzic2.Substring(x);

                potomek1 = a1 + b2;
                potomek2 = a2 + b1;

                Console.WriteLine("Rodzic1: " + rodzic1);
                Console.WriteLine("Rodzic2: " + rodzic2);
                Console.WriteLine("Potomek1: " + potomek1);
                Console.WriteLine("Potomek2: " + potomek2);
            }
        }
        
    }
    static class Obliczanie
 
    {
        public static void Rozpocznij()
        {
            for(int i=0; i<2; i++)
            {
                
                Global.iteracja = i;
                Global.Populacja_stara = Global.Populacja;
                Global.Populacja = new List<Rozwiazanie>();
                CrossingOver.Wykonaj();

                
            }
        }
    }
}
