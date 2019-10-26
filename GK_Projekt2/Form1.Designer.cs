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
            this.configureGroupBox = new System.Windows.Forms.GroupBox();
            this.nLabel = new System.Windows.Forms.Label();
            this.mLabel = new System.Windows.Forms.Label();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.configureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.BackColor = System.Drawing.Color.White;
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(624, 444);
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
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(800, 450);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.configureGroupBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(633, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.64865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 318F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(164, 444);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // configureGroupBox
            // 
            this.configureGroupBox.Controls.Add(this.resetButton);
            this.configureGroupBox.Controls.Add(this.mTextBox);
            this.configureGroupBox.Controls.Add(this.nTextBox);
            this.configureGroupBox.Controls.Add(this.mLabel);
            this.configureGroupBox.Controls.Add(this.nLabel);
            this.configureGroupBox.Location = new System.Drawing.Point(3, 3);
            this.configureGroupBox.Name = "configureGroupBox";
            this.configureGroupBox.Size = new System.Drawing.Size(158, 120);
            this.configureGroupBox.TabIndex = 0;
            this.configureGroupBox.TabStop = false;
            this.configureGroupBox.Text = "Configure";
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Location = new System.Drawing.Point(6, 28);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(27, 13);
            this.nLabel.TabIndex = 0;
            this.nLabel.Text = "N = ";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(6, 57);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(28, 13);
            this.mLabel.TabIndex = 1;
            this.mLabel.Text = "M = ";
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(39, 25);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(100, 20);
            this.nTextBox.TabIndex = 2;
            this.nTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nTextBox_Validating);
            // 
            // mTextBox
            // 
            this.mTextBox.Location = new System.Drawing.Point(40, 54);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(100, 20);
            this.mTextBox.TabIndex = 3;
            this.mTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.mTextBox_Validating);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(39, 91);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Name = "mainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.configureGroupBox.ResumeLayout(false);
            this.configureGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox configureGroupBox;
        private System.Windows.Forms.TextBox mTextBox;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

