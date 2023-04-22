using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_4
{
    class SearchTree
    {
        public Node root;
        public void Add(int value)
        {
            root = CreatingTree(root, value);
        }
        public Node CreatingTree(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }
            if (value < root.value)
            {
               root.left = CreatingTree(root.left, value);
            } 
            else if (value > root.value)
            {
               root.right = CreatingTree(root.right, value);
            } 
            return root;
        }
        public int Sum()
        {
            return SumTr(root);
        }
        private int SumTr(Node root)
        {
            if (root == null)
            {
                return 0;
            }

            return root.value + SumTr(root.left) + SumTr(root.right);
        }
        public int NumberInternalNodes()
        {
            return CountingNumberInternalNodes(root);
        }
        public static int CountingNumberInternalNodes(Node root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return 0;
            }

            return 1 + CountingNumberInternalNodes(root.left) + CountingNumberInternalNodes(root.right);
        }
    }
}
