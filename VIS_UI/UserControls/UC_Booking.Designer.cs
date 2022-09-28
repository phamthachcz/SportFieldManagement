
namespace VIS_UI.UserControls
{
    partial class UC_Booking
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewTimeTable = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(94)))));
            this.label2.Location = new System.Drawing.Point(440, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Information";
            // 
            // btnViewTimeTable
            // 
            this.btnViewTimeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(94)))));
            this.btnViewTimeTable.FlatAppearance.BorderSize = 0;
            this.btnViewTimeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewTimeTable.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTimeTable.ForeColor = System.Drawing.Color.White;
            this.btnViewTimeTable.Location = new System.Drawing.Point(779, 29);
            this.btnViewTimeTable.Name = "btnViewTimeTable";
            this.btnViewTimeTable.Size = new System.Drawing.Size(178, 42);
            this.btnViewTimeTable.TabIndex = 4;
            this.btnViewTimeTable.Text = "Time Table";
            this.btnViewTimeTable.UseVisualStyleBackColor = false;
            this.btnViewTimeTable.Click += new System.EventHandler(this.btnViewTimeTable_Click);
            // 
            // UC_Booking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnViewTimeTable);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_Booking";
            this.Size = new System.Drawing.Size(1080, 547);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewTimeTable;
    }
}
