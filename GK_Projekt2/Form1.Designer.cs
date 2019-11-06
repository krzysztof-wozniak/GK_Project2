namespace GK_Projekt2
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sizeGroupBox = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.nLabel = new System.Windows.Forms.Label();
            this.vectorNGroupBox = new System.Windows.Forms.GroupBox();
            this.vectorNTexturePictureBox = new System.Windows.Forms.PictureBox();
            this.vectorNRadioButtonCustom = new System.Windows.Forms.RadioButton();
            this.vectorNRadioButtonConst = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lightSourceColorPictureBox = new System.Windows.Forms.PictureBox();
            this.lightSourceMovingRadioButton = new System.Windows.Forms.RadioButton();
            this.lightSourceConstRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorGroupBox = new System.Windows.Forms.GroupBox();
            this.objectColorTexturePictureBox = new System.Windows.Forms.PictureBox();
            this.objectColorPictureBox = new System.Windows.Forms.PictureBox();
            this.objectColorTextureRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorSolidRadioButton = new System.Windows.Forms.RadioButton();
            this.coefficientsGroupBox = new System.Windows.Forms.GroupBox();
            this.mCoefficientLabel = new System.Windows.Forms.Label();
            this.ksCoefficientLabel = new System.Windows.Forms.Label();
            this.kdCoefficientLabel = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.randomCoefficientButton = new System.Windows.Forms.RadioButton();
            this.setCoefficientRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.method3RadioButton = new System.Windows.Forms.RadioButton();
            this.method2RadioButton = new System.Windows.Forms.RadioButton();
            this.method1RadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.drawEdgeCheckBox = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.sizeGroupBox.SuspendLayout();
            this.vectorNGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vectorNTexturePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightSourceColorPictureBox)).BeginInit();
            this.objectColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorTexturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorPictureBox)).BeginInit();
            this.coefficientsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.mainTableLayoutPanel.Controls.Add(this.mainPictureBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1034, 711);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.White;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(858, 705);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Layout += new System.Windows.Forms.LayoutEventHandler(this.mainPictureBox_Layout);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.sizeGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vectorNGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.objectColorGroupBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.coefficientsGroupBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(867, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.64865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(164, 705);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // sizeGroupBox
            // 
            this.sizeGroupBox.Controls.Add(this.resetButton);
            this.sizeGroupBox.Controls.Add(this.mTextBox);
            this.sizeGroupBox.Controls.Add(this.nTextBox);
            this.sizeGroupBox.Controls.Add(this.mLabel);
            this.sizeGroupBox.Controls.Add(this.nLabel);
            this.sizeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeGroupBox.Location = new System.Drawing.Point(3, 3);
            this.sizeGroupBox.Name = "sizeGroupBox";
            this.sizeGroupBox.Size = new System.Drawing.Size(158, 92);
            this.sizeGroupBox.TabIndex = 0;
            this.sizeGroupBox.TabStop = false;
            this.sizeGroupBox.Text = "Size";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(8, 68);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(143, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(38, 39);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(112, 20);
            this.mTextBox.TabIndex = 3;
            this.mTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.mTextBox_Validating);
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(38, 13);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(113, 20);
            this.nTextBox.TabIndex = 2;
            this.nTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nTextBox_Validating);
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(5, 42);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(28, 13);
            this.mLabel.TabIndex = 1;
            this.mLabel.Text = "M = ";
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Location = new System.Drawing.Point(5, 16);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(27, 13);
            this.nLabel.TabIndex = 0;
            this.nLabel.Text = "N = ";
            // 
            // vectorNGroupBox
            // 
            this.vectorNGroupBox.Controls.Add(this.vectorNTexturePictureBox);
            this.vectorNGroupBox.Controls.Add(this.vectorNRadioButtonCustom);
            this.vectorNGroupBox.Controls.Add(this.vectorNRadioButtonConst);
            this.vectorNGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vectorNGroupBox.Location = new System.Drawing.Point(3, 101);
            this.vectorNGroupBox.Name = "vectorNGroupBox";
            this.vectorNGroupBox.Size = new System.Drawing.Size(158, 81);
            this.vectorNGroupBox.TabIndex = 1;
            this.vectorNGroupBox.TabStop = false;
            this.vectorNGroupBox.Text = "Vector N";
            // 
            // vectorNTexturePictureBox
            // 
            this.vectorNTexturePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vectorNTexturePictureBox.Image = global::GK_Projekt2.Properties.Resources.normalbrickwall;
            this.vectorNTexturePictureBox.Location = new System.Drawing.Point(105, 36);
            this.vectorNTexturePictureBox.Name = "vectorNTexturePictureBox";
            this.vectorNTexturePictureBox.Size = new System.Drawing.Size(40, 40);
            this.vectorNTexturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vectorNTexturePictureBox.TabIndex = 2;
            this.vectorNTexturePictureBox.TabStop = false;
            this.vectorNTexturePictureBox.Click += new System.EventHandler(this.vectorNTexturePictureBox_Click);
            // 
            // vectorNRadioButtonCustom
            // 
            this.vectorNRadioButtonCustom.AutoSize = true;
            this.vectorNRadioButtonCustom.Location = new System.Drawing.Point(10, 47);
            this.vectorNRadioButtonCustom.Name = "vectorNRadioButtonCustom";
            this.vectorNRadioButtonCustom.Size = new System.Drawing.Size(61, 17);
            this.vectorNRadioButtonCustom.TabIndex = 1;
            this.vectorNRadioButtonCustom.Text = "Texture";
            this.vectorNRadioButtonCustom.UseVisualStyleBackColor = true;
            // 
            // vectorNRadioButtonConst
            // 
            this.vectorNRadioButtonConst.AutoSize = true;
            this.vectorNRadioButtonConst.Checked = true;
            this.vectorNRadioButtonConst.Location = new System.Drawing.Point(8, 19);
            this.vectorNRadioButtonConst.Name = "vectorNRadioButtonConst";
            this.vectorNRadioButtonConst.Size = new System.Drawing.Size(89, 17);
            this.vectorNRadioButtonConst.TabIndex = 0;
            this.vectorNRadioButtonConst.TabStop = true;
            this.vectorNRadioButtonConst.Text = "Stały [0, 0, 1]";
            this.vectorNRadioButtonConst.UseVisualStyleBackColor = true;
            this.vectorNRadioButtonConst.CheckedChanged += new System.EventHandler(this.vectorNRadioButtonConst_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lightSourceColorPictureBox);
            this.groupBox1.Controls.Add(this.lightSourceMovingRadioButton);
            this.groupBox1.Controls.Add(this.lightSourceConstRadioButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light source";
            // 
            // lightSourceColorPictureBox
            // 
            this.lightSourceColorPictureBox.BackColor = System.Drawing.Color.White;
            this.lightSourceColorPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lightSourceColorPictureBox.Location = new System.Drawing.Point(105, 25);
            this.lightSourceColorPictureBox.Name = "lightSourceColorPictureBox";
            this.lightSourceColorPictureBox.Size = new System.Drawing.Size(40, 23);
            this.lightSourceColorPictureBox.TabIndex = 6;
            this.lightSourceColorPictureBox.TabStop = false;
            this.lightSourceColorPictureBox.Click += new System.EventHandler(this.lightSourceColorPictureBox_Click);
            // 
            // lightSourceMovingRadioButton
            // 
            this.lightSourceMovingRadioButton.AutoSize = true;
            this.lightSourceMovingRadioButton.Location = new System.Drawing.Point(10, 42);
            this.lightSourceMovingRadioButton.Name = "lightSourceMovingRadioButton";
            this.lightSourceMovingRadioButton.Size = new System.Drawing.Size(60, 17);
            this.lightSourceMovingRadioButton.TabIndex = 2;
            this.lightSourceMovingRadioButton.TabStop = true;
            this.lightSourceMovingRadioButton.Text = "Moving";
            this.lightSourceMovingRadioButton.UseVisualStyleBackColor = true;
            this.lightSourceMovingRadioButton.CheckedChanged += new System.EventHandler(this.lightSourceMovingRadioButton_CheckedChanged);
            // 
            // lightSourceConstRadioButton
            // 
            this.lightSourceConstRadioButton.AutoSize = true;
            this.lightSourceConstRadioButton.Checked = true;
            this.lightSourceConstRadioButton.Location = new System.Drawing.Point(10, 19);
            this.lightSourceConstRadioButton.Name = "lightSourceConstRadioButton";
            this.lightSourceConstRadioButton.Size = new System.Drawing.Size(89, 17);
            this.lightSourceConstRadioButton.TabIndex = 1;
            this.lightSourceConstRadioButton.TabStop = true;
            this.lightSourceConstRadioButton.Text = "Fixed [0, 0, 1]";
            this.lightSourceConstRadioButton.UseVisualStyleBackColor = true;
            this.lightSourceConstRadioButton.CheckedChanged += new System.EventHandler(this.lightSourceConstRadioButton_CheckedChanged);
            // 
            // objectColorGroupBox
            // 
            this.objectColorGroupBox.Controls.Add(this.objectColorTexturePictureBox);
            this.objectColorGroupBox.Controls.Add(this.objectColorPictureBox);
            this.objectColorGroupBox.Controls.Add(this.objectColorTextureRadioButton);
            this.objectColorGroupBox.Controls.Add(this.objectColorSolidRadioButton);
            this.objectColorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectColorGroupBox.Location = new System.Drawing.Point(3, 258);
            this.objectColorGroupBox.Name = "objectColorGroupBox";
            this.objectColorGroupBox.Size = new System.Drawing.Size(158, 95);
            this.objectColorGroupBox.TabIndex = 3;
            this.objectColorGroupBox.TabStop = false;
            this.objectColorGroupBox.Text = "Object Color";
            // 
            // objectColorTexturePictureBox
            // 
            this.objectColorTexturePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.objectColorTexturePictureBox.Image = global::GK_Projekt2.Properties.Resources.newkoala;
            this.objectColorTexturePictureBox.Location = new System.Drawing.Point(105, 49);
            this.objectColorTexturePictureBox.Name = "objectColorTexturePictureBox";
            this.objectColorTexturePictureBox.Size = new System.Drawing.Size(40, 40);
            this.objectColorTexturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.objectColorTexturePictureBox.TabIndex = 6;
            this.objectColorTexturePictureBox.TabStop = false;
            this.objectColorTexturePictureBox.Click += new System.EventHandler(this.objectColorTexturePictureBox_Click);
            // 
            // objectColorPictureBox
            // 
            this.objectColorPictureBox.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.objectColorPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.objectColorPictureBox.Location = new System.Drawing.Point(105, 20);
            this.objectColorPictureBox.Name = "objectColorPictureBox";
            this.objectColorPictureBox.Size = new System.Drawing.Size(40, 23);
            this.objectColorPictureBox.TabIndex = 5;
            this.objectColorPictureBox.TabStop = false;
            this.objectColorPictureBox.Click += new System.EventHandler(this.objectColorPictureBox_Click);
            // 
            // objectColorTextureRadioButton
            // 
            this.objectColorTextureRadioButton.AutoSize = true;
            this.objectColorTextureRadioButton.Location = new System.Drawing.Point(10, 59);
            this.objectColorTextureRadioButton.Name = "objectColorTextureRadioButton";
            this.objectColorTextureRadioButton.Size = new System.Drawing.Size(61, 17);
            this.objectColorTextureRadioButton.TabIndex = 1;
            this.objectColorTextureRadioButton.Text = "Texture";
            this.objectColorTextureRadioButton.UseVisualStyleBackColor = true;
            this.objectColorTextureRadioButton.CheckedChanged += new System.EventHandler(this.objectColorTextureRadioButton_CheckedChanged);
            // 
            // objectColorSolidRadioButton
            // 
            this.objectColorSolidRadioButton.AutoSize = true;
            this.objectColorSolidRadioButton.Checked = true;
            this.objectColorSolidRadioButton.Location = new System.Drawing.Point(10, 20);
            this.objectColorSolidRadioButton.Name = "objectColorSolidRadioButton";
            this.objectColorSolidRadioButton.Size = new System.Drawing.Size(48, 17);
            this.objectColorSolidRadioButton.TabIndex = 0;
            this.objectColorSolidRadioButton.TabStop = true;
            this.objectColorSolidRadioButton.Text = "Solid";
            this.objectColorSolidRadioButton.UseVisualStyleBackColor = true;
            this.objectColorSolidRadioButton.CheckedChanged += new System.EventHandler(this.objectColorSolidRadioButton_CheckedChanged);
            // 
            // coefficientsGroupBox
            // 
            this.coefficientsGroupBox.Controls.Add(this.mCoefficientLabel);
            this.coefficientsGroupBox.Controls.Add(this.ksCoefficientLabel);
            this.coefficientsGroupBox.Controls.Add(this.kdCoefficientLabel);
            this.coefficientsGroupBox.Controls.Add(this.mTrackBar);
            this.coefficientsGroupBox.Controls.Add(this.ksTrackBar);
            this.coefficientsGroupBox.Controls.Add(this.kdTrackBar);
            this.coefficientsGroupBox.Controls.Add(this.randomCoefficientButton);
            this.coefficientsGroupBox.Controls.Add(this.setCoefficientRadioButton);
            this.coefficientsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coefficientsGroupBox.Location = new System.Drawing.Point(3, 359);
            this.coefficientsGroupBox.Name = "coefficientsGroupBox";
            this.coefficientsGroupBox.Size = new System.Drawing.Size(158, 175);
            this.coefficientsGroupBox.TabIndex = 4;
            this.coefficientsGroupBox.TabStop = false;
            this.coefficientsGroupBox.Text = "Coefficient";
            // 
            // mCoefficientLabel
            // 
            this.mCoefficientLabel.AutoSize = true;
            this.mCoefficientLabel.Location = new System.Drawing.Point(6, 143);
            this.mCoefficientLabel.Name = "mCoefficientLabel";
            this.mCoefficientLabel.Size = new System.Drawing.Size(18, 13);
            this.mCoefficientLabel.TabIndex = 7;
            this.mCoefficientLabel.Text = "m:";
            // 
            // ksCoefficientLabel
            // 
            this.ksCoefficientLabel.AutoSize = true;
            this.ksCoefficientLabel.Location = new System.Drawing.Point(5, 100);
            this.ksCoefficientLabel.Name = "ksCoefficientLabel";
            this.ksCoefficientLabel.Size = new System.Drawing.Size(22, 13);
            this.ksCoefficientLabel.TabIndex = 6;
            this.ksCoefficientLabel.Text = "Ks:";
            // 
            // kdCoefficientLabel
            // 
            this.kdCoefficientLabel.AutoSize = true;
            this.kdCoefficientLabel.Location = new System.Drawing.Point(5, 49);
            this.kdCoefficientLabel.Name = "kdCoefficientLabel";
            this.kdCoefficientLabel.Size = new System.Drawing.Size(23, 13);
            this.kdCoefficientLabel.TabIndex = 5;
            this.kdCoefficientLabel.Text = "Kd:";
            // 
            // mTrackBar
            // 
            this.mTrackBar.Location = new System.Drawing.Point(38, 138);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(113, 45);
            this.mTrackBar.TabIndex = 4;
            this.mTrackBar.Value = 50;
            this.mTrackBar.ValueChanged += new System.EventHandler(this.mTrackBar_ValueChanged);
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.Location = new System.Drawing.Point(38, 94);
            this.ksTrackBar.Maximum = 100;
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(113, 45);
            this.ksTrackBar.TabIndex = 3;
            this.ksTrackBar.Value = 50;
            this.ksTrackBar.ValueChanged += new System.EventHandler(this.ksTrackBar_ValueChanged);
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.Location = new System.Drawing.Point(38, 43);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(113, 45);
            this.kdTrackBar.TabIndex = 2;
            this.kdTrackBar.Value = 50;
            this.kdTrackBar.ValueChanged += new System.EventHandler(this.kdTrackBar_ValueChanged);
            // 
            // randomCoefficientButton
            // 
            this.randomCoefficientButton.AutoSize = true;
            this.randomCoefficientButton.Location = new System.Drawing.Point(69, 20);
            this.randomCoefficientButton.Name = "randomCoefficientButton";
            this.randomCoefficientButton.Size = new System.Drawing.Size(65, 17);
            this.randomCoefficientButton.TabIndex = 1;
            this.randomCoefficientButton.Text = "Random";
            this.randomCoefficientButton.UseVisualStyleBackColor = true;
            // 
            // setCoefficientRadioButton
            // 
            this.setCoefficientRadioButton.AutoSize = true;
            this.setCoefficientRadioButton.Checked = true;
            this.setCoefficientRadioButton.Location = new System.Drawing.Point(10, 20);
            this.setCoefficientRadioButton.Name = "setCoefficientRadioButton";
            this.setCoefficientRadioButton.Size = new System.Drawing.Size(41, 17);
            this.setCoefficientRadioButton.TabIndex = 0;
            this.setCoefficientRadioButton.TabStop = true;
            this.setCoefficientRadioButton.Text = "Set";
            this.setCoefficientRadioButton.UseVisualStyleBackColor = true;
            this.setCoefficientRadioButton.CheckedChanged += new System.EventHandler(this.setCoefficientRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.method3RadioButton);
            this.groupBox2.Controls.Add(this.method2RadioButton);
            this.groupBox2.Controls.Add(this.method1RadioButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 540);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 133);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filling method";
            // 
            // method3RadioButton
            // 
            this.method3RadioButton.AutoSize = true;
            this.method3RadioButton.Location = new System.Drawing.Point(10, 98);
            this.method3RadioButton.Name = "method3RadioButton";
            this.method3RadioButton.Size = new System.Drawing.Size(95, 17);
            this.method3RadioButton.TabIndex = 2;
            this.method3RadioButton.TabStop = true;
            this.method3RadioButton.Text = "Hybrid (TODO)";
            this.method3RadioButton.UseVisualStyleBackColor = true;
            this.method3RadioButton.CheckedChanged += new System.EventHandler(this.method3RadioButton_CheckedChanged);
            // 
            // method2RadioButton
            // 
            this.method2RadioButton.AutoSize = true;
            this.method2RadioButton.Location = new System.Drawing.Point(10, 63);
            this.method2RadioButton.Name = "method2RadioButton";
            this.method2RadioButton.Size = new System.Drawing.Size(45, 17);
            this.method2RadioButton.TabIndex = 1;
            this.method2RadioButton.TabStop = true;
            this.method2RadioButton.Text = "Fast";
            this.method2RadioButton.UseVisualStyleBackColor = true;
            this.method2RadioButton.CheckedChanged += new System.EventHandler(this.method2RadioButton_CheckedChanged);
            // 
            // method1RadioButton
            // 
            this.method1RadioButton.AutoSize = true;
            this.method1RadioButton.Checked = true;
            this.method1RadioButton.Location = new System.Drawing.Point(10, 28);
            this.method1RadioButton.Name = "method1RadioButton";
            this.method1RadioButton.Size = new System.Drawing.Size(52, 17);
            this.method1RadioButton.TabIndex = 0;
            this.method1RadioButton.TabStop = true;
            this.method1RadioButton.Text = "Exact";
            this.method1RadioButton.UseVisualStyleBackColor = true;
            this.method1RadioButton.CheckedChanged += new System.EventHandler(this.method1RadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.drawEdgeCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 679);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 23);
            this.panel1.TabIndex = 6;
            // 
            // drawEdgeCheckBox
            // 
            this.drawEdgeCheckBox.AutoSize = true;
            this.drawEdgeCheckBox.Checked = true;
            this.drawEdgeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawEdgeCheckBox.Location = new System.Drawing.Point(9, 3);
            this.drawEdgeCheckBox.Name = "drawEdgeCheckBox";
            this.drawEdgeCheckBox.Size = new System.Drawing.Size(83, 17);
            this.drawEdgeCheckBox.TabIndex = 0;
            this.drawEdgeCheckBox.Text = "Draw edges";
            this.drawEdgeCheckBox.UseVisualStyleBackColor = true;
            this.drawEdgeCheckBox.CheckedChanged += new System.EventHandler(this.drawEdgeCheckBox_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 711);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1050, 750);
            this.MinimumSize = new System.Drawing.Size(1050, 750);
            this.Name = "mainForm";
            this.Text = "Krzysztof Wozniak - GK Projekt 2";
            this.mainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.sizeGroupBox.ResumeLayout(false);
            this.sizeGroupBox.PerformLayout();
            this.vectorNGroupBox.ResumeLayout(false);
            this.vectorNGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vectorNTexturePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightSourceColorPictureBox)).EndInit();
            this.objectColorGroupBox.ResumeLayout(false);
            this.objectColorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorTexturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorPictureBox)).EndInit();
            this.coefficientsGroupBox.ResumeLayout(false);
            this.coefficientsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox sizeGroupBox;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox vectorNGroupBox;
        private System.Windows.Forms.RadioButton vectorNRadioButtonCustom;
        private System.Windows.Forms.RadioButton vectorNRadioButtonConst;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton lightSourceConstRadioButton;
        private System.Windows.Forms.RadioButton lightSourceMovingRadioButton;
        private System.Windows.Forms.GroupBox objectColorGroupBox;
        private System.Windows.Forms.RadioButton objectColorTextureRadioButton;
        private System.Windows.Forms.RadioButton objectColorSolidRadioButton;
        private System.Windows.Forms.PictureBox objectColorPictureBox;
        private System.Windows.Forms.GroupBox coefficientsGroupBox;
        private System.Windows.Forms.PictureBox lightSourceColorPictureBox;
        private System.Windows.Forms.Label mCoefficientLabel;
        private System.Windows.Forms.Label ksCoefficientLabel;
        private System.Windows.Forms.Label kdCoefficientLabel;
        private System.Windows.Forms.TrackBar mTrackBar;
        private System.Windows.Forms.TrackBar ksTrackBar;
        private System.Windows.Forms.TrackBar kdTrackBar;
        private System.Windows.Forms.RadioButton randomCoefficientButton;
        private System.Windows.Forms.RadioButton setCoefficientRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton method3RadioButton;
        private System.Windows.Forms.RadioButton method2RadioButton;
        private System.Windows.Forms.RadioButton method1RadioButton;
        private System.Windows.Forms.PictureBox vectorNTexturePictureBox;
        private System.Windows.Forms.PictureBox objectColorTexturePictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox drawEdgeCheckBox;
        private System.Windows.Forms.Timer timer1;
    }
}

