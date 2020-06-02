using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DOGON
{
    class Class1
    {
        public bool gameOver = false;
        int schet = 0;
        int x;
        int y;
        int celX, celY;
        const int S = 20;
        const int V = 20;

        public void Perem()// Перемешение цели при нажимание кнопки
        {
            Random celx = new Random();
            Random cely = new Random();
            celX = celx.Next(4, 10);
            celY = cely.Next(4, 10);
        }
        public bool Setup(bool gameOver)// Заданые переменные
        {
            gameOver = false;
            x = S / 2 - 1;
            y = V / 2 - 1;
            Random celx = new Random();
            Random cely = new Random();
            celX = celx.Next(0, S - 1);
            celY = cely.Next(0, V - 1);
            Console.WriteLine();
            return gameOver;
        }
        public void Draw()// Карта и персонажи
        {
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("W - Вверх");
            Console.WriteLine("S - Вниз");
            Console.WriteLine("D - Вправо");
            Console.WriteLine("A - Влево");
            for (int i = 0; i < V + 1; i++)
                Console.Write("#");
            Console.WriteLine();

            for (int i = 0; i < S; i++)
            {
                for (int j = 0; j < S; j++)
                {
                    if (j == 0 || j == S - 1)
                        Console.Write("#");
                    if (i == y - 1 && j == x - 1)
                        Console.Write("@");
                    else if (i == celY - 1 && j == celX - 1)
                        Console.Write("X");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            for (int j = 0; j < S + 1; j++)
                Console.Write("#");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Вы поймали цель " + schet + " раз(а)");
            Console.WriteLine();
        }
        public void Input_Logic()// Кнопки управления и логика игры
        {
            ConsoleKeyInfo knopki = Console.ReadKey();
            switch (knopki.Key)
            {
                case ConsoleKey.W:
                    if (y > 0)
                    {
                        y--;
                        Perem();
                    }
                    break;

                case ConsoleKey.S:
                    if (y > 0)
                    {
                        y++;
                        Perem();
                    }
                    break;

                case ConsoleKey.D:
                    if (x > 0)
                    {
                        x++;
                        Perem();
                    }
                    break;

                case ConsoleKey.A:
                    if (x > 0)
                    {
                        x--;
                        Perem();
                    }
                    break;

                case ConsoleKey.B:
                    if (!gameOver)
                    { gameOver = true; }
                    break;
            }
            if (x > 19 || x < 0 || y > 21 || y < 0)
            {
                string konec = "B";
                string povtor = "E";
                Console.WriteLine("Вы врезались в стену!!! Если хотите повторить попытку нажмите E/e или У/у ");
                Console.WriteLine("Если не хотите играть нажмите B");
                Convert.ToString(Console.ReadLine());
                if ((povtor == "E") || (povtor == "e") || (povtor == "У") || (povtor == "у"))
                {
                    povtor = Console.ReadLine();
                    schet = 0;
                }
                else if (konec == "B")
                {
                    gameOver = true;
                }
            }
            if ((x == celX && y == celY) || (y == celX && x == celY))
            {
                schet = schet + 1;
                Random celx = new Random();
                Random cely = new Random();
                celX = celx.Next(1, S);
                celY = cely.Next(1, V);
                Console.ReadKey(true);
            }
        }
    }
}