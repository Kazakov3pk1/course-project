using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_3
{
    class BalancedTree
    {
        public Node root;

        // метод для добавления значения в дерево
        public void Add(int value)
        {
            root = CreateBalancedTree(root, value);
        }

        private Node CreateBalancedTree(Node current, int value)
        {
            if (current == null)
            {
                return new Node { value = value };
            }

            if (value < current.value)
            {
                current.left = CreateBalancedTree(current.left, value);
            }
            else
            {
                current.right = CreateBalancedTree(current.right, value);
            }

            return current;
        }
        public void PBalancedTree()
        {
            PrintBalancedTree(root);
        }


        private void PrintBalancedTree(Node current)
        {
            if (current == null)
                return;


            Console.Write(current.value + " ");

            // Рекурсивно вывести левое и правое поддеревья
            PrintBalancedTree(current.left);
            PrintBalancedTree(current.right);
        }

        // метод для нахождения среднего арифметического
        public float Average()
        {
            return (float)Sum(root) / CountNodes(root);
        }

        private int Sum(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            return current.value + Sum(current.left) + Sum(current.right);
        }

        private int CountNodes(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            return 1 + CountNodes(current.left) + CountNodes(current.right);
        }

        // метод для подсчета количества узлов с положительными и отрицательными значениями
        public void CPosAndNeg(out int PosC, out int NegC)
        {
            PosC = CPos(root);
            NegC = CNeg(root);
        }

        private int CPos(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            if (current.value > 0)
            {
                return 1 + CPos(current.left) + CPos(current.right);
            }

            return CPos(current.left) + CPos(current.right);
        }

        private int CNeg(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            if (current.value < 0)
            {
                return 1 + CNeg(current.left) + CNeg(current.right);
            }

            return CNeg(current.left) + CNeg(current.right);
        }
    }
}
