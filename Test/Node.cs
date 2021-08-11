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

        internal void Move(Vector2D translation)
        {
            if (this.Children != null)
            {
                foreach (Node childNode in this.Children)
                {
                    childNode.Move(translation);
                }
            }

            this.Position += translation;
        }
    }
}
