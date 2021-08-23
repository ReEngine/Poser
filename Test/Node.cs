namespace Test
{
    using System;
    using System.Collections.Generic;

    internal class Node
    {
        public Node(Node parent = null)
        {
            this.Parent = parent;
            if (this.Parent != null)
            {
                this.Parent.Children.Add(this);
            }
        }

        public Node(Vector2D position, Node parent = null)
        {
            this.Parent = parent;
            this.Position = position;
        }

        public Vector2D Position { get; set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; set; } = new List<Node>();

        internal void Move(double angle)
        {
            Vector2D a = this.Parent.Position - this.Position;
            Vector2D b = this.Parent.Parent.Position - this.Parent.Position;

            //angle = angle - Program.GetAngle(a, b);

            double limbLength = (this.Position - this.Parent.Position).Length;
            if (this.Children != null)
            {
                foreach (Node childnode in this.Children)
                {
                    // childnode.Move(angle);
                }
            }

            this.Position = this.Parent.Position + new Vector2D(limbLength * Math.Sin(angle), limbLength * Math.Cos(angle));

        }

    }
}
