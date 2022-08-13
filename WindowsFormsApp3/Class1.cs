using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{

    class Vertex
    {
        public int x, y;
        public bool metka;
        public int zn;

        public Vertex(int x, int y, bool metka, int zn)
        {
            this.x = x;
            this.y = y;
            this.metka = metka;
            this.zn = zn;
        }
    }

    class Edge
    {
        public int v1, v2, r;

        public Edge(int v1, int v2, int r)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.r = r;
        }
    }

    class Neighbor
    {
        public int v1, v2, r;
        public Neighbor(int v1, int v2, int r)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.r = r;
        }
    }


    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Graphics gr;
        Font fo;
        Brush br;
        PointF point;
        public int R = 20; //радиус окружности вершины

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.DarkOliveGreen);
            blackPen.Width = 2;
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            darkGoldPen = new Pen(Color.Blue);
            darkGoldPen.Width = 2;
            fo = new Font("Arial", 15);
            br = Brushes.Black;
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number, bool metka)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        internal void drawVertex(object x, object y, string v, bool metka)
        {
            throw new NotImplementedException();
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE)
        {
            bool m = false;
            if (E.v1 == E.v2)
            {
                gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R));
                gr.DrawString(numberE.ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString(), m);
            }
            else
            {
                gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y);
                point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2);
                gr.DrawString(numberE.ToString(), fo, br, point);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString(), m);
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString(), m);
            }
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {
            bool m = false;
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(darkGoldPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R));
                    gr.DrawString((E[i].r).ToString(), fo, br, point);
                }
                else
                {
                    gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                    
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2);
                    gr.DrawString((E[i].r).ToString(), fo, br, point);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString(), m);
            }
        }

        //поиск соседей для вершины
        public void nei (List<Edge> E, List<Vertex> V, List<Neighbor> N, int cur)
        {
            N.Clear();
            int a, b, c;
            for (int i = 0; i <E.Count; i++)
            {
                if (E[i].v1 == cur || E[i].v2 == cur)
                {
                    if (E[i].v1 == cur)
                    {
                        a = E[i].v1;
                        b = E[i].v2;
                        c = E[i].r;
                        N.Add(new Neighbor(a, b, c));
                    }
                    else if (E[i].v2 == cur)
                    {
                        a = E[i].v2;
                        b = E[i].v1;
                        c = E[i].r;
                        N.Add(new Neighbor(a, b, c));
                    }
                }
            }
        }


        public int obhod(List<Edge> E, List<Vertex> V, List<Neighbor> N, int start)
        {
            int nowv = start - 1;
            for (int i = 0; i < V.Count; i++)
            {
                V[i].zn = int.MaxValue;
                V[i].metka = false;
            }
            V[nowv].zn = 0;
            int u;
            int d = 0;
            while(nowv != -1)
            {
                nei(E, V, N, nowv);
                for (int k = 0; k < N.Count; k++) // заполнение значений к вершинам
                {
                    u = N[k].v2;
                    if (!V[u].metka && N[k].r + V[nowv].zn < V[u].zn)
                        V[u].zn = N[k].r + V[nowv].zn;
                }
                V[nowv].metka = true;
                nowv = min_vertex(V);
            }
            
            for (int i = 0; i < V.Count; i++)
            {
                if (V[i].zn == int.MaxValue)
                {
                    d++;
                }
            }
            return d;

        }

        private int min_vertex(List<Vertex> V) 
        {
            int res = -1,
                min = int.MaxValue;
            for (int i = 0; i != V.Count; ++i)
                if (!V[i].metka && V[i].zn < min)
                {
                    min = V[i].zn;
                    res = i;
                }
            return res;
        }

        public int city(List<Vertex> V)
        {
            int cr = 0;
            int d = 0;
            for (int i = 0; i < V.Count; i++)
            {
                if (V[i].zn < 100)
                {
                    cr++;
                }

            }
            if (cr == V.Count)
            {
                d = 1;
            }

            return d;
        }


        internal void obhod()
        {
            throw new NotImplementedException();
        }
    }
}
