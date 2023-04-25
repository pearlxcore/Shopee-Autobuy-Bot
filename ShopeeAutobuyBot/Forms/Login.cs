using HtmlAgilityPack;
using NAudio.Wave;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Models;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Utililties.Helper;

namespace Shopee_Autobuy_Bot
{
    public partial class Login : DarkUI.Forms.DarkForm
    {
        private List<ChromeDriverHelper> chromeDriverHelpersList = new List<ChromeDriverHelper>();

        public Login()
        {
            InitializeComponent();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CheckForIllegalCrossThreadCalls = false;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
        }

        private bool checkDuplicate(int count)
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > count)
                return true;

            if (Process.GetProcessesByName("Shopee Autobuy Bot").Length > count)
                return true;

            //if (Process.GetProcessesByName("Shopee Autobuy Bot Pro").Any())
            //    return true;

            //if (File.Exists(fileMarkerLite))
            //    return true;

            //if (IsAlreadyRunning())
            //    return true;

            //if (File.Exists(fileMarkerPro))
            //    return true;

            return false;
        }

        private static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            Mutex mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }

        private static Mutex mutex = null;

        private bool checkDuplicates()
        {
            const string appName = "myapp";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
                return true;

            return false;
        }

        private void ReadAllByte(bool lifetime)
        {
            try
            {
                try
                {
                    bool isExecuterExists = File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe");
                    if (isExecuterExists)
                        File.Delete(DirectoryPaths.SabTempDirectory + "Executer.exe");
                }
                catch { }

                string currentProgram = System.AppDomain.CurrentDomain.FriendlyName;

                byte[] buffer;

                // get serial number
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject wmi_HD in searcher.Get())
                    serial_number = wmi_HD["SerialNumber"].ToString();

                if (serial_number.Length == 0 || serial_number == string.Empty)
                {
                    Console.WriteLine("no serial number!");
                    return;
                }

                string SerialNumberMagicByte = ComputeSha256Hash(serial_number).ToUpper();

                //Console.WriteLine("HDD serial number SHA1 : " + SerialNumberMagicByte);
                buffer = new byte[20];

                var ProgramMagicByte_ = ReadMagicByte(currentProgram, buffer);

                // Read all byte of current program

                var ProgramMagicByte = GetHexStringFrom(ProgramMagicByte_).Replace("-", "");
                //Console.WriteLine("Magic byte             : " + ProgramMagicByte);

                bool isAllZero = ProgramMagicByte.All(c => c == '0');

                if (!isAllZero == true && !lifetime == false)
                {
                    //MessageBox.Show("First time. Need patch.");
                    //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte
                    //            + "\nSerialNumberMagicByte : " + SerialNumberMagicByte);

                    //Console.WriteLine("First time. Need patch.");
                    WriteSerial(currentProgram, SerialNumberMagicByte, true);
                    if (firstTime == true)
                    {
                        Application.Exit();
                    }
                }
                else if (isAllZero == true && lifetime == false)
                {
                    //MessageBox.Show("First time. Need patch.");
                    //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte
                    //            + "\nSerialNumberMagicByte : " + SerialNumberMagicByte);

                    //Console.WriteLine("First time. Need patch.");
                    WriteSerial(currentProgram, SerialNumberMagicByte, false);
                    if (firstTime == true)
                    {
                        Application.Exit();
                    }
                }
                else if (isAllZero == false && !ProgramMagicByte.ToUpper().Contains(SerialNumberMagicByte.ToUpper()))
                {
                    //Console.WriteLine(ProgramMagicByte.ToUpper());

                    //Console.WriteLine("You are not authorized to use this program!");
                    DialogResult dialog = MessageBox.Show("You are not authorized to use this program. Visit our facebook page?.", "Unauthorized access detected.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        Process.Start("https://facebook.com/ShopeeAutobuyBot");
                    }
                    Environment.Exit(0);
                    return;
                    //Form2 form = new Form2();
                    //form.ShowDialog();
                    //MessageBox.Show("You are not authorized to use this program. visit facebook.com/ShopeeLazadaAutobuyBot to purchase.");
                    //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte.ToUpper()
                    //           + "\nSerialNumberMagicByte : " + SerialNumberMagicByte.ToUpper());
                }
                else if (isAllZero == false && ProgramMagicByte.ToUpper().Contains(SerialNumberMagicByte.ToUpper()))
                {
                    //if (File.Exists(Environment.CurrentDirectory + @"\Shopee Autobuy Bot patched.exe"))
                    //    File.Move(Environment.CurrentDirectory + @"\Shopee Autobuy Bot patched.exe", Environment.CurrentDirectory + @"\Shopee Autobuy Bot.exe");
                    //Console.WriteLine("Good to go.");
                    //MessageBox.Show("Good to go.");
                    //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte.ToUpper()
                    //           + "\nSerialNumberMagicByte : " + SerialNumberMagicByte.ToUpper());
                }
            }
            catch (Exception ex)
            {
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool IsConnectionOk()
        {
            return CheckConnection() ? true : false;
        }

        private bool IsServerOk()
        {
            return PingServer() ? true : false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                var chromeDriverProcesses = Process.GetProcesses().
Where(pr => pr.ProcessName == "chromedriver"); // without '.exe'

                foreach (var process in chromeDriverProcesses)
                {
                    process.Kill();
                }
                Thread.Sleep(500);
            }
            catch { }

            try
            {
                // verify google chrome installation
                string chromeDir = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).ToString() + @"\Google\Chrome\User Data\");
                if (!Directory.Exists(chromeDir))
                {
                    MessageBox.Show("Google Chrome is not installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                // verify log and shopee acc directory
                if (!Directory.Exists(DirectoryPaths.LogDirectory))
                    Directory.CreateDirectory(DirectoryPaths.LogDirectory);
                if (!Directory.Exists(DirectoryPaths.ShopeeAccountDirectory))
                    Directory.CreateDirectory(DirectoryPaths.ShopeeAccountDirectory);

                // configure sab temp directory and magic tool executer.exe
                try
                {
                    if (!Directory.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                        Directory.CreateDirectory(DirectoryPaths.SabTempDirectory + "Executer.exe");

                    if (File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                        File.Delete(DirectoryPaths.SabTempDirectory + "Executer.exe");

                    if (!File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                        File.WriteAllBytes(DirectoryPaths.SabTempDirectory + "Executer.exe", Properties.Resources.cashing);
                }
                catch { }

                // configure mp3 player
                Mp3Player.Mp3FileReader = new Mp3FileReader(DirectoryPaths.SabTempDirectory + "Cashing.mp3");
                Mp3Player.WaveOut = new WaveOut();
                Mp3Player.WaveOut.Init(Mp3Player.Mp3FileReader);
            }
            catch { }

            try
            {
                var directories = Directory.GetDirectories(DirectoryPaths.ShopeeAccountDirectory);
                if (directories.Count() > 0)
                {
                    foreach (var profile in directories)
                    {
                        darkListBox1.Items.Add(Path.GetFileName(profile));
                    }
                }
            }
            catch { }

            //try
            //{
            if (!IsConnectionOk())
            {
                MessageBox.Show("Internet connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (!IsServerOk())
            {
                MessageBox.Show("Server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            MaintenanceCheck();
            CheckNewVersion();
            CheckChromeDriverUpdate();
            //if (Properties.Settings.Default.ShopeeRegion == "Malaysia")
            //    darkComboBox1.Text = "Malaysia";
            //if (Properties.Settings.Default.ShopeeRegion == "Singapore")
            //    darkComboBox1.Text = "Singapore";
            //if (Properties.Settings.Default.ShopeeRegion == "Thailand")
            //    darkComboBox1.Text = "Thailand";
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error LoginUser");
            //}
        }

        private void CheckChromeDriverUpdate()
        {
            //try
            //{
            //1st check if chromedriver exists

            if (!Directory.Exists(DirectoryPaths.SabTempDirectory))
                Directory.CreateDirectory(DirectoryPaths.SabTempDirectory);

            if (!File.Exists(DirectoryPaths.CurrentDirectory + "chromedriver.exe"))
            {
                MessageBox.Show("ChromeDriver not detected.  Downloading latest version..", "ChromeDriver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Enabled = false;
                string version = "";
                string downloadUrl = "";

                using (WebClient client = new WebClient())
                {
                    string htmlCode = client.DownloadString("https://chromedriver.chromium.org/home");
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlCode);
                    var node = doc.DocumentNode.SelectSingleNode("//*[@id=\"h.e02b498c978340a_27\"]/div/div/ul[1]/li[2]/p/a");
                    downloadUrl =node.Attributes["href"].Value.Replace("index.html?path=", "");
                    int pos = downloadUrl.LastIndexOf("=") + 1;
                    version = downloadUrl.Substring(pos, downloadUrl.Length - pos);
                    version = version.Remove(version.Length - 1);

                    try
                    {
                        Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
                        notifyIcon1.Icon = appIcon;
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = "Shopee Autobuy Bot";
                        notifyIcon1.BalloonTipText = "Downloading latest ChromeDriver.. Please wait.";
                        notifyIcon1.ShowBalloonTip(10000000);
                    }
                    catch (Exception ex)
                    {
                        //don't care
                    }

                    CreateSabTempDirectory();

                    WebClient client_ = new WebClient();
                    client_.Proxy = WebRequest.DefaultWebProxy;
                    downloadUrl = downloadUrl + "chromedriver_win32.zip";
                    string zipPath = DirectoryPaths.SabTempDirectory + "chromedriver_win32.zip";
                    client_.DownloadFile(downloadUrl, zipPath);
                    notifyIcon1.Dispose();
                    string extractPath = DirectoryPaths.CurrentDirectory;

                    try
                    {
                        var chromeDriverProcesses = Process.GetProcesses().
    Where(pr => pr.ProcessName == "chromedriver"); // without '.exe'

                        foreach (var process in chromeDriverProcesses)
                        {
                            process.Kill();
                        }
                        Thread.Sleep(500);
                        if (File.Exists(DirectoryPaths.CurrentDirectory + "chromedriver.exe"))
                            File.Delete(DirectoryPaths.CurrentDirectory + "chromedriver.exe");
                    }
                    catch { }

                    // extract
                    if (File.Exists(extractPath + @"\LICENSE.chromedriver"))
                        File.Delete(extractPath + @"\LICENSE.chromedriver");
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                    this.Enabled = true;
                }
            }
            else
            {
                //check chromeDriver version
                //if driver not available in workdir, download latest
                //if new version of chromedriver available, download the latest one
                string version = "";
                string downloadLink = "";

                //check latest version
                using (WebClient client = new WebClient())
                {
                    string htmlCode = client.DownloadString("https://chromedriver.chromium.org/home");
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(htmlCode);
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//*[@id=\"h.e02b498c978340a_27\"]/div/div/ul[1]/li[2]/p/a"))
                    {
                        downloadLink = link.Attributes["href"].Value;
                        int pos = downloadLink.LastIndexOf("=") + 1;
                        version = downloadLink.Substring(pos, downloadLink.Length - pos);
                        version = version.Remove(version.Length - 1);
                    }
                }

                //check local version
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = DirectoryPaths.CurrentDirectory + "chromedriver.exe";
                startInfo.CreateNoWindow = true;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.Arguments = "--version";
                var cmd = Process.Start(startInfo);
                var output = cmd.StandardOutput.ReadToEnd();

                cmd.WaitForExit();

                int pFrom = output.IndexOf("ChromeDriver ") + "ChromeDriver ".Length;
                int pTo = output.LastIndexOf(" (");
                output = output.Substring(pFrom, pTo - pFrom);

                var latestVersion = new Version(version);
                var localVersion = new Version(output);

                var result = latestVersion.CompareTo(localVersion);
                if (result > 0) // new version available
                {
                    this.Enabled = false;
                    try
                    {
                        Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

                        notifyIcon1.Icon = appIcon;
                        notifyIcon1.Visible = true;
                        notifyIcon1.BalloonTipTitle = "Shopee Autobuy Bot";
                        notifyIcon1.BalloonTipText = "Downloading latest ChromeDriver.. Please wait.";
                        notifyIcon1.ShowBalloonTip(10000000);
                    }
                    catch (Exception ex)
                    {
                        //don't care
                    }

                    MessageBox.Show("New version of ChromeDriver available to download.  Please wait a few seconds while the program is downloading.", "ChromeDriver", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    WebClient client = new WebClient();
                    client.Proxy = WebRequest.DefaultWebProxy;
                    string downloadlinkFull = downloadLink + "chromedriver_win32.zip";
                    client.DownloadFile(downloadlinkFull.Replace("index.html?path=", ""), DirectoryPaths.SabTempDirectory + "chromedriver_win32.zip");
                    notifyIcon1.Dispose();
                    string zipPath = DirectoryPaths.SabTempDirectory + "chromedriver_win32.zip";
                    string extractPath = DirectoryPaths.CurrentDirectory;

                    try
                    {
                        var chromeDriverProcesses = Process.GetProcesses().
    Where(pr => pr.ProcessName == "chromedriver"); // without '.exe'

                        foreach (var process in chromeDriverProcesses)
                        {
                            process.Kill();
                        }
                        //Environment.Exit(0);
                        Thread.Sleep(500);
                        if (File.Exists(DirectoryPaths.CurrentDirectory + "chromedriver.exe"))
                            File.Delete(DirectoryPaths.CurrentDirectory + "chromedriver.exe");
                    }
                    catch { }

                    // needed explicit reference to System.IO.Compression.FileSystem
                    ZipFile.ExtractToDirectory(zipPath, extractPath);
                    this.Enabled = true;
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"Chromedriver download error");
            //    return;
            //}
        }

        private void MaintenanceCheck()
        {
            //try
            //{
            string maintenanceResponse = GetWithResponse($"{ServerInfos.Host}api/maintenance/");
            var maintenanceInfo = JsonConvert.DeserializeObject<MaintenanceModel>(maintenanceResponse); // -> to escape string
            int maintenanceStatus = maintenanceInfo.status;
            if (maintenanceStatus == 1)
            {
                var excludedDeviceList = new List<string>();
                foreach (var device in maintenanceInfo.exclude)
                {
                    excludedDeviceList.Add(device.ToString());
                }

                var isExcluded = excludedDeviceList.FirstOrDefault(stringToCheck => stringToCheck.Contains(System.Environment.MachineName.ToString()));
                if (isExcluded == null)
                {
                    MessageBox.Show("Currently under maintenance. Program will exit.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
            }
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

        private void CheckNewVersion()
        {
            //try
            //{
            string changeLogResponse = GetWithResponse($"{ServerInfos.Host}api/Changelog");
            string updateResponse = GetWithResponse($"{ServerInfos.Host}api/update/");
            var updateInfo = JsonConvert.DeserializeObject<ProgramInfoModel>(updateResponse); // -> to escape string

            var releaseDate = updateInfo.date;
            var programVersion = updateInfo.version;
            var updateUrl = updateInfo.url;

            var currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            var latestVersion = new Version(programVersion);

            if (latestVersion > currentVersion)
            {
                this.Enabled = false;
                MessageBox.Show("New version " + latestVersion + " (" + releaseDate + ") available to download. The file will be downloaded and launched automatically. Please wait a few seconds while the program is downloading.\n\nChangelog :\n\n" + changeLogResponse.Replace("\n", Environment.NewLine), "New version available", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CreateSabTempDirectory();

                if (!File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                    File.WriteAllBytes(DirectoryPaths.SabTempDirectory + "Executer.exe", Properties.Resources.Executer);

                if (File.Exists(DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe"))
                    File.Delete(DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe");

                try
                {
                    Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

                    notifyIcon1.Icon = appIcon;
                    notifyIcon1.Visible = true;
                    notifyIcon1.BalloonTipTitle = "Shopee Autobuy Bot";
                    notifyIcon1.BalloonTipText = "Downloading latest version.. Please wait.";
                    notifyIcon1.ShowBalloonTip(10000000);
                }
                catch (Exception ex)
                {
                    // don't care
                }

                WebClient client = new WebClient();
                client.Proxy = WebRequest.DefaultWebProxy;
                client.DownloadFile(updateUrl, DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe");
                updating = true;
                notifyIcon1.Dispose();
                Application.Exit();
            }
            this.Text += " " + currentVersion.ToString() + " | Main";
            tbId.Text = Properties.Settings.Default.ID;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Check Version Error : ChromeDriver");
            //    return;
            //}
        }

        public static string FormatJson(string json, string indent = "  ")
        {
            var indentation = 0;
            var quoteCount = 0;
            var escapeCount = 0;

            var result =
                from ch in json ?? string.Empty
                let escaped = (ch == '\\' ? escapeCount++ : escapeCount > 0 ? escapeCount-- : escapeCount) > 0
                let quotes = ch == '"' && !escaped ? quoteCount++ : quoteCount
                let unquoted = quotes % 2 == 0
                let colon = ch == ':' && unquoted ? ": " : null
                let nospace = char.IsWhiteSpace(ch) && unquoted ? string.Empty : null
                let lineBreak = ch == ',' && unquoted ? ch + Environment.NewLine + string.Concat(Enumerable.Repeat(indent, indentation)) : null
                let openChar = (ch == '{' || ch == '[') && unquoted ? ch + Environment.NewLine + string.Concat(Enumerable.Repeat(indent, ++indentation)) : ch.ToString()
                let closeChar = (ch == '}' || ch == ']') && unquoted ? Environment.NewLine + string.Concat(Enumerable.Repeat(indent, --indentation)) + ch : ch.ToString()
                select colon ?? nospace ?? lineBreak ?? (
                    openChar.Length > 1 ? openChar : closeChar
                );

            return string.Concat(result);
        }

        private void darkButton1_Click(object sender, EventArgs e)
        {
            if (darkListBox1.Items.Count == 0)
            {
                MessageBox.Show("Shopee account is empty. Create and select Shopee account to login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string chromeProfile = "";
            if (darkListBox1.SelectedItem != null)
                chromeProfile = darkListBox1.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Select Shopee account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (tbId.Text == string.Empty)
            //{
            //    MessageBox.Show("Specify user Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            Helper.chromeProfile = chromeProfile;

            Helper.Id = tbId.Text;
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                //LoginOriginal();
                LoginUser();
            }).Start();
        }

        private void LoginUser()
        {
            string hashedId = EncryptionHelper.Encrypt(tbId.Text.Replace("-", "").Replace(" ", ""));

            try
            {
                //check auth status
                #region checkAuthStatus

                //string userResponse = GetWithResponse($"{ServerInfos.Host}api/user/{tbId.Text}");
                //var userInfo = JsonConvert.DeserializeObject<UserModel>(userResponse);

                //if (userInfo.status == "ok")
                //{
                //    List<string> fingerprintList = new List<string>();
                //    fingerprintList.Add(userInfo.device_fingerprint1);
                //    fingerprintList.Add(userInfo.device_fingerprint2);
                //    fingerprintList.Add(userInfo.device_fingerprint3);

                //    //check if local pc fp is match any 3 fp in server
                //    var registeredFingerprint = fingerprintList.FirstOrDefault(x => x == getFingerPrint());

                //    //if this match "", got empty fp
                //    var emptyFingerprint = fingerprintList.FirstOrDefault(x => x == "");

                //    //not registered && got empty fp slot
                //    if (registeredFingerprint == null && emptyFingerprint != null)
                //    {
                //        //string jsonBody = "{\"id\":\"" + tbId.Text + "\",\"fingerprint\":\"" + getFingerPrint().ToLower() + "\"}";
                //        ////jsonBody = JsonConvert.SerializeObject(jsonBody, Formatting.Indented);

                //        var data = "{ \"id\": \"" + tbId.Text + "\", \"fingerprint\": \"" + getFingerPrint().ToLower() + "\" }";
                //        var setFingerprintResponse = PostWithResponse($"{ServerInfos.Host}api/fingerprint", data);

                //        if (!setFingerprintResponse.Equals("\"ok\""))
                //        {
                //            MessageBox.Show("There was problem registering fingerprint", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            tbId.Enabled = true;
                //            return;
                //        }
                //    }
                //    else if (registeredFingerprint == null && emptyFingerprint == null) //if not registered an fp are full //isEmptyFpdetected == null , means not empty fp, not authorized
                //    {
                //        MessageBox.Show("You are not authorized to use this program. To buy this software, contact @ShopeeAutobuyBot at facebook.", "Unauthorized access", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        tbId.Enabled = true;
                //        return;
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("You are not authorized to use this program. To buy this software, contact @ShopeeAutobuyBot at facebook.", "Unauthorized access", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    tbId.Enabled = true;
                //    return;
                //}

                //if (userInfo.expiry_date != null) // 30/7/2021 1:15:55 AM
                //{
                //    DateTime expiryDate = DateTime.ParseExact(userInfo.expiry_date, "dd/MM/yyyy h:mm tt", System.Globalization.CultureInfo.InvariantCulture);

                //    if (DateTime.Now > expiryDate) // subscription ended
                //    {
                //        MessageBox.Show("Your subscription has ended. Contact admin to renew subscription.", "Subscription ended", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        tbId.Enabled = true;
                //        return;
                //    }
                //}

                #endregion checkAuthStatus

                ChromeDriverHelper chromeDriverHelper = new ChromeDriverHelper();
                var chromeDriverHelper_ = firstStart(chromeDriverHelper);
                // open main form
                //tbId.Enabled = true;
                chromeDriverHelpersList.Add(chromeDriverHelper_);
                Main form = new Main(chromeDriverHelper_);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbId.Enabled = true;
                return;
            }
        }

        private ChromeDriverHelper firstStart(ChromeDriverHelper chromeDriverHelper)
        {
            chromeDriverHelper.driverService.HideCommandPromptWindow = true;
            if (darkCheckBoxDisableImageExtension.Checked == true)
            {
                chromeDriverHelper.options.AddArgument("--disable-extensions");
                chromeDriverHelper.options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
                chromeDriverHelper.options.AddArgument("--blink-settings=imagesEnabled=false");
            }
            else
                chromeDriverHelper.options.AddUserProfilePreference("profile.default_content_setting_values.images", 1);
            if (darkCheckBoxHeadless.Checked == true)
            {
                chromeDriverHelper.options.AddArgument("headless");
            }
            chromeDriverHelper.options.AddArgument("--disable-blink-features=AutomationControlled");
            chromeDriverHelper.options.AddArgument("user-data-dir=" + DirectoryPaths.ShopeeAccountDirectory + $"{chromeProfile}");
            chromeDriverHelper.options.AddArgument($"--profile-directory=Default");
            chromeDriverHelper.options.PageLoadStrategy = PageLoadStrategy.Eager;
            chromeDriverHelper.options.AddExcludedArgument("enable-automation");
            chromeDriverHelper.options.AddArgument("no-sandbox");
            chromeDriverHelper.driverProc = chromeDriverHelper.driverService.ProcessId;
            chromeDriverHelper.driver = (IWebDriver)new ChromeDriver(chromeDriverHelper.driverService, chromeDriverHelper.options, TimeSpan.FromMinutes(3.0));
            chromeDriverHelper.driver.Manage().Window.Maximize();

            return chromeDriverHelper;
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

        private string PostWithResponse(string url, string data)
        {
            string result = "";
            using (var wb = new WebClient())
            {
                wb.Headers.Add("Content-Type", "application/json");
                var response = wb.UploadString(url, "POST", data);
                result = response;
            }

            //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpWebRequest.ContentType = "application/json";
            //httpWebRequest.Method = "POST";

            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = body;

            //    streamWriter.Write(json);
            //}

            //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    result = streamReader.ReadToEnd();
            //}
            return result;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var isRunning = chromeDriverHelpersList.Any(x => x.driver != null);
            if (isRunning)
            {
                var dialog = MessageBox.Show("Close all running bot?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.Cancel)
                    return;

                try
                {
                    foreach (var driverHelper in chromeDriverHelpersList)
                    {
                        if (driverHelper != null)
                        {
                            try
                            {
                                driverHelper.driver.Quit();
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            }

            Properties.Settings.Default.ID = tbId.Text;
            Properties.Settings.Default.Save();
            if (MultipleInstances != true)
            {
                if (updating == true)
                {
                    tempFile = DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe";
                    currentFile = DirectoryPaths.CurrentDirectory + "Shopee Autobuy Bot.exe";

                    if (File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                        File.Delete(DirectoryPaths.SabTempDirectory + "Executer.exe");
                    File.WriteAllBytes(DirectoryPaths.SabTempDirectory + "Executer.exe", Properties.Resources.Executer);

                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = DirectoryPaths.SabTempDirectory + "Executer.exe";
                    startInfo.CreateNoWindow = true;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.Arguments = "\"" + currentFile + "\" \"" + tempFile + "\"";
                    Process.Start(startInfo);
                }
            }

            try
            {
                var chromeDriverProcesses = Process.GetProcesses().
Where(pr => pr.ProcessName == "chromedriver"); // without '.exe'

                foreach (var process in chromeDriverProcesses)
                {
                    process.Kill();
                }
                //Environment.Exit(0);
                Thread.Sleep(500);
            }
            catch { }
        }

        private void tbId_TextChanged(object sender, EventArgs e)
        {
            string id = tbId.Text.Trim().Replace(" ", string.Empty).Replace("-", "").Replace("+", "");
            tbId.Text = id;
        }

        private void darkButton1_Click_1(object sender, EventArgs e)
        {
        }

        private void darkButton2_Click(object sender, EventArgs e)
        {
        }

        private void darkButton3_Click(object sender, EventArgs e)
        {
        }

        private void darkButton4_Click(object sender, EventArgs e)
        {
        }

        private void darkButton5_Click(object sender, EventArgs e)
        {
        }

        private void darkButton6_Click(object sender, EventArgs e)
        {
        }

        private string getFingerPrint()
        {
            string fingerPrint = "";
            // get serial number
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
                serial_number = wmi_HD["SerialNumber"].ToString();

            //if (serial_number.Length == 0 || serial_number == string.Empty)
            //    return;

            string SerialNumberMagicByte = ComputeSha256Hash(serial_number).ToUpper();
            fingerPrint = SerialNumberMagicByte;
            return fingerPrint.ToLower();
        }

        private void CreateSabTempDirectory()
        {
            if (!Directory.Exists(DirectoryPaths.SabTempDirectory))
                Directory.CreateDirectory(DirectoryPaths.SabTempDirectory);
        }

        private void darkButton1_Click_2(object sender, EventArgs e)
        {
            if (tbNewChromeProfile.Text == String.Empty)
            {
                MessageBox.Show("Specify Shopee account name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            darkListBox1.Items.Add(tbNewChromeProfile.Text);
            if (!Directory.Exists(DirectoryPaths.ShopeeAccountDirectory + tbNewChromeProfile.Text))
                Directory.CreateDirectory(DirectoryPaths.ShopeeAccountDirectory + tbNewChromeProfile.Text);
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (darkListBox1.SelectedItem == null)
            {
                MessageBox.Show("Select Shopee account to be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dialog = MessageBox.Show($"This will delete all user data for {darkListBox1.SelectedItem}. Are you sure?", "Delete profile", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog != DialogResult.OK)
                return;
            try
            {
                Directory.Delete(DirectoryPaths.ShopeeAccountDirectory +darkListBox1.SelectedItem, true);
            }
            catch { }
            darkListBox1.Items.Remove(darkListBox1.SelectedItem);
        }
    }

    public class ProgramVersion
    {
        private static int program_version_;

        public static int program_version
        {
            get { return program_version_; }
            set { program_version_ = value; }
        }
    }
}