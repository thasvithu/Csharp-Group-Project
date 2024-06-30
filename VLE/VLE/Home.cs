using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLE
{
    public partial class Home : Form
    {
        private string loggedInUsername;

        public Home(string username)
        {
            InitializeComponent();

            // Prevent the window from being maximized
            this.MaximizeBox = false;

            // Set the form border style to fixed
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            loggedInUsername = username; // Store the logged-in username
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(loggedInUsername);
            profile.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ICT iCT = new ICT(loggedInUsername);
            iCT.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
