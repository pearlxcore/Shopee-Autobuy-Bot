using System;
using System.Diagnostics;
using System.Drawing;


namespace Shopee_Autobuy_Bot
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            darkSectionPanelTimerMode=new System.Windows.Forms.GroupBox();
            darkCheckBoxTomorrow=new System.Windows.Forms.CheckBox();
            darkCheckBoxScheduleBot=new System.Windows.Forms.CheckBox();
            darkLabel3=new System.Windows.Forms.Label();
            darkNumericUpDownCountDownSecond=new System.Windows.Forms.NumericUpDown();
            darkLabel2=new System.Windows.Forms.Label();
            darkLabel1=new System.Windows.Forms.Label();
            darkNumericUpDownCountdownMinutes=new System.Windows.Forms.NumericUpDown();
            darkNumericUpDownCountdownHour=new System.Windows.Forms.NumericUpDown();
            darkNumericUpDownTimeOut=new System.Windows.Forms.NumericUpDown();
            darkLabel13=new System.Windows.Forms.Label();
            darkCheckBoxNotifyTelegram=new System.Windows.Forms.CheckBox();
            darkLabel5=new System.Windows.Forms.Label();
            darkLabel4=new System.Windows.Forms.Label();
            darkNumericUpDownRefreshSeconds=new System.Windows.Forms.NumericUpDown();
            darkComboBoxPaymentMethod=new System.Windows.Forms.ComboBox();
            darkTextBoxShopeePayPin=new System.Windows.Forms.TextBox();
            darkLabel6=new System.Windows.Forms.Label();
            darkLabel7=new System.Windows.Forms.Label();
            darkComboBoxCourier=new System.Windows.Forms.ComboBox();
            darkLabel9=new System.Windows.Forms.Label();
            darkTextBoxVariationString=new System.Windows.Forms.TextBox();
            darkLabel10=new System.Windows.Forms.Label();
            darkNumericUpDownProductQuantity=new System.Windows.Forms.NumericUpDown();
            darkSectionPanelProductDetails=new System.Windows.Forms.GroupBox();
            cbVariantPreSelected=new System.Windows.Forms.CheckBox();
            cbRandom=new System.Windows.Forms.CheckBox();
            darkLabel11=new System.Windows.Forms.Label();
            darkTextBoxProductLink=new System.Windows.Forms.TextBox();
            darkCheckBoxClaimShopVoucher=new System.Windows.Forms.CheckBox();
            darkCheckBoxTestMode=new System.Windows.Forms.CheckBox();
            darkLabel14=new System.Windows.Forms.Label();
            tbLast4Digit=new System.Windows.Forms.TextBox();
            darkCheckBoxRedeemCoin=new System.Windows.Forms.CheckBox();
            darkComboBoxBankType=new System.Windows.Forms.ComboBox();
            darkLabel8=new System.Windows.Forms.Label();
            darkLabel12=new System.Windows.Forms.Label();
            darkSectionPanelLogs=new System.Windows.Forms.GroupBox();
            darkButtonDeleteAllOrder=new System.Windows.Forms.Button();
            richTextBoxLogs=new System.Windows.Forms.RichTextBox();
            darkButton1=new System.Windows.Forms.Button();
            darkButton4=new System.Windows.Forms.Button();
            darkButton3=new System.Windows.Forms.Button();
            darkButton2=new System.Windows.Forms.Button();
            darkButton6=new System.Windows.Forms.Button();
            tbBelowSpecificPriceCARTCHECKOUTPrice=new System.Windows.Forms.TextBox();
            radioButtonPriceSpecificCartCheckout=new System.Windows.Forms.RadioButton();
            darkButtonStart=new System.Windows.Forms.Button();
            timerlabelBig=new System.Windows.Forms.Label();
            darkSectionPanelBotSettings=new System.Windows.Forms.GroupBox();
            checkBoxDesktopNotification=new System.Windows.Forms.CheckBox();
            darkCheckBoxLogging=new System.Windows.Forms.CheckBox();
            darkButton5=new System.Windows.Forms.Button();
            darkCheckBoxRefresh=new System.Windows.Forms.CheckBox();
            darkMenuStrip1=new System.Windows.Forms.MenuStrip();
            gfrgToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            elementEditorToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            scanSaleItemsToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            profileToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemLoadProfile=new System.Windows.Forms.ToolStripMenuItem();
            saveCurrentProfileToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            sessionCookieToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            loadCookiesToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            saveCookieToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            cleToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            testToolStripMenuItem1=new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2=new System.Windows.Forms.ToolStripSeparator();
            exitToolStripMenuItem1=new System.Windows.Forms.ToolStripMenuItem();
            testCookieToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem1=new System.Windows.Forms.ToolStripMenuItem();
            updateConfigurationToolStripMenuItem1=new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1=new System.Windows.Forms.ToolStripSeparator();
            aboutToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            changeHistoryToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            testToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            saveCookiesToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            fontTestToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            telegramToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            fileToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            UpgradeProToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem1=new System.Windows.Forms.ToolStripMenuItem();
            changelogHistoryToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            disclaimerToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            howToUseToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            updateConfigurationToolStripMenuItem=new System.Windows.Forms.ToolStripMenuItem();
            darkSectionPanelBuyingMode=new System.Windows.Forms.GroupBox();
            tbPriceSpecific=new System.Windows.Forms.TextBox();
            radioButtonCheckOutCart=new System.Windows.Forms.RadioButton();
            radioButtonShockingSale=new System.Windows.Forms.RadioButton();
            radioButtonBuyNormal=new System.Windows.Forms.RadioButton();
            radioButtonPriceSpecific=new System.Windows.Forms.RadioButton();
            label1=new System.Windows.Forms.Label();
            label2=new System.Windows.Forms.Label();
            label3=new System.Windows.Forms.Label();
            label4=new System.Windows.Forms.Label();
            darkSectionPanelPaymentDetails=new System.Windows.Forms.GroupBox();
            darkCheckBoxRedeemShopeeVoucher=new System.Windows.Forms.CheckBox();
            toolTip1=new System.Windows.Forms.ToolTip(components);
            darkButton7=new System.Windows.Forms.Button();
            darkSectionPanel1=new System.Windows.Forms.GroupBox();
            notifyIcon1=new System.Windows.Forms.NotifyIcon(components);
            panel1=new System.Windows.Forms.Panel();
            darkLabel15=new System.Windows.Forms.Label();
            labelShopeeAcc=new System.Windows.Forms.Label();
            darkSectionPanelTimerMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownCountDownSecond).BeginInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownCountdownMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownCountdownHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownTimeOut).BeginInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownRefreshSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownProductQuantity).BeginInit();
            darkSectionPanelProductDetails.SuspendLayout();
            darkSectionPanelLogs.SuspendLayout();
            darkSectionPanelBotSettings.SuspendLayout();
            darkMenuStrip1.SuspendLayout();
            darkSectionPanelBuyingMode.SuspendLayout();
            darkSectionPanelPaymentDetails.SuspendLayout();
            darkSectionPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // darkSectionPanelTimerMode
            // 
            darkSectionPanelTimerMode.Controls.Add(darkCheckBoxTomorrow);
            darkSectionPanelTimerMode.Controls.Add(darkCheckBoxScheduleBot);
            darkSectionPanelTimerMode.Controls.Add(darkLabel3);
            darkSectionPanelTimerMode.Controls.Add(darkNumericUpDownCountDownSecond);
            darkSectionPanelTimerMode.Controls.Add(darkLabel2);
            darkSectionPanelTimerMode.Controls.Add(darkLabel1);
            darkSectionPanelTimerMode.Controls.Add(darkNumericUpDownCountdownMinutes);
            darkSectionPanelTimerMode.Controls.Add(darkNumericUpDownCountdownHour);
            darkSectionPanelTimerMode.Location=new Point(384, 43);
            darkSectionPanelTimerMode.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelTimerMode.Name="darkSectionPanelTimerMode";
            darkSectionPanelTimerMode.Size=new Size(376, 121);
            darkSectionPanelTimerMode.TabIndex=0;
            darkSectionPanelTimerMode.TabStop=false;
            darkSectionPanelTimerMode.Text="Schedule Bot";
            // 
            // darkCheckBoxTomorrow
            // 
            darkCheckBoxTomorrow.AutoSize=true;
            darkCheckBoxTomorrow.Enabled=false;
            darkCheckBoxTomorrow.Location=new Point(38, 89);
            darkCheckBoxTomorrow.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxTomorrow.Name="darkCheckBoxTomorrow";
            darkCheckBoxTomorrow.Size=new Size(78, 17);
            darkCheckBoxTomorrow.TabIndex=16;
            darkCheckBoxTomorrow.Text="Tomorrow";
            toolTip1.SetToolTip(darkCheckBoxTomorrow, "Enable this if the time set is for tomorrow.");
            // 
            // darkCheckBoxScheduleBot
            // 
            darkCheckBoxScheduleBot.AutoSize=true;
            darkCheckBoxScheduleBot.Location=new Point(38, 38);
            darkCheckBoxScheduleBot.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxScheduleBot.Name="darkCheckBoxScheduleBot";
            darkCheckBoxScheduleBot.Size=new Size(300, 17);
            darkCheckBoxScheduleBot.TabIndex=15;
            darkCheckBoxScheduleBot.Text="Schedule bot to run at specific time (24-hours format)";
            toolTip1.SetToolTip(darkCheckBoxScheduleBot, "Enabling this will let the bot to run at specific time set by user in 24 hour format.");
            darkCheckBoxScheduleBot.CheckedChanged+=darkCheckBoxCountDownMode_CheckedChanged;
            // 
            // darkLabel3
            // 
            darkLabel3.AutoSize=true;
            darkLabel3.Enabled=false;
            darkLabel3.ForeColor=SystemColors.ControlText;
            darkLabel3.Location=new Point(210, 65);
            darkLabel3.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel3.Name="darkLabel3";
            darkLabel3.Size=new Size(50, 13);
            darkLabel3.TabIndex=14;
            darkLabel3.Text="Seconds";
            // 
            // darkNumericUpDownCountDownSecond
            // 
            darkNumericUpDownCountDownSecond.BackColor=SystemColors.Window;
            darkNumericUpDownCountDownSecond.Enabled=false;
            darkNumericUpDownCountDownSecond.ForeColor=SystemColors.ControlText;
            darkNumericUpDownCountDownSecond.Location=new Point(263, 61);
            darkNumericUpDownCountDownSecond.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkNumericUpDownCountDownSecond.Maximum=new decimal(new int[] { 59, 0, 0, 0 });
            darkNumericUpDownCountDownSecond.Name="darkNumericUpDownCountDownSecond";
            darkNumericUpDownCountDownSecond.Size=new Size(38, 22);
            darkNumericUpDownCountDownSecond.TabIndex=13;
            // 
            // darkLabel2
            // 
            darkLabel2.AutoSize=true;
            darkLabel2.Enabled=false;
            darkLabel2.ForeColor=SystemColors.ControlText;
            darkLabel2.Location=new Point(115, 65);
            darkLabel2.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel2.Name="darkLabel2";
            darkLabel2.Size=new Size(49, 13);
            darkLabel2.TabIndex=5;
            darkLabel2.Text="Minutes";
            // 
            // darkLabel1
            // 
            darkLabel1.AutoSize=true;
            darkLabel1.Enabled=false;
            darkLabel1.ForeColor=SystemColors.ControlText;
            darkLabel1.Location=new Point(36, 65);
            darkLabel1.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel1.Name="darkLabel1";
            darkLabel1.Size=new Size(33, 13);
            darkLabel1.TabIndex=4;
            darkLabel1.Text="Hour";
            // 
            // darkNumericUpDownCountdownMinutes
            // 
            darkNumericUpDownCountdownMinutes.BackColor=SystemColors.Window;
            darkNumericUpDownCountdownMinutes.Enabled=false;
            darkNumericUpDownCountdownMinutes.ForeColor=SystemColors.ControlText;
            darkNumericUpDownCountdownMinutes.Location=new Point(168, 61);
            darkNumericUpDownCountdownMinutes.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkNumericUpDownCountdownMinutes.Maximum=new decimal(new int[] { 59, 0, 0, 0 });
            darkNumericUpDownCountdownMinutes.Name="darkNumericUpDownCountdownMinutes";
            darkNumericUpDownCountdownMinutes.Size=new Size(38, 22);
            darkNumericUpDownCountdownMinutes.TabIndex=3;
            // 
            // darkNumericUpDownCountdownHour
            // 
            darkNumericUpDownCountdownHour.BackColor=SystemColors.Window;
            darkNumericUpDownCountdownHour.Enabled=false;
            darkNumericUpDownCountdownHour.ForeColor=SystemColors.ControlText;
            darkNumericUpDownCountdownHour.Location=new Point(73, 61);
            darkNumericUpDownCountdownHour.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkNumericUpDownCountdownHour.Maximum=new decimal(new int[] { 23, 0, 0, 0 });
            darkNumericUpDownCountdownHour.Name="darkNumericUpDownCountdownHour";
            darkNumericUpDownCountdownHour.Size=new Size(38, 22);
            darkNumericUpDownCountdownHour.TabIndex=2;
            darkNumericUpDownCountdownHour.ValueChanged+=darkNumericUpDownCountdownHour_ValueChanged;
            // 
            // darkNumericUpDownTimeOut
            // 
            darkNumericUpDownTimeOut.BackColor=SystemColors.Window;
            darkNumericUpDownTimeOut.ForeColor=SystemColors.ControlText;
            darkNumericUpDownTimeOut.Location=new Point(138, 217);
            darkNumericUpDownTimeOut.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkNumericUpDownTimeOut.Maximum=new decimal(new int[] { 20, 0, 0, 0 });
            darkNumericUpDownTimeOut.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            darkNumericUpDownTimeOut.Name="darkNumericUpDownTimeOut";
            darkNumericUpDownTimeOut.Size=new Size(38, 22);
            darkNumericUpDownTimeOut.TabIndex=46;
            darkNumericUpDownTimeOut.Value=new decimal(new int[] { 5, 0, 0, 0 });
            darkNumericUpDownTimeOut.ValueChanged+=darkNumericUpDownTimeOut_ValueChanged;
            // 
            // darkLabel13
            // 
            darkLabel13.AutoSize=true;
            darkLabel13.ForeColor=SystemColors.ControlText;
            darkLabel13.Location=new Point(20, 222);
            darkLabel13.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel13.Name="darkLabel13";
            darkLabel13.Size=new Size(104, 13);
            darkLabel13.TabIndex=45;
            darkLabel13.Text="Time out (second) :";
            toolTip1.SetToolTip(darkLabel13, "Timeout in second when bot does not receive response from the webpage element.");
            // 
            // darkCheckBoxNotifyTelegram
            // 
            darkCheckBoxNotifyTelegram.AutoSize=true;
            darkCheckBoxNotifyTelegram.Location=new Point(24, 37);
            darkCheckBoxNotifyTelegram.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxNotifyTelegram.Name="darkCheckBoxNotifyTelegram";
            darkCheckBoxNotifyTelegram.Size=new Size(300, 17);
            darkCheckBoxNotifyTelegram.TabIndex=28;
            darkCheckBoxNotifyTelegram.Text="Send notification to Telegram on successful checkout";
            toolTip1.SetToolTip(darkCheckBoxNotifyTelegram, "Enabling this option will play a sound on successful checkout.");
            // 
            // darkLabel5
            // 
            darkLabel5.AutoSize=true;
            darkLabel5.ForeColor=SystemColors.ControlText;
            darkLabel5.Location=new Point(292, 113);
            darkLabel5.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel5.Name="darkLabel5";
            darkLabel5.Size=new Size(49, 13);
            darkLabel5.TabIndex=11;
            darkLabel5.Text="seconds";
            // 
            // darkLabel4
            // 
            darkLabel4.AutoSize=true;
            darkLabel4.ForeColor=SystemColors.ControlText;
            darkLabel4.Location=new Point(176, 113);
            darkLabel4.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel4.Name="darkLabel4";
            darkLabel4.Size=new Size(75, 13);
            darkLabel4.TabIndex=10;
            darkLabel4.Text="Refresh every";
            // 
            // darkNumericUpDownRefreshSeconds
            // 
            darkNumericUpDownRefreshSeconds.BackColor=SystemColors.Window;
            darkNumericUpDownRefreshSeconds.ForeColor=SystemColors.ControlText;
            darkNumericUpDownRefreshSeconds.Location=new Point(253, 108);
            darkNumericUpDownRefreshSeconds.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkNumericUpDownRefreshSeconds.Maximum=new decimal(new int[] { 10, 0, 0, 0 });
            darkNumericUpDownRefreshSeconds.Name="darkNumericUpDownRefreshSeconds";
            darkNumericUpDownRefreshSeconds.Size=new Size(38, 22);
            darkNumericUpDownRefreshSeconds.TabIndex=9;
            darkNumericUpDownRefreshSeconds.Value=new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // darkComboBoxPaymentMethod
            // 
            darkComboBoxPaymentMethod.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
            darkComboBoxPaymentMethod.FormattingEnabled=true;
            darkComboBoxPaymentMethod.Items.AddRange(new object[] { "Default", "Credit / Debit Card", "ATM / Cash Deposit", "Online Banking", "ShopeePay", "Cash on Delivery", "7-Eleven", "KK Mart" });
            darkComboBoxPaymentMethod.Location=new Point(154, 33);
            darkComboBoxPaymentMethod.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkComboBoxPaymentMethod.Name="darkComboBoxPaymentMethod";
            darkComboBoxPaymentMethod.Size=new Size(194, 21);
            darkComboBoxPaymentMethod.TabIndex=12;
            toolTip1.SetToolTip(darkComboBoxPaymentMethod, "Payment method.");
            darkComboBoxPaymentMethod.SelectedIndexChanged+=darkComboBoxPaymentMethod_SelectedIndexChanged;
            // 
            // darkTextBoxShopeePayPin
            // 
            darkTextBoxShopeePayPin.Location=new Point(223, 131);
            darkTextBoxShopeePayPin.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkTextBoxShopeePayPin.MaxLength=6;
            darkTextBoxShopeePayPin.Name="darkTextBoxShopeePayPin";
            darkTextBoxShopeePayPin.Size=new Size(124, 22);
            darkTextBoxShopeePayPin.TabIndex=13;
            darkTextBoxShopeePayPin.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(darkTextBoxShopeePayPin, "ShopeePay PIN.");
            darkTextBoxShopeePayPin.KeyPress+=darkTextBoxWalletPin_KeyPress;
            // 
            // darkLabel6
            // 
            darkLabel6.AutoSize=true;
            darkLabel6.ForeColor=SystemColors.ControlText;
            darkLabel6.Location=new Point(17, 38);
            darkLabel6.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel6.Name="darkLabel6";
            darkLabel6.Size=new Size(99, 13);
            darkLabel6.TabIndex=14;
            darkLabel6.Text="Payment method :";
            // 
            // darkLabel7
            // 
            darkLabel7.AutoSize=true;
            darkLabel7.ForeColor=SystemColors.ControlText;
            darkLabel7.Location=new Point(17, 137);
            darkLabel7.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel7.Name="darkLabel7";
            darkLabel7.Size=new Size(89, 13);
            darkLabel7.TabIndex=15;
            darkLabel7.Text="ShopeePay PIN :";
            // 
            // darkComboBoxCourier
            // 
            darkComboBoxCourier.FormattingEnabled=true;
            darkComboBoxCourier.Items.AddRange(new object[] { "Default" });
            darkComboBoxCourier.Location=new Point(149, 35);
            darkComboBoxCourier.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkComboBoxCourier.Name="darkComboBoxCourier";
            darkComboBoxCourier.Size=new Size(126, 21);
            darkComboBoxCourier.TabIndex=16;
            // 
            // darkLabel9
            // 
            darkLabel9.AutoSize=true;
            darkLabel9.ForeColor=SystemColors.ControlText;
            darkLabel9.Location=new Point(17, 139);
            darkLabel9.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel9.Name="darkLabel9";
            darkLabel9.Size=new Size(59, 13);
            darkLabel9.TabIndex=19;
            darkLabel9.Text="Variation :";
            // 
            // darkTextBoxVariationString
            // 
            darkTextBoxVariationString.Location=new Point(98, 134);
            darkTextBoxVariationString.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkTextBoxVariationString.Name="darkTextBoxVariationString";
            darkTextBoxVariationString.Size=new Size(244, 22);
            darkTextBoxVariationString.TabIndex=18;
            darkTextBoxVariationString.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(darkTextBoxVariationString, "Product variant (if required). If the product have more than 1 variant (eg : Colour and Size), separate the variant with '|' character without space. For example : RED|XXL");
            // 
            // darkLabel10
            // 
            darkLabel10.AutoSize=true;
            darkLabel10.ForeColor=SystemColors.ControlText;
            darkLabel10.Location=new Point(17, 111);
            darkLabel10.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel10.Name="darkLabel10";
            darkLabel10.Size=new Size(57, 13);
            darkLabel10.TabIndex=21;
            darkLabel10.Text="Quantity :";
            // 
            // darkNumericUpDownProductQuantity
            // 
            darkNumericUpDownProductQuantity.BackColor=SystemColors.Window;
            darkNumericUpDownProductQuantity.ForeColor=SystemColors.ControlText;
            darkNumericUpDownProductQuantity.Location=new Point(98, 106);
            darkNumericUpDownProductQuantity.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkNumericUpDownProductQuantity.Maximum=new decimal(new int[] { 1000000000, 0, 0, 0 });
            darkNumericUpDownProductQuantity.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            darkNumericUpDownProductQuantity.Name="darkNumericUpDownProductQuantity";
            darkNumericUpDownProductQuantity.ReadOnly=true;
            darkNumericUpDownProductQuantity.Size=new Size(47, 22);
            darkNumericUpDownProductQuantity.TabIndex=20;
            toolTip1.SetToolTip(darkNumericUpDownProductQuantity, "Product quantity.");
            darkNumericUpDownProductQuantity.Value=new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // darkSectionPanelProductDetails
            // 
            darkSectionPanelProductDetails.Controls.Add(cbVariantPreSelected);
            darkSectionPanelProductDetails.Controls.Add(cbRandom);
            darkSectionPanelProductDetails.Controls.Add(darkLabel11);
            darkSectionPanelProductDetails.Controls.Add(darkTextBoxProductLink);
            darkSectionPanelProductDetails.Controls.Add(darkLabel10);
            darkSectionPanelProductDetails.Controls.Add(darkTextBoxVariationString);
            darkSectionPanelProductDetails.Controls.Add(darkNumericUpDownProductQuantity);
            darkSectionPanelProductDetails.Controls.Add(darkLabel9);
            darkSectionPanelProductDetails.Location=new Point(14, 301);
            darkSectionPanelProductDetails.Margin=new System.Windows.Forms.Padding(2);
            darkSectionPanelProductDetails.Name="darkSectionPanelProductDetails";
            darkSectionPanelProductDetails.Size=new Size(364, 195);
            darkSectionPanelProductDetails.TabIndex=23;
            darkSectionPanelProductDetails.TabStop=false;
            darkSectionPanelProductDetails.Text="Product Details";
            // 
            // cbVariantPreSelected
            // 
            cbVariantPreSelected.AutoSize=true;
            cbVariantPreSelected.Location=new Point(209, 162);
            cbVariantPreSelected.Margin=new System.Windows.Forms.Padding(2);
            cbVariantPreSelected.Name="cbVariantPreSelected";
            cbVariantPreSelected.Size=new Size(127, 17);
            cbVariantPreSelected.TabIndex=52;
            cbVariantPreSelected.Text="Variant pre selected";
            toolTip1.SetToolTip(cbVariantPreSelected, "Variant is pre selected when there are only 1 option left to choose. Tick this option to set the variant is pre selected.");
            cbVariantPreSelected.CheckedChanged+=cbVariantPreSelected_CheckedChanged;
            // 
            // cbRandom
            // 
            cbRandom.AutoSize=true;
            cbRandom.Location=new Point(98, 162);
            cbRandom.Margin=new System.Windows.Forms.Padding(2);
            cbRandom.Name="cbRandom";
            cbRandom.Size=new Size(107, 17);
            cbRandom.TabIndex=51;
            cbRandom.Text="Random variant";
            toolTip1.SetToolTip(cbRandom, "Enabling this option will let the progam to choose 1st variant available.");
            cbRandom.CheckedChanged+=cbRandom_CheckedChanged;
            // 
            // darkLabel11
            // 
            darkLabel11.AutoSize=true;
            darkLabel11.ForeColor=SystemColors.ControlText;
            darkLabel11.Location=new Point(17, 37);
            darkLabel11.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel11.Name="darkLabel11";
            darkLabel11.Size=new Size(75, 13);
            darkLabel11.TabIndex=24;
            darkLabel11.Text="Product link :";
            // 
            // darkTextBoxProductLink
            // 
            darkTextBoxProductLink.Location=new Point(98, 37);
            darkTextBoxProductLink.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkTextBoxProductLink.Multiline=true;
            darkTextBoxProductLink.Name="darkTextBoxProductLink";
            darkTextBoxProductLink.ScrollBars=System.Windows.Forms.ScrollBars.Vertical;
            darkTextBoxProductLink.Size=new Size(244, 62);
            darkTextBoxProductLink.TabIndex=23;
            toolTip1.SetToolTip(darkTextBoxProductLink, "Product link.");
            // 
            // darkCheckBoxClaimShopVoucher
            // 
            darkCheckBoxClaimShopVoucher.AutoSize=true;
            darkCheckBoxClaimShopVoucher.Location=new Point(11, 44);
            darkCheckBoxClaimShopVoucher.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxClaimShopVoucher.Name="darkCheckBoxClaimShopVoucher";
            darkCheckBoxClaimShopVoucher.Size=new Size(148, 17);
            darkCheckBoxClaimShopVoucher.TabIndex=50;
            darkCheckBoxClaimShopVoucher.Text="Claim any shop voucher";
            toolTip1.SetToolTip(darkCheckBoxClaimShopVoucher, "Enabling this will let bot claim any available shop voucher.");
            // 
            // darkCheckBoxTestMode
            // 
            darkCheckBoxTestMode.AutoSize=true;
            darkCheckBoxTestMode.Location=new Point(24, 185);
            darkCheckBoxTestMode.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxTestMode.Name="darkCheckBoxTestMode";
            darkCheckBoxTestMode.Size=new Size(78, 17);
            darkCheckBoxTestMode.TabIndex=49;
            darkCheckBoxTestMode.Text="Test mode";
            toolTip1.SetToolTip(darkCheckBoxTestMode, "Enabling this option will stop the autobuy process right before placing order. User may use this option to 'warm up' the bot.");
            // 
            // darkLabel14
            // 
            darkLabel14.AutoSize=true;
            darkLabel14.ForeColor=SystemColors.ControlText;
            darkLabel14.Location=new Point(17, 104);
            darkLabel14.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel14.Name="darkLabel14";
            darkLabel14.Size=new Size(171, 13);
            darkLabel14.TabIndex=51;
            darkLabel14.Text="Last 4 digit of debit/credit card :";
            // 
            // tbLast4Digit
            // 
            tbLast4Digit.Location=new Point(223, 99);
            tbLast4Digit.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbLast4Digit.MaxLength=4;
            tbLast4Digit.Name="tbLast4Digit";
            tbLast4Digit.Size=new Size(124, 22);
            tbLast4Digit.TabIndex=50;
            tbLast4Digit.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(tbLast4Digit, "Last 4 digit of debit/credit card to be used.");
            tbLast4Digit.KeyPress+=tbLast4Digit_KeyPress;
            // 
            // darkCheckBoxRedeemCoin
            // 
            darkCheckBoxRedeemCoin.AutoSize=true;
            darkCheckBoxRedeemCoin.Location=new Point(11, 110);
            darkCheckBoxRedeemCoin.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxRedeemCoin.Name="darkCheckBoxRedeemCoin";
            darkCheckBoxRedeemCoin.Size=new Size(92, 17);
            darkCheckBoxRedeemCoin.TabIndex=42;
            darkCheckBoxRedeemCoin.Text="Redeem coin";
            toolTip1.SetToolTip(darkCheckBoxRedeemCoin, "Enabling this let the bot redeem any available coin.");
            // 
            // darkComboBoxBankType
            // 
            darkComboBoxBankType.DropDownStyle=System.Windows.Forms.ComboBoxStyle.DropDownList;
            darkComboBoxBankType.FormattingEnabled=true;
            darkComboBoxBankType.Items.AddRange(new object[] { "Maybank2u", "CIMB Clicks", "Public Bank", "RHB Now", "Ambank", "MyBSN", "Bank Rakyat", "UOB", "Affin Bank", "Bank Islam", "HSBC Online", "Standard Chartered Bank", "Kuwait Finance House", "Bank Muamalat", "OCBC Online", "Alliance Bank (Personal)", "Hong Leong Connect" });
            darkComboBoxBankType.Location=new Point(154, 66);
            darkComboBoxBankType.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkComboBoxBankType.Name="darkComboBoxBankType";
            darkComboBoxBankType.Size=new Size(194, 21);
            darkComboBoxBankType.TabIndex=30;
            toolTip1.SetToolTip(darkComboBoxBankType, "Bank type.");
            // 
            // darkLabel8
            // 
            darkLabel8.AutoSize=true;
            darkLabel8.ForeColor=SystemColors.ControlText;
            darkLabel8.Location=new Point(17, 72);
            darkLabel8.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel8.Name="darkLabel8";
            darkLabel8.Size=new Size(63, 13);
            darkLabel8.TabIndex=31;
            darkLabel8.Text="Bank type :";
            // 
            // darkLabel12
            // 
            darkLabel12.AutoSize=true;
            darkLabel12.ForeColor=SystemColors.ControlText;
            darkLabel12.Location=new Point(49, 40);
            darkLabel12.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel12.Name="darkLabel12";
            darkLabel12.Size=new Size(51, 13);
            darkLabel12.TabIndex=28;
            darkLabel12.Text="Courier :";
            // 
            // darkSectionPanelLogs
            // 
            darkSectionPanelLogs.Controls.Add(darkButtonDeleteAllOrder);
            darkSectionPanelLogs.Controls.Add(richTextBoxLogs);
            darkSectionPanelLogs.Controls.Add(darkLabel12);
            darkSectionPanelLogs.Controls.Add(darkButton1);
            darkSectionPanelLogs.Controls.Add(darkButton4);
            darkSectionPanelLogs.Controls.Add(darkButton3);
            darkSectionPanelLogs.Controls.Add(darkComboBoxCourier);
            darkSectionPanelLogs.Controls.Add(darkButton2);
            darkSectionPanelLogs.Controls.Add(darkButton6);
            darkSectionPanelLogs.Location=new Point(14, 501);
            darkSectionPanelLogs.Margin=new System.Windows.Forms.Padding(2);
            darkSectionPanelLogs.Name="darkSectionPanelLogs";
            darkSectionPanelLogs.Size=new Size(312, 151);
            darkSectionPanelLogs.TabIndex=24;
            darkSectionPanelLogs.TabStop=false;
            darkSectionPanelLogs.Text="Logs";
            // 
            // darkButtonDeleteAllOrder
            // 
            darkButtonDeleteAllOrder.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            darkButtonDeleteAllOrder.Location=new Point(39, 85);
            darkButtonDeleteAllOrder.Margin=new System.Windows.Forms.Padding(2);
            darkButtonDeleteAllOrder.Name="darkButtonDeleteAllOrder";
            darkButtonDeleteAllOrder.Size=new Size(236, 42);
            darkButtonDeleteAllOrder.TabIndex=28;
            darkButtonDeleteAllOrder.Text="Delete all order (To pay)";
            darkButtonDeleteAllOrder.Visible=false;
            // 
            // richTextBoxLogs
            // 
            richTextBoxLogs.BackColor=SystemColors.Window;
            richTextBoxLogs.BorderStyle=System.Windows.Forms.BorderStyle.None;
            richTextBoxLogs.Dock=System.Windows.Forms.DockStyle.Fill;
            richTextBoxLogs.Location=new Point(3, 18);
            richTextBoxLogs.Margin=new System.Windows.Forms.Padding(2);
            richTextBoxLogs.Name="richTextBoxLogs";
            richTextBoxLogs.ReadOnly=true;
            richTextBoxLogs.ScrollBars=System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            richTextBoxLogs.Size=new Size(306, 130);
            richTextBoxLogs.TabIndex=0;
            richTextBoxLogs.Text="";
            toolTip1.SetToolTip(richTextBoxLogs, "Current running process will be displayed here.");
            richTextBoxLogs.TextChanged+=richTextBoxLogs_TextChanged;
            // 
            // darkButton1
            // 
            darkButton1.Location=new Point(170, 259);
            darkButton1.Margin=new System.Windows.Forms.Padding(2);
            darkButton1.Name="darkButton1";
            darkButton1.Size=new Size(104, 15);
            darkButton1.TabIndex=28;
            darkButton1.Text="Cancel All Order";
            darkButton1.Visible=false;
            darkButton1.Click+=darkButton1_Click;
            // 
            // darkButton4
            // 
            darkButton4.Location=new Point(50, 57);
            darkButton4.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkButton4.Name="darkButton4";
            darkButton4.Size=new Size(94, 23);
            darkButton4.TabIndex=29;
            darkButton4.Text="deliver anytime";
            darkButton4.Click+=darkButton4_Click;
            // 
            // darkButton3
            // 
            darkButton3.Location=new Point(181, 122);
            darkButton3.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkButton3.Name="darkButton3";
            darkButton3.Size=new Size(94, 23);
            darkButton3.TabIndex=28;
            darkButton3.Text="select poslaju";
            darkButton3.Click+=darkButton3_Click;
            // 
            // darkButton2
            // 
            darkButton2.Location=new Point(127, 35);
            darkButton2.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkButton2.Name="darkButton2";
            darkButton2.Size=new Size(94, 23);
            darkButton2.TabIndex=12;
            darkButton2.Text="change courier";
            darkButton2.Click+=darkButton2_Click;
            // 
            // darkButton6
            // 
            darkButton6.Font=new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            darkButton6.Location=new Point(205, 35);
            darkButton6.Margin=new System.Windows.Forms.Padding(2);
            darkButton6.Name="darkButton6";
            darkButton6.Size=new Size(101, 51);
            darkButton6.TabIndex=56;
            darkButton6.Text="Order Price";
            darkButton6.Click+=darkButton6_Click;
            // 
            // tbBelowSpecificPriceCARTCHECKOUTPrice
            // 
            tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled=false;
            tbBelowSpecificPriceCARTCHECKOUTPrice.Location=new Point(280, 93);
            tbBelowSpecificPriceCARTCHECKOUTPrice.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbBelowSpecificPriceCARTCHECKOUTPrice.Name="tbBelowSpecificPriceCARTCHECKOUTPrice";
            tbBelowSpecificPriceCARTCHECKOUTPrice.Size=new Size(67, 22);
            tbBelowSpecificPriceCARTCHECKOUTPrice.TabIndex=54;
            tbBelowSpecificPriceCARTCHECKOUTPrice.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            tbBelowSpecificPriceCARTCHECKOUTPrice.KeyPress+=tbCheckoutLinkPrice_KeyPress;
            tbBelowSpecificPriceCARTCHECKOUTPrice.Leave+=tbCheckoutLinkPrice_Leave;
            // 
            // radioButtonPriceSpecificCartCheckout
            // 
            radioButtonPriceSpecificCartCheckout.AutoSize=true;
            radioButtonPriceSpecificCartCheckout.ForeColor=SystemColors.ControlText;
            radioButtonPriceSpecificCartCheckout.Location=new Point(26, 96);
            radioButtonPriceSpecificCartCheckout.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonPriceSpecificCartCheckout.Name="radioButtonPriceSpecificCartCheckout";
            radioButtonPriceSpecificCartCheckout.Size=new Size(211, 17);
            radioButtonPriceSpecificCartCheckout.TabIndex=53;
            radioButtonPriceSpecificCartCheckout.Text="Below specific price (Cart checkout) :";
            toolTip1.SetToolTip(radioButtonPriceSpecificCartCheckout, "This option require user to get the unique checkout link and paste it in product link text box.");
            radioButtonPriceSpecificCartCheckout.CheckedChanged+=radioButtonPriceSpecificCheckoutLink_CheckedChanged;
            // 
            // darkButtonStart
            // 
            darkButtonStart.Font=new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            darkButtonStart.Location=new Point(528, 562);
            darkButtonStart.Margin=new System.Windows.Forms.Padding(2);
            darkButtonStart.Name="darkButtonStart";
            darkButtonStart.Size=new Size(233, 90);
            darkButtonStart.TabIndex=25;
            darkButtonStart.Text="Start";
            toolTip1.SetToolTip(darkButtonStart, "Start checkout.");
            darkButtonStart.Click+=darkButtonStart_Click;
            // 
            // timerlabelBig
            // 
            timerlabelBig.AutoSize=true;
            timerlabelBig.BackColor=Color.Transparent;
            timerlabelBig.Font=new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            timerlabelBig.ForeColor=Color.DimGray;
            timerlabelBig.Location=new Point(0, 0);
            timerlabelBig.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            timerlabelBig.Name="timerlabelBig";
            timerlabelBig.Size=new Size(177, 40);
            timerlabelBig.TabIndex=27;
            timerlabelBig.Text="00:00:00:00";
            timerlabelBig.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // darkSectionPanelBotSettings
            // 
            darkSectionPanelBotSettings.Controls.Add(checkBoxDesktopNotification);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxTestMode);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxLogging);
            darkSectionPanelBotSettings.Controls.Add(darkButton5);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxRefresh);
            darkSectionPanelBotSettings.Controls.Add(darkLabel5);
            darkSectionPanelBotSettings.Controls.Add(darkNumericUpDownTimeOut);
            darkSectionPanelBotSettings.Controls.Add(darkLabel4);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxNotifyTelegram);
            darkSectionPanelBotSettings.Controls.Add(darkNumericUpDownRefreshSeconds);
            darkSectionPanelBotSettings.Controls.Add(darkLabel13);
            darkSectionPanelBotSettings.Location=new Point(14, 43);
            darkSectionPanelBotSettings.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelBotSettings.Name="darkSectionPanelBotSettings";
            darkSectionPanelBotSettings.Size=new Size(364, 253);
            darkSectionPanelBotSettings.TabIndex=29;
            darkSectionPanelBotSettings.TabStop=false;
            darkSectionPanelBotSettings.Text="Bot Settings";
            // 
            // checkBoxDesktopNotification
            // 
            checkBoxDesktopNotification.AutoSize=true;
            checkBoxDesktopNotification.Location=new Point(24, 74);
            checkBoxDesktopNotification.Margin=new System.Windows.Forms.Padding(2);
            checkBoxDesktopNotification.Name="checkBoxDesktopNotification";
            checkBoxDesktopNotification.Size=new Size(285, 17);
            checkBoxDesktopNotification.TabIndex=54;
            checkBoxDesktopNotification.Text="Show desktop notification on successful checkout";
            // 
            // darkCheckBoxLogging
            // 
            darkCheckBoxLogging.AutoSize=true;
            darkCheckBoxLogging.Location=new Point(24, 148);
            darkCheckBoxLogging.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxLogging.Name="darkCheckBoxLogging";
            darkCheckBoxLogging.Size=new Size(108, 17);
            darkCheckBoxLogging.TabIndex=50;
            darkCheckBoxLogging.Text="Disable logging";
            toolTip1.SetToolTip(darkCheckBoxLogging, "Enabling this option will disable the current running process log in 'Logs' section.");
            // 
            // darkButton5
            // 
            darkButton5.Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            darkButton5.Location=new Point(190, 179);
            darkButton5.Margin=new System.Windows.Forms.Padding(2);
            darkButton5.Name="darkButton5";
            darkButton5.Size=new Size(146, 23);
            darkButton5.TabIndex=49;
            darkButton5.Text="ClearKeys cache";
            darkButton5.Visible=false;
            darkButton5.Click+=darkButton5_Click_1;
            // 
            // darkCheckBoxRefresh
            // 
            darkCheckBoxRefresh.AutoSize=true;
            darkCheckBoxRefresh.Location=new Point(24, 111);
            darkCheckBoxRefresh.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxRefresh.Name="darkCheckBoxRefresh";
            darkCheckBoxRefresh.Size=new Size(141, 17);
            darkCheckBoxRefresh.TabIndex=48;
            darkCheckBoxRefresh.Text="Auto refresh webpage";
            toolTip1.SetToolTip(darkCheckBoxRefresh, "Enabling this will automatically refresh webpage. ");
            // 
            // darkMenuStrip1
            // 
            darkMenuStrip1.BackColor=SystemColors.Control;
            darkMenuStrip1.ForeColor=SystemColors.ControlText;
            darkMenuStrip1.ImageScalingSize=new Size(24, 24);
            darkMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { gfrgToolStripMenuItem, helpToolStripMenuItem1, testToolStripMenuItem });
            darkMenuStrip1.Location=new Point(0, 0);
            darkMenuStrip1.Name="darkMenuStrip1";
            darkMenuStrip1.Padding=new System.Windows.Forms.Padding(2, 2, 0, 2);
            darkMenuStrip1.Size=new Size(776, 24);
            darkMenuStrip1.TabIndex=34;
            darkMenuStrip1.Text="darkMenuStrip1";
            // 
            // gfrgToolStripMenuItem
            // 
            gfrgToolStripMenuItem.BackColor=SystemColors.Control;
            gfrgToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { elementEditorToolStripMenuItem, scanSaleItemsToolStripMenuItem, profileToolStripMenuItem, sessionCookieToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem1, testCookieToolStripMenuItem });
            gfrgToolStripMenuItem.ForeColor=SystemColors.ControlText;
            gfrgToolStripMenuItem.Name="gfrgToolStripMenuItem";
            gfrgToolStripMenuItem.Size=new Size(37, 20);
            gfrgToolStripMenuItem.Text="File";
            // 
            // elementEditorToolStripMenuItem
            // 
            elementEditorToolStripMenuItem.BackColor=SystemColors.Control;
            elementEditorToolStripMenuItem.ForeColor=SystemColors.ControlText;
            elementEditorToolStripMenuItem.Name="elementEditorToolStripMenuItem";
            elementEditorToolStripMenuItem.Size=new Size(151, 22);
            elementEditorToolStripMenuItem.Text="Element editor";
            elementEditorToolStripMenuItem.Click+=elementEditorToolStripMenuItem_Click;
            // 
            // scanSaleItemsToolStripMenuItem
            // 
            scanSaleItemsToolStripMenuItem.BackColor=SystemColors.Control;
            scanSaleItemsToolStripMenuItem.ForeColor=SystemColors.ControlText;
            scanSaleItemsToolStripMenuItem.Name="scanSaleItemsToolStripMenuItem";
            scanSaleItemsToolStripMenuItem.Size=new Size(151, 22);
            scanSaleItemsToolStripMenuItem.Text="Scan sale item";
            scanSaleItemsToolStripMenuItem.Visible=false;
            scanSaleItemsToolStripMenuItem.Click+=scanSaleItemsToolStripMenuItem_Click;
            // 
            // profileToolStripMenuItem
            // 
            profileToolStripMenuItem.BackColor=SystemColors.Control;
            profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItemLoadProfile, saveCurrentProfileToolStripMenuItem });
            profileToolStripMenuItem.ForeColor=SystemColors.ControlText;
            profileToolStripMenuItem.Name="profileToolStripMenuItem";
            profileToolStripMenuItem.Size=new Size(151, 22);
            profileToolStripMenuItem.Text="Profile";
            // 
            // toolStripMenuItemLoadProfile
            // 
            toolStripMenuItemLoadProfile.BackColor=SystemColors.Control;
            toolStripMenuItemLoadProfile.ForeColor=SystemColors.ControlText;
            toolStripMenuItemLoadProfile.Name="toolStripMenuItemLoadProfile";
            toolStripMenuItemLoadProfile.Size=new Size(181, 22);
            toolStripMenuItemLoadProfile.Text="Load profile settings";
            toolStripMenuItemLoadProfile.Click+=toolStripMenuItemLoadProfile_Click;
            // 
            // saveCurrentProfileToolStripMenuItem
            // 
            saveCurrentProfileToolStripMenuItem.BackColor=SystemColors.Control;
            saveCurrentProfileToolStripMenuItem.ForeColor=SystemColors.ControlText;
            saveCurrentProfileToolStripMenuItem.Name="saveCurrentProfileToolStripMenuItem";
            saveCurrentProfileToolStripMenuItem.Size=new Size(181, 22);
            saveCurrentProfileToolStripMenuItem.Text="Save current profile";
            saveCurrentProfileToolStripMenuItem.Click+=saveCurrentProfileToolStripMenuItem_Click;
            // 
            // sessionCookieToolStripMenuItem
            // 
            sessionCookieToolStripMenuItem.BackColor=SystemColors.Control;
            sessionCookieToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { loadCookiesToolStripMenuItem, saveCookieToolStripMenuItem, cleToolStripMenuItem, testToolStripMenuItem1 });
            sessionCookieToolStripMenuItem.ForeColor=SystemColors.ControlText;
            sessionCookieToolStripMenuItem.Name="sessionCookieToolStripMenuItem";
            sessionCookieToolStripMenuItem.Size=new Size(151, 22);
            sessionCookieToolStripMenuItem.Text="Session cookie";
            sessionCookieToolStripMenuItem.Visible=false;
            // 
            // loadCookiesToolStripMenuItem
            // 
            loadCookiesToolStripMenuItem.BackColor=Color.Gainsboro;
            loadCookiesToolStripMenuItem.ForeColor=SystemColors.ControlText;
            loadCookiesToolStripMenuItem.Name="loadCookiesToolStripMenuItem";
            loadCookiesToolStripMenuItem.Size=new Size(139, 22);
            loadCookiesToolStripMenuItem.Text="Load cookie";
            loadCookiesToolStripMenuItem.Click+=loadCookiesToolStripMenuItem_Click;
            // 
            // saveCookieToolStripMenuItem
            // 
            saveCookieToolStripMenuItem.BackColor=Color.Gainsboro;
            saveCookieToolStripMenuItem.ForeColor=SystemColors.ControlText;
            saveCookieToolStripMenuItem.Name="saveCookieToolStripMenuItem";
            saveCookieToolStripMenuItem.Size=new Size(139, 22);
            saveCookieToolStripMenuItem.Text="Save cookie";
            saveCookieToolStripMenuItem.Click+=saveCookieToolStripMenuItem_Click;
            // 
            // cleToolStripMenuItem
            // 
            cleToolStripMenuItem.BackColor=Color.Gainsboro;
            cleToolStripMenuItem.ForeColor=SystemColors.ControlText;
            cleToolStripMenuItem.Name="cleToolStripMenuItem";
            cleToolStripMenuItem.Size=new Size(139, 22);
            cleToolStripMenuItem.Text="Clear cookie";
            cleToolStripMenuItem.Click+=cleToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem1
            // 
            testToolStripMenuItem1.BackColor=Color.Gainsboro;
            testToolStripMenuItem1.ForeColor=SystemColors.ControlText;
            testToolStripMenuItem1.Name="testToolStripMenuItem1";
            testToolStripMenuItem1.Size=new Size(139, 22);
            testToolStripMenuItem1.Text="Test";
            testToolStripMenuItem1.Click+=testToolStripMenuItem1_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.BackColor=SystemColors.Control;
            toolStripSeparator2.ForeColor=SystemColors.ControlText;
            toolStripSeparator2.Margin=new System.Windows.Forms.Padding(0, 0, 0, 1);
            toolStripSeparator2.Name="toolStripSeparator2";
            toolStripSeparator2.Size=new Size(148, 6);
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.BackColor=SystemColors.Control;
            exitToolStripMenuItem1.ForeColor=SystemColors.ControlText;
            exitToolStripMenuItem1.Name="exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size=new Size(151, 22);
            exitToolStripMenuItem1.Text="Exit";
            exitToolStripMenuItem1.Click+=exitToolStripMenuItem1_Click;
            // 
            // testCookieToolStripMenuItem
            // 
            testCookieToolStripMenuItem.BackColor=SystemColors.Control;
            testCookieToolStripMenuItem.ForeColor=SystemColors.ControlText;
            testCookieToolStripMenuItem.Name="testCookieToolStripMenuItem";
            testCookieToolStripMenuItem.Size=new Size(151, 22);
            testCookieToolStripMenuItem.Text="test cookie";
            testCookieToolStripMenuItem.Visible=false;
            testCookieToolStripMenuItem.Click+=testCookieToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.BackColor=SystemColors.Control;
            helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { updateConfigurationToolStripMenuItem1, toolStripSeparator1, aboutToolStripMenuItem, changeHistoryToolStripMenuItem });
            helpToolStripMenuItem1.ForeColor=SystemColors.ControlText;
            helpToolStripMenuItem1.Name="helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size=new Size(44, 20);
            helpToolStripMenuItem1.Text="Help";
            // 
            // updateConfigurationToolStripMenuItem1
            // 
            updateConfigurationToolStripMenuItem1.BackColor=SystemColors.Control;
            updateConfigurationToolStripMenuItem1.ForeColor=SystemColors.ControlText;
            updateConfigurationToolStripMenuItem1.Name="updateConfigurationToolStripMenuItem1";
            updateConfigurationToolStripMenuItem1.Size=new Size(219, 22);
            updateConfigurationToolStripMenuItem1.Text="Update configuration";
            updateConfigurationToolStripMenuItem1.Click+=updateConfigurationToolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.BackColor=SystemColors.Control;
            toolStripSeparator1.ForeColor=SystemColors.ControlText;
            toolStripSeparator1.Margin=new System.Windows.Forms.Padding(0, 0, 0, 1);
            toolStripSeparator1.Name="toolStripSeparator1";
            toolStripSeparator1.Size=new Size(216, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.BackColor=SystemColors.Control;
            aboutToolStripMenuItem.ForeColor=SystemColors.ControlText;
            aboutToolStripMenuItem.Name="aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size=new Size(219, 22);
            aboutToolStripMenuItem.Text="About Shopee Autobuy Bot";
            aboutToolStripMenuItem.Click+=aboutToolStripMenuItem_Click;
            // 
            // changeHistoryToolStripMenuItem
            // 
            changeHistoryToolStripMenuItem.BackColor=SystemColors.Control;
            changeHistoryToolStripMenuItem.ForeColor=SystemColors.ControlText;
            changeHistoryToolStripMenuItem.Name="changeHistoryToolStripMenuItem";
            changeHistoryToolStripMenuItem.Size=new Size(219, 22);
            changeHistoryToolStripMenuItem.Text="Changelog history";
            changeHistoryToolStripMenuItem.Click+=changeHistoryToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.BackColor=SystemColors.Control;
            testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { saveCookiesToolStripMenuItem, fontTestToolStripMenuItem, telegramToolStripMenuItem });
            testToolStripMenuItem.ForeColor=SystemColors.ControlText;
            testToolStripMenuItem.Name="testToolStripMenuItem";
            testToolStripMenuItem.Size=new Size(39, 20);
            testToolStripMenuItem.Text="Test";
            testToolStripMenuItem.Visible=false;
            // 
            // saveCookiesToolStripMenuItem
            // 
            saveCookiesToolStripMenuItem.BackColor=SystemColors.Control;
            saveCookiesToolStripMenuItem.ForeColor=SystemColors.ControlText;
            saveCookiesToolStripMenuItem.Name="saveCookiesToolStripMenuItem";
            saveCookiesToolStripMenuItem.Size=new Size(140, 22);
            saveCookiesToolStripMenuItem.Text="save cookies";
            saveCookiesToolStripMenuItem.Click+=saveCookiesToolStripMenuItem_Click;
            // 
            // fontTestToolStripMenuItem
            // 
            fontTestToolStripMenuItem.BackColor=SystemColors.Control;
            fontTestToolStripMenuItem.ForeColor=SystemColors.ControlText;
            fontTestToolStripMenuItem.Name="fontTestToolStripMenuItem";
            fontTestToolStripMenuItem.Size=new Size(140, 22);
            fontTestToolStripMenuItem.Text="font test";
            fontTestToolStripMenuItem.Click+=fontTestToolStripMenuItem_Click;
            // 
            // telegramToolStripMenuItem
            // 
            telegramToolStripMenuItem.Name="telegramToolStripMenuItem";
            telegramToolStripMenuItem.Size=new Size(140, 22);
            telegramToolStripMenuItem.Text="telegram";
            telegramToolStripMenuItem.Click+=telegramToolStripMenuItem_Click;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.BackColor=Color.Gainsboro;
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { UpgradeProToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor=SystemColors.ControlText;
            fileToolStripMenuItem.Name="fileToolStripMenuItem";
            fileToolStripMenuItem.Size=new Size(37, 20);
            fileToolStripMenuItem.Text="File";
            // 
            // UpgradeProToolStripMenuItem
            // 
            UpgradeProToolStripMenuItem.BackColor=Color.Gainsboro;
            UpgradeProToolStripMenuItem.ForeColor=SystemColors.ControlText;
            UpgradeProToolStripMenuItem.Name="UpgradeProToolStripMenuItem";
            UpgradeProToolStripMenuItem.Size=new Size(154, 22);
            UpgradeProToolStripMenuItem.Text="Upgrade to Pro";
            UpgradeProToolStripMenuItem.Visible=false;
            UpgradeProToolStripMenuItem.Click+=visitFacebookPageToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.BackColor=Color.Gainsboro;
            exitToolStripMenuItem.ForeColor=SystemColors.ControlText;
            exitToolStripMenuItem.Name="exitToolStripMenuItem";
            exitToolStripMenuItem.Size=new Size(154, 22);
            exitToolStripMenuItem.Text="Exit";
            exitToolStripMenuItem.Click+=exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.BackColor=Color.Gainsboro;
            helpToolStripMenuItem.ForeColor=SystemColors.ControlText;
            helpToolStripMenuItem.Name="helpToolStripMenuItem";
            helpToolStripMenuItem.Size=new Size(44, 20);
            helpToolStripMenuItem.Text="Help";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.BackColor=Color.Gainsboro;
            aboutToolStripMenuItem1.ForeColor=SystemColors.ControlText;
            aboutToolStripMenuItem1.Name="aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size=new Size(187, 22);
            aboutToolStripMenuItem1.Text="About";
            aboutToolStripMenuItem1.Click+=aboutToolStripMenuItem1_Click;
            // 
            // changelogHistoryToolStripMenuItem
            // 
            changelogHistoryToolStripMenuItem.BackColor=Color.Gainsboro;
            changelogHistoryToolStripMenuItem.ForeColor=SystemColors.ControlText;
            changelogHistoryToolStripMenuItem.Name="changelogHistoryToolStripMenuItem";
            changelogHistoryToolStripMenuItem.Size=new Size(187, 22);
            changelogHistoryToolStripMenuItem.Text="Change history";
            changelogHistoryToolStripMenuItem.Click+=changelogHistoryToolStripMenuItem_Click;
            // 
            // disclaimerToolStripMenuItem
            // 
            disclaimerToolStripMenuItem.BackColor=Color.Gainsboro;
            disclaimerToolStripMenuItem.ForeColor=SystemColors.ControlText;
            disclaimerToolStripMenuItem.Name="disclaimerToolStripMenuItem";
            disclaimerToolStripMenuItem.Size=new Size(187, 22);
            disclaimerToolStripMenuItem.Text="Disclaimer";
            disclaimerToolStripMenuItem.Visible=false;
            disclaimerToolStripMenuItem.Click+=disclaimerToolStripMenuItem_Click;
            // 
            // howToUseToolStripMenuItem
            // 
            howToUseToolStripMenuItem.BackColor=Color.Gainsboro;
            howToUseToolStripMenuItem.ForeColor=SystemColors.ControlText;
            howToUseToolStripMenuItem.Name="howToUseToolStripMenuItem";
            howToUseToolStripMenuItem.Size=new Size(187, 22);
            howToUseToolStripMenuItem.Text="How to use";
            // 
            // updateConfigurationToolStripMenuItem
            // 
            updateConfigurationToolStripMenuItem.BackColor=Color.Gainsboro;
            updateConfigurationToolStripMenuItem.ForeColor=SystemColors.ControlText;
            updateConfigurationToolStripMenuItem.Name="updateConfigurationToolStripMenuItem";
            updateConfigurationToolStripMenuItem.Size=new Size(187, 22);
            updateConfigurationToolStripMenuItem.Text="Update configuration";
            updateConfigurationToolStripMenuItem.Click+=updateConfigurationToolStripMenuItem_Click;
            // 
            // darkSectionPanelBuyingMode
            // 
            darkSectionPanelBuyingMode.Controls.Add(tbBelowSpecificPriceCARTCHECKOUTPrice);
            darkSectionPanelBuyingMode.Controls.Add(tbPriceSpecific);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonPriceSpecificCartCheckout);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonCheckOutCart);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonShockingSale);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonBuyNormal);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonPriceSpecific);
            darkSectionPanelBuyingMode.Location=new Point(384, 170);
            darkSectionPanelBuyingMode.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelBuyingMode.Name="darkSectionPanelBuyingMode";
            darkSectionPanelBuyingMode.Size=new Size(376, 126);
            darkSectionPanelBuyingMode.TabIndex=50;
            darkSectionPanelBuyingMode.TabStop=false;
            darkSectionPanelBuyingMode.Text="Buy Mode";
            darkSectionPanelBuyingMode.Click+=darkSectionPanelBuyingMode_Click;
            // 
            // tbPriceSpecific
            // 
            tbPriceSpecific.Enabled=false;
            tbPriceSpecific.Location=new Point(280, 63);
            tbPriceSpecific.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbPriceSpecific.Name="tbPriceSpecific";
            tbPriceSpecific.Size=new Size(67, 22);
            tbPriceSpecific.TabIndex=50;
            tbPriceSpecific.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            tbPriceSpecific.KeyPress+=darkTextBox1_KeyPress;
            tbPriceSpecific.Leave+=tbPriceSpecific_Leave;
            // 
            // radioButtonCheckOutCart
            // 
            radioButtonCheckOutCart.AutoSize=true;
            radioButtonCheckOutCart.ForeColor=SystemColors.ControlText;
            radioButtonCheckOutCart.Location=new Point(26, 66);
            radioButtonCheckOutCart.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonCheckOutCart.Name="radioButtonCheckOutCart";
            radioButtonCheckOutCart.Size=new Size(96, 17);
            radioButtonCheckOutCart.TabIndex=52;
            radioButtonCheckOutCart.Text="Cart checkout";
            toolTip1.SetToolTip(radioButtonCheckOutCart, "To use this option, user need to manually add items into cart. When Start button clicked, the checkout process is start from cart page thus lower checkout time.");
            radioButtonCheckOutCart.CheckedChanged+=radioButtonCheckOutCart_CheckedChanged;
            // 
            // radioButtonShockingSale
            // 
            radioButtonShockingSale.AutoSize=true;
            radioButtonShockingSale.ForeColor=SystemColors.ControlText;
            radioButtonShockingSale.Location=new Point(145, 36);
            radioButtonShockingSale.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonShockingSale.Name="radioButtonShockingSale";
            radioButtonShockingSale.Size=new Size(159, 17);
            radioButtonShockingSale.TabIndex=51;
            radioButtonShockingSale.Text="Flash/Shocking sale mode";
            toolTip1.SetToolTip(radioButtonShockingSale, "For this option, bot will only start checkout process if the item is in the shocking/flash sale period.");
            // 
            // radioButtonBuyNormal
            // 
            radioButtonBuyNormal.AutoSize=true;
            radioButtonBuyNormal.Checked=true;
            radioButtonBuyNormal.ForeColor=SystemColors.ControlText;
            radioButtonBuyNormal.Location=new Point(26, 36);
            radioButtonBuyNormal.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonBuyNormal.Name="radioButtonBuyNormal";
            radioButtonBuyNormal.Size=new Size(94, 17);
            radioButtonBuyNormal.TabIndex=50;
            radioButtonBuyNormal.TabStop=true;
            radioButtonBuyNormal.Text="Normal mode";
            toolTip1.SetToolTip(radioButtonBuyNormal, "Normal Mode.");
            // 
            // radioButtonPriceSpecific
            // 
            radioButtonPriceSpecific.AutoSize=true;
            radioButtonPriceSpecific.ForeColor=SystemColors.ControlText;
            radioButtonPriceSpecific.Location=new Point(146, 66);
            radioButtonPriceSpecific.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonPriceSpecific.Name="radioButtonPriceSpecific";
            radioButtonPriceSpecific.Size=new Size(131, 17);
            radioButtonPriceSpecific.TabIndex=15;
            radioButtonPriceSpecific.Text="Below specific price :";
            toolTip1.SetToolTip(radioButtonPriceSpecific, "This option let the user choose which price they want bot to start checkout. Bot will only start checkout process once product's price is lower than the price set by user.");
            radioButtonPriceSpecific.CheckedChanged+=radioButtonPriceSpecific_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.BackColor=Color.Transparent;
            label1.Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor=Color.DimGray;
            label1.Location=new Point(545, 506);
            label1.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name="label1";
            label1.Size=new Size(31, 13);
            label1.TabIndex=51;
            label1.Text="Days";
            label1.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.BackColor=Color.Transparent;
            label2.Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor=Color.DimGray;
            label2.Location=new Point(599, 506);
            label2.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name="label2";
            label2.Size=new Size(33, 13);
            label2.TabIndex=52;
            label2.Text="Hour";
            label2.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.BackColor=Color.Transparent;
            label3.Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor=Color.DimGray;
            label3.Location=new Point(647, 506);
            label3.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name="label3";
            label3.Size=new Size(44, 13);
            label3.TabIndex=53;
            label3.Text="Minute";
            label3.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.BackColor=Color.Transparent;
            label4.Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor=Color.DimGray;
            label4.Location=new Point(701, 506);
            label4.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name="label4";
            label4.Size=new Size(45, 13);
            label4.TabIndex=54;
            label4.Text="Second";
            label4.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // darkSectionPanelPaymentDetails
            // 
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel14);
            darkSectionPanelPaymentDetails.Controls.Add(tbLast4Digit);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel6);
            darkSectionPanelPaymentDetails.Controls.Add(darkComboBoxPaymentMethod);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel8);
            darkSectionPanelPaymentDetails.Controls.Add(darkComboBoxBankType);
            darkSectionPanelPaymentDetails.Controls.Add(darkTextBoxShopeePayPin);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel7);
            darkSectionPanelPaymentDetails.Location=new Point(384, 301);
            darkSectionPanelPaymentDetails.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelPaymentDetails.Name="darkSectionPanelPaymentDetails";
            darkSectionPanelPaymentDetails.Size=new Size(376, 195);
            darkSectionPanelPaymentDetails.TabIndex=55;
            darkSectionPanelPaymentDetails.TabStop=false;
            darkSectionPanelPaymentDetails.Text="Payment Details";
            // 
            // darkCheckBoxRedeemShopeeVoucher
            // 
            darkCheckBoxRedeemShopeeVoucher.AutoSize=true;
            darkCheckBoxRedeemShopeeVoucher.Location=new Point(11, 77);
            darkCheckBoxRedeemShopeeVoucher.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxRedeemShopeeVoucher.Name="darkCheckBoxRedeemShopeeVoucher";
            darkCheckBoxRedeemShopeeVoucher.Size=new Size(174, 17);
            darkCheckBoxRedeemShopeeVoucher.TabIndex=52;
            darkCheckBoxRedeemShopeeVoucher.Text="Redeem any Shopee voucher";
            toolTip1.SetToolTip(darkCheckBoxRedeemShopeeVoucher, "Enabling this will let bot claim any available Shopee voucher.");
            // 
            // darkButton7
            // 
            darkButton7.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            darkButton7.Location=new Point(502, 626);
            darkButton7.Margin=new System.Windows.Forms.Padding(2);
            darkButton7.Name="darkButton7";
            darkButton7.Size=new Size(259, 26);
            darkButton7.TabIndex=56;
            darkButton7.Text="Copy logs to clipboard";
            toolTip1.SetToolTip(darkButton7, "Copy logs to clipboard");
            darkButton7.Visible=false;
            darkButton7.Click+=darkButton7_Click;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(darkCheckBoxRedeemShopeeVoucher);
            darkSectionPanel1.Controls.Add(darkCheckBoxClaimShopVoucher);
            darkSectionPanel1.Controls.Add(darkCheckBoxRedeemCoin);
            darkSectionPanel1.Location=new Point(331, 501);
            darkSectionPanel1.Name="darkSectionPanel1";
            darkSectionPanel1.Size=new Size(192, 151);
            darkSectionPanel1.TabIndex=57;
            darkSectionPanel1.TabStop=false;
            darkSectionPanel1.Text="Voucher && coin";
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text="notifyIcon1";
            notifyIcon1.Visible=true;
            // 
            // panel1
            // 
            panel1.Controls.Add(timerlabelBig);
            panel1.ForeColor=Color.DimGray;
            panel1.Location=new Point(558, 518);
            panel1.Name="panel1";
            panel1.Size=new Size(177, 40);
            panel1.TabIndex=53;
            // 
            // darkLabel15
            // 
            darkLabel15.AutoSize=true;
            darkLabel15.ForeColor=SystemColors.ControlText;
            darkLabel15.Location=new Point(547, 7);
            darkLabel15.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel15.Name="darkLabel15";
            darkLabel15.Size=new Size(94, 13);
            darkLabel15.TabIndex=58;
            darkLabel15.Text="Shopee Account:";
            darkLabel15.Visible=false;
            // 
            // labelShopeeAcc
            // 
            labelShopeeAcc.AutoSize=true;
            labelShopeeAcc.ForeColor=SystemColors.ControlText;
            labelShopeeAcc.Location=new Point(641, 7);
            labelShopeeAcc.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelShopeeAcc.Name="labelShopeeAcc";
            labelShopeeAcc.Size=new Size(16, 13);
            labelShopeeAcc.TabIndex=59;
            labelShopeeAcc.Text="...";
            labelShopeeAcc.Visible=false;
            // 
            // Main
            // 
            AutoScaleDimensions=new SizeF(6F, 13F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            BackColor=SystemColors.ActiveCaption;
            ClientSize=new Size(776, 666);
            Controls.Add(labelShopeeAcc);
            Controls.Add(darkLabel15);
            Controls.Add(panel1);
            Controls.Add(darkSectionPanel1);
            Controls.Add(darkSectionPanelPaymentDetails);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(darkSectionPanelBuyingMode);
            Controls.Add(darkMenuStrip1);
            Controls.Add(darkSectionPanelBotSettings);
            Controls.Add(darkButtonStart);
            Controls.Add(darkSectionPanelLogs);
            Controls.Add(darkSectionPanelProductDetails);
            Controls.Add(darkSectionPanelTimerMode);
            Controls.Add(darkButton7);
            Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon=(Icon)resources.GetObject("$this.Icon");
            Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            MaximizeBox=false;
            MinimumSize=new Size(570, 56);
            Name="Main";
            SizeGripStyle=System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Text="Shopee Autobuy Bot";
            FormClosing+=Form1_FormClosing;
            Load+=Form1_Load;
            darkSectionPanelTimerMode.ResumeLayout(false);
            darkSectionPanelTimerMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownCountDownSecond).EndInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownCountdownMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownCountdownHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownTimeOut).EndInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownRefreshSeconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)darkNumericUpDownProductQuantity).EndInit();
            darkSectionPanelProductDetails.ResumeLayout(false);
            darkSectionPanelProductDetails.PerformLayout();
            darkSectionPanelLogs.ResumeLayout(false);
            darkSectionPanelLogs.PerformLayout();
            darkSectionPanelBotSettings.ResumeLayout(false);
            darkSectionPanelBotSettings.PerformLayout();
            darkMenuStrip1.ResumeLayout(false);
            darkMenuStrip1.PerformLayout();
            darkSectionPanelBuyingMode.ResumeLayout(false);
            darkSectionPanelBuyingMode.PerformLayout();
            darkSectionPanelPaymentDetails.ResumeLayout(false);
            darkSectionPanelPaymentDetails.PerformLayout();
            darkSectionPanel1.ResumeLayout(false);
            darkSectionPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private System.Windows.Forms.ComboBox darkComboBoxPaymentMethod;
        private System.Windows.Forms.ComboBox darkComboBoxCourier;
        private System.Windows.Forms.Label darkLabel7;
        private System.Windows.Forms.TextBox darkTextBoxVariationString;
        private System.Windows.Forms.GroupBox darkSectionPanelProductDetails;
        private System.Windows.Forms.Label darkLabel12;
        private System.Windows.Forms.Label darkLabel11;
        private System.Windows.Forms.TextBox darkTextBoxProductLink;
        private System.Windows.Forms.Label darkLabel10;
        private System.Windows.Forms.NumericUpDown darkNumericUpDownProductQuantity;
        private System.Windows.Forms.Label darkLabel6;
        private System.Windows.Forms.TextBox darkTextBoxShopeePayPin;
        private System.Windows.Forms.Label darkLabel9;
        private System.Windows.Forms.RichTextBox richTextBoxLogs;
        private System.Windows.Forms.Button darkButton1;
        private System.Windows.Forms.Button darkButton4;
        private System.Windows.Forms.Button darkButton3;
        private System.Windows.Forms.Button darkButton2;
        private System.Windows.Forms.Button darkButtonStart;
        private System.Windows.Forms.GroupBox darkSectionPanelLogs;
        private System.Windows.Forms.CheckBox darkCheckBoxNotifyTelegram;
        private System.Windows.Forms.Label darkLabel5;
        private System.Windows.Forms.Label darkLabel4;
        private System.Windows.Forms.NumericUpDown darkNumericUpDownRefreshSeconds;
        private System.Windows.Forms.Label darkLabel2;
        private System.Windows.Forms.Label darkLabel1;
        private System.Windows.Forms.NumericUpDown darkNumericUpDownCountdownMinutes;
        private System.Windows.Forms.NumericUpDown darkNumericUpDownCountdownHour;
        private System.Windows.Forms.Label timerlabelBig;
        private System.Windows.Forms.GroupBox darkSectionPanelTimerMode;
        private System.Windows.Forms.ComboBox darkComboBoxBankType;
        private System.Windows.Forms.Label darkLabel8;
        private System.Windows.Forms.NumericUpDown darkNumericUpDownTimeOut;
        private System.Windows.Forms.Label darkLabel13;
        private System.Windows.Forms.CheckBox darkCheckBoxRedeemCoin;
        private System.Windows.Forms.Button darkButtonDeleteAllOrder;
        private System.Windows.Forms.GroupBox darkSectionPanelBotSettings;
        private System.Windows.Forms.CheckBox darkCheckBoxRefresh;
        private System.Windows.Forms.MenuStrip darkMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpgradeProToolStripMenuItem;
        private System.Windows.Forms.Label darkLabel3;
        private System.Windows.Forms.NumericUpDown darkNumericUpDownCountDownSecond;
        private System.Windows.Forms.CheckBox darkCheckBoxTestMode;
        private System.Windows.Forms.GroupBox darkSectionPanelBuyingMode;
        private System.Windows.Forms.RadioButton radioButtonBuyNormal;
        private System.Windows.Forms.RadioButton radioButtonPriceSpecific;
        private System.Windows.Forms.RadioButton radioButtonShockingSale;
        private System.Windows.Forms.RadioButton radioButtonCheckOutCart;
        private System.Windows.Forms.TextBox tbPriceSpecific;
        private System.Windows.Forms.CheckBox darkCheckBoxScheduleBot;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disclaimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.CheckBox darkCheckBoxTomorrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem updateConfigurationToolStripMenuItem;
        private System.Windows.Forms.Label darkLabel14;
        private System.Windows.Forms.TextBox tbLast4Digit;
        private System.Windows.Forms.Button darkButton5;
        private System.Windows.Forms.CheckBox darkCheckBoxLogging;
        private System.Windows.Forms.ToolStripMenuItem gfrgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateConfigurationToolStripMenuItem1;
        private System.Windows.Forms.GroupBox darkSectionPanelPaymentDetails;
        private System.Windows.Forms.Button darkButton6;
        private System.Windows.Forms.CheckBox darkCheckBoxRedeemShopeeVoucher;
        private System.Windows.Forms.CheckBox darkCheckBoxClaimShopVoucher;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbBelowSpecificPriceCARTCHECKOUTPrice;
        private System.Windows.Forms.RadioButton radioButtonPriceSpecificCartCheckout;
        private System.Windows.Forms.Button darkButton7;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCookiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanSaleItemsToolStripMenuItem;
        private System.Windows.Forms.GroupBox darkSectionPanel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem testCookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elementEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fontTestToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbRandom;
        private System.Windows.Forms.Label darkLabel15;
        private System.Windows.Forms.Label labelShopeeAcc;
        private System.Windows.Forms.ToolStripMenuItem sessionCookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCookiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCookieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadProfile;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentProfileToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbVariantPreSelected;
        private System.Windows.Forms.ToolStripMenuItem telegramToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxDesktopNotification;
    }
}

