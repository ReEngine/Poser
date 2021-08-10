using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Node
    {
        public Vector2D Position { get; set; }
        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public Node(Node parent = null)
        {
            Parent = parent;
        }
        public Node(Vector2D position, Node parent = null)
        {
            Parent = parent;
            Position = position;
        }

    }
}
