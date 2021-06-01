
namespace EkaHarjoitus
{
    partial class Form1
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
            this.TulosteLB = new System.Windows.Forms.Label();
            this.NimiTB = new System.Windows.Forms.TextBox();
            this.PainaMinuaBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TulosteLB
            // 
            this.TulosteLB.AutoSize = true;
            this.TulosteLB.Location = new System.Drawing.Point(12, 9);
            this.TulosteLB.Name = "TulosteLB";
            this.TulosteLB.Size = new System.Drawing.Size(0, 13);
            this.TulosteLB.TabIndex = 0;
            // 
            // NimiTB
            // 
            this.NimiTB.Location = new System.Drawing.Point(12, 25);
            this.NimiTB.Name = "NimiTB";
            this.NimiTB.Size = new System.Drawing.Size(100, 20);
            this.NimiTB.TabIndex = 1;
            this.NimiTB.Text = "Syötä tähän nimesi";
            // 
            // PainaMinuaBt
            // 
            this.PainaMinuaBt.Location = new System.Drawing.Point(4, 51);
            this.PainaMinuaBt.Name = "PainaMinuaBt";
            this.PainaMinuaBt.Size = new System.Drawing.Size(116, 23);
            this.PainaMinuaBt.TabIndex = 2;
            this.PainaMinuaBt.Text = "Paina sitten minua";
            this.PainaMinuaBt.UseVisualStyleBackColor = true;
            this.PainaMinuaBt.Click += new System.EventHandler(this.PainaMinuaBt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 88);
            this.Controls.Add(this.PainaMinuaBt);
            this.Controls.Add(this.NimiTB);
            this.Controls.Add(this.TulosteLB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TulosteLB;
        private System.Windows.Forms.TextBox NimiTB;
        private System.Windows.Forms.Button PainaMinuaBt;
    }
}

