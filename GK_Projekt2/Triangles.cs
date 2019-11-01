using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GK_Projekt2
{
    public class Triangles
    {
        public int N { get; set; } //width
        public int M { get; set; } //height

        private const int defaultN = 3;
        private const int defaultM = 3;
        public Point[,] Points { get; private set; }
        private Pen pen = new Pen(Brushes.Black);
        public List<ActiveEdge> ActiveEdges { get; set; }

        public Triangle[] GetTriangles
        {
            get
            {
                List<Triangle> triangles = new List<Triangle>();
                for (int i = 0; i < Points.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < Points.GetLength(1) - 1; j++)
                    {
                        triangles.Add(new Triangle(Points[i, j], Points[i, j + 1], Points[i + 1, j]));
                        triangles.Add(new Triangle(Points[i, j + 1], Points[i + 1, j], Points[i + 1, j + 1]));
                    }
                }

                return triangles.ToArray();
            }
        }

        public Triangles(int n = defaultN, int m = defaultM)
        {
            this.N = n;
            this.M = m;
        }

        private void Swap(ref Point a, ref Point b)
        {
            Point temp = a;
            a = b;
            b = temp;
        }

        public void InitTriangles(int width, int height)
        {
            Points = new Point[N + 1, M + 1];
            int widthEmpty = width * 8 / 100;
            int heightEmpty = height * 8 / 100;
            double TriaWidth = (double)(width - widthEmpty)/ (double)M;
            double TriaHeight = (double)(height - heightEmpty)/ (double)N;

            for (int i = 0; i < N + 1; i++)
            { 
                for (int j = 0; j < M + 1; j++)
                { 
                    Points[i, j].X = (int)(TriaWidth * j) + widthEmpty / 2;
                    Points[i, j].Y = (int)(TriaHeight * i) + heightEmpty / 2;
                }
            }
            
            
        }

        //public void 

        public void DrawTriangles(Image image)
        {
            if (Points == null)
                return;
            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                for (int i = 0; i < Points.GetLength(0); i++)
                {
                    for (int j = 0; j < Points.GetLength(1); j++)
                    {
                        if (j < Points.GetLength(1) - 1)
                        {
                            g.DrawLine(pen, Points[i, j], Points[i, j + 1]); // w prawo
                            if (i > 0)
                                g.DrawLine(pen, Points[i, j], Points[i - 1, j + 1]); // do gory prawo

                        }
                        if (i < Points.GetLength(0) - 1)
                            g.DrawLine(pen, Points[i, j], Points[i + 1, j]); // w dol
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mousePoint"></param>
        /// <returns>
        /// 
        /// </returns>
        public (int, int, double) FindNearestPoint(Point mousePoint)
        {
            int iNearest = 0;
            int jNearest = 0;
            double distance = Points[0, 0].DistanceToPoint(mousePoint);
            for (int i = 0; i < Points.GetLength(0); i++)
            {
                for (int j = 0; j < Points.GetLength(1); j++)
                {
                    double curDistance = Points[i, j].DistanceToPoint(mousePoint);
                    if (curDistance < distance)
                    {
                        distance = curDistance;
                        iNearest = i;
                        jNearest = j;
                    }
                }
            }
            return (iNearest, jNearest, distance);
            
        }

        public void MovePoint(int i, int j, Point p)
        {
            if (Points == null || i >= Points.GetLength(0) || j >= Points.GetLength(1) || i < 0 || j < 0)
                return;
            Points[i, j] = p;
            
        }


        public void InitActiveEdges()
        {
            List<ActiveEdge> edges = new List<ActiveEdge>();
            Point higherPoint;
            Point lowerPoint;
            double dx, dy;
            double m;
            for (int i = 0; i < Points.GetLength(0); i++)
            {
                for (int j = 0; j < Points.GetLength(1); j++)
                {
                    if (j < Points.GetLength(1) - 1)
                    {
                        //w prawo
                        higherPoint = Points[i, j];
                        lowerPoint = Points[i, j + 1];
                        if(higherPoint.Y < lowerPoint.Y)
                        {
                            Swap(ref higherPoint, ref lowerPoint);
                        }
                        dx = higherPoint.X - lowerPoint.X;
                        dy = higherPoint.Y - lowerPoint.Y;
                        if (dy != 0)
                        {
                            m = dx / dy;
                            edges.Add(new ActiveEdge(higherPoint.Y, lowerPoint.Y, lowerPoint.X, m));
                            if (i > 0 && i < Points.GetLength(0) - 1)
                                edges.Add(new ActiveEdge(higherPoint.Y, lowerPoint.Y, lowerPoint.X, m));
                        }
                        if(i > 0)
                        {
                            //do gory prawo
                            higherPoint = Points[i, j];
                            lowerPoint = Points[i - 1, j + 1];
                            if (higherPoint.Y < lowerPoint.Y)
                            {
                                Swap(ref higherPoint, ref lowerPoint);

                            }
                            dx = higherPoint.X - lowerPoint.X;
                            dy = higherPoint.Y - lowerPoint.Y;
                            if (dy != 0)
                            {
                                m = dx / dy;
                                edges.Add(new ActiveEdge(higherPoint.Y, lowerPoint.Y, lowerPoint.X, m));
                                edges.Add(new ActiveEdge(higherPoint.Y, lowerPoint.Y, lowerPoint.X, m));
                            }
                        }

                    }
                    if (i < Points.GetLength(0) - 1)
                    {
                        //w dol
                        higherPoint = Points[i, j];
                        lowerPoint = Points[i + 1, j];
                        if (higherPoint.Y < lowerPoint.Y)
                        {
                            Swap(ref higherPoint, ref lowerPoint);

                        }
                        dx = higherPoint.X - lowerPoint.X;
                        dy = higherPoint.Y - lowerPoint.Y;
                        if (dy != 0)
                        {
                            m = dx / dy;
                            edges.Add(new ActiveEdge(higherPoint.Y, lowerPoint.Y, lowerPoint.X, m));
                            if (j > 0 && j < Points.GetLength(1) - 1)
                                edges.Add(new ActiveEdge(higherPoint.Y, lowerPoint.Y, lowerPoint.X, m));
                        }
                    }
                }
            }
            ActiveEdges = edges;
        }

        public void FillTriangles(Color color)
        {
            
        }


        
    }
}
