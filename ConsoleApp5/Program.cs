using System;

namespace DOGON
{
    class Program
    {
        static void Main(string[] args)
        {
            Class2 class1 = new Class2();
            class1.Setup(class1.endgame);
            while (!class1.endgame)
            {
                class1.Draw();
                class1.Input_Logic();
            }
            Console.ReadKey();
        }
    }
}
