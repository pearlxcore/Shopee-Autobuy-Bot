using Shopee_Autobuy_Bot.Constants;
using Shopee_Autobuy_Bot.Services;
using Shopee_Autobuy_Bot.Services.Logger;
using Shopee_Autobuy_Bot.Services.Profile;
using Shopee_Autobuy_Bot.Utililties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using static Shopee_Autobuy_Bot.Constants.AutoBuyInfo;
using static Shopee_Autobuy_Bot.Utililties.Helper;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Shopee_Autobuy_Bot
{
    public partial class Login : Form
    {
        private List<ISeleniumService> seleniumServiceList = new List<ISeleniumService>();

        public Login(ISeleniumService seleniumService, IAutoBuyLoggerService autoBuyLoggerService, IAutoBuyService autoBuyService, IProfileService profileService)
        {
            InitializeComponent();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CheckForIllegalCrossThreadCalls = false;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            _seleniumService=seleniumService;
            _autoBuyLoggerService=autoBuyLoggerService;
            _autoBuyService=autoBuyService;
            _profileService=profileService;
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
        private readonly ISeleniumService _seleniumService;
        private readonly IAutoBuyLoggerService _autoBuyLoggerService;
        private readonly IAutoBuyService _autoBuyService;
        private readonly IProfileService _profileService;

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
            //try
            //{
            //    try
            //    {
            //        bool isExecuterExists = File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe");
            //        if (isExecuterExists)
            //            File.Delete(DirectoryPaths.SabTempDirectory + "Executer.exe");
            //    }
            //    catch { }

            //    string currentProgram = System.AppDomain.CurrentDomain.FriendlyName;

            //    byte[] buffer;

            //    // get serial number
            //    ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            //    foreach (ManagementObject wmi_HD in searcher.Get())
            //        serial_number = wmi_HD["SerialNumber"].ToString();

            //    if (serial_number.Length == 0 || serial_number == string.Empty)
            //    {
            //        Console.WriteLine("no serial number!");
            //        return;
            //    }

            //    string SerialNumberMagicByte = ComputeSha256Hash(serial_number).ToUpper();

            //    //Console.WriteLine("HDD serial number SHA1 : " + SerialNumberMagicByte);
            //    buffer = new byte[20];

            //    var ProgramMagicByte_ = ReadMagicByte(currentProgram, buffer);

            //    // Read all byte of current program

            //    var ProgramMagicByte = GetHexStringFrom(ProgramMagicByte_).Replace("-", "");
            //    //Console.WriteLine("Magic byte             : " + ProgramMagicByte);

            //    bool isAllZero = ProgramMagicByte.All(c => c == '0');

            //    if (!isAllZero == true && !lifetime == false)
            //    {
            //        //MessageBox.Show("First time. Need patch.");
            //        //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte
            //        //            + "\nSerialNumberMagicByte : " + SerialNumberMagicByte);

            //        //Console.WriteLine("First time. Need patch.");
            //        WriteSerial(currentProgram, SerialNumberMagicByte, true);
            //        if (firstTime == true)
            //        {
            //            Application.Exit();
            //        }
            //    }
            //    else if (isAllZero == true && lifetime == false)
            //    {
            //        //MessageBox.Show("First time. Need patch.");
            //        //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte
            //        //            + "\nSerialNumberMagicByte : " + SerialNumberMagicByte);

            //        //Console.WriteLine("First time. Need patch.");
            //        WriteSerial(currentProgram, SerialNumberMagicByte, false);
            //        if (firstTime == true)
            //        {
            //            Application.Exit();
            //        }
            //    }
            //    else if (isAllZero == false && !ProgramMagicByte.ToUpper().Contains(SerialNumberMagicByte.ToUpper()))
            //    {
            //        //Console.WriteLine(ProgramMagicByte.ToUpper());

            //        //Console.WriteLine("You are not authorized to use this program!");
            //        DialogResult dialog = MessageBox.Show("You are not authorized to use this program. Visit our facebook page?.", "Unauthorized access detected.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //        if (dialog == DialogResult.OK)
            //        {
            //            Process.Start("https://facebook.com/ShopeeAutobuyBot");
            //        }
            //        Environment.Exit(0);
            //        return;
            //        //Form2 form = new Form2();
            //        //form.ShowDialog();
            //        //MessageBox.Show("You are not authorized to use this program. visit facebook.com/ShopeeLazadaAutobuyBot to purchase.");
            //        //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte.ToUpper()
            //        //           + "\nSerialNumberMagicByte : " + SerialNumberMagicByte.ToUpper());
            //    }
            //    else if (isAllZero == false && ProgramMagicByte.ToUpper().Contains(SerialNumberMagicByte.ToUpper()))
            //    {
            //        //if (File.Exists(Environment.CurrentDirectory + @"\Shopee Autobuy Bot patched.exe"))
            //        //    File.Move(Environment.CurrentDirectory + @"\Shopee Autobuy Bot patched.exe", Environment.CurrentDirectory + @"\Shopee Autobuy Bot.exe");
            //        //Console.WriteLine("Good to go.");
            //        //MessageBox.Show("Good to go.");
            //        //MessageBox.Show("ProgramMagicByte        : " + ProgramMagicByte.ToUpper()
            //        //           + "\nSerialNumberMagicByte : " + SerialNumberMagicByte.ToUpper());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Get stack trace for the exception with source file information
            //    var st = new StackTrace(ex, true);
            //    // Get the top stack frame
            //    var frame = st.GetFrame(0);
            //    // Get the line number from the stack frame
            //    var line = frame.GetFileLineNumber();
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //    MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private bool IsConnectionOk()
        {
            return Helper.Utilities.CheckConnection() ? true : false;
        }

        private bool IsServerOk()
        {
            return Helper.Utilities.PingServer() ? true : false;
        }

        public static string GetApplicationVersion()
        {
            // Get the entry assembly (usually represents the current application)
            Assembly entryAssembly = Assembly.GetEntryAssembly();

            // Get the custom attribute for the AssemblyInformationalVersionAttribute
            // This attribute should be set in the project's Properties/AssemblyInfo.cs file
            AssemblyInformationalVersionAttribute versionAttribute =
                entryAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            // Retrieve and return the version string
            return versionAttribute?.InformationalVersion ?? "Version information not available";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetEntryAssembly().GetName().Version.ToString();
            this.Text += $" {assembly}";
            try
            {
                if (!File.Exists(DirectoryPaths.ChromedriverPath))
                {
                    DialogResult dialog = System.Windows.Forms.MessageBox.Show("chromedriver.exe not found. Download ChromeDriver from download page. Choose version that compatible with Chrome browser version. Make sure to download the correct filename (chromedriver_win32.zip). Place chromedriver.exe into application folder then restart this program. Open ChromeDriver download page?", "ChromDriver not found", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        Process.Start("https://chromedriver.chromium.org/downloads");
                    }
                    else
                    {
                        System.Windows.Forms.Application.Exit();
                        return;
                    }
                }

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
                if (!Directory.Exists(DirectoryPaths.SabProfileDirectory))
                    Directory.CreateDirectory(DirectoryPaths.SabProfileDirectory);

                // configure sab temp directory and magic tool executer.exe
                try
                {
                    //if (!Directory.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                    //    Directory.CreateDirectory(DirectoryPaths.SabTempDirectory + "Executer.exe");

                    //if (File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                    //    File.Delete(DirectoryPaths.SabTempDirectory + "Executer.exe");

                    if (!File.Exists(DirectoryPaths.SabTempDirectory + "cashing.mp3"))
                        File.WriteAllBytes(DirectoryPaths.SabTempDirectory + "cashing.mp3", Properties.Resources.cashing);
                }
                catch { }

            }
            catch { }

            try
            {
                var directories = Directory.GetDirectories(DirectoryPaths.SabProfileDirectory);
                if (directories.Count() > 0)
                {
                    foreach (var profile in directories)
                    {
                        listBoxChromeProfile.Items.Add(Path.GetFileName(profile));
                    }
                }
            }
            catch { }

            try
            {
                if (!IsConnectionOk())
                {
                    MessageBox.Show("Connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                if (!IsServerOk())
                {
                    MessageBox.Show("Server error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                //MaintenanceCheck();
                //ChromedriverUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error LoginUser");
            }
        }

        public void ChromedriverDownload(string chromeVersion)
        {
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
            Utilities.KillChromedriver();
            Utilities.DownloadChromedriver(chromeVersion, DirectoryPaths.ChromedriverZipPath);
            // extract
            if (File.Exists(DirectoryPaths.CurrentDirectory + @"\LICENSE.chromedriver"))
                File.Delete(DirectoryPaths.CurrentDirectory + @"\LICENSE.chromedriver");
            Utilities.ExtractChromedriver(DirectoryPaths.ChromedriverZipPath, DirectoryPaths.CurrentDirectory);
        }

        public void ChromedriverUpdate()
        {
            // get current chrome version
            string chromeVersion = Utilities.GetChromeVersion();

            if (!File.Exists(DirectoryPaths.ChromedriverPath))
            {
                ////ChromedriverDownload(chromeVersion);
            }
            else
            {
                // get chromedriver version
                string currentChromeDriverVersion = Utilities.GetChromeDriverVersion();
                var chromeVersion_ = new Version(chromeVersion);
                var currentChromeDriverVersion_ = new Version(currentChromeDriverVersion);

                // compare version
                var result = chromeVersion_.CompareTo(currentChromeDriverVersion_);
                if (result > 0)
                {
                    ChromedriverDownload(chromeVersion);
                }
            }
        }

        //private void MaintenanceCheck()
        //{
        //    //try
        //    //{
        //    string maintenanceResponse = GetWithResponse($"{Urls.Host}api/maintenance/");
        //    var maintenanceInfo = JsonConvert.DeserializeObject<MaintenanceModel>(maintenanceResponse); // -> to escape string
        //    int maintenanceStatus = maintenanceInfo.status;
        //    if (maintenanceStatus == 1)
        //    {
        //        var excludedDeviceList = new List<string>();
        //        foreach (var device in maintenanceInfo.exclude)
        //        {
        //            excludedDeviceList.Add(device.ToString());
        //        }

        //        var isExcluded = excludedDeviceList.FirstOrDefault(stringToCheck => stringToCheck.Contains(System.Environment.MachineName.ToString()));
        //        if (isExcluded == null)
        //        {
        //            MessageBox.Show("Currently under maintenance. Program will exit.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            this.Close();
        //            return;
        //        }
        //    }
        //    //}
        //    //catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        //}

        //private void CheckNewVersion()
        //{
        //    //try
        //    //{
        //    string changeLogResponse = GetWithResponse($"{Urls.Host}api/Changelog");
        //    string updateResponse = GetWithResponse($"{Urls.Host}api/update/");
        //    var updateInfo = JsonConvert.DeserializeObject<ProgramInfoModel>(updateResponse); // -> to escape string

        //    var releaseDate = updateInfo.date;
        //    var programVersion = updateInfo.version;
        //    var updateUrl = updateInfo.url;

        //    var currentVersion = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
        //    var latestVersion = new Version(programVersion);

        //    if (latestVersion > currentVersion)
        //    {
        //        this.Enabled = false;
        //        MessageBox.Show("New version " + latestVersion + " (" + releaseDate + ") available to download. The file will be downloaded and launched automatically. Please wait a few seconds while the program is downloading.\n\nChangelog :\n\n" + changeLogResponse.Replace("\n", Environment.NewLine), "New version available", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        CreateSabTempDirectory();

        //        //if (!File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
        //        //    File.WriteAllBytes(DirectoryPaths.SabTempDirectory + "Executer.exe", Properties.Resources.Executer);

        //        //if (File.Exists(DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe"))
        //        //    File.Delete(DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe");

        //        try
        //        {
        //            Icon appIcon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);

        //            notifyIcon1.Icon = appIcon;
        //            notifyIcon1.Visible = true;
        //            notifyIcon1.BalloonTipTitle = "Shopee Autobuy Bot";
        //            notifyIcon1.BalloonTipText = "Downloading latest version.. Please wait.";
        //            notifyIcon1.ShowBalloonTip(10000000);
        //        }
        //        catch (Exception ex)
        //        {
        //            // don't care
        //        }

        //        WebClient client = new WebClient();
        //        client.Proxy = WebRequest.DefaultWebProxy;
        //        client.DownloadFile(updateUrl, DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe");
        //        Helper.ProgramRegistration.updating = true;
        //        notifyIcon1.Dispose();
        //        Application.Exit();
        //    }
        //    this.Text += " " + currentVersion.ToString() + " | Main";
        //    tbId.Text = Properties.Settings.Default.ID;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message, "Check Version Error : ChromeDriver");
        //    //    return;
        //    //}
        //}

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
            if (listBoxChromeProfile.Items.Count == 0)
            {
                MessageBox.Show("SAB profile is empty. Create and select SAB profile to login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBoxChromeProfile.SelectedItem != null)
                SAB_Account = listBoxChromeProfile.SelectedItem.ToString();
            else
            {
                MessageBox.Show("Select SAB profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

                _seleniumService.Initialize(darkCheckBoxDisableImageExtension.Checked, darkCheckBoxHeadless.Checked, listBoxChromeProfile.Text);

                //ChromeDriverHelper chromeDriverHelper = new ChromeDriverHelper();
                //var chromeDriverHelper_ = firstStart(chromeDriverHelper);
                // open main form
                //tbId.Enabled = true;
                seleniumServiceList.Add(_seleniumService);
                Main form = new Main(_seleniumService, _profileService);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbId.Enabled = true;
                return;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var isRunning = seleniumServiceList.Any(x => x._driver != null);
            if (isRunning)
            {
                var dialog = MessageBox.Show("Close all running bot?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.Cancel)
                    return;

                try
                {
                    foreach (var service in seleniumServiceList)
                    {
                        if (service != null)
                        {
                            try
                            {
                                service.QuitDriver();
                            }
                            catch { }
                        }
                    }
                }
                catch { }
            }

            Properties.Settings.Default.ID = tbId.Text;
            Properties.Settings.Default.Save();
            if (Helper.ProgramRegistration.MultipleInstances != true)
            {
                if (Helper.ProgramRegistration.updating == true)
                {
                    //tempFile = DirectoryPaths.SabTempDirectory + "Shopee Autobuy Bot.exe";
                    //currentFile = DirectoryPaths.CurrentDirectory + "Shopee Autobuy Bot.exe";

                    //if (File.Exists(DirectoryPaths.SabTempDirectory + "Executer.exe"))
                    //    File.Delete(DirectoryPaths.SabTempDirectory + "Executer.exe");
                    //File.WriteAllBytes(DirectoryPaths.SabTempDirectory + "Executer.exe", Properties.Resources.Executer);

                    //ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = DirectoryPaths.SabTempDirectory + "Executer.exe";
                    //startInfo.CreateNoWindow = true;
                    //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //startInfo.Arguments = "\"" + currentFile + "\" \"" + tempFile + "\"";
                    //Process.Start(startInfo);
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

        private string getFingerPrint()
        {
            string fingerPrint = "";
            // get serial number
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
                Helper.ProgramRegistration.serial_number = wmi_HD["SerialNumber"].ToString();

            //if (serial_number.Length == 0 || serial_number == string.Empty)
            //    return;

            string SerialNumberMagicByte = Helper.ProgramRegistration.ComputeSha256Hash(Helper.ProgramRegistration.serial_number).ToUpper();
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
                MessageBox.Show("Specify SAB profile name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listBoxChromeProfile.Items.Add(tbNewChromeProfile.Text);
            if (!Directory.Exists(DirectoryPaths.SabProfileDirectory + tbNewChromeProfile.Text))
                Directory.CreateDirectory(DirectoryPaths.SabProfileDirectory + tbNewChromeProfile.Text);
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            if (listBoxChromeProfile.SelectedItem == null)
            {
                MessageBox.Show("Select SAB profile to be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dialog = MessageBox.Show($"This will delete all user data for {listBoxChromeProfile.SelectedItem}. Are you sure?", "Delete profile", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog != DialogResult.OK)
                return;
            try
            {
                Directory.Delete(DirectoryPaths.SabProfileDirectory +listBoxChromeProfile.SelectedItem, true);
            }
            catch { }
            listBoxChromeProfile.Items.Remove(listBoxChromeProfile.SelectedItem);
        }
    }
}