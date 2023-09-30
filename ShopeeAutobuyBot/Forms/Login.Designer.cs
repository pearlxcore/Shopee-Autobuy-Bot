namespace Shopee_Autobuy_Bot
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnLogin = new DarkUI.Controls.DarkButton();
            this.tbId = new DarkUI.Controls.DarkTextBox();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.listBoxChromeProfile = new DarkUI.Controls.DarkListBox(this.components);
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.btnAddChromeProfile = new DarkUI.Controls.DarkButton();
            this.btnDeleteProfile = new DarkUI.Controls.DarkButton();
            this.tbNewChromeProfile = new DarkUI.Controls.DarkTextBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBoxHeadless = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxDisableImageExtension = new DarkUI.Controls.DarkCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.darkSectionPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(12, 284);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(393, 28);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Launch SAB";
            this.btnLogin.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbId.Location = new System.Drawing.Point(154, 71);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(142, 22);
            this.tbId.TabIndex = 1;
            this.tbId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbId.TextChanged += new System.EventHandler(this.tbId_TextChanged);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(96, 76);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(52, 13);
            this.darkLabel1.TabIndex = 2;
            this.darkLabel1.Text = "User Id : ";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(11, 180);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(0, 13);
            this.darkLabel2.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // listBoxChromeProfile
            // 
            this.listBoxChromeProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.listBoxChromeProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxChromeProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxChromeProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxChromeProfile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxChromeProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.listBoxChromeProfile.FormattingEnabled = true;
            this.listBoxChromeProfile.ItemHeight = 18;
            this.listBoxChromeProfile.Location = new System.Drawing.Point(1, 25);
            this.listBoxChromeProfile.Name = "listBoxChromeProfile";
            this.listBoxChromeProfile.Size = new System.Drawing.Size(215, 94);
            this.listBoxChromeProfile.TabIndex = 14;
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.Controls.Add(this.listBoxChromeProfile);
            this.darkSectionPanel1.Location = new System.Drawing.Point(14, 23);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Shopee Account";
            this.darkSectionPanel1.Size = new System.Drawing.Size(217, 120);
            this.darkSectionPanel1.TabIndex = 15;
            // 
            // btnAddChromeProfile
            // 
            this.btnAddChromeProfile.Location = new System.Drawing.Point(237, 67);
            this.btnAddChromeProfile.Name = "btnAddChromeProfile";
            this.btnAddChromeProfile.Size = new System.Drawing.Size(141, 20);
            this.btnAddChromeProfile.TabIndex = 16;
            this.btnAddChromeProfile.Text = "Add Shopee account";
            this.btnAddChromeProfile.Click += new System.EventHandler(this.darkButton1_Click_2);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Location = new System.Drawing.Point(238, 123);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(141, 20);
            this.btnDeleteProfile.TabIndex = 17;
            this.btnDeleteProfile.Text = "Delete selected account";
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // tbNewChromeProfile
            // 
            this.tbNewChromeProfile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewChromeProfile.Location = new System.Drawing.Point(237, 39);
            this.tbNewChromeProfile.Name = "tbNewChromeProfile";
            this.tbNewChromeProfile.Size = new System.Drawing.Size(142, 22);
            this.tbNewChromeProfile.TabIndex = 18;
            this.tbNewChromeProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(237, 23);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(119, 13);
            this.darkLabel3.TabIndex = 19;
            this.darkLabel3.Text = "New Shopee account:";
            // 
            // darkCheckBoxHeadless
            // 
            this.darkCheckBoxHeadless.AutoSize = true;
            this.darkCheckBoxHeadless.Location = new System.Drawing.Point(99, 18);
            this.darkCheckBoxHeadless.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxHeadless.Name = "darkCheckBoxHeadless";
            this.darkCheckBoxHeadless.Size = new System.Drawing.Size(137, 17);
            this.darkCheckBoxHeadless.TabIndex = 49;
            this.darkCheckBoxHeadless.Text = "Hide Chrome Browser";
            // 
            // darkCheckBoxDisableImageExtension
            // 
            this.darkCheckBoxDisableImageExtension.AutoSize = true;
            this.darkCheckBoxDisableImageExtension.Location = new System.Drawing.Point(99, 47);
            this.darkCheckBoxDisableImageExtension.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxDisableImageExtension.Name = "darkCheckBoxDisableImageExtension";
            this.darkCheckBoxDisableImageExtension.Size = new System.Drawing.Size(197, 17);
            this.darkCheckBoxDisableImageExtension.TabIndex = 48;
            this.darkCheckBoxDisableImageExtension.Text = "Disable website Image & Extension";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.darkCheckBoxHeadless);
            this.groupBox1.Controls.Add(this.darkCheckBoxDisableImageExtension);
            this.groupBox1.Controls.Add(this.tbId);
            this.groupBox1.Controls.Add(this.darkLabel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 105);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.darkSectionPanel1);
            this.groupBox2.Controls.Add(this.tbNewChromeProfile);
            this.groupBox2.Controls.Add(this.btnDeleteProfile);
            this.groupBox2.Controls.Add(this.darkLabel3);
            this.groupBox2.Controls.Add(this.btnAddChromeProfile);
            this.groupBox2.Location = new System.Drawing.Point(12, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 162);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 321);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.darkLabel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopee Autobuy Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.darkSectionPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DarkUI.Controls.DarkButton btnLogin;
        private DarkUI.Controls.DarkTextBox tbId;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DarkUI.Controls.DarkListBox listBoxChromeProfile;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkButton btnAddChromeProfile;
        private DarkUI.Controls.DarkButton btnDeleteProfile;
        private DarkUI.Controls.DarkTextBox tbNewChromeProfile;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxHeadless;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxDisableImageExtension;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}