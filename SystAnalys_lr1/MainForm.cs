using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
Найти все вершины графа, недостижимые из заданной вершины. 
Указание: использовать рекурсивную процедуру проверки доступности одной вершины из другой.
 */

namespace Graphs
{
    public partial class MainForm : Form
    {
        DrawGraph Graph;
        List<Vertex> vertices;
        List<Edge> edges;
        int[,] AMatrix; //матрица
        Vertex selected1 = null; //выбранные вершины, для соединения линиями
        Vertex selected2 = null;

        public MainForm()
        {
            InitializeComponent();
            Graph = new DrawGraph(sheet.Width, sheet.Height);
            vertices = new List<Vertex>();
            edges = new List<Edge>();
            sheet.Image = Graph.bitmap;
        }
        
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this graph?", "Deleting", 
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                vertices.Clear();
                edges.Clear();
                Graph.clearSheet();
                sheet.Image = Graph.bitmap;
            }
        }
        
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            AMatrix = new int[vertices.Count, vertices.Count];
            FillAdjacencyMatrix(vertices, edges, AMatrix);
            WriteAdjacencyMatrix(AMatrix);
        }

        private void buttonUnattainable_Click(object sender, EventArgs e)
        {
            if (selected1 == null)
            {
                MessageBox.Show("Select a vertex", "Error", MessageBoxButtons.OK);
                return;
            }
            List<Vertex> unAt = GetUnAttainable(vertices, selected1);
            string mes = "Unattainable vertices number: ";
            foreach (Vertex vert in unAt)
                mes += vert.num + ", ";
            mes = mes.Remove(mes.Length - 2, 2) + ".";
            MessageBox.Show(mes, "Task", MessageBoxButtons.OK);
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && selected1 != null)
            {
                Graph.drawVertex(selected1);
                selected1 = null;
                sheet.Image = Graph.bitmap;
            }

            if (selectButton.Checked)
                SelectVertex(e);
             
            if (drawVertexButton.Checked)
                AddVertex(e);

            if (drawEdgeButton.Checked)
                AddEdge(e);
            
            if (deleteButton.Checked)
                delete(e);
        }

        private void delete(MouseEventArgs e)
        {
            bool deleted = false;
            Vertex vertex = vertices.GetSelectedVertex(e.X, e.Y);
            if (vertex != null)
            {
                if (selected1 == vertex)
                    selected1 = null;

                foreach (Edge edge in vertex.edges)
                {
                    if (edges.IndexOf(edge) >= 0)
                    {
                        edges.Remove(edge);
                    }
                }
                vertices.DeleteAndRemove(vertex);
                deleted = true;
            }
            else 
            {
                Edge edge = edges.GetSelectededge(e.X, e.Y);
                if (edge != null)
                {
                    edges.Remove(edge);
                    edge.Delete();
                    deleted = true;
                }
            }

            if (deleted)
            {

                Graph.clearSheet();
                Graph.drawALLGraph(vertices, edges);
                sheet.Image = Graph.bitmap;
            }
        }

        private void AddEdge(MouseEventArgs e)
        {
            if (selected1 is null)
            {
                SelectVertex(e);
            }
            else
            {
                selected2 = vertices.GetSelectedVertex(e.X, e.Y);
                if (selected2 is null)
                    return;

                Graph.drawSelectedVertex(selected2);
                Edge edge = new Edge(selected1, selected2);
                edges.Add(edge);
                Graph.DrawEdge(edge);
                selected1 = null;
                selected2 = null;
                sheet.Image = Graph.bitmap;
            }
        }

        private void SelectVertex(MouseEventArgs e)
        {
            Vertex vertex = vertices.GetSelectedVertex(e.X, e.Y);
            if (vertex is null)
                return;

            if (selected1 != null)
            {
                selected1 = null;
                Graph.clearSheet();
                Graph.drawALLGraph(vertices, edges);
                sheet.Image = Graph.bitmap;
            }

            selected1 = vertex;
            Graph.drawSelectedVertex(selected1);
            sheet.Image = Graph.bitmap;
        }

        private void AddVertex(MouseEventArgs e)
        {
            Vertex vertex = new Vertex(e.X, e.Y);
            vertices.Add(vertex);
            Graph.drawVertex(vertex);
            sheet.Image = Graph.bitmap;
        }

        private void WriteAdjacencyMatrix(int[,] matrix)
        {
            int vertCount = matrix.GetLength(0);
            listBoxMatrix.Items.Clear();
            string sOut = "    ";
            for (int i = 0; i < vertCount; i++)
                sOut += (vertices[i].num) + " ";
            listBoxMatrix.Items.Add(sOut);
            for (int i = 0; i < vertCount; i++)
            {
                sOut = (vertices[i].num) + " | ";
                for (int j = 0; j < vertCount; j++)
                    sOut += AMatrix[i, j] + " ";
                listBoxMatrix.Items.Add(sOut);
            }
        }

        private void initMas(int[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                    mas[i, j] = 0;
        }
        
        private void FillAdjacencyMatrix(List<Vertex> vertices, List<Edge> edges, int[,] matrix)
        {
            int VertCount = vertices.Count;
            initMas(matrix);

            for (int i = 0; i < VertCount; i++)
            {
                Vertex current = vertices[i];
                foreach (Edge edge in current.edges)
                {
                    Vertex linked = edge.GetLinked(vertices[i]);
                    int j = vertices.IndexOf(linked);
                    matrix[i, j] = 1;
                }
            }
        }

        private List<Vertex> GetUnAttainable(List<Vertex> vertices, Vertex selected)
        {
            List<Vertex> result = new List<Vertex>();
            foreach(Vertex vertex in vertices)
            {
                if (selected.CanAttain(vertex) == false)
                    result.Add(vertex);
            }
            return result;
        }
    }
}
