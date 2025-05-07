namespace Hotel.Floors
{
    partial class frmAddEditFloor
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
            this.components = new System.ComponentModel.Container();
            this.lblFloorID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nudFloorNumber = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox19 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtFloorAreas = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox19)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFloorID
            // 
            this.lblFloorID.BackColor = System.Drawing.Color.Transparent;
            this.lblFloorID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorID.ForeColor = System.Drawing.Color.Black;
            this.lblFloorID.Location = new System.Drawing.Point(63, 74);
            this.lblFloorID.Name = "lblFloorID";
            this.lblFloorID.Size = new System.Drawing.Size(43, 23);
            this.lblFloorID.TabIndex = 152;
            this.lblFloorID.Text = "[????]";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(73, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 47);
            this.lblTitle.TabIndex = 151;
            this.lblTitle.Text = "Add New Floor";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // nudFloorNumber
            // 
            this.nudFloorNumber.BackColor = System.Drawing.Color.Transparent;
            this.nudFloorNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudFloorNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudFloorNumber.Location = new System.Drawing.Point(63, 103);
            this.nudFloorNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFloorNumber.Name = "nudFloorNumber";
            this.nudFloorNumber.Size = new System.Drawing.Size(100, 36);
            this.nudFloorNumber.TabIndex = 0;
            this.nudFloorNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFloorNumber.Validating += new System.ComponentModel.CancelEventHandler(this.nudFloorNumber_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BorderRadius = 8;
            this.btnSave.BorderThickness = 1;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.SystemColors.Control;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::Hotel.Properties.Resources.Save_32;
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(255, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::Hotel.Properties.Resources.Close_32;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(121, 206);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BorderRadius = 2;
            this.guna2PictureBox2.Image = global::Hotel.Properties.Resources.border_diagonal_a;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(25, 146);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(33, 30);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 158;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 2;
            this.guna2PictureBox1.Image = global::Hotel.Properties.Resources.Number_321;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(23, 112);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(33, 27);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 155;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.BorderRadius = 2;
            this.guna2PictureBox8.Image = global::Hotel.Properties.Resources.id;
            this.guna2PictureBox8.ImageRotate = 0F;
            this.guna2PictureBox8.Location = new System.Drawing.Point(24, 74);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox8.TabIndex = 153;
            this.guna2PictureBox8.TabStop = false;
            // 
            // guna2PictureBox19
            // 
            this.guna2PictureBox19.BorderRadius = 2;
            this.guna2PictureBox19.Image = global::Hotel.Properties.Resources.Floors;
            this.guna2PictureBox19.ImageRotate = 0F;
            this.guna2PictureBox19.Location = new System.Drawing.Point(24, 158);
            this.guna2PictureBox19.Name = "guna2PictureBox19";
            this.guna2PictureBox19.Size = new System.Drawing.Size(33, 30);
            this.guna2PictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox19.TabIndex = 149;
            this.guna2PictureBox19.TabStop = false;
            // 
            // txtFloorAreas
            // 
            this.txtFloorAreas.Animated = true;
            this.txtFloorAreas.BorderRadius = 8;
            this.txtFloorAreas.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtFloorAreas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFloorAreas.DefaultText = "";
            this.txtFloorAreas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFloorAreas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFloorAreas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFloorAreas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFloorAreas.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFloorAreas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFloorAreas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFloorAreas.ForeColor = System.Drawing.Color.Black;
            this.txtFloorAreas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFloorAreas.Location = new System.Drawing.Point(63, 146);
            this.txtFloorAreas.Margin = new System.Windows.Forms.Padding(4);
            this.txtFloorAreas.Name = "txtFloorAreas";
            this.txtFloorAreas.PasswordChar = '\0';
            this.txtFloorAreas.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFloorAreas.PlaceholderText = "Floor Area";
            this.txtFloorAreas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFloorAreas.SelectedText = "";
            this.txtFloorAreas.Size = new System.Drawing.Size(309, 40);
            this.txtFloorAreas.TabIndex = 2;
            this.txtFloorAreas.Validating += new System.ComponentModel.CancelEventHandler(this.txtFloorAreas_Validating);
            // 
            // frmAddEditFloor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(394, 255);
            this.Controls.Add(this.txtFloorAreas);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.nudFloorNumber);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2PictureBox8);
            this.Controls.Add(this.lblFloorID);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditFloor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Floor";
            this.Load += new System.EventHandler(this.frmAddEditFloor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFloorNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox19)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFloorID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox19;
        private Guna.UI2.WinForms.Guna2TextBox txtFloorArea;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudFloorNumber;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtFloorAreas;
    }
}