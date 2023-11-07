using Newtonsoft.Json.Linq;
using Shopee_Autobuy_Bot.Extensions;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Utililties.Helper;

namespace Shopee_Autobuy_Bot
{
    public partial class Scan_payday_sale : Form
    {
        private ChromeDriverHelper _chromeDriverHelper;
        private string cookiePaths = "";
        private IContainer components_ = (IContainer)null;
        private JObject jAllSession;
        private string SPC_EC = "";
        private bool stopScan;

        public Scan_payday_sale(ChromeDriverHelper ChromeDriverHelper)
        {
            InitializeComponent();
            _chromeDriverHelper = ChromeDriverHelper;
        }

        private void Logger(
            RichTextBox richTextBox,
      string text,
      Color? color = null,
      bool NewLine = true,
      bool Production = true,
      bool WithDateTime = true)
        {
            if (tbLog.InvokeRequired)
            {
                Invoke((Delegate)new SetTextCallbackl(Logger), richTextBox, text, color, NewLine, Production, WithDateTime);
            }
            else
            {
                if (WithDateTime)
                    tbLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] ", Color.LightBlue, false);
                tbLog.AppendText(text, color ?? Color.White, NewLine);
            }
        }

        private void Scan_payday_sale_Load(object sender, EventArgs e)
        {
            var allcookies = _chromeDriverHelper.driver.Manage().Cookies.AllCookies;
            foreach (var cookie in allcookies)
            {
                if (cookie.Name == "SPC_EC")
                {
                    SPC_EC = "SPC_EC=" + cookie.Value;
                    break;
                }
            }
        }

        private string postJsonToApi(string json, string url)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.Cookie, SPC_EC);
            string response = client.UploadString(url, json);
            return response;
        }

        private string GetJson(string url)
        {
            var client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers.Add(HttpRequestHeader.Cookie, SPC_EC);
            string response = client.DownloadString(url);
            return response;
        }

        private void darkButtonScan_Click(object sender, EventArgs e)
        {
            //darkDataGridView1.DoubleBuffered(true);
            darkButtonScan.Enabled = false;
            var bw = new BackgroundWorker();
            bw.DoWork += delegate
            {
                try
                {
                    stopScan = false;
                    int next_offset;
                    int total_count;

                    string collectionId = tbCollectionId.Text;
                    string url = String.Format("https://shopee.com.my/api/v4/collection/get_items?collection_id={0}&limit=150&show_collection_info=true&source=1", collectionId);
                    JObject collectionInfo = JObject.Parse(GetJson(url));
                    JToken errorMsg = collectionInfo["error_msg"];
                    if (errorMsg.ToString() != string.Empty)
                    {
                        MessageBox.Show(errorMsg.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        darkButtonScan.Enabled = true;

                        return;
                    }

                    darkDataGridView1.DataSource = null;

                    next_offset = Convert.ToInt32(collectionInfo["data"]["next_offset"].ToString());
                    total_count = Convert.ToInt32(collectionInfo["data"]["total_count"].ToString());

                    //MessageBox.Show("next_offset: " + collectionInfo["data"]["next_offset"].ToString() + "\ntotal_count: " + collectionInfo["data"]["total_count"].ToString(), "next_offset, total_count");
                    darkLabelCollectionName.Text = collectionInfo["data"]["collection"]["name"].ToString().Replace("&", "&&");

                    List<string> listItemId = new List<string>();
                    List<string> listShopId = new List<string>();
                    int i;

                    DataTable dt = new DataTable();
                    //dt.Columns.Add("itemId");
                    //dt.Columns.Add("shopId");
                    dt.Columns.Add("Product name");
                    dt.Columns.Add("Product link");
                    dt.Columns.Add("Price min - max (RM)");
                    dt.Columns.Add("Promotion price (RM)", typeof(double)); // untuk sorting column by price value
                    //dt.Columns.Add("Price difference (RM)");
                    dt.Columns.Add("Start sale");
                    dt.Columns.Add("End sale");

                    darkLabelStatus.Text = "Gathering product info (" + total_count + " entry)..";

                    for (i = 150; i <= total_count; i = i + 150)
                    {
                        string url_ = "https://shopee.com.my/api/v4/collection/get_items?collection_id=" + collectionId + "&limit=150&show_collection_info=true&source=1&next_offset=" + i.ToString();
                        JObject collectionInfo_ = JObject.Parse(GetJson(url_));
                        JToken errorMsg_ = collectionInfo_["error_msg"];
                        if (errorMsg.ToString() != string.Empty)
                        {
                            MessageBox.Show(errorMsg_.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            darkButtonScan.Enabled = true;

                            return;
                        }
                        //Logger("url_: " + url_, new Color?(Color.Blue), true, true, true);

                        //Logger("current offset: " + i.ToString(), new Color?(Color.Blue), true, true, true);

                        JToken items = collectionInfo_["data"]["items"];
                        //Logger("items count: " + items.Count().ToString(), new Color?(Color.Blue), true, true, true);

                        if (items.Count() == 0)
                        {
                            darkButtonScan.Enabled = true;
                            break;
                        }
                        //retrieve each item info
                        foreach (var item in items)
                        {
                            listItemId.Add(item["item_card_full"]["itemid"].ToString());
                            listShopId.Add(item["item_card_full"]["shopid"].ToString());
                        }

                        if (stopScan)
                        {
                            darkLabelStatus.Text = "Process aborted";
                            darkButtonScan.Enabled = true;
                            break;
                        }

                        //Thread.Sleep(2000);
                        //Logger("", new Color?(Color.Blue), true, true, false);
                    }

                    darkLabelStatus.Text = "Listing product (" + total_count + " entry)..";

                    var numbersAndWords = listItemId.Zip(listShopId, (n, w) => new { itemid = n, shopid = w });
                    foreach (var nw in numbersAndWords)
                    {
                        string itemId = "";
                        string shopId = "";
                        string url__ = "";

                        Console.WriteLine(nw.itemid + nw.shopid);
                        itemId = nw.itemid;
                        shopId = nw.shopid;

                        string productLinkJson = string.Format("https://shopee.com.my/api/v4/item/get?itemid={0}&shopid={1}", itemId, shopId);
                        url__ = string.Format("https://shopee.com.my/product/{0}/{1}", shopId, itemId);
                        JObject itemInfo = JObject.Parse(GetJson(productLinkJson));
                        JToken errorMsg__ = itemInfo["Error"];
                        if (errorMsg.ToString() != string.Empty)
                        {
                            MessageBox.Show(errorMsg__.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            darkButtonScan.Enabled = true;

                            return;
                        }

                        string name = "";
                        string price_min = "";
                        string price_max = "";
                        string startTime = "";
                        string endTime = "";
                        string promotionPrice = "";
                        string priceFinal_min = "";
                        string priceFinal_max = "";
                        string priceStr = "";
                        string promotionId = "";

                        name = itemInfo["data"]["name"].ToString();
                        price_min = itemInfo["data"]["price_min"].ToString();
                        price_max = itemInfo["data"]["price_max"].ToString();
                        price_min = price_min.Substring(0, price_min.Length - 3);
                        price_max = price_max.Substring(0, price_max.Length - 3);
                        priceFinal_min = string.Format("{0:#.00}", Convert.ToDecimal(price_min) / 100);
                        priceFinal_max = string.Format("{0:#.00}", Convert.ToDecimal(price_max) / 100);
                        priceStr = (priceFinal_min == priceFinal_max) ? priceFinal_min : priceFinal_min + " - " + priceFinal_max;

                        var deepDiscountEl = itemInfo["data"]["deep_discount"];
                        if (deepDiscountEl.Count() != 0)
                        {
                            promotionId = deepDiscountEl["promotion"]["promotion_id"].ToString();
                            startTime = deepDiscountEl["promotion"]["start_time"].ToString();
                            endTime = deepDiscountEl["promotion"]["end_time"].ToString();
                            promotionPrice = deepDiscountEl["promotion"]["promotion_price"].ToString();

                            if (promotionPrice == String.Empty)
                            {
                                promotionPrice = deepDiscountEl["skin"]["pc"]["pre_hype_text"].ToString();
                                if (promotionPrice != String.Empty)
                                    promotionPrice = Between(promotionPrice, "<strong>", "</strong>");
                            }

                            var startDateTime = UnixTimeStampToDateTime(Double.Parse(startTime));
                            var endDateTime = UnixTimeStampToDateTime(Double.Parse(endTime));

                            //Logger("promotionId: " + promotionId, new Color?(Color.Blue), true, true, true);
                            //Logger("startTime: " + startDateTime, new Color?(Color.Blue), true, true, true);
                            //Logger("endTime: " + endDateTime, new Color?(Color.Blue), true, true, true);
                            //Logger("promotionPrice: " + promotionPrice, new Color?(Color.Blue), true, true, true);

                            promotionPrice = promotionPrice.Replace("RM", "").Replace(".", "") + "000";
                            promotionPrice = promotionPrice.Replace(" ", "");
                            promotionPrice = promotionPrice.Substring(0, promotionPrice.Length - 3);
                            var promotionPriceFinal = string.Format("{0:#.00}", Convert.ToDecimal(promotionPrice) / 100);

                            dt.Rows.Add(name, url__, priceStr, promotionPriceFinal, startDateTime, endDateTime);
                        }
                        else
                        {
                            //Logger("deepDiscount element empty", new Color?(Color.IndianRed), true, true, true);
                            dt.Rows.Add(name, url__, priceStr, "0", "", "");
                        }

                        try
                        {
                            this.Invoke((Action)(() =>
                            {
                                darkDataGridView1.DataSource = dt;
                                darkDataGridView1.FirstDisplayedScrollingRowIndex = darkDataGridView1.RowCount - 1;
                            }));
                        }
                        catch
                        {
                        }

                        if (stopScan)
                        {
                            darkLabelStatus.Text = "Process aborted";

                            darkButtonScan.Enabled = true;
                            break;
                        }
                    }
                    darkButtonScan.Enabled = true;
                    darkLabelStatus.Text = "Listing done";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    darkButtonScan.Enabled = true;
                }
            };
            bw.RunWorkerCompleted += delegate
            {
                darkButtonScan.Enabled = true;
            };
            bw.RunWorkerAsync();
        }

        private double convertStringtoReadablePrice(string str)
        {
            if (str == "0")
                return 0;
            str = str.Substring(0, str.Length - 3);

            //str = string.Format("{0:c}", str);
            var priceInDouble = double.Parse(str);
            return priceInDouble;
        }

        public string Between(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        private void tbLog_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            tbLog.SelectionStart = tbLog.Text.Length;
            // scroll it automatically
            tbLog.ScrollToCaret();
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            stopScan = true;
        }

        private void darkDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (darkDataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0)
            //{
            //    try
            //    {
            //        foreach (DataGridViewCell cell in darkDataGridView1.SelectedCells)
            //        {
            //            int selectedrowindex = cell.RowIndex;
            //            DataGridViewRow selectedRow = darkDataGridView1.Rows[selectedrowindex];
            //            Clipboard.SetText(Convert.ToString(selectedRow.Cells[1].Value));

            //        }

            //    }
            //    catch (System.Runtime.InteropServices.ExternalException)
            //    {
            //        MessageBox.Show("The Clipboard could not be accessed.", "Error");
            //    }
            //}
        }

        private void darkDataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int column = e.ColumnIndex;

                if (column == 3)
                {
                    //if (darkDataGridView1.SortOrder.Equals(SortOrder.Ascending))
                    //{
                    //    darkDataGridView1.Sort(darkDataGridView1.Columns[13], ListSortDirection.Descending);
                    //}else if (darkDataGridView1.SortOrder.Equals(SortOrder.Descending))
                    //{
                    //    darkDataGridView1.Sort(darkDataGridView1.Columns[13], ListSortDirection.Ascending);
                    //}
                    //else if(darkDataGridView1.SortOrder.Equals(SortOrder.None))
                    //{
                    //    darkDataGridView1.Sort(darkDataGridView1.Columns[13], ListSortDirection.Ascending);
                    //}

                    darkDataGridView1.Columns[3].SortMode =
    DataGridViewColumnSortMode.Automatic;
                }
            }
            catch (Exception ex) { }
        }

        private void copyProductLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (darkDataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    foreach (DataGridViewCell cell in darkDataGridView1.SelectedCells)
                    {
                        int selectedrowindex = cell.RowIndex;
                        DataGridViewRow selectedRow = darkDataGridView1.Rows[selectedrowindex];
                        Clipboard.SetText(Convert.ToString(selectedRow.Cells[1].Value));
                        break;
                    }
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("The Clipboard could not be accessed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openProductLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (darkDataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    foreach (DataGridViewCell cell in darkDataGridView1.SelectedCells)
                    {
                        int selectedrowindex = cell.RowIndex;
                        DataGridViewRow selectedRow = darkDataGridView1.Rows[selectedrowindex];
                        Process.Start(Convert.ToString(selectedRow.Cells[1].Value));
                        break;
                    }
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("The Clipboard could not be accessed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}