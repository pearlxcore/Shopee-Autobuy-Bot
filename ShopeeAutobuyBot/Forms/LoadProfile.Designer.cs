namespace Shopee_Autobuy_Bot
{
    partial class LoadProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadProfile));
            btnLoadProfile=new DarkUI.Controls.DarkButton();
            btnDeleteProfile=new DarkUI.Controls.DarkButton();
            darkLabel1=new DarkUI.Controls.DarkLabel();
            darkComboBoxProfile=new DarkUI.Controls.DarkComboBox();
            darkSectionPanel1=new DarkUI.Controls.DarkSectionPanel();
            darkCheckBoxRedeemShopeeVoucher=new DarkUI.Controls.DarkCheckBox();
            darkCheckBoxClaimShopVoucher=new DarkUI.Controls.DarkCheckBox();
            darkCheckBoxRedeemCoin=new DarkUI.Controls.DarkCheckBox();
            darkSectionPanelPaymentDetails=new DarkUI.Controls.DarkSectionPanel();
            tbPaymentMethod=new DarkUI.Controls.DarkTextBox();
            tbBankType=new DarkUI.Controls.DarkTextBox();
            darkLabel14=new DarkUI.Controls.DarkLabel();
            tbLast4Digit=new DarkUI.Controls.DarkTextBox();
            darkLabel6=new DarkUI.Controls.DarkLabel();
            darkLabel8=new DarkUI.Controls.DarkLabel();
            darkTextBoxShopeePayPin=new DarkUI.Controls.DarkTextBox();
            darkLabel7=new DarkUI.Controls.DarkLabel();
            darkSectionPanelBuyingMode=new DarkUI.Controls.DarkSectionPanel();
            tbBelowSpecificPriceCARTCHECKOUTPrice=new DarkUI.Controls.DarkTextBox();
            tbPriceSpecific=new DarkUI.Controls.DarkTextBox();
            radioButtonPriceSpecificCARTCHECKOUT=new System.Windows.Forms.RadioButton();
            radioButtonCheckOutCart=new System.Windows.Forms.RadioButton();
            radioButtonShockingSale=new System.Windows.Forms.RadioButton();
            radioButtonBuyNormal=new System.Windows.Forms.RadioButton();
            radioButtonPriceSpecific=new System.Windows.Forms.RadioButton();
            darkSectionPanelBotSettings=new DarkUI.Controls.DarkSectionPanel();
            tbTimeOut=new DarkUI.Controls.DarkTextBox();
            tbRefreshSecond=new DarkUI.Controls.DarkTextBox();
            darkCheckBoxTestMode=new DarkUI.Controls.DarkCheckBox();
            darkCheckBoxLogging=new DarkUI.Controls.DarkCheckBox();
            darkCheckBoxRefresh=new DarkUI.Controls.DarkCheckBox();
            darkCheckBoxHeadless=new DarkUI.Controls.DarkCheckBox();
            darkLabel5=new DarkUI.Controls.DarkLabel();
            darkLabel4=new DarkUI.Controls.DarkLabel();
            darkCheckBoxPlaySound=new DarkUI.Controls.DarkCheckBox();
            darkLabel13=new DarkUI.Controls.DarkLabel();
            darkCheckBoxDisableImageExtension=new DarkUI.Controls.DarkCheckBox();
            darkSectionPanelProductDetails=new DarkUI.Controls.DarkSectionPanel();
            cbRandom=new DarkUI.Controls.DarkCheckBox();
            tbQuality=new DarkUI.Controls.DarkTextBox();
            darkLabel11=new DarkUI.Controls.DarkLabel();
            darkTextBoxProductLink=new DarkUI.Controls.DarkTextBox();
            darkLabel10=new DarkUI.Controls.DarkLabel();
            darkTextBoxVariationString=new DarkUI.Controls.DarkTextBox();
            darkLabel9=new DarkUI.Controls.DarkLabel();
            darkSectionPanelTimerMode=new DarkUI.Controls.DarkSectionPanel();
            tbCountdownSeconds=new DarkUI.Controls.DarkTextBox();
            tbCountdownMinutes=new DarkUI.Controls.DarkTextBox();
            tbCountdownHour=new DarkUI.Controls.DarkTextBox();
            darkCheckBoxTomorrow=new DarkUI.Controls.DarkCheckBox();
            darkCheckBoxScheduleBot=new DarkUI.Controls.DarkCheckBox();
            darkLabel3=new DarkUI.Controls.DarkLabel();
            darkLabel2=new DarkUI.Controls.DarkLabel();
            darkLabel12=new DarkUI.Controls.DarkLabel();
            darkButton1=new DarkUI.Controls.DarkButton();
            cbVariantPreSelected=new DarkUI.Controls.DarkCheckBox();
            darkSectionPanel1.SuspendLayout();
            darkSectionPanelPaymentDetails.SuspendLayout();
            darkSectionPanelBuyingMode.SuspendLayout();
            darkSectionPanelBotSettings.SuspendLayout();
            darkSectionPanelProductDetails.SuspendLayout();
            darkSectionPanelTimerMode.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadProfile
            // 
            btnLoadProfile.Font=new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnLoadProfile.Location=new System.Drawing.Point(529, 13);
            btnLoadProfile.Margin=new System.Windows.Forms.Padding(2);
            btnLoadProfile.Name="btnLoadProfile";
            btnLoadProfile.Size=new System.Drawing.Size(123, 24);
            btnLoadProfile.TabIndex=103;
            btnLoadProfile.Text="Load profile";
            btnLoadProfile.Click+=btnLoadProfile_Click;
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Font=new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnDeleteProfile.Location=new System.Drawing.Point(656, 13);
            btnDeleteProfile.Margin=new System.Windows.Forms.Padding(2);
            btnDeleteProfile.Name="btnDeleteProfile";
            btnDeleteProfile.Size=new System.Drawing.Size(123, 24);
            btnDeleteProfile.TabIndex=104;
            btnDeleteProfile.Text="Delete profile";
            btnDeleteProfile.Click+=btnDeleteProfile_Click;
            // 
            // darkLabel1
            // 
            darkLabel1.AutoSize=true;
            darkLabel1.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel1.Location=new System.Drawing.Point(194, 18);
            darkLabel1.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel1.Name="darkLabel1";
            darkLabel1.Size=new System.Drawing.Size(78, 15);
            darkLabel1.TabIndex=108;
            darkLabel1.Text="Select profile:";
            // 
            // darkComboBoxProfile
            // 
            darkComboBoxProfile.FormattingEnabled=true;
            darkComboBoxProfile.Location=new System.Drawing.Point(276, 13);
            darkComboBoxProfile.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkComboBoxProfile.Name="darkComboBoxProfile";
            darkComboBoxProfile.Size=new System.Drawing.Size(249, 24);
            darkComboBoxProfile.TabIndex=107;
            darkComboBoxProfile.SelectedIndexChanged+=darkComboBoxProfile_SelectedIndexChanged;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            darkSectionPanel1.Controls.Add(darkCheckBoxRedeemShopeeVoucher);
            darkSectionPanel1.Controls.Add(darkCheckBoxClaimShopVoucher);
            darkSectionPanel1.Controls.Add(darkCheckBoxRedeemCoin);
            darkSectionPanel1.Location=new System.Drawing.Point(765, 50);
            darkSectionPanel1.Name="darkSectionPanel1";
            darkSectionPanel1.SectionHeader="Voucher & coin";
            darkSectionPanel1.Size=new System.Drawing.Size(192, 151);
            darkSectionPanel1.TabIndex=114;
            // 
            // darkCheckBoxRedeemShopeeVoucher
            // 
            darkCheckBoxRedeemShopeeVoucher.AutoSize=true;
            darkCheckBoxRedeemShopeeVoucher.Enabled=false;
            darkCheckBoxRedeemShopeeVoucher.Location=new System.Drawing.Point(11, 77);
            darkCheckBoxRedeemShopeeVoucher.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxRedeemShopeeVoucher.Name="darkCheckBoxRedeemShopeeVoucher";
            darkCheckBoxRedeemShopeeVoucher.Size=new System.Drawing.Size(179, 19);
            darkCheckBoxRedeemShopeeVoucher.TabIndex=52;
            darkCheckBoxRedeemShopeeVoucher.Text="Redeem any Shopee voucher";
            // 
            // darkCheckBoxClaimShopVoucher
            // 
            darkCheckBoxClaimShopVoucher.AutoSize=true;
            darkCheckBoxClaimShopVoucher.Enabled=false;
            darkCheckBoxClaimShopVoucher.Location=new System.Drawing.Point(11, 44);
            darkCheckBoxClaimShopVoucher.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxClaimShopVoucher.Name="darkCheckBoxClaimShopVoucher";
            darkCheckBoxClaimShopVoucher.Size=new System.Drawing.Size(154, 19);
            darkCheckBoxClaimShopVoucher.TabIndex=50;
            darkCheckBoxClaimShopVoucher.Text="Claim any shop voucher";
            // 
            // darkCheckBoxRedeemCoin
            // 
            darkCheckBoxRedeemCoin.AutoSize=true;
            darkCheckBoxRedeemCoin.Enabled=false;
            darkCheckBoxRedeemCoin.Location=new System.Drawing.Point(11, 110);
            darkCheckBoxRedeemCoin.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxRedeemCoin.Name="darkCheckBoxRedeemCoin";
            darkCheckBoxRedeemCoin.Size=new System.Drawing.Size(95, 19);
            darkCheckBoxRedeemCoin.TabIndex=42;
            darkCheckBoxRedeemCoin.Text="Redeem coin";
            // 
            // darkSectionPanelPaymentDetails
            // 
            darkSectionPanelPaymentDetails.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            darkSectionPanelPaymentDetails.Controls.Add(tbPaymentMethod);
            darkSectionPanelPaymentDetails.Controls.Add(tbBankType);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel14);
            darkSectionPanelPaymentDetails.Controls.Add(tbLast4Digit);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel6);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel8);
            darkSectionPanelPaymentDetails.Controls.Add(darkTextBoxShopeePayPin);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel7);
            darkSectionPanelPaymentDetails.Location=new System.Drawing.Point(384, 308);
            darkSectionPanelPaymentDetails.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelPaymentDetails.Name="darkSectionPanelPaymentDetails";
            darkSectionPanelPaymentDetails.SectionHeader="Payment Details";
            darkSectionPanelPaymentDetails.Size=new System.Drawing.Size(376, 195);
            darkSectionPanelPaymentDetails.TabIndex=113;
            // 
            // tbPaymentMethod
            // 
            tbPaymentMethod.Enabled=false;
            tbPaymentMethod.Location=new System.Drawing.Point(145, 44);
            tbPaymentMethod.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbPaymentMethod.MaxLength=4;
            tbPaymentMethod.Name="tbPaymentMethod";
            tbPaymentMethod.Size=new System.Drawing.Size(202, 23);
            tbPaymentMethod.TabIndex=53;
            tbPaymentMethod.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbBankType
            // 
            tbBankType.Enabled=false;
            tbBankType.Location=new System.Drawing.Point(145, 78);
            tbBankType.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbBankType.MaxLength=4;
            tbBankType.Name="tbBankType";
            tbBankType.Size=new System.Drawing.Size(202, 23);
            tbBankType.TabIndex=52;
            tbBankType.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel14
            // 
            darkLabel14.AutoSize=true;
            darkLabel14.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel14.Location=new System.Drawing.Point(17, 114);
            darkLabel14.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel14.Name="darkLabel14";
            darkLabel14.Size=new System.Drawing.Size(175, 15);
            darkLabel14.TabIndex=51;
            darkLabel14.Text="Last 4 digit of debit/credit card :";
            // 
            // tbLast4Digit
            // 
            tbLast4Digit.Enabled=false;
            tbLast4Digit.Location=new System.Drawing.Point(223, 109);
            tbLast4Digit.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbLast4Digit.MaxLength=4;
            tbLast4Digit.Name="tbLast4Digit";
            tbLast4Digit.Size=new System.Drawing.Size(124, 23);
            tbLast4Digit.TabIndex=50;
            tbLast4Digit.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel6
            // 
            darkLabel6.AutoSize=true;
            darkLabel6.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel6.Location=new System.Drawing.Point(17, 48);
            darkLabel6.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel6.Name="darkLabel6";
            darkLabel6.Size=new System.Drawing.Size(105, 15);
            darkLabel6.TabIndex=14;
            darkLabel6.Text="Payment Method :";
            // 
            // darkLabel8
            // 
            darkLabel8.AutoSize=true;
            darkLabel8.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel8.Location=new System.Drawing.Point(17, 82);
            darkLabel8.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel8.Name="darkLabel8";
            darkLabel8.Size=new System.Drawing.Size(65, 15);
            darkLabel8.TabIndex=31;
            darkLabel8.Text="Bank type :";
            // 
            // darkTextBoxShopeePayPin
            // 
            darkTextBoxShopeePayPin.Enabled=false;
            darkTextBoxShopeePayPin.Location=new System.Drawing.Point(223, 141);
            darkTextBoxShopeePayPin.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkTextBoxShopeePayPin.MaxLength=6;
            darkTextBoxShopeePayPin.Name="darkTextBoxShopeePayPin";
            darkTextBoxShopeePayPin.Size=new System.Drawing.Size(124, 23);
            darkTextBoxShopeePayPin.TabIndex=13;
            darkTextBoxShopeePayPin.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel7
            // 
            darkLabel7.AutoSize=true;
            darkLabel7.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel7.Location=new System.Drawing.Point(17, 147);
            darkLabel7.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel7.Name="darkLabel7";
            darkLabel7.Size=new System.Drawing.Size(93, 15);
            darkLabel7.TabIndex=15;
            darkLabel7.Text="ShopeePay PIN :";
            // 
            // darkSectionPanelBuyingMode
            // 
            darkSectionPanelBuyingMode.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            darkSectionPanelBuyingMode.Controls.Add(tbBelowSpecificPriceCARTCHECKOUTPrice);
            darkSectionPanelBuyingMode.Controls.Add(tbPriceSpecific);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonPriceSpecificCARTCHECKOUT);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonCheckOutCart);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonShockingSale);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonBuyNormal);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonPriceSpecific);
            darkSectionPanelBuyingMode.Location=new System.Drawing.Point(384, 177);
            darkSectionPanelBuyingMode.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelBuyingMode.Name="darkSectionPanelBuyingMode";
            darkSectionPanelBuyingMode.SectionHeader="Buying Mode";
            darkSectionPanelBuyingMode.Size=new System.Drawing.Size(376, 126);
            darkSectionPanelBuyingMode.TabIndex=112;
            // 
            // tbBelowSpecificPriceCARTCHECKOUTPrice
            // 
            tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled=false;
            tbBelowSpecificPriceCARTCHECKOUTPrice.Location=new System.Drawing.Point(280, 93);
            tbBelowSpecificPriceCARTCHECKOUTPrice.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbBelowSpecificPriceCARTCHECKOUTPrice.Name="tbBelowSpecificPriceCARTCHECKOUTPrice";
            tbBelowSpecificPriceCARTCHECKOUTPrice.Size=new System.Drawing.Size(67, 23);
            tbBelowSpecificPriceCARTCHECKOUTPrice.TabIndex=54;
            tbBelowSpecificPriceCARTCHECKOUTPrice.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPriceSpecific
            // 
            tbPriceSpecific.Enabled=false;
            tbPriceSpecific.Location=new System.Drawing.Point(280, 63);
            tbPriceSpecific.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbPriceSpecific.Name="tbPriceSpecific";
            tbPriceSpecific.Size=new System.Drawing.Size(67, 23);
            tbPriceSpecific.TabIndex=50;
            tbPriceSpecific.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButtonPriceSpecificCARTCHECKOUT
            // 
            radioButtonPriceSpecificCARTCHECKOUT.AutoSize=true;
            radioButtonPriceSpecificCARTCHECKOUT.Enabled=false;
            radioButtonPriceSpecificCARTCHECKOUT.ForeColor=System.Drawing.Color.Gainsboro;
            radioButtonPriceSpecificCARTCHECKOUT.Location=new System.Drawing.Point(26, 96);
            radioButtonPriceSpecificCARTCHECKOUT.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonPriceSpecificCARTCHECKOUT.Name="radioButtonPriceSpecificCARTCHECKOUT";
            radioButtonPriceSpecificCARTCHECKOUT.Size=new System.Drawing.Size(220, 19);
            radioButtonPriceSpecificCARTCHECKOUT.TabIndex=53;
            radioButtonPriceSpecificCARTCHECKOUT.Text="Below specific price (Cart checkout) :";
            // 
            // radioButtonCheckOutCart
            // 
            radioButtonCheckOutCart.AutoSize=true;
            radioButtonCheckOutCart.Enabled=false;
            radioButtonCheckOutCart.ForeColor=System.Drawing.Color.Gainsboro;
            radioButtonCheckOutCart.Location=new System.Drawing.Point(26, 66);
            radioButtonCheckOutCart.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonCheckOutCart.Name="radioButtonCheckOutCart";
            radioButtonCheckOutCart.Size=new System.Drawing.Size(99, 19);
            radioButtonCheckOutCart.TabIndex=52;
            radioButtonCheckOutCart.Text="Cart checkout";
            // 
            // radioButtonShockingSale
            // 
            radioButtonShockingSale.AutoSize=true;
            radioButtonShockingSale.Enabled=false;
            radioButtonShockingSale.ForeColor=System.Drawing.Color.Gainsboro;
            radioButtonShockingSale.Location=new System.Drawing.Point(145, 36);
            radioButtonShockingSale.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonShockingSale.Name="radioButtonShockingSale";
            radioButtonShockingSale.Size=new System.Drawing.Size(163, 19);
            radioButtonShockingSale.TabIndex=51;
            radioButtonShockingSale.Text="Flash/Shocking sale mode";
            // 
            // radioButtonBuyNormal
            // 
            radioButtonBuyNormal.AutoSize=true;
            radioButtonBuyNormal.Checked=true;
            radioButtonBuyNormal.Enabled=false;
            radioButtonBuyNormal.ForeColor=System.Drawing.Color.Gainsboro;
            radioButtonBuyNormal.Location=new System.Drawing.Point(26, 36);
            radioButtonBuyNormal.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonBuyNormal.Name="radioButtonBuyNormal";
            radioButtonBuyNormal.Size=new System.Drawing.Size(99, 19);
            radioButtonBuyNormal.TabIndex=50;
            radioButtonBuyNormal.TabStop=true;
            radioButtonBuyNormal.Text="Normal mode";
            // 
            // radioButtonPriceSpecific
            // 
            radioButtonPriceSpecific.AutoSize=true;
            radioButtonPriceSpecific.Enabled=false;
            radioButtonPriceSpecific.ForeColor=System.Drawing.Color.Gainsboro;
            radioButtonPriceSpecific.Location=new System.Drawing.Point(146, 66);
            radioButtonPriceSpecific.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            radioButtonPriceSpecific.Name="radioButtonPriceSpecific";
            radioButtonPriceSpecific.Size=new System.Drawing.Size(135, 19);
            radioButtonPriceSpecific.TabIndex=15;
            radioButtonPriceSpecific.Text="Below specific price :";
            // 
            // darkSectionPanelBotSettings
            // 
            darkSectionPanelBotSettings.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            darkSectionPanelBotSettings.Controls.Add(tbTimeOut);
            darkSectionPanelBotSettings.Controls.Add(tbRefreshSecond);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxTestMode);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxLogging);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxRefresh);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxHeadless);
            darkSectionPanelBotSettings.Controls.Add(darkLabel5);
            darkSectionPanelBotSettings.Controls.Add(darkLabel4);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxPlaySound);
            darkSectionPanelBotSettings.Controls.Add(darkLabel13);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxDisableImageExtension);
            darkSectionPanelBotSettings.Location=new System.Drawing.Point(14, 50);
            darkSectionPanelBotSettings.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelBotSettings.Name="darkSectionPanelBotSettings";
            darkSectionPanelBotSettings.SectionHeader="Bot Settings";
            darkSectionPanelBotSettings.Size=new System.Drawing.Size(364, 253);
            darkSectionPanelBotSettings.TabIndex=111;
            // 
            // tbTimeOut
            // 
            tbTimeOut.Enabled=false;
            tbTimeOut.Location=new System.Drawing.Point(133, 219);
            tbTimeOut.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbTimeOut.Name="tbTimeOut";
            tbTimeOut.Size=new System.Drawing.Size(31, 23);
            tbTimeOut.TabIndex=52;
            tbTimeOut.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbRefreshSecond
            // 
            tbRefreshSecond.Enabled=false;
            tbRefreshSecond.Location=new System.Drawing.Point(257, 128);
            tbRefreshSecond.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbRefreshSecond.Name="tbRefreshSecond";
            tbRefreshSecond.Size=new System.Drawing.Size(31, 23);
            tbRefreshSecond.TabIndex=51;
            tbRefreshSecond.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkCheckBoxTestMode
            // 
            darkCheckBoxTestMode.AutoSize=true;
            darkCheckBoxTestMode.Enabled=false;
            darkCheckBoxTestMode.Location=new System.Drawing.Point(24, 192);
            darkCheckBoxTestMode.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxTestMode.Name="darkCheckBoxTestMode";
            darkCheckBoxTestMode.Size=new System.Drawing.Size(80, 19);
            darkCheckBoxTestMode.TabIndex=49;
            darkCheckBoxTestMode.Text="Test Mode";
            // 
            // darkCheckBoxLogging
            // 
            darkCheckBoxLogging.AutoSize=true;
            darkCheckBoxLogging.Enabled=false;
            darkCheckBoxLogging.Location=new System.Drawing.Point(24, 161);
            darkCheckBoxLogging.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxLogging.Name="darkCheckBoxLogging";
            darkCheckBoxLogging.Size=new System.Drawing.Size(108, 19);
            darkCheckBoxLogging.TabIndex=50;
            darkCheckBoxLogging.Text="Disable logging";
            // 
            // darkCheckBoxRefresh
            // 
            darkCheckBoxRefresh.AutoSize=true;
            darkCheckBoxRefresh.Enabled=false;
            darkCheckBoxRefresh.Location=new System.Drawing.Point(24, 130);
            darkCheckBoxRefresh.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxRefresh.Name="darkCheckBoxRefresh";
            darkCheckBoxRefresh.Size=new System.Drawing.Size(142, 19);
            darkCheckBoxRefresh.TabIndex=48;
            darkCheckBoxRefresh.Text="Auto refresh webpage";
            // 
            // darkCheckBoxHeadless
            // 
            darkCheckBoxHeadless.AutoSize=true;
            darkCheckBoxHeadless.Enabled=false;
            darkCheckBoxHeadless.Location=new System.Drawing.Point(24, 68);
            darkCheckBoxHeadless.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxHeadless.Name="darkCheckBoxHeadless";
            darkCheckBoxHeadless.Size=new System.Drawing.Size(142, 19);
            darkCheckBoxHeadless.TabIndex=47;
            darkCheckBoxHeadless.Text="Hide Chrome Browser";
            // 
            // darkLabel5
            // 
            darkLabel5.AutoSize=true;
            darkLabel5.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel5.Location=new System.Drawing.Point(292, 132);
            darkLabel5.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel5.Name="darkLabel5";
            darkLabel5.Size=new System.Drawing.Size(50, 15);
            darkLabel5.TabIndex=11;
            darkLabel5.Text="seconds";
            // 
            // darkLabel4
            // 
            darkLabel4.AutoSize=true;
            darkLabel4.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel4.Location=new System.Drawing.Point(176, 132);
            darkLabel4.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel4.Name="darkLabel4";
            darkLabel4.Size=new System.Drawing.Size(77, 15);
            darkLabel4.TabIndex=10;
            darkLabel4.Text="Refresh every";
            // 
            // darkCheckBoxPlaySound
            // 
            darkCheckBoxPlaySound.AutoSize=true;
            darkCheckBoxPlaySound.Enabled=false;
            darkCheckBoxPlaySound.Location=new System.Drawing.Point(24, 37);
            darkCheckBoxPlaySound.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxPlaySound.Name="darkCheckBoxPlaySound";
            darkCheckBoxPlaySound.Size=new System.Drawing.Size(210, 19);
            darkCheckBoxPlaySound.TabIndex=28;
            darkCheckBoxPlaySound.Text="Play sound on successful checkout";
            // 
            // darkLabel13
            // 
            darkLabel13.AutoSize=true;
            darkLabel13.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel13.Location=new System.Drawing.Point(20, 223);
            darkLabel13.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel13.Name="darkLabel13";
            darkLabel13.Size=new System.Drawing.Size(109, 15);
            darkLabel13.TabIndex=45;
            darkLabel13.Text="Time out (second) :";
            // 
            // darkCheckBoxDisableImageExtension
            // 
            darkCheckBoxDisableImageExtension.AutoSize=true;
            darkCheckBoxDisableImageExtension.Enabled=false;
            darkCheckBoxDisableImageExtension.Location=new System.Drawing.Point(24, 99);
            darkCheckBoxDisableImageExtension.Margin=new System.Windows.Forms.Padding(2);
            darkCheckBoxDisableImageExtension.Name="darkCheckBoxDisableImageExtension";
            darkCheckBoxDisableImageExtension.Size=new System.Drawing.Size(200, 19);
            darkCheckBoxDisableImageExtension.TabIndex=25;
            darkCheckBoxDisableImageExtension.Text="Disable website Image & Extension";
            // 
            // darkSectionPanelProductDetails
            // 
            darkSectionPanelProductDetails.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            darkSectionPanelProductDetails.Controls.Add(cbVariantPreSelected);
            darkSectionPanelProductDetails.Controls.Add(cbRandom);
            darkSectionPanelProductDetails.Controls.Add(tbQuality);
            darkSectionPanelProductDetails.Controls.Add(darkLabel11);
            darkSectionPanelProductDetails.Controls.Add(darkTextBoxProductLink);
            darkSectionPanelProductDetails.Controls.Add(darkLabel10);
            darkSectionPanelProductDetails.Controls.Add(darkTextBoxVariationString);
            darkSectionPanelProductDetails.Controls.Add(darkLabel9);
            darkSectionPanelProductDetails.Location=new System.Drawing.Point(14, 308);
            darkSectionPanelProductDetails.Margin=new System.Windows.Forms.Padding(2);
            darkSectionPanelProductDetails.Name="darkSectionPanelProductDetails";
            darkSectionPanelProductDetails.SectionHeader="Product Details";
            darkSectionPanelProductDetails.Size=new System.Drawing.Size(364, 195);
            darkSectionPanelProductDetails.TabIndex=110;
            // 
            // cbRandom
            // 
            cbRandom.AutoSize=true;
            cbRandom.Enabled=false;
            cbRandom.Location=new System.Drawing.Point(98, 163);
            cbRandom.Margin=new System.Windows.Forms.Padding(2);
            cbRandom.Name="cbRandom";
            cbRandom.Size=new System.Drawing.Size(110, 19);
            cbRandom.TabIndex=55;
            cbRandom.Text="Random variant";
            // 
            // tbQuality
            // 
            tbQuality.Enabled=false;
            tbQuality.Location=new System.Drawing.Point(98, 103);
            tbQuality.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbQuality.Name="tbQuality";
            tbQuality.Size=new System.Drawing.Size(68, 23);
            tbQuality.TabIndex=54;
            tbQuality.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel11
            // 
            darkLabel11.AutoSize=true;
            darkLabel11.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel11.Location=new System.Drawing.Point(17, 37);
            darkLabel11.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel11.Name="darkLabel11";
            darkLabel11.Size=new System.Drawing.Size(80, 15);
            darkLabel11.TabIndex=24;
            darkLabel11.Text="Product Link :";
            // 
            // darkTextBoxProductLink
            // 
            darkTextBoxProductLink.Enabled=false;
            darkTextBoxProductLink.Location=new System.Drawing.Point(98, 37);
            darkTextBoxProductLink.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkTextBoxProductLink.Multiline=true;
            darkTextBoxProductLink.Name="darkTextBoxProductLink";
            darkTextBoxProductLink.ScrollBars=System.Windows.Forms.ScrollBars.Vertical;
            darkTextBoxProductLink.Size=new System.Drawing.Size(244, 60);
            darkTextBoxProductLink.TabIndex=23;
            // 
            // darkLabel10
            // 
            darkLabel10.AutoSize=true;
            darkLabel10.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel10.Location=new System.Drawing.Point(17, 107);
            darkLabel10.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel10.Name="darkLabel10";
            darkLabel10.Size=new System.Drawing.Size(59, 15);
            darkLabel10.TabIndex=21;
            darkLabel10.Text="Quantity :";
            // 
            // darkTextBoxVariationString
            // 
            darkTextBoxVariationString.Enabled=false;
            darkTextBoxVariationString.Location=new System.Drawing.Point(98, 132);
            darkTextBoxVariationString.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkTextBoxVariationString.Name="darkTextBoxVariationString";
            darkTextBoxVariationString.Size=new System.Drawing.Size(244, 23);
            darkTextBoxVariationString.TabIndex=18;
            darkTextBoxVariationString.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkLabel9
            // 
            darkLabel9.AutoSize=true;
            darkLabel9.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel9.Location=new System.Drawing.Point(17, 137);
            darkLabel9.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel9.Name="darkLabel9";
            darkLabel9.Size=new System.Drawing.Size(59, 15);
            darkLabel9.TabIndex=19;
            darkLabel9.Text="Variation :";
            // 
            // darkSectionPanelTimerMode
            // 
            darkSectionPanelTimerMode.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            darkSectionPanelTimerMode.Controls.Add(tbCountdownSeconds);
            darkSectionPanelTimerMode.Controls.Add(tbCountdownMinutes);
            darkSectionPanelTimerMode.Controls.Add(tbCountdownHour);
            darkSectionPanelTimerMode.Controls.Add(darkCheckBoxTomorrow);
            darkSectionPanelTimerMode.Controls.Add(darkCheckBoxScheduleBot);
            darkSectionPanelTimerMode.Controls.Add(darkLabel3);
            darkSectionPanelTimerMode.Controls.Add(darkLabel2);
            darkSectionPanelTimerMode.Controls.Add(darkLabel12);
            darkSectionPanelTimerMode.Location=new System.Drawing.Point(384, 50);
            darkSectionPanelTimerMode.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkSectionPanelTimerMode.Name="darkSectionPanelTimerMode";
            darkSectionPanelTimerMode.SectionHeader="Schedule Bot";
            darkSectionPanelTimerMode.Size=new System.Drawing.Size(376, 121);
            darkSectionPanelTimerMode.TabIndex=109;
            // 
            // tbCountdownSeconds
            // 
            tbCountdownSeconds.Enabled=false;
            tbCountdownSeconds.Location=new System.Drawing.Point(264, 61);
            tbCountdownSeconds.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbCountdownSeconds.Name="tbCountdownSeconds";
            tbCountdownSeconds.Size=new System.Drawing.Size(31, 23);
            tbCountdownSeconds.TabIndex=55;
            tbCountdownSeconds.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCountdownMinutes
            // 
            tbCountdownMinutes.Enabled=false;
            tbCountdownMinutes.Location=new System.Drawing.Point(172, 61);
            tbCountdownMinutes.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbCountdownMinutes.Name="tbCountdownMinutes";
            tbCountdownMinutes.Size=new System.Drawing.Size(31, 23);
            tbCountdownMinutes.TabIndex=54;
            tbCountdownMinutes.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCountdownHour
            // 
            tbCountdownHour.Enabled=false;
            tbCountdownHour.Location=new System.Drawing.Point(75, 61);
            tbCountdownHour.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            tbCountdownHour.Name="tbCountdownHour";
            tbCountdownHour.Size=new System.Drawing.Size(37, 23);
            tbCountdownHour.TabIndex=53;
            tbCountdownHour.TextAlign=System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // darkCheckBoxTomorrow
            // 
            darkCheckBoxTomorrow.AutoSize=true;
            darkCheckBoxTomorrow.Enabled=false;
            darkCheckBoxTomorrow.Location=new System.Drawing.Point(38, 89);
            darkCheckBoxTomorrow.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxTomorrow.Name="darkCheckBoxTomorrow";
            darkCheckBoxTomorrow.Size=new System.Drawing.Size(80, 19);
            darkCheckBoxTomorrow.TabIndex=16;
            darkCheckBoxTomorrow.Text="Tomorrow";
            // 
            // darkCheckBoxScheduleBot
            // 
            darkCheckBoxScheduleBot.AutoSize=true;
            darkCheckBoxScheduleBot.Enabled=false;
            darkCheckBoxScheduleBot.Location=new System.Drawing.Point(38, 38);
            darkCheckBoxScheduleBot.Margin=new System.Windows.Forms.Padding(2, 3, 2, 3);
            darkCheckBoxScheduleBot.Name="darkCheckBoxScheduleBot";
            darkCheckBoxScheduleBot.Size=new System.Drawing.Size(310, 19);
            darkCheckBoxScheduleBot.TabIndex=15;
            darkCheckBoxScheduleBot.Text="Schedule bot to run at specific time (24-hours format)";
            // 
            // darkLabel3
            // 
            darkLabel3.AutoSize=true;
            darkLabel3.Enabled=false;
            darkLabel3.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel3.Location=new System.Drawing.Point(208, 65);
            darkLabel3.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel3.Name="darkLabel3";
            darkLabel3.Size=new System.Drawing.Size(51, 15);
            darkLabel3.TabIndex=14;
            darkLabel3.Text="Seconds";
            // 
            // darkLabel2
            // 
            darkLabel2.AutoSize=true;
            darkLabel2.Enabled=false;
            darkLabel2.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel2.Location=new System.Drawing.Point(117, 65);
            darkLabel2.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel2.Name="darkLabel2";
            darkLabel2.Size=new System.Drawing.Size(50, 15);
            darkLabel2.TabIndex=5;
            darkLabel2.Text="Minutes";
            // 
            // darkLabel12
            // 
            darkLabel12.AutoSize=true;
            darkLabel12.Enabled=false;
            darkLabel12.ForeColor=System.Drawing.Color.FromArgb(220, 220, 220);
            darkLabel12.Location=new System.Drawing.Point(36, 65);
            darkLabel12.Margin=new System.Windows.Forms.Padding(2, 0, 2, 0);
            darkLabel12.Name="darkLabel12";
            darkLabel12.Size=new System.Drawing.Size(34, 15);
            darkLabel12.TabIndex=4;
            darkLabel12.Text="Hour";
            // 
            // darkButton1
            // 
            darkButton1.Font=new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            darkButton1.Location=new System.Drawing.Point(719, 13);
            darkButton1.Margin=new System.Windows.Forms.Padding(2);
            darkButton1.Name="darkButton1";
            darkButton1.Size=new System.Drawing.Size(123, 24);
            darkButton1.TabIndex=115;
            darkButton1.Text="Save profile";
            darkButton1.Visible=false;
            // 
            // cbVariantPreSelected
            // 
            cbVariantPreSelected.AutoSize=true;
            cbVariantPreSelected.Location=new System.Drawing.Point(214, 163);
            cbVariantPreSelected.Margin=new System.Windows.Forms.Padding(2);
            cbVariantPreSelected.Name="cbVariantPreSelected";
            cbVariantPreSelected.Size=new System.Drawing.Size(128, 19);
            cbVariantPreSelected.TabIndex=116;
            cbVariantPreSelected.Text="Variant pre selected";
            // 
            // LoadProfile
            // 
            AutoScaleDimensions=new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            ClientSize=new System.Drawing.Size(972, 515);
            Controls.Add(darkButton1);
            Controls.Add(darkSectionPanel1);
            Controls.Add(darkSectionPanelPaymentDetails);
            Controls.Add(darkSectionPanelBuyingMode);
            Controls.Add(darkSectionPanelBotSettings);
            Controls.Add(darkSectionPanelProductDetails);
            Controls.Add(darkSectionPanelTimerMode);
            Controls.Add(darkLabel1);
            Controls.Add(darkComboBoxProfile);
            Controls.Add(btnDeleteProfile);
            Controls.Add(btnLoadProfile);
            Font=new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon=(System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox=false;
            Name="LoadProfile";
            StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Text="Load Profile";
            Load+=Profile_Load_1;
            darkSectionPanel1.ResumeLayout(false);
            darkSectionPanel1.PerformLayout();
            darkSectionPanelPaymentDetails.ResumeLayout(false);
            darkSectionPanelPaymentDetails.PerformLayout();
            darkSectionPanelBuyingMode.ResumeLayout(false);
            darkSectionPanelBuyingMode.PerformLayout();
            darkSectionPanelBotSettings.ResumeLayout(false);
            darkSectionPanelBotSettings.PerformLayout();
            darkSectionPanelProductDetails.ResumeLayout(false);
            darkSectionPanelProductDetails.PerformLayout();
            darkSectionPanelTimerMode.ResumeLayout(false);
            darkSectionPanelTimerMode.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkCheckBox cbRandom;
        private DarkUI.Controls.DarkCheckBox cbVariantPreSelected;
    }
}