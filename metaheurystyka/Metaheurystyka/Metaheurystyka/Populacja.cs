using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Metaheurystyka
{
    public class Populacja
    {
        public  List<Rozwiazanie> Lista= new List<Rozwiazanie>(); //Populacja jest listą rozwiązań
        public List<Rozwiazanie> Rodzice_list; //lista par rodziców
        public List<Rozwiazanie> Potomkowie; //potomkowie stworzeni w wyniku crossing-over z rodziców
        public List<Rozwiazanie> Najlepsze;//najlepsze rozwiązania w populacji, które mają przejść dalej
        public void Gen_pierwsza(Instancja instancja) //funkcja generuje pierwszą populację w sposób losowy
        { 
            Random rnd = new Random();
            int m;
            
            for (int i = 0; i < instancja.population_size; i++)
            {
                List<int> s = new List<int>(instancja.sumy); //Kopia listy sum, z której będziemy losawac oraz usuwać zużyte wartości
                Rozwiazanie r = new Rozwiazanie(i);

                r.Lista.Add(0);
                

                for (int j = 1; j < instancja.Dlugosc_rozwiazania; j++)
                {
                    m = rnd.Next(0, s.Count() - 1);//losujemy element z listy sum

                    r.Lista.Add(s[m]); //Dodajemy wylosowaną wartośc do rozwiązania
                    s.RemoveAt(m); //usuwamy element wykorzystany aby uniknąc powtórzeń
                }
                r.Lista.Sort();

                //jeżeli rozwiązanie o minimalnej długości nie jest dopuszczalne
                //dodajemy losowe elementy z listy sum, dopóki uzyskamy rozwiązanie dopuszczalne
                while (!r.Sprawdzenie(instancja)) 
                {
                    m = rnd.Next(0, s.Count() - 1);
                    r.Lista.Add(s[m]);
                    s.RemoveAt(m);
                    r.Lista.Sort();
                }

                r.Lista.Sort();
                r.FitnesFunction(instancja);

                Lista.Add(r);
                Console.WriteLine(i.ToString() + ": " + string.Join(",", Lista[i].Lista.ToArray()));
            }
            

        }

        
        public void Crossing_over(Instancja instancja)//Funkcja wykonująca crossing-over
        {
            List<int> a1;
            List<int> a2;
            List<int> b1;
            List<int> b2;
            List<int> potomek1;
            List<int> potomek2;
            List<int> rodzic1;
            List<int> rodzic2;
            Potomkowie = new List<Rozwiazanie>();
            int x;
            Random rnd = new Random();
            for (int i = 0; i < Rodzice_list.Count(); i += 2)
            {
                rodzic1 = Rodzice_list[i].Lista;
                rodzic2 = Rodzice_list[i + 1].Lista;
                int dl = Math.Min(rodzic1.Count(), rodzic2.Count());
                x = rnd.Next(1, dl - 2);
                a1 = rodzic1.GetRange(0, x);
                a2 = rodzic2.GetRange(0, x);
                b1 = rodzic1.GetRange(x,rodzic1.Count()-x);
                b2 = rodzic2.GetRange(x,rodzic2.Count()-x);

                potomek1 = a1.Concat(b2).ToList();
                potomek2 = a2.Concat(b1).ToList();

                potomek1= potomek1.Distinct().ToList();
                potomek2 = potomek2.Distinct().ToList();

                potomek1.Sort();
                potomek2.Sort();

                
                Rozwiazanie p = new Rozwiazanie(i, potomek1, instancja);
                Potomkowie.Add(p);
                p = new Rozwiazanie(i+1, potomek2, instancja);
                Potomkowie.Add(p);

                Debug.WriteLine("Rodzic1: "+ Rodzice_list[i].id.ToString() + string.Join(" ", rodzic1.ToArray()));
                Debug.WriteLine("Rodzic2: " + Rodzice_list[i+1].id.ToString()+ string.Join(" ", rodzic2.ToArray()));
                Debug.WriteLine("Potomek1: " + string.Join(" ", potomek1.ToArray())+ Potomkowie[0].Sprawdzenie(instancja).ToString());
                Debug.WriteLine("Potomek2: " + string.Join(" ", potomek2.ToArray())+ Potomkowie[1].Sprawdzenie(instancja).ToString());

                while(!Potomkowie[i].Sprawdzenie(instancja))
                {
                    Potomkowie[i].Naprawianie(instancja);
                }
                while (!Potomkowie[i+1].Sprawdzenie(instancja))
                {
                    Potomkowie[i+1].Naprawianie(instancja);
                }

                Potomkowie[i].FitnesFunction(instancja);
                Potomkowie[i + 1].FitnesFunction(instancja);
            }
        } 

        public void Wybor_rodzicow(Instancja ins)
        
        {
            //Ruletka 
            //Najpierw znajdujemy, minimum, maximum oraz sumę wszystkich fitness dla każdego rozwiązania
            double min = ins.populacja.Lista[0].fitnes;
            double max = ins.populacja.Lista[0].fitnes;
            double sum = 0;

            List<double> lista = new List<double>(); //Lista w której zapisane zostają obliczone wartości fitness/suma dla każdego rozwiązania
            double[][] table = new double[ins.population_size][]; //Lista znormalizowana od 0-1, pomnożone razy 100 i zamienione na int
            double[][] prob = new double[ins.population_size][];
            int[][] probabilities = new int[ins.population_size][]; //Lista obliczonych prawdopodobieństw do ruletki wyrażona w procentach
            foreach (Rozwiazanie r in ins.populacja.Lista)
            {
                if (r.fitnes < min)
                {
                    min = r.fitnes;
                }
                if (r.fitnes > max)
                {
                    max = r.fitnes;
                }
                sum += r.fitnes;
            }
            min = min / sum;
            max = max / sum;

            //Obliczanie fitness/suma dla każdego rozwiązania
            for (int i = 0; i < ins.populacja.Lista.Count(); i++)
            {
                double x = ins.populacja.Lista[i].fitnes / sum;
                lista.Add(x);
            }
            //Normalizacja wartości od 0-1
            for (int i = 0; i <ins.populacja.Lista.Count(); i++)
            {
                double y = (lista[i] - min) / (max - min); //Wartość znormalizowana

                table[i] = new double[] { i, y };
            }

            //sortowanie tablicy znormalizowanych wartości rosnąco
            Comparer<double> comparer = Comparer<double>.Default;
            Array.Sort<double[]>(table, (x, y) => comparer.Compare(x[1], y[1]));

            for (int i = 0; i <ins.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(",", table[i]));
            }

            prob[0] = table[0];
            for (int i = 1; i < ins.population_size; i++)
            {
                double x = prob[i - 1][1] + table[i][1];
                prob[i] = new double[] { table[i][0], x };
            }

            Console.WriteLine("------------Probabilities-----------");
            for (int i = 0; i < ins.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(", ", prob[i]));
            }
            //converting probabilities *100 and to int
            for (int i = 0; i <ins.population_size; i++)
            {
                int y = Convert.ToInt32(prob[i][1]*100);
                int x = Convert.ToInt32(prob[i][0]);
                probabilities[i] = new int[] { x, y };
            }
            Console.WriteLine("------------Probabilities*100-----------");
            for (int i = 0; i < ins.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(", ", probabilities[i]));
            }
            //Normalizing converted probabilities from 0-100
            int minimum = probabilities[0][1];
            int maksimum = probabilities[ins.population_size - 1][1];
            for (int i = 0; i <ins.population_size; i++)
            {
                probabilities[i][1] = (probabilities[i][1] - minimum) * 100 / (maksimum - minimum);
            }
            Console.WriteLine("------------Probabilities*100 normalized-----------");
            for (int i = 0; i < ins.population_size; i++)
            {
                Console.WriteLine(i.ToString() + ": " + string.Join(", ", probabilities[i]));
            }
            //Losowanie rodziców
            Random rnd = new Random();

            Rodzice_list = new List<Rozwiazanie>();
            List<int> indexes = new List<int>();
            while (indexes.Count()<ins.r_liczba)
            {
                int a = rnd.Next(1, 100);
                for (int j = 0; j < ins.population_size; j++)
                {
                    if (a < probabilities[j][1])
                    {
                        int index = probabilities[j][0];
                        if (indexes.Count() == 0 || !indexes.Contains(index))
                        {
                            Rodzice_list.Add(ins.populacja.Lista[index]);
                            indexes.Add(index);
                        }
                      
                         break;
                    }
                }
            }
            Debug.WriteLine("------------Rodzice-----------");
            for (int i = 0; i < ins.r_liczba; i++)
            {
                Debug.WriteLine(Rodzice_list[i].id.ToString() + ": " +
                    string.Join(", ", Rodzice_list[i].Lista));
            }

        }

        public void Mutacja(Instancja instancja)
        {
            //wybieramy losowe rozwiązanie na którym przeprowadzamy mutację
            Random rnd = new Random();
            int x = rnd.Next(0, Lista.Count()-1);

            Rozwiazanie r = Lista[x]; //Rozwiązanie wybrane do mutacji

            List<int> l = new List<int>(r.Lista); //kopia listy rozwiązania
            List<int> s = new List<int>(instancja.sumy); //kopia listy sum

            //wybieramy losowe miejsce do wprowadzenia zmiany
            int j= rnd.Next(1, r.Lista.Count() - 1);

            //50% szansy na usunięcie elementu i 50% szansy na zmianę elementu
            int d = rnd.Next(0, 100);
            //int d = 100;
            if(d<=50)
            {
                //wybieramy losową wartośc do wstawienia w tym miejscu
                int y = rnd.Next(0, s.Count()-1);
                //wstawiamy losową wartość z listy sum
                r.Lista[j] = s[y];
                s.RemoveAt(y); //usuwamy tą wartość z listy sum żeby nie testować tej samej opcji kilka razy

                //Sprawdzamy losowe, możliwe do wstawienia wartości, dopóki nie otrzymamy rozwiązania dopuszczalnego
                while (!r.Sprawdzenie(instancja)&&s.Count()!=0)
                {
                    r.Lista = new List<int>(l); //przywracamy listę rozwiązania do stanu pierwotnego

                    //ponownie lodujemy wartość do wsatwienia w miejscu mutacji
                    y = rnd.Next(0, s.Count()-1);
                    r.Lista[j] = s[y];
                    s.RemoveAt(y);
                }

            }
            else //W tym przypadku usuwamy losową wartość z rozwiązania
            {
                List<int> index = new List<int>();//lista do losowania indeksów
                for (int i = 1; i < r.Lista.Count(); i++) index.Add(i);

                //usuwamy losową wartośc
                r.Lista.RemoveAt(j);
                index.RemoveAt(j);//usuwamy ten indeks z listy, aby uniknąć sprawdzania tej samej wartości kilka razy

                //Sprawdzamy kolejne losowe wartości dopóki nie  uzyskamy rozwiązania dopuszczalnego
                while (!r.Sprawdzenie(instancja)&&index.Count()!=0)
                {
                    r.Lista = new List<int>(l); //przywracamy listę rozwiązania do stanu pierwotnego

                    j = rnd.Next(0, index.Count() - 1); //losowanie indeksu 
                    r.Lista.RemoveAt(index[j]); 
                    index.RemoveAt(j);
                }
            }

            Lista[x] = r;//Listę którą otrzymaliśmy w wyniku mutacji zapisujemy do rozwiązania
            Debug.WriteLine("Sprawdzenie poprawności mutacja :");
            Debug.WriteLine(Lista[x].Sprawdzenie(instancja));

            //Dopóki to rozwiązanie nie jest dopuszczalne, to je naprawiamy
            while(!Lista[x].Sprawdzenie(instancja))
            {
                Lista[x].Naprawianie(instancja);
            }

            Lista[x].FitnesFunction(instancja); //Liczymy wartośc funkcji przystosowania dla otrzymanego rozwiązania


        }

        public void Najlepsze_Znajdz(Instancja ins)
        {
            Najlepsze = new List<Rozwiazanie>();
            List<Rozwiazanie> l = new List<Rozwiazanie>(Lista); //Kopia listy rozwiązań
            l.Sort((x, y) => y.fitnes.CompareTo(x.fitnes)); //sortowanie tej listy po wartości funkcji przystosowania malejąco
            
            for(int i=0; i<ins.r_liczba; i++) //najlepszych rozwiązań ma być tyle co rodziców
            {
                Najlepsze.Add(Lista[l[i].id]);
            }

            //Sprawdzenie czy najlepsze rozwiązanie z tej iteracji jest lepsze niż najlepsze rozwiązanie podczas obliczeń
            if(ins.Najlepsze==null || Najlepsze[0].fitnes>ins.Najlepsze.fitnes)
            {
                ins.Najlepsze = Najlepsze[0];
            }

            Najlepsze = Najlepsze.Except(Rodzice_list).ToList(); //Usunięcie elementów które znajdują się również w liście rodziców

        }
    }
}
