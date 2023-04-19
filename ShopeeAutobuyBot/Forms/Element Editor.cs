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

        bool isSaved;
        private bool forceExit;

        public Element_Editor()
        {
            InitializeComponent();
        }

        private void Element_Editor_Load(object sender, EventArgs e)
        {
            isSaved = false;

            ElementInfo.Root element = SettingsHelper.Element.ParseElementSettingsFromFile();

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
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveElementChanges();
            //isSaved = true;
            //this.Hide();
            //this.Close();
        }

        private void Element_Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!isSaved && !forceExit)
            //{
            //    var dialog = MessageBox.Show("Save before exit?", "Save changes", MessageBoxButtons.YesNo);
            //    if (dialog == DialogResult.Yes)
            //    {
            //        saveElementChanges();
            //        isSaved = true;
            //        this.Hide();
            //    }
            //    else
            //        forceExit = true;
            //}
            //else if (!isSaved && forceExit || isSaved)
            //    this.Hide();
        }

        private void saveElementChanges()
        {

            var productPage = new ElementInfo.ProductPage()
            {
                BuyNowButton= tbBuyNowButton_product.Text,
                ProductVariationFlexBox= tbVariationFlexBox_product.Text,
                QuantityCheckbox= tbQuantityTextbox_product.Text,
                CurrentPriceLabel= tbCurrentPriceLabel_product.Text,
                SaleBanner= tbSaleBanner_product.Text
            };

            var cartPage = new ElementInfo.CartPage()
            {

                CheckOutButton= tbCheckoutButton_cart.Text,
                SelectAllCheckbox= tbSelectAllCheckbox_cart.Text,
                ProductPriceLabel= tbProductPrice_cart.Text,
                ClaimShopVoucherButton= tbClaimShopVC_cart.Text,
                CartEmptyLabel= tbCartEmptyLabel_cart.Text
            };

            var checkoutPage = new ElementInfo.CheckoutPage()
            {

                PlaceOrderButton= tbPLaceOrderButton_placeOrder.Text,
                SelectShopeeVoucherButton= tbSelectShopeeVcButton_placeOrder.Text,
                ShopeeVoucherContainer= tbShopeeVcContainer_placeOrder.Text,
                ShopeeVoucherOkButton= tbClaimShopeeVcOkButton_placeOrder.Text,
                RedeemCoinCheckbox= tbRedeemCoinCheckbox_placeOrder.Text,
                ChangePaymentButton= tbCHangePaymentButton_placeOrder.Text
            };

            var rootElement = new ElementInfo.Root()
            {
                ProductPage = productPage,
                CartPage = cartPage,
                CheckoutPage = checkoutPage
            };

            string jsonString = JsonConvert.SerializeObject(rootElement, Formatting.Indented);
            var elementPath = DirectoryProvider.ElementSettingsPath;
            var elementExists = File.Exists(elementPath);

            if (!elementExists || (elementExists && File.ReadAllText(elementPath) == ""))
                File.WriteAllText(elementPath, "[\n" + jsonString + "\n]");
            else
            {
                var elements = File.ReadAllText(elementPath);
                File.WriteAllText(elementPath, elements);
            }

            SettingsHelper.Element.Elements = rootElement;
            MessageBox.Show("Elements settings saved", "Elements saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbCartEmptyLabel_cart_TextChanged(object sender, EventArgs e)
        {

        }

        private void darkLabel13_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateElementValue()
        {
            try
            {
                //get delay config

                string elementResponse = GetWithResponse($"{HostProvider.Host}api/element/");
                SettingsHelper.Element.Elements = JsonConvert.DeserializeObject<ElementInfo.Root>(elementResponse); // -> to escape string
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
            UpdateElementValue();
        }

    }
}
