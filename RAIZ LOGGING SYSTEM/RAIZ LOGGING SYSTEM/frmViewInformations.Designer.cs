namespace RAIZ_LOGGING_SYSTEM
{
    partial class frmViewInformations
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
            this.lvSAY = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvSAY
            // 
            this.lvSAY.BackColor = System.Drawing.Color.White;
            this.lvSAY.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.lvSAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSAY.FullRowSelect = true;
            this.lvSAY.GridLines = true;
            this.lvSAY.Location = new System.Drawing.Point(12, 30);
            this.lvSAY.Name = "lvSAY";
            this.lvSAY.Size = new System.Drawing.Size(1570, 417);
            this.lvSAY.TabIndex = 559;
            this.lvSAY.UseCompatibleStateImageBehavior = false;
            this.lvSAY.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "ID";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Date";
            this.columnHeader17.Width = 200;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "To";
            this.columnHeader18.Width = 250;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Thru";
            this.columnHeader19.Width = 300;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "From";
            this.columnHeader20.Width = 300;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Subject";
            this.columnHeader21.Width = 400;
            // 
            // frmViewInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1586, 459);
            this.Controls.Add(this.lvSAY);
            this.Name = "frmViewInformations";
            this.Text = "frmViewInformations";
            this.Load += new System.EventHandler(this.frmViewInformations_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSAY;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
    }
}