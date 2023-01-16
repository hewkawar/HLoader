using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace Hewkaw_s_ScriptLoader
{
    public partial class Form1 : Form
    {
        ExploitAPI module = new ExploitAPI();
        public Form1()
        {
            InitializeComponent();
        }
        Point lastPoint;

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

        private void btn_injecter(object sender, EventArgs e)
        {
            module.LaunchExploit();
        }

        private void btn_execute(object sender, EventArgs e)
        {
            module.SendLuaScript(fastColoredTextBox1.Text);
        }

        private void btn_openfile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void btn_savefile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            { 
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.WriteLine(fastColoredTextBox1.Text);
                }
            }
        }

        private void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = File.ReadAllText($"./script/{listBox1.SelectedItem}");
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./script", "*.txt");
            Functions.PopulateListBox(listBox1, "./script", "*.lua");
        }

        private void btn_minimized(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btn_exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_clear(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void btn_paste(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = Clipboard.GetText();
        }

        private void btn_refresh(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Functions.PopulateListBox(listBox1, "./script", "*.txt");
            Functions.PopulateListBox(listBox1, "./script", "*.lua");
        }

        private void btn_options(object sender, EventArgs e)
        {
            Options openform = new Options();
            openform.Show();
        }

        private void btn_scripthub(object sender, EventArgs e)
        {
            ScriptHub openform = new ScriptHub();
            openform.Show();
        }
    }
}
