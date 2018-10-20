using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slotmachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Erstellen der random Funktion
            Random random = new Random();

            //Variablen
            int numberA = 0;
            int numberB = 0;
            int numberC = 0;
            int token = 10;
            int jackpot = 0;

            //Constante Variablen
            const int MIN_NUMBER = 5;
            const int MAX_NUMBER = 9;

            Game();

            while (token > 0)
            {
                Console.WriteLine("Weiterspielen? (J)a oder (N)ein?");
                ConsoleKeyInfo info = Console.ReadKey();
                Console.CursorLeft = 0;

                //Abfrage der Eingabe
                if (info.Key == ConsoleKey.J)
                {
                    Console.Clear();
                    Game();
                }
                else if (info.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("Herzlichen Glückwunsch, sie haben " + token + " Token erspielt!");
                    Console.WriteLine("Nicht alles auf einmal Ausgeben");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Falsche Eingabe, bitte nur (J) für Ja oder (N) für Nein!");
                }
            }

            Console.Clear();
            Console.WriteLine(numberA + " " + numberB + " " + numberC);
            Console.WriteLine("Schade, keine Token mehr");
            Console.ReadKey();

            void Game()
            {
                //Randomzahlen in A B und C setzen
                numberA = random.Next(MIN_NUMBER, MAX_NUMBER);
                numberB = random.Next(MIN_NUMBER, MAX_NUMBER);
                numberC = random.Next(MIN_NUMBER, MAX_NUMBER);

                //Ausgabe der Zahlen in einer Reihe
                Console.WriteLine(numberA + " " + numberB + " " + numberC);

                //Abfrage sind Zahl A und B, A und C Identisch 
                if (numberA == numberB && numberA == numberC)
                {
                    //Abfrage sind alle Zahlen 7
                    if (numberA == 7 && numberB == 7 && numberC == 7)
                    {
                        Console.WriteLine("Herzlichen Glückwunsch der Jackpot von " + jackpot + " wurde geknackt");
                        token = token + jackpot;
                        jackpot = 0;
                    }
                    token = token + 10;
                }

                //Abfrage sind Zahlen A und B, B und C, und A und C Identisch
                else if (numberA == numberB || numberB == numberC || numberA == numberC)
                {
                    token = token + 5;
                }

                //Ausführung wenn Abfrage 1 und 2 nicht zutreffen - keine Zahlen gleich
                else
                {
                    token = token - 1;
                    jackpot++;
                }

                Console.WriteLine("Du hast jetzt " + token + " Token");
                Console.WriteLine("Der Jackpot beträgt derzeit " + jackpot + " Token");
            }
        }
    }
}
