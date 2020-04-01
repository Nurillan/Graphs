using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    static class VertexListExtension
    {
        public static void DeleteAndRemove(this List<Vertex> vertices, Vertex vertex)
        {
            vertex.DeleteLinked();
            vertices.Remove(vertex);
        }

        public static Vertex GetSelectedVertex(this List<Vertex> vertices, int x, int y)
        {
            foreach (Vertex vertex in vertices)
            {
                if (Math.Pow((vertex.x - x), 2) + Math.Pow((vertex.y - y), 2) <= DrawGraph.R * DrawGraph.R)
                    return vertex;
            }
            return null;
        }
    }

    static class EdgeListExtension
    {
        public static Edge GetSelectededge(this List<Edge> edges, int x, int y)
        {
            foreach (Edge edge in edges)
            {
                if (edge.v1 == edge.v2) //если это петля
                {
                    int r = DrawGraph.R;
                    int w = DrawGraph.W;
                    Vertex vert = edge.v1;
                    if ((Math.Pow((vert.x - r - x), 2) + Math.Pow((vert.y - r - y), 2) <= ((r + w) * (r + w))) &&
                        (Math.Pow((vert.x - r - x), 2) + Math.Pow((vert.y - r - y), 2) >= ((r - w) * (r - w))))
                        return edge;
                }
                else //не петля
                {
                    Vertex vert1 = edge.v1;
                    Vertex vert2 = edge.v2;
                    if (((x - vert1.x) * (vert2.y - vert1.y) / (vert2.x - vert1.x) + vert1.y) <= (y + 4) &&
                        ((x - vert1.x) * (vert2.y - vert1.y) / (vert2.x - vert1.x) + vert1.y) >= (y - 4))
                    {
                        if ((vert1.x <= vert2.x && vert1.x <= x && x <= vert2.x) ||
                            (vert1.x >= vert2.x && vert1.x >= x && x >= vert2.x))
                            return edge;                        
                    }
                }
            }
            return null;
        }
    }
}
