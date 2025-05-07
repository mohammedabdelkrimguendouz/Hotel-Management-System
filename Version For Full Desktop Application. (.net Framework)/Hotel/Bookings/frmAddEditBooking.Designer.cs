namespace Hotel.Bookings
{
    partial class frmAddEditBooking
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
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tcBooking = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpGuestInfo = new System.Windows.Forms.TabPage();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ctrlGuestInfoWithFilter1 = new Hotel.Guests.Controls.ctrlGuestInfoWithFilter();
            this.btnNextToBookingInfo = new Guna.UI2.WinForms.Guna2Button();
            this.tpBookingInfo = new System.Windows.Forms.TabPage();
            this.pBookingInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecordsCountForRoomsBooking = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel15 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblRecordsCountForRooms = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel12 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblCheckInDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnBackToGuestInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextToPaymentInfo = new Guna.UI2.WinForms.Guna2Button();
            this.dgvListRoomsForBooking = new System.Windows.Forms.DataGridView();
            this.RoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FloorNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsListRoomsForBookings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChoose = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbRoomClasses = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvListRoomsForRoomClass = new System.Windows.Forms.DataGridView();
            this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblDiscount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox5 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblBookingAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.nudNumberChildren = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.nudNumberAdults = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dtpCheckOutDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox16 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblBookingID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tpPaymentInfo = new System.Windows.Forms.TabPage();
            this.pPaymentInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.rbCreditCard = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnBackToBookingInfo = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox14 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox12 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox13 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.rbCash = new Guna.UI2.WinForms.Guna2RadioButton();
            this.pbGender = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox11 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPaymentAmount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel14 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox9 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPaymentDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel11 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox7 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPaymentID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.tcBooking.SuspendLayout();
            this.tpGuestInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.tpBookingInfo.SuspendLayout();
            this.pBookingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomsForBooking)).BeginInit();
            this.cmsListRoomsForBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomsForRoomClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberChildren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberAdults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox16)).BeginInit();
            this.tpPaymentInfo.SuspendLayout();
            this.pPaymentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(308, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.lblTitle.Size = new System.Drawing.Size(570, 50);
            this.lblTitle.TabIndex = 70;
            this.lblTitle.Text = "Add New Booking";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tcBooking
            // 
            this.tcBooking.Controls.Add(this.tpGuestInfo);
            this.tcBooking.Controls.Add(this.tpBookingInfo);
            this.tcBooking.Controls.Add(this.tpPaymentInfo);
            this.tcBooking.ItemSize = new System.Drawing.Size(180, 40);
            this.tcBooking.Location = new System.Drawing.Point(1, 57);
            this.tcBooking.Name = "tcBooking";
            this.tcBooking.SelectedIndex = 0;
            this.tcBooking.Size = new System.Drawing.Size(1145, 580);
            this.tcBooking.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcBooking.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcBooking.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcBooking.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcBooking.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcBooking.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcBooking.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcBooking.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcBooking.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcBooking.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcBooking.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcBooking.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcBooking.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcBooking.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcBooking.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcBooking.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcBooking.TabIndex = 71;
            this.tcBooking.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcBooking.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpGuestInfo
            // 
            this.tpGuestInfo.Controls.Add(this.guna2PictureBox1);
            this.tpGuestInfo.Controls.Add(this.ctrlGuestInfoWithFilter1);
            this.tpGuestInfo.Controls.Add(this.btnNextToBookingInfo);
            this.tpGuestInfo.Location = new System.Drawing.Point(4, 44);
            this.tpGuestInfo.Name = "tpGuestInfo";
            this.tpGuestInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGuestInfo.Size = new System.Drawing.Size(1137, 532);
            this.tpGuestInfo.TabIndex = 0;
            this.tpGuestInfo.Text = "Guest Info";
            this.tpGuestInfo.UseVisualStyleBackColor = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Hotel.Properties.Resources.focus_group;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(20, 6);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(240, 505);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 74;
            this.guna2PictureBox1.TabStop = false;
            // 
            // ctrlGuestInfoWithFilter1
            // 
            this.ctrlGuestInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlGuestInfoWithFilter1.EnableAddNew = true;
            this.ctrlGuestInfoWithFilter1.EnableFilter = true;
            this.ctrlGuestInfoWithFilter1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlGuestInfoWithFilter1.Location = new System.Drawing.Point(275, 0);
            this.ctrlGuestInfoWithFilter1.Name = "ctrlGuestInfoWithFilter1";
            this.ctrlGuestInfoWithFilter1.Size = new System.Drawing.Size(699, 525);
            this.ctrlGuestInfoWithFilter1.TabIndex = 73;
            // 
            // btnNextToBookingInfo
            // 
            this.btnNextToBookingInfo.Animated = true;
            this.btnNextToBookingInfo.BorderRadius = 8;
            this.btnNextToBookingInfo.BorderThickness = 1;
            this.btnNextToBookingInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextToBookingInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextToBookingInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextToBookingInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextToBookingInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextToBookingInfo.FillColor = System.Drawing.SystemColors.Control;
            this.btnNextToBookingInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnNextToBookingInfo.ForeColor = System.Drawing.Color.Black;
            this.btnNextToBookingInfo.Image = global::Hotel.Properties.Resources.Next_32;
            this.btnNextToBookingInfo.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNextToBookingInfo.Location = new System.Drawing.Point(980, 481);
            this.btnNextToBookingInfo.Name = "btnNextToBookingInfo";
            this.btnNextToBookingInfo.Size = new System.Drawing.Size(154, 45);
            this.btnNextToBookingInfo.TabIndex = 72;
            this.btnNextToBookingInfo.Text = "Next";
            this.btnNextToBookingInfo.Click += new System.EventHandler(this.btnNextToBookingInfo_Click);
            // 
            // tpBookingInfo
            // 
            this.tpBookingInfo.Controls.Add(this.pBookingInfo);
            this.tpBookingInfo.Location = new System.Drawing.Point(4, 44);
            this.tpBookingInfo.Name = "tpBookingInfo";
            this.tpBookingInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpBookingInfo.Size = new System.Drawing.Size(1137, 532);
            this.tpBookingInfo.TabIndex = 1;
            this.tpBookingInfo.Text = "Booking Info";
            this.tpBookingInfo.UseVisualStyleBackColor = true;
            // 
            // pBookingInfo
            // 
            this.pBookingInfo.Controls.Add(this.lblRecordsCountForRoomsBooking);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel15);
            this.pBookingInfo.Controls.Add(this.lblRecordsCountForRooms);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel12);
            this.pBookingInfo.Controls.Add(this.lblCheckInDate);
            this.pBookingInfo.Controls.Add(this.btnBackToGuestInfo);
            this.pBookingInfo.Controls.Add(this.btnNextToPaymentInfo);
            this.pBookingInfo.Controls.Add(this.dgvListRoomsForBooking);
            this.pBookingInfo.Controls.Add(this.btnChoose);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel6);
            this.pBookingInfo.Controls.Add(this.cbRoomClasses);
            this.pBookingInfo.Controls.Add(this.dgvListRoomsForRoomClass);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox6);
            this.pBookingInfo.Controls.Add(this.lblDiscount);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel8);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox5);
            this.pBookingInfo.Controls.Add(this.lblBookingAmount);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel7);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel5);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel4);
            this.pBookingInfo.Controls.Add(this.nudNumberChildren);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox4);
            this.pBookingInfo.Controls.Add(this.nudNumberAdults);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox3);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel2);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel1);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox2);
            this.pBookingInfo.Controls.Add(this.dtpCheckOutDate);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox8);
            this.pBookingInfo.Controls.Add(this.guna2PictureBox16);
            this.pBookingInfo.Controls.Add(this.lblBookingID);
            this.pBookingInfo.Controls.Add(this.guna2HtmlLabel3);
            this.pBookingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBookingInfo.Location = new System.Drawing.Point(3, 3);
            this.pBookingInfo.Name = "pBookingInfo";
            this.pBookingInfo.Size = new System.Drawing.Size(1131, 526);
            this.pBookingInfo.TabIndex = 0;
            // 
            // lblRecordsCountForRoomsBooking
            // 
            this.lblRecordsCountForRoomsBooking.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCountForRoomsBooking.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCountForRoomsBooking.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCountForRoomsBooking.Location = new System.Drawing.Point(712, 488);
            this.lblRecordsCountForRoomsBooking.Name = "lblRecordsCountForRoomsBooking";
            this.lblRecordsCountForRoomsBooking.Size = new System.Drawing.Size(12, 23);
            this.lblRecordsCountForRoomsBooking.TabIndex = 207;
            this.lblRecordsCountForRoomsBooking.Text = "0";
            // 
            // guna2HtmlLabel15
            // 
            this.guna2HtmlLabel15.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel15.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel15.Location = new System.Drawing.Point(627, 488);
            this.guna2HtmlLabel15.Name = "guna2HtmlLabel15";
            this.guna2HtmlLabel15.Size = new System.Drawing.Size(79, 23);
            this.guna2HtmlLabel15.TabIndex = 206;
            this.guna2HtmlLabel15.Text = "# Records :";
            // 
            // lblRecordsCountForRooms
            // 
            this.lblRecordsCountForRooms.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsCountForRooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCountForRooms.ForeColor = System.Drawing.Color.Black;
            this.lblRecordsCountForRooms.Location = new System.Drawing.Point(94, 488);
            this.lblRecordsCountForRooms.Name = "lblRecordsCountForRooms";
            this.lblRecordsCountForRooms.Size = new System.Drawing.Size(12, 23);
            this.lblRecordsCountForRooms.TabIndex = 205;
            this.lblRecordsCountForRooms.Text = "0";
            // 
            // guna2HtmlLabel12
            // 
            this.guna2HtmlLabel12.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel12.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel12.Location = new System.Drawing.Point(9, 488);
            this.guna2HtmlLabel12.Name = "guna2HtmlLabel12";
            this.guna2HtmlLabel12.Size = new System.Drawing.Size(79, 23);
            this.guna2HtmlLabel12.TabIndex = 204;
            this.guna2HtmlLabel12.Text = "# Records :";
            // 
            // lblCheckInDate
            // 
            this.lblCheckInDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckInDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckInDate.ForeColor = System.Drawing.Color.Black;
            this.lblCheckInDate.Location = new System.Drawing.Point(189, 62);
            this.lblCheckInDate.Name = "lblCheckInDate";
            this.lblCheckInDate.Size = new System.Drawing.Size(43, 23);
            this.lblCheckInDate.TabIndex = 203;
            this.lblCheckInDate.Text = "[????]";
            // 
            // btnBackToGuestInfo
            // 
            this.btnBackToGuestInfo.Animated = true;
            this.btnBackToGuestInfo.BorderRadius = 8;
            this.btnBackToGuestInfo.BorderThickness = 1;
            this.btnBackToGuestInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToGuestInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToGuestInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToGuestInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackToGuestInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBackToGuestInfo.FillColor = System.Drawing.SystemColors.Control;
            this.btnBackToGuestInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnBackToGuestInfo.ForeColor = System.Drawing.Color.Black;
            this.btnBackToGuestInfo.Image = global::Hotel.Properties.Resources.Prev_32;
            this.btnBackToGuestInfo.ImageSize = new System.Drawing.Size(30, 30);
            this.btnBackToGuestInfo.Location = new System.Drawing.Point(813, 478);
            this.btnBackToGuestInfo.Name = "btnBackToGuestInfo";
            this.btnBackToGuestInfo.Size = new System.Drawing.Size(154, 45);
            this.btnBackToGuestInfo.TabIndex = 202;
            this.btnBackToGuestInfo.Text = "Back";
            this.btnBackToGuestInfo.Click += new System.EventHandler(this.btnBackToGuestInfo_Click);
            // 
            // btnNextToPaymentInfo
            // 
            this.btnNextToPaymentInfo.Animated = true;
            this.btnNextToPaymentInfo.BorderRadius = 8;
            this.btnNextToPaymentInfo.BorderThickness = 1;
            this.btnNextToPaymentInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextToPaymentInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextToPaymentInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextToPaymentInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextToPaymentInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextToPaymentInfo.FillColor = System.Drawing.SystemColors.Control;
            this.btnNextToPaymentInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnNextToPaymentInfo.ForeColor = System.Drawing.Color.Black;
            this.btnNextToPaymentInfo.Image = global::Hotel.Properties.Resources.Next_32;
            this.btnNextToPaymentInfo.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNextToPaymentInfo.Location = new System.Drawing.Point(973, 478);
            this.btnNextToPaymentInfo.Name = "btnNextToPaymentInfo";
            this.btnNextToPaymentInfo.Size = new System.Drawing.Size(154, 45);
            this.btnNextToPaymentInfo.TabIndex = 201;
            this.btnNextToPaymentInfo.Text = "Next";
            this.btnNextToPaymentInfo.Click += new System.EventHandler(this.btnNextToPaymentInfo_Click);
            // 
            // dgvListRoomsForBooking
            // 
            this.dgvListRoomsForBooking.AllowUserToAddRows = false;
            this.dgvListRoomsForBooking.AllowUserToDeleteRows = false;
            this.dgvListRoomsForBooking.AllowUserToOrderColumns = true;
            this.dgvListRoomsForBooking.AllowUserToResizeColumns = false;
            this.dgvListRoomsForBooking.AllowUserToResizeRows = false;
            this.dgvListRoomsForBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListRoomsForBooking.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListRoomsForBooking.BackgroundColor = System.Drawing.Color.White;
            this.dgvListRoomsForBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRoomsForBooking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomID,
            this.RoomClassName,
            this.BasePrice,
            this.FloorNumber,
            this.RoomNumber});
            this.dgvListRoomsForBooking.ContextMenuStrip = this.cmsListRoomsForBookings;
            this.dgvListRoomsForBooking.Location = new System.Drawing.Point(613, 163);
            this.dgvListRoomsForBooking.MultiSelect = false;
            this.dgvListRoomsForBooking.Name = "dgvListRoomsForBooking";
            this.dgvListRoomsForBooking.ReadOnly = true;
            this.dgvListRoomsForBooking.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvListRoomsForBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListRoomsForBooking.Size = new System.Drawing.Size(514, 310);
            this.dgvListRoomsForBooking.TabIndex = 200;
            // 
            // RoomID
            // 
            this.RoomID.HeaderText = "Room ID";
            this.RoomID.Name = "RoomID";
            this.RoomID.ReadOnly = true;
            // 
            // RoomClassName
            // 
            this.RoomClassName.HeaderText = "Class Name";
            this.RoomClassName.Name = "RoomClassName";
            this.RoomClassName.ReadOnly = true;
            // 
            // BasePrice
            // 
            this.BasePrice.HeaderText = "Price";
            this.BasePrice.Name = "BasePrice";
            this.BasePrice.ReadOnly = true;
            // 
            // FloorNumber
            // 
            this.FloorNumber.HeaderText = "Floor Number";
            this.FloorNumber.Name = "FloorNumber";
            this.FloorNumber.ReadOnly = true;
            // 
            // RoomNumber
            // 
            this.RoomNumber.HeaderText = "Room Number";
            this.RoomNumber.Name = "RoomNumber";
            this.RoomNumber.ReadOnly = true;
            // 
            // cmsListRoomsForBookings
            // 
            this.cmsListRoomsForBookings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsListRoomsForBookings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsListRoomsForBookings.Name = "cmsListRoomsForBookings";
            this.cmsListRoomsForBookings.Size = new System.Drawing.Size(141, 42);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Hotel.Properties.Resources.delete_column;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(140, 38);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoose.Enabled = false;
            this.btnChoose.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnChoose.Image = global::Hotel.Properties.Resources.icons8_arrow_100;
            this.btnChoose.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnChoose.ImageRotate = 0F;
            this.btnChoose.Location = new System.Drawing.Point(520, 305);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnChoose.Size = new System.Drawing.Size(87, 35);
            this.btnChoose.TabIndex = 199;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(286, 116);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(114, 23);
            this.guna2HtmlLabel6.TabIndex = 198;
            this.guna2HtmlLabel6.Text = "Room Classes :";
            // 
            // cbRoomClasses
            // 
            this.cbRoomClasses.BackColor = System.Drawing.Color.Transparent;
            this.cbRoomClasses.BorderRadius = 8;
            this.cbRoomClasses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRoomClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoomClasses.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbRoomClasses.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRoomClasses.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbRoomClasses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbRoomClasses.ForeColor = System.Drawing.Color.Black;
            this.cbRoomClasses.ItemHeight = 30;
            this.cbRoomClasses.Items.AddRange(new object[] {
            "None"});
            this.cbRoomClasses.Location = new System.Drawing.Point(440, 111);
            this.cbRoomClasses.Name = "cbRoomClasses";
            this.cbRoomClasses.Size = new System.Drawing.Size(252, 36);
            this.cbRoomClasses.StartIndex = 0;
            this.cbRoomClasses.TabIndex = 197;
            this.cbRoomClasses.SelectedIndexChanged += new System.EventHandler(this.cbRoomClasses_SelectedIndexChanged);
            // 
            // dgvListRoomsForRoomClass
            // 
            this.dgvListRoomsForRoomClass.AllowUserToAddRows = false;
            this.dgvListRoomsForRoomClass.AllowUserToDeleteRows = false;
            this.dgvListRoomsForRoomClass.AllowUserToOrderColumns = true;
            this.dgvListRoomsForRoomClass.AllowUserToResizeColumns = false;
            this.dgvListRoomsForRoomClass.AllowUserToResizeRows = false;
            this.dgvListRoomsForRoomClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListRoomsForRoomClass.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListRoomsForRoomClass.BackgroundColor = System.Drawing.Color.White;
            this.dgvListRoomsForRoomClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListRoomsForRoomClass.Location = new System.Drawing.Point(3, 163);
            this.dgvListRoomsForRoomClass.MultiSelect = false;
            this.dgvListRoomsForRoomClass.Name = "dgvListRoomsForRoomClass";
            this.dgvListRoomsForRoomClass.ReadOnly = true;
            this.dgvListRoomsForRoomClass.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgvListRoomsForRoomClass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListRoomsForRoomClass.Size = new System.Drawing.Size(514, 310);
            this.dgvListRoomsForRoomClass.TabIndex = 196;
            // 
            // guna2PictureBox6
            // 
            this.guna2PictureBox6.BorderRadius = 2;
            this.guna2PictureBox6.Image = global::Hotel.Properties.Resources.icons8_discount_32;
            this.guna2PictureBox6.ImageRotate = 0F;
            this.guna2PictureBox6.Location = new System.Drawing.Point(986, 38);
            this.guna2PictureBox6.Name = "guna2PictureBox6";
            this.guna2PictureBox6.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox6.TabIndex = 195;
            this.guna2PictureBox6.TabStop = false;
            // 
            // lblDiscount
            // 
            this.lblDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.Black;
            this.lblDiscount.Location = new System.Drawing.Point(1039, 38);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(12, 23);
            this.lblDiscount.TabIndex = 194;
            this.lblDiscount.Text = "0";
            // 
            // guna2HtmlLabel8
            // 
            this.guna2HtmlLabel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel8.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel8.Location = new System.Drawing.Point(908, 38);
            this.guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            this.guna2HtmlLabel8.Size = new System.Drawing.Size(71, 23);
            this.guna2HtmlLabel8.TabIndex = 193;
            this.guna2HtmlLabel8.Text = "Discount :";
            // 
            // guna2PictureBox5
            // 
            this.guna2PictureBox5.BorderRadius = 2;
            this.guna2PictureBox5.Image = global::Hotel.Properties.Resources.money_32;
            this.guna2PictureBox5.ImageRotate = 0F;
            this.guna2PictureBox5.Location = new System.Drawing.Point(986, 9);
            this.guna2PictureBox5.Name = "guna2PictureBox5";
            this.guna2PictureBox5.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox5.TabIndex = 192;
            this.guna2PictureBox5.TabStop = false;
            // 
            // lblBookingAmount
            // 
            this.lblBookingAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblBookingAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingAmount.ForeColor = System.Drawing.Color.Black;
            this.lblBookingAmount.Location = new System.Drawing.Point(1039, 9);
            this.lblBookingAmount.Name = "lblBookingAmount";
            this.lblBookingAmount.Size = new System.Drawing.Size(12, 23);
            this.lblBookingAmount.TabIndex = 191;
            this.lblBookingAmount.Text = "0";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(853, 9);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(127, 23);
            this.guna2HtmlLabel7.TabIndex = 190;
            this.guna2HtmlLabel7.Text = "Booking Amount :";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(257, 17);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(116, 23);
            this.guna2HtmlLabel5.TabIndex = 189;
            this.guna2HtmlLabel5.Text = "Number Adults :";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(548, 13);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(131, 23);
            this.guna2HtmlLabel4.TabIndex = 188;
            this.guna2HtmlLabel4.Text = "Number Children :";
            // 
            // nudNumberChildren
            // 
            this.nudNumberChildren.BackColor = System.Drawing.Color.Transparent;
            this.nudNumberChildren.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudNumberChildren.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudNumberChildren.Location = new System.Drawing.Point(724, 4);
            this.nudNumberChildren.Name = "nudNumberChildren";
            this.nudNumberChildren.Size = new System.Drawing.Size(100, 36);
            this.nudNumberChildren.TabIndex = 186;
            this.nudNumberChildren.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.BorderRadius = 2;
            this.guna2PictureBox4.Image = global::Hotel.Properties.Resources.Number_321;
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(685, 9);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(33, 27);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 187;
            this.guna2PictureBox4.TabStop = false;
            // 
            // nudNumberAdults
            // 
            this.nudNumberAdults.BackColor = System.Drawing.Color.Transparent;
            this.nudNumberAdults.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudNumberAdults.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudNumberAdults.Location = new System.Drawing.Point(417, 9);
            this.nudNumberAdults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberAdults.Name = "nudNumberAdults";
            this.nudNumberAdults.Size = new System.Drawing.Size(100, 36);
            this.nudNumberAdults.TabIndex = 184;
            this.nudNumberAdults.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BorderRadius = 2;
            this.guna2PictureBox3.Image = global::Hotel.Properties.Resources.Number_321;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(378, 13);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(33, 27);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 185;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(466, 62);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(118, 23);
            this.guna2HtmlLabel2.TabIndex = 183;
            this.guna2HtmlLabel2.Text = "Check Out Date :";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(32, 62);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(105, 23);
            this.guna2HtmlLabel1.TabIndex = 182;
            this.guna2HtmlLabel1.Text = "Check In Date :";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BorderRadius = 2;
            this.guna2PictureBox2.Image = global::Hotel.Properties.Resources.Calendar_321;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(587, 62);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 181;
            this.guna2PictureBox2.TabStop = false;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.BorderRadius = 8;
            this.dtpCheckOutDate.Checked = true;
            this.dtpCheckOutDate.FillColor = System.Drawing.Color.White;
            this.dtpCheckOutDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpCheckOutDate.ForeColor = System.Drawing.Color.Black;
            this.dtpCheckOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpCheckOutDate.Location = new System.Drawing.Point(627, 57);
            this.dtpCheckOutDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckOutDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(252, 36);
            this.dtpCheckOutDate.TabIndex = 180;
            this.dtpCheckOutDate.Value = new System.DateTime(2024, 7, 26, 1, 35, 48, 147);
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.BorderRadius = 2;
            this.guna2PictureBox8.Image = global::Hotel.Properties.Resources.Calendar_321;
            this.guna2PictureBox8.ImageRotate = 0F;
            this.guna2PictureBox8.Location = new System.Drawing.Point(140, 62);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox8.TabIndex = 179;
            this.guna2PictureBox8.TabStop = false;
            // 
            // guna2PictureBox16
            // 
            this.guna2PictureBox16.BorderRadius = 2;
            this.guna2PictureBox16.Image = global::Hotel.Properties.Resources.id;
            this.guna2PictureBox16.ImageRotate = 0F;
            this.guna2PictureBox16.Location = new System.Drawing.Point(141, 17);
            this.guna2PictureBox16.Name = "guna2PictureBox16";
            this.guna2PictureBox16.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox16.TabIndex = 177;
            this.guna2PictureBox16.TabStop = false;
            // 
            // lblBookingID
            // 
            this.lblBookingID.BackColor = System.Drawing.Color.Transparent;
            this.lblBookingID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingID.ForeColor = System.Drawing.Color.Black;
            this.lblBookingID.Location = new System.Drawing.Point(180, 17);
            this.lblBookingID.Name = "lblBookingID";
            this.lblBookingID.Size = new System.Drawing.Size(43, 23);
            this.lblBookingID.TabIndex = 176;
            this.lblBookingID.Text = "[????]";
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(51, 17);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(86, 23);
            this.guna2HtmlLabel3.TabIndex = 175;
            this.guna2HtmlLabel3.Text = "Booking ID :";
            // 
            // tpPaymentInfo
            // 
            this.tpPaymentInfo.Controls.Add(this.pPaymentInfo);
            this.tpPaymentInfo.Location = new System.Drawing.Point(4, 44);
            this.tpPaymentInfo.Name = "tpPaymentInfo";
            this.tpPaymentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPaymentInfo.Size = new System.Drawing.Size(1137, 532);
            this.tpPaymentInfo.TabIndex = 2;
            this.tpPaymentInfo.Text = "Payment Info";
            this.tpPaymentInfo.UseVisualStyleBackColor = true;
            // 
            // pPaymentInfo
            // 
            this.pPaymentInfo.Controls.Add(this.rbCreditCard);
            this.pPaymentInfo.Controls.Add(this.btnBackToBookingInfo);
            this.pPaymentInfo.Controls.Add(this.guna2PictureBox14);
            this.pPaymentInfo.Controls.Add(this.txtNotes);
            this.pPaymentInfo.Controls.Add(this.guna2PictureBox12);
            this.pPaymentInfo.Controls.Add(this.guna2PictureBox13);
            this.pPaymentInfo.Controls.Add(this.rbCash);
            this.pPaymentInfo.Controls.Add(this.pbGender);
            this.pPaymentInfo.Controls.Add(this.guna2HtmlLabel9);
            this.pPaymentInfo.Controls.Add(this.guna2PictureBox11);
            this.pPaymentInfo.Controls.Add(this.lblPaymentAmount);
            this.pPaymentInfo.Controls.Add(this.guna2HtmlLabel14);
            this.pPaymentInfo.Controls.Add(this.guna2PictureBox9);
            this.pPaymentInfo.Controls.Add(this.lblPaymentDate);
            this.pPaymentInfo.Controls.Add(this.guna2HtmlLabel11);
            this.pPaymentInfo.Controls.Add(this.guna2PictureBox7);
            this.pPaymentInfo.Controls.Add(this.lblPaymentID);
            this.pPaymentInfo.Controls.Add(this.guna2HtmlLabel10);
            this.pPaymentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPaymentInfo.Location = new System.Drawing.Point(3, 3);
            this.pPaymentInfo.Name = "pPaymentInfo";
            this.pPaymentInfo.Size = new System.Drawing.Size(1131, 526);
            this.pPaymentInfo.TabIndex = 179;
            // 
            // rbCreditCard
            // 
            this.rbCreditCard.AutoSize = true;
            this.rbCreditCard.Checked = true;
            this.rbCreditCard.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbCreditCard.CheckedState.BorderThickness = 0;
            this.rbCreditCard.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbCreditCard.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbCreditCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbCreditCard.Location = new System.Drawing.Point(839, 261);
            this.rbCreditCard.Name = "rbCreditCard";
            this.rbCreditCard.Size = new System.Drawing.Size(95, 21);
            this.rbCreditCard.TabIndex = 199;
            this.rbCreditCard.TabStop = true;
            this.rbCreditCard.Text = "Credit Card";
            this.rbCreditCard.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbCreditCard.UncheckedState.BorderThickness = 2;
            this.rbCreditCard.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbCreditCard.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // btnBackToBookingInfo
            // 
            this.btnBackToBookingInfo.Animated = true;
            this.btnBackToBookingInfo.BorderRadius = 8;
            this.btnBackToBookingInfo.BorderThickness = 1;
            this.btnBackToBookingInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToBookingInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToBookingInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBackToBookingInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackToBookingInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBackToBookingInfo.FillColor = System.Drawing.SystemColors.Control;
            this.btnBackToBookingInfo.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnBackToBookingInfo.ForeColor = System.Drawing.Color.Black;
            this.btnBackToBookingInfo.Image = global::Hotel.Properties.Resources.Prev_32;
            this.btnBackToBookingInfo.ImageSize = new System.Drawing.Size(30, 30);
            this.btnBackToBookingInfo.Location = new System.Drawing.Point(974, 478);
            this.btnBackToBookingInfo.Name = "btnBackToBookingInfo";
            this.btnBackToBookingInfo.Size = new System.Drawing.Size(154, 45);
            this.btnBackToBookingInfo.TabIndex = 198;
            this.btnBackToBookingInfo.Text = "Back";
            this.btnBackToBookingInfo.Click += new System.EventHandler(this.btnBackToBookingInfo_Click);
            // 
            // guna2PictureBox14
            // 
            this.guna2PictureBox14.BorderRadius = 2;
            this.guna2PictureBox14.Image = global::Hotel.Properties.Resources.Notes_32;
            this.guna2PictureBox14.ImageRotate = 0F;
            this.guna2PictureBox14.Location = new System.Drawing.Point(676, 305);
            this.guna2PictureBox14.Name = "guna2PictureBox14";
            this.guna2PictureBox14.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox14.TabIndex = 197;
            this.guna2PictureBox14.TabStop = false;
            // 
            // txtNotes
            // 
            this.txtNotes.Animated = true;
            this.txtNotes.AutoScroll = true;
            this.txtNotes.AutoSize = true;
            this.txtNotes.BorderRadius = 8;
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNotes.Location = new System.Drawing.Point(716, 305);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtNotes.PlaceholderText = "Notes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(314, 85);
            this.txtNotes.TabIndex = 196;
            // 
            // guna2PictureBox12
            // 
            this.guna2PictureBox12.Image = global::Hotel.Properties.Resources.icons8_payment_100;
            this.guna2PictureBox12.ImageRotate = 0F;
            this.guna2PictureBox12.Location = new System.Drawing.Point(100, 11);
            this.guna2PictureBox12.Name = "guna2PictureBox12";
            this.guna2PictureBox12.Size = new System.Drawing.Size(361, 505);
            this.guna2PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox12.TabIndex = 195;
            this.guna2PictureBox12.TabStop = false;
            // 
            // guna2PictureBox13
            // 
            this.guna2PictureBox13.BorderRadius = 2;
            this.guna2PictureBox13.Image = global::Hotel.Properties.Resources.payment_credit_card_32;
            this.guna2PictureBox13.ImageRotate = 0F;
            this.guna2PictureBox13.Location = new System.Drawing.Point(789, 261);
            this.guna2PictureBox13.Name = "guna2PictureBox13";
            this.guna2PictureBox13.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox13.TabIndex = 194;
            this.guna2PictureBox13.TabStop = false;
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbCash.CheckedState.BorderThickness = 0;
            this.rbCash.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbCash.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbCash.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.rbCash.Location = new System.Drawing.Point(716, 259);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(55, 21);
            this.rbCash.TabIndex = 192;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbCash.UncheckedState.BorderThickness = 2;
            this.rbCash.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbCash.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // pbGender
            // 
            this.pbGender.BorderRadius = 2;
            this.pbGender.Image = global::Hotel.Properties.Resources.payment_cash_32;
            this.pbGender.ImageRotate = 0F;
            this.pbGender.Location = new System.Drawing.Point(677, 258);
            this.pbGender.Name = "pbGender";
            this.pbGender.Size = new System.Drawing.Size(33, 23);
            this.pbGender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGender.TabIndex = 193;
            this.pbGender.TabStop = false;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(543, 267);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(129, 23);
            this.guna2HtmlLabel9.TabIndex = 191;
            this.guna2HtmlLabel9.Text = "Payment Method :";
            // 
            // guna2PictureBox11
            // 
            this.guna2PictureBox11.BorderRadius = 2;
            this.guna2PictureBox11.Image = global::Hotel.Properties.Resources.icons8_payment_32;
            this.guna2PictureBox11.ImageRotate = 0F;
            this.guna2PictureBox11.Location = new System.Drawing.Point(677, 201);
            this.guna2PictureBox11.Name = "guna2PictureBox11";
            this.guna2PictureBox11.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox11.TabIndex = 190;
            this.guna2PictureBox11.TabStop = false;
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentAmount.Location = new System.Drawing.Point(716, 201);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(12, 23);
            this.lblPaymentAmount.TabIndex = 189;
            this.lblPaymentAmount.Text = "0";
            // 
            // guna2HtmlLabel14
            // 
            this.guna2HtmlLabel14.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel14.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel14.Location = new System.Drawing.Point(541, 207);
            this.guna2HtmlLabel14.Name = "guna2HtmlLabel14";
            this.guna2HtmlLabel14.Size = new System.Drawing.Size(131, 23);
            this.guna2HtmlLabel14.TabIndex = 188;
            this.guna2HtmlLabel14.Text = "Payment Amount :";
            // 
            // guna2PictureBox9
            // 
            this.guna2PictureBox9.BorderRadius = 2;
            this.guna2PictureBox9.Image = global::Hotel.Properties.Resources.Calendar_32;
            this.guna2PictureBox9.ImageRotate = 0F;
            this.guna2PictureBox9.Location = new System.Drawing.Point(677, 144);
            this.guna2PictureBox9.Name = "guna2PictureBox9";
            this.guna2PictureBox9.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox9.TabIndex = 184;
            this.guna2PictureBox9.TabStop = false;
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentDate.Location = new System.Drawing.Point(716, 144);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(43, 23);
            this.lblPaymentDate.TabIndex = 183;
            this.lblPaymentDate.Text = "[????]";
            // 
            // guna2HtmlLabel11
            // 
            this.guna2HtmlLabel11.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel11.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel11.Location = new System.Drawing.Point(565, 147);
            this.guna2HtmlLabel11.Name = "guna2HtmlLabel11";
            this.guna2HtmlLabel11.Size = new System.Drawing.Size(107, 23);
            this.guna2HtmlLabel11.TabIndex = 182;
            this.guna2HtmlLabel11.Text = "Payment Date :";
            // 
            // guna2PictureBox7
            // 
            this.guna2PictureBox7.BorderRadius = 2;
            this.guna2PictureBox7.Image = global::Hotel.Properties.Resources.id;
            this.guna2PictureBox7.ImageRotate = 0F;
            this.guna2PictureBox7.Location = new System.Drawing.Point(677, 87);
            this.guna2PictureBox7.Name = "guna2PictureBox7";
            this.guna2PictureBox7.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox7.TabIndex = 181;
            this.guna2PictureBox7.TabStop = false;
            // 
            // lblPaymentID
            // 
            this.lblPaymentID.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentID.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentID.Location = new System.Drawing.Point(716, 87);
            this.lblPaymentID.Name = "lblPaymentID";
            this.lblPaymentID.Size = new System.Drawing.Size(43, 23);
            this.lblPaymentID.TabIndex = 180;
            this.lblPaymentID.Text = "[????]";
            // 
            // guna2HtmlLabel10
            // 
            this.guna2HtmlLabel10.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel10.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel10.Location = new System.Drawing.Point(582, 87);
            this.guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            this.guna2HtmlLabel10.Size = new System.Drawing.Size(90, 23);
            this.guna2HtmlLabel10.TabIndex = 179;
            this.guna2HtmlLabel10.Text = "Payment ID :";
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
            this.btnSave.Location = new System.Drawing.Point(985, 638);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(154, 45);
            this.btnSave.TabIndex = 72;
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
            this.btnClose.Location = new System.Drawing.Point(825, 638);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(154, 45);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddEditBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1150, 686);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcBooking);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Booking";
            this.Load += new System.EventHandler(this.frmAddEditBooking_Load);
            this.tcBooking.ResumeLayout(false);
            this.tpGuestInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.tpBookingInfo.ResumeLayout(false);
            this.pBookingInfo.ResumeLayout(false);
            this.pBookingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomsForBooking)).EndInit();
            this.cmsListRoomsForBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListRoomsForRoomClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberChildren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberAdults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox16)).EndInit();
            this.tpPaymentInfo.ResumeLayout(false);
            this.pPaymentInfo.ResumeLayout(false);
            this.pPaymentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2TabControl tcBooking;
        private System.Windows.Forms.TabPage tpGuestInfo;
        private System.Windows.Forms.TabPage tpBookingInfo;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnNextToBookingInfo;
        private Guests.Controls.ctrlGuestInfoWithFilter ctrlGuestInfoWithFilter1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.TabPage tpPaymentInfo;
        private Guna.UI2.WinForms.Guna2Panel pPaymentInfo;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox14;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox12;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox13;
        private Guna.UI2.WinForms.Guna2RadioButton rbCash;
        private Guna.UI2.WinForms.Guna2PictureBox pbGender;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox11;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPaymentAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel14;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox9;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPaymentDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel11;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox7;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPaymentID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2Button btnBackToBookingInfo;
        private Guna.UI2.WinForms.Guna2Panel pBookingInfo;
        private Guna.UI2.WinForms.Guna2Button btnBackToGuestInfo;
        private Guna.UI2.WinForms.Guna2Button btnNextToPaymentInfo;
        private System.Windows.Forms.DataGridView dgvListRoomsForBooking;
        private Guna.UI2.WinForms.Guna2ImageButton btnChoose;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2ComboBox cbRoomClasses;
        private System.Windows.Forms.DataGridView dgvListRoomsForRoomClass;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox6;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDiscount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox5;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBookingAmount;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudNumberChildren;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudNumberAdults;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckOutDate;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox16;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBookingID;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCheckInDate;
        private Guna.UI2.WinForms.Guna2RadioButton rbCreditCard;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCountForRoomsBooking;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel15;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecordsCountForRooms;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel12;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn FloorNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNumber;
        private System.Windows.Forms.ContextMenuStrip cmsListRoomsForBookings;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}