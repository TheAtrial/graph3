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

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {

        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        List<Neighbor> N;
        Random x = new Random();

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            N = new List<Neighbor>();
            sheet.Image = G.GetBitmap();
        }

        //кнопка - выбрать вершину
        private void SelectB_Click(object sender, EventArgs e)
        {
            SelectB.Enabled = false;
            VertexB.Enabled = true;
            EdgeB.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
        }

        //кнопка - рисовать вершину
        private void VertexB_Click(object sender, EventArgs e)
        {
            VertexB.Enabled = false;
            SelectB.Enabled = true;
            EdgeB.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void EdgeB_Click(object sender, EventArgs e)
        {
            EdgeB.Enabled = false;
            SelectB.Enabled = true;
            VertexB.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - рассчет пути
        private void Shw_Click(object sender, EventArgs e)
        {
            const string caption = "Есть путь!";
            const string caption1 = "Путь длиннее 100км!";
            const string caption2 = "Ошибка: Вершина не найдена";
            const string caption3 = "Ошибка: недосягаемая вершина";
            int q = G.city(V);
            try
            {
                int start = int.Parse(textBox2.Text);
                if (start > V.Count)
                {
                    MessageBox.Show(caption2);
                }
                if (start <= V.Count)
                {
                    int r = G.obhod(E, V, N, start);
                    if (r > 0)
                    {
                        MessageBox.Show(caption3);
                    }
                    if (r == 0)
                    {
                        if (q == 1)
                        {
                            MessageBox.Show(caption);
                        }
                        if (q != 1)
                        {
                            MessageBox.Show(caption1);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                const string caption4 = "Ошибка: Неверное имя вершины";
                MessageBox.Show(caption4);
            }
        }


        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            int rand = x.Next(1, 50);
            bool metka = false;
            if (SelectB.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            G.clearSheet();
                            G.drawALLGraph(V, E);
                            sheet.Image = G.GetBitmap();
                        }
                    }
                }
            }
            // добавление вершины
            if (VertexB.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y, metka, rand));
                G.drawVertex(e.X, e.Y, V.Count.ToString(), metka);
                sheet.Image = G.GetBitmap();
            }
            // добавление ребра
            if (EdgeB.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2, rand));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], rand);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString(), metka);
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
        }
   
    }
}
