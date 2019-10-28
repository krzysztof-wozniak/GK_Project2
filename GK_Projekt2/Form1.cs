using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GK_Projekt2
{
    public partial class mainForm : Form
    {
        private Triangles triangles = new Triangles();
        private Bitmap image;
        private Image oldImage;
        

        private int minDistanceToPoint = 10;
        private int nearestI = -1;
        private int nearestJ = -1;

        private bool movingPoint = false;

        public mainForm()
        {
            InitializeComponent();
            nTextBox.Text = triangles.N.ToString();
            mTextBox.Text = triangles.M.ToString();
            this.ActiveControl = configureGroupBox;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            triangles.InitTriangles(mainPictureBox.Width, mainPictureBox.Height);
            UpdatePictureBox();
        }

        private void mainPictureBox_Layout(object sender, LayoutEventArgs e)
        {
            RefreshTriangles();
        }

        /// <summary>
        /// Redraws all objects without changing the Picturebox image
        /// </summary>
        private void RefreshTriangles()
        {
            triangles.DrawTriangles(mainPictureBox.Image);
        }

        

        
        /*
         ***********************************
         *-----------Validating-------------
         ***********************************
         */

        private bool ValidateN()
        {
            bool status = true;
            if (nTextBox.Text == "" || (Int32.TryParse(nTextBox.Text, out int n) && n >= 1))
            {
                errorProvider1.SetError(nTextBox, "");
            }
            else
            {
                errorProvider1.SetError(nTextBox, "Please enter a positve integer");
                status = false;
            }
            return status;
        }

        private bool ValidateM()
        {
            bool status = true;
            if (nTextBox.Text == "" || (Int32.TryParse(mTextBox.Text, out int n) && n >= 1))
            {
                errorProvider1.SetError(mTextBox, "");
            }
            else
            {
                errorProvider1.SetError(mTextBox, "Please enter a positve integer");
                status = false;
            }
            return status;
        }

        private void nTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateN();
        }

        private void mTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateM();
        }


        /*
         ***********************************
         *-------------Events---------------
         ***********************************
         */

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            if(movingPoint)
            {
                triangles.MovePoint(nearestI, nearestJ, mousePoint);
                UpdatePictureBox();
                return;
            }
            (int i, int j, double dis) = triangles.FindNearestPoint(mousePoint);
            if(dis <= minDistanceToPoint)
            {
                nearestI = i;
                nearestJ = j;
                return;
            }
            nearestI = -1;
            nearestJ = -1;
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(nearestI == -1 && nearestJ == 1)
            {
                return;
            }
            movingPoint = true;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            movingPoint = false;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (ValidateN() && ValidateM())
            {
                if (nTextBox.Text != "")
                {
                    triangles.N = Int32.Parse(nTextBox.Text);
                }
                if (mTextBox.Text != "")
                {
                    triangles.M = Int32.Parse(mTextBox.Text);
                }
                //Image image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
                //mainPictureBox.Image = image;
                triangles.InitTriangles(mainPictureBox.Width, mainPictureBox.Height);
                UpdatePictureBox();
                //triangles.DrawTriangles(image);
            }
        }

        
        private void UpdatePictureBox()
        {
            Image oldImage = mainPictureBox.Image;
            Bitmap image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            
            FillTriangles(image);
            triangles.DrawTriangles(image);
            mainPictureBox.Image = image;
            if(oldImage != null)
                oldImage.Dispose();
        }
        
        //ET tablica 
        private void FillTriangles(Bitmap image)
        {
            triangles.InitActiveEdges();
            List<ActiveEdge> activeEdges = triangles.ActiveEdges;
            List<ActiveEdge>[] ET = new List<ActiveEdge>[image.Height];
            foreach(ActiveEdge e in activeEdges)
            {
                if (ET[e.yMin] == null)
                    ET[e.yMin] = new List<ActiveEdge>();
                ET[e.yMin].Add(e);
            }//tablica ET
            int y = -1;
            for(int i = 0; i < ET.Length; i++)
            {
                if (ET[i] != null)
                {
                    y = i;
                    break;
                }
            }//najmniejszy index y
            var AET = new List<ActiveEdge>();
            for(int i = y; i < ET.Length; i++)
            {
                if (ET[i] != null)
                    AET.AddRange(ET[i]);
                AET.Sort((e1, e2) => e1.x.CompareTo(e2.x));//posortowane
                for(int j = 0; j + 1< AET.Count; j += 2)
                {
                    int x1 = (int)Math.Round(AET[j].x);
                    int x2 = (int)Math.Round(AET[j + 1].x);
                    while(x1 < x2)
                    {
                        double ratio = (double)x1 / (double)image.Width;
                        image.SetPixel(x1++, i, Color.FromArgb((int)(255 * (1 - ratio)), (int)(255 * ratio), (int)(255 * ratio)));
                    }
                }
                AET.RemoveAll(x => x.yMax == i);
                foreach(var e in AET)
                {
                    e.IncreaseX();
                }
            }

        }
        
    }
}
