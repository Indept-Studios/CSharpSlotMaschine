using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSlotMaschine
{
    class Program
    {
        //Variablen
        public static int NumberA = 0;
        public static int NumberB = 0;
        public static int NumberC = 0;
        public static int Token = 2;

        //Erstellen der random Funktion
        static Random random = new Random();


        //Hier beginnt dann die "Main"
        static void Main(string[] args)
        {
            Game();

            while (Token > 0)
            {
                Console.WriteLine("Weiterspielen? (J)a oder (N)ein?");
                ConsoleKeyInfo info = Console.ReadKey();
                Console.CursorLeft = 0;

                if (info.Key == ConsoleKey.J)
                {
                    Game();
                }
                else if (info.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("Herzlichen Glückwunsch, sie haben " + Token + " Token erspielt!");
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
            Console.WriteLine(NumberA + " " + NumberB + " " + NumberC);
            Console.WriteLine("Schade, keine Token mehr");
            Console.ReadKey();
        }

        private static void Game()
        {
            //Randomzahlen in A B und C setzen
            NumberA = random.Next(1, 10);
            NumberB = random.Next(1, 10);
            NumberC = random.Next(1, 10);

            // Ausgabe der Zahlen in einer Reihe
            Console.WriteLine(NumberA + " " + NumberB + " " + NumberC);

            if (NumberA == NumberB && NumberA == NumberC)
            {
                Token = Token + 10;
            }
            else if (NumberA == NumberB || NumberB == NumberC || NumberA == NumberC)
            {
                Token = Token + 5;
            }
            else
                Token = Token - 1;

            Console.WriteLine("Du hast jetzt " + Token + " Token");
        }
    }
}
