
namespace Shopee_Autobuy_Bot
{
    partial class BotSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BotSettings));
            this.darkCheckBoxTestMode = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxLogging = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxRefresh = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxHeadless = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkNumericUpDownTimeOut = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBoxPlaySound = new DarkUI.Controls.DarkCheckBox();
            this.darkNumericUpDownRefreshSeconds = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel13 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBoxDisableImageExtension = new DarkUI.Controls.DarkCheckBox();
            this.darkButton5 = new DarkUI.Controls.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownRefreshSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // darkCheckBoxTestMode
            // 
            this.darkCheckBoxTestMode.AutoSize = true;
            this.darkCheckBoxTestMode.Location = new System.Drawing.Point(16, 161);
            this.darkCheckBoxTestMode.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxTestMode.Name = "darkCheckBoxTestMode";
            this.darkCheckBoxTestMode.Size = new System.Drawing.Size(79, 17);
            this.darkCheckBoxTestMode.TabIndex = 49;
            this.darkCheckBoxTestMode.Text = "Test Mode";
            // 
            // darkCheckBoxLogging
            // 
            this.darkCheckBoxLogging.AutoSize = true;
            this.darkCheckBoxLogging.Location = new System.Drawing.Point(16, 131);
            this.darkCheckBoxLogging.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxLogging.Name = "darkCheckBoxLogging";
            this.darkCheckBoxLogging.Size = new System.Drawing.Size(108, 17);
            this.darkCheckBoxLogging.TabIndex = 50;
            this.darkCheckBoxLogging.Text = "Disable logging";
            // 
            // darkCheckBoxRefresh
            // 
            this.darkCheckBoxRefresh.AutoSize = true;
            this.darkCheckBoxRefresh.Location = new System.Drawing.Point(16, 102);
            this.darkCheckBoxRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxRefresh.Name = "darkCheckBoxRefresh";
            this.darkCheckBoxRefresh.Size = new System.Drawing.Size(141, 17);
            this.darkCheckBoxRefresh.TabIndex = 48;
            this.darkCheckBoxRefresh.Text = "Auto refresh webpage";
            // 
            // darkCheckBoxHeadless
            // 
            this.darkCheckBoxHeadless.AutoSize = true;
            this.darkCheckBoxHeadless.Location = new System.Drawing.Point(16, 44);
            this.darkCheckBoxHeadless.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxHeadless.Name = "darkCheckBoxHeadless";
            this.darkCheckBoxHeadless.Size = new System.Drawing.Size(137, 17);
            this.darkCheckBoxHeadless.TabIndex = 47;
            this.darkCheckBoxHeadless.Text = "Hide Chrome Browser";
            this.darkCheckBoxHeadless.Click += new System.EventHandler(this.darkCheckBoxHeadless_Click);
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(284, 104);
            this.darkLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(49, 13);
            this.darkLabel5.TabIndex = 11;
            this.darkLabel5.Text = "seconds";
            // 
            // darkNumericUpDownTimeOut
            // 
            this.darkNumericUpDownTimeOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDownTimeOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkNumericUpDownTimeOut.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.darkNumericUpDownTimeOut.Location = new System.Drawing.Point(130, 184);
            this.darkNumericUpDownTimeOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkNumericUpDownTimeOut.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.darkNumericUpDownTimeOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.darkNumericUpDownTimeOut.MousewheelSingleIncrement = true;
            this.darkNumericUpDownTimeOut.Name = "darkNumericUpDownTimeOut";
            this.darkNumericUpDownTimeOut.Size = new System.Drawing.Size(38, 22);
            this.darkNumericUpDownTimeOut.TabIndex = 46;
            this.darkNumericUpDownTimeOut.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(168, 104);
            this.darkLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(75, 13);
            this.darkLabel4.TabIndex = 10;
            this.darkLabel4.Text = "Refresh every";
            // 
            // darkCheckBoxPlaySound
            // 
            this.darkCheckBoxPlaySound.AutoSize = true;
            this.darkCheckBoxPlaySound.Location = new System.Drawing.Point(16, 15);
            this.darkCheckBoxPlaySound.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxPlaySound.Name = "darkCheckBoxPlaySound";
            this.darkCheckBoxPlaySound.Size = new System.Drawing.Size(204, 17);
            this.darkCheckBoxPlaySound.TabIndex = 28;
            this.darkCheckBoxPlaySound.Text = "Play sound on successful checkout";
            // 
            // darkNumericUpDownRefreshSeconds
            // 
            this.darkNumericUpDownRefreshSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDownRefreshSeconds.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkNumericUpDownRefreshSeconds.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.darkNumericUpDownRefreshSeconds.Location = new System.Drawing.Point(245, 99);
            this.darkNumericUpDownRefreshSeconds.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkNumericUpDownRefreshSeconds.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.darkNumericUpDownRefreshSeconds.MousewheelSingleIncrement = true;
            this.darkNumericUpDownRefreshSeconds.Name = "darkNumericUpDownRefreshSeconds";
            this.darkNumericUpDownRefreshSeconds.Size = new System.Drawing.Size(38, 22);
            this.darkNumericUpDownRefreshSeconds.TabIndex = 9;
            this.darkNumericUpDownRefreshSeconds.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // darkLabel13
            // 
            this.darkLabel13.AutoSize = true;
            this.darkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel13.Location = new System.Drawing.Point(12, 189);
            this.darkLabel13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel13.Name = "darkLabel13";
            this.darkLabel13.Size = new System.Drawing.Size(104, 13);
            this.darkLabel13.TabIndex = 45;
            this.darkLabel13.Text = "Time out (second) :";
            // 
            // darkCheckBoxDisableImageExtension
            // 
            this.darkCheckBoxDisableImageExtension.AutoSize = true;
            this.darkCheckBoxDisableImageExtension.Location = new System.Drawing.Point(16, 73);
            this.darkCheckBoxDisableImageExtension.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxDisableImageExtension.Name = "darkCheckBoxDisableImageExtension";
            this.darkCheckBoxDisableImageExtension.Size = new System.Drawing.Size(197, 17);
            this.darkCheckBoxDisableImageExtension.TabIndex = 25;
            this.darkCheckBoxDisableImageExtension.Text = "Disable website Image & Extension";
            this.darkCheckBoxDisableImageExtension.Click += new System.EventHandler(this.darkCheckBoxDisableImageExtension_Click);
            // 
            // darkButton5
            // 
            this.darkButton5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButton5.Location = new System.Drawing.Point(128, 221);
            this.darkButton5.Margin = new System.Windows.Forms.Padding(2);
            this.darkButton5.Name = "darkButton5";
            this.darkButton5.Size = new System.Drawing.Size(89, 23);
            this.darkButton5.TabIndex = 51;
            this.darkButton5.Text = "Save & Close";
            this.darkButton5.Visible = false;
            this.darkButton5.Click += new System.EventHandler(this.darkButton5_Click);
            // 
            // BotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 258);
            this.Controls.Add(this.darkButton5);
            this.Controls.Add(this.darkCheckBoxTestMode);
            this.Controls.Add(this.darkCheckBoxLogging);
            this.Controls.Add(this.darkCheckBoxPlaySound);
            this.Controls.Add(this.darkCheckBoxDisableImageExtension);
            this.Controls.Add(this.darkCheckBoxRefresh);
            this.Controls.Add(this.darkLabel13);
            this.Controls.Add(this.darkCheckBoxHeadless);
            this.Controls.Add(this.darkNumericUpDownRefreshSeconds);
            this.Controls.Add(this.darkLabel5);
            this.Controls.Add(this.darkLabel4);
            this.Controls.Add(this.darkNumericUpDownTimeOut);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BotSettings";
            this.Text = "Bot Settings";
            this.Load += new System.EventHandler(this.BotSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownRefreshSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkCheckBox darkCheckBoxTestMode;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxLogging;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRefresh;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxHeadless;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownTimeOut;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxPlaySound;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownRefreshSeconds;
        private DarkUI.Controls.DarkLabel darkLabel13;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxDisableImageExtension;
        private DarkUI.Controls.DarkButton darkButton5;
    }
}