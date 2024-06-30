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
    public partial class ICT : Form
    {
        private readonly UserDataClassDataContext userDataContext;
        private string loggedInUsername;
        public ICT(string username)
        {
            InitializeComponent();

            // Prevent the window from being maximized
            this.MaximizeBox = false;

            // Set the form border style to fixed
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Store the logged-in username
            loggedInUsername = username;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ICT_Load(object sender, EventArgs e)
        {

        }
    }
}
