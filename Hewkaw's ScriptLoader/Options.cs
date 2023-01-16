using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace Hewkaw_s_ScriptLoader
{
    public partial class Options : Form
    {
        ExploitAPI module = new ExploitAPI();
        public Options()
        {
            InitializeComponent();
        }
        Point lastPoint;

        private void Options_Load(object sender, EventArgs e)
        {

        }

        private void btn_killroblox(object sender, EventArgs e)
        {
            Process[] roblox = Process.GetProcesses();
            foreach (Process openedroblox in roblox)
            {
                bool flag = openedroblox.ProcessName == "RobloxPlayerBeta";
                if (flag)
                {
                    openedroblox.Kill();
                }
            }
        }

        private void btn_afk(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Script = wb.DownloadString("https://pastebin.com/raw/pQF6rXMm");
            module.LaunchExploit();
            module.SendLuaScript(Script);
        }

        private void btn_forcereset(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Script = wb.DownloadString("https://pastebin.com/raw/SiqScdtW");
            module.LaunchExploit();
            module.SendLuaScript(Script);

        }

        private void btn_update(object sender, EventArgs e)
        {

        }

        private void btn_minimized(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Point_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Point_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
