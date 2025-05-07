namespace Hotel.Rooms.Controls
{
    partial class ctrlRoomCardInfoWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.gbFilters = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.txtFilterValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.lablae1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbFilters = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ctrlRoomCardInfo1 = new Hotel.Rooms.ctrlRoomCardInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Controls.Add(this.lablae1);
            this.gbFilters.Controls.Add(this.cbFilters);
            this.gbFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbFilters.Location = new System.Drawing.Point(3, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(517, 112);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.Text = "Filter";
            // 
            // btnFind
            // 
            this.btnFind.Animated = true;
            this.btnFind.BorderRadius = 8;
            this.btnFind.BorderThickness = 1;
            this.btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFind.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFind.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFind.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFind.FillColor = System.Drawing.SystemColors.Control;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnFind.ForeColor = System.Drawing.Color.Black;
            this.btnFind.Image = global::Hotel.Properties.Resources.icons8_find_32;
            this.btnFind.ImageSize = new System.Drawing.Size(50, 50);
            this.btnFind.Location = new System.Drawing.Point(464, 52);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(40, 37);
            this.btnFind.TabIndex = 155;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Animated = true;
            this.txtFilterValue.BorderRadius = 8;
            this.txtFilterValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtFilterValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFilterValue.DefaultText = "";
            this.txtFilterValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFilterValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFilterValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFilterValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFilterValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFilterValue.ForeColor = System.Drawing.Color.Black;
            this.txtFilterValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFilterValue.Location = new System.Drawing.Point(283, 54);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.PasswordChar = '\0';
            this.txtFilterValue.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFilterValue.PlaceholderText = "Filter Value";
            this.txtFilterValue.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFilterValue.SelectedText = "";
            this.txtFilterValue.Size = new System.Drawing.Size(147, 35);
            this.txtFilterValue.TabIndex = 149;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // lablae1
            // 
            this.lablae1.BackColor = System.Drawing.Color.Transparent;
            this.lablae1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablae1.ForeColor = System.Drawing.Color.Black;
            this.lablae1.Location = new System.Drawing.Point(5, 60);
            this.lablae1.Name = "lablae1";
            this.lablae1.Size = new System.Drawing.Size(73, 23);
            this.lablae1.TabIndex = 100;
            this.lablae1.Text = "Filter By : ";
            // 
            // cbFilters
            // 
            this.cbFilters.BackColor = System.Drawing.Color.Transparent;
            this.cbFilters.BorderRadius = 8;
            this.cbFilters.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilters.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbFilters.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilters.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFilters.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.cbFilters.ForeColor = System.Drawing.Color.Black;
            this.cbFilters.ItemHeight = 30;
            this.cbFilters.Items.AddRange(new object[] {
            "Room Number",
            "Room ID"});
            this.cbFilters.Location = new System.Drawing.Point(84, 54);
            this.cbFilters.Name = "cbFilters";
            this.cbFilters.Size = new System.Drawing.Size(192, 36);
            this.cbFilters.StartIndex = 0;
            this.cbFilters.TabIndex = 11;
            this.cbFilters.SelectedIndexChanged += new System.EventHandler(this.cbFilters_SelectedIndexChanged);
            // 
            // ctrlRoomCardInfo1
            // 
            this.ctrlRoomCardInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlRoomCardInfo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlRoomCardInfo1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlRoomCardInfo1.Location = new System.Drawing.Point(0, 118);
            this.ctrlRoomCardInfo1.Name = "ctrlRoomCardInfo1";
            this.ctrlRoomCardInfo1.Size = new System.Drawing.Size(756, 209);
            this.ctrlRoomCardInfo1.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlRoomCardInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlRoomCardInfo1);
            this.Controls.Add(this.gbFilters);
            this.Name = "ctrlRoomCardInfoWithFilter";
            this.Size = new System.Drawing.Size(756, 327);
            this.Load += new System.EventHandler(this.ctrlRoomCardInfoWithFilter_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbFilters;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilters;
        private Guna.UI2.WinForms.Guna2HtmlLabel lablae1;
        private Guna.UI2.WinForms.Guna2TextBox txtFilterValue;
        private Guna.UI2.WinForms.Guna2Button btnFind;
        private ctrlRoomCardInfo ctrlRoomCardInfo1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
