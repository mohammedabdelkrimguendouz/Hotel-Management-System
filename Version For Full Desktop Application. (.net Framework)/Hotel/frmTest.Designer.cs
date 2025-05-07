namespace Hotel
{
    partial class frmTest
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
            this.ctrlGuestInfoWithFilter1 = new Hotel.Guests.Controls.ctrlGuestInfoWithFilter();
            this.SuspendLayout();
            // 
            // ctrlGuestInfoWithFilter1
            // 
            this.ctrlGuestInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlGuestInfoWithFilter1.EnableAddNew = true;
            this.ctrlGuestInfoWithFilter1.EnableFilter = true;
            this.ctrlGuestInfoWithFilter1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlGuestInfoWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlGuestInfoWithFilter1.Name = "ctrlGuestInfoWithFilter1";
            this.ctrlGuestInfoWithFilter1.Size = new System.Drawing.Size(699, 525);
            this.ctrlGuestInfoWithFilter1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 604);
            this.Controls.Add(this.ctrlGuestInfoWithFilter1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guests.Controls.ctrlGuestInfoWithFilter ctrlGuestInfoWithFilter1;
    }
}