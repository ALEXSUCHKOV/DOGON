using System;

namespace DOGON
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            class1.Setup(class1.gameOver);
            while (!class1.gameOver)
            {
                class1.Draw();
                class1.Input_Logic();
            }
            Console.ReadKey();
        }
    }
}
