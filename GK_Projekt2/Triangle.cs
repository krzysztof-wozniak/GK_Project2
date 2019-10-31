using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2
{
    public class Triangle
    {
        //A najnizej, C najwyzej
        Point A { get; set; }
        Point B { get; set; }
        Point C { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            List<Point> points = new List<Point>() { a, b, c };
            points.Sort((x, y) => x.Y.CompareTo(y.Y));//rosnaca
            A = points[0];
            B = points[1];
            C = points[2];
        }

        public List<ActiveEdge> ActiveEdges
        {
            get
            {
                List<ActiveEdge> edges = new List<ActiveEdge>();
                double dx, dy, m;
                dx = C.X - B.X;
                dy = C.Y - B.Y;
                if (dy != 0)
                {
                    m = dx / dy;
                    edges.Add(new ActiveEdge(C.Y, B.Y, B.X, m));
                }
                dx = C.X - A.X;
                dy = C.Y - A.Y;
                if (dy != 0)
                {
                    m = dx / dy;
                    edges.Add(new ActiveEdge(C.Y, A.Y, A.X, m));
                }
                dx = B.X - A.X;
                dy = B.Y - A.Y;
                if (dy != 0)
                {
                    m = dx / dy;
                    edges.Add(new ActiveEdge(B.Y, A.Y, A.X, m));
                }
                return edges;
            }
        }
    }
}
