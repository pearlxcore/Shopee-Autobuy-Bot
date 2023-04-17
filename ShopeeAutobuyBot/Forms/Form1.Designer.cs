using System;
using System.Diagnostics;
using System.Drawing;


namespace Shopee_Autobuy_Bot
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.darkSectionPanelTimerMode = new DarkUI.Controls.DarkSectionPanel();
            this.darkCheckBoxTomorrow = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxScheduleBot = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkNumericUpDownCountDownSecond = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkNumericUpDownCountdownMinutes = new DarkUI.Controls.DarkNumericUpDown();
            this.darkNumericUpDownCountdownHour = new DarkUI.Controls.DarkNumericUpDown();
            this.darkNumericUpDownTimeOut = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel13 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBoxPlaySound = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxDisableImageExtension = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkNumericUpDownRefreshSeconds = new DarkUI.Controls.DarkNumericUpDown();
            this.darkComboBoxPaymentMethod = new DarkUI.Controls.DarkComboBox();
            this.darkTextBoxShopeePayPin = new DarkUI.Controls.DarkTextBox();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.darkComboBoxCourier = new DarkUI.Controls.DarkComboBox();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.darkTextBoxVariationString = new DarkUI.Controls.DarkTextBox();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.darkNumericUpDownProductQuantity = new DarkUI.Controls.DarkNumericUpDown();
            this.darkSectionPanelProductDetails = new DarkUI.Controls.DarkSectionPanel();
            this.cbRandom = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel11 = new DarkUI.Controls.DarkLabel();
            this.darkTextBoxProductLink = new DarkUI.Controls.DarkTextBox();
            this.darkCheckBoxClaimShopVoucher = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxTestMode = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel14 = new DarkUI.Controls.DarkLabel();
            this.tbLast4Digit = new DarkUI.Controls.DarkTextBox();
            this.darkCheckBoxRedeemCoin = new DarkUI.Controls.DarkCheckBox();
            this.darkComboBoxBankType = new DarkUI.Controls.DarkComboBox();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.darkLabel12 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanelLogs = new DarkUI.Controls.DarkSectionPanel();
            this.darkButtonDeleteAllOrder = new DarkUI.Controls.DarkButton();
            this.richTextBoxLogs = new System.Windows.Forms.RichTextBox();
            this.darkButton1 = new DarkUI.Controls.DarkButton();
            this.darkButton4 = new DarkUI.Controls.DarkButton();
            this.darkButton3 = new DarkUI.Controls.DarkButton();
            this.darkButton2 = new DarkUI.Controls.DarkButton();
            this.darkButton6 = new DarkUI.Controls.DarkButton();
            this.tbBelowSpecificPriceCARTCHECKOUTPrice = new DarkUI.Controls.DarkTextBox();
            this.radioButtonPriceSpecificCARTCHECKOUT = new System.Windows.Forms.RadioButton();
            this.darkButtonStart = new DarkUI.Controls.DarkButton();
            this.timerlabel1 = new System.Windows.Forms.Label();
            this.darkSectionPanelBotSettings = new DarkUI.Controls.DarkSectionPanel();
            this.darkCheckBoxLogging = new DarkUI.Controls.DarkCheckBox();
            this.darkButton5 = new DarkUI.Controls.DarkButton();
            this.darkCheckBoxRefresh = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxHeadless = new DarkUI.Controls.DarkCheckBox();
            this.darkDockPanel1 = new DarkUI.Docking.DarkDockPanel();
            this.darkMenuStrip1 = new DarkUI.Controls.DarkMenuStrip();
            this.gfrgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanSaleItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProfileSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setNewFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateConfigurationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paydaySaleTipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCookiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpgradeProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkSectionPanelBuyingMode = new DarkUI.Controls.DarkSectionPanel();
            this.tbPriceSpecific = new DarkUI.Controls.DarkTextBox();
            this.radioButtonCheckOutCart = new System.Windows.Forms.RadioButton();
            this.radioButtonShockingSale = new System.Windows.Forms.RadioButton();
            this.radioButtonBuyNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonPriceSpecific = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.darkSectionPanelPaymentDetails = new DarkUI.Controls.DarkSectionPanel();
            this.darkCheckBoxRedeemShopeeVoucher = new DarkUI.Controls.DarkCheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.darkButton7 = new DarkUI.Controls.DarkButton();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.darkLabel15 = new DarkUI.Controls.DarkLabel();
            this.labelShopeeAcc = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanelTimerMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownCountDownSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownCountdownMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownCountdownHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownRefreshSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownProductQuantity)).BeginInit();
            this.darkSectionPanelProductDetails.SuspendLayout();
            this.darkSectionPanelLogs.SuspendLayout();
            this.darkSectionPanelBotSettings.SuspendLayout();
            this.darkMenuStrip1.SuspendLayout();
            this.darkSectionPanelBuyingMode.SuspendLayout();
            this.darkSectionPanelPaymentDetails.SuspendLayout();
            this.darkSectionPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // darkSectionPanelTimerMode
            // 
            this.darkSectionPanelTimerMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelTimerMode.Controls.Add(this.darkCheckBoxTomorrow);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkCheckBoxScheduleBot);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkLabel3);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkNumericUpDownCountDownSecond);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkLabel2);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkLabel1);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkNumericUpDownCountdownMinutes);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkNumericUpDownCountdownHour);
            this.darkSectionPanelTimerMode.Location = new System.Drawing.Point(384, 43);
            this.darkSectionPanelTimerMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelTimerMode.Name = "darkSectionPanelTimerMode";
            this.darkSectionPanelTimerMode.SectionHeader = "Schedule Bot";
            this.darkSectionPanelTimerMode.Size = new System.Drawing.Size(376, 121);
            this.darkSectionPanelTimerMode.TabIndex = 0;
            // 
            // darkCheckBoxTomorrow
            // 
            this.darkCheckBoxTomorrow.AutoSize = true;
            this.darkCheckBoxTomorrow.Enabled = false;
            this.darkCheckBoxTomorrow.Location = new System.Drawing.Point(38, 89);
            this.darkCheckBoxTomorrow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxTomorrow.Name = "darkCheckBoxTomorrow";
            this.darkCheckBoxTomorrow.Size = new System.Drawing.Size(78, 17);
            this.darkCheckBoxTomorrow.TabIndex = 16;
            this.darkCheckBoxTomorrow.Text = "Tomorrow";
            this.toolTip1.SetToolTip(this.darkCheckBoxTomorrow, "Enable this if the time set is for tomorrow.");
            // 
            // darkCheckBoxScheduleBot
            // 
            this.darkCheckBoxScheduleBot.AutoSize = true;
            this.darkCheckBoxScheduleBot.Location = new System.Drawing.Point(38, 38);
            this.darkCheckBoxScheduleBot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxScheduleBot.Name = "darkCheckBoxScheduleBot";
            this.darkCheckBoxScheduleBot.Size = new System.Drawing.Size(300, 17);
            this.darkCheckBoxScheduleBot.TabIndex = 15;
            this.darkCheckBoxScheduleBot.Text = "Schedule bot to run at specific time (24-hours format)";
            this.toolTip1.SetToolTip(this.darkCheckBoxScheduleBot, "Enabling this will let the bot to run at specific time set by user in 24 hour for" +
        "mat.");
            this.darkCheckBoxScheduleBot.CheckedChanged += new System.EventHandler(this.darkCheckBoxCountDownMode_CheckedChanged);
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.Enabled = false;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(210, 65);
            this.darkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(50, 13);
            this.darkLabel3.TabIndex = 14;
            this.darkLabel3.Text = "Seconds";
            // 
            // darkNumericUpDownCountDownSecond
            // 
            this.darkNumericUpDownCountDownSecond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDownCountDownSecond.Enabled = false;
            this.darkNumericUpDownCountDownSecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkNumericUpDownCountDownSecond.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.darkNumericUpDownCountDownSecond.Location = new System.Drawing.Point(263, 61);
            this.darkNumericUpDownCountDownSecond.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkNumericUpDownCountDownSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.darkNumericUpDownCountDownSecond.MousewheelSingleIncrement = true;
            this.darkNumericUpDownCountDownSecond.Name = "darkNumericUpDownCountDownSecond";
            this.darkNumericUpDownCountDownSecond.Size = new System.Drawing.Size(38, 22);
            this.darkNumericUpDownCountDownSecond.TabIndex = 13;
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Enabled = false;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(115, 65);
            this.darkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(49, 13);
            this.darkLabel2.TabIndex = 5;
            this.darkLabel2.Text = "Minutes";
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.Enabled = false;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(36, 65);
            this.darkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(33, 13);
            this.darkLabel1.TabIndex = 4;
            this.darkLabel1.Text = "Hour";
            // 
            // darkNumericUpDownCountdownMinutes
            // 
            this.darkNumericUpDownCountdownMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDownCountdownMinutes.Enabled = false;
            this.darkNumericUpDownCountdownMinutes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkNumericUpDownCountdownMinutes.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.darkNumericUpDownCountdownMinutes.Location = new System.Drawing.Point(168, 61);
            this.darkNumericUpDownCountdownMinutes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkNumericUpDownCountdownMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.darkNumericUpDownCountdownMinutes.MousewheelSingleIncrement = true;
            this.darkNumericUpDownCountdownMinutes.Name = "darkNumericUpDownCountdownMinutes";
            this.darkNumericUpDownCountdownMinutes.Size = new System.Drawing.Size(38, 22);
            this.darkNumericUpDownCountdownMinutes.TabIndex = 3;
            // 
            // darkNumericUpDownCountdownHour
            // 
            this.darkNumericUpDownCountdownHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDownCountdownHour.Enabled = false;
            this.darkNumericUpDownCountdownHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkNumericUpDownCountdownHour.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.darkNumericUpDownCountdownHour.Location = new System.Drawing.Point(73, 61);
            this.darkNumericUpDownCountdownHour.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkNumericUpDownCountdownHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.darkNumericUpDownCountdownHour.MousewheelSingleIncrement = true;
            this.darkNumericUpDownCountdownHour.Name = "darkNumericUpDownCountdownHour";
            this.darkNumericUpDownCountdownHour.Size = new System.Drawing.Size(38, 22);
            this.darkNumericUpDownCountdownHour.TabIndex = 2;
            this.darkNumericUpDownCountdownHour.ValueChanged += new System.EventHandler(this.darkNumericUpDownCountdownHour_ValueChanged);
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
            this.darkNumericUpDownTimeOut.Location = new System.Drawing.Point(138, 218);
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
            this.darkNumericUpDownTimeOut.ValueChanged += new System.EventHandler(this.darkNumericUpDownTimeOut_ValueChanged);
            // 
            // darkLabel13
            // 
            this.darkLabel13.AutoSize = true;
            this.darkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel13.Location = new System.Drawing.Point(20, 223);
            this.darkLabel13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel13.Name = "darkLabel13";
            this.darkLabel13.Size = new System.Drawing.Size(104, 13);
            this.darkLabel13.TabIndex = 45;
            this.darkLabel13.Text = "Time out (second) :";
            this.toolTip1.SetToolTip(this.darkLabel13, "Timeout in second when bot does not receive response from the webpage element.");
            // 
            // darkCheckBoxPlaySound
            // 
            this.darkCheckBoxPlaySound.AutoSize = true;
            this.darkCheckBoxPlaySound.Location = new System.Drawing.Point(24, 37);
            this.darkCheckBoxPlaySound.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxPlaySound.Name = "darkCheckBoxPlaySound";
            this.darkCheckBoxPlaySound.Size = new System.Drawing.Size(204, 17);
            this.darkCheckBoxPlaySound.TabIndex = 28;
            this.darkCheckBoxPlaySound.Text = "Play sound on successful checkout";
            this.toolTip1.SetToolTip(this.darkCheckBoxPlaySound, "Enabling this option will play a sound on successful checkout.");
            // 
            // darkCheckBoxDisableImageExtension
            // 
            this.darkCheckBoxDisableImageExtension.AutoSize = true;
            this.darkCheckBoxDisableImageExtension.Enabled = false;
            this.darkCheckBoxDisableImageExtension.Location = new System.Drawing.Point(24, 99);
            this.darkCheckBoxDisableImageExtension.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxDisableImageExtension.Name = "darkCheckBoxDisableImageExtension";
            this.darkCheckBoxDisableImageExtension.Size = new System.Drawing.Size(197, 17);
            this.darkCheckBoxDisableImageExtension.TabIndex = 25;
            this.darkCheckBoxDisableImageExtension.Text = "Disable website Image & Extension";
            this.toolTip1.SetToolTip(this.darkCheckBoxDisableImageExtension, "Enabling this option will disable images in webpage and browser extension on the " +
        "next restart. It may help improve the checkout time.");
            this.darkCheckBoxDisableImageExtension.Click += new System.EventHandler(this.darkCheckBoxDisableImageExtension_Click);
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(292, 132);
            this.darkLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(49, 13);
            this.darkLabel5.TabIndex = 11;
            this.darkLabel5.Text = "seconds";
            // 
            // darkLabel4
            // 
            this.darkLabel4.AutoSize = true;
            this.darkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel4.Location = new System.Drawing.Point(176, 132);
            this.darkLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel4.Name = "darkLabel4";
            this.darkLabel4.Size = new System.Drawing.Size(75, 13);
            this.darkLabel4.TabIndex = 10;
            this.darkLabel4.Text = "Refresh every";
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
            this.darkNumericUpDownRefreshSeconds.Location = new System.Drawing.Point(253, 127);
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
            // darkComboBoxPaymentMethod
            // 
            this.darkComboBoxPaymentMethod.FormattingEnabled = true;
            this.darkComboBoxPaymentMethod.Items.AddRange(new object[] {
            "Default",
            "Credit / Debit Card",
            "ATM / Cash Deposit",
            "Online Banking",
            "ShopeePay",
            "Cash on Delivery",
            "7-Eleven",
            "KK Mart"});
            this.darkComboBoxPaymentMethod.Location = new System.Drawing.Point(154, 33);
            this.darkComboBoxPaymentMethod.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkComboBoxPaymentMethod.Name = "darkComboBoxPaymentMethod";
            this.darkComboBoxPaymentMethod.Size = new System.Drawing.Size(194, 23);
            this.darkComboBoxPaymentMethod.TabIndex = 12;
            this.toolTip1.SetToolTip(this.darkComboBoxPaymentMethod, "Payment method.");
            this.darkComboBoxPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.darkComboBoxPaymentMethod_SelectedIndexChanged);
            // 
            // darkTextBoxShopeePayPin
            // 
            this.darkTextBoxShopeePayPin.Location = new System.Drawing.Point(223, 131);
            this.darkTextBoxShopeePayPin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkTextBoxShopeePayPin.MaxLength = 6;
            this.darkTextBoxShopeePayPin.Name = "darkTextBoxShopeePayPin";
            this.darkTextBoxShopeePayPin.Size = new System.Drawing.Size(124, 22);
            this.darkTextBoxShopeePayPin.TabIndex = 13;
            this.darkTextBoxShopeePayPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.darkTextBoxShopeePayPin, "ShopeePay PIN.");
            this.darkTextBoxShopeePayPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.darkTextBoxWalletPin_KeyPress);
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(17, 38);
            this.darkLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(100, 13);
            this.darkLabel6.TabIndex = 14;
            this.darkLabel6.Text = "Payment Method :";
            // 
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(17, 137);
            this.darkLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(89, 13);
            this.darkLabel7.TabIndex = 15;
            this.darkLabel7.Text = "ShopeePay PIN :";
            // 
            // darkComboBoxCourier
            // 
            this.darkComboBoxCourier.FormattingEnabled = true;
            this.darkComboBoxCourier.Items.AddRange(new object[] {
            "Default"});
            this.darkComboBoxCourier.Location = new System.Drawing.Point(149, 35);
            this.darkComboBoxCourier.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkComboBoxCourier.Name = "darkComboBoxCourier";
            this.darkComboBoxCourier.Size = new System.Drawing.Size(126, 23);
            this.darkComboBoxCourier.TabIndex = 16;
            // 
            // darkLabel9
            // 
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(17, 134);
            this.darkLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(59, 13);
            this.darkLabel9.TabIndex = 19;
            this.darkLabel9.Text = "Variation :";
            // 
            // darkTextBoxVariationString
            // 
            this.darkTextBoxVariationString.Location = new System.Drawing.Point(98, 129);
            this.darkTextBoxVariationString.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkTextBoxVariationString.Name = "darkTextBoxVariationString";
            this.darkTextBoxVariationString.Size = new System.Drawing.Size(171, 22);
            this.darkTextBoxVariationString.TabIndex = 18;
            this.darkTextBoxVariationString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.darkTextBoxVariationString, "Product variant (if required). If the product have more than 1 variant (eg : Colo" +
        "ur and Size), separate the variant with \'|\' character without space. For example" +
        " : RED|XXL");
            // 
            // darkLabel10
            // 
            this.darkLabel10.AutoSize = true;
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(17, 164);
            this.darkLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(57, 13);
            this.darkLabel10.TabIndex = 21;
            this.darkLabel10.Text = "Quantity :";
            // 
            // darkNumericUpDownProductQuantity
            // 
            this.darkNumericUpDownProductQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDownProductQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkNumericUpDownProductQuantity.IncrementAlternate = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.darkNumericUpDownProductQuantity.Location = new System.Drawing.Point(98, 159);
            this.darkNumericUpDownProductQuantity.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkNumericUpDownProductQuantity.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.darkNumericUpDownProductQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.darkNumericUpDownProductQuantity.MousewheelSingleIncrement = true;
            this.darkNumericUpDownProductQuantity.Name = "darkNumericUpDownProductQuantity";
            this.darkNumericUpDownProductQuantity.ReadOnly = true;
            this.darkNumericUpDownProductQuantity.Size = new System.Drawing.Size(47, 22);
            this.darkNumericUpDownProductQuantity.TabIndex = 20;
            this.toolTip1.SetToolTip(this.darkNumericUpDownProductQuantity, "Product quantity.");
            this.darkNumericUpDownProductQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // darkSectionPanelProductDetails
            // 
            this.darkSectionPanelProductDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelProductDetails.Controls.Add(this.cbRandom);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkLabel11);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkTextBoxProductLink);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkLabel10);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkTextBoxVariationString);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkNumericUpDownProductQuantity);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkLabel9);
            this.darkSectionPanelProductDetails.Location = new System.Drawing.Point(14, 301);
            this.darkSectionPanelProductDetails.Margin = new System.Windows.Forms.Padding(2);
            this.darkSectionPanelProductDetails.Name = "darkSectionPanelProductDetails";
            this.darkSectionPanelProductDetails.SectionHeader = "Product Details";
            this.darkSectionPanelProductDetails.Size = new System.Drawing.Size(364, 195);
            this.darkSectionPanelProductDetails.TabIndex = 23;
            // 
            // cbRandom
            // 
            this.cbRandom.AutoSize = true;
            this.cbRandom.Location = new System.Drawing.Point(278, 132);
            this.cbRandom.Margin = new System.Windows.Forms.Padding(2);
            this.cbRandom.Name = "cbRandom";
            this.cbRandom.Size = new System.Drawing.Size(69, 17);
            this.cbRandom.TabIndex = 51;
            this.cbRandom.Text = "Random";
            this.toolTip1.SetToolTip(this.cbRandom, "Enabling this option will stop the autobuy process right before placing order. Us" +
        "er may use this option to \'warm up\' the bot.");
            this.cbRandom.CheckedChanged += new System.EventHandler(this.cbRandom_CheckedChanged);
            // 
            // darkLabel11
            // 
            this.darkLabel11.AutoSize = true;
            this.darkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel11.Location = new System.Drawing.Point(17, 37);
            this.darkLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel11.Name = "darkLabel11";
            this.darkLabel11.Size = new System.Drawing.Size(77, 13);
            this.darkLabel11.TabIndex = 24;
            this.darkLabel11.Text = "Product Link :";
            // 
            // darkTextBoxProductLink
            // 
            this.darkTextBoxProductLink.Location = new System.Drawing.Point(98, 37);
            this.darkTextBoxProductLink.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkTextBoxProductLink.Multiline = true;
            this.darkTextBoxProductLink.Name = "darkTextBoxProductLink";
            this.darkTextBoxProductLink.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.darkTextBoxProductLink.Size = new System.Drawing.Size(244, 84);
            this.darkTextBoxProductLink.TabIndex = 23;
            this.toolTip1.SetToolTip(this.darkTextBoxProductLink, "Product link.");
            // 
            // darkCheckBoxClaimShopVoucher
            // 
            this.darkCheckBoxClaimShopVoucher.AutoSize = true;
            this.darkCheckBoxClaimShopVoucher.Location = new System.Drawing.Point(11, 44);
            this.darkCheckBoxClaimShopVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxClaimShopVoucher.Name = "darkCheckBoxClaimShopVoucher";
            this.darkCheckBoxClaimShopVoucher.Size = new System.Drawing.Size(148, 17);
            this.darkCheckBoxClaimShopVoucher.TabIndex = 50;
            this.darkCheckBoxClaimShopVoucher.Text = "Claim any shop voucher";
            this.toolTip1.SetToolTip(this.darkCheckBoxClaimShopVoucher, "Enabling this will let bot claim any available shop voucher.");
            // 
            // darkCheckBoxTestMode
            // 
            this.darkCheckBoxTestMode.AutoSize = true;
            this.darkCheckBoxTestMode.Location = new System.Drawing.Point(24, 192);
            this.darkCheckBoxTestMode.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxTestMode.Name = "darkCheckBoxTestMode";
            this.darkCheckBoxTestMode.Size = new System.Drawing.Size(79, 17);
            this.darkCheckBoxTestMode.TabIndex = 49;
            this.darkCheckBoxTestMode.Text = "Test Mode";
            this.toolTip1.SetToolTip(this.darkCheckBoxTestMode, "Enabling this option will stop the autobuy process right before placing order. Us" +
        "er may use this option to \'warm up\' the bot.");
            // 
            // darkLabel14
            // 
            this.darkLabel14.AutoSize = true;
            this.darkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel14.Location = new System.Drawing.Point(17, 104);
            this.darkLabel14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel14.Name = "darkLabel14";
            this.darkLabel14.Size = new System.Drawing.Size(171, 13);
            this.darkLabel14.TabIndex = 51;
            this.darkLabel14.Text = "Last 4 digit of debit/credit card :";
            // 
            // tbLast4Digit
            // 
            this.tbLast4Digit.Location = new System.Drawing.Point(223, 99);
            this.tbLast4Digit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbLast4Digit.MaxLength = 4;
            this.tbLast4Digit.Name = "tbLast4Digit";
            this.tbLast4Digit.Size = new System.Drawing.Size(124, 22);
            this.tbLast4Digit.TabIndex = 50;
            this.tbLast4Digit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbLast4Digit, "Last 4 digit of debit/credit card to be used.");
            this.tbLast4Digit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLast4Digit_KeyPress);
            // 
            // darkCheckBoxRedeemCoin
            // 
            this.darkCheckBoxRedeemCoin.AutoSize = true;
            this.darkCheckBoxRedeemCoin.Location = new System.Drawing.Point(11, 110);
            this.darkCheckBoxRedeemCoin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxRedeemCoin.Name = "darkCheckBoxRedeemCoin";
            this.darkCheckBoxRedeemCoin.Size = new System.Drawing.Size(92, 17);
            this.darkCheckBoxRedeemCoin.TabIndex = 42;
            this.darkCheckBoxRedeemCoin.Text = "Redeem coin";
            this.toolTip1.SetToolTip(this.darkCheckBoxRedeemCoin, "Enabling this let the bot redeem any available coin.");
            // 
            // darkComboBoxBankType
            // 
            this.darkComboBoxBankType.FormattingEnabled = true;
            this.darkComboBoxBankType.Items.AddRange(new object[] {
            "Maybank2u",
            "CIMB Clicks",
            "Public Bank",
            "RHB Now",
            "Ambank",
            "MyBSN",
            "Bank Rakyat",
            "UOB",
            "Affin Bank",
            "Bank Islam",
            "HSBC Online",
            "Standard Chartered Bank",
            "Kuwait Finance House",
            "Bank Muamalat",
            "OCBC Online",
            "Alliance Bank (Personal)",
            "Hong Leong Connect"});
            this.darkComboBoxBankType.Location = new System.Drawing.Point(154, 66);
            this.darkComboBoxBankType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkComboBoxBankType.Name = "darkComboBoxBankType";
            this.darkComboBoxBankType.Size = new System.Drawing.Size(194, 23);
            this.darkComboBoxBankType.TabIndex = 30;
            this.toolTip1.SetToolTip(this.darkComboBoxBankType, "Bank type.");
            // 
            // darkLabel8
            // 
            this.darkLabel8.AutoSize = true;
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(17, 72);
            this.darkLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(63, 13);
            this.darkLabel8.TabIndex = 31;
            this.darkLabel8.Text = "Bank type :";
            // 
            // darkLabel12
            // 
            this.darkLabel12.AutoSize = true;
            this.darkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel12.Location = new System.Drawing.Point(49, 40);
            this.darkLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel12.Name = "darkLabel12";
            this.darkLabel12.Size = new System.Drawing.Size(51, 13);
            this.darkLabel12.TabIndex = 28;
            this.darkLabel12.Text = "Courier :";
            // 
            // darkSectionPanelLogs
            // 
            this.darkSectionPanelLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelLogs.Controls.Add(this.darkButtonDeleteAllOrder);
            this.darkSectionPanelLogs.Controls.Add(this.richTextBoxLogs);
            this.darkSectionPanelLogs.Controls.Add(this.darkLabel12);
            this.darkSectionPanelLogs.Controls.Add(this.darkButton1);
            this.darkSectionPanelLogs.Controls.Add(this.darkButton4);
            this.darkSectionPanelLogs.Controls.Add(this.darkButton3);
            this.darkSectionPanelLogs.Controls.Add(this.darkComboBoxCourier);
            this.darkSectionPanelLogs.Controls.Add(this.darkButton2);
            this.darkSectionPanelLogs.Controls.Add(this.darkButton6);
            this.darkSectionPanelLogs.Location = new System.Drawing.Point(14, 501);
            this.darkSectionPanelLogs.Margin = new System.Windows.Forms.Padding(2);
            this.darkSectionPanelLogs.Name = "darkSectionPanelLogs";
            this.darkSectionPanelLogs.SectionHeader = "Logs";
            this.darkSectionPanelLogs.Size = new System.Drawing.Size(312, 151);
            this.darkSectionPanelLogs.TabIndex = 24;
            // 
            // darkButtonDeleteAllOrder
            // 
            this.darkButtonDeleteAllOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButtonDeleteAllOrder.Location = new System.Drawing.Point(39, 85);
            this.darkButtonDeleteAllOrder.Margin = new System.Windows.Forms.Padding(2);
            this.darkButtonDeleteAllOrder.Name = "darkButtonDeleteAllOrder";
            this.darkButtonDeleteAllOrder.Size = new System.Drawing.Size(236, 42);
            this.darkButtonDeleteAllOrder.TabIndex = 28;
            this.darkButtonDeleteAllOrder.Text = "Delete all order (To pay)";
            this.darkButtonDeleteAllOrder.Visible = false;
            this.darkButtonDeleteAllOrder.Click += new System.EventHandler(this.darkButton5_Click);
            // 
            // richTextBoxLogs
            // 
            this.richTextBoxLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.richTextBoxLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogs.Location = new System.Drawing.Point(1, 25);
            this.richTextBoxLogs.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBoxLogs.Name = "richTextBoxLogs";
            this.richTextBoxLogs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxLogs.Size = new System.Drawing.Size(308, 123);
            this.richTextBoxLogs.TabIndex = 0;
            this.richTextBoxLogs.Text = "";
            this.toolTip1.SetToolTip(this.richTextBoxLogs, "Current running process will be displayed here.");
            this.richTextBoxLogs.TextChanged += new System.EventHandler(this.richTextBoxLogs_TextChanged);
            // 
            // darkButton1
            // 
            this.darkButton1.Location = new System.Drawing.Point(170, 259);
            this.darkButton1.Margin = new System.Windows.Forms.Padding(2);
            this.darkButton1.Name = "darkButton1";
            this.darkButton1.Size = new System.Drawing.Size(104, 15);
            this.darkButton1.TabIndex = 28;
            this.darkButton1.Text = "Cancel All Order";
            this.darkButton1.Visible = false;
            this.darkButton1.Click += new System.EventHandler(this.darkButton1_Click);
            // 
            // darkButton4
            // 
            this.darkButton4.Location = new System.Drawing.Point(50, 57);
            this.darkButton4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkButton4.Name = "darkButton4";
            this.darkButton4.Size = new System.Drawing.Size(94, 23);
            this.darkButton4.TabIndex = 29;
            this.darkButton4.Text = "deliver anytime";
            this.darkButton4.Click += new System.EventHandler(this.darkButton4_Click);
            // 
            // darkButton3
            // 
            this.darkButton3.Location = new System.Drawing.Point(292, 122);
            this.darkButton3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkButton3.Name = "darkButton3";
            this.darkButton3.Size = new System.Drawing.Size(94, 23);
            this.darkButton3.TabIndex = 28;
            this.darkButton3.Text = "select poslaju";
            this.darkButton3.Click += new System.EventHandler(this.darkButton3_Click);
            // 
            // darkButton2
            // 
            this.darkButton2.Location = new System.Drawing.Point(272, 61);
            this.darkButton2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkButton2.Name = "darkButton2";
            this.darkButton2.Size = new System.Drawing.Size(94, 23);
            this.darkButton2.TabIndex = 12;
            this.darkButton2.Text = "change courier";
            this.darkButton2.Click += new System.EventHandler(this.darkButton2_Click);
            // 
            // darkButton6
            // 
            this.darkButton6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButton6.Location = new System.Drawing.Point(205, 35);
            this.darkButton6.Margin = new System.Windows.Forms.Padding(2);
            this.darkButton6.Name = "darkButton6";
            this.darkButton6.Size = new System.Drawing.Size(101, 51);
            this.darkButton6.TabIndex = 56;
            this.darkButton6.Text = "Order Price";
            this.darkButton6.Click += new System.EventHandler(this.darkButton6_Click);
            // 
            // tbBelowSpecificPriceCARTCHECKOUTPrice
            // 
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled = false;
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Location = new System.Drawing.Point(280, 93);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Name = "tbBelowSpecificPriceCARTCHECKOUTPrice";
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Size = new System.Drawing.Size(67, 22);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.TabIndex = 54;
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCheckoutLinkPrice_KeyPress);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Leave += new System.EventHandler(this.tbCheckoutLinkPrice_Leave);
            // 
            // radioButtonPriceSpecificCARTCHECKOUT
            // 
            this.radioButtonPriceSpecificCARTCHECKOUT.AutoSize = true;
            this.radioButtonPriceSpecificCARTCHECKOUT.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonPriceSpecificCARTCHECKOUT.Location = new System.Drawing.Point(26, 96);
            this.radioButtonPriceSpecificCARTCHECKOUT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonPriceSpecificCARTCHECKOUT.Name = "radioButtonPriceSpecificCARTCHECKOUT";
            this.radioButtonPriceSpecificCARTCHECKOUT.Size = new System.Drawing.Size(211, 17);
            this.radioButtonPriceSpecificCARTCHECKOUT.TabIndex = 53;
            this.radioButtonPriceSpecificCARTCHECKOUT.Text = "Below specific price (Cart checkout) :";
            this.toolTip1.SetToolTip(this.radioButtonPriceSpecificCARTCHECKOUT, "This option require user to get the unique checkout link and paste it in product " +
        "link text box.");
            this.radioButtonPriceSpecificCARTCHECKOUT.CheckedChanged += new System.EventHandler(this.radioButtonPriceSpecificCheckoutLink_CheckedChanged);
            // 
            // darkButtonStart
            // 
            this.darkButtonStart.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButtonStart.Location = new System.Drawing.Point(528, 562);
            this.darkButtonStart.Margin = new System.Windows.Forms.Padding(2);
            this.darkButtonStart.Name = "darkButtonStart";
            this.darkButtonStart.Size = new System.Drawing.Size(233, 90);
            this.darkButtonStart.TabIndex = 25;
            this.darkButtonStart.Text = "Start";
            this.toolTip1.SetToolTip(this.darkButtonStart, "Start checkout.");
            this.darkButtonStart.Click += new System.EventHandler(this.darkButtonStart_Click);
            // 
            // timerlabel1
            // 
            this.timerlabel1.AutoSize = true;
            this.timerlabel1.BackColor = System.Drawing.Color.Transparent;
            this.timerlabel1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerlabel1.ForeColor = System.Drawing.Color.Gold;
            this.timerlabel1.Location = new System.Drawing.Point(0, 0);
            this.timerlabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timerlabel1.Name = "timerlabel1";
            this.timerlabel1.Size = new System.Drawing.Size(177, 40);
            this.timerlabel1.TabIndex = 27;
            this.timerlabel1.Text = "00:00:00:00";
            this.timerlabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkSectionPanelBotSettings
            // 
            this.darkSectionPanelBotSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxTestMode);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxLogging);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkButton5);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxRefresh);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxHeadless);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkLabel5);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkNumericUpDownTimeOut);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkLabel4);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxPlaySound);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkNumericUpDownRefreshSeconds);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkLabel13);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxDisableImageExtension);
            this.darkSectionPanelBotSettings.Location = new System.Drawing.Point(14, 43);
            this.darkSectionPanelBotSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelBotSettings.Name = "darkSectionPanelBotSettings";
            this.darkSectionPanelBotSettings.SectionHeader = "Bot Settings";
            this.darkSectionPanelBotSettings.Size = new System.Drawing.Size(364, 253);
            this.darkSectionPanelBotSettings.TabIndex = 29;
            // 
            // darkCheckBoxLogging
            // 
            this.darkCheckBoxLogging.AutoSize = true;
            this.darkCheckBoxLogging.Location = new System.Drawing.Point(24, 161);
            this.darkCheckBoxLogging.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxLogging.Name = "darkCheckBoxLogging";
            this.darkCheckBoxLogging.Size = new System.Drawing.Size(108, 17);
            this.darkCheckBoxLogging.TabIndex = 50;
            this.darkCheckBoxLogging.Text = "Disable logging";
            this.toolTip1.SetToolTip(this.darkCheckBoxLogging, "Enabling this option will disable the current running process log in \'Logs\' secti" +
        "on.");
            // 
            // darkButton5
            // 
            this.darkButton5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButton5.Location = new System.Drawing.Point(218, 55);
            this.darkButton5.Margin = new System.Windows.Forms.Padding(2);
            this.darkButton5.Name = "darkButton5";
            this.darkButton5.Size = new System.Drawing.Size(146, 23);
            this.darkButton5.TabIndex = 49;
            this.darkButton5.Text = "Clear cache";
            this.darkButton5.Visible = false;
            this.darkButton5.Click += new System.EventHandler(this.darkButton5_Click_1);
            // 
            // darkCheckBoxRefresh
            // 
            this.darkCheckBoxRefresh.AutoSize = true;
            this.darkCheckBoxRefresh.Location = new System.Drawing.Point(24, 130);
            this.darkCheckBoxRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxRefresh.Name = "darkCheckBoxRefresh";
            this.darkCheckBoxRefresh.Size = new System.Drawing.Size(141, 17);
            this.darkCheckBoxRefresh.TabIndex = 48;
            this.darkCheckBoxRefresh.Text = "Auto refresh webpage";
            this.toolTip1.SetToolTip(this.darkCheckBoxRefresh, "Enabling this will automatically refresh webpage. ");
            // 
            // darkCheckBoxHeadless
            // 
            this.darkCheckBoxHeadless.AutoSize = true;
            this.darkCheckBoxHeadless.Enabled = false;
            this.darkCheckBoxHeadless.Location = new System.Drawing.Point(24, 68);
            this.darkCheckBoxHeadless.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxHeadless.Name = "darkCheckBoxHeadless";
            this.darkCheckBoxHeadless.Size = new System.Drawing.Size(137, 17);
            this.darkCheckBoxHeadless.TabIndex = 47;
            this.darkCheckBoxHeadless.Text = "Hide Chrome Browser";
            this.toolTip1.SetToolTip(this.darkCheckBoxHeadless, "Enabling this option will hide chrome browser on  the next restart. It may help i" +
        "mprove the checkout time.");
            this.darkCheckBoxHeadless.Click += new System.EventHandler(this.darkCheckBoxHeadless_Click);
            // 
            // darkDockPanel1
            // 
            this.darkDockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkDockPanel1.Location = new System.Drawing.Point(-10, 27);
            this.darkDockPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkDockPanel1.Name = "darkDockPanel1";
            this.darkDockPanel1.Size = new System.Drawing.Size(805, 650);
            this.darkDockPanel1.TabIndex = 30;
            // 
            // darkMenuStrip1
            // 
            this.darkMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.darkMenuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.darkMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gfrgToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.testToolStripMenuItem});
            this.darkMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.darkMenuStrip1.Name = "darkMenuStrip1";
            this.darkMenuStrip1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.darkMenuStrip1.Size = new System.Drawing.Size(776, 24);
            this.darkMenuStrip1.TabIndex = 34;
            this.darkMenuStrip1.Text = "darkMenuStrip1";
            // 
            // gfrgToolStripMenuItem
            // 
            this.gfrgToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.gfrgToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elementEditorToolStripMenuItem,
            this.scanSaleItemsToolStripMenuItem,
            this.loadProfileSettingsToolStripMenuItem,
            this.saveProfileToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem1,
            this.testCookieToolStripMenuItem});
            this.gfrgToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.gfrgToolStripMenuItem.Name = "gfrgToolStripMenuItem";
            this.gfrgToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.gfrgToolStripMenuItem.Text = "File";
            // 
            // elementEditorToolStripMenuItem
            // 
            this.elementEditorToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.elementEditorToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.elementEditorToolStripMenuItem.Name = "elementEditorToolStripMenuItem";
            this.elementEditorToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.elementEditorToolStripMenuItem.Text = "Element editor";
            this.elementEditorToolStripMenuItem.Click += new System.EventHandler(this.elementEditorToolStripMenuItem_Click);
            // 
            // scanSaleItemsToolStripMenuItem
            // 
            this.scanSaleItemsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.scanSaleItemsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.scanSaleItemsToolStripMenuItem.Name = "scanSaleItemsToolStripMenuItem";
            this.scanSaleItemsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.scanSaleItemsToolStripMenuItem.Text = "Scan sale item";
            this.scanSaleItemsToolStripMenuItem.Visible = false;
            this.scanSaleItemsToolStripMenuItem.Click += new System.EventHandler(this.scanSaleItemsToolStripMenuItem_Click);
            // 
            // loadProfileSettingsToolStripMenuItem
            // 
            this.loadProfileSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.loadProfileSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.loadProfileSettingsToolStripMenuItem.Name = "loadProfileSettingsToolStripMenuItem";
            this.loadProfileSettingsToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.loadProfileSettingsToolStripMenuItem.Text = "Load profile settings";
            this.loadProfileSettingsToolStripMenuItem.Click += new System.EventHandler(this.loadProfileSettingsToolStripMenuItem_Click);
            // 
            // saveProfileToolStripMenuItem
            // 
            this.saveProfileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveProfileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveProfileToolStripMenuItem.Name = "saveProfileToolStripMenuItem";
            this.saveProfileToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.saveProfileToolStripMenuItem.Text = "Save current profile settings";
            this.saveProfileToolStripMenuItem.Click += new System.EventHandler(this.saveProfileToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(217, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.exitToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // testCookieToolStripMenuItem
            // 
            this.testCookieToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.testCookieToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.testCookieToolStripMenuItem.Name = "testCookieToolStripMenuItem";
            this.testCookieToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.testCookieToolStripMenuItem.Text = "test cookie";
            this.testCookieToolStripMenuItem.Visible = false;
            this.testCookieToolStripMenuItem.Click += new System.EventHandler(this.testCookieToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFontToolStripMenuItem,
            this.updateConfigurationToolStripMenuItem1,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.changeHistoryToolStripMenuItem,
            this.paydaySaleTipToolStripMenuItem});
            this.helpToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.changeFontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setNewFontToolStripMenuItem,
            this.resetFontToolStripMenuItem});
            this.changeFontToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.changeFontToolStripMenuItem.Text = "Font settings";
            this.changeFontToolStripMenuItem.Visible = false;
            // 
            // setNewFontToolStripMenuItem
            // 
            this.setNewFontToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.setNewFontToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.setNewFontToolStripMenuItem.Name = "setNewFontToolStripMenuItem";
            this.setNewFontToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.setNewFontToolStripMenuItem.Text = "Set new font";
            this.setNewFontToolStripMenuItem.Click += new System.EventHandler(this.setNewFontToolStripMenuItem_Click);
            // 
            // resetFontToolStripMenuItem
            // 
            this.resetFontToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.resetFontToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.resetFontToolStripMenuItem.Name = "resetFontToolStripMenuItem";
            this.resetFontToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.resetFontToolStripMenuItem.Text = "Reset font";
            this.resetFontToolStripMenuItem.Click += new System.EventHandler(this.resetFontToolStripMenuItem_Click);
            // 
            // updateConfigurationToolStripMenuItem1
            // 
            this.updateConfigurationToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.updateConfigurationToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.updateConfigurationToolStripMenuItem1.Name = "updateConfigurationToolStripMenuItem1";
            this.updateConfigurationToolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.updateConfigurationToolStripMenuItem1.Text = "Update configuration";
            this.updateConfigurationToolStripMenuItem1.Click += new System.EventHandler(this.updateConfigurationToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.aboutToolStripMenuItem.Text = "About Shopee Autobuy Bot";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // changeHistoryToolStripMenuItem
            // 
            this.changeHistoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.changeHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.changeHistoryToolStripMenuItem.Name = "changeHistoryToolStripMenuItem";
            this.changeHistoryToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.changeHistoryToolStripMenuItem.Text = "Changelog history";
            this.changeHistoryToolStripMenuItem.Click += new System.EventHandler(this.changeHistoryToolStripMenuItem_Click);
            // 
            // paydaySaleTipToolStripMenuItem
            // 
            this.paydaySaleTipToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.paydaySaleTipToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.paydaySaleTipToolStripMenuItem.Name = "paydaySaleTipToolStripMenuItem";
            this.paydaySaleTipToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.paydaySaleTipToolStripMenuItem.Text = "Tips";
            this.paydaySaleTipToolStripMenuItem.Click += new System.EventHandler(this.paydaySaleTipToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveCookiesToolStripMenuItem,
            this.fontTestToolStripMenuItem});
            this.testToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            // 
            // saveCookiesToolStripMenuItem
            // 
            this.saveCookiesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.saveCookiesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.saveCookiesToolStripMenuItem.Name = "saveCookiesToolStripMenuItem";
            this.saveCookiesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveCookiesToolStripMenuItem.Text = "save cookies";
            this.saveCookiesToolStripMenuItem.Click += new System.EventHandler(this.saveCookiesToolStripMenuItem_Click);
            // 
            // fontTestToolStripMenuItem
            // 
            this.fontTestToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fontTestToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fontTestToolStripMenuItem.Name = "fontTestToolStripMenuItem";
            this.fontTestToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.fontTestToolStripMenuItem.Text = "font test";
            this.fontTestToolStripMenuItem.Click += new System.EventHandler(this.fontTestToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpgradeProToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // UpgradeProToolStripMenuItem
            // 
            this.UpgradeProToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.UpgradeProToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.UpgradeProToolStripMenuItem.Name = "UpgradeProToolStripMenuItem";
            this.UpgradeProToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.UpgradeProToolStripMenuItem.Text = "Upgrade to Pro";
            this.UpgradeProToolStripMenuItem.Visible = false;
            this.UpgradeProToolStripMenuItem.Click += new System.EventHandler(this.visitFacebookPageToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.aboutToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // changelogHistoryToolStripMenuItem
            // 
            this.changelogHistoryToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.changelogHistoryToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.changelogHistoryToolStripMenuItem.Name = "changelogHistoryToolStripMenuItem";
            this.changelogHistoryToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.changelogHistoryToolStripMenuItem.Text = "Change history";
            this.changelogHistoryToolStripMenuItem.Click += new System.EventHandler(this.changelogHistoryToolStripMenuItem_Click);
            // 
            // disclaimerToolStripMenuItem
            // 
            this.disclaimerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.disclaimerToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.disclaimerToolStripMenuItem.Name = "disclaimerToolStripMenuItem";
            this.disclaimerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.disclaimerToolStripMenuItem.Text = "Disclaimer";
            this.disclaimerToolStripMenuItem.Visible = false;
            this.disclaimerToolStripMenuItem.Click += new System.EventHandler(this.disclaimerToolStripMenuItem_Click);
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.howToUseToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.howToUseToolStripMenuItem.Text = "How to use";
            // 
            // updateConfigurationToolStripMenuItem
            // 
            this.updateConfigurationToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.updateConfigurationToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.updateConfigurationToolStripMenuItem.Name = "updateConfigurationToolStripMenuItem";
            this.updateConfigurationToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.updateConfigurationToolStripMenuItem.Text = "Update configuration";
            this.updateConfigurationToolStripMenuItem.Click += new System.EventHandler(this.updateConfigurationToolStripMenuItem_Click);
            // 
            // darkSectionPanelBuyingMode
            // 
            this.darkSectionPanelBuyingMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelBuyingMode.Controls.Add(this.tbBelowSpecificPriceCARTCHECKOUTPrice);
            this.darkSectionPanelBuyingMode.Controls.Add(this.tbPriceSpecific);
            this.darkSectionPanelBuyingMode.Controls.Add(this.radioButtonPriceSpecificCARTCHECKOUT);
            this.darkSectionPanelBuyingMode.Controls.Add(this.radioButtonCheckOutCart);
            this.darkSectionPanelBuyingMode.Controls.Add(this.radioButtonShockingSale);
            this.darkSectionPanelBuyingMode.Controls.Add(this.radioButtonBuyNormal);
            this.darkSectionPanelBuyingMode.Controls.Add(this.radioButtonPriceSpecific);
            this.darkSectionPanelBuyingMode.Location = new System.Drawing.Point(384, 170);
            this.darkSectionPanelBuyingMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelBuyingMode.Name = "darkSectionPanelBuyingMode";
            this.darkSectionPanelBuyingMode.SectionHeader = "Buying Mode";
            this.darkSectionPanelBuyingMode.Size = new System.Drawing.Size(376, 126);
            this.darkSectionPanelBuyingMode.TabIndex = 50;
            this.darkSectionPanelBuyingMode.Click += new System.EventHandler(this.darkSectionPanelBuyingMode_Click);
            // 
            // tbPriceSpecific
            // 
            this.tbPriceSpecific.Enabled = false;
            this.tbPriceSpecific.Location = new System.Drawing.Point(280, 63);
            this.tbPriceSpecific.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbPriceSpecific.Name = "tbPriceSpecific";
            this.tbPriceSpecific.Size = new System.Drawing.Size(67, 22);
            this.tbPriceSpecific.TabIndex = 50;
            this.tbPriceSpecific.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPriceSpecific.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.darkTextBox1_KeyPress);
            this.tbPriceSpecific.Leave += new System.EventHandler(this.tbPriceSpecific_Leave);
            // 
            // radioButtonCheckOutCart
            // 
            this.radioButtonCheckOutCart.AutoSize = true;
            this.radioButtonCheckOutCart.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonCheckOutCart.Location = new System.Drawing.Point(26, 66);
            this.radioButtonCheckOutCart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonCheckOutCart.Name = "radioButtonCheckOutCart";
            this.radioButtonCheckOutCart.Size = new System.Drawing.Size(96, 17);
            this.radioButtonCheckOutCart.TabIndex = 52;
            this.radioButtonCheckOutCart.Text = "Cart checkout";
            this.toolTip1.SetToolTip(this.radioButtonCheckOutCart, "To use this option, user need to manually add items into cart. When Start button " +
        "clicked, the checkout process is start from cart page thus lower checkout time.");
            this.radioButtonCheckOutCart.CheckedChanged += new System.EventHandler(this.radioButtonCheckOutCart_CheckedChanged);
            // 
            // radioButtonShockingSale
            // 
            this.radioButtonShockingSale.AutoSize = true;
            this.radioButtonShockingSale.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonShockingSale.Location = new System.Drawing.Point(145, 36);
            this.radioButtonShockingSale.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonShockingSale.Name = "radioButtonShockingSale";
            this.radioButtonShockingSale.Size = new System.Drawing.Size(159, 17);
            this.radioButtonShockingSale.TabIndex = 51;
            this.radioButtonShockingSale.Text = "Flash/Shocking sale mode";
            this.toolTip1.SetToolTip(this.radioButtonShockingSale, "For this option, bot will only start checkout process if the item is in the shock" +
        "ing/flash sale period.");
            // 
            // radioButtonBuyNormal
            // 
            this.radioButtonBuyNormal.AutoSize = true;
            this.radioButtonBuyNormal.Checked = true;
            this.radioButtonBuyNormal.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonBuyNormal.Location = new System.Drawing.Point(26, 36);
            this.radioButtonBuyNormal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonBuyNormal.Name = "radioButtonBuyNormal";
            this.radioButtonBuyNormal.Size = new System.Drawing.Size(94, 17);
            this.radioButtonBuyNormal.TabIndex = 50;
            this.radioButtonBuyNormal.TabStop = true;
            this.radioButtonBuyNormal.Text = "Normal mode";
            this.toolTip1.SetToolTip(this.radioButtonBuyNormal, "Normal Mode.");
            // 
            // radioButtonPriceSpecific
            // 
            this.radioButtonPriceSpecific.AutoSize = true;
            this.radioButtonPriceSpecific.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonPriceSpecific.Location = new System.Drawing.Point(146, 66);
            this.radioButtonPriceSpecific.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonPriceSpecific.Name = "radioButtonPriceSpecific";
            this.radioButtonPriceSpecific.Size = new System.Drawing.Size(131, 17);
            this.radioButtonPriceSpecific.TabIndex = 15;
            this.radioButtonPriceSpecific.Text = "Below specific price :";
            this.toolTip1.SetToolTip(this.radioButtonPriceSpecific, "This option let the user choose which price they want bot to start checkout. Bot " +
        "will only start checkout process once product\'s price is lower than the price se" +
        "t by user.");
            this.radioButtonPriceSpecific.CheckedChanged += new System.EventHandler(this.radioButtonPriceSpecific_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(545, 506);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Days";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(599, 506);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Hour";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(647, 506);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Minute";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(701, 506);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Second";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // darkSectionPanelPaymentDetails
            // 
            this.darkSectionPanelPaymentDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel14);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.tbLast4Digit);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel6);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkComboBoxPaymentMethod);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel8);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkComboBoxBankType);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkTextBoxShopeePayPin);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel7);
            this.darkSectionPanelPaymentDetails.Location = new System.Drawing.Point(384, 301);
            this.darkSectionPanelPaymentDetails.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelPaymentDetails.Name = "darkSectionPanelPaymentDetails";
            this.darkSectionPanelPaymentDetails.SectionHeader = "Payment Details";
            this.darkSectionPanelPaymentDetails.Size = new System.Drawing.Size(376, 195);
            this.darkSectionPanelPaymentDetails.TabIndex = 55;
            // 
            // darkCheckBoxRedeemShopeeVoucher
            // 
            this.darkCheckBoxRedeemShopeeVoucher.AutoSize = true;
            this.darkCheckBoxRedeemShopeeVoucher.Location = new System.Drawing.Point(11, 77);
            this.darkCheckBoxRedeemShopeeVoucher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxRedeemShopeeVoucher.Name = "darkCheckBoxRedeemShopeeVoucher";
            this.darkCheckBoxRedeemShopeeVoucher.Size = new System.Drawing.Size(174, 17);
            this.darkCheckBoxRedeemShopeeVoucher.TabIndex = 52;
            this.darkCheckBoxRedeemShopeeVoucher.Text = "Redeem any Shopee voucher";
            this.toolTip1.SetToolTip(this.darkCheckBoxRedeemShopeeVoucher, "Enabling this will let bot claim any available Shopee voucher.");
            // 
            // darkButton7
            // 
            this.darkButton7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.darkButton7.Location = new System.Drawing.Point(502, 626);
            this.darkButton7.Margin = new System.Windows.Forms.Padding(2);
            this.darkButton7.Name = "darkButton7";
            this.darkButton7.Size = new System.Drawing.Size(259, 26);
            this.darkButton7.TabIndex = 56;
            this.darkButton7.Text = "Copy logs to clipboard";
            this.toolTip1.SetToolTip(this.darkButton7, "Copy logs to clipboard");
            this.darkButton7.Click += new System.EventHandler(this.darkButton7_Click);
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel1.Controls.Add(this.darkCheckBoxRedeemShopeeVoucher);
            this.darkSectionPanel1.Controls.Add(this.darkCheckBoxClaimShopVoucher);
            this.darkSectionPanel1.Controls.Add(this.darkCheckBoxRedeemCoin);
            this.darkSectionPanel1.Location = new System.Drawing.Point(331, 501);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Voucher & coin";
            this.darkSectionPanel1.Size = new System.Drawing.Size(192, 151);
            this.darkSectionPanel1.TabIndex = 57;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.timerlabel1);
            this.panel1.Location = new System.Drawing.Point(558, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 40);
            this.panel1.TabIndex = 53;
            // 
            // darkLabel15
            // 
            this.darkLabel15.AutoSize = true;
            this.darkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel15.Location = new System.Drawing.Point(547, 7);
            this.darkLabel15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel15.Name = "darkLabel15";
            this.darkLabel15.Size = new System.Drawing.Size(94, 13);
            this.darkLabel15.TabIndex = 58;
            this.darkLabel15.Text = "Shopee Account:";
            this.darkLabel15.Visible = false;
            // 
            // labelShopeeAcc
            // 
            this.labelShopeeAcc.AutoSize = true;
            this.labelShopeeAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelShopeeAcc.Location = new System.Drawing.Point(641, 7);
            this.labelShopeeAcc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelShopeeAcc.Name = "labelShopeeAcc";
            this.labelShopeeAcc.Size = new System.Drawing.Size(16, 13);
            this.labelShopeeAcc.TabIndex = 59;
            this.labelShopeeAcc.Text = "...";
            this.labelShopeeAcc.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 666);
            this.Controls.Add(this.labelShopeeAcc);
            this.Controls.Add(this.darkLabel15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.darkSectionPanelPaymentDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.darkSectionPanelBuyingMode);
            this.Controls.Add(this.darkMenuStrip1);
            this.Controls.Add(this.darkSectionPanelBotSettings);
            this.Controls.Add(this.darkButtonStart);
            this.Controls.Add(this.darkSectionPanelLogs);
            this.Controls.Add(this.darkSectionPanelProductDetails);
            this.Controls.Add(this.darkSectionPanelTimerMode);
            this.Controls.Add(this.darkDockPanel1);
            this.Controls.Add(this.darkButton7);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 56);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopee Autobuy Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.darkSectionPanelTimerMode.ResumeLayout(false);
            this.darkSectionPanelTimerMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownCountDownSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownCountdownMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownCountdownHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownRefreshSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDownProductQuantity)).EndInit();
            this.darkSectionPanelProductDetails.ResumeLayout(false);
            this.darkSectionPanelProductDetails.PerformLayout();
            this.darkSectionPanelLogs.ResumeLayout(false);
            this.darkSectionPanelLogs.PerformLayout();
            this.darkSectionPanelBotSettings.ResumeLayout(false);
            this.darkSectionPanelBotSettings.PerformLayout();
            this.darkMenuStrip1.ResumeLayout(false);
            this.darkMenuStrip1.PerformLayout();
            this.darkSectionPanelBuyingMode.ResumeLayout(false);
            this.darkSectionPanelBuyingMode.PerformLayout();
            this.darkSectionPanelPaymentDetails.ResumeLayout(false);
            this.darkSectionPanelPaymentDetails.PerformLayout();
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private DarkUI.Controls.DarkComboBox darkComboBoxPaymentMethod;
        private DarkUI.Controls.DarkComboBox darkComboBoxCourier;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkTextBox darkTextBoxVariationString;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelProductDetails;
        private DarkUI.Controls.DarkLabel darkLabel12;
        private DarkUI.Controls.DarkLabel darkLabel11;
        private DarkUI.Controls.DarkTextBox darkTextBoxProductLink;
        private DarkUI.Controls.DarkLabel darkLabel10;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownProductQuantity;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private DarkUI.Controls.DarkTextBox darkTextBoxShopeePayPin;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkButton darkButton4;
        private DarkUI.Controls.DarkButton darkButton3;
        private DarkUI.Controls.DarkButton darkButton2;
        private DarkUI.Controls.DarkButton darkButtonStart;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelLogs;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxPlaySound;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxDisableImageExtension;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownRefreshSeconds;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownCountdownMinutes;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownCountdownHour;
        private System.Windows.Forms.Label timerlabel1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelTimerMode;
        private DarkUI.Controls.DarkComboBox darkComboBoxBankType;
        private DarkUI.Controls.DarkLabel darkLabel8;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownTimeOut;
        private DarkUI.Controls.DarkLabel darkLabel13;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRedeemCoin;
        private DarkUI.Controls.DarkButton darkButtonDeleteAllOrder;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelBotSettings;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxHeadless;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRefresh;
        private DarkUI.Docking.DarkDockPanel darkDockPanel1;
        private DarkUI.Controls.DarkMenuStrip darkMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpgradeProToolStripMenuItem;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkNumericUpDown darkNumericUpDownCountDownSecond;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxTestMode;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelBuyingMode;
        private  System.Windows.Forms.RadioButton radioButtonBuyNormal;
        private  System.Windows.Forms.RadioButton radioButtonPriceSpecific;
        private  System.Windows.Forms.RadioButton radioButtonShockingSale;
        private  System.Windows.Forms.RadioButton radioButtonCheckOutCart;
        private DarkUI.Controls.DarkTextBox tbPriceSpecific;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxScheduleBot;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disclaimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxTomorrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem updateConfigurationToolStripMenuItem;
        private DarkUI.Controls.DarkLabel darkLabel14;
        private DarkUI.Controls.DarkTextBox tbLast4Digit;
        private DarkUI.Controls.DarkButton darkButton5;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxLogging;
        private System.Windows.Forms.ToolStripMenuItem gfrgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateConfigurationToolStripMenuItem1;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelPaymentDetails;
        private DarkUI.Controls.DarkButton darkButton6;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRedeemShopeeVoucher;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxClaimShopVoucher;
        private System.Windows.Forms.ToolTip toolTip1;
        private DarkUI.Controls.DarkTextBox tbBelowSpecificPriceCARTCHECKOUTPrice;
        private System.Windows.Forms.RadioButton radioButtonPriceSpecificCARTCHECKOUT;
        private DarkUI.Controls.DarkButton darkButton7;
        private System.Windows.Forms.ToolStripMenuItem paydaySaleTipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCookiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanSaleItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProfileToolStripMenuItem;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem testCookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elementEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fontTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setNewFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetFontToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem loadProfileSettingsToolStripMenuItem;
        private DarkUI.Controls.DarkCheckBox cbRandom;
        private DarkUI.Controls.DarkLabel darkLabel15;
        private DarkUI.Controls.DarkLabel labelShopeeAcc;
    }
}

