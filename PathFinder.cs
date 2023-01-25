using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg_lab_1
{
    class PathFinder
    {
        private Matrix matrix;
        private bool [,] visited;
        private QueueCustom<int> queue_x = new QueueCustom<int>();
        private QueueCustom<int> queue_y = new QueueCustom<int>();
        private Dictionary<Node, List<Node>> map = new Dictionary<Node, List<Node>>();

        private int[] direct_x = { -1, 1, 0, 0 };
        private int[] direct_y = { 0, 0, 1, -1 };

        public PathFinder(Matrix matrix)
        {
            this.matrix = matrix;
            visited = new bool[matrix.getN(), matrix.getM()];

        }
        public List<Node> FindPath()
        {
            bool isFinish = false;
            queue_x.add(matrix.getStartNode().x);
            queue_y.add(matrix.getStartNode().y);

            visited[matrix.getStartNode().x, matrix.getStartNode().y] = true;
            while (queue_x.Size() != 0)
            {
                int x = queue_x.poll();
                int y = queue_y.poll();

                if (matrix.get(x, y) == 'F')
                {
                    isFinish = true;
                    GetPath(map, new Node(x,y));
                    break;
                }
                checkNeighbors(x, y);
            }

            if (isFinish)
            {
                return path;
            }
            return null;

        }

        private void GetPath(Dictionary<Node, List<Node>> map, Node value)
        {
            foreach (var entry in map)
            {
                foreach(var node in entry.Value)
                {
                    if (node.Equals(value))
                    {
                        path.Add(entry.Key);
                        GetPath(map, entry.Key);
                    }
                }
            }
        }

        List<Node> path = new List<Node>();

        private void checkNeighbors(int x, int y)
        {
            Node key = new Node(x, y);
            map.Add(key, new List<Node>());
            for (int i = 0; i < 4; i++)
            {
                int nx = x + direct_x[i];
                int ny = y + direct_y[i];

                if (nx < 0 || ny < 0 || nx >= matrix.getM() || ny >= matrix.getN())
                {
                    continue;
                }

                if (!visited[nx, ny] && matrix.get(nx, ny) != '#')
                {
                    queue_x.add(nx);
                    queue_y.add(ny);
                    visited[nx, ny] = true;
                    map[key].Add(new Node(nx, ny));
                }
            }
        }
    }
}
