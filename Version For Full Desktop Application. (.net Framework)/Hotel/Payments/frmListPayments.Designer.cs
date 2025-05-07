namespace Hotel.Payments
{
    partial class frmListPayments
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
            this.lblPageNumber = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cmsListPayments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvListPayments = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtfilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnNext = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnPrev = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmsListPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPayments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = false;
            this.lblPageNumber.BackColor = System.Drawing.Color.Black;
            this.lblPageNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageNumber.ForeColor = System.Drawing.Color.White;
            this.lblPageNumber.Location = new System.Drawing.Point(363, 627);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Padding = new System.Windows.Forms.Padding(13, 0, 10, 0);
            this.lblPageNumber.Size = new System.Drawing.Size(68, 23);
            this.lblPageNumber.TabIndex = 165;
            this.lblPageNumber.Text = "1";
            this.lblPageNumber.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmsListPayments
            // 
            this.cmsListPayments.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsListPayments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailstoolStripMenuItem1});
            this.cmsListPayments.Name = "cmsListBedTypes";
            this.cmsListPayments.Size = new System.Drawing.Size(187, 42);
            // 
            // showDetailstoolStripMenuItem1
            // 
            this.showDetailstoolStripMenuItem1.Image = global::Hotel.Properties.Resources.icons8_payment_32__1_;
            this.showDetailstoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailstoolStripMenuItem1.Name = "showDetailstoolStripMenuItem1";
            this.showDetailstoolStripMenuItem1.Size = new System.Drawing.Size(186, 38);
            this.showDetailstoolStripMenuItem1.Text = "Show Details";
            this.showDetailstoolStripMenuItem1.Click += new System.EventHandler(this.showDetailstoolStripMenuItem1_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(375, 661);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(48, 23);
            this.guna2HtmlLabel2.TabIndex = 163;
            this.guna2HtmlLabel2.Text = "Pages";
            // 
            // dgvListPayments
            // 
            this.dgvListPayments.AllowUserToAddRows = false;
            this.dgvListPayments.AllowUserToDeleteRows = false;
            this.dgvListPayments.AllowUserToOrderColumns = true;
            this.dgvListPayments.AllowUserToResizeColumns = false;
            this.dgvListPayments.AllowUserToResizeRows = false;
            this.dgvListPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListPayments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvListPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPayments.ContextMenuStrip = this.cmsListPayments;
            this.dgvListPayments.Location = new System.Drawing.Point(10, 216);
            this.dgvListPayments.MultiSelect = false;
            this.dgvListPayments.Name = "dgvListPayments";
            this.dgvListPayments.ReadOnly = true;
            this.dgvListPayments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvListPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListPayments.Size = new System.Drawing.Size(776, 398);
            this.dgvListPayments.TabIndex = 160;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCount.Location = new System.Drawing.Point(95, 620);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(43, 23);
            this.lblRecordsCount.TabIndex = 159;
            this.lblRecordsCount.Text = "[????]";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(281, 115);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(242, 52);
            this.lblTitle.TabIndex = 156;
            this.lblTitle.Text = "List Payments";
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
            this.txtfilterValue.Location = new System.Drawing.Point(247, 174);
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
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(10, 620);
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
            "Payment ID",
            "Booking ID",
            "National No",
            "Full Name",
            "Payment Amount",
            "Payment Date"});
            this.cbFilter.Location = new System.Drawing.Point(10, 173);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(206, 36);
            this.cbFilter.StartIndex = 0;
            this.cbFilter.TabIndex = 161;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
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
            this.btnNext.Location = new System.Drawing.Point(448, 627);
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
            this.btnPrev.Location = new System.Drawing.Point(311, 627);
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
            this.guna2PictureBox2.Location = new System.Drawing.Point(351, 620);
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
            this.btnClose.Location = new System.Drawing.Point(632, 620);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 45);
            this.btnClose.TabIndex = 157;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Hotel.Properties.Resources.icons8_payment_100;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(247, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(326, 122);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 155;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmListPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(792, 685);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.dgvListPayments);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtfilterValue);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.cbFilter);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Payments";
            this.Load += new System.EventHandler(this.frmListPayments_Load);
            this.cmsListPayments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPayments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ImageButton btnNext;
        private Guna.UI2.WinForms.Guna2ImageButton btnPrev;
        private System.Windows.Forms.ToolStripMenuItem showDetailstoolStripMenuItem1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPageNumber;
        private System.Windows.Forms.ContextMenuStrip cmsListPayments;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.DataGridView dgvListPayments;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCount;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtfilterValue;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
    }
}