namespace MultiRBX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool exists;
            new Mutex(true, "ROBLOX_singletonMutex", out exists);
            if (!exists)
            {
                MessageBox.Show("Please run the application before opening Roblox or there is an already running MultiRBX instance.");
                Application.Exit();
            }
            Opacity = 0;
            ShowInTaskbar = false;
            TopLevel = false;
        }

        protected void Displaynotify()
        {
            try
            {
                notifyIcon1.Icon = Resource1.icon;
                notifyIcon1.Text = "MultiRBX";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "MultiRBX has started.";
                notifyIcon1.BalloonTipText = " ";
                notifyIcon1.ShowBalloonTip(100);
                notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
                notifyIcon1.ContextMenuStrip.Items.Add("Exit", null, MenuExit_Click);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Displaynotify();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}