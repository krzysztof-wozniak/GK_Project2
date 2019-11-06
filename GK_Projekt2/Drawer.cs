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

        public static void FillPolygons(DirectBitmap image, Polygons triangles)
        {
            var _triangles = triangles.GetPolygons;

            if (mainForm.Method1)
            {
                if (mainForm.SetCoefficient)
                {
                    Parallel.For(0, _triangles.Length, i =>
                    {
                        FillPolygonSetCo(_triangles[i].ActiveEdges, image);
                    });
                }
                else
                {
                    Parallel.For(0, _triangles.Length, i =>
                    {
                        FillPolygonRandomCo(_triangles[i].ActiveEdges, image, mainForm.RandomKd[i], mainForm.RandomKs[i], mainForm.RandomM[i]);
                    });
                }
            }
            else if(mainForm.Method2)
            {
                if (mainForm.SetCoefficient)
                {
                    Parallel.For(0, _triangles.Length, i =>
                    {
                        FillPolygonMethod2SetCo(_triangles[i], image);
                    });
                }
                else
                {
                    Parallel.For(0, _triangles.Length, i =>
                    {
                        FillPolygonMethod2RandomCo(_triangles[i], image, mainForm.RandomKd[i], mainForm.RandomKs[i], mainForm.RandomM[i]);
                    });
                }
            }
            else
            {
                if (mainForm.SetCoefficient)
                {
                    Parallel.For(0, _triangles.Length, i =>
                    {
                        FillPolygonMethod3SetCo(_triangles[i], image);
                    });
                }
                else
                {
                    Parallel.For(0, _triangles.Length, i =>
                    {
                        FillPolygonMethod3RandomCo(_triangles[i], image, mainForm.RandomKd[i], mainForm.RandomKs[i], mainForm.RandomM[i]);
                    });
                }

            }


        }



        public static void FillPolygonSetCo(List<ActiveEdge> edges, DirectBitmap image)
        {
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N * Vector3D.DotProduct(N, L)- L;
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
                                if(!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;
                                R.Normalize();
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
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;
                                R.Normalize();
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

        public static void FillPolygonRandomCo(List<ActiveEdge> edges, DirectBitmap image, double kd, double ks, double m)
        {
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N * Vector3D.DotProduct(N, L) - L;
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
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }

                                R = 2 * N * Vector3D.DotProduct(N, L) - L;
                                R.Normalize();
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
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;
                                R.Normalize();
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

        private static void FillPolygonMethod2SetCo(Polygon p, DirectBitmap image)
        {
            Triangle t = (Triangle)p;
            var edges = t.ActiveEdges;
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N * Vector3D.DotProduct(N, L) - L;
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
                Color objectColorA = objectColor;
                Color objectColorB = objectColor;
                Color objectColorC = objectColor;

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                Vector3D VectorRA = R;
                Vector3D VectorRB = R;
                Vector3D VectorRC = R;

                Vector3D VectorLA = L;
                Vector3D VectorLB = L;
                Vector3D VectorLC = L;

                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }
                if (!mainForm.ConstLightSource)
                {
                    VectorLA = new Vector3D(mainForm.LightSource.X - t.A.X, mainForm.LightSource.Y - t.A.Y, mainForm.LightSource.Z);
                    VectorLA.Normalize();

                    VectorLB = new Vector3D(mainForm.LightSource.X - t.B.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLB.Normalize();

                    VectorLC = new Vector3D(mainForm.LightSource.X - t.C.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLC.Normalize();
                }

                VectorRA = 2 * VectorNA * Vector3D.DotProduct(VectorNA, VectorLA) - VectorLA;
                VectorRA.Normalize();

                VectorRB = 2 * VectorNB * Vector3D.DotProduct(VectorNB, VectorLB) - VectorLB;
                VectorRB.Normalize();

                VectorRC = 2 * VectorNC * Vector3D.DotProduct(VectorNC, VectorLC) - VectorLC;
                VectorRC.Normalize();

                Color colorA = CalculateColor(lightColor, objectColorA, VectorNA, VectorLA, VectorRA, V, m, kd, ks);
                Color colorB = CalculateColor(lightColor, objectColorB, VectorNB, VectorLB, VectorRB, V, m, kd, ks);
                Color colorC = CalculateColor(lightColor, objectColorC, VectorNC, VectorLC, VectorRC, V, m, kd, ks);

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
                                //objectColor = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC);


                                Color c = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), colorA, colorB, colorC);
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
                Color objectColorA = mainForm.ObjectColorTexture.GetPixel(t.A.X % mainForm.ObjectColorTexture.Width, t.A.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorB = mainForm.ObjectColorTexture.GetPixel(t.B.X % mainForm.ObjectColorTexture.Width, t.B.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorC = mainForm.ObjectColorTexture.GetPixel(t.C.X % mainForm.ObjectColorTexture.Width, t.C.Y % mainForm.ObjectColorTexture.Height);

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                Vector3D VectorRA = R;
                Vector3D VectorRB = R;
                Vector3D VectorRC = R;

                Vector3D VectorLA = L;
                Vector3D VectorLB = L;
                Vector3D VectorLC = L;

                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }
                if (!mainForm.ConstLightSource)
                {
                    VectorLA = new Vector3D(mainForm.LightSource.X - t.A.X, mainForm.LightSource.Y - t.A.Y, mainForm.LightSource.Z);
                    VectorLA.Normalize();

                    VectorLB = new Vector3D(mainForm.LightSource.X - t.B.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLB.Normalize();

                    VectorLC = new Vector3D(mainForm.LightSource.X - t.C.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLC.Normalize();
                }

                VectorRA = 2 * VectorNA * Vector3D.DotProduct(VectorNA, VectorLA) - VectorLA;
                VectorRA.Normalize();

                VectorRB = 2 * VectorNB * Vector3D.DotProduct(VectorNB, VectorLB) - VectorLB;
                VectorRB.Normalize();

                VectorRC = 2 * VectorNC * Vector3D.DotProduct(VectorNC, VectorLC) - VectorLC;
                VectorRC.Normalize();

                Color colorA = CalculateColor(lightColor, objectColorA, VectorNA, VectorLA, VectorRA, V, m, kd, ks);
                Color colorB = CalculateColor(lightColor, objectColorB, VectorNB, VectorLB, VectorRB, V, m, kd, ks);
                Color colorC = CalculateColor(lightColor, objectColorC, VectorNC, VectorLC, VectorRC, V, m, kd, ks);

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
                                //objectColor = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC);


                                Color c = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), colorA, colorB, colorC);
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

        private static void FillPolygonMethod2RandomCo(Polygon p, DirectBitmap image, double kd, double ks, double m)
        {
            Triangle t = (Triangle)p;
            var edges = t.ActiveEdges;
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N * Vector3D.DotProduct(N, L) - L;
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
                Color objectColorA = objectColor;
                Color objectColorB = objectColor;
                Color objectColorC = objectColor;

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                Vector3D VectorRA = R;
                Vector3D VectorRB = R;
                Vector3D VectorRC = R;

                Vector3D VectorLA = L;
                Vector3D VectorLB = L;
                Vector3D VectorLC = L;

                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }
                if (!mainForm.ConstLightSource)
                {
                    VectorLA = new Vector3D(mainForm.LightSource.X - t.A.X, mainForm.LightSource.Y - t.A.Y, mainForm.LightSource.Z);
                    VectorLA.Normalize();

                    VectorLB = new Vector3D(mainForm.LightSource.X - t.B.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLB.Normalize();

                    VectorLC = new Vector3D(mainForm.LightSource.X - t.C.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLC.Normalize();
                }

                VectorRA = 2 * VectorNA * Vector3D.DotProduct(VectorNA, VectorLA) - VectorLA;
                VectorRA.Normalize();

                VectorRB = 2 * VectorNB * Vector3D.DotProduct(VectorNB, VectorLB) - VectorLB;
                VectorRB.Normalize();

                VectorRC = 2 * VectorNC * Vector3D.DotProduct(VectorNC, VectorLC) - VectorLC;
                VectorRC.Normalize();

                Color colorA = CalculateColor(lightColor, objectColorA, VectorNA, VectorLA, VectorRA, V, m, kd, ks);
                Color colorB = CalculateColor(lightColor, objectColorB, VectorNB, VectorLB, VectorRB, V, m, kd, ks);
                Color colorC = CalculateColor(lightColor, objectColorC, VectorNC, VectorLC, VectorRC, V, m, kd, ks);

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
                                //objectColor = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC);


                                Color c = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), colorA, colorB, colorC);
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
                Color objectColorA = mainForm.ObjectColorTexture.GetPixel(t.A.X % mainForm.ObjectColorTexture.Width, t.A.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorB = mainForm.ObjectColorTexture.GetPixel(t.B.X % mainForm.ObjectColorTexture.Width, t.B.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorC = mainForm.ObjectColorTexture.GetPixel(t.C.X % mainForm.ObjectColorTexture.Width, t.C.Y % mainForm.ObjectColorTexture.Height);

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                Vector3D VectorRA = R;
                Vector3D VectorRB = R;
                Vector3D VectorRC = R;

                Vector3D VectorLA = L;
                Vector3D VectorLB = L;
                Vector3D VectorLC = L;

                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }
                if (!mainForm.ConstLightSource)
                {
                    VectorLA = new Vector3D(mainForm.LightSource.X - t.A.X, mainForm.LightSource.Y - t.A.Y, mainForm.LightSource.Z);
                    VectorLA.Normalize();

                    VectorLB = new Vector3D(mainForm.LightSource.X - t.B.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLB.Normalize();

                    VectorLC = new Vector3D(mainForm.LightSource.X - t.C.X, mainForm.LightSource.Y - t.C.Y, mainForm.LightSource.Z);
                    VectorLC.Normalize();
                }

                VectorRA = 2 * VectorNA * Vector3D.DotProduct(VectorNA, VectorLA) - VectorLA;
                VectorRA.Normalize();

                VectorRB = 2 * VectorNB * Vector3D.DotProduct(VectorNB, VectorLB) - VectorLB;
                VectorRB.Normalize();

                VectorRC = 2 * VectorNC * Vector3D.DotProduct(VectorNC, VectorLC) - VectorLC;
                VectorRC.Normalize();

                Color colorA = CalculateColor(lightColor, objectColorA, VectorNA, VectorLA, VectorRA, V, m, kd, ks);
                Color colorB = CalculateColor(lightColor, objectColorB, VectorNB, VectorLB, VectorRB, V, m, kd, ks);
                Color colorC = CalculateColor(lightColor, objectColorC, VectorNC, VectorLC, VectorRC, V, m, kd, ks);

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
                                //objectColor = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC);


                                Color c = CalculateObjectColor(t.A, t.B, t.C, new Point(x1, i), colorA, colorB, colorC);
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

        private static void FillPolygonMethod3SetCo(Polygon p, DirectBitmap image)
        {
            Triangle t = (Triangle)p;
            var edges = t.ActiveEdges;
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N * Vector3D.DotProduct(N, L) - L;
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
                Color objectColorA = objectColor;
                Color objectColorB = objectColor;
                Color objectColorC = objectColor;

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                if (!mainForm.ConstVectorN)
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }
                
                

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
                                (objectColor, N) = CalculateObjectColorAndN(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC, VectorNA, VectorNB, VectorNC);
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;


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
                Color objectColorA = mainForm.ObjectColorTexture.GetPixel(t.A.X % mainForm.ObjectColorTexture.Width, t.A.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorB = mainForm.ObjectColorTexture.GetPixel(t.B.X % mainForm.ObjectColorTexture.Width, t.B.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorC = mainForm.ObjectColorTexture.GetPixel(t.C.X % mainForm.ObjectColorTexture.Width, t.C.Y % mainForm.ObjectColorTexture.Height);

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }
                

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
                                (objectColor, N) = CalculateObjectColorAndN(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC, VectorNA, VectorNB, VectorNC);
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;


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

        private static void FillPolygonMethod3RandomCo(Polygon p, DirectBitmap image, double kd, double ks, double m)
        {
            Triangle t = (Triangle)p;
            var edges = t.ActiveEdges;
            Vector3D N = mainForm.defaultN;
            Vector3D L = mainForm.defaultL;
            Vector3D V = new Vector3D(0, 0, 1);
            Vector3D R = 2 * N * Vector3D.DotProduct(N, L) - L;
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
                Color objectColorA = objectColor;
                Color objectColorB = objectColor;
                Color objectColorC = objectColor;

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                if (!mainForm.ConstVectorN)
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }



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
                                (objectColor, N) = CalculateObjectColorAndN(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC, VectorNA, VectorNB, VectorNC);
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;


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
                Color objectColorA = mainForm.ObjectColorTexture.GetPixel(t.A.X % mainForm.ObjectColorTexture.Width, t.A.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorB = mainForm.ObjectColorTexture.GetPixel(t.B.X % mainForm.ObjectColorTexture.Width, t.B.Y % mainForm.ObjectColorTexture.Height);
                Color objectColorC = mainForm.ObjectColorTexture.GetPixel(t.C.X % mainForm.ObjectColorTexture.Width, t.C.Y % mainForm.ObjectColorTexture.Height);

                Vector3D VectorNA = N;
                Vector3D VectorNB = N;
                Vector3D VectorNC = N;

                if (!mainForm.ConstVectorN)//obliczany w kazdym punkcie
                {
                    Color pixel = mainForm.VectorNTexture.GetPixel(t.A.X % mainForm.VectorNTexture.Width, t.A.Y % mainForm.VectorNTexture.Height);
                    double r = pixel.R;
                    double g = pixel.G;
                    double b = pixel.B;
                    double X = r / 255.0 * 2.0 - 1.0;
                    double Y = g / 255.0 * 2.0 - 1.0;
                    double Z = b / 255.0;
                    VectorNA.X = X;
                    VectorNA.Y = Y;
                    VectorNA.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.B.X % mainForm.VectorNTexture.Width, t.B.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNB.X = X;
                    VectorNB.Y = Y;
                    VectorNB.Z = Z;

                    pixel = mainForm.VectorNTexture.GetPixel(t.C.X % mainForm.VectorNTexture.Width, t.C.Y % mainForm.VectorNTexture.Height);
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    X = r / 255.0 * 2.0 - 1.0;
                    Y = g / 255.0 * 2.0 - 1.0;
                    Z = b / 255.0;
                    VectorNC.X = X;
                    VectorNC.Y = Y;
                    VectorNC.Z = Z;
                }


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
                                (objectColor, N) = CalculateObjectColorAndN(t.A, t.B, t.C, new Point(x1, i), objectColorA, objectColorB, objectColorC, VectorNA, VectorNB, VectorNC);
                                if (!mainForm.ConstLightSource)
                                {
                                    L = new Vector3D(mainForm.LightSource.X - x1, mainForm.LightSource.Y - i, mainForm.LightSource.Z);
                                    L.Normalize();
                                }
                                R = 2 * N * Vector3D.DotProduct(N, L) - L;


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
            int cR = (int)(kd * lightColor.R * objectcolor.R * myCos(N, L) + ks * lightColor.R * objectcolor.R * Math.Pow(myCos(V, R), m)) / 255;
            if (cR > 255)
                cR = 255;
            if (cR < 0)
                cR = 0;

            int cG = (int)(kd * lightColor.G * objectcolor.G * myCos(N, L) + ks * lightColor.G * objectcolor.G * Math.Pow(myCos(V, R), m)) / 255;
            if (cG > 255)
                cG = 255;
            if (cG < 0)
                cG = 0;
            int cB = (int)(kd * lightColor.B * objectcolor.B * myCos(N, L) + ks * lightColor.B * objectcolor.B * Math.Pow(myCos(V, R), m)) /255;
            if (cB > 255)
                cB = 255;
            if (cB < 0)
                cB = 0;
            return Color.FromArgb(cR , cG, cB );

        }

        private static double myCos(Vector3D a, Vector3D b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }


        private static Color CalculateObjectColor(Point A, Point B, Point C, Point p, Color cA, Color cB, Color cC)
        {
            double denominator = ((B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y));
            double l1 = ((B.Y - C.Y) * (p.X - C.X) + (C.X - B.X) * (p.Y - C.Y)) / denominator;
            double l2 = ((C.Y - A.Y) * (p.X - C.X) + (A.X - C.X) * (p.Y - C.Y)) / denominator;
            double l3 = 1.0 - l2 - l1;
            int r = (int)Math.Round(l1 * cA.R + l2 * cB.R + l3 * cC.R);
            int g = (int)Math.Round(l1 * cA.G + l2 * cB.G + l3 * cC.G);
            int b = (int)Math.Round(l1 * cA.B + l2 * cB.B + l3 * cC.B);
            if (r > 255)
                r = 255;
            if (r < 0)
                r = 0;
            if (g > 255)
                g = 255;
            if (g < 0)
                g = 0;
            if (b > 255)
                b = 255;
            if (b < 0)
                b = 0;
            return Color.FromArgb(r, g, b);
        }

        private static (Color, Vector3D) CalculateObjectColorAndN(Point A, Point B, Point C, Point p, Color cA, Color cB, Color cC, Vector3D NA, Vector3D NB, Vector3D NC)
        {
            double denominator = ((B.Y - C.Y) * (A.X - C.X) + (C.X - B.X) * (A.Y - C.Y));
            double l1 = ((B.Y - C.Y) * (p.X - C.X) + (C.X - B.X) * (p.Y - C.Y)) / denominator;
            double l2 = ((C.Y - A.Y) * (p.X - C.X) + (A.X - C.X) * (p.Y - C.Y)) / denominator;
            double l3 = 1.0 - l2 - l1;
            int r = (int)Math.Round(l1 * cA.R + l2 * cB.R + l3 * cC.R);
            int g = (int)Math.Round(l1 * cA.G + l2 * cB.G + l3 * cC.G);
            int b = (int)Math.Round(l1 * cA.B + l2 * cB.B + l3 * cC.B);
            if (r > 255)
                r = 255;
            if (r < 0)
                r = 0;
            if (g > 255)
                g = 255;
            if (g < 0)
                g = 0;
            if (b > 255)
                b = 255;
            if (b < 0)
                b = 0;
            return (Color.FromArgb(r, g, b), new Vector3D(l1 * NA.X + l2 * NB.X + l3 * NC.X, 
                                                          l1 * NA.Y + l2 * NB.Y + l3 * NC.Y,
                                                          l1 * NA.Z + l2 * NB.Z + l3 * NC.Z));
        }

    }
}
