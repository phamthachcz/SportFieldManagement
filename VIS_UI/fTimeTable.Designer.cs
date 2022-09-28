
namespace VIS_UI
{
    partial class fTimeTable
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
            this.dtgvTimeTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTimeTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvTimeTable
            // 
            this.dtgvTimeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTimeTable.Location = new System.Drawing.Point(32, 56);
            this.dtgvTimeTable.Name = "dtgvTimeTable";
            this.dtgvTimeTable.RowHeadersWidth = 51;
            this.dtgvTimeTable.RowTemplate.Height = 24;
            this.dtgvTimeTable.Size = new System.Drawing.Size(1110, 117);
            this.dtgvTimeTable.TabIndex = 0;
            this.dtgvTimeTable.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgvTimeTable_RowPostPaint);
            this.dtgvTimeTable.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtgvTimeTable_RowsAdded);
            // 
            // fTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 673);
            this.Controls.Add(this.dtgvTimeTable);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fTimeTable";
            this.Text = "fTimeTable";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTimeTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvTimeTable;
    }
}