namespace Hotel.Features
{
    partial class frmAddEditFeature
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
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox8 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblFeatureID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox18 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox19 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtFeatureName = new Guna.UI2.WinForms.Guna2TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(252, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 45);
            this.btnSave.TabIndex = 138;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BorderRadius = 8;
            this.btnClose.BorderThickness = 1;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::Hotel.Properties.Resources.Close_32;
            this.btnClose.ImageSize = new System.Drawing.Size(30, 30);
            this.btnClose.Location = new System.Drawing.Point(127, 277);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 45);
            this.btnClose.TabIndex = 139;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2PictureBox8
            // 
            this.guna2PictureBox8.BorderRadius = 2;
            this.guna2PictureBox8.Image = global::Hotel.Properties.Resources.id;
            this.guna2PictureBox8.ImageRotate = 0F;
            this.guna2PictureBox8.Location = new System.Drawing.Point(30, 84);
            this.guna2PictureBox8.Name = "guna2PictureBox8";
            this.guna2PictureBox8.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox8.TabIndex = 144;
            this.guna2PictureBox8.TabStop = false;
            // 
            // lblFeatureID
            // 
            this.lblFeatureID.BackColor = System.Drawing.Color.Transparent;
            this.lblFeatureID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeatureID.ForeColor = System.Drawing.Color.Black;
            this.lblFeatureID.Location = new System.Drawing.Point(64, 84);
            this.lblFeatureID.Name = "lblFeatureID";
            this.lblFeatureID.Size = new System.Drawing.Size(43, 23);
            this.lblFeatureID.TabIndex = 143;
            this.lblFeatureID.Text = "[????]";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(64, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(264, 47);
            this.lblTitle.TabIndex = 142;
            this.lblTitle.Text = "Add New Feature";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2PictureBox18
            // 
            this.guna2PictureBox18.BorderRadius = 2;
            this.guna2PictureBox18.Image = global::Hotel.Properties.Resources.Notes_32;
            this.guna2PictureBox18.ImageRotate = 0F;
            this.guna2PictureBox18.Location = new System.Drawing.Point(24, 184);
            this.guna2PictureBox18.Name = "guna2PictureBox18";
            this.guna2PictureBox18.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox18.TabIndex = 141;
            this.guna2PictureBox18.TabStop = false;
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
            this.txtDescription.Location = new System.Drawing.Point(64, 185);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDescription.PlaceholderText = "Descriptions";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(314, 85);
            this.txtDescription.TabIndex = 137;
            // 
            // guna2PictureBox19
            // 
            this.guna2PictureBox19.BorderRadius = 2;
            this.guna2PictureBox19.Image = global::Hotel.Properties.Resources.icons8_feature_100;
            this.guna2PictureBox19.ImageRotate = 0F;
            this.guna2PictureBox19.Location = new System.Drawing.Point(26, 130);
            this.guna2PictureBox19.Name = "guna2PictureBox19";
            this.guna2PictureBox19.Size = new System.Drawing.Size(33, 23);
            this.guna2PictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox19.TabIndex = 140;
            this.guna2PictureBox19.TabStop = false;
            // 
            // txtFeatureName
            // 
            this.txtFeatureName.Animated = true;
            this.txtFeatureName.BorderRadius = 8;
            this.txtFeatureName.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtFeatureName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFeatureName.DefaultText = "";
            this.txtFeatureName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFeatureName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFeatureName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFeatureName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFeatureName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtFeatureName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFeatureName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFeatureName.ForeColor = System.Drawing.Color.Black;
            this.txtFeatureName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFeatureName.Location = new System.Drawing.Point(64, 128);
            this.txtFeatureName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFeatureName.Name = "txtFeatureName";
            this.txtFeatureName.PasswordChar = '\0';
            this.txtFeatureName.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtFeatureName.PlaceholderText = "Feature Name";
            this.txtFeatureName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFeatureName.SelectedText = "";
            this.txtFeatureName.Size = new System.Drawing.Size(309, 40);
            this.txtFeatureName.TabIndex = 136;
            this.txtFeatureName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFeatureName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 326);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.guna2PictureBox8);
            this.Controls.Add(this.lblFeatureID);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.guna2PictureBox18);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.guna2PictureBox19);
            this.Controls.Add(this.txtFeatureName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditFeature";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Feature";
            this.Load += new System.EventHandler(this.frmAddEditFeature_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox8;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFeatureID;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox18;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox19;
        private Guna.UI2.WinForms.Guna2TextBox txtFeatureName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}