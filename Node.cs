using System.Drawing;

namespace Runner
{
    class Node
    {
        /*The Node class contains various information and is presented through a pixel. 
          It contains various information such as:
          - The coordinates of a pixel
          - The Parent(The Node whose move lead to this node)
          - Visited(If the node has been visited or not)
          - Is a wall in the maze.
         */
        public Point Coord { get; }
        public Node Parent { get; set; }
        public bool Visited { get; set; }
        public bool Wall { get; set; }

        public Node(Point coord)
        {
            this.Coord = coord;
            Parent = null;
            Visited = false;
            Wall = false;
        }
    }
}
