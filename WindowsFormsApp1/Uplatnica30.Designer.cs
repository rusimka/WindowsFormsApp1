namespace WindowsFormsApp1
{
    partial class Uplatnica30
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.smetkaNalogodavac = new System.Windows.Forms.TextBox();
            this.smetkaNalogoPrimac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.provizija = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.iznos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smetka Nalogodavac";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Smetka Nalogoprimac";
            // 
            // smetkaNalogodavac
            // 
            this.smetkaNalogodavac.Location = new System.Drawing.Point(208, 93);
            this.smetkaNalogodavac.Name = "smetkaNalogodavac";
            this.smetkaNalogodavac.Size = new System.Drawing.Size(100, 20);
            this.smetkaNalogodavac.TabIndex = 2;
            // 
            // smetkaNalogoPrimac
            // 
            this.smetkaNalogoPrimac.Location = new System.Drawing.Point(208, 124);
            this.smetkaNalogoPrimac.Name = "smetkaNalogoPrimac";
            this.smetkaNalogoPrimac.Size = new System.Drawing.Size(100, 20);
            this.smetkaNalogoPrimac.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Provizija";
            // 
            // provizija
            // 
            this.provizija.Location = new System.Drawing.Point(208, 218);
            this.provizija.Name = "provizija";
            this.provizija.Size = new System.Drawing.Size(100, 20);
            this.provizija.TabIndex = 5;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(41, 250);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "na kraj mesec";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 286);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dodadi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Iznos";
            // 
            // iznos
            // 
            this.iznos.Location = new System.Drawing.Point(208, 174);
            this.iznos.Name = "iznos";
            this.iznos.Size = new System.Drawing.Size(100, 20);
            this.iznos.TabIndex = 9;
            // 
            // Uplatnica30
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.iznos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.provizija);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.smetkaNalogoPrimac);
            this.Controls.Add(this.smetkaNalogodavac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Uplatnica30";
            this.Text = "Uplatnica30";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox smetkaNalogodavac;
        private System.Windows.Forms.TextBox smetkaNalogoPrimac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox provizija;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox iznos;
    }
}