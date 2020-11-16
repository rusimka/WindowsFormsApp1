namespace WindowsFormsApp1
{
    partial class AdminMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.уплатнициToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пП10УплатницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пП40УплатницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пП30УплатницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кориснициToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.извештајToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.уплатнициToolStripMenuItem,
            this.кориснициToolStripMenuItem,
            this.извештајToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // уплатнициToolStripMenuItem
            // 
            this.уплатнициToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пП10УплатницаToolStripMenuItem,
            this.пП40УплатницаToolStripMenuItem,
            this.пП30УплатницаToolStripMenuItem});
            this.уплатнициToolStripMenuItem.Name = "уплатнициToolStripMenuItem";
            this.уплатнициToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.уплатнициToolStripMenuItem.Text = "Уплатници";
            // 
            // пП10УплатницаToolStripMenuItem
            // 
            this.пП10УплатницаToolStripMenuItem.Name = "пП10УплатницаToolStripMenuItem";
            this.пП10УплатницаToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.пП10УплатницаToolStripMenuItem.Text = "ПП-10 уплатница";
            this.пП10УплатницаToolStripMenuItem.Click += new System.EventHandler(this.пП10УплатницаToolStripMenuItem_Click);
            // 
            // пП40УплатницаToolStripMenuItem
            // 
            this.пП40УплатницаToolStripMenuItem.Name = "пП40УплатницаToolStripMenuItem";
            this.пП40УплатницаToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.пП40УплатницаToolStripMenuItem.Text = "ПП-40 уплатница";
            this.пП40УплатницаToolStripMenuItem.Click += new System.EventHandler(this.пП40УплатницаToolStripMenuItem_Click);
            // 
            // пП30УплатницаToolStripMenuItem
            // 
            this.пП30УплатницаToolStripMenuItem.Name = "пП30УплатницаToolStripMenuItem";
            this.пП30УплатницаToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.пП30УплатницаToolStripMenuItem.Text = "ПП-30 уплатница";
            this.пП30УплатницаToolStripMenuItem.Click += new System.EventHandler(this.пП30УплатницаToolStripMenuItem_Click);
            // 
            // кориснициToolStripMenuItem
            // 
            this.кориснициToolStripMenuItem.Name = "кориснициToolStripMenuItem";
            this.кориснициToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.кориснициToolStripMenuItem.Text = "Корисници";
            this.кориснициToolStripMenuItem.Click += new System.EventHandler(this.кориснициToolStripMenuItem_Click);
            // 
            // извештајToolStripMenuItem
            // 
            this.извештајToolStripMenuItem.Name = "извештајToolStripMenuItem";
            this.извештајToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.извештајToolStripMenuItem.Text = "Извештај ";
            this.извештајToolStripMenuItem.Click += new System.EventHandler(this.извештајToolStripMenuItem_Click);
            // 
            // AdminMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 423);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AdminMenu";
            this.Text = "AdminMenu";
            this.Load += new System.EventHandler(this.AdminMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem уплатнициToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пП10УплатницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пП40УплатницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пП30УплатницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кориснициToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem извештајToolStripMenuItem;
    }
}