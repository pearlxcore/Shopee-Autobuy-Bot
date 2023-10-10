using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Models;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    public partial class Element_Editor : Form
    {
        public Element_Editor()
        {
            InitializeComponent();
        }

        private void Element_Editor_Load(object sender, EventArgs e)
        {
            if (AutoBuyInfo.ConstantElements is null)
            { MessageBox.Show("No elements settings found. Create new settings by saving new one or choose option 'Update element from repository'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
                LoadElementsToControls(AutoBuyInfo.ConstantElements);
        }

        private void LoadElementsToControls(ElementModel.Root element)
        {
            tbBuyNowButton_product.Text = element.ProductPage.BuyNowButton;
            tbVariationFlexBox_product.Text = element.ProductPage.ProductVariationContainer;
            tbQuantityTextbox_product.Text = element.ProductPage.QuantityCheckbox;
            tbCurrentPriceLabel_product.Text = element.ProductPage.CurrentPriceLabel;
            tbSaleBanner_product.Text = element.ProductPage.SaleBanner;
            tbUnlisted_product.Text = element.ProductPage.UnlistedError;

            tbCheckoutButton_cart.Text = element.CartPage.CheckOutButton;
            tbSelectAllCheckbox_cart.Text = element.CartPage.SelectAllCheckbox;
            tbCartTotalPrice.Text = element.CartPage.CartTotalPriceLabel;
            tbClaimShopVC_cart.Text = element.CartPage.ClaimShopVoucherButton;
            tbCartEmptyLabel_cart.Text = element.CartPage.CartEmptyLabel;
            tbSelectAllLabel.Text = element.CartPage.SelectAllLabel;

            tbPLaceOrderButton_placeOrder.Text = element.CheckoutPage.PlaceOrderButton;
            tbSelectShopeeVcButton_placeOrder.Text = element.CheckoutPage.SelectShopeeVoucherButton;
            tbShopeeVcContainer_placeOrder.Text = element.CheckoutPage.ShopeeVoucherContainer;
            tbClaimShopeeVcOkButton_placeOrder.Text = element.CheckoutPage.ShopeeVoucherOkButton;
            tbRedeemCoinCheckbox_placeOrder.Text = element.CheckoutPage.RedeemCoinCheckbox;
            tbCHangePaymentButton_placeOrder.Text = element.CheckoutPage.ChangePaymentButton;
            tbOrderPrice_placeOrder.Text = element.CheckoutPage.OrderPrice;

            // payment type
            tbPayment_OnlineBanking.Text = element.Payment.PaymentMethod.OnlineBanking;
            tbPayment_ATM_CashDeposit.Text = element.Payment.PaymentMethod.ATM_CashDeposit;
            tbPayment_COD.Text = element.Payment.PaymentMethod.CashOnDelivery;
            tbPayment_ConvenienceStore.Text = element.Payment.PaymentMethod.ConvenienceStores;
            tbPayment_Debit_CreditCard.Text = element.Payment.PaymentMethod.DebitCreditCard;
            tbPayment_CreditCardInstallment.Text = element.Payment.PaymentMethod.CreditCardInstallment;
            tbPayment_GooglePay.Text = element.Payment.PaymentMethod.GooglePay;

            // payment error message
            tbErrMess_ActivateShopeePay.Text = element.Payment.PaymentErrorMessage.ActivateShopeePay;
            tbErrMess_BankMaintenance.Text = element.Payment.PaymentErrorMessage.BankMaintenance;
            tbErrMess_CartOutOfStock.Text = element.Payment.PaymentErrorMessage.CartItemOutOfStock;
            tbErrMess_InactiveProduct.Text = element.Payment.PaymentErrorMessage.InactiveProducts;
            tbErrMess_InsuffShopeePay.Text = element.Payment.PaymentErrorMessage.ShopeePayInsufficientFund;
            tbErrMess_InvalidShopeePayPin.Text = element.Payment.PaymentErrorMessage.InvalidShopeePayPin;
            tbErrMess_TransExceeded.Text = element.Payment.PaymentErrorMessage.TransactionExceeded;
            tbErrMess_PayNowMaintenance.Text = element.Payment.PaymentErrorMessage.PayNowMaintenance;

            // convenience store type
            tbConvStoreType_SevenEleven.Text = element.Payment.PaymentConvenienceStoresType.SevenEleven;
            tbConvStoreType_KKMart.Text = element.Payment.PaymentConvenienceStoresType.KKMart;
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveElementsSettings();
        }

        private void SaveElementsSettings()
        {
            try
            {
                var productPage = new ElementModel.ProductPage()
                {
                    BuyNowButton= tbBuyNowButton_product.Text,
                    ProductVariationContainer= tbVariationFlexBox_product.Text,
                    QuantityCheckbox= tbQuantityTextbox_product.Text,
                    CurrentPriceLabel= tbCurrentPriceLabel_product.Text,
                    SaleBanner= tbSaleBanner_product.Text,
                    UnlistedError = tbUnlisted_product.Text
                };
                var cartPage = new ElementModel.CartPage()
                {
                    CheckOutButton= tbCheckoutButton_cart.Text,
                    SelectAllCheckbox= tbSelectAllCheckbox_cart.Text,
                    CartTotalPriceLabel= tbCartTotalPrice.Text,
                    ClaimShopVoucherButton= tbClaimShopVC_cart.Text,
                    CartEmptyLabel= tbCartEmptyLabel_cart.Text,
                    SelectAllLabel = tbSelectAllLabel.Text
                };
                var checkoutPage = new ElementModel.CheckoutPage()
                {
                    PlaceOrderButton= tbPLaceOrderButton_placeOrder.Text,
                    SelectShopeeVoucherButton= tbSelectShopeeVcButton_placeOrder.Text,
                    ShopeeVoucherContainer= tbShopeeVcContainer_placeOrder.Text,
                    ShopeeVoucherOkButton= tbClaimShopeeVcOkButton_placeOrder.Text,
                    RedeemCoinCheckbox= tbRedeemCoinCheckbox_placeOrder.Text,
                    ChangePaymentButton= tbCHangePaymentButton_placeOrder.Text,
                    OrderPrice = tbOrderPrice_placeOrder.Text
                };
                var paymentMethod = new ElementModel.PaymentMethod()
                {
                    ATM_CashDeposit = tbPayment_ATM_CashDeposit.Text,
                    OnlineBanking = tbPayment_OnlineBanking.Text,
                    CashOnDelivery = tbPayment_ATM_CashDeposit.Text,
                    DebitCreditCard = tbPayment_Debit_CreditCard.Text,
                    ConvenienceStores = tbPayment_ConvenienceStore.Text,
                    CreditCardInstallment = tbPayment_CreditCardInstallment.Text,
                    GooglePay = tbPayment_GooglePay.Text
                };
                var storeType = new ElementModel.PaymentConvenienceStoresType()
                {
                    KKMart = tbConvStoreType_KKMart.Text,
                    SevenEleven = tbConvStoreType_SevenEleven.Text
                };
                var paymentErrorMessage = new ElementModel.PaymentErrorMessage()
                {
                    InvalidShopeePayPin = tbErrMess_InvalidShopeePayPin.Text,
                    ActivateShopeePay = tbErrMess_ActivateShopeePay.Text,
                    BankMaintenance = tbErrMess_BankMaintenance.Text,
                    ShopeePayInsufficientFund = tbErrMess_InsuffShopeePay.Text,
                    PayNowMaintenance = tbErrMess_PayNowMaintenance.Text,
                    TransactionExceeded = tbErrMess_TransExceeded.Text,
                    CartItemOutOfStock = tbErrMess_CartOutOfStock.Text,
                    InactiveProducts = tbErrMess_InactiveProduct.Text
                };
                var payment = new ElementModel.Payment()
                {
                    PaymentConvenienceStoresType= storeType,
                    PaymentMethod= paymentMethod,
                    PaymentErrorMessage = paymentErrorMessage
                };
                var rootElement = new ElementModel.Root()
                {
                    ProductPage = productPage,
                    CartPage = cartPage,
                    CheckoutPage = checkoutPage,
                    Payment = payment
                };
                SettingsHelper.Element.SaveElementsToFile(rootElement);
                MessageBox.Show("Elements settings saved.", "Elements saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("An error occured while saving elements.", "Error"); }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateElementValueFromRepository()
        {
            try
            {
                string elementResponse = GetWithResponse($"{Urls.SabSettings.Element}");
                AutoBuyInfo.ConstantElements = JsonConvert.DeserializeObject<ElementModel.Root>(elementResponse); // -> to escape string
                LoadElementsToControls(AutoBuyInfo.ConstantElements);
                var dialog = MessageBox.Show("Elements successfully updated from repository. Save elements settings?", "Save settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;
                SaveElementsSettings();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private string GetWithResponse(string url)
        {
            string html_ = string.Empty;
            HttpWebRequest request_ = (HttpWebRequest)WebRequest.Create(url);
            request_.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response = (HttpWebResponse)request_.GetResponse())
            using (Stream stream_ = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream_))
            {
                html_ = reader.ReadToEnd();
            }
            return html_;
        }

        private void updateElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateElementValueFromRepository();
        }

        private void loadElementsFromLocalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AutoBuyInfo.ConstantElements is null)
            { MessageBox.Show("No elements settings found. Create new settings by saving new one or choose option 'Update element from repository'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
            {
                AutoBuyInfo.ConstantElements = SettingsHelper.Element.LoadElementsFromFile();
                LoadElementsToControls(AutoBuyInfo.ConstantElements);
            }
        }

        private void darkLabel32_Click(object sender, EventArgs e)
        {

        }

        private void darkTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}