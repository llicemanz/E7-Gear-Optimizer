using System;
using System.Windows.Forms;

namespace E7_Gear_Optimizer
{
    public partial class Updated : Form
    {
        public Updated()
        {
            InitializeComponent();
        }

        private void Updated_Shown(object sender, EventArgs e)
        {
            label1.Text = "Application was updated from " + Util.ver.Substring(0, Util.ver.Length - 2) + "  to " + Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2) + "!";
            linkLabel1.Text = Util.GitHubUrl;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Util.GitHubUrl);
        }
    }
}
