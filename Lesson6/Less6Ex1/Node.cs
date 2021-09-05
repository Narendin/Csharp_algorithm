using System.Collections.Generic;

namespace Less6Ex1
{
    public class Node
    {
        public int Value { get; set; }
        public List<Node> Nodes { get; set; }

        public Node(int value)
        {
            Value = value;
            Nodes = new List<Node>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return Value == ((Node)obj).Value;
        }
    }
}