using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using LanguaMouse2._0.Properties;
using System.Media;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using Utilities;

namespace LanguaMouse2._0
{
    public partial class Form1 : Form
    {
        string usr = Environment.UserName;
        DateTime timenow = DateTime.Now;

        [DllImport("shell32.dll", EntryPoint = "#261",
              CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(
          string username,
          UInt32 whatever, // 0x80000000
          StringBuilder picpath, int maxLength);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);
        public static Point Position { get; set; }
        int X = Cursor.Position.X;
        int Y = Cursor.Position.Y;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // constants for the mouse_input() API function
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_XDOWN = 0x0080;
        private const int MOUSEEVENTF_XUP = 0x0100;
        private const int MOUSEEVENTF_WHEEL = 0x0800;
        private const int MOUSEEVENTF_HWHEEL = 0x01000;
        const int KEY_DOWN_EVENT = 0x0001; //Key down flag
        const int KEY_UP_EVENT = 0x0002; //Key up flag

      //  Random Location = new Random();
        List<Point> points = new List<Point>();

        public static SpeechSynthesizer lm = new SpeechSynthesizer();
        private SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        private SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        private SpeechRecognitionEngine goodbyelistening = new SpeechRecognitionEngine();

        Grid mGrid = new Grid();
        Form2 frm = new Form2();
        Form3 frm1 = new Form3();
        globalKeyboardHook gkh = new globalKeyboardHook();

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
        }

        // When the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("nudge up", "nudge down", "nudge left", "nudge right",
               "mouse move up", "mouse move down", "mouse move left", "mouse move right", "mouse stop", "right click", "left click", "escape",
               "grab it", "release it", "stop listening", "goto center screen", "shut down mouse", "show control panel", "press enter", "select all text",
               "hide control panel", "double click", "stand by mouse", "what can i do", "exit what can i do", "turn on highlight", "press backspace",
               "turn off highlight", "set text to 12", "set text to 14", "set text to 16", "set text to 18", "set text to 20", "set text to 22",
               "mouse scroll up", "mouse scroll down", "show grid", "cancel grid", "grid 1", "grid 2", "grid 3", "grid 4", "grid 5", "grid 6",
               "grid 7", "grid 8", "grid 9", "grid 10", "grid 11", "grid 12", "grid 13", "grid 14", "grid 15", "grid 16", "grid 17", "grid 18", "grid 19",
               "grid 20", "grid 21", "grid 22", "grid 23", "grid 24", "grid 25", "grid 26", "grid 27", "grid 28", "grid 29", "grid 30", "grid 31",
               "grid 32", "grid 33", "grid 34", "grid 35", "grid 36", "grid 37", "grid 38", "grid 39", "grid 40", "grid 41", "grid 42", "grid 43", "grid 44",
               "grid 45", "grid 46", "grid 47", "48", "49", "grid 50", "grid 51", "grid 52", "grid 53", "grid 54", "grid 55", "grid 56", "grid 57", "grid 58", "grid 59",
               "grid 60", "grid 61", "grid 62", "grid 63", "grid 64", "grid 65", "grid 66", "grid 67", "grid 68", "grid 69",
               "grid 70", "grid 71", "grid 72", "grid 73", "grid 74", "grid 75", "grid 76", "grid 77", "grid 78", "grid 79",
               "grid 80", "grid 81","read the selected text", "clear the clipboard"))));

            _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice(); // set the input of the speech recognizer to the default audio device
             // _recognizer.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous

            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices("enable push to talk", "enable hands free")))); //Loads a grammar choice into the speech recognition engine
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);

            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width /2 - this.Width /2, 0);
            lblDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
          //  this.Height = Screen.PrimaryScreen.Bounds.Height - 75;
            pictureBox1.Image = GetUserTile(usr);
            lblUser.Text = "Current user " + usr;
            numMonitors();

            gkh.HookedKeys.Add(Keys.NumPad0);
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            gkh.unhook();

            // load save settings
            #region Load from settings 

            if (Settings.Default.AutoLaunch == true)
            {               
                chkBoxStartUp.Checked = true;
            }
            else if (Settings.Default.AutoLaunch == false)
            {
                chkBoxStartUp.Checked = false;
            }

            if (Settings.Default.AutoHide == true)
            {
                tmrOut.Start();
                chkBoxAutoHide.Checked = true;
            }
            else if (Settings.Default.AutoHide == false)
            {
                tmrOut.Stop();
                panel1.Dock = DockStyle.Fill;
                toolStrip1.Visible = false;
            }

            if (Settings.Default.HighLight == true)
            {
                
                chkBoxHighLight.Checked = true;
            }
            else if (Settings.Default.HighLight == false)
            {
                chkBoxHighLight.Checked = false;
            }

            if (Settings.Default.PTT == true)
            {

                chkBoxPTT.Checked = true;
            }
            else if (Settings.Default.PTT == false)
            {
                chkBoxPTT.Checked = false;
            }

            if (Settings.Default.HandsFree == true)
            {

                chkBoxHFree.Checked = true;
            }
            else if (Settings.Default.HandsFree == false)
            {
                chkBoxHFree.Checked = false;
            }

            if (Settings.Default.TalkBack == true)
            {

                chkBoxSpeak.Checked = true;
            }
            else if (Settings.Default.TalkBack == false)
            {
                chkBoxSpeak.Checked = false;
            }

            picBoxHighLight.BackColor = Settings.Default.highlightColor;
            picBoxLine.BackColor = Settings.Default.lineColor;
            picBoxFont.BackColor = Settings.Default.fontColor;
            picBoxBarFontColor.BackColor = Settings.Default.BarFontColor;
            panel1.ForeColor = picBoxFont.BackColor;
            lblTime.ForeColor = picBoxBarFontColor.BackColor;
            lblDate.ForeColor = picBoxBarFontColor.BackColor;
            toolStripButton1.ForeColor = picBoxBarFontColor.BackColor;
            txtMouseSpeed.ForeColor = picBoxFont.BackColor;
            txtNudgeAmount.ForeColor = picBoxFont.BackColor;
           
            if (Settings.Default.PTT == false & Settings.Default.HandsFree == false)
            { startlistening.RecognizeAsync(RecognizeMode.Multiple); }
            #endregion

            lmSpeak("Hello, I am ready to go.");
        }

        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            txtInput.Text = speech;

        }

        void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            switch (speech)
            {
                case "enable push to talk":
                    try
                    {
                        lm.SpeakAsync("p t t enabled");
                        gkh.hook();
                        chkBoxPTT.Checked = true;
                        lblStatus.BackColor = Color.Yellow;
                        lblStatus.Text = "PTT Ready";
                        lblStatus.ForeColor = Color.Black;
                        _recognizer.RecognizeAsyncCancel();
                        startlistening.RecognizeAsync(RecognizeMode.Multiple);

                    }
                    catch
                    { }
                    break;

                case "enable hands free":
                    try
                    {
                        lm.SpeakAsync("hands free enabled");
                        chkBoxHFree.Checked = true;
                        lblStatus.BackColor = Color.Yellow;
                        lblStatus.Text = "Hands Free Ready";
                        lblStatus.ForeColor = Color.Black;
                        startlistening.RecognizeAsyncCancel();
                        _recognizer.RecognizeAsync(RecognizeMode.Multiple);

                    }
                    catch
                    { }
                    break;
            }
        }

        // make the program pause
        public void wait(int interval)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < interval)
            {
                // Allows UI to remain responsive
                Application.DoEvents();
            }
            sw.Stop();
        }

        //Keep Time
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            timenow = DateTime.Now;
            string time = timenow.GetDateTimeFormats('T')[0];
            lblTime.Text = time;
        }

        // timer to expand the form
        private void tmrOut_Tick(object sender, EventArgs e)
        {
            if (RestoreBounds.Contains(MousePosition))
            {
                if (this.Height < 265)
                {
                    this.Height = this.Height + 75;
                }
                else if (this.Height == 269)
                {
                //    this.panel1.Visible = true;
                    tmrOut.Stop();
                    this.Height = 275;
                }
            }
            tmrInn.Start();
        }
    
        //timer to contract the form
        private void tmrInn_Tick(object sender, EventArgs e)
        {
            if (!RestoreBounds.Contains(MousePosition))
            {
                if (this.Height > 23)
                {
                    this.Height = this.Height - 75;
                }
                else if (this.Height < 21)
                {
                    tmrInn.Stop();
                    this.Height = 23;
                   
                }
            }
            tmrOut.Start();
        }
        
        // get the path on user image
        public static string GetUserTilePath(string username)
        {   // username: use null for current user
            var sb = new StringBuilder(1000);
            GetUserTilePath(username, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        // get user image
        public static Image GetUserTile(string username)
        {
            return Image.FromFile(GetUserTilePath(username));
        }

        // get the number of the monitors
        private void numMonitors()
        {
            string count = (Screen.AllScreens.Count().ToString());

            char[] chars = { '1', '2', '3' };
            // string m = new string(chars);

            
            foreach (char m in count)
            {
                lblNumScreens.Text = "Number of Monitors " + m;
                            
            }
        }

        // track cursor position
        private void tmrCurPosition_Tick(object sender, EventArgs e)
        {
            lblMouseXY.Text = "Mouse Location:  Left: " + Cursor.Position.X.ToString() + " Top: " + Cursor.Position.Y.ToString();
          
        }

        // Hide or show form chkbox
        private void chkBoxAutoHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxAutoHide.Checked == true)
            {
                tmrOut.Start();
            }
            else  {              
                        tmrOut.Stop();
                        tmrInn.Stop();
                        this.Width = 400;
                  }
        }

        //Do when the form resizes
        private void Form1_Resize(object sender, EventArgs e)
        {
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            if (this.Height > 275)
            {
                this.panel1.Visible = true;
                panel1.Dock = DockStyle.Fill;
                toolStrip1.Visible = false;
                this.Width = 439;
                panel1.Width = 439;
                panel1.Height = 269;

            }
            else if (this.Height < 150)
            {
                this.panel1.Visible = false;
                panel1.Dock = DockStyle.None;
                toolStrip1.Visible = true;
                this.Width = 439;
                panel1.Width = 439;
                panel1.Height = 269;
            }
        }
              
        //Paint the panel border
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;

            g = e.Graphics;

            Pen myPen = new Pen(Color.White);
            Pen bPen = new Pen(Color.Red);
            bPen.Width = 5;
            myPen.Width = 10;
            //  g.DrawLine(myPen, 30, 30, 45, 65);

            g.DrawLine(myPen, 0, 0, this.Width, 0);
            g.DrawLine(myPen, 0, 0, 0, this.Height);
            g.DrawLine(myPen, this.Width - 3, this.Height, this.Width, 0);
            g.DrawLine(myPen, 0, this.Height, this.Width, this.Height);
        }

        // Close the program
        private void btnClose_Click(object sender, EventArgs e)
        {
            _recognizer.UnloadAllGrammars();
            startlistening.UnloadAllGrammars();
            Application.Exit();
        }
        
        // Save application settings on close
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _recognizer.UnloadAllGrammars();
            startlistening.UnloadAllGrammars();

            if (chkBoxStartUp.Checked == true)
            {
                Settings.Default.AutoLaunch = true;
                Settings.Default.Save();
            }
            else if (chkBoxStartUp.Checked == false)
            {
                Settings.Default.AutoLaunch = false;
                Settings.Default.Save();
            }

            if (chkBoxAutoHide.Checked == true)
            {
                Settings.Default.AutoHide = true;
                Settings.Default.Save();
            } 
            else if (chkBoxAutoHide.Checked == false)
            {
                Settings.Default.AutoHide = false;
                Settings.Default.Save();
            }

            if (chkBoxHighLight.Checked == true)
            {
                Settings.Default.HighLight = true;
                Settings.Default.Save();
            }
            else if (chkBoxHighLight.Checked == false)
            {
                Settings.Default.HighLight = false;
                Settings.Default.Save();
            }

            if (chkBoxPTT.Checked == true)
            {
                Settings.Default.PTT = true;
                Settings.Default.Save();
            }
            else if (chkBoxPTT.Checked == false)
            {
                Settings.Default.PTT = false;
                Settings.Default.Save();
            }

            if (chkBoxHFree.Checked == true)
            {
                Settings.Default.HandsFree = true;
                Settings.Default.Save();
            }
            else if (chkBoxHFree.Checked == false)
            {
                Settings.Default.HandsFree = false;
                Settings.Default.Save();
            }

            if (chkBoxSpeak.Checked == true)
            {
                Settings.Default.TalkBack = true;
                Settings.Default.Save();
            }
            else if (chkBoxSpeak.Checked == false)
            {
                Settings.Default.TalkBack = false;
                Settings.Default.Save();
            }

            Settings.Default.fontColor = picBoxFont.BackColor;
            Settings.Default.fontColor = picBoxHighLight.BackColor;
            Settings.Default.fontColor = picBoxLine.BackColor;
           
            
        }

        private void picBoxHighLight_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
               if(colorDialog1.Color == Color.Black)
               {
                   MessageBox.Show("Can't use that color");
               }
               else
               {
                   // Set form background to the selected color.
                   picBoxHighLight.BackColor = colorDialog1.Color;
                   Settings.Default.highlightColor = picBoxHighLight.BackColor;
                   Settings.Default.Save();
                   Application.Restart();
               }
            }
        }

        private void picBoxFont_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                if (colorDialog1.Color == Color.Black)
                {
                    MessageBox.Show("Can't use that color");
                }
                else
                {
                    // Set form background to the selected color.
                    picBoxFont.BackColor = colorDialog1.Color;
                    Settings.Default.fontColor = colorDialog1.Color;
                    Settings.Default.Save();
                    Application.Restart();
                }
            }
        }

        private void picBoxLine_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                if (colorDialog1.Color == Color.Black)
                {
                    MessageBox.Show("Can't use that color");
                }
                else
                {
                    // Set form background to the selected color.
                    picBoxLine.BackColor = colorDialog1.Color;
                    Settings.Default.lineColor = colorDialog1.Color;
                    Settings.Default.Save();
                    Application.Restart();
                }
            }
        }

        private void picBoxBarFontColor_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog1.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                if (colorDialog1.Color == Color.Black)
                {
                    MessageBox.Show("Can't use that color");
                }
                else
                {
                    // Set form background to the selected color.
                    picBoxBarFontColor.BackColor = colorDialog1.Color;
                    Settings.Default.BarFontColor = colorDialog1.Color;
                    Settings.Default.Save();
                    Application.Restart();
                }
            }
        }
                
        private void lmSpeak(string str)
        {
            if (chkBoxSpeak.Checked == true)
            {
                lm.SpeakAsync(str);
            }
        }

        // fires when the targeted key is released
        void gkh_KeyUp(object sender, KeyEventArgs e)
        {

            lblStatus.BackColor = Color.Yellow;
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Black;
            _recognizer.RecognizeAsyncStop();

            _recognizer.RecognizeAsyncCancel();
            //    startlistening.RecognizeAsync(RecognizeMode.Multiple);
            e.Handled = true;

            tmrStopSound.Start();

        }

        // fires when the targeted key is pushed
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {

                lblStatus.BackColor = Color.Green;
                lblStatus.ForeColor = Color.White;
                lblStatus.Text = "Speak";

                //    startlistening.RecognizeAsyncCancel();
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                tmrStopSound.Start();
            }
            catch

            { }

        }

        Control GetControlByName(string Name)
        {
            foreach (Control c in mGrid.tableLayoutPanel1.Controls)
                if (c.Text == Name)
                    return c;

            return null;
        }

        // simulate mouse wheel up
        public static void wheelUP()
        {
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 250, 0);
        }

        // simulate mouse wheel down
        public static void wheelDown()
        {
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -250, 0);
        }

        // simulate left click
        public static void LeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        // simulate right click
        public static void RightClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
        }

        // move cursor to center screen
        private void centerScreen()
        {

            Cursor.Position = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

        }
        
        private void tmrMouseUP_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y - Int32.Parse(txtMouseSpeed.Text));
        }

        private void tmrMouseDown_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y + Int32.Parse(txtMouseSpeed.Text));
        }

        private void tmrMouseLeft_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X - Int32.Parse(txtMouseSpeed.Text), Cursor.Position.Y);
        }

        private void tmrMouseRight_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new System.Drawing.Point(Cursor.Position.X + Int32.Parse(txtMouseSpeed.Text), Cursor.Position.Y);
        }

        private void tmrStopSound_Tick(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Resources.switch12);
            player.Play();
            tmrStopSound.Stop();
        }

        private void chkBoxHFree_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBoxHFree.Checked == true)
                {
                    lmSpeak("Hands Free Ready");
                    chkBoxPTT.Checked = false;
                    lblStatus.BackColor = Color.Yellow;
                    lblStatus.Text = "Hands Free Ready";
                    lblStatus.ForeColor = Color.Black;
                    startlistening.RecognizeAsyncCancel();
                    _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                }
                else
                {
                    lmSpeak("LanguaMouse Standing by");
                    _recognizer.RecognizeAsyncCancel();
                    lblStatus.BackColor = Color.Yellow;
                    lblStatus.Text = "LanguaMouse Standing by";
                    lblStatus.ForeColor = Color.Black;
                }
            }
            catch
            { }
        }

        private void chkBoxPTT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkBoxPTT.Checked == true)
                {
                    lmSpeak("PTT Ready");
                    gkh.hook();
                    chkBoxHFree.Checked = false;
                    lblStatus.BackColor = Color.Yellow;
                    lblStatus.Text = "PTT Ready";
                    lblStatus.ForeColor = Color.Black;
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }
                else
                {
                    lmSpeak("LanguaMouse Standing by");
                    _recognizer.RecognizeAsyncCancel(); gkh.unhook();
                    lblStatus.BackColor = Color.Yellow;
                    lblStatus.Text = "LanguaMouse Standing by";
                    lblStatus.ForeColor = Color.Black;
                }
            }
            catch
            { }
        }

        private void chkBoxHighLight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxHighLight.Checked == true)
            {

                if (frm == null)
                    frm = new Form2();
                frm.Show();
                lmSpeak("Highlight enabled");
            }
            else if (chkBoxHighLight.Checked == false)
            {
                frm.Hide();
                lmSpeak("Highlight disabled");
            }
        }

        private void chkBoxStartUp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxStartUp.Checked == true)
            {  if ( Settings.Default.AutoLaunch == false)
                {
                    MessageBox.Show("Languamouse will now start with Windows", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddApplicationToStartup();
                    Settings.Default.AutoLaunch = true;
                    Settings.Default.Save();
                }

                             

            }
            else if (chkBoxStartUp.Checked == false)
            {
                RemoveApplicationFromStartup();
                MessageBox.Show("Languamouse will no longer start with Windows", "System Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Settings.Default.AutoLaunch = true;
                Settings.Default.Save();
            }
        }

        public static void AddApplicationToStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue("Languamouse 2.0", Application.StartupPath + "\\LanguaMouse2.0.exe", RegistryValueKind.String);
                key.Close();
            }
        }

        public static void RemoveApplicationFromStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue("Languamouse 2.0", false);
                key.Close();
            }
        }

        public static void keyDown(byte key)
        {
            keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            //   keybd_event(key, 0, KEY_UP_EVENT, 0);

        }

        public static void keyUp(byte key)
        {
            // keybd_event(key, 0, KEY_DOWN_EVENT, 0);
            keybd_event(key, 0, KEY_UP_EVENT, 0);

        }

        private void txtInput_TextChanged_1(object sender, EventArgs e)
        {
            #region MOUSE COMMANDS

            // Commands to change the text size
            #region Text Sizes

            if (txtInput.Text == "set text to 12")
            {
                if (frm1.Visible == true)
                {
                    frm1.toolStripComboBox1.Text = "12";
                }
            }

            if (txtInput.Text == "set text to 14")
            {
                if (frm1.Visible == true)
                {
                    frm1.toolStripComboBox1.Text = "14";
                }
            }

            if (txtInput.Text == "set text to 16")
            {
                if (frm1.Visible == true)
                {
                    frm1.toolStripComboBox1.Text = "16";
                }
            }

            if (txtInput.Text == "set text to 18")
            {
                if (frm1.Visible == true)
                {
                    frm1.toolStripComboBox1.Text = "18";
                }
            }

            if (txtInput.Text == "set text to 20")
            {
                if (frm1.Visible == true)
                {
                    frm1.toolStripComboBox1.Text = "20";
                }
            }

            if (txtInput.Text == "set text to 22")
            {
                if (frm1.Visible == true)
                {
                    frm1.toolStripComboBox1.Text = "22";
                }
            }

            #endregion

            #region GRID COMMANDS

             if (txtInput.Text == "grid 1")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("1");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 2")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("2");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 3")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("3");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 4")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("4");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 5")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("5");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 6")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("6");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 7")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("7");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 8")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("8");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 9")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("9");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 10")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("10");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 11")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("11");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 12")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("12");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 13")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("13");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 14")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("14");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 15")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("15");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 16")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("16");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 17")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("17");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 18")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("18");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 19")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("19");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 20")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("20");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 21")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("21");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 22")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("22");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 23")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("23");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 24")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("24");
                    mGrid.labelClick(ctrl, e);
                }
            }
            
            if (txtInput.Text == "grid 25")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("25");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 26")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("26");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 27")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("27");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 28")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("28");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 29")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("29");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 30")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("30");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 31")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("31");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 32")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("32");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 33")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("33");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 34")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("34");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 35")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("35");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 36")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("36");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 37")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("37");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 38")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("38");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 39")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("39");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 40")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("40");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 41")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("41");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 42")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("42");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 43")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("43");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 44")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("44");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 45")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("45");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 46")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("46");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 47")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("47");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 48")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("48");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 49")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("49");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 50")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("50");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 51")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("51");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 52")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("52");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 53")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("53");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 54")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("54");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 55")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("55");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 56")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("56");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 57")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("57");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 58")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("58");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 59")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("59");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 60")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("60");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 61")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("61");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 62")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("62");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 63")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("63");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 64")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("64");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 65")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("65");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 66")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("66");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 67")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("67");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 68")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("68");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 69")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("69");
                    mGrid.labelClick(ctrl, e);
                }
            }

             if (txtInput.Text == "grid 70")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("70");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 71")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("71");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 72")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("72");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 73")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("73");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 74")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("74");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 75")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("75");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 76")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("76");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 77")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("77");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 78")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("78");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 79")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("79");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 80")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("80");
                    mGrid.labelClick(ctrl, e);
                }
            }

            if (txtInput.Text == "grid 81")
            {
                txtInput.Text = "";
                if (mGrid.Visible == true)
                {
                    Control ctrl = GetControlByName("81");
                    mGrid.labelClick(ctrl, e);
                }
            }
            
            #endregion

            if (txtInput.Text == "select all text")
            {
                txtInput.Text = "";
                keyDown(17);
                keyDown(65);
                keyUp(17);
                keyUp(65);
            }

            if (txtInput.Text == "press backspace")
            {
                txtInput.Text = "";
                keyDown(8);
                keyUp(8);
            }

            if (txtInput.Text == "press enter")
            {
                txtInput.Text = "";
                keyDown(13);
                keyUp(13);
            }

            if (txtInput.Text == "read the selected text")
            {
                txtInput.Text = "";
            
                    textBox1.Text = Clipboard.GetText();
                    lm.Speak(textBox1.Text.ToString());
                    textBox1.Text = "";
                
             
            }

            if (txtInput.Text == "clear the clipboard")
            {
                txtInput.Text = "";
                Clipboard.Clear();
            }

            if (txtInput.Text == "cancel grid")
            {
                txtInput.Text = "";
                mGrid.DynamicGenerateTable(9, 9);
                mGrid.tableLayoutPanel1.Dock = DockStyle.Fill;
                mGrid.Hide();
            }

            if (txtInput.Text == "show grid")
            {
                txtInput.Text = "";
                mGrid.Show();
            }

            if (txtInput.Text == "mouse scroll down")
            {
                txtInput.Text = "";
                wheelDown();
            }

            if (txtInput.Text == "mouse scroll up")
            {
                txtInput.Text = "";
                wheelUP();
            }
          
            if (txtInput.Text == "turn on highlight")
            {
                txtInput.Text = "";
                chkBoxHighLight.Checked = true;
            }

            if (txtInput.Text == "turn off highlight")
            {
                txtInput.Text = "";
                chkBoxHighLight.Checked = false;
            }

            if (txtInput.Text == "what can i do")
            {
                txtInput.Text = "";
                if (frm1 == null)
                    frm1 = new Form3();
                frm1.Show();
            }

            if (txtInput.Text == "exit what can i do")
            {
                txtInput.Text = "";
                frm1.Hide();
            }

            if (txtInput.Text == "show control panel")
            {
                txtInput.Text = "";
                this.WindowState = FormWindowState.Normal;
            }

            if (txtInput.Text == "hide control panel")
            {
                txtInput.Text = "";
                this.WindowState = FormWindowState.Minimized;
            }

            if (txtInput.Text == "shut down mouse")
            {
                txtInput.Text = "";
                lmSpeak("ok shutting down have a good one.");
                wait(3000);
                _recognizer.RecognizeAsyncCancel();
                Application.Exit();
            }


            if (txtInput.Text == "goto center screen")
            {
                txtInput.Text = "";
                centerScreen();
            }

            if (txtInput.Text == "nudge up")
            {
                txtInput.Text = "";
                lmSpeak("ok.");
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y - Int32.Parse(txtNudgeAmount.Text));
            }

            if (txtInput.Text == "nudge down")
            {
                txtInput.Text = "";
                lmSpeak("ok.");
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y + Int32.Parse(txtNudgeAmount.Text));
            }

            if (txtInput.Text == "nudge right")
            {
                txtInput.Text = "";
                lmSpeak("ok.");
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X + Int32.Parse(txtNudgeAmount.Text), Cursor.Position.Y);
            }

            if (txtInput.Text == "nudge left")
            {
                txtInput.Text = "";
                lmSpeak("ok.");
                Cursor.Position = new System.Drawing.Point(Cursor.Position.X - Int32.Parse(txtNudgeAmount.Text), Cursor.Position.Y);
            }

            if (txtInput.Text == "mouse move left")
            {
                txtInput.Text = "";
                SystemSounds.Beep.Play();
                tmrMouseLeft.Start();
            }


            if (txtInput.Text == "mouse move right")
            {
                txtInput.Text = "";
                SystemSounds.Beep.Play();
                tmrMouseRight.Start();

            }


            if (txtInput.Text == "mouse move up")
            {
                txtInput.Text = "";
                SystemSounds.Beep.Play();
                tmrMouseUP.Start();
            }


            if (txtInput.Text == "mouse move down")
            {
                txtInput.Text = "";
                SystemSounds.Beep.Play();
                tmrMouseDown.Start();
            }


            if (txtInput.Text == "mouse stop")
            {
                lmSpeak("ok");
                txtInput.Text = "";
                tmrMouseDown.Stop();
                tmrMouseLeft.Stop();
                tmrMouseRight.Stop();
                tmrMouseUP.Stop();
                
            }

            if (txtInput.Text == "right click")
            {
                txtInput.Text = "";
                lmSpeak("clicking right mouse button.");
                RightClick();
            }

            if (txtInput.Text == "left click")
            {
                txtInput.Text = "";
                lmSpeak("clicking left mouse button.");
                LeftClick();

            }

            if (txtInput.Text == "double click")
            {
                txtInput.Text = "";
                lmSpeak("double clicking.");
                LeftClick();
                LeftClick();
            }

            if (txtInput.Text == "escape")
            {
                txtInput.Text = "";
                SendKeys.Send("{ESC}");
            }

            if (txtInput.Text == "grab it")
            {
                txtInput.Text = "";
                mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                lmSpeak("ok i have it.");
            }

            if (txtInput.Text == "release it")
            {
                txtInput.Text = "";
                mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                lmSpeak("ok i have let it go.");
            }

            if (txtInput.Text == "stop listening")
            {
                try
                {
                    txtInput.Text = "";
                  
                    lblStatus.BackColor = Color.Yellow;
                    lblStatus.Text = "LanguaMouse Standing by";
                    lblStatus.ForeColor = Color.Black;
                    chkBoxPTT.Checked = false;
                    chkBoxHFree.Checked = false;
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);

                }
                catch
                { }
            }

            if (txtInput.Text == "stand by mouse")
            {
                try
                {
                    txtInput.Text = "";
                    chkBoxPTT.Checked = false;
                    chkBoxHFree.Checked = false;
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch
                { }
            }


            #endregion
        
        }

       



    }
}
