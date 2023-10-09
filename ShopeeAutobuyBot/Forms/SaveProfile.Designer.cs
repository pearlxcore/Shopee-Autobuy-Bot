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
            btnSave=new System.Windows.Forms.Button();
            darkLabel14=new System.Windows.Forms.Label();
            tbProfileName=new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Font=new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnSave.Location=new System.Drawing.Point(88, 59);
            btnSave.Margin=new System.Windows.Forms.Padding(2);
            btnSave.Name="btnSave";
            btnSave.Size=new System.Drawing.Size(95, 27);
            btnSave.TabIndex=52;
            btnSave.Text="Save profile";
            btnSave.Click+=btnSave_Click;
            // 
            // darkLabel14
            // 
            darkLabel14.AutoSize=true;
            darkLabel14.ForeColor=System.Drawing.SystemColors.ControlText;
            darkLabel14.Location=new System.Drawing.Point(15, 11);
            darkLabel14.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel14.Name="darkLabel14";
            darkLabel14.Size=new System.Drawing.Size(105, 13);
            darkLabel14.TabIndex=54;
            darkLabel14.Text="Enter profile name:";
            // 
            // tbProfileName
            // 
            tbProfileName.Location=new System.Drawing.Point(18, 27);
            tbProfileName.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbProfileName.MaxLength=50;
            tbProfileName.Name="tbProfileName";
            tbProfileName.Size=new System.Drawing.Size(237, 22);
            tbProfileName.TabIndex=53;
            tbProfileName.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveProfile
            // 
            AutoScaleDimensions=new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            BackColor=System.Drawing.SystemColors.ActiveCaption;
            ClientSize=new System.Drawing.Size(271, 96);
            Controls.Add(btnSave);
            Controls.Add(darkLabel14);
            Controls.Add(tbProfileName);
            Font=new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon=(System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox=false;
            MinimizeBox=false;
            Name="SaveProfile";
            SizeGripStyle=System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Text="New Profile";
            FormClosing+=ProfileName_FormClosing;
            Load+=ProfileName_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label darkLabel14;
        private System.Windows.Forms.TextBox tbProfileName;
    }
}