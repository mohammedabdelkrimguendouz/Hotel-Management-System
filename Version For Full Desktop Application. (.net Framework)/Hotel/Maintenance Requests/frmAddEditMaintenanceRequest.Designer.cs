namespace Hotel.Maintenance_Requests
{
    partial class frmAddEditMaintenanceRequest
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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox16 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblMaintenanceRequestID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblCreatedByEmployee = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpMaintenanceRequestDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2PictureBox7 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnMaintenance = new Guna.UI2.WinForms.Guna2Button();
            this.ctrlRoomCardInfoWithFilter1 = new Hotel.Rooms.Controls.ctrlRoomCardInfoWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(65, -1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(667, 56);
            this.lblTitle.TabIndex = 70;
            this.lblTitle.Text = "Add New Maintenance Request";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnClose.Location = new System.Drawing.Point(428, 602);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 45);
            this.btnClose.TabIndex = 72;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PictureBox16
            // 
            this.guna2PictureBox16.BorderRadius = 2;
            this.guna2PictureBox16.Image = global::Hotel.Properties.Resources.id;
            this.guna2PictureBox16.ImageRotate = 0F;
            this.guna2PictureBox16.Location = new System.Drawing.Point(163, 381);
            this.guna2PictureBox16.Name = "guna2PictureBox16";
            this.guna2PictureBox16.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox16.TabIndex = 106;
            this.guna2PictureBox16.TabStop = false;
            // 
            // lblMaintenanceRequestID
            // 
            this.lblMaintenanceRequestID.BackColor = System.Drawing.Color.Transparent;
            this.lblMaintenanceRequestID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaintenanceRequestID.ForeColor = System.Drawing.Color.Black;
            this.lblMaintenanceRequestID.Location = new System.Drawing.Point(202, 381);
            this.lblMaintenanceRequestID.Name = "lblMaintenanceRequestID";
            this.lblMaintenanceRequestID.Size = new System.Drawing.Size(43, 23);
            this.lblMaintenanceRequestID.TabIndex = 105;
            this.lblMaintenanceRequestID.Text = "[????]";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(101, 381);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(56, 23);
            this.guna2HtmlLabel3.TabIndex = 104;
            this.guna2HtmlLabel3.Text = "M.R ID : ";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 2;
            this.guna2PictureBox1.Image = global::Hotel.Properties.Resources.Calendar_32;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(163, 426);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 109;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(84, 427);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(73, 23);
            this.guna2HtmlLabel2.TabIndex = 107;
            this.guna2HtmlLabel2.Text = "M.R Date :";
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.BorderRadius = 2;
            this.guna2PictureBox5.Image = global::Hotel.Properties.Resources.User_32__2;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(162, 471);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox5.TabIndex = 121;
            this.guna2PictureBox5.TabStop = false;
            // 
            // lblCreatedByEmployee
            // 
            this.lblCreatedByEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedByEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByEmployee.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedByEmployee.Location = new System.Drawing.Point(202, 474);
            this.lblCreatedByEmployee.Name = "lblCreatedByEmployee";
            this.lblCreatedByEmployee.Size = new System.Drawing.Size(43, 23);
            this.lblCreatedByEmployee.TabIndex = 120;
            this.lblCreatedByEmployee.Text = "[????]";
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(8, 473);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(149, 23);
            this.guna2HtmlLabel9.TabIndex = 119;
            this.guna2HtmlLabel9.Text = "CreatedByEmployee : ";
            // 
            // dtpMaintenanceRequestDate
            // 
            this.dtpMaintenanceRequestDate.BorderRadius = 8;
            this.dtpMaintenanceRequestDate.Checked = true;
            this.dtpMaintenanceRequestDate.FillColor = System.Drawing.Color.White;
            this.dtpMaintenanceRequestDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpMaintenanceRequestDate.ForeColor = System.Drawing.Color.Black;
            this.dtpMaintenanceRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpMaintenanceRequestDate.Location = new System.Drawing.Point(202, 419);
            this.dtpMaintenanceRequestDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpMaintenanceRequestDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpMaintenanceRequestDate.Name = "dtpMaintenanceRequestDate";
            this.dtpMaintenanceRequestDate.Size = new System.Drawing.Size(252, 36);
            this.dtpMaintenanceRequestDate.TabIndex = 122;
            this.dtpMaintenanceRequestDate.Value = new System.DateTime(2024, 7, 26, 1, 35, 48, 147);
            // 
            // guna2PictureBox7
            // 
            this.guna2PictureBox7.BorderRadius = 2;
            this.guna2PictureBox7.Image = global::Hotel.Properties.Resources.Notes_32;
            this.guna2PictureBox7.ImageRotate = 0F;
            this.guna2PictureBox7.Location = new System.Drawing.Point(162, 513);
            this.guna2PictureBox7.Name = "guna2PictureBox7";
            this.guna2PictureBox7.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox7.TabIndex = 124;
            this.guna2PictureBox7.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Animated = true;
            this.txtDescription.AutoScroll = true;
            this.txtDescription.AutoSize = true;
            this.txtDescription.BorderRadius = 8;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(202, 513);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDescription.PlaceholderText = "Description";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(314, 85);
            this.txtDescription.TabIndex = 123;
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.Animated = true;
            this.btnMaintenance.BorderRadius = 8;
            this.btnMaintenance.BorderThickness = 1;
            this.btnMaintenance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaintenance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMaintenance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMaintenance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMaintenance.Enabled = false;
            this.btnMaintenance.FillColor = System.Drawing.SystemColors.Control;
            this.btnMaintenance.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnMaintenance.ForeColor = System.Drawing.Color.Black;
            this.btnMaintenance.Image = global::Hotel.Properties.Resources.icons8_maintenance_50;
            this.btnMaintenance.ImageSize = new System.Drawing.Size(30, 30);
            this.btnMaintenance.Location = new System.Drawing.Point(588, 602);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(180, 45);
            this.btnMaintenance.TabIndex = 125;
            this.btnMaintenance.Text = "Maintenance";
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // ctrlRoomCardInfoWithFilter1
            // 
            this.ctrlRoomCardInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlRoomCardInfoWithFilter1.EnableFilter = true;
            this.ctrlRoomCardInfoWithFilter1.Location = new System.Drawing.Point(12, 50);
            this.ctrlRoomCardInfoWithFilter1.Name = "ctrlRoomCardInfoWithFilter1";
            this.ctrlRoomCardInfoWithFilter1.Size = new System.Drawing.Size(756, 327);
            this.ctrlRoomCardInfoWithFilter1.TabIndex = 73;
            this.ctrlRoomCardInfoWithFilter1.OnRoomSelected += new System.EventHandler<Hotel.Rooms.Controls.ctrlRoomCardInfoWithFilter.RoomSelectedEventArgs>(this.ctrlRoomCardInfoWithFilter1_OnRoomSelected);
            // 
            // frmAddEditMaintenanceRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(778, 652);
            this.Controls.Add(this.btnMaintenance);
            this.Controls.Add(this.guna2PictureBox7);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.dtpMaintenanceRequestDate);
            this.Controls.Add(this.guna2PictureBox5);
            this.Controls.Add(this.lblCreatedByEmployee);
            this.Controls.Add(this.guna2HtmlLabel9);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2PictureBox16);
            this.Controls.Add(this.lblMaintenanceRequestID);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.ctrlRoomCardInfoWithFilter1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditMaintenanceRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Maintenance Request";
            this.Load += new System.EventHandler(this.frmAddEditMaintenanceRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Rooms.Controls.ctrlRoomCardInfoWithFilter ctrlRoomCardInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox16;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblMaintenanceRequestID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCreatedByEmployee;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpMaintenanceRequestDate;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox7;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2Button btnMaintenance;
    }
}