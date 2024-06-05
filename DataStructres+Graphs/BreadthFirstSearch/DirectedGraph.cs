using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    internal class DirectedGraph
    {
        public readonly int MAX_VERTICIES = 30;
        int n, e;
        bool[,] adj;
        Vertex[] vertexList;

        private readonly int INITIAL = 0;
        private readonly int WAITING = 1;
        private readonly int VISITED = 2;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICIES, MAX_VERTICIES];
            vertexList = new Vertex[MAX_VERTICIES];
        }

        public void BfsTraversal()
        {
            for (int v = 0; v < n; v++)
            {
                vertexList[v].state = INITIAL;
            }
            Console.WriteLine("Enter starting vertex for breadth first search: ");
            String s = Console.ReadLine();
            Bfs(GetIndex(s));

        }

        private void Bfs(int v)
        {
            Queue<int> qu = new Queue<int>();
            qu.Enqueue(v);
            vertexList[v].state = WAITING;

            while (qu.Count != 0){
                v = qu.Dequeue();
                Console.Write(vertexList[v].name + " ");
                vertexList[v].state = VISITED;
                
                for (int i = 0; i < n; i++)
                {
                    if (isAdjacent(v,i) && vertexList[i].state == INITIAL)
                    {
                        qu.Enqueue(i);
                        vertexList[i].state = WAITING;
                    }
                }
            }
            Console.WriteLine();
        }

        public void BfsTraversal_All()
        {
            int v;
            for (v = 0; v < n; v++)
            {
                vertexList[v].state = INITIAL;
            }

            Console.WriteLine("Enter starting vertex for breadth first search: ");
            String s = Console.ReadLine();
            Bfs(GetIndex(s));
        }

        public void InsertVertex(String name)
        {
            vertexList[n++] = new Vertex(name);
        }

        private int GetIndex(String s)
        {
            for (int i = 0; i < n; i++)
            {
                if (s.Equals(vertexList[i].name))
                {
                    return i;
                }
            }
            throw new System.InvalidOperationException("Invalid vertex");
        }

        private bool isAdjacent(int u, int v)
        {
            return adj[u, v];
        }

        public void InsertEdge(String s1, String s2)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);

            if (u == v)
                throw new System.InvalidOperationException("Not a valid edge");
            if (adj[u, v] == true)
                Console.WriteLine("Edge already present");
            else
            {
                adj[u, v] = true;
                e++;
            }
        }
    }
}
