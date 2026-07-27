
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
            this.butBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // butBrowse
            // 
            this.butBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse.Location = new System.Drawing.Point(297, 29);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 20);
            this.butBrowse.TabIndex = 0;
            this.butBrowse.Text = "...";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.ButBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(12, 29);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(279, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "File name";
            // 
            // butProcess
            // 
            this.butProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butProcess.Location = new System.Drawing.Point(12, 479);
            this.butProcess.Name = "butProcess";
            this.butProcess.Size = new System.Drawing.Size(360, 37);
            this.butProcess.TabIndex = 3;
            this.butProcess.Text = "Process";
            this.butProcess.UseVisualStyleBackColor = true;
            this.butProcess.Click += new System.EventHandler(this.ButProcess_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Air density (kg/m³)";
            // 
            // txtAirDens
            // 
            this.txtAirDens.Location = new System.Drawing.Point(12, 78);
            this.txtAirDens.Name = "txtAirDens";
            this.txtAirDens.Size = new System.Drawing.Size(120, 20);
            this.txtAirDens.TabIndex = 5;
            // 
            // txtMass
            // 
            this.txtMass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMass.Location = new System.Drawing.Point(202, 78);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(170, 20);
            this.txtMass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "System mass (kg)";
            // 
            // txtCrr
            // 
            this.txtCrr.Location = new System.Drawing.Point(12, 126);
            this.txtCrr.Name = "txtCrr";
            this.txtCrr.Size = new System.Drawing.Size(170, 20);
            this.txtCrr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Coefficient of rolling resistance";
            // 
            // butDens
            // 
            this.butDens.Location = new System.Drawing.Point(138, 78);
            this.butDens.Name = "butDens";
            this.butDens.Size = new System.Drawing.Size(44, 20);
            this.butDens.TabIndex = 10;
            this.butDens.Text = "...";
            this.butDens.UseVisualStyleBackColor = true;
            this.butDens.Click += new System.EventHandler(this.ButDens_Click);
            // 
            // txtEff
            // 
            this.txtEff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEff.Location = new System.Drawing.Point(202, 126);
            this.txtEff.Name = "txtEff";
            this.txtEff.Size = new System.Drawing.Size(170, 20);
            this.txtEff.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Drive train efficiency (%)";
            // 
            // txtTrimStart
            // 
            this.txtTrimStart.Location = new System.Drawing.Point(12, 174);
            this.txtTrimStart.Name = "txtTrimStart";
            this.txtTrimStart.Size = new System.Drawing.Size(170, 20);
            this.txtTrimStart.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Trim from start (m)";
            // 
            // txtTrimEnd
            // 
            this.txtTrimEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrimEnd.Location = new System.Drawing.Point(202, 174);
            this.txtTrimEnd.Name = "txtTrimEnd";
            this.txtTrimEnd.Size = new System.Drawing.Size(170, 20);
            this.txtTrimEnd.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Trim from end (m)";
            // 
            // txtWindCalib
            // 
            this.txtWindCalib.Location = new System.Drawing.Point(12, 222);
            this.txtWindCalib.Name = "txtWindCalib";
            this.txtWindCalib.Size = new System.Drawing.Size(170, 20);
            this.txtWindCalib.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Wind calibration factor";
            // 
            // txtSpeedCalib
            // 
            this.txtSpeedCalib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpeedCalib.Location = new System.Drawing.Point(202, 222);
            this.txtSpeedCalib.Name = "txtSpeedCalib";
            this.txtSpeedCalib.Size = new System.Drawing.Size(170, 20);
            this.txtSpeedCalib.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Speed/distance calibration factor";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 526);
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
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.butBrowse);
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Chung Analysis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.TextBox txtFileName;
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
    }
}

