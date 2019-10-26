using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GK_Projekt2
{
    class Triangles
    {
        public int N { get; set; } //width
        public int M { get; set; } //height

        private Point[,] Points;
        private Pen pen = new Pen(Brushes.Black);

        public Triangles(int n = 10, int m = 15)
        {
            this.N = n;
            this.M = m;
        }


        public void InitTriangles(int width, int height)
        {
            Points = new Point[N + 1, M + 1];
            double TriaWidth = (double)(width - 5)/ (double)M;
            double TriaHeight = (double)(height - 5)/ (double)N;

            for (int i = 0; i < N + 1; i++)
            { 
                for (int j = 0; j < M + 1; j++)
                { 
                    Points[i, j].X = (int)(TriaWidth * j);
                    Points[i, j].Y = (int)(TriaHeight * i);
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
                for (int i = 0; i < N + 1; i++)
                {
                    for (int j = 0; j < M + 1; j++)
                    {
                        if (j < M)
                        {
                            g.DrawLine(pen, Points[i, j], Points[i, j + 1]); // w prawo
                            if (i > 0)
                                g.DrawLine(pen, Points[i, j], Points[i - 1, j + 1]); // do gory prawo

                        }
                        if (i < N)
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
                for (int j = 1; j < Points.GetLength(1); j++)
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


    }
}
