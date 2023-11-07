using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    public partial class ChangelogHistory : Form
    {
        public ChangelogHistory()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //string changlogHistoryUrl = $"{Urls.Host}api/ChangelogHistory";
            //string changelog = GetWithResponse(changlogHistoryUrl).Replace("\n", Environment.NewLine);
            //darkTextBox1.Text = changelog;
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
    }
}