using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace GK_Projekt2
{
    public class Drawer
    {

        public static void FillPolygons(DirectBitmap image, Triangles triangles)
        {
            var _triangles = triangles.GetTriangles;
            Parallel.For(0, _triangles.Length, i =>
            {
                FillPolygon(_triangles[i].ActiveEdges, image, mainForm.ObjectColor);
            });

        }


        public static void FillPolygon(List<ActiveEdge> edges, DirectBitmap image, Color color)
        {
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N - L;
            double kd = mainForm.KdCo;
            double ks = mainForm.KsCo;
            double m = mainForm.MCo;
            Color lightColor = mainForm.LightColor;
            Color objectColor = mainForm.ObjectColor;



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
            if (mainForm.ConstObjectColor)
            {
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
                                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                                {
                                    Color pixel = mainForm.VectorNTexture.GetPixel(x1 % mainForm.VectorNTexture.Width, i % mainForm.VectorNTexture.Height);
                                    double r = pixel.R;
                                    double g = pixel.G;
                                    double b = pixel.B;
                                    double X = r / 255.0 * 2.0 - 1.0;
                                    double Y = g / 255.0 * 2.0 - 1.0;
                                    double Z = b / 255.0;
                                    N.X = X;
                                    N.Y = Y;
                                    N.Z = Z;
                                }
                                R = 2 * N - L;
                                Color c = CalculateColor(lightColor, objectColor, N, L, R, V, m, kd, ks);
                                image.SetPixel(x1++, i, c);
                            }
                        }
                        AET.RemoveAll(x => x.yMax - 1 == i);
                        foreach (var e in AET)
                        {
                            e.IncreaseX();
                        }
                    }
            }
            else
            {
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
                                objectColor = mainForm.ObjectColorTexture.GetPixel(x1 % mainForm.ObjectColorTexture.Width, i % mainForm.ObjectColorTexture.Height);
                                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                                {
                                    Color pixel = mainForm.VectorNTexture.GetPixel(x1 % mainForm.VectorNTexture.Width, i % mainForm.VectorNTexture.Height);
                                    double r = pixel.R;
                                    double g = pixel.G;
                                    double b = pixel.B;
                                    double X = r / 255.0 * 2.0 - 1.0;
                                    double Y = g / 255.0 * 2.0 - 1.0;
                                    double Z = b / 255.0;
                                    N.X = X;
                                    N.Y = Y;
                                    N.Z = Z;
                                }
                                R = 2 * N - L;
                                Color c = CalculateColor(lightColor, objectColor, N, L, R, V, m, kd, ks);
                                image.SetPixel(x1++, i, c);
                            }
                        }
                        AET.RemoveAll(x => x.yMax - 1 == i);
                        foreach (var e in AET)
                        {
                            e.IncreaseX();
                        }
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


        private static Color CalculateColor(Color lightColor, Color objectcolor, Vector3D N, Vector3D L, Vector3D R, Vector3D V, double m, double kd, double ks)
        {
            int cR = (int)(kd * lightColor.R * objectcolor.R * myCos(N, L) + ks * lightColor.R * objectcolor.R * Math.Pow(myCos(V, R), m));
            if (cR > 255)
                cR = 255;
            if (cR < 0)
                cR = 0;

            int cG = (int)(kd * lightColor.G * objectcolor.G * myCos(N, L) + ks * lightColor.G * objectcolor.G * Math.Pow(myCos(V, R), m));
            if (cG > 255)
                cG = 255;
            if (cG < 0)
                cG = 0;
            int cB = (int)(kd * lightColor.B * objectcolor.B * myCos(N, L) + ks * lightColor.B * objectcolor.B * Math.Pow(myCos(V, R), m));
            if (cB > 255)
                cB = 255;
            if (cB < 0)
                cB = 0;
            return Color.FromArgb(cR, cG, cB);

        }

        private static double myCos(Vector3D a, Vector3D b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }



    }
}
