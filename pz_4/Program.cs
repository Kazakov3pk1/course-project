using System;

namespace pz_4
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchTree st = new SearchTree();
            Random random = new Random();
            for (int i = 1; i < 10; i++)
            {
                int value = random.Next(10, 1001);
                st.Add(value);
                Console.WriteLine("Значение узла дерева = {1}", i, value);
            }
            int s = st.Sum();
            Console.WriteLine($"Сумма значений информационных полей: {s}");
            int c = st.NumberInternalNodes();
            Console.WriteLine($"Количество внутренних узлов: {c}");
        }
    }
}