using Newtonsoft.Json;
using Shopee_Autobuy_Bot.Constant;
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

            tbBuyNowButton_product.Text = Properties.Settings.Default.product_strBuyNowButton;
            tbVariationFlexBox_product.Text = Properties.Settings.Default.product_strProductVariationFlexBox;
            tbQuantityTextbox_product.Text = Properties.Settings.Default.product_strQuantityTextBox;
            tbCurrentPriceLabel_product.Text = Properties.Settings.Default.product_strCurrentProductPrice;
            tbSaleBanner_product.Text = Properties.Settings.Default.product_strSaleBanner;

            tbCheckoutButton_cart.Text = Properties.Settings.Default.cart_strCheckOut;
            tbSelectAllCheckbox_cart.Text = Properties.Settings.Default.cart_strSelectAllCheckbox;
            tbProductPrice_cart.Text = Properties.Settings.Default.cart_strProductPriceLabel;
            tbClaimShopVC_cart.Text = Properties.Settings.Default.cart_strClaimShopVC;
            tbCartEmptyLabel_cart.Text = Properties.Settings.Default.cart_strCartEmptyLabel;

            tbPLaceOrderButton_placeOrder.Text = Properties.Settings.Default.checkout_strPlaceOrder;
            tbCSelectShopeeVcButton_placeOrder.Text = Properties.Settings.Default.chekcout_strClaimShopeeVcButton;
            tbShopeeVcContainer_placeOrder.Text = Properties.Settings.Default.checkout_strShopeeVcContainer;
            tbClaimShopeeVcOkButton_placeOrder.Text = Properties.Settings.Default.checkout_strShopeeVcOkButton;
            tbRedeemCoinCheckbox_placeOrder.Text = Properties.Settings.Default.checkout_strRedeemCoinCheckbox;
            tbCHangePaymentButton_placeOrder.Text = Properties.Settings.Default.checkout_strChangePaymentButton;
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
            Properties.Settings.Default.product_strBuyNowButton = tbBuyNowButton_product.Text;
            Properties.Settings.Default.product_strProductVariationFlexBox = tbVariationFlexBox_product.Text;
            Properties.Settings.Default.product_strQuantityTextBox = tbQuantityTextbox_product.Text;
            Properties.Settings.Default.product_strCurrentProductPrice = tbCurrentPriceLabel_product.Text;
            Properties.Settings.Default.product_strSaleBanner = tbSaleBanner_product.Text;

            Properties.Settings.Default.cart_strCheckOut = tbCheckoutButton_cart.Text;
            Properties.Settings.Default.cart_strSelectAllCheckbox = tbSelectAllCheckbox_cart.Text;
            Properties.Settings.Default.cart_strProductPriceLabel = tbProductPrice_cart.Text;
            Properties.Settings.Default.cart_strClaimShopVC = tbClaimShopVC_cart.Text;
            Properties.Settings.Default.cart_strCartEmptyLabel = tbCartEmptyLabel_cart.Text;

            Properties.Settings.Default.checkout_strPlaceOrder = tbPLaceOrderButton_placeOrder.Text;
            Properties.Settings.Default.chekcout_strClaimShopeeVcButton = tbCSelectShopeeVcButton_placeOrder.Text;
            Properties.Settings.Default.checkout_strShopeeVcContainer = tbShopeeVcContainer_placeOrder.Text;
            Properties.Settings.Default.checkout_strShopeeVcOkButton = tbClaimShopeeVcOkButton_placeOrder.Text;
            Properties.Settings.Default.checkout_strRedeemCoinCheckbox = tbRedeemCoinCheckbox_placeOrder.Text;
            Properties.Settings.Default.checkout_strChangePaymentButton = tbCHangePaymentButton_placeOrder.Text;
            Properties.Settings.Default.Save();
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
                var elementinfo = JsonConvert.DeserializeObject<ElementInfo.Root>(elementResponse); // -> to escape string

                Properties.Settings.Default.product_strBuyNowButton = tbBuyNowButton_product.Text = elementinfo.ProductPage.BuyNowButton.ToString();
                Properties.Settings.Default.product_strProductVariationFlexBox = tbVariationFlexBox_product.Text = elementinfo.ProductPage.ProductVariationFlexBox.ToString();
                Properties.Settings.Default.product_strQuantityTextBox = tbQuantityTextbox_product.Text = elementinfo.ProductPage.QuantityCheckbox.ToString();
                Properties.Settings.Default.product_strCurrentProductPrice = tbCurrentPriceLabel_product.Text = elementinfo.ProductPage.CurrentPriceLabel.ToString();
                Properties.Settings.Default.product_strSaleBanner = tbSaleBanner_product.Text = elementinfo.ProductPage.SaleBanner.ToString();

                Properties.Settings.Default.cart_strCheckOut = tbCheckoutButton_cart.Text = elementinfo.CartPage.CheckOutButton.ToString();
                Properties.Settings.Default.cart_strSelectAllCheckbox = tbSelectAllCheckbox_cart.Text = elementinfo.CartPage.SelectAllCheckbox.ToString();
                Properties.Settings.Default.cart_strProductPriceLabel = tbProductPrice_cart.Text = elementinfo.CartPage.ProductPriceLabel.ToString();
                Properties.Settings.Default.cart_strClaimShopVC = tbClaimShopVC_cart.Text = elementinfo.CartPage.ClaimShopVoucherButton.ToString();
                Properties.Settings.Default.cart_strCartEmptyLabel = tbCartEmptyLabel_cart.Text = elementinfo.CartPage.CartEmptyLabel.ToString();

                Properties.Settings.Default.checkout_strPlaceOrder = tbPLaceOrderButton_placeOrder.Text = elementinfo.CheckoutPage.PlaceOrderButton.ToString();
                Properties.Settings.Default.chekcout_strClaimShopeeVcButton = tbCSelectShopeeVcButton_placeOrder.Text = elementinfo.CheckoutPage.SelectShopeeVoucherButton.ToString();
                Properties.Settings.Default.checkout_strShopeeVcContainer = tbShopeeVcContainer_placeOrder.Text = elementinfo.CheckoutPage.ShopeeVoucherContainer.ToString();
                Properties.Settings.Default.checkout_strShopeeVcOkButton = tbClaimShopeeVcOkButton_placeOrder.Text = elementinfo.CheckoutPage.ShopeeVoucherOkButton.ToString();
                Properties.Settings.Default.checkout_strRedeemCoinCheckbox = tbRedeemCoinCheckbox_placeOrder.Text = elementinfo.CheckoutPage.RedeemCoinCheckbox.ToString();
                Properties.Settings.Default.checkout_strChangePaymentButton = tbCHangePaymentButton_placeOrder.Text = elementinfo.CheckoutPage.ChangePaymentButton.ToString();
                Properties.Settings.Default.Save();

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
