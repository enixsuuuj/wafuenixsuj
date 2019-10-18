namespace RAIZ_LOGGING_SYSTEM
{
    partial class frmMain
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
            this.menustrip = new System.Windows.Forms.MenuStrip();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.surveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menustrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menustrip
            // 
            this.menustrip.BackColor = System.Drawing.Color.Green;
            this.menustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xToolStripMenuItem,
            this.surveyToolStripMenuItem,
            this.trackingToolStripMenuItem});
            this.menustrip.Location = new System.Drawing.Point(0, 0);
            this.menustrip.Name = "menustrip";
            this.menustrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menustrip.Size = new System.Drawing.Size(1461, 33);
            this.menustrip.TabIndex = 2;
            this.menustrip.Text = "menuStrip1";
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.xToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(36, 29);
            this.xToolStripMenuItem.Text = "X";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.xToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Green;
            this.statusStrip1.Location = new System.Drawing.Point(0, 774);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1461, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // surveyToolStripMenuItem
            // 
            this.surveyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem,
            this.filterDataToolStripMenuItem1});
            this.surveyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surveyToolStripMenuItem.Name = "surveyToolStripMenuItem";
            this.surveyToolStripMenuItem.Size = new System.Drawing.Size(80, 29);
            this.surveyToolStripMenuItem.Text = "Survey";
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.informationToolStripMenuItem.Text = "Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // filterDataToolStripMenuItem1
            // 
            this.filterDataToolStripMenuItem1.Name = "filterDataToolStripMenuItem1";
            this.filterDataToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.filterDataToolStripMenuItem1.Text = "Filter Data";
            this.filterDataToolStripMenuItem1.Click += new System.EventHandler(this.filterDataToolStripMenuItem1_Click);
            // 
            // trackingToolStripMenuItem
            // 
            this.trackingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informationToolStripMenuItem1});
            this.trackingToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackingToolStripMenuItem.Name = "trackingToolStripMenuItem";
            this.trackingToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.trackingToolStripMenuItem.Text = "Tracking";
            // 
            // informationToolStripMenuItem1
            // 
            this.informationToolStripMenuItem1.Name = "informationToolStripMenuItem1";
            this.informationToolStripMenuItem1.Size = new System.Drawing.Size(183, 30);
            this.informationToolStripMenuItem1.Text = "Information";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 796);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menustrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMaincs";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menustrip.ResumeLayout(false);
            this.menustrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menustrip;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem surveyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trackingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem1;
    }
}