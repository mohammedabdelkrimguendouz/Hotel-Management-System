namespace Hotel.Maintenance_Requests
{
    partial class frmListMaintenanceRequests
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
            this.cbIsCompleted = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtfilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRecordsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsListMaintenanceRequests = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewtoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailestoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.setCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvListMaintenanceRequests = new System.Windows.Forms.DataGridView();
            this.btnAddNew = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmsListMaintenanceRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMaintenanceRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIsCompleted
            // 
            this.cbIsCompleted.BackColor = System.Drawing.Color.Transparent;
            this.cbIsCompleted.BorderRadius = 8;
            this.cbIsCompleted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIsCompleted.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbIsCompleted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsCompleted.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbIsCompleted.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsCompleted.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbIsCompleted.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbIsCompleted.ForeColor = System.Drawing.Color.Black;
            this.cbIsCompleted.ItemHeight = 30;
            this.cbIsCompleted.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsCompleted.Location = new System.Drawing.Point(246, 213);
            this.cbIsCompleted.Name = "cbIsCompleted";
            this.cbIsCompleted.Size = new System.Drawing.Size(138, 36);
            this.cbIsCompleted.StartIndex = 0;
            this.cbIsCompleted.TabIndex = 131;
            this.cbIsCompleted.Visible = false;
            this.cbIsCompleted.SelectedIndexChanged += new System.EventHandler(this.cbIsCompleted_SelectedIndexChanged);
            // 
            // txtfilterValue
            // 
            this.txtfilterValue.Animated = true;
            this.txtfilterValue.BorderRadius = 8;
            this.txtfilterValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtfilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfilterValue.DefaultText = "";
            this.txtfilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtfilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtfilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfilterValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtfilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfilterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtfilterValue.ForeColor = System.Drawing.Color.Black;
            this.txtfilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfilterValue.Location = new System.Drawing.Point(246, 213);
            this.txtfilterValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtfilterValue.Name = "txtfilterValue";
            this.txtfilterValue.PasswordChar = '\0';
            this.txtfilterValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtfilterValue.PlaceholderText = "Filter Value";
            this.txtfilterValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtfilterValue.SelectedText = "";
            this.txtfilterValue.Size = new System.Drawing.Size(232, 35);
            this.txtfilterValue.TabIndex = 130;
            this.txtfilterValue.Visible = false;
            this.txtfilterValue.TextChanged += new System.EventHandler(this.txtfilterValue_TextChanged);
            this.txtfilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfilterValue_KeyPress);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderRadius = 8;
            this.cbFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Maintenance Request ID",
            "Room ID",
            "Room Number",
            "Floor Number",
            "Is Completed"});
            this.cbFilter.Location = new System.Drawing.Point(12, 213);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(206, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 129;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(104, 594);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(43, 23);
            this.lblRecordsCount.TabIndex = 126;
            this.lblRecordsCount.Text = "[????]";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 594);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(79, 23);
            this.guna2HtmlLabel1.TabIndex = 125;
            this.guna2HtmlLabel1.Text = "# Records :";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(167, 143);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(542, 52);
            this.lblTitle.TabIndex = 123;
            this.lblTitle.Text = "Manage Maintenance Requests";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(195, 6);
            // 
            // cmsListMaintenanceRequests
            // 
            this.cmsListMaintenanceRequests.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsListMaintenanceRequests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewtoolStripMenuItem1,
            this.editToolStripMenuItem,
            this.showDetailestoolStripMenuItem1,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.setCompletedToolStripMenuItem});
            this.cmsListMaintenanceRequests.Name = "cmsListBedTypes";
            this.cmsListMaintenanceRequests.Size = new System.Drawing.Size(199, 228);
            this.cmsListMaintenanceRequests.Opening += new System.ComponentModel.CancelEventHandler(this.cmsListMaintenanceRequests_Opening);
            // 
            // addNewtoolStripMenuItem1
            // 
            this.addNewtoolStripMenuItem1.Image = global::Hotel.Properties.Resources.icons8_maintenance_321;
            this.addNewtoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewtoolStripMenuItem1.Name = "addNewtoolStripMenuItem1";
            this.addNewtoolStripMenuItem1.Size = new System.Drawing.Size(198, 38);
            this.addNewtoolStripMenuItem1.Text = "Add";
            this.addNewtoolStripMenuItem1.Click += new System.EventHandler(this.addNewtoolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Hotel.Properties.Resources.icons8_maintenance_32__1_;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // showDetailestoolStripMenuItem1
            // 
            this.showDetailestoolStripMenuItem1.Image = global::Hotel.Properties.Resources.icons8_maintenance_32__3_;
            this.showDetailestoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailestoolStripMenuItem1.Name = "showDetailestoolStripMenuItem1";
            this.showDetailestoolStripMenuItem1.Size = new System.Drawing.Size(198, 38);
            this.showDetailestoolStripMenuItem1.Text = "Show Details";
            this.showDetailestoolStripMenuItem1.Click += new System.EventHandler(this.showDetailestoolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Hotel.Properties.Resources.icons8_maintenance_32__2_;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // setCompletedToolStripMenuItem
            // 
            this.setCompletedToolStripMenuItem.Image = global::Hotel.Properties.Resources.icons8_check_mark_32;
            this.setCompletedToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.setCompletedToolStripMenuItem.Name = "setCompletedToolStripMenuItem";
            this.setCompletedToolStripMenuItem.Size = new System.Drawing.Size(198, 38);
            this.setCompletedToolStripMenuItem.Text = "Set Completed";
            this.setCompletedToolStripMenuItem.Click += new System.EventHandler(this.setCompletedToolStripMenuItem_Click);
            // 
            // dgvListMaintenanceRequests
            // 
            this.dgvListMaintenanceRequests.AllowUserToAddRows = false;
            this.dgvListMaintenanceRequests.AllowUserToDeleteRows = false;
            this.dgvListMaintenanceRequests.AllowUserToOrderColumns = true;
            this.dgvListMaintenanceRequests.AllowUserToResizeColumns = false;
            this.dgvListMaintenanceRequests.AllowUserToResizeRows = false;
            this.dgvListMaintenanceRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListMaintenanceRequests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListMaintenanceRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvListMaintenanceRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMaintenanceRequests.ContextMenuStrip = this.cmsListMaintenanceRequests;
            this.dgvListMaintenanceRequests.Location = new System.Drawing.Point(12, 255);
            this.dgvListMaintenanceRequests.MultiSelect = false;
            this.dgvListMaintenanceRequests.Name = "dgvListMaintenanceRequests";
            this.dgvListMaintenanceRequests.ReadOnly = true;
            this.dgvListMaintenanceRequests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvListMaintenanceRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListMaintenanceRequests.Size = new System.Drawing.Size(863, 321);
            this.dgvListMaintenanceRequests.TabIndex = 128;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Animated = true;
            this.btnAddNew.BorderRadius = 8;
            this.btnAddNew.BorderThickness = 1;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNew.FillColor = System.Drawing.SystemColors.Control;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnAddNew.ForeColor = System.Drawing.Color.Black;
            this.btnAddNew.Image = global::Hotel.Properties.Resources.icons8_maintenance_32;
            this.btnAddNew.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAddNew.Location = new System.Drawing.Point(806, 204);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(69, 45);
            this.btnAddNew.TabIndex = 127;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
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
            this.btnClose.Location = new System.Drawing.Point(721, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 45);
            this.btnClose.TabIndex = 124;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Hotel.Properties.Resources.icons8_maintenance_100;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(200, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(464, 134);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 122;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmListMaintenanceRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 633);
            this.Controls.Add(this.cbIsCompleted);
            this.Controls.Add(this.txtfilterValue);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.dgvListMaintenanceRequests);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListMaintenanceRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Maintenance Requests";
            this.Load += new System.EventHandler(this.frmListMaintenanceRequests_Load);
            this.cmsListMaintenanceRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMaintenanceRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox cbIsCompleted;
        private Guna.UI2.WinForms.Guna2TextBox txtfilterValue;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddNew;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDetailestoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewtoolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsListMaintenanceRequests;
        private System.Windows.Forms.DataGridView dgvListMaintenanceRequests;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem setCompletedToolStripMenuItem;
    }
}