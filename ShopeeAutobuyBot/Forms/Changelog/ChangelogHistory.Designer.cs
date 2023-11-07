namespace Shopee_Autobuy_Bot
{
    partial class ChangelogHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangelogHistory));
            darkTextBox1=new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // darkTextBox1
            // 
            darkTextBox1.BackColor=System.Drawing.SystemColors.Window;
            darkTextBox1.Dock=System.Windows.Forms.DockStyle.Fill;
            darkTextBox1.Location=new System.Drawing.Point(0, 0);
            darkTextBox1.Multiline=true;
            darkTextBox1.Name="darkTextBox1";
            darkTextBox1.ReadOnly=true;
            darkTextBox1.ScrollBars=System.Windows.Forms.ScrollBars.Vertical;
            darkTextBox1.Size=new System.Drawing.Size(933, 519);
            darkTextBox1.TabIndex=0;
            darkTextBox1.TabStop=false;
            // 
            // ChangelogHistory
            // 
            AutoScaleDimensions=new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            ClientSize=new System.Drawing.Size(933, 519);
            Controls.Add(darkTextBox1);
            Font=new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Icon=(System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name="ChangelogHistory";
            StartPosition=System.Windows.Forms.FormStartPosition.CenterParent;
            Text="Change History";
            Load+=Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox darkTextBox1;
    }
}