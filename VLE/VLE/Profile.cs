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
    public partial class Profile : Form
    {
        private string loggedInUsername;
        public Profile(string username)
        {
            InitializeComponent();

            // Prevent the window from being maximized
            this.MaximizeBox = false;

            // Set the form border style to fixed
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Set the loggedInUsername from the constructor parameter
            loggedInUsername = username;
        }

        private void Profile_Load(object sender, EventArgs e)
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
                    // Populate labels with user details
                    lblUsername.Text = currentUser.Username;
                    lblFullname.Text = currentUser.FullName;
                    lblEmail.Text = currentUser.Email;
                    lblCountry.Text = currentUser.Country;
                    lblCity.Text = currentUser.City;
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChnagePassword changePassword = new ChnagePassword(loggedInUsername);
            changePassword.Show();
        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblCountry_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblCity_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblFullname_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Prompt user for confirmation
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete your account?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
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
                        // Delete the user
                        userDataContext.Users.DeleteOnSubmit(currentUser);
                        userDataContext.SubmitChanges();

                        MessageBox.Show("Account deleted successfully.");
                        this.Close(); // Close the Profile form

                        // Optionally, log the user out or redirect to login form
                        // For example:
                        Application.Exit(); // Close the entire application
                        // new LoginForm().Show(); // Show login form
                    }
                    else
                    {
                        MessageBox.Show("User not found.");
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
