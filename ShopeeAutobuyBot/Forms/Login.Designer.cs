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
            components=new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            btnLogin=new System.Windows.Forms.Button();
            tbId=new System.Windows.Forms.TextBox();
            darkLabel1=new System.Windows.Forms.Label();
            darkLabel2=new System.Windows.Forms.Label();
            notifyIcon1=new System.Windows.Forms.NotifyIcon(components);
            darkSectionPanel1=new System.Windows.Forms.GroupBox();
            listBoxChromeProfile=new System.Windows.Forms.ListBox();
            btnAddChromeProfile=new System.Windows.Forms.Button();
            btnDeleteProfile=new System.Windows.Forms.Button();
            tbNewChromeProfile=new System.Windows.Forms.TextBox();
            darkLabel3=new System.Windows.Forms.Label();
            darkCheckBoxHeadless=new System.Windows.Forms.CheckBox();
            darkCheckBoxDisableImageExtension=new System.Windows.Forms.CheckBox();
            groupBox1=new System.Windows.Forms.GroupBox();
            groupBox2=new System.Windows.Forms.GroupBox();
            darkSectionPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font=new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLogin.Location=new System.Drawing.Point(12, 284);
            btnLogin.Name="btnLogin";
            btnLogin.Size=new System.Drawing.Size(393, 26);
            btnLogin.TabIndex=0;
            btnLogin.Text="Launch SAB";
            btnLogin.Click+=darkButton1_Click;
            // 
            // tbId
            // 
            tbId.Enabled=false;
            tbId.Font=new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbId.Location=new System.Drawing.Point(154, 71);
            tbId.Name="tbId";
            tbId.Size=new System.Drawing.Size(142, 22);
            tbId.TabIndex=1;
            tbId.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            tbId.Visible=false;
            tbId.TextChanged+=tbId_TextChanged;
            // 
            // darkLabel1
            // 
            darkLabel1.AutoSize=true;
            darkLabel1.Font=new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            darkLabel1.ForeColor=System.Drawing.SystemColors.ControlText;
            darkLabel1.Location=new System.Drawing.Point(96, 76);
            darkLabel1.Name="darkLabel1";
            darkLabel1.Size=new System.Drawing.Size(52, 13);
            darkLabel1.TabIndex=2;
            darkLabel1.Text="User Id : ";
            darkLabel1.Visible=false;
            // 
            // darkLabel2
            // 
            darkLabel2.AutoSize=true;
            darkLabel2.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel2.Location=new System.Drawing.Point(11, 180);
            darkLabel2.Name="darkLabel2";
            darkLabel2.Size=new System.Drawing.Size(0, 13);
            darkLabel2.TabIndex=3;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text="notifyIcon1";
            notifyIcon1.Visible=true;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(listBoxChromeProfile);
            darkSectionPanel1.Location=new System.Drawing.Point(14, 23);
            darkSectionPanel1.Name="darkSectionPanel1";
            darkSectionPanel1.Size=new System.Drawing.Size(217, 120);
            darkSectionPanel1.TabIndex=15;
            darkSectionPanel1.TabStop=false;
            darkSectionPanel1.Text="SAB profile";
            // 
            // listBoxChromeProfile
            // 
            listBoxChromeProfile.Dock=System.Windows.Forms.DockStyle.Fill;
            listBoxChromeProfile.FormattingEnabled=true;
            listBoxChromeProfile.Location=new System.Drawing.Point(3, 18);
            listBoxChromeProfile.Name="listBoxChromeProfile";
            listBoxChromeProfile.Size=new System.Drawing.Size(211, 99);
            listBoxChromeProfile.TabIndex=0;
            // 
            // btnAddChromeProfile
            // 
            btnAddChromeProfile.Location=new System.Drawing.Point(237, 67);
            btnAddChromeProfile.Name="btnAddChromeProfile";
            btnAddChromeProfile.Size=new System.Drawing.Size(141, 26);
            btnAddChromeProfile.TabIndex=16;
            btnAddChromeProfile.Text="Add profile";
            btnAddChromeProfile.Click+=darkButton1_Click_2;
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Location=new System.Drawing.Point(238, 117);
            btnDeleteProfile.Name="btnDeleteProfile";
            btnDeleteProfile.Size=new System.Drawing.Size(141, 26);
            btnDeleteProfile.TabIndex=17;
            btnDeleteProfile.Text="Delete profile";
            btnDeleteProfile.Click+=btnDeleteProfile_Click;
            // 
            // tbNewChromeProfile
            // 
            tbNewChromeProfile.Font=new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tbNewChromeProfile.Location=new System.Drawing.Point(237, 39);
            tbNewChromeProfile.Name="tbNewChromeProfile";
            tbNewChromeProfile.Size=new System.Drawing.Size(142, 22);
            tbNewChromeProfile.TabIndex=18;
            tbNewChromeProfile.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel3
            // 
            darkLabel3.AutoSize=true;
            darkLabel3.ForeColor=System.Drawing.SystemColors.ControlText;
            darkLabel3.Location=new System.Drawing.Point(237, 23);
            darkLabel3.Name="darkLabel3";
            darkLabel3.Size=new System.Drawing.Size(92, 13);
            darkLabel3.TabIndex=19;
            darkLabel3.Text="New SAB profile:";
            // 
            // darkCheckBoxHeadless
            // 
            darkCheckBoxHeadless.AutoSize=true;
            darkCheckBoxHeadless.Location=new System.Drawing.Point(99, 29);
            darkCheckBoxHeadless.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxHeadless.Name="darkCheckBoxHeadless";
            darkCheckBoxHeadless.Size=new System.Drawing.Size(136, 17);
            darkCheckBoxHeadless.TabIndex=49;
            darkCheckBoxHeadless.Text="Hide chrome browser";
            // 
            // darkCheckBoxDisableImageExtension
            // 
            darkCheckBoxDisableImageExtension.AutoSize=true;
            darkCheckBoxDisableImageExtension.Location=new System.Drawing.Point(99, 58);
            darkCheckBoxDisableImageExtension.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxDisableImageExtension.Name="darkCheckBoxDisableImageExtension";
            darkCheckBoxDisableImageExtension.Size=new System.Drawing.Size(206, 17);
            darkCheckBoxDisableImageExtension.TabIndex=48;
            darkCheckBoxDisableImageExtension.Text="Disable website image && extension";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(darkCheckBoxHeadless);
            groupBox1.Controls.Add(darkCheckBoxDisableImageExtension);
            groupBox1.Controls.Add(tbId);
            groupBox1.Controls.Add(darkLabel1);
            groupBox1.Location=new System.Drawing.Point(12, 171);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new System.Drawing.Size(393, 105);
            groupBox1.TabIndex=50;
            groupBox1.TabStop=false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(darkSectionPanel1);
            groupBox2.Controls.Add(tbNewChromeProfile);
            groupBox2.Controls.Add(btnDeleteProfile);
            groupBox2.Controls.Add(darkLabel3);
            groupBox2.Controls.Add(btnAddChromeProfile);
            groupBox2.Location=new System.Drawing.Point(12, 8);
            groupBox2.Name="groupBox2";
            groupBox2.Size=new System.Drawing.Size(393, 162);
            groupBox2.TabIndex=51;
            groupBox2.TabStop=false;
            // 
            // Login
            // 
            AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            BackColor=System.Drawing.SystemColors.ActiveCaption;
            ClientSize=new System.Drawing.Size(417, 321);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnLogin);
            Controls.Add(darkLabel2);
            Font=new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon=(System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox=false;
            Name="Login";
            SizeGripStyle=System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Text="Shopee Autobuy Bot";
            FormClosing+=Form2_FormClosing;
            Load+=Form2_Load;
            darkSectionPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label darkLabel1;
        private System.Windows.Forms.Label darkLabel2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox darkSectionPanel1;
        private System.Windows.Forms.Button btnAddChromeProfile;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.TextBox tbNewChromeProfile;
        private System.Windows.Forms.Label darkLabel3;
        private System.Windows.Forms.CheckBox darkCheckBoxHeadless;
        private System.Windows.Forms.CheckBox darkCheckBoxDisableImageExtension;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxChromeProfile;
    }
}