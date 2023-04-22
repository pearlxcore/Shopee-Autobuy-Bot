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
    public partial class Element_Editor : DarkUI.Forms.DarkForm
    {
        private bool isSaved;
        private bool forceExit;

        public Element_Editor()
        {
            InitializeComponent();
        }

        private void Element_Editor_Load(object sender, EventArgs e)
        {
            isSaved = false;
            if (SettingsHelper.Element.ConstantElements is null)
            { MessageBox.Show("No elements settings found. Create new settings by saving new one or choose option 'Update element from repository'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
                LoadElementsToControls(SettingsHelper.Element.ConstantElements);
        }

        private void LoadElementsToControls(ElementModel.Root element)
        {
            tbBuyNowButton_product.Text = element.ProductPage.BuyNowButton;
            tbVariationFlexBox_product.Text = element.ProductPage.ProductVariationFlexBox;
            tbQuantityTextbox_product.Text = element.ProductPage.QuantityCheckbox;
            tbCurrentPriceLabel_product.Text = element.ProductPage.CurrentPriceLabel;
            tbSaleBanner_product.Text = element.ProductPage.SaleBanner;

            tbCheckoutButton_cart.Text = element.CartPage.CheckOutButton;
            tbSelectAllCheckbox_cart.Text = element.CartPage.SelectAllCheckbox;
            tbProductPrice_cart.Text = element.CartPage.ProductPriceLabel;
            tbClaimShopVC_cart.Text = element.CartPage.ClaimShopVoucherButton;
            tbCartEmptyLabel_cart.Text = element.CartPage.CartEmptyLabel;

            tbPLaceOrderButton_placeOrder.Text = element.CheckoutPage.PlaceOrderButton;
            tbSelectShopeeVcButton_placeOrder.Text = element.CheckoutPage.SelectShopeeVoucherButton;
            tbShopeeVcContainer_placeOrder.Text = element.CheckoutPage.ShopeeVoucherContainer;
            tbClaimShopeeVcOkButton_placeOrder.Text = element.CheckoutPage.ShopeeVoucherOkButton;
            tbRedeemCoinCheckbox_placeOrder.Text = element.CheckoutPage.RedeemCoinCheckbox;
            tbCHangePaymentButton_placeOrder.Text = element.CheckoutPage.ChangePaymentButton;
            tbOrderPrice_placeOrder.Text = element.CheckoutPage.OrderPrice;
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
                    ProductVariationFlexBox= tbVariationFlexBox_product.Text,
                    QuantityCheckbox= tbQuantityTextbox_product.Text,
                    CurrentPriceLabel= tbCurrentPriceLabel_product.Text,
                    SaleBanner= tbSaleBanner_product.Text
                };
                var cartPage = new ElementModel.CartPage()
                {
                    CheckOutButton= tbCheckoutButton_cart.Text,
                    SelectAllCheckbox= tbSelectAllCheckbox_cart.Text,
                    ProductPriceLabel= tbProductPrice_cart.Text,
                    ClaimShopVoucherButton= tbClaimShopVC_cart.Text,
                    CartEmptyLabel= tbCartEmptyLabel_cart.Text
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
                var rootElement = new ElementModel.Root()
                {
                    ProductPage = productPage,
                    CartPage = cartPage,
                    CheckoutPage = checkoutPage
                };
                SettingsHelper.Element.SaveElementsToFile(rootElement);
                MessageBox.Show("Elements settings saved", "Elements saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("An error occured while saving elements", "Error"); }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateElementValueFromRepository()
        {
            try
            {
                //get delay config
                string elementResponse = GetWithResponse($"{ServerInfos.Host}api/element/");
                SettingsHelper.Element.ConstantElements = JsonConvert.DeserializeObject<ElementModel.Root>(elementResponse); // -> to escape string
                LoadElementsToControls(SettingsHelper.Element.ConstantElements);
                var dialog = MessageBox.Show("Save elements settings?", "Save settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;
                SaveElementsSettings();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            MessageBox.Show("Element updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (SettingsHelper.Element.ConstantElements is null)
            { MessageBox.Show("No elements settings found. Create new settings by saving new one or choose option 'Update element from repository'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            else
            {
                SettingsHelper.Element.ConstantElements = SettingsHelper.Element.LoadElementsFromFile();
                LoadElementsToControls(SettingsHelper.Element.ConstantElements);
            }
        }
    }
}