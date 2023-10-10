using System.Drawing;
using System.Windows.Forms;

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
            btnLoadProfile=new Button();
            btnDeleteProfile=new Button();
            darkLabel1=new Label();
            darkComboBoxProfile=new ComboBox();
            darkSectionPanel1=new GroupBox();
            darkCheckBoxRedeemShopeeVoucher=new CheckBox();
            darkCheckBoxClaimShopVoucher=new CheckBox();
            darkCheckBoxRedeemCoin=new CheckBox();
            darkSectionPanelPaymentDetails=new GroupBox();
            tbPaymentMethod=new TextBox();
            tbBankType=new TextBox();
            darkLabel14=new Label();
            tbLast4Digit=new TextBox();
            darkLabel6=new Label();
            darkLabel8=new Label();
            darkTextBoxShopeePayPin=new TextBox();
            darkLabel7=new Label();
            darkSectionPanelBuyingMode=new GroupBox();
            tbBelowSpecificPriceCARTCHECKOUTPrice=new TextBox();
            tbPriceSpecific=new TextBox();
            radioButtonPriceSpecificCARTCHECKOUT=new RadioButton();
            radioButtonCheckOutCart=new RadioButton();
            radioButtonShockingSale=new RadioButton();
            radioButtonBuyNormal=new RadioButton();
            radioButtonPriceSpecific=new RadioButton();
            darkSectionPanelBotSettings=new GroupBox();
            darkCheckBoxNotifyTelegram=new CheckBox();
            checkBoxDesktopNotification=new CheckBox();
            tbTimeOut=new TextBox();
            tbRefreshSecond=new TextBox();
            darkCheckBoxTestMode=new CheckBox();
            darkCheckBoxLogging=new CheckBox();
            darkCheckBoxRefresh=new CheckBox();
            darkLabel5=new Label();
            darkLabel4=new Label();
            darkLabel13=new Label();
            darkSectionPanelProductDetails=new GroupBox();
            cbVariantPreSelected=new CheckBox();
            cbRandom=new CheckBox();
            tbQuality=new TextBox();
            darkLabel11=new Label();
            darkTextBoxProductLink=new TextBox();
            darkLabel10=new Label();
            darkTextBoxVariationString=new TextBox();
            darkLabel9=new Label();
            darkSectionPanelTimerMode=new GroupBox();
            tbCountdownSeconds=new TextBox();
            tbCountdownMinutes=new TextBox();
            tbCountdownHour=new TextBox();
            darkCheckBoxTomorrow=new CheckBox();
            darkCheckBoxScheduleBot=new CheckBox();
            darkLabel3=new Label();
            darkLabel2=new Label();
            darkLabel12=new Label();
            darkButton1=new Button();
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
            btnLoadProfile.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnLoadProfile.Location=new Point(529, 13);
            btnLoadProfile.Margin=new Padding(2);
            btnLoadProfile.Name="btnLoadProfile";
            btnLoadProfile.Size=new Size(123, 24);
            btnLoadProfile.TabIndex=103;
            btnLoadProfile.Text="Load profile";
            btnLoadProfile.Click+=btnLoadProfile_Click;
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteProfile.Location=new Point(656, 13);
            btnDeleteProfile.Margin=new Padding(2);
            btnDeleteProfile.Name="btnDeleteProfile";
            btnDeleteProfile.Size=new Size(123, 24);
            btnDeleteProfile.TabIndex=104;
            btnDeleteProfile.Text="Delete profile";
            btnDeleteProfile.Click+=btnDeleteProfile_Click;
            // 
            // darkLabel1
            // 
            darkLabel1.AutoSize=true;
            darkLabel1.ForeColor=SystemColors.ControlText;
            darkLabel1.Location=new Point(194, 18);
            darkLabel1.Margin=new Padding(2, 0, 2, 0);
            darkLabel1.Name="darkLabel1";
            darkLabel1.Size=new Size(78, 15);
            darkLabel1.TabIndex=108;
            darkLabel1.Text="Select profile:";
            // 
            // darkComboBoxProfile
            // 
            darkComboBoxProfile.DropDownStyle=ComboBoxStyle.DropDownList;
            darkComboBoxProfile.FormattingEnabled=true;
            darkComboBoxProfile.Location=new Point(276, 13);
            darkComboBoxProfile.Margin=new Padding(2, 3, 2, 3);
            darkComboBoxProfile.Name="darkComboBoxProfile";
            darkComboBoxProfile.Size=new Size(249, 23);
            darkComboBoxProfile.TabIndex=107;
            darkComboBoxProfile.SelectedIndexChanged+=darkComboBoxProfile_SelectedIndexChanged;
            // 
            // darkSectionPanel1
            // 
            darkSectionPanel1.Controls.Add(darkCheckBoxRedeemShopeeVoucher);
            darkSectionPanel1.Controls.Add(darkCheckBoxClaimShopVoucher);
            darkSectionPanel1.Controls.Add(darkCheckBoxRedeemCoin);
            darkSectionPanel1.Location=new Point(765, 50);
            darkSectionPanel1.Name="darkSectionPanel1";
            darkSectionPanel1.Size=new Size(192, 151);
            darkSectionPanel1.TabIndex=114;
            darkSectionPanel1.TabStop=false;
            darkSectionPanel1.Text="Voucher && coin";
            // 
            // darkCheckBoxRedeemShopeeVoucher
            // 
            darkCheckBoxRedeemShopeeVoucher.AutoSize=true;
            darkCheckBoxRedeemShopeeVoucher.Enabled=false;
            darkCheckBoxRedeemShopeeVoucher.Location=new Point(11, 77);
            darkCheckBoxRedeemShopeeVoucher.Margin=new Padding(2, 3, 2, 3);
            darkCheckBoxRedeemShopeeVoucher.Name="darkCheckBoxRedeemShopeeVoucher";
            darkCheckBoxRedeemShopeeVoucher.Size=new Size(179, 19);
            darkCheckBoxRedeemShopeeVoucher.TabIndex=52;
            darkCheckBoxRedeemShopeeVoucher.Text="Redeem any Shopee voucher";
            // 
            // darkCheckBoxClaimShopVoucher
            // 
            darkCheckBoxClaimShopVoucher.AutoSize=true;
            darkCheckBoxClaimShopVoucher.Enabled=false;
            darkCheckBoxClaimShopVoucher.Location=new Point(11, 44);
            darkCheckBoxClaimShopVoucher.Margin=new Padding(2);
            darkCheckBoxClaimShopVoucher.Name="darkCheckBoxClaimShopVoucher";
            darkCheckBoxClaimShopVoucher.Size=new Size(154, 19);
            darkCheckBoxClaimShopVoucher.TabIndex=50;
            darkCheckBoxClaimShopVoucher.Text="Claim any shop voucher";
            // 
            // darkCheckBoxRedeemCoin
            // 
            darkCheckBoxRedeemCoin.AutoSize=true;
            darkCheckBoxRedeemCoin.Enabled=false;
            darkCheckBoxRedeemCoin.Location=new Point(11, 110);
            darkCheckBoxRedeemCoin.Margin=new Padding(2, 3, 2, 3);
            darkCheckBoxRedeemCoin.Name="darkCheckBoxRedeemCoin";
            darkCheckBoxRedeemCoin.Size=new Size(95, 19);
            darkCheckBoxRedeemCoin.TabIndex=42;
            darkCheckBoxRedeemCoin.Text="Redeem coin";
            // 
            // darkSectionPanelPaymentDetails
            // 
            darkSectionPanelPaymentDetails.Controls.Add(tbPaymentMethod);
            darkSectionPanelPaymentDetails.Controls.Add(tbBankType);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel14);
            darkSectionPanelPaymentDetails.Controls.Add(tbLast4Digit);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel6);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel8);
            darkSectionPanelPaymentDetails.Controls.Add(darkTextBoxShopeePayPin);
            darkSectionPanelPaymentDetails.Controls.Add(darkLabel7);
            darkSectionPanelPaymentDetails.Location=new Point(384, 308);
            darkSectionPanelPaymentDetails.Margin=new Padding(2, 3, 2, 3);
            darkSectionPanelPaymentDetails.Name="darkSectionPanelPaymentDetails";
            darkSectionPanelPaymentDetails.Size=new Size(376, 195);
            darkSectionPanelPaymentDetails.TabIndex=113;
            darkSectionPanelPaymentDetails.TabStop=false;
            darkSectionPanelPaymentDetails.Text="Payment Details";
            // 
            // tbPaymentMethod
            // 
            tbPaymentMethod.Enabled=false;
            tbPaymentMethod.Location=new Point(145, 44);
            tbPaymentMethod.Margin=new Padding(2, 3, 2, 3);
            tbPaymentMethod.MaxLength=4;
            tbPaymentMethod.Name="tbPaymentMethod";
            tbPaymentMethod.Size=new Size(202, 23);
            tbPaymentMethod.TabIndex=53;
            tbPaymentMethod.TextAlign=HorizontalAlignment.Center;
            // 
            // tbBankType
            // 
            tbBankType.Enabled=false;
            tbBankType.Location=new Point(145, 78);
            tbBankType.Margin=new Padding(2, 3, 2, 3);
            tbBankType.MaxLength=4;
            tbBankType.Name="tbBankType";
            tbBankType.Size=new Size(202, 23);
            tbBankType.TabIndex=52;
            tbBankType.TextAlign=HorizontalAlignment.Center;
            // 
            // darkLabel14
            // 
            darkLabel14.AutoSize=true;
            darkLabel14.ForeColor=SystemColors.ControlText;
            darkLabel14.Location=new Point(17, 114);
            darkLabel14.Margin=new Padding(2, 0, 2, 0);
            darkLabel14.Name="darkLabel14";
            darkLabel14.Size=new Size(175, 15);
            darkLabel14.TabIndex=51;
            darkLabel14.Text="Last 4 digit of debit/credit card :";
            // 
            // tbLast4Digit
            // 
            tbLast4Digit.Enabled=false;
            tbLast4Digit.Location=new Point(223, 109);
            tbLast4Digit.Margin=new Padding(2, 3, 2, 3);
            tbLast4Digit.MaxLength=4;
            tbLast4Digit.Name="tbLast4Digit";
            tbLast4Digit.Size=new Size(124, 23);
            tbLast4Digit.TabIndex=50;
            tbLast4Digit.TextAlign=HorizontalAlignment.Center;
            // 
            // darkLabel6
            // 
            darkLabel6.AutoSize=true;
            darkLabel6.ForeColor=SystemColors.ControlText;
            darkLabel6.Location=new Point(17, 48);
            darkLabel6.Margin=new Padding(2, 0, 2, 0);
            darkLabel6.Name="darkLabel6";
            darkLabel6.Size=new Size(105, 15);
            darkLabel6.TabIndex=14;
            darkLabel6.Text="Payment method :";
            // 
            // darkLabel8
            // 
            darkLabel8.AutoSize=true;
            darkLabel8.ForeColor=SystemColors.ControlText;
            darkLabel8.Location=new Point(17, 82);
            darkLabel8.Margin=new Padding(2, 0, 2, 0);
            darkLabel8.Name="darkLabel8";
            darkLabel8.Size=new Size(65, 15);
            darkLabel8.TabIndex=31;
            darkLabel8.Text="Bank type :";
            // 
            // darkTextBoxShopeePayPin
            // 
            darkTextBoxShopeePayPin.Enabled=false;
            darkTextBoxShopeePayPin.Location=new Point(223, 141);
            darkTextBoxShopeePayPin.Margin=new Padding(2, 3, 2, 3);
            darkTextBoxShopeePayPin.MaxLength=6;
            darkTextBoxShopeePayPin.Name="darkTextBoxShopeePayPin";
            darkTextBoxShopeePayPin.Size=new Size(124, 23);
            darkTextBoxShopeePayPin.TabIndex=13;
            darkTextBoxShopeePayPin.TextAlign=HorizontalAlignment.Center;
            // 
            // darkLabel7
            // 
            darkLabel7.AutoSize=true;
            darkLabel7.ForeColor=SystemColors.ControlText;
            darkLabel7.Location=new Point(17, 147);
            darkLabel7.Margin=new Padding(2, 0, 2, 0);
            darkLabel7.Name="darkLabel7";
            darkLabel7.Size=new Size(93, 15);
            darkLabel7.TabIndex=15;
            darkLabel7.Text="ShopeePay PIN :";
            // 
            // darkSectionPanelBuyingMode
            // 
            darkSectionPanelBuyingMode.Controls.Add(tbBelowSpecificPriceCARTCHECKOUTPrice);
            darkSectionPanelBuyingMode.Controls.Add(tbPriceSpecific);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonPriceSpecificCARTCHECKOUT);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonCheckOutCart);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonShockingSale);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonBuyNormal);
            darkSectionPanelBuyingMode.Controls.Add(radioButtonPriceSpecific);
            darkSectionPanelBuyingMode.Location=new Point(384, 177);
            darkSectionPanelBuyingMode.Margin=new Padding(2, 3, 2, 3);
            darkSectionPanelBuyingMode.Name="darkSectionPanelBuyingMode";
            darkSectionPanelBuyingMode.Size=new Size(376, 126);
            darkSectionPanelBuyingMode.TabIndex=112;
            darkSectionPanelBuyingMode.TabStop=false;
            darkSectionPanelBuyingMode.Text="Buy Mode";
            // 
            // tbBelowSpecificPriceCARTCHECKOUTPrice
            // 
            tbBelowSpecificPriceCARTCHECKOUTPrice.Enabled=false;
            tbBelowSpecificPriceCARTCHECKOUTPrice.Location=new Point(280, 93);
            tbBelowSpecificPriceCARTCHECKOUTPrice.Margin=new Padding(2, 3, 2, 3);
            tbBelowSpecificPriceCARTCHECKOUTPrice.Name="tbBelowSpecificPriceCARTCHECKOUTPrice";
            tbBelowSpecificPriceCARTCHECKOUTPrice.Size=new Size(67, 23);
            tbBelowSpecificPriceCARTCHECKOUTPrice.TabIndex=54;
            tbBelowSpecificPriceCARTCHECKOUTPrice.TextAlign=HorizontalAlignment.Center;
            // 
            // tbPriceSpecific
            // 
            tbPriceSpecific.Enabled=false;
            tbPriceSpecific.Location=new Point(280, 63);
            tbPriceSpecific.Margin=new Padding(2, 3, 2, 3);
            tbPriceSpecific.Name="tbPriceSpecific";
            tbPriceSpecific.Size=new Size(67, 23);
            tbPriceSpecific.TabIndex=50;
            tbPriceSpecific.TextAlign=HorizontalAlignment.Center;
            // 
            // radioButtonPriceSpecificCARTCHECKOUT
            // 
            radioButtonPriceSpecificCARTCHECKOUT.AutoSize=true;
            radioButtonPriceSpecificCARTCHECKOUT.Enabled=false;
            radioButtonPriceSpecificCARTCHECKOUT.ForeColor=SystemColors.ControlText;
            radioButtonPriceSpecificCARTCHECKOUT.Location=new Point(26, 96);
            radioButtonPriceSpecificCARTCHECKOUT.Margin=new Padding(2, 3, 2, 3);
            radioButtonPriceSpecificCARTCHECKOUT.Name="radioButtonPriceSpecificCARTCHECKOUT";
            radioButtonPriceSpecificCARTCHECKOUT.Size=new Size(220, 19);
            radioButtonPriceSpecificCARTCHECKOUT.TabIndex=53;
            radioButtonPriceSpecificCARTCHECKOUT.Text="Below specific price (Cart checkout) :";
            // 
            // radioButtonCheckOutCart
            // 
            radioButtonCheckOutCart.AutoSize=true;
            radioButtonCheckOutCart.Enabled=false;
            radioButtonCheckOutCart.ForeColor=SystemColors.ControlText;
            radioButtonCheckOutCart.Location=new Point(26, 66);
            radioButtonCheckOutCart.Margin=new Padding(2, 3, 2, 3);
            radioButtonCheckOutCart.Name="radioButtonCheckOutCart";
            radioButtonCheckOutCart.Size=new Size(99, 19);
            radioButtonCheckOutCart.TabIndex=52;
            radioButtonCheckOutCart.Text="Cart checkout";
            // 
            // radioButtonShockingSale
            // 
            radioButtonShockingSale.AutoSize=true;
            radioButtonShockingSale.Enabled=false;
            radioButtonShockingSale.ForeColor=SystemColors.ControlText;
            radioButtonShockingSale.Location=new Point(145, 36);
            radioButtonShockingSale.Margin=new Padding(2, 3, 2, 3);
            radioButtonShockingSale.Name="radioButtonShockingSale";
            radioButtonShockingSale.Size=new Size(163, 19);
            radioButtonShockingSale.TabIndex=51;
            radioButtonShockingSale.Text="Flash/Shocking sale mode";
            // 
            // radioButtonBuyNormal
            // 
            radioButtonBuyNormal.AutoSize=true;
            radioButtonBuyNormal.Checked=true;
            radioButtonBuyNormal.Enabled=false;
            radioButtonBuyNormal.ForeColor=SystemColors.ControlText;
            radioButtonBuyNormal.Location=new Point(26, 36);
            radioButtonBuyNormal.Margin=new Padding(2, 3, 2, 3);
            radioButtonBuyNormal.Name="radioButtonBuyNormal";
            radioButtonBuyNormal.Size=new Size(99, 19);
            radioButtonBuyNormal.TabIndex=50;
            radioButtonBuyNormal.TabStop=true;
            radioButtonBuyNormal.Text="Normal mode";
            // 
            // radioButtonPriceSpecific
            // 
            radioButtonPriceSpecific.AutoSize=true;
            radioButtonPriceSpecific.Enabled=false;
            radioButtonPriceSpecific.ForeColor=SystemColors.ControlText;
            radioButtonPriceSpecific.Location=new Point(146, 66);
            radioButtonPriceSpecific.Margin=new Padding(2, 3, 2, 3);
            radioButtonPriceSpecific.Name="radioButtonPriceSpecific";
            radioButtonPriceSpecific.Size=new Size(135, 19);
            radioButtonPriceSpecific.TabIndex=15;
            radioButtonPriceSpecific.Text="Below specific price :";
            // 
            // darkSectionPanelBotSettings
            // 
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxNotifyTelegram);
            darkSectionPanelBotSettings.Controls.Add(checkBoxDesktopNotification);
            darkSectionPanelBotSettings.Controls.Add(tbTimeOut);
            darkSectionPanelBotSettings.Controls.Add(tbRefreshSecond);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxTestMode);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxLogging);
            darkSectionPanelBotSettings.Controls.Add(darkCheckBoxRefresh);
            darkSectionPanelBotSettings.Controls.Add(darkLabel5);
            darkSectionPanelBotSettings.Controls.Add(darkLabel4);
            darkSectionPanelBotSettings.Controls.Add(darkLabel13);
            darkSectionPanelBotSettings.Location=new Point(14, 50);
            darkSectionPanelBotSettings.Margin=new Padding(2, 3, 2, 3);
            darkSectionPanelBotSettings.Name="darkSectionPanelBotSettings";
            darkSectionPanelBotSettings.Size=new Size(364, 253);
            darkSectionPanelBotSettings.TabIndex=111;
            darkSectionPanelBotSettings.TabStop=false;
            darkSectionPanelBotSettings.Text="Bot Settings";
            // 
            // darkCheckBoxNotifyTelegram
            // 
            darkCheckBoxNotifyTelegram.AutoSize=true;
            darkCheckBoxNotifyTelegram.Enabled=false;
            darkCheckBoxNotifyTelegram.Location=new Point(24, 36);
            darkCheckBoxNotifyTelegram.Margin=new Padding(2);
            darkCheckBoxNotifyTelegram.Name="darkCheckBoxNotifyTelegram";
            darkCheckBoxNotifyTelegram.Size=new Size(307, 19);
            darkCheckBoxNotifyTelegram.TabIndex=54;
            darkCheckBoxNotifyTelegram.Text="Send notification to Telegram on successful checkout";
            // 
            // checkBoxDesktopNotification
            // 
            checkBoxDesktopNotification.AutoSize=true;
            checkBoxDesktopNotification.Enabled=false;
            checkBoxDesktopNotification.Location=new Point(24, 74);
            checkBoxDesktopNotification.Margin=new Padding(2);
            checkBoxDesktopNotification.Name="checkBoxDesktopNotification";
            checkBoxDesktopNotification.Size=new Size(290, 19);
            checkBoxDesktopNotification.TabIndex=53;
            checkBoxDesktopNotification.Text="Show desktop notification on successful checkout";
            // 
            // tbTimeOut
            // 
            tbTimeOut.Enabled=false;
            tbTimeOut.Location=new Point(133, 219);
            tbTimeOut.Margin=new Padding(2, 3, 2, 3);
            tbTimeOut.Name="tbTimeOut";
            tbTimeOut.Size=new Size(31, 23);
            tbTimeOut.TabIndex=52;
            tbTimeOut.TextAlign=HorizontalAlignment.Center;
            // 
            // tbRefreshSecond
            // 
            tbRefreshSecond.Enabled=false;
            tbRefreshSecond.Location=new Point(257, 109);
            tbRefreshSecond.Margin=new Padding(2, 3, 2, 3);
            tbRefreshSecond.Name="tbRefreshSecond";
            tbRefreshSecond.Size=new Size(31, 23);
            tbRefreshSecond.TabIndex=51;
            tbRefreshSecond.TextAlign=HorizontalAlignment.Center;
            // 
            // darkCheckBoxTestMode
            // 
            darkCheckBoxTestMode.AutoSize=true;
            darkCheckBoxTestMode.Enabled=false;
            darkCheckBoxTestMode.Location=new Point(24, 185);
            darkCheckBoxTestMode.Margin=new Padding(2);
            darkCheckBoxTestMode.Name="darkCheckBoxTestMode";
            darkCheckBoxTestMode.Size=new Size(80, 19);
            darkCheckBoxTestMode.TabIndex=49;
            darkCheckBoxTestMode.Text="Test mode";
            // 
            // darkCheckBoxLogging
            // 
            darkCheckBoxLogging.AutoSize=true;
            darkCheckBoxLogging.Enabled=false;
            darkCheckBoxLogging.Location=new Point(24, 148);
            darkCheckBoxLogging.Margin=new Padding(2);
            darkCheckBoxLogging.Name="darkCheckBoxLogging";
            darkCheckBoxLogging.Size=new Size(108, 19);
            darkCheckBoxLogging.TabIndex=50;
            darkCheckBoxLogging.Text="Disable logging";
            // 
            // darkCheckBoxRefresh
            // 
            darkCheckBoxRefresh.AutoSize=true;
            darkCheckBoxRefresh.Enabled=false;
            darkCheckBoxRefresh.Location=new Point(24, 111);
            darkCheckBoxRefresh.Margin=new Padding(2);
            darkCheckBoxRefresh.Name="darkCheckBoxRefresh";
            darkCheckBoxRefresh.Size=new Size(142, 19);
            darkCheckBoxRefresh.TabIndex=48;
            darkCheckBoxRefresh.Text="Auto refresh webpage";
            // 
            // darkLabel5
            // 
            darkLabel5.AutoSize=true;
            darkLabel5.ForeColor=SystemColors.ControlText;
            darkLabel5.Location=new Point(292, 113);
            darkLabel5.Margin=new Padding(2, 0, 2, 0);
            darkLabel5.Name="darkLabel5";
            darkLabel5.Size=new Size(50, 15);
            darkLabel5.TabIndex=11;
            darkLabel5.Text="seconds";
            // 
            // darkLabel4
            // 
            darkLabel4.AutoSize=true;
            darkLabel4.ForeColor=SystemColors.ControlText;
            darkLabel4.Location=new Point(176, 113);
            darkLabel4.Margin=new Padding(2, 0, 2, 0);
            darkLabel4.Name="darkLabel4";
            darkLabel4.Size=new Size(77, 15);
            darkLabel4.TabIndex=10;
            darkLabel4.Text="Refresh every";
            // 
            // darkLabel13
            // 
            darkLabel13.AutoSize=true;
            darkLabel13.ForeColor=SystemColors.ControlText;
            darkLabel13.Location=new Point(20, 222);
            darkLabel13.Margin=new Padding(2, 0, 2, 0);
            darkLabel13.Name="darkLabel13";
            darkLabel13.Size=new Size(109, 15);
            darkLabel13.TabIndex=45;
            darkLabel13.Text="Time out (second) :";
            // 
            // darkSectionPanelProductDetails
            // 
            darkSectionPanelProductDetails.Controls.Add(cbVariantPreSelected);
            darkSectionPanelProductDetails.Controls.Add(cbRandom);
            darkSectionPanelProductDetails.Controls.Add(tbQuality);
            darkSectionPanelProductDetails.Controls.Add(darkLabel11);
            darkSectionPanelProductDetails.Controls.Add(darkTextBoxProductLink);
            darkSectionPanelProductDetails.Controls.Add(darkLabel10);
            darkSectionPanelProductDetails.Controls.Add(darkTextBoxVariationString);
            darkSectionPanelProductDetails.Controls.Add(darkLabel9);
            darkSectionPanelProductDetails.Location=new Point(14, 308);
            darkSectionPanelProductDetails.Margin=new Padding(2);
            darkSectionPanelProductDetails.Name="darkSectionPanelProductDetails";
            darkSectionPanelProductDetails.Size=new Size(364, 195);
            darkSectionPanelProductDetails.TabIndex=110;
            darkSectionPanelProductDetails.TabStop=false;
            darkSectionPanelProductDetails.Text="Product Details";
            // 
            // cbVariantPreSelected
            // 
            cbVariantPreSelected.AutoSize=true;
            cbVariantPreSelected.Enabled=false;
            cbVariantPreSelected.Location=new Point(214, 163);
            cbVariantPreSelected.Margin=new Padding(2);
            cbVariantPreSelected.Name="cbVariantPreSelected";
            cbVariantPreSelected.Size=new Size(128, 19);
            cbVariantPreSelected.TabIndex=116;
            cbVariantPreSelected.Text="Variant pre selected";
            // 
            // cbRandom
            // 
            cbRandom.AutoSize=true;
            cbRandom.Enabled=false;
            cbRandom.Location=new Point(98, 163);
            cbRandom.Margin=new Padding(2);
            cbRandom.Name="cbRandom";
            cbRandom.Size=new Size(110, 19);
            cbRandom.TabIndex=55;
            cbRandom.Text="Random variant";
            // 
            // tbQuality
            // 
            tbQuality.Enabled=false;
            tbQuality.Location=new Point(98, 103);
            tbQuality.Margin=new Padding(2, 3, 2, 3);
            tbQuality.Name="tbQuality";
            tbQuality.Size=new Size(68, 23);
            tbQuality.TabIndex=54;
            tbQuality.TextAlign=HorizontalAlignment.Center;
            // 
            // darkLabel11
            // 
            darkLabel11.AutoSize=true;
            darkLabel11.ForeColor=SystemColors.ControlText;
            darkLabel11.Location=new Point(17, 37);
            darkLabel11.Margin=new Padding(2, 0, 2, 0);
            darkLabel11.Name="darkLabel11";
            darkLabel11.Size=new Size(77, 15);
            darkLabel11.TabIndex=24;
            darkLabel11.Text="Product link :";
            // 
            // darkTextBoxProductLink
            // 
            darkTextBoxProductLink.Enabled=false;
            darkTextBoxProductLink.Location=new Point(98, 37);
            darkTextBoxProductLink.Margin=new Padding(2, 3, 2, 3);
            darkTextBoxProductLink.Multiline=true;
            darkTextBoxProductLink.Name="darkTextBoxProductLink";
            darkTextBoxProductLink.ScrollBars=ScrollBars.Vertical;
            darkTextBoxProductLink.Size=new Size(244, 60);
            darkTextBoxProductLink.TabIndex=23;
            // 
            // darkLabel10
            // 
            darkLabel10.AutoSize=true;
            darkLabel10.ForeColor=SystemColors.ControlText;
            darkLabel10.Location=new Point(17, 107);
            darkLabel10.Margin=new Padding(2, 0, 2, 0);
            darkLabel10.Name="darkLabel10";
            darkLabel10.Size=new Size(59, 15);
            darkLabel10.TabIndex=21;
            darkLabel10.Text="Quantity :";
            // 
            // darkTextBoxVariationString
            // 
            darkTextBoxVariationString.Enabled=false;
            darkTextBoxVariationString.Location=new Point(98, 132);
            darkTextBoxVariationString.Margin=new Padding(2, 3, 2, 3);
            darkTextBoxVariationString.Name="darkTextBoxVariationString";
            darkTextBoxVariationString.Size=new Size(244, 23);
            darkTextBoxVariationString.TabIndex=18;
            darkTextBoxVariationString.TextAlign=HorizontalAlignment.Center;
            // 
            // darkLabel9
            // 
            darkLabel9.AutoSize=true;
            darkLabel9.ForeColor=SystemColors.ControlText;
            darkLabel9.Location=new Point(17, 137);
            darkLabel9.Margin=new Padding(2, 0, 2, 0);
            darkLabel9.Name="darkLabel9";
            darkLabel9.Size=new Size(59, 15);
            darkLabel9.TabIndex=19;
            darkLabel9.Text="Variation :";
            // 
            // darkSectionPanelTimerMode
            // 
            darkSectionPanelTimerMode.Controls.Add(tbCountdownSeconds);
            darkSectionPanelTimerMode.Controls.Add(tbCountdownMinutes);
            darkSectionPanelTimerMode.Controls.Add(tbCountdownHour);
            darkSectionPanelTimerMode.Controls.Add(darkCheckBoxTomorrow);
            darkSectionPanelTimerMode.Controls.Add(darkCheckBoxScheduleBot);
            darkSectionPanelTimerMode.Controls.Add(darkLabel3);
            darkSectionPanelTimerMode.Controls.Add(darkLabel2);
            darkSectionPanelTimerMode.Controls.Add(darkLabel12);
            darkSectionPanelTimerMode.Location=new Point(384, 50);
            darkSectionPanelTimerMode.Margin=new Padding(2, 3, 2, 3);
            darkSectionPanelTimerMode.Name="darkSectionPanelTimerMode";
            darkSectionPanelTimerMode.Size=new Size(376, 121);
            darkSectionPanelTimerMode.TabIndex=109;
            darkSectionPanelTimerMode.TabStop=false;
            darkSectionPanelTimerMode.Text="Schedule Bot";
            // 
            // tbCountdownSeconds
            // 
            tbCountdownSeconds.Enabled=false;
            tbCountdownSeconds.Location=new Point(264, 61);
            tbCountdownSeconds.Margin=new Padding(2, 3, 2, 3);
            tbCountdownSeconds.Name="tbCountdownSeconds";
            tbCountdownSeconds.Size=new Size(31, 23);
            tbCountdownSeconds.TabIndex=55;
            tbCountdownSeconds.TextAlign=HorizontalAlignment.Center;
            // 
            // tbCountdownMinutes
            // 
            tbCountdownMinutes.Enabled=false;
            tbCountdownMinutes.Location=new Point(172, 61);
            tbCountdownMinutes.Margin=new Padding(2, 3, 2, 3);
            tbCountdownMinutes.Name="tbCountdownMinutes";
            tbCountdownMinutes.Size=new Size(31, 23);
            tbCountdownMinutes.TabIndex=54;
            tbCountdownMinutes.TextAlign=HorizontalAlignment.Center;
            // 
            // tbCountdownHour
            // 
            tbCountdownHour.Enabled=false;
            tbCountdownHour.Location=new Point(75, 61);
            tbCountdownHour.Margin=new Padding(2, 3, 2, 3);
            tbCountdownHour.Name="tbCountdownHour";
            tbCountdownHour.Size=new Size(37, 23);
            tbCountdownHour.TabIndex=53;
            tbCountdownHour.TextAlign=HorizontalAlignment.Center;
            // 
            // darkCheckBoxTomorrow
            // 
            darkCheckBoxTomorrow.AutoSize=true;
            darkCheckBoxTomorrow.Enabled=false;
            darkCheckBoxTomorrow.Location=new Point(38, 89);
            darkCheckBoxTomorrow.Margin=new Padding(2, 3, 2, 3);
            darkCheckBoxTomorrow.Name="darkCheckBoxTomorrow";
            darkCheckBoxTomorrow.Size=new Size(80, 19);
            darkCheckBoxTomorrow.TabIndex=16;
            darkCheckBoxTomorrow.Text="Tomorrow";
            // 
            // darkCheckBoxScheduleBot
            // 
            darkCheckBoxScheduleBot.AutoSize=true;
            darkCheckBoxScheduleBot.Enabled=false;
            darkCheckBoxScheduleBot.Location=new Point(38, 38);
            darkCheckBoxScheduleBot.Margin=new Padding(2, 3, 2, 3);
            darkCheckBoxScheduleBot.Name="darkCheckBoxScheduleBot";
            darkCheckBoxScheduleBot.Size=new Size(310, 19);
            darkCheckBoxScheduleBot.TabIndex=15;
            darkCheckBoxScheduleBot.Text="Schedule bot to run at specific time (24-hours format)";
            // 
            // darkLabel3
            // 
            darkLabel3.AutoSize=true;
            darkLabel3.Enabled=false;
            darkLabel3.ForeColor=SystemColors.ControlText;
            darkLabel3.Location=new Point(208, 65);
            darkLabel3.Margin=new Padding(2, 0, 2, 0);
            darkLabel3.Name="darkLabel3";
            darkLabel3.Size=new Size(51, 15);
            darkLabel3.TabIndex=14;
            darkLabel3.Text="Seconds";
            // 
            // darkLabel2
            // 
            darkLabel2.AutoSize=true;
            darkLabel2.Enabled=false;
            darkLabel2.ForeColor=SystemColors.ControlText;
            darkLabel2.Location=new Point(117, 65);
            darkLabel2.Margin=new Padding(2, 0, 2, 0);
            darkLabel2.Name="darkLabel2";
            darkLabel2.Size=new Size(50, 15);
            darkLabel2.TabIndex=5;
            darkLabel2.Text="Minutes";
            // 
            // darkLabel12
            // 
            darkLabel12.AutoSize=true;
            darkLabel12.Enabled=false;
            darkLabel12.ForeColor=SystemColors.ControlText;
            darkLabel12.Location=new Point(36, 65);
            darkLabel12.Margin=new Padding(2, 0, 2, 0);
            darkLabel12.Name="darkLabel12";
            darkLabel12.Size=new Size(34, 15);
            darkLabel12.TabIndex=4;
            darkLabel12.Text="Hour";
            // 
            // darkButton1
            // 
            darkButton1.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            darkButton1.Location=new Point(719, 13);
            darkButton1.Margin=new Padding(2);
            darkButton1.Name="darkButton1";
            darkButton1.Size=new Size(123, 24);
            darkButton1.TabIndex=115;
            darkButton1.Text="Save profile";
            darkButton1.Visible=false;
            // 
            // LoadProfile
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=SystemColors.ActiveCaption;
            ClientSize=new Size(972, 515);
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
            Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            Icon=(Icon)resources.GetObject("$this.Icon");
            MaximizeBox=false;
            Name="LoadProfile";
            StartPosition=FormStartPosition.CenterScreen;
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
        private Button btnLoadProfile;
        private Button btnDeleteProfile;
        private Label darkLabel1;
        private ComboBox darkComboBoxProfile;
        private GroupBox darkSectionPanel1;
        private CheckBox darkCheckBoxRedeemShopeeVoucher;
        private CheckBox darkCheckBoxClaimShopVoucher;
        private CheckBox darkCheckBoxRedeemCoin;
        private GroupBox darkSectionPanelPaymentDetails;
        private TextBox tbPaymentMethod;
        private TextBox tbBankType;
        private Label darkLabel14;
        private TextBox tbLast4Digit;
        private Label darkLabel6;
        private Label darkLabel8;
        private TextBox darkTextBoxShopeePayPin;
        private Label darkLabel7;
        private GroupBox darkSectionPanelBuyingMode;
        private TextBox tbBelowSpecificPriceCARTCHECKOUTPrice;
        private TextBox tbPriceSpecific;
        private RadioButton radioButtonPriceSpecificCARTCHECKOUT;
        private RadioButton radioButtonCheckOutCart;
        private RadioButton radioButtonShockingSale;
        private RadioButton radioButtonBuyNormal;
        private RadioButton radioButtonPriceSpecific;
        private GroupBox darkSectionPanelBotSettings;
        private TextBox tbTimeOut;
        private TextBox tbRefreshSecond;
        private CheckBox darkCheckBoxTestMode;
        private CheckBox darkCheckBoxLogging;
        private CheckBox darkCheckBoxRefresh;
        private CheckBox darkCheckBoxHeadless;
        private Label darkLabel5;
        private Label darkLabel4;
        private Label darkLabel13;
        private CheckBox darkCheckBoxDisableImageExtension;
        private GroupBox darkSectionPanelProductDetails;
        private TextBox tbQuality;
        private Label darkLabel11;
        private TextBox darkTextBoxProductLink;
        private Label darkLabel10;
        private TextBox darkTextBoxVariationString;
        private Label darkLabel9;
        private GroupBox darkSectionPanelTimerMode;
        private TextBox tbCountdownSeconds;
        private TextBox tbCountdownMinutes;
        private TextBox tbCountdownHour;
        private CheckBox darkCheckBoxTomorrow;
        private CheckBox darkCheckBoxScheduleBot;
        private Label darkLabel3;
        private Label darkLabel2;
        private Label darkLabel12;
        private Button darkButton1;
        private CheckBox cbRandom;
        private CheckBox cbVariantPreSelected;
        private CheckBox checkBoxDesktopNotification;
        private CheckBox darkCheckBoxNotifyTelegram;
    }
}