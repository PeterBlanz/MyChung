
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
            this.butProcess.Location = new System.Drawing.Point(12, 264);
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
            this.txtAirDens.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAirDens.Location = new System.Drawing.Point(12, 78);
            this.txtAirDens.Name = "txtAirDens";
            this.txtAirDens.Size = new System.Drawing.Size(279, 20);
            this.txtAirDens.TabIndex = 5;
            // 
            // txtMass
            // 
            this.txtMass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMass.Location = new System.Drawing.Point(12, 127);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(360, 20);
            this.txtMass.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "System mass (kg)";
            // 
            // txtCrr
            // 
            this.txtCrr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrr.Location = new System.Drawing.Point(12, 176);
            this.txtCrr.Name = "txtCrr";
            this.txtCrr.Size = new System.Drawing.Size(360, 20);
            this.txtCrr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Coefficient of rolling resistance";
            // 
            // butDens
            // 
            this.butDens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDens.Location = new System.Drawing.Point(297, 78);
            this.butDens.Name = "butDens";
            this.butDens.Size = new System.Drawing.Size(75, 20);
            this.butDens.TabIndex = 10;
            this.butDens.Text = "...";
            this.butDens.UseVisualStyleBackColor = true;
            this.butDens.Click += new System.EventHandler(this.ButDens_Click);
            // 
            // txtEff
            // 
            this.txtEff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEff.Location = new System.Drawing.Point(12, 225);
            this.txtEff.Name = "txtEff";
            this.txtEff.Size = new System.Drawing.Size(360, 20);
            this.txtEff.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Drive train efficiency (%)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
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
    }
}

