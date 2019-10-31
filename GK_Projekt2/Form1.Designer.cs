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
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.sizeGroupBox = new System.Windows.Forms.GroupBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.nLabel = new System.Windows.Forms.Label();
            this.vectorNGroupBox = new System.Windows.Forms.GroupBox();
            this.vectorNTexturePicutreBox = new System.Windows.Forms.PictureBox();
            this.vectorNRadioButtonCustom = new System.Windows.Forms.RadioButton();
            this.vectorNRadioButtonConst = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lightSourceMovingRadioButton = new System.Windows.Forms.RadioButton();
            this.lightSourceConstRadioButton = new System.Windows.Forms.RadioButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.objectColorGroupBox = new System.Windows.Forms.GroupBox();
            this.objectColorSolidRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorTextureRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorButton = new System.Windows.Forms.Button();
            this.objectColorTexturePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.sizeGroupBox.SuspendLayout();
            this.vectorNGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vectorNTexturePicutreBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.objectColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorTexturePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.White;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(624, 555);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Layout += new System.Windows.Forms.LayoutEventHandler(this.mainPictureBox_Layout);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
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
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 561);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.sizeGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vectorNGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.objectColorGroupBox, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(633, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.64865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(164, 555);
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
            this.sizeGroupBox.Size = new System.Drawing.Size(158, 95);
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
            this.vectorNGroupBox.Controls.Add(this.vectorNTexturePicutreBox);
            this.vectorNGroupBox.Controls.Add(this.vectorNRadioButtonCustom);
            this.vectorNGroupBox.Controls.Add(this.vectorNRadioButtonConst);
            this.vectorNGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vectorNGroupBox.Location = new System.Drawing.Point(3, 104);
            this.vectorNGroupBox.Name = "vectorNGroupBox";
            this.vectorNGroupBox.Size = new System.Drawing.Size(158, 98);
            this.vectorNGroupBox.TabIndex = 1;
            this.vectorNGroupBox.TabStop = false;
            this.vectorNGroupBox.Text = "Vector N";
            // 
            // vectorNTexturePicutreBox
            // 
            this.vectorNTexturePicutreBox.Image = global::GK_Projekt2.Properties.Resources.brick_normalmap;
            this.vectorNTexturePicutreBox.Location = new System.Drawing.Point(100, 42);
            this.vectorNTexturePicutreBox.Name = "vectorNTexturePicutreBox";
            this.vectorNTexturePicutreBox.Size = new System.Drawing.Size(50, 50);
            this.vectorNTexturePicutreBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.vectorNTexturePicutreBox.TabIndex = 3;
            this.vectorNTexturePicutreBox.TabStop = false;
            this.vectorNTexturePicutreBox.Click += new System.EventHandler(this.vectorNTexturePicutreBox_Click);
            // 
            // vectorNRadioButtonCustom
            // 
            this.vectorNRadioButtonCustom.AutoSize = true;
            this.vectorNRadioButtonCustom.Location = new System.Drawing.Point(10, 58);
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
            this.groupBox1.Controls.Add(this.lightSourceMovingRadioButton);
            this.groupBox1.Controls.Add(this.lightSourceConstRadioButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 64);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Light source";
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // objectColorGroupBox
            // 
            this.objectColorGroupBox.Controls.Add(this.objectColorTexturePictureBox);
            this.objectColorGroupBox.Controls.Add(this.objectColorButton);
            this.objectColorGroupBox.Controls.Add(this.objectColorTextureRadioButton);
            this.objectColorGroupBox.Controls.Add(this.objectColorSolidRadioButton);
            this.objectColorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectColorGroupBox.Location = new System.Drawing.Point(3, 278);
            this.objectColorGroupBox.Name = "objectColorGroupBox";
            this.objectColorGroupBox.Size = new System.Drawing.Size(158, 107);
            this.objectColorGroupBox.TabIndex = 3;
            this.objectColorGroupBox.TabStop = false;
            this.objectColorGroupBox.Text = "Object Color";
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
            // objectColorTextureRadioButton
            // 
            this.objectColorTextureRadioButton.AutoSize = true;
            this.objectColorTextureRadioButton.Location = new System.Drawing.Point(10, 65);
            this.objectColorTextureRadioButton.Name = "objectColorTextureRadioButton";
            this.objectColorTextureRadioButton.Size = new System.Drawing.Size(61, 17);
            this.objectColorTextureRadioButton.TabIndex = 1;
            this.objectColorTextureRadioButton.Text = "Texture";
            this.objectColorTextureRadioButton.UseVisualStyleBackColor = true;
            // 
            // objectColorButton
            // 
            this.objectColorButton.BackColor = System.Drawing.Color.Cyan;
            this.objectColorButton.FlatAppearance.BorderSize = 0;
            this.objectColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.objectColorButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.objectColorButton.Location = new System.Drawing.Point(100, 20);
            this.objectColorButton.Name = "objectColorButton";
            this.objectColorButton.Size = new System.Drawing.Size(52, 23);
            this.objectColorButton.TabIndex = 2;
            this.objectColorButton.UseVisualStyleBackColor = false;
            this.objectColorButton.Click += new System.EventHandler(this.objectColorButton_Click);
            // 
            // objectColorTexturePictureBox
            // 
            this.objectColorTexturePictureBox.Image = global::GK_Projekt2.Properties.Resources.brick_normalmap;
            this.objectColorTexturePictureBox.Location = new System.Drawing.Point(100, 49);
            this.objectColorTexturePictureBox.Name = "objectColorTexturePictureBox";
            this.objectColorTexturePictureBox.Size = new System.Drawing.Size(50, 50);
            this.objectColorTexturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.objectColorTexturePictureBox.TabIndex = 4;
            this.objectColorTexturePictureBox.TabStop = false;
            this.objectColorTexturePictureBox.Click += new System.EventHandler(this.objectColorTexturePictureBox_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "mainForm";
            this.Text = "Krzysztof Wozniak - GK Projekt 2";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.sizeGroupBox.ResumeLayout(false);
            this.sizeGroupBox.PerformLayout();
            this.vectorNGroupBox.ResumeLayout(false);
            this.vectorNGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vectorNTexturePicutreBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.objectColorGroupBox.ResumeLayout(false);
            this.objectColorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorTexturePictureBox)).EndInit();
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
        private System.Windows.Forms.PictureBox vectorNTexturePicutreBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton lightSourceConstRadioButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton lightSourceMovingRadioButton;
        private System.Windows.Forms.GroupBox objectColorGroupBox;
        private System.Windows.Forms.PictureBox objectColorTexturePictureBox;
        private System.Windows.Forms.Button objectColorButton;
        private System.Windows.Forms.RadioButton objectColorTextureRadioButton;
        private System.Windows.Forms.RadioButton objectColorSolidRadioButton;
    }
}

