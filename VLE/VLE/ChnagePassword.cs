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
    public partial class ChnagePassword : Form
    {
        private readonly UserDataClassDataContext userDataContext;
        private string loggedInUsername;

        public ChnagePassword(string username)
        {
            InitializeComponent();

            // Prevent the window from being maximized
            this.MaximizeBox = false;

            // Set the form border style to fixed
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Store the logged-in username
            loggedInUsername = username;
        }

        private void ChnagePassword_Load(object sender, EventArgs e)
        {
            using (UserDataClassDataContext userDataContext = new UserDataClassDataContext())
            {
                // Query to retrieve user details based on username
                var query = from user in userDataContext.Users
                            where user.Username == loggedInUsername
                            select user;

                // Execute the query
                User currentUser = query.FirstOrDefault();

                if (currentUser != null)
                {
                    lblUserName.Text = currentUser.Username;
                    lblFullname.Text = currentUser.FullName;
                }
            }
        }

        private void lblUserName_dis_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_new_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string currentPassword = txtPassword_new.Text;
            string newPassword = txtConfirmPassword.Text;

            if (newPassword == currentPassword)
            {
                using (UserDataClassDataContext userDataContext = new UserDataClassDataContext())
                {
                    // Query to retrieve user based on username
                    var query = from user in userDataContext.Users
                                where user.Username == loggedInUsername
                                select user;

                    // Execute the query
                    User currentUser = query.FirstOrDefault();

                    if (currentUser != null)
                    {
                        // Update the user's password
                        currentUser.Password = newPassword;
                        userDataContext.SubmitChanges();

                        MessageBox.Show("Password changed successfully.");
                        this.Close(); // Close the Change Password form
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Pass_Click(object sender, EventArgs e)
        {

        }
    }
}
