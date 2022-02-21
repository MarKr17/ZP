using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaheurystyka
{
    public class Rozwiazanie
    {

        public List<int> Lista; //Lista przechowując wierzchołki rozwiązania
        public double fitnes; //Wartość funckcji przystosowania dla danego rozwiązania
        public int id;

        public Rozwiazanie(int ID)
        {
            Lista = new List<int>();
            id = ID;
        }
        public Rozwiazanie(int ID, List<int> list, Instancja instancja)
        {
            id = ID;
            Lista = list;
            FitnesFunction(instancja);
        }
        public void FitnesFunction(Instancja instancja) //Funkcja obliczająca wartość funkcji przystosowania dla każdego rozwiązania
        {
            //Funkcja przystosowania = długość_rozwiązania_idealnego/długośc rozwiązania badanego 
            //Długość rozwiązania idealnego jest obliczana przy wczytywaniu instancji na podstawie wzoru podanego na laboratorium

            fitnes = Convert.ToDouble(instancja.Dlugosc_rozwiazania) / Convert.ToDouble(Lista.Count()); //Przyjęta funkcja przystosowania
            fitnes = Math.Round(fitnes, 2);
            
            //wartość fitnes przyjmuje wartości od 0(najgorsze) do 1 najlepsze
            fitnes = fitnes * 100; //Dla lepszej czytelności wartosc jest mnożona 100 razy
            
        }

       public bool Sprawdzenie(Instancja ins) //funkcja sprawdzająca czy zadanie jest dopuszczalne
        {
            
            List<int> kopia = new List<int>(ins.Lista); //kopia listy zawierającej instancję wejściową
            for(int i=0; i<Lista.Count()-1; i++)
            {
                int dif = 0;//różnica pomiędzy danymi elementami rozwiązania
                for (int j=i+1; j<Lista.Count(); j++)
                {
                    dif = Lista[j] - Lista[i]; //obliczenie odcinka
                    if(kopia.Contains(dif)) 
                    {
                        //jeżeli odcinek znajduję się w kopii instancji, to usuwamy go 
                        kopia.Remove(dif);
                    }
                    if(kopia.Count()==0)
                    {
                        return true;
                    }
                }
            }
            if(kopia.Count()==0)
            {
                //jeżeli wszystkie elementy instancji są reprezentowane w odcinkach utworzonych z rozwiązania
                //wtedy kopia instanmcji jest pusta, oznacza to że sprawdzane rozwiązanie jest dopuszczalne
                return true;
            }
            else
            {
                return false;
            }

            
        }
        
        public void Naprawianie(Instancja ins) //funkcja która naprawia rozwiązanie, otrzymnane w wyniku krzyżowania aby dalej było dopuszczalne
        {
            Random rnd = new Random();
            List<int> s = new List<int>(ins.sumy);
            int m = rnd.Next(0, s.Count()-1);

            List<int> l = new List<int>(Lista);//kopia listy składającej się na rozwiązanie
            
            while(Lista.Contains(s[m]))
            {
                m = rnd.Next(0, s.Count()-1);
            }
            Lista.Add(s[m]);
            s.RemoveAt(m);
            Lista.Sort();

            if (!this.Sprawdzenie(ins))
            {
                Lista.Remove(s[m]);
                s.RemoveAt(m);
                m = rnd.Next(0, s.Count() - 1);
                while (Lista.Contains(s[m]))
                {
                    m = rnd.Next(0, s.Count()-1);
                }
               
                Lista.Add(s[m]);
               
                Lista.Sort();
            }
            
        }
    }
}
