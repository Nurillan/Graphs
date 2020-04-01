using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Edge
    {
        static int count = 0;

        public Vertex v1, v2;
        public int num { get; private set; }

        public Edge(Vertex v1, Vertex v2)
        {
            num = ++count;
            this.v1 = v1;
            this.v2 = v2;
            v1.edges.Add(this);
            v2.edges.Add(this);
        }

        public void Delete()
        {
            v1.edges.Remove(this);
            v2.edges.Remove(this);
        }

        public Vertex GetLinked(Vertex vertex)
        {
            return vertex == v1 ? v2 : v1;
        }
    }

    class Vertex : IComparable<Vertex>
    {
        static int count = 0;

        public int x, y;
        public int num { get; private set; }
        public List<Edge> edges;

        public Vertex(int x, int y)
        {
            edges = new List<Edge>();
            num = ++count;
            this.x = x;
            this.y = y;
        }

        public bool CanAttain(Vertex destination, List<Vertex> visited = null)
        {
            if (visited is null)
                visited = new List<Vertex>();

            if (this == destination)
                return true;

            visited.Add(this);
            bool result = false;
            int i = 0;
            while (result != true && i < edges.Count)
            {
                Vertex vert = edges[i].GetLinked(this);
                if (visited.IndexOf(vert) == -1)
                {
                    if (vert == destination)
                        result = true;
                    else
                        result = vert.CanAttain(destination, visited);                    
                }
                i++;
            }
            return result;
        }

        public void DeleteLinked()
        {
            foreach(Edge edge in edges)
            {
                Vertex vert = edge.GetLinked(this);
                vert.edges.Remove(edge);
            }
        }

        public int CompareTo(Vertex vert)
        {
            return this.num.CompareTo(vert.num);
        }
    }
}
