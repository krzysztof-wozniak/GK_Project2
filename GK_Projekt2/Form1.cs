using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace GK_Projekt2
{
    public partial class mainForm : Form
    {
        private Triangles triangles = new Triangles();
        private DirectBitmap image;
        private DirectBitmap oldImage;
        public Vector3D a;
        private Pen pen = new Pen(Color.Black);
        private DirectBitmap vectorNTexture;
        private DirectBitmap objectColorTexture;
        private bool drawEdges = true;

        private int minDistanceToPoint = 10;
        private int nearestI = -1;
        private int nearestJ = -1;

        private bool constLightSource = true;
        private bool constVectorN = true;
        private bool movingPoint = false;
        private bool constObjectColor = true;

        public mainForm()
        {
            InitializeComponent();
            nTextBox.Text = triangles.N.ToString();
            mTextBox.Text = triangles.M.ToString();
            this.ActiveControl = sizeGroupBox;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            triangles.InitTriangles(mainPictureBox.Width, mainPictureBox.Height);
            UpdatePictureBox();
            //var i = vectorNTexturePicutreBox.Image;
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
            oldImage = this.image;
            this.image = new DirectBitmap(mainPictureBox.Width, mainPictureBox.Height);
            Drawer.FillPolygons(image, triangles);
            if(drawEdges)
                Drawer.DrawPolygon(image, triangles.Points, pen);
            mainPictureBox.Image = image.Bitmap;
            if(oldImage != null)
                oldImage.Dispose();
        }

        private void vectorNRadioButtonConst_CheckedChanged(object sender, EventArgs e)
        {
            if(vectorNRadioButtonConst.Checked)
            {
                constVectorN = true;
            }
            else
            {
                constVectorN = false;
            }
        }

        private void objectColorButton_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    objectColorButton.BackColor = colorDialog.Color;
                }
        }
        

        private void vectorNTexturePicutreBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
                openFileDialog.RestoreDirectory = true;
                Image image = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (vectorNTexture != null)
                        vectorNTexture.Dispose();
                    Image oldImage = vectorNTexturePicutreBox.Image;
                    image = Image.FromFile(openFileDialog.FileName);
                    Bitmap bitmap = new Bitmap(image, mainPictureBox.Width, mainPictureBox.Height);
                    vectorNTexture = new DirectBitmap(image.Width, image.Height);
                    vectorNTexture.SetBitmap(bitmap);
                    bitmap.Dispose();
                    //mainPictureBox.Image = vectorNTexture.Bitmap;
                    vectorNTexturePicutreBox.Image = image;
                    if (oldImage != null)
                        oldImage.Dispose();
                }
            }
        }

        private void objectColorTexturePictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
                openFileDialog.RestoreDirectory = true;
                Image image = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (objectColorTexture != null)
                        objectColorTexture.Dispose();
                    Image oldImage = vectorNTexturePicutreBox.Image;
                    image = Image.FromFile(openFileDialog.FileName);
                    Bitmap bitmap = new Bitmap(image, mainPictureBox.Width, mainPictureBox.Height);
                    objectColorTexture = new DirectBitmap(image.Width, image.Height);
                    objectColorTexture.SetBitmap(bitmap);
                    bitmap.Dispose();
                    mainPictureBox.Image = objectColorTexture.Bitmap;
                    objectColorTexturePictureBox.Image = image;
                    if (oldImage != null)
                        oldImage.Dispose();
                }
            }
        }

        private void lightSourceConstRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lightSourceConstRadioButton.Checked)
            {
                constLightSource = true;
            }
            else
            {
                constLightSource = false;
            }
        }

        private void objectColorSolidRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectColorSolidRadioButton.Checked)
            {
                constObjectColor = true;
            }
            else
            {
                constObjectColor = false;
            }
        }
    }
}
