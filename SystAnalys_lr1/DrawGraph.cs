using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    class DrawGraph
    {
        public Bitmap bitmap { get; }
        Graphics gr;
        PointF point; //for number
        Pen blackPen = new Pen(Color.Black); //vertices
        Pen redPen = new Pen(Color.Red); //selected
        Pen darkGoldPen = new Pen(Color.DarkGoldenrod); //edges
        Font fo = new Font("Arial", 15);
        Brush br = Brushes.Black;
        public static int R = 20; //radius of circle
        public static int W = 2; //width of pens

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen.Width = W;
            redPen.Width = W;            
            darkGoldPen.Width = W;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }
        
        //with vertices redrawing 
        public void drawVertex(Vertex vertex)
        {
            gr.FillEllipse(Brushes.White, (vertex.x - R), (vertex.y - R), 2 * R, 2 * R);
            drawOnlyVertex(vertex);
        }

        public void drawSelectedVertex(Vertex vertex)
        {
            gr.FillEllipse(Brushes.White, (vertex.x - R), (vertex.y - R), 2 * R, 2 * R);
            drawOnlyVertex(vertex, redPen);
        }

        //without vertices redrawing 
        private void drawOnlyVertex(Vertex vertex, Pen pen = null)
        {
            if (pen is null)
                pen = blackPen;
            gr.DrawEllipse(pen, (vertex.x - R), (vertex.y - R), 2 * R, 2 * R);
            point = new PointF(vertex.x - (R / 2), vertex.y - (R / 2));
            gr.DrawString(vertex.num.ToString(), fo, br, point);
        }

        //with vertices redrawing
        public void DrawEdge(Edge edge)
        {
            if (edge.v1 == edge.v2)
            {
                DrawOnlyEdge(edge);
                drawVertex(edge.v1);
            }
            else
            {
                DrawOnlyEdge(edge);
                drawVertex(edge.v1);
                drawVertex(edge.v2);
            }
        }

        //without vertices redrawing 
        private void DrawOnlyEdge(Edge edge)
        {
            Vertex vertex1 = edge.v1;
            Vertex vertex2 = edge.v2;
            if (vertex1 == vertex2)
            {
                gr.DrawArc(darkGoldPen, (vertex1.x - 2 * R), (vertex1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(vertex1.x - (int)(2.75 * R), vertex1.y - (int)(2.75 * R));
            }
            else
            {
                gr.DrawLine(darkGoldPen, vertex1.x, vertex1.y, vertex2.x, vertex2.y);
                point = new PointF((vertex1.x + vertex2.x) / 2, (vertex1.y + vertex2.y) / 2);//middle of hypotenuse
            }
            gr.DrawString(((char)('a' + edge.num)).ToString(), fo, br, point);
        }

        public void drawALLGraph(List<Vertex> Vertices, List<Edge> Edges)
        {
            foreach (Edge edge in Edges)
            {
                DrawOnlyEdge(edge);
            }
            foreach (Vertex vertex in Vertices)
            {
                drawVertex(vertex);
            }
        }       
    }
}