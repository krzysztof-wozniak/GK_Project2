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

        public static DirectBitmap VectorNTexture { get; private set; }
        public static DirectBitmap ObjectColorTexture { get; private set; }

        private bool drawEdges = true;
        private int minDistanceToPoint = 10;
        private int nearestI = -1;
        private int nearestJ = -1;
        private bool movingPoint = false;


        public static bool ConstLightSource { get; private set; }
        public static bool ConstVectorN { get; private set; }
        public static bool ConstObjectColor { get; private set; }
        public static bool SetCoefficient { get; private set; }
        public static Color ObjectColor { get; private set; }
        public static Color LightColor { get; private set; }
        public static double KdCo { get; private set; }
        public static double KsCo { get; private set; }
        public static double MCo { get; private set; }
        public static bool Method1 { get; private set; }
        public static bool Method2 { get; private set; }
        public static bool Method3 { get; private set; }
        public static Vector3D defaultN { get; private set; }
        public static Vector3D defaultL { get; private set; }
        public static Point3D LightSource { get; private set; }


        public mainForm()
        {
            InitializeComponent();
            nTextBox.Text = triangles.N.ToString();
            mTextBox.Text = triangles.M.ToString();
            this.ActiveControl = sizeGroupBox;
            ObjectColor = objectColorPictureBox.BackColor;
            ConstLightSource = true;
            ConstVectorN = true;
            ConstObjectColor = true;
            //ObjectColorTexture = new Bitmap("koala.jpg")
            lightSourceColorPictureBox.BackColor = Color.FromArgb(1, 1, 1);
            LightColor = lightSourceColorPictureBox.BackColor;
            KdCo = 0.5;
            KsCo = 0.5;
            MCo = 50;
            Method1 = true;
            Method2 = false;
            Method3 = false;
            defaultN = new Vector3D(0, 0, 1);
            defaultL = new Vector3D(0, 0, 1);
            ObjectColorTexture = new DirectBitmap(mainPictureBox.Width, mainPictureBox.Height);
            Bitmap temp = new Bitmap(GK_Projekt2.Properties.Resources.newkoala, mainPictureBox.Width, mainPictureBox.Height);
            ObjectColorTexture.SetBitmap(temp);
            temp.Dispose();
            //var l = GK_Projekt2.Properties.Resources.brick_normalmap;
            temp = new Bitmap(GK_Projekt2.Properties.Resources.normalbrickwall);
            VectorNTexture = new DirectBitmap(temp.Width, temp.Height);
            VectorNTexture.SetBitmap(temp);
            temp.Dispose();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            triangles.InitTriangles(mainPictureBox.Width, mainPictureBox.Height);
            UpdatePictureBox();
            //SolidColor = objectColorPictureBox.BackColor;
            //ConstLightSource = true;
            //ConstVectorN = true;
            //ConstObjectColor = true;
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
            if(drawEdgeCheckBox.Checked)
                Drawer.DrawPolygon(image, triangles.Points, pen);
            mainPictureBox.Image = image.Bitmap;
            if(oldImage != null)
                oldImage.Dispose();
        }

        private void vectorNRadioButtonConst_CheckedChanged(object sender, EventArgs e)
        {
            if(vectorNRadioButtonConst.Checked)
            {
                ConstVectorN = true;
            }
            else
            {
                ConstVectorN = false;
            }
            UpdatePictureBox();
        }
        
        

        private void vectorNTexturePictureBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
                openFileDialog.RestoreDirectory = true;
                Image image = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (VectorNTexture != null)
                        VectorNTexture.Dispose();
                    Image oldImage = vectorNTexturePictureBox.Image;
                    image = Image.FromFile(openFileDialog.FileName);
                    Bitmap bitmap = new Bitmap(image, mainPictureBox.Width, mainPictureBox.Height);
                    VectorNTexture = new DirectBitmap(image.Width, image.Height);
                    VectorNTexture.SetBitmap(bitmap);
                    bitmap.Dispose();
                    //mainPictureBox.Image = vectorNTexture.Bitmap;
                    vectorNTexturePictureBox.Image = image;
                    if (oldImage != null)
                        oldImage.Dispose();
                    UpdatePictureBox();
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
                    if (ObjectColorTexture != null)
                        ObjectColorTexture.Dispose();
                    Image oldImage = vectorNTexturePictureBox.Image;
                    image = Image.FromFile(openFileDialog.FileName);
                    Bitmap bitmap = new Bitmap(image, mainPictureBox.Width, mainPictureBox.Height);
                    ObjectColorTexture = new DirectBitmap(image.Width, image.Height);
                    ObjectColorTexture.SetBitmap(bitmap);
                    bitmap.Dispose();
                    //mainPictureBox.Image = ObjectColorTexture.Bitmap;
                    objectColorTexturePictureBox.Image = image;
                    if (oldImage != null)
                        oldImage.Dispose();
                    UpdatePictureBox();
                }
            }
        }

        private void lightSourceConstRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lightSourceConstRadioButton.Checked)
            {
                ConstLightSource = true;
            }
            else
            {
                ConstLightSource = false;
            }
            UpdatePictureBox();

        }

        private void objectColorSolidRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectColorSolidRadioButton.Checked)
            {
                ConstObjectColor = true;
            }
            else
            {
                ConstObjectColor = false;
            }
            UpdatePictureBox();
        }
        

        private void objectColorPictureBox_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    objectColorPictureBox.BackColor = colorDialog.Color;
                    ObjectColor = colorDialog.Color;
                    UpdatePictureBox();
                }
            }
        }

        private void lightSourceColorPictureBox_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    lightSourceColorPictureBox.BackColor = colorDialog.Color;
                    LightColor = colorDialog.Color;
                    UpdatePictureBox();
                }
            }
        }

        private void kdTrackBar_ValueChanged(object sender, EventArgs e)
        {
            KdCo = (double)kdTrackBar.Value * 0.01;
            UpdatePictureBox();
        }

        private void ksTrackBar_ValueChanged(object sender, EventArgs e)
        {
            KsCo = (double)ksTrackBar.Value * 0.01;
            UpdatePictureBox();
        }

        private void mTrackBar_ValueChanged(object sender, EventArgs e)
        {
            MCo = (double)mTrackBar.Value;
            UpdatePictureBox();
        }

        private void setCoefficientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (setCoefficientRadioButton.Checked)
            {
                SetCoefficient = true;
            }
            else
            {
                SetCoefficient = false;
            }
            UpdatePictureBox();
        }

        private void method1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(method1RadioButton.Checked)
            {
                Method1 = true;
            }
            else
            {
                Method1 = false;
            }
            UpdatePictureBox();
        }

        private void method2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (method2RadioButton.Checked)
            {
                Method2 = true;
            }
            else
            {
                Method2 = false;
            }
            UpdatePictureBox();
        }

        private void method3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (method3RadioButton.Checked)
            {
                Method3 = true;
            }
            else
            {
                Method3 = false;
            }
            UpdatePictureBox();
        }

        private void objectColorTextureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (objectColorTextureRadioButton.Checked)
            {
                ConstObjectColor = false;
            }
            else
            {
                ConstObjectColor = true;
            }
            UpdatePictureBox();
        }

        private void objectColorTexturePictureBox_Click_1(object sender, EventArgs e)
        {

        }

        private void drawEdgeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePictureBox();
        }
    }
}
