namespace Shopee_Autobuy_Bot
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.btnLoadProfile = new DarkUI.Controls.DarkButton();
            this.btnDeleteProfile = new DarkUI.Controls.DarkButton();
            this.darkLabel1 = new DarkUI.Controls.DarkLabel();
            this.darkComboBoxProfile = new DarkUI.Controls.DarkComboBox();
            this.darkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.darkCheckBoxRedeemShopeeVoucher = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxClaimShopVoucher = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxRedeemCoin = new DarkUI.Controls.DarkCheckBox();
            this.darkSectionPanelPaymentDetails = new DarkUI.Controls.DarkSectionPanel();
            this.tbPaymentMethod = new DarkUI.Controls.DarkTextBox();
            this.tbBankType = new DarkUI.Controls.DarkTextBox();
            this.darkLabel14 = new DarkUI.Controls.DarkLabel();
            this.tbLast4Digit = new DarkUI.Controls.DarkTextBox();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.darkTextBoxShopeePayPin = new DarkUI.Controls.DarkTextBox();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanelBuyingMode = new DarkUI.Controls.DarkSectionPanel();
            this.tbBelowSpecificPriceCARTCHECKOUTPrice = new DarkUI.Controls.DarkTextBox();
            this.tbPriceSpecific = new DarkUI.Controls.DarkTextBox();
            this.radioButtonPriceSpecificCARTCHECKOUT = new System.Windows.Forms.RadioButton();
            this.radioButtonCheckOutCart = new System.Windows.Forms.RadioButton();
            this.radioButtonShockingSale = new System.Windows.Forms.RadioButton();
            this.radioButtonBuyNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonPriceSpecific = new System.Windows.Forms.RadioButton();
            this.darkSectionPanelBotSettings = new DarkUI.Controls.DarkSectionPanel();
            this.tbTimeOut = new DarkUI.Controls.DarkTextBox();
            this.tbRefreshSecond = new DarkUI.Controls.DarkTextBox();
            this.darkCheckBoxTestMode = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxLogging = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxRefresh = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxHeadless = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel5 = new DarkUI.Controls.DarkLabel();
            this.darkLabel4 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBoxPlaySound = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel13 = new DarkUI.Controls.DarkLabel();
            this.darkCheckBoxDisableImageExtension = new DarkUI.Controls.DarkCheckBox();
            this.darkSectionPanelProductDetails = new DarkUI.Controls.DarkSectionPanel();
            this.tbQuality = new DarkUI.Controls.DarkTextBox();
            this.darkLabel11 = new DarkUI.Controls.DarkLabel();
            this.darkTextBoxProductLink = new DarkUI.Controls.DarkTextBox();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.darkTextBoxVariationString = new DarkUI.Controls.DarkTextBox();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanelTimerMode = new DarkUI.Controls.DarkSectionPanel();
            this.tbCountdownSeconds = new DarkUI.Controls.DarkTextBox();
            this.tbCountdownMinutes = new DarkUI.Controls.DarkTextBox();
            this.tbCountdownHour = new DarkUI.Controls.DarkTextBox();
            this.darkCheckBoxTomorrow = new DarkUI.Controls.DarkCheckBox();
            this.darkCheckBoxScheduleBot = new DarkUI.Controls.DarkCheckBox();
            this.darkLabel3 = new DarkUI.Controls.DarkLabel();
            this.darkLabel2 = new DarkUI.Controls.DarkLabel();
            this.darkLabel12 = new DarkUI.Controls.DarkLabel();
            this.darkSectionPanel1.SuspendLayout();
            this.darkSectionPanelPaymentDetails.SuspendLayout();
            this.darkSectionPanelBuyingMode.SuspendLayout();
            this.darkSectionPanelBotSettings.SuspendLayout();
            this.darkSectionPanelProductDetails.SuspendLayout();
            this.darkSectionPanelTimerMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadProfile
            // 
            this.btnLoadProfile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadProfile.Location = new System.Drawing.Point(532, 13);
            this.btnLoadProfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadProfile.Name = "btnLoadProfile";
            this.btnLoadProfile.Size = new System.Drawing.Size(123, 24);
            this.btnLoadProfile.TabIndex = 103;
            this.btnLoadProfile.Text = "Load profile";
            this.btnLoadProfile.Click += new System.EventHandler(this.btnLoadProfile_Click);
            // 
            // btnDeleteProfile
            // 
            this.btnDeleteProfile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProfile.Location = new System.Drawing.Point(665, 13);
            this.btnDeleteProfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(123, 24);
            this.btnDeleteProfile.TabIndex = 104;
            this.btnDeleteProfile.Text = "Delete profile";
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            // 
            // darkLabel1
            // 
            this.darkLabel1.AutoSize = true;
            this.darkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel1.Location = new System.Drawing.Point(185, 18);
            this.darkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel1.Name = "darkLabel1";
            this.darkLabel1.Size = new System.Drawing.Size(78, 15);
            this.darkLabel1.TabIndex = 108;
            this.darkLabel1.Text = "Select profile:";
            // 
            // darkComboBoxProfile
            // 
            this.darkComboBoxProfile.FormattingEnabled = true;
            this.darkComboBoxProfile.Location = new System.Drawing.Point(273, 13);
            this.darkComboBoxProfile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkComboBoxProfile.Name = "darkComboBoxProfile";
            this.darkComboBoxProfile.Size = new System.Drawing.Size(249, 24);
            this.darkComboBoxProfile.TabIndex = 107;
            this.darkComboBoxProfile.SelectedIndexChanged += new System.EventHandler(this.darkComboBoxProfile_SelectedIndexChanged);
            // 
            // darkSectionPanel1
            // 
            this.darkSectionPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanel1.Controls.Add(this.darkCheckBoxRedeemShopeeVoucher);
            this.darkSectionPanel1.Controls.Add(this.darkCheckBoxClaimShopVoucher);
            this.darkSectionPanel1.Controls.Add(this.darkCheckBoxRedeemCoin);
            this.darkSectionPanel1.Location = new System.Drawing.Point(765, 50);
            this.darkSectionPanel1.Name = "darkSectionPanel1";
            this.darkSectionPanel1.SectionHeader = "Voucher & coin";
            this.darkSectionPanel1.Size = new System.Drawing.Size(192, 151);
            this.darkSectionPanel1.TabIndex = 114;
            // 
            // darkCheckBoxRedeemShopeeVoucher
            // 
            this.darkCheckBoxRedeemShopeeVoucher.AutoSize = true;
            this.darkCheckBoxRedeemShopeeVoucher.Enabled = false;
            this.darkCheckBoxRedeemShopeeVoucher.Location = new System.Drawing.Point(11, 77);
            this.darkCheckBoxRedeemShopeeVoucher.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxRedeemShopeeVoucher.Name = "darkCheckBoxRedeemShopeeVoucher";
            this.darkCheckBoxRedeemShopeeVoucher.Size = new System.Drawing.Size(179, 19);
            this.darkCheckBoxRedeemShopeeVoucher.TabIndex = 52;
            this.darkCheckBoxRedeemShopeeVoucher.Text = "Redeem any Shopee voucher";
            // 
            // darkCheckBoxClaimShopVoucher
            // 
            this.darkCheckBoxClaimShopVoucher.AutoSize = true;
            this.darkCheckBoxClaimShopVoucher.Enabled = false;
            this.darkCheckBoxClaimShopVoucher.Location = new System.Drawing.Point(11, 44);
            this.darkCheckBoxClaimShopVoucher.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxClaimShopVoucher.Name = "darkCheckBoxClaimShopVoucher";
            this.darkCheckBoxClaimShopVoucher.Size = new System.Drawing.Size(154, 19);
            this.darkCheckBoxClaimShopVoucher.TabIndex = 50;
            this.darkCheckBoxClaimShopVoucher.Text = "Claim any shop voucher";
            // 
            // darkCheckBoxRedeemCoin
            // 
            this.darkCheckBoxRedeemCoin.AutoSize = true;
            this.darkCheckBoxRedeemCoin.Enabled = false;
            this.darkCheckBoxRedeemCoin.Location = new System.Drawing.Point(11, 110);
            this.darkCheckBoxRedeemCoin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxRedeemCoin.Name = "darkCheckBoxRedeemCoin";
            this.darkCheckBoxRedeemCoin.Size = new System.Drawing.Size(95, 19);
            this.darkCheckBoxRedeemCoin.TabIndex = 42;
            this.darkCheckBoxRedeemCoin.Text = "Redeem coin";
            // 
            // darkSectionPanelPaymentDetails
            // 
            this.darkSectionPanelPaymentDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelPaymentDetails.Controls.Add(this.tbPaymentMethod);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.tbBankType);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel14);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.tbLast4Digit);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel6);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel8);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkTextBoxShopeePayPin);
            this.darkSectionPanelPaymentDetails.Controls.Add(this.darkLabel7);
            this.darkSectionPanelPaymentDetails.Location = new System.Drawing.Point(384, 308);
            this.darkSectionPanelPaymentDetails.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelPaymentDetails.Name = "darkSectionPanelPaymentDetails";
            this.darkSectionPanelPaymentDetails.SectionHeader = "Payment Details";
            this.darkSectionPanelPaymentDetails.Size = new System.Drawing.Size(376, 195);
            this.darkSectionPanelPaymentDetails.TabIndex = 113;
            // 
            // tbPaymentMethod
            // 
            this.tbPaymentMethod.Enabled = false;
            this.tbPaymentMethod.Location = new System.Drawing.Point(145, 44);
            this.tbPaymentMethod.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbPaymentMethod.MaxLength = 4;
            this.tbPaymentMethod.Name = "tbPaymentMethod";
            this.tbPaymentMethod.Size = new System.Drawing.Size(202, 23);
            this.tbPaymentMethod.TabIndex = 53;
            this.tbPaymentMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBankType
            // 
            this.tbBankType.Enabled = false;
            this.tbBankType.Location = new System.Drawing.Point(145, 78);
            this.tbBankType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbBankType.MaxLength = 4;
            this.tbBankType.Name = "tbBankType";
            this.tbBankType.Size = new System.Drawing.Size(202, 23);
            this.tbBankType.TabIndex = 52;
            this.tbBankType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel14
            // 
            this.darkLabel14.AutoSize = true;
            this.darkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel14.Location = new System.Drawing.Point(17, 114);
            this.darkLabel14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel14.Name = "darkLabel14";
            this.darkLabel14.Size = new System.Drawing.Size(175, 15);
            this.darkLabel14.TabIndex = 51;
            this.darkLabel14.Text = "Last 4 digit of debit/credit card :";
            // 
            // tbLast4Digit
            // 
            this.tbLast4Digit.Enabled = false;
            this.tbLast4Digit.Location = new System.Drawing.Point(223, 109);
            this.tbLast4Digit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbLast4Digit.MaxLength = 4;
            this.tbLast4Digit.Name = "tbLast4Digit";
            this.tbLast4Digit.Size = new System.Drawing.Size(124, 23);
            this.tbLast4Digit.TabIndex = 50;
            this.tbLast4Digit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(17, 48);
            this.darkLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(105, 15);
            this.darkLabel6.TabIndex = 14;
            this.darkLabel6.Text = "Payment Method :";
            // 
            // darkLabel8
            // 
            this.darkLabel8.AutoSize = true;
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(17, 82);
            this.darkLabel8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(65, 15);
            this.darkLabel8.TabIndex = 31;
            this.darkLabel8.Text = "Bank type :";
            // 
            // darkTextBoxShopeePayPin
            // 
            this.darkTextBoxShopeePayPin.Enabled = false;
            this.darkTextBoxShopeePayPin.Location = new System.Drawing.Point(223, 141);
            this.darkTextBoxShopeePayPin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkTextBoxShopeePayPin.MaxLength = 6;
            this.darkTextBoxShopeePayPin.Name = "darkTextBoxShopeePayPin";
            this.darkTextBoxShopeePayPin.Size = new System.Drawing.Size(124, 23);
            this.darkTextBoxShopeePayPin.TabIndex = 13;
            this.darkTextBoxShopeePayPin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(17, 147);
            this.darkLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(93, 15);
            this.darkLabel7.TabIndex = 15;
            this.darkLabel7.Text = "ShopeePay PIN :";
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
            this.darkSectionPanelBuyingMode.Location = new System.Drawing.Point(384, 177);
            this.darkSectionPanelBuyingMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelBuyingMode.Name = "darkSectionPanelBuyingMode";
            this.darkSectionPanelBuyingMode.SectionHeader = "Buying Mode";
            this.darkSectionPanelBuyingMode.Size = new System.Drawing.Size(376, 126);
            this.darkSectionPanelBuyingMode.TabIndex = 112;
            // 
            // tbBelowSpecificPriceCARTCHECKOUTPrice
            // 
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled = false;
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Location = new System.Drawing.Point(280, 93);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Name = "tbBelowSpecificPriceCARTCHECKOUTPrice";
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.Size = new System.Drawing.Size(67, 23);
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.TabIndex = 54;
            this.tbBelowSpecificPriceCARTCHECKOUTPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPriceSpecific
            // 
            this.tbPriceSpecific.Enabled = false;
            this.tbPriceSpecific.Location = new System.Drawing.Point(280, 63);
            this.tbPriceSpecific.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbPriceSpecific.Name = "tbPriceSpecific";
            this.tbPriceSpecific.Size = new System.Drawing.Size(67, 23);
            this.tbPriceSpecific.TabIndex = 50;
            this.tbPriceSpecific.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButtonPriceSpecificCARTCHECKOUT
            // 
            this.radioButtonPriceSpecificCARTCHECKOUT.AutoSize = true;
            this.radioButtonPriceSpecificCARTCHECKOUT.Enabled = false;
            this.radioButtonPriceSpecificCARTCHECKOUT.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonPriceSpecificCARTCHECKOUT.Location = new System.Drawing.Point(26, 96);
            this.radioButtonPriceSpecificCARTCHECKOUT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonPriceSpecificCARTCHECKOUT.Name = "radioButtonPriceSpecificCARTCHECKOUT";
            this.radioButtonPriceSpecificCARTCHECKOUT.Size = new System.Drawing.Size(220, 19);
            this.radioButtonPriceSpecificCARTCHECKOUT.TabIndex = 53;
            this.radioButtonPriceSpecificCARTCHECKOUT.Text = "Below specific price (Cart checkout) :";
            // 
            // radioButtonCheckOutCart
            // 
            this.radioButtonCheckOutCart.AutoSize = true;
            this.radioButtonCheckOutCart.Enabled = false;
            this.radioButtonCheckOutCart.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonCheckOutCart.Location = new System.Drawing.Point(26, 66);
            this.radioButtonCheckOutCart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonCheckOutCart.Name = "radioButtonCheckOutCart";
            this.radioButtonCheckOutCart.Size = new System.Drawing.Size(99, 19);
            this.radioButtonCheckOutCart.TabIndex = 52;
            this.radioButtonCheckOutCart.Text = "Cart checkout";
            // 
            // radioButtonShockingSale
            // 
            this.radioButtonShockingSale.AutoSize = true;
            this.radioButtonShockingSale.Enabled = false;
            this.radioButtonShockingSale.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonShockingSale.Location = new System.Drawing.Point(145, 36);
            this.radioButtonShockingSale.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonShockingSale.Name = "radioButtonShockingSale";
            this.radioButtonShockingSale.Size = new System.Drawing.Size(163, 19);
            this.radioButtonShockingSale.TabIndex = 51;
            this.radioButtonShockingSale.Text = "Flash/Shocking sale mode";
            // 
            // radioButtonBuyNormal
            // 
            this.radioButtonBuyNormal.AutoSize = true;
            this.radioButtonBuyNormal.Checked = true;
            this.radioButtonBuyNormal.Enabled = false;
            this.radioButtonBuyNormal.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonBuyNormal.Location = new System.Drawing.Point(26, 36);
            this.radioButtonBuyNormal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonBuyNormal.Name = "radioButtonBuyNormal";
            this.radioButtonBuyNormal.Size = new System.Drawing.Size(99, 19);
            this.radioButtonBuyNormal.TabIndex = 50;
            this.radioButtonBuyNormal.TabStop = true;
            this.radioButtonBuyNormal.Text = "Normal mode";
            // 
            // radioButtonPriceSpecific
            // 
            this.radioButtonPriceSpecific.AutoSize = true;
            this.radioButtonPriceSpecific.Enabled = false;
            this.radioButtonPriceSpecific.ForeColor = System.Drawing.Color.Gainsboro;
            this.radioButtonPriceSpecific.Location = new System.Drawing.Point(146, 66);
            this.radioButtonPriceSpecific.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButtonPriceSpecific.Name = "radioButtonPriceSpecific";
            this.radioButtonPriceSpecific.Size = new System.Drawing.Size(135, 19);
            this.radioButtonPriceSpecific.TabIndex = 15;
            this.radioButtonPriceSpecific.Text = "Below specific price :";
            // 
            // darkSectionPanelBotSettings
            // 
            this.darkSectionPanelBotSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelBotSettings.Controls.Add(this.tbTimeOut);
            this.darkSectionPanelBotSettings.Controls.Add(this.tbRefreshSecond);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxTestMode);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxLogging);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxRefresh);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxHeadless);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkLabel5);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkLabel4);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxPlaySound);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkLabel13);
            this.darkSectionPanelBotSettings.Controls.Add(this.darkCheckBoxDisableImageExtension);
            this.darkSectionPanelBotSettings.Location = new System.Drawing.Point(14, 50);
            this.darkSectionPanelBotSettings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelBotSettings.Name = "darkSectionPanelBotSettings";
            this.darkSectionPanelBotSettings.SectionHeader = "Bot Settings";
            this.darkSectionPanelBotSettings.Size = new System.Drawing.Size(364, 253);
            this.darkSectionPanelBotSettings.TabIndex = 111;
            // 
            // tbTimeOut
            // 
            this.tbTimeOut.Enabled = false;
            this.tbTimeOut.Location = new System.Drawing.Point(133, 219);
            this.tbTimeOut.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbTimeOut.Name = "tbTimeOut";
            this.tbTimeOut.Size = new System.Drawing.Size(31, 23);
            this.tbTimeOut.TabIndex = 52;
            this.tbTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRefreshSecond
            // 
            this.tbRefreshSecond.Enabled = false;
            this.tbRefreshSecond.Location = new System.Drawing.Point(257, 128);
            this.tbRefreshSecond.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbRefreshSecond.Name = "tbRefreshSecond";
            this.tbRefreshSecond.Size = new System.Drawing.Size(31, 23);
            this.tbRefreshSecond.TabIndex = 51;
            this.tbRefreshSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkCheckBoxTestMode
            // 
            this.darkCheckBoxTestMode.AutoSize = true;
            this.darkCheckBoxTestMode.Enabled = false;
            this.darkCheckBoxTestMode.Location = new System.Drawing.Point(24, 192);
            this.darkCheckBoxTestMode.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxTestMode.Name = "darkCheckBoxTestMode";
            this.darkCheckBoxTestMode.Size = new System.Drawing.Size(80, 19);
            this.darkCheckBoxTestMode.TabIndex = 49;
            this.darkCheckBoxTestMode.Text = "Test Mode";
            // 
            // darkCheckBoxLogging
            // 
            this.darkCheckBoxLogging.AutoSize = true;
            this.darkCheckBoxLogging.Enabled = false;
            this.darkCheckBoxLogging.Location = new System.Drawing.Point(24, 161);
            this.darkCheckBoxLogging.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxLogging.Name = "darkCheckBoxLogging";
            this.darkCheckBoxLogging.Size = new System.Drawing.Size(108, 19);
            this.darkCheckBoxLogging.TabIndex = 50;
            this.darkCheckBoxLogging.Text = "Disable logging";
            // 
            // darkCheckBoxRefresh
            // 
            this.darkCheckBoxRefresh.AutoSize = true;
            this.darkCheckBoxRefresh.Enabled = false;
            this.darkCheckBoxRefresh.Location = new System.Drawing.Point(24, 130);
            this.darkCheckBoxRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxRefresh.Name = "darkCheckBoxRefresh";
            this.darkCheckBoxRefresh.Size = new System.Drawing.Size(142, 19);
            this.darkCheckBoxRefresh.TabIndex = 48;
            this.darkCheckBoxRefresh.Text = "Auto refresh webpage";
            // 
            // darkCheckBoxHeadless
            // 
            this.darkCheckBoxHeadless.AutoSize = true;
            this.darkCheckBoxHeadless.Enabled = false;
            this.darkCheckBoxHeadless.Location = new System.Drawing.Point(24, 68);
            this.darkCheckBoxHeadless.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxHeadless.Name = "darkCheckBoxHeadless";
            this.darkCheckBoxHeadless.Size = new System.Drawing.Size(142, 19);
            this.darkCheckBoxHeadless.TabIndex = 47;
            this.darkCheckBoxHeadless.Text = "Hide Chrome Browser";
            // 
            // darkLabel5
            // 
            this.darkLabel5.AutoSize = true;
            this.darkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel5.Location = new System.Drawing.Point(292, 132);
            this.darkLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel5.Name = "darkLabel5";
            this.darkLabel5.Size = new System.Drawing.Size(50, 15);
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
            this.darkLabel4.Size = new System.Drawing.Size(77, 15);
            this.darkLabel4.TabIndex = 10;
            this.darkLabel4.Text = "Refresh every";
            // 
            // darkCheckBoxPlaySound
            // 
            this.darkCheckBoxPlaySound.AutoSize = true;
            this.darkCheckBoxPlaySound.Enabled = false;
            this.darkCheckBoxPlaySound.Location = new System.Drawing.Point(24, 37);
            this.darkCheckBoxPlaySound.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxPlaySound.Name = "darkCheckBoxPlaySound";
            this.darkCheckBoxPlaySound.Size = new System.Drawing.Size(210, 19);
            this.darkCheckBoxPlaySound.TabIndex = 28;
            this.darkCheckBoxPlaySound.Text = "Play sound on successful checkout";
            // 
            // darkLabel13
            // 
            this.darkLabel13.AutoSize = true;
            this.darkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel13.Location = new System.Drawing.Point(20, 223);
            this.darkLabel13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel13.Name = "darkLabel13";
            this.darkLabel13.Size = new System.Drawing.Size(109, 15);
            this.darkLabel13.TabIndex = 45;
            this.darkLabel13.Text = "Time out (second) :";
            // 
            // darkCheckBoxDisableImageExtension
            // 
            this.darkCheckBoxDisableImageExtension.AutoSize = true;
            this.darkCheckBoxDisableImageExtension.Enabled = false;
            this.darkCheckBoxDisableImageExtension.Location = new System.Drawing.Point(24, 99);
            this.darkCheckBoxDisableImageExtension.Margin = new System.Windows.Forms.Padding(2);
            this.darkCheckBoxDisableImageExtension.Name = "darkCheckBoxDisableImageExtension";
            this.darkCheckBoxDisableImageExtension.Size = new System.Drawing.Size(200, 19);
            this.darkCheckBoxDisableImageExtension.TabIndex = 25;
            this.darkCheckBoxDisableImageExtension.Text = "Disable website Image & Extension";
            // 
            // darkSectionPanelProductDetails
            // 
            this.darkSectionPanelProductDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelProductDetails.Controls.Add(this.tbQuality);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkLabel11);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkTextBoxProductLink);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkLabel10);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkTextBoxVariationString);
            this.darkSectionPanelProductDetails.Controls.Add(this.darkLabel9);
            this.darkSectionPanelProductDetails.Location = new System.Drawing.Point(14, 308);
            this.darkSectionPanelProductDetails.Margin = new System.Windows.Forms.Padding(2);
            this.darkSectionPanelProductDetails.Name = "darkSectionPanelProductDetails";
            this.darkSectionPanelProductDetails.SectionHeader = "Product Details";
            this.darkSectionPanelProductDetails.Size = new System.Drawing.Size(364, 195);
            this.darkSectionPanelProductDetails.TabIndex = 110;
            // 
            // tbQuality
            // 
            this.tbQuality.Enabled = false;
            this.tbQuality.Location = new System.Drawing.Point(98, 160);
            this.tbQuality.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new System.Drawing.Size(37, 23);
            this.tbQuality.TabIndex = 54;
            this.tbQuality.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel11
            // 
            this.darkLabel11.AutoSize = true;
            this.darkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel11.Location = new System.Drawing.Point(17, 37);
            this.darkLabel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel11.Name = "darkLabel11";
            this.darkLabel11.Size = new System.Drawing.Size(80, 15);
            this.darkLabel11.TabIndex = 24;
            this.darkLabel11.Text = "Product Link :";
            // 
            // darkTextBoxProductLink
            // 
            this.darkTextBoxProductLink.Enabled = false;
            this.darkTextBoxProductLink.Location = new System.Drawing.Point(98, 37);
            this.darkTextBoxProductLink.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkTextBoxProductLink.Multiline = true;
            this.darkTextBoxProductLink.Name = "darkTextBoxProductLink";
            this.darkTextBoxProductLink.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.darkTextBoxProductLink.Size = new System.Drawing.Size(244, 84);
            this.darkTextBoxProductLink.TabIndex = 23;
            // 
            // darkLabel10
            // 
            this.darkLabel10.AutoSize = true;
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(17, 164);
            this.darkLabel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(59, 15);
            this.darkLabel10.TabIndex = 21;
            this.darkLabel10.Text = "Quantity :";
            // 
            // darkTextBoxVariationString
            // 
            this.darkTextBoxVariationString.Enabled = false;
            this.darkTextBoxVariationString.Location = new System.Drawing.Point(98, 129);
            this.darkTextBoxVariationString.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkTextBoxVariationString.Name = "darkTextBoxVariationString";
            this.darkTextBoxVariationString.Size = new System.Drawing.Size(244, 23);
            this.darkTextBoxVariationString.TabIndex = 18;
            this.darkTextBoxVariationString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel9
            // 
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(17, 134);
            this.darkLabel9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(59, 15);
            this.darkLabel9.TabIndex = 19;
            this.darkLabel9.Text = "Variation :";
            // 
            // darkSectionPanelTimerMode
            // 
            this.darkSectionPanelTimerMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkSectionPanelTimerMode.Controls.Add(this.tbCountdownSeconds);
            this.darkSectionPanelTimerMode.Controls.Add(this.tbCountdownMinutes);
            this.darkSectionPanelTimerMode.Controls.Add(this.tbCountdownHour);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkCheckBoxTomorrow);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkCheckBoxScheduleBot);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkLabel3);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkLabel2);
            this.darkSectionPanelTimerMode.Controls.Add(this.darkLabel12);
            this.darkSectionPanelTimerMode.Location = new System.Drawing.Point(384, 50);
            this.darkSectionPanelTimerMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkSectionPanelTimerMode.Name = "darkSectionPanelTimerMode";
            this.darkSectionPanelTimerMode.SectionHeader = "Schedule Bot";
            this.darkSectionPanelTimerMode.Size = new System.Drawing.Size(376, 121);
            this.darkSectionPanelTimerMode.TabIndex = 109;
            // 
            // tbCountdownSeconds
            // 
            this.tbCountdownSeconds.Enabled = false;
            this.tbCountdownSeconds.Location = new System.Drawing.Point(264, 61);
            this.tbCountdownSeconds.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbCountdownSeconds.Name = "tbCountdownSeconds";
            this.tbCountdownSeconds.Size = new System.Drawing.Size(31, 23);
            this.tbCountdownSeconds.TabIndex = 55;
            this.tbCountdownSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCountdownMinutes
            // 
            this.tbCountdownMinutes.Enabled = false;
            this.tbCountdownMinutes.Location = new System.Drawing.Point(172, 61);
            this.tbCountdownMinutes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbCountdownMinutes.Name = "tbCountdownMinutes";
            this.tbCountdownMinutes.Size = new System.Drawing.Size(31, 23);
            this.tbCountdownMinutes.TabIndex = 54;
            this.tbCountdownMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCountdownHour
            // 
            this.tbCountdownHour.Enabled = false;
            this.tbCountdownHour.Location = new System.Drawing.Point(75, 61);
            this.tbCountdownHour.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbCountdownHour.Name = "tbCountdownHour";
            this.tbCountdownHour.Size = new System.Drawing.Size(37, 23);
            this.tbCountdownHour.TabIndex = 53;
            this.tbCountdownHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkCheckBoxTomorrow
            // 
            this.darkCheckBoxTomorrow.AutoSize = true;
            this.darkCheckBoxTomorrow.Enabled = false;
            this.darkCheckBoxTomorrow.Location = new System.Drawing.Point(38, 89);
            this.darkCheckBoxTomorrow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxTomorrow.Name = "darkCheckBoxTomorrow";
            this.darkCheckBoxTomorrow.Size = new System.Drawing.Size(80, 19);
            this.darkCheckBoxTomorrow.TabIndex = 16;
            this.darkCheckBoxTomorrow.Text = "Tomorrow";
            // 
            // darkCheckBoxScheduleBot
            // 
            this.darkCheckBoxScheduleBot.AutoSize = true;
            this.darkCheckBoxScheduleBot.Enabled = false;
            this.darkCheckBoxScheduleBot.Location = new System.Drawing.Point(38, 38);
            this.darkCheckBoxScheduleBot.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.darkCheckBoxScheduleBot.Name = "darkCheckBoxScheduleBot";
            this.darkCheckBoxScheduleBot.Size = new System.Drawing.Size(310, 19);
            this.darkCheckBoxScheduleBot.TabIndex = 15;
            this.darkCheckBoxScheduleBot.Text = "Schedule bot to run at specific time (24-hours format)";
            // 
            // darkLabel3
            // 
            this.darkLabel3.AutoSize = true;
            this.darkLabel3.Enabled = false;
            this.darkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel3.Location = new System.Drawing.Point(208, 65);
            this.darkLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel3.Name = "darkLabel3";
            this.darkLabel3.Size = new System.Drawing.Size(51, 15);
            this.darkLabel3.TabIndex = 14;
            this.darkLabel3.Text = "Seconds";
            // 
            // darkLabel2
            // 
            this.darkLabel2.AutoSize = true;
            this.darkLabel2.Enabled = false;
            this.darkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel2.Location = new System.Drawing.Point(117, 65);
            this.darkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel2.Name = "darkLabel2";
            this.darkLabel2.Size = new System.Drawing.Size(50, 15);
            this.darkLabel2.TabIndex = 5;
            this.darkLabel2.Text = "Minutes";
            // 
            // darkLabel12
            // 
            this.darkLabel12.AutoSize = true;
            this.darkLabel12.Enabled = false;
            this.darkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel12.Location = new System.Drawing.Point(36, 65);
            this.darkLabel12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.darkLabel12.Name = "darkLabel12";
            this.darkLabel12.Size = new System.Drawing.Size(34, 15);
            this.darkLabel12.TabIndex = 4;
            this.darkLabel12.Text = "Hour";
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 515);
            this.Controls.Add(this.darkSectionPanel1);
            this.Controls.Add(this.darkSectionPanelPaymentDetails);
            this.Controls.Add(this.darkSectionPanelBuyingMode);
            this.Controls.Add(this.darkSectionPanelBotSettings);
            this.Controls.Add(this.darkSectionPanelProductDetails);
            this.Controls.Add(this.darkSectionPanelTimerMode);
            this.Controls.Add(this.darkLabel1);
            this.Controls.Add(this.darkComboBoxProfile);
            this.Controls.Add(this.btnDeleteProfile);
            this.Controls.Add(this.btnLoadProfile);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Profile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Profile";
            this.Load += new System.EventHandler(this.Profile_Load_1);
            this.darkSectionPanel1.ResumeLayout(false);
            this.darkSectionPanel1.PerformLayout();
            this.darkSectionPanelPaymentDetails.ResumeLayout(false);
            this.darkSectionPanelPaymentDetails.PerformLayout();
            this.darkSectionPanelBuyingMode.ResumeLayout(false);
            this.darkSectionPanelBuyingMode.PerformLayout();
            this.darkSectionPanelBotSettings.ResumeLayout(false);
            this.darkSectionPanelBotSettings.PerformLayout();
            this.darkSectionPanelProductDetails.ResumeLayout(false);
            this.darkSectionPanelProductDetails.PerformLayout();
            this.darkSectionPanelTimerMode.ResumeLayout(false);
            this.darkSectionPanelTimerMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DarkUI.Controls.DarkButton btnLoadProfile;
        private DarkUI.Controls.DarkButton btnDeleteProfile;
        private DarkUI.Controls.DarkLabel darkLabel1;
        private DarkUI.Controls.DarkComboBox darkComboBoxProfile;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanel1;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRedeemShopeeVoucher;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxClaimShopVoucher;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRedeemCoin;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelPaymentDetails;
        private DarkUI.Controls.DarkTextBox tbPaymentMethod;
        private DarkUI.Controls.DarkTextBox tbBankType;
        private DarkUI.Controls.DarkLabel darkLabel14;
        private DarkUI.Controls.DarkTextBox tbLast4Digit;
        private DarkUI.Controls.DarkLabel darkLabel6;
        private DarkUI.Controls.DarkLabel darkLabel8;
        private DarkUI.Controls.DarkTextBox darkTextBoxShopeePayPin;
        private DarkUI.Controls.DarkLabel darkLabel7;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelBuyingMode;
        private DarkUI.Controls.DarkTextBox tbBelowSpecificPriceCARTCHECKOUTPrice;
        private DarkUI.Controls.DarkTextBox tbPriceSpecific;
        private System.Windows.Forms.RadioButton radioButtonPriceSpecificCARTCHECKOUT;
        private System.Windows.Forms.RadioButton radioButtonCheckOutCart;
        private System.Windows.Forms.RadioButton radioButtonShockingSale;
        private System.Windows.Forms.RadioButton radioButtonBuyNormal;
        private System.Windows.Forms.RadioButton radioButtonPriceSpecific;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelBotSettings;
        private DarkUI.Controls.DarkTextBox tbTimeOut;
        private DarkUI.Controls.DarkTextBox tbRefreshSecond;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxTestMode;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxLogging;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxRefresh;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxHeadless;
        private DarkUI.Controls.DarkLabel darkLabel5;
        private DarkUI.Controls.DarkLabel darkLabel4;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxPlaySound;
        private DarkUI.Controls.DarkLabel darkLabel13;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxDisableImageExtension;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelProductDetails;
        private DarkUI.Controls.DarkTextBox tbQuality;
        private DarkUI.Controls.DarkLabel darkLabel11;
        private DarkUI.Controls.DarkTextBox darkTextBoxProductLink;
        private DarkUI.Controls.DarkLabel darkLabel10;
        private DarkUI.Controls.DarkTextBox darkTextBoxVariationString;
        private DarkUI.Controls.DarkLabel darkLabel9;
        private DarkUI.Controls.DarkSectionPanel darkSectionPanelTimerMode;
        private DarkUI.Controls.DarkTextBox tbCountdownSeconds;
        private DarkUI.Controls.DarkTextBox tbCountdownMinutes;
        private DarkUI.Controls.DarkTextBox tbCountdownHour;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxTomorrow;
        private DarkUI.Controls.DarkCheckBox darkCheckBoxScheduleBot;
        private DarkUI.Controls.DarkLabel darkLabel3;
        private DarkUI.Controls.DarkLabel darkLabel2;
        private DarkUI.Controls.DarkLabel darkLabel12;
    }
}