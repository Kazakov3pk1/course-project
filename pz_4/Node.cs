using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_4
{
    class Node
    {
        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node() { }
        public Node(int Value) { value = Value; }
        public Node(int Value, Node Left, Node Right)
        {
            value = Value;
            left = Left;
            right = Right;
        }
    }
}
