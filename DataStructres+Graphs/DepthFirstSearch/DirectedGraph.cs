using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    internal class DirectedGraph
    {
        public readonly int MAX_VERTICIES = 30;
        int n, e;
        bool[,] adj;
        Vertex[] vertexList;

        private readonly int INITIAL = 0;
        private readonly int VISITED = 1;

        public DirectedGraph()
        {
            adj = new bool[MAX_VERTICIES, MAX_VERTICIES];
            vertexList = new Vertex[MAX_VERTICIES];
        }

        public void DfsTraversal()
        {
            for (int v = 0; v < n; v++)
            {
                vertexList[v].state = INITIAL;
            }
            Console.WriteLine("Enter starting vertex for depth first search: ");
            String s = Console.ReadLine();
            Dfs(GetIndex(s));

        }

        private void Dfs(int v)
        {
            Stack<int> st = new Stack<int>();
            st.Push(v);

            while (st.Count != 0)
            {
                v = st.Pop();
                if (vertexList[v].state == INITIAL)
                {
                    Console.WriteLine(vertexList[v].name + " ");
                    vertexList[v].state = VISITED;
                }
                for (int i = n-1; i >=0; i--)
                {
                    if (isAdjacent(v,i) && (vertexList[i].state == INITIAL))
                    {
                        st.Push(i);
                    }
                }
                
            }
            Console.WriteLine();
        }

        public void DfsTraversal_All()
        {
            int v;
            for (v = 0; v < n; v++)
            {
                vertexList[v].state = INITIAL;
            }

            Console.WriteLine("Enter starting vertex for depth first search: ");
            String s = Console.ReadLine();
            Dfs(GetIndex(s));

            for(v = 0; v<n; v++)
            {
                if (vertexList[v].state == INITIAL)
                {
                    Dfs(v);
                }
            }
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
