using System.Drawing;
using System.Collections.Generic;

namespace Runner
{
    class Maze
    {
        /*Maze contains:
          - A two dimensional Matrix of Nodes
          - A Coloring class (Makes all abstracted coloring decisions)
          - Methods to solve the maze. (Currently uses Breadth-First Search.)
        */
        private Point start;
        private Node[,] graph;
        private int graphWidth;
        private int graphHeight;
        private Coloring colors;

        public Maze(Bitmap bmp)
        {
            bool startPoint = false; //Local variable used to find the first "red" point.
            this.graphWidth = bmp.Width;
            this.graphHeight = bmp.Height;
            colors = new Coloring(bmp); //Coloring object generation
            graph = new Node[graphWidth , graphHeight]; //Graph generation
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Point coord = new Point(i, j);
                    Node node = new Node(coord);
                    graph[i, j] = node;
                    if (colors.isRed(i,j) && !startPoint)
                    {
                        start = coord; //Stores the first "red" point
                        startPoint = true;
                    }
                    else if (colors.isBlack(i,j))
                        node.Wall = true; //Is a wall
                }
            }  
        }
        public Bitmap printPath()
        {
            //Generates a solution path and returns it in Bitmap form.
            Node endNode = breadthFirstSearch(graph[start.X,start.Y]); //Returns the solution of BFS
            if (endNode == null) //BFS did not find a solution
                return null;
            while (endNode != null)
            {
                Point start = endNode.Coord;
                colors.colorPixel(start.X, start.Y);
                endNode = endNode.Parent;
            }
            return colors.Bmp; //Returns Bitmap
        }
        private Node breadthFirstSearch(Node root)
        {
            Queue<Node> queue = new Queue<Node>();
            Node current = root;
            current.Visited = true;
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                current = queue.Dequeue();
                if (colors.isBlue(current.Coord))
                    return current; //Returns solution is coordinates are blue.
  
                List<Node> neighbors = getNeighbors(current);
                foreach (Node node in neighbors)
                {
                     graph[node.Coord.X, node.Coord.Y] = node;
                     node.Visited = true;
                     node.Parent = current;
                     queue.Enqueue(node);
                }
            }
            return null;
        }
        private List<Node> getNeighbors(Node node)
        {
            //Up,Down,Left,Right neighbors.
            List<Node> neighbors = new List<Node>();
            Point pos = node.Coord;
            Point[] coords = new Point[] { new Point(pos.X - 1, pos.Y), new Point(pos.X + 1, pos.Y),
                new Point(pos.X, pos.Y - 1), new Point(pos.X, pos.Y + 1) };

            foreach (Point coord in coords)
            {
                if (coord.X > -1 && coord.X < graphWidth && coord.Y > -1 && coord.Y < graphHeight)
                {
                    //is a valid neighbor
                    Node currNode = graph[coord.X, coord.Y];
                    if (!currNode.Wall && !currNode.Visited)
                        neighbors.Add(currNode);
                }
            }
            return neighbors;
        }
    }
}
