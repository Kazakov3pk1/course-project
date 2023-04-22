using System;

namespace pz_3
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedTree balans = new BalancedTree();

            balans.Add(4);
            balans.Add(-2);
            balans.Add(3);
            balans.Add(-5);
            balans.Add(1);
            balans.Add(7);
            balans.Add(-2);

            Console.WriteLine("Дерево: ");
            balans.PBalancedTree();
        
            Console.WriteLine($"\nСреднее арифметическое: {balans.Average()}");
        
            int PosC = 0;
            int NegC = 0;
            balans.CPosAndNeg(out PosC, out NegC);
            Console.WriteLine($"Количество положительных узлов: {PosC}");
            Console.WriteLine($"Количество отрицательных узлов: {NegC}");


            Console.ReadLine();
        }

       
    }
}
