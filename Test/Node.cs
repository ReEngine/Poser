// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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

        internal void Move(double translation)
        {
            if (this.Parent != null)
            {
                double limbLength = (this.Position - this.Parent.Position).Length;
                if (this.Children != null)
                {
                    foreach (Node childnode in this.Children)
                    {
                        //     childnode.Move(translation);
                    }
                }

                this.Position = this.Parent.Position + new Vector2D(limbLength * Math.Cos(translation), limbLength * Math.Sin(translation));
            }
        }
    }
}
