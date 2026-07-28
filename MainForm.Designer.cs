
namespace MyChung
{
    partial class MainForm
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
            this.butBrowseA = new System.Windows.Forms.Button();
            this.txtFileNamesA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAirDens = new System.Windows.Forms.TextBox();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCrr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butDens = new System.Windows.Forms.Button();
            this.txtEff = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTrimStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTrimEnd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWindCalib = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSpeedCalib = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFileNamesB = new System.Windows.Forms.TextBox();
            this.butBrowseB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butBrowseA
            // 
            this.butBrowseA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butBrowseA.Location = new System.Drawing.Point(197, 185);
            this.butBrowseA.Name = "butBrowseA";
            this.butBrowseA.Size = new System.Drawing.Size(75, 20);
            this.butBrowseA.TabIndex = 0;
            this.butBrowseA.Text = "...";
            this.butBrowseA.UseVisualStyleBackColor = true;
            this.butBrowseA.Click += new System.EventHandler(this.ButBrowseA_Click);
            // 
            // txtFileNamesA
            // 
            this.txtFileNamesA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileNamesA.Location = new System.Drawing.Point(12, 29);
            this.txtFileNamesA.Multiline = true;
            this.txtFileNamesA.Name = "txtFileNamesA";
            this.txtFileNamesA.Size = new System.Drawing.Size(260, 150);
            this.txtFileNamesA.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File set A";
            // 
            // butProcess
            // 
            this.butProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butProcess.Location = new System.Drawing.Point(12, 414);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(535, 37);
            this.butProcess.TabIndex = 3;
            this.butProcess.Text = "Process";
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.ButProcess_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Air density (kg/m³)";
            // 
            // txtAirDens
            // 
            this.txtAirDens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAirDens.Location = new System.Drawing.Point(12, 239);
            this.txtAirDens.Name = "txtAirDens";
            this.txtAirDens.Size = new System.Drawing.Size(210, 20);
            this.txtAirDens.TabIndex = 5;
            // 
            // txtMass
            // 
            this.txtMass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMass.Location = new System.Drawing.Point(287, 239);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(260, 20);
            this.txtMass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "System mass (kg)";
            // 
            // txtCrr
            // 
            this.txtCrr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCrr.Location = new System.Drawing.Point(12, 287);
            this.txtCrr.Name = "txtCrr";
            this.txtCrr.Size = new System.Drawing.Size(260, 20);
            this.txtCrr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Coefficient of rolling resistance";
            // 
            // butDens
            // 
            this.butDens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDens.Location = new System.Drawing.Point(228, 238);
            this.butDens.Name = "butDens";
            this.butDens.Size = new System.Drawing.Size(44, 20);
            this.butDens.TabIndex = 10;
            this.butDens.Text = "...";
            this.butDens.UseVisualStyleBackColor = true;
            this.butDens.Click += new System.EventHandler(this.ButDens_Click);
            // 
            // txtEff
            // 
            this.txtEff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEff.Location = new System.Drawing.Point(287, 287);
            this.txtEff.Name = "txtEff";
            this.txtEff.Size = new System.Drawing.Size(260, 20);
            this.txtEff.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(284, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Drive train efficiency (%)";
            // 
            // txtTrimStart
            // 
            this.txtTrimStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTrimStart.Location = new System.Drawing.Point(12, 335);
            this.txtTrimStart.Name = "txtTrimStart";
            this.txtTrimStart.Size = new System.Drawing.Size(260, 20);
            this.txtTrimStart.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Trim from start (m)";
            // 
            // txtTrimEnd
            // 
            this.txtTrimEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrimEnd.Location = new System.Drawing.Point(287, 335);
            this.txtTrimEnd.Name = "txtTrimEnd";
            this.txtTrimEnd.Size = new System.Drawing.Size(260, 20);
            this.txtTrimEnd.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Trim from end (m)";
            // 
            // txtWindCalib
            // 
            this.txtWindCalib.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtWindCalib.Location = new System.Drawing.Point(12, 383);
            this.txtWindCalib.Name = "txtWindCalib";
            this.txtWindCalib.Size = new System.Drawing.Size(260, 20);
            this.txtWindCalib.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Wind calibration factor";
            // 
            // txtSpeedCalib
            // 
            this.txtSpeedCalib.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpeedCalib.Location = new System.Drawing.Point(287, 383);
            this.txtSpeedCalib.Name = "txtSpeedCalib";
            this.txtSpeedCalib.Size = new System.Drawing.Size(260, 20);
            this.txtSpeedCalib.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(284, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Speed/distance calibration factor";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "File set B";
            // 
            // txtFileNamesB
            // 
            this.txtFileNamesB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileNamesB.Location = new System.Drawing.Point(287, 29);
            this.txtFileNamesB.Multiline = true;
            this.txtFileNamesB.Name = "txtFileNamesB";
            this.txtFileNamesB.Size = new System.Drawing.Size(260, 150);
            this.txtFileNamesB.TabIndex = 2;
            // 
            // butBrowseB
            // 
            this.butBrowseB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowseB.Location = new System.Drawing.Point(472, 185);
            this.butBrowseB.Name = "butBrowseB";
            this.butBrowseB.Size = new System.Drawing.Size(75, 20);
            this.butBrowseB.TabIndex = 21;
            this.butBrowseB.Text = "...";
            this.butBrowseB.UseVisualStyleBackColor = true;
            this.butBrowseB.Click += new System.EventHandler(this.ButBrowseB_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 461);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFileNamesB);
            this.Controls.Add(this.butBrowseB);
            this.Controls.Add(this.txtSpeedCalib);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtWindCalib);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTrimEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTrimStart);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butDens);
            this.Controls.Add(this.txtCrr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAirDens);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileNamesA);
            this.Controls.Add(this.butBrowseA);
            this.MaximumSize = new System.Drawing.Size(575, 2000);
            this.MinimumSize = new System.Drawing.Size(575, 500);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Chung Analysis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBrowseA;
        private System.Windows.Forms.TextBox txtFileNamesA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butProcess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAirDens;
        private System.Windows.Forms.TextBox txtMass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCrr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butDens;
        private System.Windows.Forms.TextBox txtEff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrimStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTrimEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWindCalib;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSpeedCalib;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFileNamesB;
        private System.Windows.Forms.Button butBrowseB;
    }
}

