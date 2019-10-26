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
            //triangles.InitTriangles(mainPictureBox.Width - 50, mainPictureBox.Height - 50);
            nTextBox.Text = triangles.N.ToString();
            mTextBox.Text = triangles.M.ToString();
            this.ActiveControl = configureGroupBox;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //image = new Bitmap(mainPictureBox.Image.Width, mainPictureBox.Height);
            //mainPictureBox.Image = image;
            //triangles.InitTriangles(image.Width, image.Height);
            //triangles.DrawTriangles(image);
            //Image oldImage = mainPictureBox.Image;
            //mainPictureBox.Image = image;
            //oldImage.Dispose();

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

        

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (ValidateN() && ValidateM())
            {
                if(nTextBox.Text != "")
                {
                    triangles.N = Int32.Parse(nTextBox.Text);
                }
                if(mTextBox.Text != "")
                {
                    triangles.M = Int32.Parse(mTextBox.Text);
                }
                Image image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
                mainPictureBox.Image = image;
                triangles.InitTriangles(image.Width, image.Height);
                triangles.DrawTriangles(image);
            }
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




        private void UpdatePictureBox()
        {
            Image oldImage = mainPictureBox.Image;
            Image image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            triangles.DrawTriangles(image);
            mainPictureBox.Image = image;
            if(oldImage != null)
                oldImage.Dispose();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            /*Image image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            mainPictureBox.Image = image;
            triangles.InitTriangles(image.Width, image.Height);
            triangles.DrawTriangles(image);*/
        }

        private void mainPictureBox_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Image image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            //mainPictureBox.Image = image;
            triangles.InitTriangles(image.Width, image.Height);
            triangles.DrawTriangles(image);
        }
    }
}
