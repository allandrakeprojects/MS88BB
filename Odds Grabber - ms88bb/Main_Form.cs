using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odds_Grabber___ms88bb
{
    public partial class Main_Form : Form
    {
        private ChromiumWebBrowser chromeBrowser;
        private string __app = "Odds Grabber";
        private string __app_type = "{edit this}";
        private string __brand_code = "{edit this}";
        private string __brand_color = "#B29340";
        private string __url = "www.ms88bb.com";
        private string __website_name = "ms88bb";
        private string __app__website_name = "";
        private string __api_key = "youdieidie";
        private string __running_01 = "ms88bb";
        private string __running_02 = "m";
        private string __running_11 = "MS88BB";
        private string __running_22 = "";
        private int __send = 0;
        private int __r = 178;
        private int __g = 147;
        private int __b = 64;
        private bool __is_close;
        private bool __is_login = false;
        private bool __is_send = false;
        private bool __m_aeroEnabled;
        Form __mainFormHandler;

        // Drag Header to Move
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        // ----- Drag Header to Move

        // Form Shadow
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int WS_MINIMIZEBOX = 0x20000;
        private const int CS_DBLCLKS = 0x8;
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                __m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!__m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (__m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
                m.Result = (IntPtr)HTCAPTION;
        }
        // ----- Form Shadow

        public Main_Form()
        {
            InitializeComponent();

            timer_landing.Start();
        }

        // Drag to Move
        private void panel_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_loader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void label_brand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panel_landing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_landing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBox_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // ----- Drag to Move

        // Click Close
        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Exit the program?", __app__website_name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                __is_close = true;
                Environment.Exit(0);
            }
        }

        // Click Minimize
        private void pictureBox_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        const UInt32 WM_CLOSE = 0x0010;

        void ___CloseMessageBox()
        {
            IntPtr windowPtr = FindWindowByCaption(IntPtr.Zero, "JavaScript Alert - http://mem.sghuatchai.com");

            if (windowPtr == IntPtr.Zero)
            {
                return;
            }

            SendMessage(windowPtr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        private void timer_close_message_box_Tick(object sender, EventArgs e)
        {
            ___CloseMessageBox();
        }

        private void timer_size_Tick(object sender, EventArgs e)
        {
            __mainFormHandler = Application.OpenForms[0];
            __mainFormHandler.Size = new Size(466, 168);
        }

        // Form Closing
        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!__is_close)
            {
                DialogResult dr = MessageBox.Show("Exit the program?", __app__website_name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        // Form Load
        private void Main_Form_Load(object sender, EventArgs e)
        {
            __app__website_name = __app + " - " + __website_name;
            panel1.BackColor = Color.FromArgb(__r, __g, __b);
            panel2.BackColor = Color.FromArgb(__r, __g, __b);
            label_brand.BackColor = Color.FromArgb(__r, __g, __b);
            Text = __app__website_name;
            label_title.Text = __app__website_name;

            InitializeChromium();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (__is_send)
            {
                __is_send = false;
                MessageBox.Show("Telegram Notification is Disabled.", __brand_code + " " + __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                __is_send = true;
                MessageBox.Show("Telegram Notification is Enabled.", __brand_code + " " + __app, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer_landing_Tick(object sender, EventArgs e)
        {
            panel_landing.Visible = false;
            panel_cefsharp.Visible = false;
            pictureBox_loader.Visible = true;
            label_page_count.Visible = true;
            label_currentrecord.Visible = true;
            timer_size.Start();
            timer_landing.Stop();
        }

        public static void ___FlushMemory()
        {
            Process prs = Process.GetCurrentProcess();
            try
            {
                prs.MinWorkingSet = (IntPtr)(300000);
            }
            catch (Exception err)
            {
                // leave blank
            }
        }

        private void timer_flush_memory_Tick(object sender, EventArgs e)
        {
            ___FlushMemory();
        }

        private void SendMyBot(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "772918363:AAHn2ufmP3ocLEilQ1V-IHcqYMcSuFJHx5g";
                string chatId = "@allandrake";
                string text = "-----" + __app__website_name + "-----%0A%0AIP:%20ABC PC%0ALocation:%20Pacific%20Star%0ADate%20and%20Time:%20[" + datetime + "]%0AMessage:%20" + message;
                urlString = String.Format(urlString, apiToken, chatId, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs);
                string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
                __send = 0;
            }
            catch (Exception err)
            {
                __send++;

                if (___CheckForInternetConnection())
                {
                    if (__send == 5)
                    {
                        __Flag();
                        __is_close = false;
                        Environment.Exit(0);
                    }
                    else
                    {
                        SendMyBot(message);
                    }
                }
                else
                {
                    __is_close = false;
                    Environment.Exit(0);
                }
            }
        }

        private void SendABCTeam(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToString("dd MMM HH:mm:ss");
                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                string apiToken = "651945130:AAGMFj-C4wX0yElG2dBU1SRbfrNZi75jPHg";
                string chatId = "@odds_bot_abc_team";
                string text = "Bot:%20-----" + __website_name.ToUpper() + "-----%0ADate%20and%20Time:%20[" + datetime + "]%0AMessage:%20<b>" + message + "</>&parse_mode=html";
                urlString = String.Format(urlString, apiToken, chatId, text);
                WebRequest request = WebRequest.Create(urlString);
                Stream rs = request.GetResponse().GetResponseStream();
                StreamReader reader = new StreamReader(rs);
                string line = "";
                StringBuilder sb = new StringBuilder();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                        sb.Append(line);
                }
                __send = 0;
            }
            catch (Exception err)
            {
                __send++;

                if (___CheckForInternetConnection())
                {
                    if (__send == 5)
                    {
                        __Flag();
                        __is_close = false;
                        Environment.Exit(0);
                    }
                    else
                    {
                        SendABCTeam(message);
                    }
                }
                else
                {
                    __is_close = false;
                    Environment.Exit(0);
                }
            }
        }

        private void timer_detect_running_Tick(object sender, EventArgs e)
        {
            //___DetectRunningAsync();
        }

        private async void ___DetectRunningAsync()
        {
            try
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string password = __brand_code + datetime + "youdieidie";
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string token = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower();

                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection
                    {
                        ["brand_code"] = __brand_code,
                        ["app_type"] = __app_type,
                        ["last_update"] = datetime,
                        ["token"] = token
                    };

                    var response = wb.UploadValues("http://192.168.10.252:8080/API/updateAppStatus", "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                }
                __send = 0;
            }
            catch (Exception err)
            {
                __send++;

                if (___CheckForInternetConnection())
                {
                    if (__send == 5)
                    {
                        SendMyBot(err.ToString());
                        __is_close = false;
                        Environment.Exit(0);
                    }
                    else
                    {
                        await ___TaskWait_Handler(10);
                        ___DetectRunning2Async();
                    }
                }
                else
                {
                    __is_close = false;
                    Environment.Exit(0);
                }
            }
        }

        private async void ___DetectRunning2Async()
        {
            try
            {
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string password = __brand_code + datetime + "youdieidie";
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string token = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower();

                using (var wb = new WebClient())
                {
                    var data = new NameValueCollection
                    {
                        ["brand_code"] = __brand_code,
                        ["app_type"] = __app_type,
                        ["last_update"] = datetime,
                        ["token"] = token
                    };

                    var response = wb.UploadValues("http://zeus.ssitex.com:8080/API/updateAppStatus", "POST", data);
                    string responseInString = Encoding.UTF8.GetString(response);
                }
                __send = 0;
            }
            catch (Exception err)
            {
                __send++;

                if (___CheckForInternetConnection())
                {
                    if (__send == 5)
                    {
                        SendMyBot(err.ToString());
                        __is_close = false;
                        Environment.Exit(0);
                    }
                    else
                    {
                        await ___TaskWait_Handler(10);
                        ___DetectRunningAsync();
                    }
                }
                else
                {
                    __is_close = false;
                    Environment.Exit(0);
                }
            }
        }

        // CefSharp Initialize
        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();

            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            Cef.Initialize(settings);
            chromeBrowser = new ChromiumWebBrowser("https://nss.ms88bb.com/sports.aspx");
            panel_cefsharp.Controls.Add(chromeBrowser);
            chromeBrowser.AddressChanged += ChromiumBrowserAddressChanged;
        }

        // CefSharp Address Changed
        private void ChromiumBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            __url = e.Address.ToString();
            Invoke(new Action(() =>
            {
                //panel3.Visible = true;
                panel4.Visible = true;
            }));

            if (e.Address.ToString().Equals("https://nss.ms88bb.com/sports.aspx"))
            {
                Invoke(new Action(() =>
                {
                    chromeBrowser.FrameLoadEnd += (sender_, args) =>
                    {
                        if (args.Frame.IsMain)
                        {
                            Invoke(new Action(() =>
                            {
                                __is_login = true;
                                panel_cefsharp.Visible = false;
                                pictureBox_loader.Visible = true;

                                SendABCTeam("Firing up!");

                                Task task_01 = new Task(delegate { ___FIRST_RUNNINGAsync(); });
                                task_01.Start();
                            }));
                        }
                    };
                }));
            }
        }

        // ----- Functions
        // MS88BB -----
        private async void ___FIRST_RUNNINGAsync()
        {
            Invoke(new Action(() =>
            {
                panel4.BackColor = Color.FromArgb(0, 255, 0);
            }));

            try
            {
                var cookieManager = Cef.GetGlobalCookieManager();
                var visitor = new CookieCollector();
                cookieManager.VisitUrlCookies(__url, true, visitor);
                var cookies = await visitor.Task;
                var cookie = CookieCollector.GetCookieHeader(cookies);
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", cookie);
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                var reqparm = new NameValueCollection
                {
                    {"spid", "10"},
                    {"ot", "2"},
                    {"dt", "21"},
                    {"vt", "0"},
                    {"vs", "0"},
                    {"tf", "0"},
                    {"vd", "0"},
                    {"lid", "en"},
                    {"lgnum", "999"},
                    {"reqpart", "0"},
                    {"verpart", "undefined"},
                    {"prevParams", "undefined"},
                    {"verpartLA", ""}
                };

                byte[] result = await wc.UploadValuesTaskAsync("https://nss.ms88bb.com/nss/Main2Data.aspx", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(result).Replace("<script type=\"text/javascript\">var d=[];d=", "").Replace(";parent.main.rdrLvScr.lfull(d);</script>", "");
                var deserializeObject = JsonConvert.DeserializeObject(responsebody);
                JArray _jo = JArray.Parse(deserializeObject.ToString());
                JToken _count = _jo.SelectToken("[0]");

                string password = __running_01 + __api_key;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string token = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                string ref_match_id = "";
                string _last_ref_id = "";
                int _row_no = 1;

                JToken LeagueName = "";
                JToken MatchID = "";
                JToken HomeTeamName = "";
                JToken AwayTeamName = "";
                JToken HomeScore = "";
                JToken AwayScore = "";
                JToken MatchTimeHalf = "";
                JToken KickOffDateTime = "";
                String StatementDate = "";
                JToken MatchTimeMinute = "";
                String MatchStatus = "";

                if (_count.Count() > 0)
                {
                    for (int i = 0; i < _count.Count(); i++)
                    {

                        // League Name
                        string LeagueName_Detect = _jo.SelectToken("[0][" + i + "][2]").ToString().Replace("|0", "");
                        if (LeagueName_Detect != "")
                        {
                            LeagueName = LeagueName_Detect;
                        }
                        // Match ID
                        string MatchID_Detect = _jo.SelectToken("[0][" + i + "][3]").ToString();
                        if (MatchID_Detect != "")
                        {
                            MatchID = MatchID_Detect;
                        }
                        // Home Team Name
                        string HomeTeamName_Detect = _jo.SelectToken("[0][" + i + "][6]").ToString();
                        if (HomeTeamName_Detect != "")
                        {
                            HomeTeamName = HomeTeamName_Detect;
                        }
                        // Away Team Name
                        string AwayTeamName_Detect = _jo.SelectToken("[0][" + i + "][7]").ToString();
                        if (AwayTeamName_Detect != "")
                        {
                            AwayTeamName = AwayTeamName_Detect;
                        }
                        // Home Score
                        string HomeScore_Detect = _jo.SelectToken("[0][" + i + "][8]").ToString();
                        if (HomeScore_Detect != "")
                        {
                            String[] HomeScore_Replace = HomeScore_Detect.ToString().Split(new string[] { "_" }, StringSplitOptions.None);
                            HomeScore = HomeScore_Replace[1].Trim();
                        }
                        // Away Score
                        string AwayScore_Detect = _jo.SelectToken("[0][" + i + "][9]").ToString();
                        if (AwayScore_Detect != "")
                        {
                            AwayScore = AwayScore_Detect;
                        }
                        // Match Time Half
                        string MatchTimeHalf_Detect = _jo.SelectToken("[0][" + i + "][10]").ToString();
                        if (MatchTimeHalf_Detect != "")
                        {
                            if (MatchTimeHalf_Detect == "1")
                            {
                                MatchTimeHalf_Detect = "1H";
                            }
                            else if (MatchTimeHalf_Detect == "2")
                            {
                                MatchTimeHalf_Detect = "HT";
                            }
                            else if (MatchTimeHalf_Detect == "3")
                            {
                                MatchTimeHalf_Detect = "2H";
                            }
                            
                            MatchTimeHalf = MatchTimeHalf_Detect;
                        }
                        // Match Time Minute
                        string MatchTimeMinute_Detect = _jo.SelectToken("[0][" + i + "][11]").ToString().Replace("`", "");
                        if (MatchTimeMinute_Detect != "")
                        {
                            MatchTimeMinute = MatchTimeMinute_Detect;
                        }
                        else
                        {
                            if (LeagueName_Detect != "")
                            {
                                MatchTimeMinute = "0";
                            }
                        }
                        if (__is_numeric(MatchTimeMinute.ToString()))
                        {
                            if (MatchTimeHalf.ToString() == "2H" && Convert.ToInt32(MatchTimeMinute.ToString()) > 30)
                            {
                                MatchTimeHalf = "FT";
                                MatchStatus = "C";
                            }
                            else
                            {
                                MatchStatus = "R";
                            }
                        }
                        else
                        {
                            MatchStatus = "R";
                        }
                        // KickOffDateTime && StatementDate
                        string KickOffDateTime_Detect = _jo.SelectToken("[0][" + i + "][5]").ToString();
                        if (KickOffDateTime_Detect != "")
                        {
                            DateTime KickOffDateTime_Replace = DateTime.ParseExact(KickOffDateTime_Detect.ToString(), "yyyyMMddHHmm", CultureInfo.InvariantCulture);
                            KickOffDateTime = KickOffDateTime_Replace.ToString("yyyy-MM-dd HH:mm:ss");
                            StatementDate = KickOffDateTime_Replace.ToString("yyyy-MM-dd 00:00:00");
                        }
                        // FTHDP
                        JToken FTHDP = _jo.SelectToken("[0][" + i + "][21]").ToString().Replace("|", "");
                        JToken FTH = _jo.SelectToken("[0][" + i + "][23]");
                        if (FTH.ToString() != "" && FTH.ToString() != "|")
                        {
                            String[] FTH_Replace = FTH.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTH = Math.Round(Convert.ToDecimal(FTH_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTH = "";
                        }
                        JToken FTA = _jo.SelectToken("[0][" + i + "][24]");
                        if (FTA.ToString() != "" && FTA.ToString() != "|")
                        {
                            String[] FTA_Replace = FTA.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTA = Math.Round(Convert.ToDecimal(FTA_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTA = "";
                        }
                        // FTOU
                        JToken FTOU = _jo.SelectToken("[0][" + i + "][30]").ToString().Replace("|", "");
                        JToken FTO = _jo.SelectToken("[0][" + i + "][32]");
                        if (FTO.ToString() != "" && FTO.ToString() != "|")
                        {
                            String[] FTO_Replace = FTO.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTO = Math.Round(Convert.ToDecimal(FTO_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTO = "";
                        }
                        JToken FTU = _jo.SelectToken("[0][" + i + "][33]");
                        if (FTU.ToString() != "" && FTU.ToString() != "|")
                        {
                            String[] FTU_Replace = FTU.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTU = Math.Round(Convert.ToDecimal(FTU_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTU = "";
                        }
                        // 1x2
                        JToken FT1 = _jo.SelectToken("[0][" + i + "][46]");
                        if (FT1.ToString() != "" && FT1.ToString() != "|")
                        {
                            String[] FT1_Replace = FT1.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FT1 = Math.Round(Convert.ToDecimal(FT1_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FT1 = "";
                        }
                        JToken FT2 = _jo.SelectToken("[0][" + i + "][48]");
                        if (FT2.ToString() != "" && FT2.ToString() != "|")
                        {
                            String[] FT2_Replace = FT2.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FT2 = Math.Round(Convert.ToDecimal(FT2_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FT2 = "";
                        }
                        JToken FTX = _jo.SelectToken("[0][" + i + "][47]");
                        if (FTX.ToString() != "" && FTX.ToString() != "|")
                        {
                            String[] FTX_Replace = FTX.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTX = Math.Round(Convert.ToDecimal(FTX_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTX = "";
                        }

                        // FHHDP
                        JToken FHHDP = _jo.SelectToken("[0][" + i + "][54]").ToString().Replace("|", "");
                        JToken FHH = _jo.SelectToken("[0][" + i + "][56]");
                        if (FHH.ToString() != "" && FHH.ToString() != "|")
                        {
                            String[] FHH_Replace = FHH.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHH = Math.Round(Convert.ToDecimal(FHH_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHH = "";
                        }
                        JToken FHA = _jo.SelectToken("[0][" + i + "][57]");
                        if (FHA.ToString() != "" && FHA.ToString() != "|")
                        {
                            String[] FHA_Replace = FHA.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHA = Math.Round(Convert.ToDecimal(FHA_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHA = "";
                        }
                        // FHOU
                        JToken FHOU = _jo.SelectToken("[0][" + i + "][63]").ToString().Replace("|", "");
                        JToken FHO = _jo.SelectToken("[0][" + i + "][65]");
                        if (FHO.ToString() != "" && FHO.ToString() != "|")
                        {
                            String[] FHO_Replace = FHO.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHO = Math.Round(Convert.ToDecimal(FHO_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHO = "";
                        }
                        JToken FHU = _jo.SelectToken("[0][" + i + "][66]");
                        if (FHU.ToString() != "" && FHU.ToString() != "|")
                        {
                            String[] FHU_Replace = FHU.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHU = Math.Round(Convert.ToDecimal(FHU_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHU = "";
                        }
                        // 1x2
                        JToken FH1 = _jo.SelectToken("[0][" + i + "][72]");
                        if (FH1.ToString() != "" && FH1.ToString() != "|")
                        {
                            String[] FH1_Replace = FH1.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FH1 = Math.Round(Convert.ToDecimal(FH1_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FH1 = "";
                        }
                        JToken FH2 = _jo.SelectToken("[0][" + i + "][74]");
                        if (FH2.ToString() != "" && FH2.ToString() != "|")
                        {
                            String[] FH2_Replace = FH2.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FH2 = Math.Round(Convert.ToDecimal(FH2_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FH2 = "";
                        }
                        JToken FHX = _jo.SelectToken("[0][" + i + "][73]");
                        if (FHX.ToString() != "" && FHX.ToString() != "|")
                        {
                            String[] FHX_Replace = FHX.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHX = Math.Round(Convert.ToDecimal(FHX_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHX = "";
                        }

                        ref_match_id = MatchID.ToString();
                        if (ref_match_id == _last_ref_id)
                        {
                            _row_no++;
                        }
                        else
                        {
                            _row_no = 1;
                        }

                        _last_ref_id = ref_match_id;

                        //MessageBox.Show("LeagueName: " + LeagueName + "\n" +
                        //                "MatchID: " + MatchID + "\n" +
                        //                "_row_no: " + _row_no + "\n" +
                        //                "HomeTeamName: " + HomeTeamName + "\n" +
                        //                "HomeTeamName: " + AwayTeamName + "\n" +
                        //                //"HomeScore: " + HomeScore + "\n" +
                        //                //"AwayScore: " + AwayScore + "\n" +
                        //                //"MatchTimeHalf: " + MatchTimeHalf + "\n" +
                        //                "MatchTimeMinute: " + MatchTimeMinute + "\n" +
                        //                "KickOffDateTime: " + KickOffDateTime + "\n" +
                        //                "StatementDate: " + StatementDate + "\n" +
                        //                "\n-FTHDP-\n" +
                        //                "FTHDP: " + FTHDP + "\n" +
                        //                "FTH: " + FTH + "\n" +
                        //                "FTA: " + FTA + "\n" +
                        //                "\nFTOU\n" +
                        //                "FTOU: " + FTOU + "\n" +
                        //                "FTO: " + FTO + "\n" +
                        //                "FTU: " + FTU + "\n" +
                        //                "\n1x2\n" +
                        //                "FT1: " + FT1 + "\n" +
                        //                "FT2: " + FT2 + "\n" +
                        //                "FTX: " + FTX + "\n" +
                        //                //"\nOdd\n" +
                        //                //"FTOdd: " + FTOdd + "\n" +
                        //                //"FTEven: " + FTEven + "\n" +
                        //                "\n-FHHDP-\n" +
                        //                "FHHDP: " + FHHDP + "\n" +
                        //                "FHH: " + FHH + "\n" +
                        //                "FHA: " + FHA + "\n" +
                        //                "\nFHOU\n" +
                        //                "FHOU: " + FHOU + "\n" +
                        //                "FHO: " + FHO + "\n" +
                        //                "FHU: " + FHU + "\n" +
                        //                "\n1x2\n" +
                        //                "FH1: " + FH1 + "\n" +
                        //                "FH2: " + FH2 + "\n" +
                        //                "FHX: " + FHX + "\n"
                        //                );
                                                
                        var reqparm_ = new NameValueCollection
                        {
                            {"source_id", "7"},
                            {"sport_name", ""},
                            {"league_name", LeagueName.ToString().Trim()},
                            {"home_team", HomeTeamName.ToString().Trim()},
                            {"away_team", AwayTeamName.ToString().Trim()},
                            {"home_team_score", HomeScore.ToString()},
                            {"away_team_score", AwayScore.ToString()},
                            {"ref_match_id", ref_match_id},
                            {"odds_row_no", _row_no.ToString()},
                            {"fthdp", (FTHDP.ToString() != "") ? FTHDP.ToString() : "0"},
                            {"fth", (FTH.ToString() != "") ? FTH.ToString() : "0"},
                            {"fta", (FTA.ToString() != "") ? FTA.ToString() : "0"},
                            {"betidftou", "0"},
                            {"ftou", "0"},
                            {"fto", (FTO.ToString() != "") ? FTO.ToString() : "0"},
                            {"ftu", (FTU.ToString() != "") ? FTU.ToString() : "0"},
                            {"betidftoe", "0"},
                            {"ftodd", "0"},
                            {"fteven", "0"},
                            {"betidft1x2", "0"},
                            {"ft1", (FT1.ToString() != "") ? FT1.ToString() : "0"},
                            {"ftx", (FTX.ToString() != "") ? FTX.ToString() : "0"},
                            {"ft2", (FT2.ToString() != "") ? FT2.ToString() : "0"},
                            {"specialgame", "0"},
                            {"fhhdp", (FHHDP.ToString() != "") ? FHHDP.ToString() : "0"},
                            {"fhh", (FHH.ToString() != "") ? FHH.ToString() : "0"},
                            {"fha", (FHA.ToString() != "") ? FHA.ToString() : "0"},
                            {"fhou", (FHOU.ToString() != "") ? FHOU.ToString() : "0"},
                            {"fho", (FHO.ToString() != "") ? FHO.ToString() : "0"},
                            {"fhu", (FHU.ToString() != "") ? FHU.ToString() : "0"},
                            {"fhodd", "0"},
                            {"fheven", "0"},
                            {"fh1", (FH1.ToString() != "") ? FH1.ToString() : "0"},
                            {"fhx", (FHX.ToString() != "") ? FHX.ToString() : "0"},
                            {"fh2", (FH2.ToString() != "") ? FH2.ToString() : "0"},
                            {"statement_date", StatementDate.ToString()},
                            {"kickoff_date", KickOffDateTime.ToString()},
                            {"match_time", MatchTimeHalf.ToString()},
                            {"match_status", MatchStatus},
                            {"match_minute", MatchTimeMinute.ToString()},
                            {"api_status", "R"},
                            {"token_api", token},
                        };

                        try
                        {
                            WebClient wc_ = new WebClient();
                            byte[] result_ = wc_.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
                            string responsebody_ = Encoding.UTF8.GetString(result_);
                            __send = 0;
                        }
                        catch (Exception err)
                        {
                            __send++;

                            if (___CheckForInternetConnection())
                            {
                                if (__send == 5)
                                {
                                    SendMyBot(err.ToString());
                                    __is_close = false;
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    await ___TaskWait_Handler(10);
                                    WebClient wc_ = new WebClient();
                                    byte[] result_ = wc_.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
                                    string responsebody_ = Encoding.UTF8.GetString(result_);
                                }
                            }
                            else
                            {
                                __is_close = false;
                                Environment.Exit(0);
                            }
                        }
                    }
                }

                __send = 0;
                ___FIRST_NOTRUNNINGAsync();
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    __send++;
                    if (__send == 5)
                    {
                        Properties.Settings.Default.______odds_iswaiting_01 = true;
                        Properties.Settings.Default.Save();

                        if (!Properties.Settings.Default.______odds_issend_01)
                        {
                            Properties.Settings.Default.______odds_issend_01 = true;
                            Properties.Settings.Default.Save();
                            SendABCTeam(__running_11 + " Under Maintenance.");
                        }

                        ___FIRST_NOTRUNNINGAsync();
                        SendMyBot(err.ToString());
                    }
                    else
                    {
                        await ___TaskWait_Handler(10);
                        ___FIRST_RUNNINGAsync();
                    }
                }
                else
                {
                    __is_close = false;
                    Environment.Exit(0);
                }
            }
        }

        private async void ___FIRST_NOTRUNNINGAsync()
        {
            try
            {
                var cookieManager = Cef.GetGlobalCookieManager();
                var visitor = new CookieCollector();
                cookieManager.VisitUrlCookies(__url, true, visitor);
                var cookies = await visitor.Task;
                var cookie = CookieCollector.GetCookieHeader(cookies);
                WebClient wc = new WebClient();
                wc.Headers.Add("Cookie", cookie);
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                var reqparm = new NameValueCollection
                {
                    {"spid", "10"},
                    {"ot", "2"},
                    {"dt", "2"},
                    {"vt", "0"},
                    {"vs", "0"},
                    {"tf", "10"},
                    {"vd", "0"},
                    {"lid", "en"},
                    {"lgnum", "999"},
                    {"reqpart", "0"},
                    {"verpart", "undefined"},
                    {"prevParams", "undefined"}
                };

                byte[] result = await wc.UploadValuesTaskAsync("https://nss.ms88bb.com/nss/Main2Data.aspx", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(result).Replace(";parent.main.rdrScr.full(d);</script>", "");
                var pattern = @"Date\((.*?)\)";
                Match responsebody_detect = Regex.Match(responsebody, pattern, RegexOptions.IgnoreCase);
                if (responsebody_detect.Success)
                {
                    responsebody = Regex.Replace(responsebody, pattern, String.Empty).Replace("<script type=\"text/javascript\">var d=[];parent.svrTime2=new ; d=", "");
                }
                else
                {
                    SendMyBot(Encoding.UTF8.GetString(result));
                }

                var deserializeObject = JsonConvert.DeserializeObject(responsebody);
                JArray _jo = JArray.Parse(deserializeObject.ToString());
                JToken _count = _jo.SelectToken("[0]");

                string password = __running_01 + __api_key;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                string token = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                string ref_match_id = "";
                string _last_ref_id = "";
                int _row_no = 1;

                JToken LeagueName = "";
                JToken MatchID = "";
                JToken HomeTeamName = "";
                JToken AwayTeamName = "";
                JToken KickOffDateTime = "";
                String StatementDate = "";
                JToken MatchTimeMinute = "";

                if (_count.Count() > 0)
                {
                    for (int i = 0; i < _count.Count(); i++)
                    {

                        // League Name
                        string LeagueName_Detect = _jo.SelectToken("[0][" + i + "][2]").ToString().Replace("|0", "");
                        if (LeagueName_Detect != "")
                        {
                            LeagueName = LeagueName_Detect;
                        }
                        // Match ID
                        string MatchID_Detect = _jo.SelectToken("[0][" + i + "][3]").ToString();
                        if (MatchID_Detect != "")
                        {
                            MatchID = MatchID_Detect;
                        }
                        // Home Team Name
                        string HomeTeamName_Detect = _jo.SelectToken("[0][" + i + "][6]").ToString();
                        if (HomeTeamName_Detect != "")
                        {
                            HomeTeamName = HomeTeamName_Detect;
                        }
                        // Away Team Name
                        string AwayTeamName_Detect = _jo.SelectToken("[0][" + i + "][7]").ToString();
                        if (AwayTeamName_Detect != "")
                        {
                            AwayTeamName = AwayTeamName_Detect;
                        }
                        // Match Time Minute
                        string MatchTimeMinute_Detect = _jo.SelectToken("[0][" + i + "][11]").ToString().Replace("`", "");
                        if (MatchTimeMinute_Detect != "")
                        {
                            MatchTimeMinute = MatchTimeMinute_Detect;
                        }
                        else
                        {
                            if (LeagueName_Detect != "")
                            {
                                MatchTimeMinute = "0asdsadsadsdsadas";
                            }
                        }
                        // KickOffDateTime && StatementDate
                        string KickOffDateTime_Detect = _jo.SelectToken("[0][" + i + "][5]").ToString();
                        if (KickOffDateTime_Detect != "")
                        {
                            DateTime KickOffDateTime_Replace = DateTime.ParseExact(KickOffDateTime_Detect.ToString(), "yyyyMMddHHmm", CultureInfo.InvariantCulture);
                            KickOffDateTime = KickOffDateTime_Replace.ToString("yyyy-MM-dd HH:mm:ss");
                            StatementDate = KickOffDateTime_Replace.ToString("yyyy-MM-dd 00:00:00");
                        }
                        // FTHDP
                        JToken FTHDP = _jo.SelectToken("[0][" + i + "][21]").ToString().Replace("|", "");
                        JToken FTH = _jo.SelectToken("[0][" + i + "][23]");
                        if (FTH.ToString() != "" && FTH.ToString() != "|")
                        {
                            String[] FTH_Replace = FTH.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTH = Math.Round(Convert.ToDecimal(FTH_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTH = "";
                        }
                        JToken FTA = _jo.SelectToken("[0][" + i + "][24]");
                        if (FTA.ToString() != "" && FTA.ToString() != "|")
                        {
                            String[] FTA_Replace = FTA.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTA = Math.Round(Convert.ToDecimal(FTA_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTA = "";
                        }
                        // FTOU
                        JToken FTOU = _jo.SelectToken("[0][" + i + "][30]").ToString().Replace("|", "");
                        JToken FTO = _jo.SelectToken("[0][" + i + "][32]");
                        if (FTO.ToString() != "" && FTO.ToString() != "|")
                        {
                            String[] FTO_Replace = FTO.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTO = Math.Round(Convert.ToDecimal(FTO_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTO = "";
                        }
                        JToken FTU = _jo.SelectToken("[0][" + i + "][33]");
                        if (FTU.ToString() != "" && FTU.ToString() != "|")
                        {
                            String[] FTU_Replace = FTU.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTU = Math.Round(Convert.ToDecimal(FTU_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTU = "";
                        }
                        // 1x2
                        JToken FT1 = _jo.SelectToken("[0][" + i + "][46]");
                        if (FT1.ToString() != "" && FT1.ToString() != "|")
                        {
                            String[] FT1_Replace = FT1.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FT1 = Math.Round(Convert.ToDecimal(FT1_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FT1 = "";
                        }
                        JToken FT2 = _jo.SelectToken("[0][" + i + "][48]");
                        if (FT2.ToString() != "" && FT2.ToString() != "|")
                        {
                            String[] FT2_Replace = FT2.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FT2 = Math.Round(Convert.ToDecimal(FT2_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FT2 = "";
                        }
                        JToken FTX = _jo.SelectToken("[0][" + i + "][47]");
                        if (FTX.ToString() != "" && FTX.ToString() != "|")
                        {
                            String[] FTX_Replace = FTX.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FTX = Math.Round(Convert.ToDecimal(FTX_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FTX = "";
                        }

                        // FHHDP
                        JToken FHHDP = _jo.SelectToken("[0][" + i + "][54]").ToString().Replace("|", "");
                        JToken FHH = _jo.SelectToken("[0][" + i + "][56]");
                        if (FHH.ToString() != "" && FHH.ToString() != "|")
                        {
                            String[] FHH_Replace = FHH.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHH = Math.Round(Convert.ToDecimal(FHH_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHH = "";
                        }
                        JToken FHA = _jo.SelectToken("[0][" + i + "][57]");
                        if (FHA.ToString() != "" && FHA.ToString() != "|")
                        {
                            String[] FHA_Replace = FHA.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHA = Math.Round(Convert.ToDecimal(FHA_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHA = "";
                        }
                        // FHOU
                        JToken FHOU = _jo.SelectToken("[0][" + i + "][63]").ToString().Replace("|", "");
                        JToken FHO = _jo.SelectToken("[0][" + i + "][65]");
                        if (FHO.ToString() != "" && FHO.ToString() != "|")
                        {
                            String[] FHO_Replace = FHO.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHO = Math.Round(Convert.ToDecimal(FHO_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHO = "";
                        }
                        JToken FHU = _jo.SelectToken("[0][" + i + "][66]");
                        if (FHU.ToString() != "" && FHU.ToString() != "|")
                        {
                            String[] FHU_Replace = FHU.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHU = Math.Round(Convert.ToDecimal(FHU_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHU = "";
                        }
                        // 1x2
                        JToken FH1 = _jo.SelectToken("[0][" + i + "][72]");
                        if (FH1.ToString() != "" && FH1.ToString() != "|")
                        {
                            String[] FH1_Replace = FH1.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FH1 = Math.Round(Convert.ToDecimal(FH1_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FH1 = "";
                        }
                        JToken FH2 = _jo.SelectToken("[0][" + i + "][74]");
                        if (FH2.ToString() != "" && FH2.ToString() != "|")
                        {
                            String[] FH2_Replace = FH2.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FH2 = Math.Round(Convert.ToDecimal(FH2_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FH2 = "";
                        }
                        JToken FHX = _jo.SelectToken("[0][" + i + "][73]");
                        if (FHX.ToString() != "" && FHX.ToString() != "|")
                        {
                            String[] FHX_Replace = FHX.ToString().Split(new string[] { "|" }, StringSplitOptions.None);
                            FHX = Math.Round(Convert.ToDecimal(FHX_Replace[0].Trim()), 2);
                        }
                        else
                        {
                            FHX = "";
                        }

                        ref_match_id = MatchID.ToString();
                        if (ref_match_id == _last_ref_id)
                        {
                            _row_no++;
                        }
                        else
                        {
                            _row_no = 1;
                        }

                        _last_ref_id = ref_match_id;

                        //MessageBox.Show("LeagueName: " + LeagueName + "\n" +
                        //                "MatchID: " + MatchID + "\n" +
                        //                "_row_no: " + _row_no + "\n" +
                        //                "HomeTeamName: " + HomeTeamName + "\n" +
                        //                "HomeTeamName: " + AwayTeamName + "\n" +
                        //                //"HomeScore: " + HomeScore + "\n" +
                        //                //"AwayScore: " + AwayScore + "\n" +
                        //                //"MatchTimeHalf: " + MatchTimeHalf + "\n" +
                        //                "MatchTimeMinute: " + MatchTimeMinute + "\n" +
                        //                "KickOffDateTime: " + KickOffDateTime + "\n" +
                        //                "StatementDate: " + StatementDate + "\n" +
                        //                "\n-FTHDP-\n" +
                        //                "FTHDP: " + FTHDP + "\n" +
                        //                "FTH: " + FTH + "\n" +
                        //                "FTA: " + FTA + "\n" +
                        //                "\nFTOU\n" +
                        //                "FTOU: " + FTOU + "\n" +
                        //                "FTO: " + FTO + "\n" +
                        //                "FTU: " + FTU + "\n" +
                        //                "\n1x2\n" +
                        //                "FT1: " + FT1 + "\n" +
                        //                "FT2: " + FT2 + "\n" +
                        //                "FTX: " + FTX + "\n" +
                        //                //"\nOdd\n" +
                        //                //"FTOdd: " + FTOdd + "\n" +
                        //                //"FTEven: " + FTEven + "\n" +
                        //                "\n-FHHDP-\n" +
                        //                "FHHDP: " + FHHDP + "\n" +
                        //                "FHH: " + FHH + "\n" +
                        //                "FHA: " + FHA + "\n" +
                        //                "\nFHOU\n" +
                        //                "FHOU: " + FHOU + "\n" +
                        //                "FHO: " + FHO + "\n" +
                        //                "FHU: " + FHU + "\n" +
                        //                "\n1x2\n" +
                        //                "FH1: " + FH1 + "\n" +
                        //                "FH2: " + FH2 + "\n" +
                        //                "FHX: " + FHX + "\n"
                        //                );

                        var reqparm_ = new NameValueCollection
                        {
                            {"source_id", "7"},
                            {"sport_name", ""},
                            {"league_name", LeagueName.ToString().Trim()},
                            {"home_team", HomeTeamName.ToString().Trim()},
                            {"away_team", AwayTeamName.ToString().Trim()},
                            {"home_team_score", "0"},
                            {"away_team_score", "0"},
                            {"ref_match_id", ref_match_id},
                            {"odds_row_no", _row_no.ToString()},
                            {"fthdp", (FTHDP.ToString() != "") ? FTHDP.ToString() : "0"},
                            {"fth", (FTH.ToString() != "") ? FTH.ToString() : "0"},
                            {"fta", (FTA.ToString() != "") ? FTA.ToString() : "0"},
                            {"betidftou", "0"},
                            {"ftou", (FTOU.ToString() != "") ? FTOU.ToString() : "0"},
                            {"fto", (FTO.ToString() != "") ? FTO.ToString() : "0"},
                            {"ftu", (FTU.ToString() != "") ? FTU.ToString() : "0"},
                            {"betidftoe", "0"},
                            {"ftodd", "0"},
                            {"fteven", "0"},
                            {"betidft1x2", "0"},
                            {"ft1", (FT1.ToString() != "") ? FT1.ToString() : "0"},
                            {"ftx", (FTX.ToString() != "") ? FTX.ToString() : "0"},
                            {"ft2", (FT2.ToString() != "") ? FT2.ToString() : "0"},
                            {"specialgame", "0"},
                            {"fhhdp", (FHHDP.ToString() != "") ? FHHDP.ToString() : "0"},
                            {"fhh", (FHH.ToString() != "") ? FHH.ToString() : "0"},
                            {"fha", (FHA.ToString() != "") ? FHA.ToString() : "0"},
                            {"fhou", (FHOU.ToString() != "") ? FHOU.ToString() : "0"},
                            {"fho", (FHO.ToString() != "") ? FHO.ToString() : "0"},
                            {"fhu", (FHU.ToString() != "") ? FHU.ToString() : "0"},
                            {"fhodd", "0"},
                            {"fheven", "0"},
                            {"fh1", (FH1.ToString() != "") ? FH1.ToString() : "0"},
                            {"fhx", (FHX.ToString() != "") ? FHX.ToString() : "0"},
                            {"fh2", (FH2.ToString() != "") ? FH2.ToString() : "0"},
                            {"statement_date", StatementDate.ToString()},
                            {"kickoff_date", KickOffDateTime.ToString()},
                            {"match_time", "Upcoming"},
                            {"match_status", "N"},
                            {"match_minute", "0"},
                            {"api_status", "R"},
                            {"token_api", token},
                        };

                        try
                        {
                            WebClient wc_ = new WebClient();
                            byte[] result_ = wc_.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
                            string responsebody_ = Encoding.UTF8.GetString(result_);
                            __send = 0;
                        }
                        catch (Exception err)
                        {
                            __send++;

                            if (___CheckForInternetConnection())
                            {
                                if (__send == 5)
                                {
                                    SendMyBot(err.ToString());
                                    __is_close = false;
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    await ___TaskWait_Handler(10);
                                    WebClient wc_ = new WebClient();
                                    byte[] result_ = wc_.UploadValues("http://oddsgrabber.ssitex.com/API/sendOdds", "POST", reqparm_);
                                    string responsebody_ = Encoding.UTF8.GetString(result_);
                                }
                            }
                            else
                            {
                                __is_close = false;
                                Environment.Exit(0);
                            }
                        }
                    }
                }

                // send msports 
                if (!Properties.Settings.Default.______odds_iswaiting_01 && Properties.Settings.Default.______odds_issend_01)
                {
                    Properties.Settings.Default.______odds_issend_01 = false;
                    Properties.Settings.Default.Save();

                    SendABCTeam(__running_11 + " Back to Normal.");
                }

                Properties.Settings.Default.______odds_iswaiting_01 = false;
                Properties.Settings.Default.Save();

                Invoke(new Action(() =>
                {
                    panel4.BackColor = Color.FromArgb(16, 90, 101);
                }));

                __send = 0;
                await ___TaskWait();
                ___FIRST_RUNNINGAsync();
            }
            catch (Exception err)
            {
                if (___CheckForInternetConnection())
                {
                    __send++;
                    if (__send == 5)
                    {
                        Properties.Settings.Default.______odds_iswaiting_01 = true;
                        Properties.Settings.Default.Save();

                        if (!Properties.Settings.Default.______odds_issend_01)
                        {
                            Properties.Settings.Default.______odds_issend_01 = true;
                            Properties.Settings.Default.Save();
                            SendABCTeam(__running_11 + " Under Maintenance.");
                        }

                        ___FIRST_RUNNINGAsync();
                        SendMyBot(err.ToString());
                    }
                    else
                    {
                        await ___TaskWait_Handler(10);
                        ___FIRST_NOTRUNNINGAsync();
                    }
                }
                else
                {
                    __is_close = false;
                    Environment.Exit(0);
                }
            }
        }

        public static bool ___CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task ___TaskWait()
        {
            Random _random = new Random();
            int _random_number = _random.Next(10, 16);
            string _randowm_number_replace = _random_number.ToString() + "000";
            await Task.Delay(Convert.ToInt32(_randowm_number_replace));
        }

        private async Task ___TaskWait_Handler(int sec)
        {
            sec++;
            Random _random = new Random();
            int _random_number = _random.Next(sec, sec);
            string _randowm_number_replace = _random_number.ToString() + "000";
            await Task.Delay(Convert.ToInt32(_randowm_number_replace));
        }

        public bool __is_numeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void __Flag()
        {
            string _flag = Path.Combine(Path.GetTempPath(), __app + " - " + __website_name + ".txt");
            using (StreamWriter sw = new StreamWriter(_flag, true))
            {
                sw.WriteLine("<<>>" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "<<>>");
            }
        }
    }
}