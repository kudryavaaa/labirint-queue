using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg_lab_1
{
    public class Matrix
    {
        private int n;
        private int m;
        private char[,] matrix;
        private Node startNode;
        private Node finishNode;

        public int getN()
        {
            return n;
        }

        public int getM()
        {
            return m;
        }

        public char[,] getMatrix()
        {
            return matrix;
        }

        public Node getStartNode()
        {
            return startNode;
        }

        public Node getFinishNode()
        {
            return finishNode;
        }

        public Matrix(int n, int m, Node startNode, Node finishNode)
        {
            this.n = n;
            this.m = m;
            this.startNode = startNode;
            this.finishNode = finishNode;
            matrix = new char[n, m];
            setMatrix();
            matrix[startNode.x, startNode.y] = 'S';
            matrix[finishNode.x, finishNode.y] = 'F';
        }

        private void setMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = '.';
                }
            }
        }

        public void setBlocks(List<Node> blocks)
        {
            foreach (Node block in blocks)
            {
                matrix[block.x, block.y] = '#';
            }
        }

        public char get(int x, int y)
        {
            return matrix[x, y];
        }

        public void buildPath(List<Node> path)
        {
            for (int i = 1; i < path.Count - 1; i++)
            {
                matrix[path[i].x, path[i].y] = 'x';
            }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    str += matrix[i, j] + " ";
                }
                str += "\n";
            }
            return str;
        }
    }
}
