namespace Shopee_Autobuy_Bot
{
    partial class Warning
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
            this.label1 = new System.Windows.Forms.Label();
            this.darkButton5 = new DarkUI.Controls.DarkButton();
            this.darkCheckBoxTomorrow = new DarkUI.Controls.DarkCheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "\'Cart checkout\' and \'Below specific price (Cart checkout) (BETA)\' \r\ndoes not work" +
    " with Flash/Shocking sale and not tested yet on \r\npayday sale so use these mode " +
    "on your own risk!\r\n";
            // 
            // darkButton5
            // 
            this.darkButton5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButton5.Location = new System.Drawing.Point(283, 80);
            this.darkButton5.Margin = new System.Windows.Forms.Padding(2);
            this.darkButton5.Name = "darkButton5";
            this.darkButton5.Size = new System.Drawing.Size(76, 23);
            this.darkButton5.TabIndex = 50;
            this.darkButton5.Text = "Ok";
            this.darkButton5.Click += new System.EventHandler(this.darkButton5_Click);
            // 
            // darkCheckBoxTomorrow
            // 
            this.darkCheckBoxTomorrow.AutoSize = true;
            this.darkCheckBoxTomorrow.Checked = true;
            this.darkCheckBoxTomorrow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.darkCheckBoxTomorrow.Location = new System.Drawing.Point(14, 84);
            this.darkCheckBoxTomorrow.Name = "darkCheckBoxTomorrow";
            this.darkCheckBoxTomorrow.Size = new System.Drawing.Size(140, 19);
            this.darkCheckBoxTomorrow.TabIndex = 51;
            this.darkCheckBoxTomorrow.Text = "Don\'t show this again";
            this.darkCheckBoxTomorrow.CheckedChanged += new System.EventHandler(this.darkCheckBoxTomorrow_CheckedChanged);
            // 
            // Warning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 114);
            this.Controls.Add(this.darkCheckBoxTomorrow);
            this.Controls.Add(this.darkButton5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Warning";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Warning!";
            this.Load += new System.EventHandler(this.Warning_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DarkUI.Controls.DarkButton darkButton5;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxTomorrow;
    }
}