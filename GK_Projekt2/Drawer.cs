using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Projekt2
{
    public static class Drawer
    {

        public static void FillPolygons(DirectBitmap image, Triangles triangles)
        {
            var _triangles = triangles.GetTriangles;
            Color c1 = Color.Red;
            Color c2 = Color.Green;
            Color c = c1;
            Parallel.For(0, _triangles.Length, i =>
            {
                c = Color.FromArgb(100, (5 * i) % 255, (10 * i) % 255, (15 * i) % 255);
                FillPolygon(_triangles[i].ActiveEdges, image, c);
            });

        }


        public static void FillPolygon(List<ActiveEdge> edges, DirectBitmap image, Color color)
        {
            List<ActiveEdge>[] ET = new List<ActiveEdge>[image.Height];
            foreach (ActiveEdge e in edges)
            {
                if (e.yMax >= image.Height)
                    e.yMax = image.Height - 1;
                if (e.yMin < 0)
                    e.yMin = 0;
                if (ET[e.yMin] == null)
                    ET[e.yMin] = new List<ActiveEdge>();
                ET[e.yMin].Add(e);
            }//tablica ET
            int y = -1;
            for (int i = 0; i < ET.Length; i++)
            {
                if (ET[i] != null)
                {
                    y = i;
                    break;
                }
            }//najmniejszy index y
            var AET = new List<ActiveEdge>();
            if (y != -1)
                for (int i = y; i < ET.Length; i++)
                {
                    if (ET[i] != null)
                        AET.AddRange(ET[i]);
                    AET.Sort((e1, e2) => e1.x.CompareTo(e2.x));//posortowane
                    for (int j = 0; j + 1 < AET.Count; j += 2)
                    {
                        int x1 = (int)Math.Round(AET[j].x);
                        int x2 = (int)Math.Round(AET[j + 1].x);
                        while (x1 <= x2)
                        {
                            image.SetPixel(x1++, i, color);
                        }
                    }
                    AET.RemoveAll(x => x.yMax - 1 == i);
                    foreach (var e in AET)
                    {
                        e.IncreaseX();
                    }
                }
        }


        public static void DrawPolygon(DirectBitmap image, Point[,] Points, Pen pen)
        {
            if (Points == null)
                return;
            using (Graphics g = Graphics.FromImage(image.Bitmap))
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
    }
}
