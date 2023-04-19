namespace Shopee_Autobuy_Bot
{
    partial class SaveProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveProfile));
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.darkLabel14 = new DarkUI.Controls.DarkLabel();
            this.tbProfileName = new DarkUI.Controls.DarkTextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(88, 59);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 27);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Save profile";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // darkLabel14
            // 
            this.darkLabel14.AutoSize = true;
            this.darkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel14.Location = new System.Drawing.Point(15, 11);
            this.darkLabel14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel14.Name = "darkLabel14";
            this.darkLabel14.Size = new System.Drawing.Size(105, 13);
            this.darkLabel14.TabIndex = 54;
            this.darkLabel14.Text = "Enter profile name:";
            // 
            // tbProfileName
            // 
            this.tbProfileName.Location = new System.Drawing.Point(18, 27);
            this.tbProfileName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbProfileName.MaxLength = 50;
            this.tbProfileName.Name = "tbProfileName";
            this.tbProfileName.Size = new System.Drawing.Size(237, 22);
            this.tbProfileName.TabIndex = 53;
            this.tbProfileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProfileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 96);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.darkLabel14);
            this.Controls.Add(this.tbProfileName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileName";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileName_FormClosing);
            this.Load += new System.EventHandler(this.ProfileName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton btnSave;
        private DarkUI.Controls.DarkLabel darkLabel14;
        private DarkUI.Controls.DarkTextBox tbProfileName;
    }
}