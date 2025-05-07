namespace Hotel.Bookings
{
    partial class frmListBookings
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPageNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmsListBookings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addtoolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.edittoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvListBookings = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtfilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbBookingStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddNew = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnPrev = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmsListBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = false;
            this.lblPageNumber.BackColor = System.Drawing.Color.Black;
            this.lblPageNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumber.ForeColor = System.Drawing.Color.White;
            this.lblPageNumber.Location = new System.Drawing.Point(417, 636);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Padding = new System.Windows.Forms.Padding(13, 0, 10, 0);
            this.lblPageNumber.Size = new System.Drawing.Size(68, 23);
            this.lblPageNumber.TabIndex = 165;
            this.lblPageNumber.Text = "1";
            this.lblPageNumber.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsListBookings
            // 
            this.cmsListBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsListBookings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addtoolStripMenuItem2,
            this.edittoolStripMenuItem1,
            this.showDetailstoolStripMenuItem1,
            this.toolStripSeparator1,
            this.CancelToolStripMenuItem});
            this.cmsListBookings.Name = "cmsListBedTypes";
            this.cmsListBookings.Size = new System.Drawing.Size(197, 184);
            this.cmsListBookings.Opening += new System.ComponentModel.CancelEventHandler(this.cmsListBookings_Opening);
            // 
            // addtoolStripMenuItem2
            // 
            this.addtoolStripMenuItem2.Image = global::Hotel.Properties.Resources.icons8_bookings_32__2_;
            this.addtoolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addtoolStripMenuItem2.Name = "addtoolStripMenuItem2";
            this.addtoolStripMenuItem2.Size = new System.Drawing.Size(196, 38);
            this.addtoolStripMenuItem2.Text = "Add";
            this.addtoolStripMenuItem2.Click += new System.EventHandler(this.addtoolStripMenuItem2_Click);
            // 
            // edittoolStripMenuItem1
            // 
            this.edittoolStripMenuItem1.Image = global::Hotel.Properties.Resources.icons8_bookings_32__4_;
            this.edittoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edittoolStripMenuItem1.Name = "edittoolStripMenuItem1";
            this.edittoolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.edittoolStripMenuItem1.Text = "Edit";
            this.edittoolStripMenuItem1.Click += new System.EventHandler(this.edittoolStripMenuItem1_Click);
            // 
            // showDetailstoolStripMenuItem1
            // 
            this.showDetailstoolStripMenuItem1.Image = global::Hotel.Properties.Resources.icons8_bookings_32__3_;
            this.showDetailstoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailstoolStripMenuItem1.Name = "showDetailstoolStripMenuItem1";
            this.showDetailstoolStripMenuItem1.Size = new System.Drawing.Size(196, 38);
            this.showDetailstoolStripMenuItem1.Text = "Show Details";
            this.showDetailstoolStripMenuItem1.Click += new System.EventHandler(this.showDetailstoolStripMenuItem1_Click);
            // 
            // CancelToolStripMenuItem
            // 
            this.CancelToolStripMenuItem.Image = global::Hotel.Properties.Resources.icons8_bookings_32__5_;
            this.CancelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            this.CancelToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.CancelToolStripMenuItem.Text = "Cancel";
            this.CancelToolStripMenuItem.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(429, 670);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(48, 23);
            this.guna2HtmlLabel2.TabIndex = 163;
            this.guna2HtmlLabel2.Text = "Pages";
            // 
            // dgvListBookings
            // 
            this.dgvListBookings.AllowUserToAddRows = false;
            this.dgvListBookings.AllowUserToDeleteRows = false;
            this.dgvListBookings.AllowUserToOrderColumns = true;
            this.dgvListBookings.AllowUserToResizeColumns = false;
            this.dgvListBookings.AllowUserToResizeRows = false;
            this.dgvListBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListBookings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvListBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBookings.ContextMenuStrip = this.cmsListBookings;
            this.dgvListBookings.Location = new System.Drawing.Point(12, 230);
            this.dgvListBookings.MultiSelect = false;
            this.dgvListBookings.Name = "dgvListBookings";
            this.dgvListBookings.ReadOnly = true;
            this.dgvListBookings.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvListBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListBookings.Size = new System.Drawing.Size(923, 398);
            this.dgvListBookings.TabIndex = 160;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(97, 634);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(43, 23);
            this.lblRecordsCount.TabIndex = 159;
            this.lblRecordsCount.Text = "[????]";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(258, 117);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.lblTitle.Size = new System.Drawing.Size(491, 52);
            this.lblTitle.TabIndex = 156;
            this.lblTitle.Text = "List Bookings";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.txtfilterValue.Location = new System.Drawing.Point(249, 188);
            this.txtfilterValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtfilterValue.Name = "txtfilterValue";
            this.txtfilterValue.PasswordChar = '\0';
            this.txtfilterValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtfilterValue.PlaceholderText = "Filter Value";
            this.txtfilterValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtfilterValue.SelectedText = "";
            this.txtfilterValue.Size = new System.Drawing.Size(210, 35);
            this.txtfilterValue.TabIndex = 162;
            this.txtfilterValue.Visible = false;
            this.txtfilterValue.TextChanged += new System.EventHandler(this.txtfilterValue_TextChanged);
            this.txtfilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfilterValue_KeyPress);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 634);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(79, 23);
            this.guna2HtmlLabel1.TabIndex = 158;
            this.guna2HtmlLabel1.Text = "# Records :";
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
            "Booking ID",
            "National No",
            "Full Name",
            "Booking Status",
            "Number Rooms"});
            this.cbFilter.Location = new System.Drawing.Point(12, 187);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(206, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 161;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbBookingStatus
            // 
            this.cbBookingStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbBookingStatus.BorderRadius = 8;
            this.cbBookingStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBookingStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBookingStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBookingStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbBookingStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBookingStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbBookingStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbBookingStatus.ForeColor = System.Drawing.Color.Black;
            this.cbBookingStatus.ItemHeight = 30;
            this.cbBookingStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Cancelled",
            "Completed"});
            this.cbBookingStatus.Location = new System.Drawing.Point(249, 187);
            this.cbBookingStatus.Name = "cbBookingStatus";
            this.cbBookingStatus.Size = new System.Drawing.Size(161, 36);
            this.cbBookingStatus.StartIndex = 0;
            this.cbBookingStatus.TabIndex = 169;
            this.cbBookingStatus.Visible = false;
            this.cbBookingStatus.SelectedIndexChanged += new System.EventHandler(this.cbBookingStatus_SelectedIndexChanged);
            this.cbBookingStatus.SelectedValueChanged += new System.EventHandler(this.cbBookingStatus_SelectedValueChanged);
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
            this.btnAddNew.Image = global::Hotel.Properties.Resources.icons8_bookings_32__2_;
            this.btnAddNew.ImageSize = new System.Drawing.Size(50, 50);
            this.btnAddNew.Location = new System.Drawing.Point(866, 178);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(69, 45);
            this.btnAddNew.TabIndex = 168;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnNext
            // 
            this.btnNext.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNext.Image = global::Hotel.Properties.Resources.Next_32;
            this.btnNext.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNext.ImageRotate = 0F;
            this.btnNext.ImageSize = new System.Drawing.Size(32, 32);
            this.btnNext.Location = new System.Drawing.Point(502, 636);
            this.btnNext.Name = "btnNext";
            this.btnNext.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnNext.Size = new System.Drawing.Size(34, 30);
            this.btnNext.TabIndex = 167;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPrev.Image = global::Hotel.Properties.Resources.Prev_32;
            this.btnPrev.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnPrev.ImageRotate = 0F;
            this.btnPrev.ImageSize = new System.Drawing.Size(32, 32);
            this.btnPrev.Location = new System.Drawing.Point(365, 636);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnPrev.Size = new System.Drawing.Size(34, 30);
            this.btnPrev.TabIndex = 166;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::Hotel.Properties.Resources.Ionic_Ionicons_Tv_512;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(405, 629);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(91, 45);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 164;
            this.guna2PictureBox2.TabStop = false;
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
            this.btnClose.Location = new System.Drawing.Point(781, 636);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 45);
            this.btnClose.TabIndex = 157;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Hotel.Properties.Resources.icons8_bookings_100;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(369, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(263, 122);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 155;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmListBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(947, 706);
            this.Controls.Add(this.cbBookingStatus);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.dgvListBookings);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtfilterValue);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.cbFilter);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListBookings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Bookings";
            this.Load += new System.EventHandler(this.frmListBookings_Load);
            this.cmsListBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddNew;
        private Guna.UI2.WinForms.Guna2ImageButton btnNext;
        private Guna.UI2.WinForms.Guna2ImageButton btnPrev;
        private System.Windows.Forms.ToolStripMenuItem CancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDetailstoolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageNumber;
        private System.Windows.Forms.ToolStripMenuItem addtoolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip cmsListBookings;
        private System.Windows.Forms.ToolStripMenuItem edittoolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.DataGridView dgvListBookings;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtfilterValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cbBookingStatus;
    }
}