using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Metaheurystyka
{
    public class Instancja
    {
        public List<int> Lista= new List<int>(); //instancja wejściowa algorytmu
        public  int Dlugosc_rozwiazania;
        public  int iteracje_max; //maksymalna ilośc iteracji
        public  int population_size; //rozmiar populacji
        public  double mutation_prob; //prawdopodobieństwo mutacji
        public  double crossing_prob; //prawdopodobieństwo krzyżowania
        public  int iteracja=0; //zmienna przechowująca nr iteracji
        public int r_liczba; //liczba rodziców
        public Populacja populacja = new Populacja();//just populacja
        public Populacja populacja_stara = new Populacja(); //populacja wcześniejsza
        public List<int> sumy = new List<int>();//lista zawierająca wszystkie możliwe sumy uzyskane z instancji, potrzben do losowania rozwiązań
        public int max_value = 20;
        public Rozwiazanie Najlepsze; //Najlepsze otrzymane do tej pory rozwiązanie
        public bool Stop = false;
        public double czas;
        public Instancja(string nazwa)
        {
            Wczytywanie(nazwa);
            crossing_prob = 0.01;
            mutation_prob = 0.05;
            iteracje_max = 100;
            population_size = 20;
            r_liczba= Convert.ToInt32(Math.Ceiling((Convert.ToDouble(population_size) * crossing_prob)));
            if (r_liczba % 2 == 1) r_liczba++;
            Sumy_obliczanie();

        }
        public void Sumy_obliczanie()
        {
            
            for(int i=0; i<Lista.Count()-1; i++)
            {
                if(!sumy.Contains(Lista[i]))
                {
                    sumy.Add(Lista[i]);
                }
                
                for (int j=i+1; j<Lista.Count(); j++)
                {
                    int s = Lista[i] + Lista[j];
                    if(!sumy.Contains(s))
                    {
                        sumy.Add(s);
                    }
                    
                }
            }
            sumy.Sort();
            
        }
        public void Obliczenie_dlugosci_rozwiazania()
        {//Funkcja oblicza jaka jest prawidłowa długość rozwiązania

            for (int x = 1; x < Lista.Count(); x++)
            {
                int y = Convert.ToInt32(Math.Pow(Convert.ToDouble(x), 2)) - x;

                if (y == 2 * Lista.Count())
                {
                    Dlugosc_rozwiazania = x;
                    Console.WriteLine("x: " + x.ToString());
                }
                Console.WriteLine("y: " + y.ToString());
                Console.WriteLine("count: " + Lista.Count().ToString());
            }
        }
        public void Wczytywanie(string nazwa) //Funkcja wczytująca instancję o podanej nazwie, znajdującej się w folderze Instancje
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
                while ((line = reader.ReadLine()) != null)
                {

                    Lista.Add(Int32.Parse(line));

                }
                Obliczenie_dlugosci_rozwiazania();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }


        }
        public void Obliczanie() //funkcja odpowiadająca za działanie całego algorytmu, obliczanie następnych ins itd
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
                populacja.Wybor_rodzicow(this);
                populacja.Crossing_over(this);
                populacja.Najlepsze_Znajdz(this);
                populacja_stara=populacja;
                //stworzenie nowej populacji
                populacja = new Populacja();
                List<Rozwiazanie> p = new List<Rozwiazanie>(populacja_stara.Lista);

                Debug.WriteLine("P :" + p.Count().ToString());

                //Usunięcie losowych osobników aby zrobić miejsce na potomków
                int d;
                
                Random rnd = new Random();
                p=p.Except(populacja_stara.Rodzice_list).ToList() ; //usuwamy rodziców aby nie zostali usunięci w wyniku losowania, zostaną dodani poźniej
                
                Debug.WriteLine("Rodzice :"+populacja_stara.Rodzice_list.Count().ToString());
                Debug.WriteLine("P :" + p.Count().ToString());

               
                Debug.WriteLine("Najlepsze :" + populacja_stara.Najlepsze.Count().ToString());
                p = p.Except(populacja_stara.Najlepsze).ToList(); //usuwamy najlepsze rozwiązania, taik jak w przypadku rodziców
                
                Debug.WriteLine("P :" + p.Count().ToString());
                
                Debug.WriteLine("Potomkowie :" + populacja_stara.Potomkowie.Count().ToString());

                Debug.WriteLine("P :" + p.Count().ToString());

                for (int j=0; j<r_liczba; j++) //usuwamy losowo liczbę rodziców
                {
                    d = rnd.Next(0,p.Count()-1);
                    //Debug.WriteLine("P(d):" + p[d].id.ToString());
                    p.RemoveAt(d);
                }
                //Debug.WriteLine("P :" + p.Count().ToString());

                p.AddRange(populacja_stara.Rodzice_list); //Dodajemy z powrotem rodziców
                p.AddRange(populacja_stara.Najlepsze); //Dodajemy najlepsze rozwiązania
                p.AddRange(populacja_stara.Potomkowie); //dodanie potomków utworzonych z rodziców
                p.Sort((x, y) => x.id.CompareTo(y.id));//sortowanie rozwiązań w populacji względem id
                
                for(int j=0; j<population_size; j++) //ponowne przypisanie id ponieważ po wcześniejszych zmianach istnieje szansa że nie będą się zgadzać
                {
                    p[j].id = j;
                }
                
                //Wykonanie z prawdopodobieństwem mutacji
                //nowa lista rozwiązań trafia do aktualnej populacji
                populacja.Lista = new List<Rozwiazanie>(p);

                //obliczenie liczby mutacji
                int m = Convert.ToInt32(Math.Ceiling(mutation_prob * Convert.ToDouble(population_size)));
                
                for(int j=0; j<m; j++)
                {
                    populacja.Mutacja(this);
                }

                iteracja++;
            stopwatch.Stop();
            czas += stopwatch.Elapsed.TotalMilliseconds;
               
            
        }
    }
}

