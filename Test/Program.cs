namespace Test
{
    using System;
    using SFML.Graphics;
    using SFML.System;
    using SFML.Window;

    internal class Program
    {
        private const uint ResMult = 1;
        private static Font font = new(Properties.Resources.DotGothic16_Regular);

        private static uint sWidth = VideoMode.DesktopMode.Width;
        private static uint sHeight = VideoMode.DesktopMode.Height;

        private static uint width = SWidth / ResMult;
        private static uint height = SHeight / ResMult;
        private static RenderWindow window = new(new VideoMode(SWidth, SHeight), "Pixels");

        private static RenderTexture graphLinesTexture = new(Width / 10 * 4, Height - (Height / 10));

        private static RenderTexture graphNodesTextures = new(Width / 10 * 4, Height - (Height / 10));

        public static uint Height { get => height; set => height = value; }

        public static uint SHeight { get => sHeight; set => sHeight = value; }

        public static uint Width { get => width; set => width = value; }

        public static uint SWidth { get => sWidth; set => sWidth = value; }

        public static RenderWindow Window { get => window; set => window = value; }

        public static Font Font
        {
            get => font; set => font = value;
        }

        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }
            double[] origin = new double[]
            {
                0.5156606580054994, 0.5389367358015656,
                0.5494335791381163, 0.5591362968115753,
                0.505949948896629, 0.49268546704503946,
                0.48006104341570305, 0.5610029474458118,
                0.45475960136118304, 0.5225187963671678,
                0.48529673454152067, 0.6016100326338628,
                0.34147617237377503, 0.7718396869736165,
                0.19564083924567913, 0.9414761166195745,
                0.04992565641975702, 1.0,
                0.0, 0.9962884428697393,
                0.014004897634823182, 0.9764423634911831,
                0.03446538830338202, 0.5339872495718775,
                0.3774140291135426, 0.49497417697739937,
                0.3589448926411053, 0.4695446861089617,
                0.3562402563726819, 0.4623051890155676,
                0.370826298624516, 0.46873532096438786,
                0.31165213541840414, 0.14988756958826552,
                0.13190473930060523, 0.13418044842782434,
                0.13613800356153594, 0.1252820743633083,
                0.12319972292448635, 0.12146354265082623,
                0.14400226774068986, 0.12715668116388912,
                0.17516830326654556, 0.16888302962577945,
                0.22200274829946, 0.23887143787429918,
                0.12882326981007206, 0.3455715676016447,
                0.02770647553467041, 0.4347774763037112,
                0.004974932950819164, 0.46155835492959923,
                0.0, 0.4647668088544966,
                0.007948972132892985, 0.45728045283189034,
                0.5331726890890015, 0.5275330412189897,
                0.7379913608919004, 0.7297902524485291,
                0.9119670379844514, 0.8981358000333225,
                0.9308422056162358, 0.9184586339794437,
                1.0, 0.9724952882169435,
            };

            double[] points = new double[]
            {
                0.5156606580054994, 0.5389367358015656,
                0.5494335791381163, 0.5591362968115753,
                0.505949948896629, 0.49268546704503946,
                0.48006104341570305, 0.5610029474458118,
                0.45475960136118304, 0.5225187963671678,
                0.48529673454152067, 0.6016100326338628,
                0.34147617237377503, 0.7718396869736165,
                0.19564083924567913, 0.9414761166195745,
                0.04992565641975702, 1.0,
                0.0, 0.9962884428697393,
                0.014004897634823182, 0.9764423634911831,
                0.03446538830338202, 0.5339872495718775,
                0.3774140291135426, 0.49497417697739937,
                0.3589448926411053, 0.4695446861089617,
                0.3562402563726819, 0.4623051890155676,
                0.370826298624516, 0.46873532096438786,
                0.31165213541840414, 0.14988756958826552,
                0.13190473930060523, 0.13418044842782434,
                0.13613800356153594, 0.1252820743633083,
                0.12319972292448635, 0.12146354265082623,
                0.14400226774068986, 0.12715668116388912,
                0.17516830326654556, 0.16888302962577945,
                0.22200274829946, 0.23887143787429918,
                0.12882326981007206, 0.3455715676016447,
                0.02770647553467041, 0.4347774763037112,
                0.004974932950819164, 0.46155835492959923,
                0.0, 0.4647668088544966,
                0.007948972132892985, 0.45728045283189034,
                0.5331726890890015, 0.5275330412189897,
                0.7379913608919004, 0.7297902524485291,
                0.9119670379844514, 0.8981358000333225,
                0.9308422056162358, 0.9184586339794437,
                1.0, 0.9724952882169435,
            };
            Window.Clear(Color.White);

            Vector2D[] coords = GetCoords(points);
            Window.Display();
            while (true)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);
                if (window.HasFocus())
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.F5))
                    {
                        coords = GetCoords(origin);
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                    {
                        Window.Close();
                    }

                    Node[] graph = BuildGraph(coords);
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        graph = DragNodes(graph);
                        for (int i = 0; i < graph.Length; i++)
                        {
                            coords[i] = graph[i].Position;
                        }
                    }

                    Sprite poseLines = DrawGraphLines(graph);
                    Sprite poseNodes = DrawGraphNodes(graph);
                    poseLines.Position = poseNodes.Position = new(Width / 20, Height / 20);
                    Window.Draw(poseLines);
                    Window.Draw(poseNodes);
                    poseLines.Position = new((Width / 2) + (Width / 20), Height / 20);

                    Window.Draw(poseLines);

                    Window.Display();
                    Window.DispatchEvents();
                }
            }
        }

        private static Node[] DragNodes(Node[] graph)
        {
            Vector2D mousePos = new(Mouse.GetPosition(Window).X - (Width / 20), Mouse.GetPosition(Window).Y - (Width / 40));
            mousePos /= graphNodesTextures.Size.X;
            int closestId = GetClosestNodeToMouse(graph);

            if (graph[closestId].Parent != null && graph[closestId].Parent.Parent != null)
            {
                // double translation = Math.Atan2(graph[closestId].Position.Y - mousePos.Y, graph[closestId].Position.X - mousePos.X);
                Vector2D a = graph[closestId].Parent.Position - mousePos;
                Vector2D b = graph[closestId].Parent.Parent.Position - graph[closestId].Parent.Position;

                double angle = GetAngle(a, b);

                double degAngle = angle * 180 / Math.PI;

                Text angleText = new(degAngle.ToString(), Font, 15);
                angleText.Scale = new(1, 1);
                angleText.FillColor = Color.Black;
                angleText.Position = new(10, 10);
                window.Draw(angleText);
                graph[closestId].Move(angle);

                // graph[closestId].Move(-angle);
            }

            return graph;
        }

        public static double GetAngle(Vector2D a, Vector2D b)
        {
            double dot = a * b;

            double det = (a.X * b.Y) - (a.Y * b.X);

            return Math.Atan2(det, dot);
        }

        private static Vector2D[] GetCoords(double[] dots)
        {
            Vector2D[] result = new Vector2D[dots.Length / 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new(dots[i], dots[i + result.Length]);
            }

            return result;
        }

        private static Node[] BuildGraph(Vector2D[] coords)
        {
            Node[] result = new Node[coords.Length];
            for (int i = 0; i < coords.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        result[i] = new(null);
                        break;
                    case 1:
                        result[i] = new(result[0]);
                        break;
                    case 2:
                        result[i] = new(result[1]);
                        break;
                    case 3:
                        result[i] = new(result[2]);
                        break;
                    case 4:
                        result[i] = new(result[0]);
                        break;
                    case 5:
                        result[i] = new(result[4]);
                        break;
                    case 6:
                        result[i] = new(result[5]);
                        break;
                    case 7:
                        result[i] = new(result[3]);
                        break;
                    case 8:
                        result[i] = new(result[6]);
                        break;
                    case 9:
                        result[i] = new();
                        break;
                    case 10:
                        result[i] = new();
                        break;
                    case 11:
                        result[i] = new(result[0]);
                        break;
                    case 12:
                        result[i] = new(result[0]);
                        break;
                    case 13:
                        result[i] = new(result[11]);
                        break;
                    case 14:
                        result[i] = new(result[12]);
                        break;
                    case 15:
                        result[i] = new(result[13]);
                        break;
                    case 16:
                        result[i] = new(result[14]);
                        break;
                    case 17:
                        result[i] = new(result[15]);
                        break;
                    case 18:
                        result[i] = new(result[16]);
                        break;
                    case 19:
                        result[i] = new(result[15]);
                        break;
                    case 20:
                        result[i] = new(result[16]);
                        break;
                    case 21:
                        result[i] = new(result[15]);
                        break;
                    case 22:
                        result[i] = new(result[16]);
                        break;
                    case 23:
                        result[i] = new(result[0]);
                        break;
                    case 24:
                        result[i] = new(result[0]);
                        break;
                    case 25:
                        result[i] = new(result[23]);
                        break;
                    case 26:
                        result[i] = new(result[24]);
                        break;
                    case 27:
                        result[i] = new(result[25]);
                        break;
                    case 28:
                        result[i] = new(result[26]);
                        break;
                    case 29:
                        result[i] = new(result[27]);
                        break;
                    case 30:
                        result[i] = new(result[28]);
                        break;
                    case 31:
                        result[i] = new(result[27]);
                        break;
                    case 32:
                        result[i] = new(result[28]);
                        break;
                }

                result[i].Position = coords[i];
            }

            return result;
        }

        private static Sprite DrawGraphLines(Node[] nodes)
        {
            graphLinesTexture.Clear(Color.Transparent);
            Sprite result = new();
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Parent != null)
                {
                    VertexArray line = new(PrimitiveType.Lines, 2);
                    line[0] = new Vertex(new Vector2f((float)nodes[i].Position.X * graphLinesTexture.Size.X, graphLinesTexture.Size.Y - ((float)nodes[i].Position.Y * graphLinesTexture.Size.X)), Color.Black);
                    line[1] = new Vertex(new Vector2f((float)nodes[i].Parent.Position.X * graphLinesTexture.Size.X, graphLinesTexture.Size.Y - ((float)nodes[i].Parent.Position.Y * graphLinesTexture.Size.X)), Color.Black);
                    graphLinesTexture.Draw(line);
                }
            }

            result.Texture = graphLinesTexture.Texture;
            return result;
        }

        private static Sprite DrawGraphNodes(Node[] nodes)
        {
            graphNodesTextures.Clear(Color.Transparent);
            int closestId = GetClosestNodeToMouse(nodes);
            Sprite result = new();

            // GraphNodesTextures = new(_Width / 10 * 4, _Height - (_Height / 10));
            for (int i = 0; i < nodes.Length; i++)
            {
                CircleShape pivot = new(5)
                {
                    Position = new Vector2f(((float)nodes[i].Position.X * graphNodesTextures.Size.X) - 5, graphNodesTextures.Size.Y - ((float)nodes[i].Position.Y * graphNodesTextures.Size.X) - 5),
                };
                pivot.OutlineThickness = 2;
                pivot.OutlineColor = Color.Black;
                graphNodesTextures.Draw(pivot);
                Text nodeId = new(i.ToString(), Font, 15);
                nodeId.Scale = new(1, -1);
                nodeId.FillColor = Color.Black;
                nodeId.Position = new Vector2f((float)nodes[i].Position.X * graphNodesTextures.Size.X, graphNodesTextures.Size.Y - ((float)nodes[i].Position.Y * graphNodesTextures.Size.X));
                //graphNodesTextures.Draw(nodeId);
                if (nodes[i].Parent != null && nodes[i].Parent.Parent != null)
                {
                    Vector2D a = nodes[i].Parent.Position - nodes[i].Position;
                    Vector2D b = nodes[i].Parent.Parent.Position - nodes[i].Parent.Position;
                    Text angleText = new(Math.Truncate(GetAngle(a, b) * 180 / Math.PI).ToString(), Font, 15);
                    angleText.Scale = new(1, -1);
                    angleText.FillColor = Color.Black;
                    angleText.Position = new Vector2f((float)nodes[i].Parent.Position.X * graphNodesTextures.Size.X, graphNodesTextures.Size.Y - ((float)nodes[i].Parent.Position.Y * graphNodesTextures.Size.X));
                    angleText.Position -= new Vector2f(-15, 15);
                    graphNodesTextures.Draw(angleText);
                }
            }

            CircleShape highlighted = new(5)
            {
                Position = new Vector2f(((float)nodes[closestId].Position.X * graphNodesTextures.Size.X) - 5, graphNodesTextures.Size.Y - ((float)nodes[closestId].Position.Y * graphNodesTextures.Size.X) - 5),
            };
            if (nodes[closestId].Parent != null)
            {
                CircleShape highlightedParent = new(5)
                {
                    Position = new Vector2f(((float)nodes[closestId].Parent.Position.X * graphNodesTextures.Size.X) - 5, graphNodesTextures.Size.Y - ((float)nodes[closestId].Parent.Position.Y * graphNodesTextures.Size.X) - 5),
                };
                highlightedParent.FillColor = Color.Green;
                graphNodesTextures.Draw(highlightedParent);
            }

            highlighted.FillColor = Color.Red;
            graphNodesTextures.Draw(highlighted);
            result.Texture = graphNodesTextures.Texture;
            return result;
        }

        private static int GetClosestNodeToMouse(Node[] nodes)
        {
            int closest = 0;
            double distanceToMouseMin = 10000000000;
            Vector2D mousePos = new(Mouse.GetPosition(Window).X - (Width / 20), Mouse.GetPosition(Window).Y - (Width / 40));
            for (int i = 0; i < nodes.Length; i++)
            {
                double distanceToMouse = (nodes[i].Position - (mousePos / graphNodesTextures.Size.X)).Length;
                if (distanceToMouse < distanceToMouseMin)
                {
                    distanceToMouseMin = distanceToMouse;
                    closest = i;
                }
            }

            return closest;
        }
    }
}
