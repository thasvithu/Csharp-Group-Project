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
    public partial class SignUp : Form
    {
        private readonly UserDataClassDataContext userDataContext;
        private string loggedInUsername;
        public SignUp()
        {
            InitializeComponent();

            // Prevent the window from being maximized
            this.MaximizeBox = false;

            // Set the form border style to fixed
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            userDataContext = new UserDataClassDataContext();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string country = txtCountry.Text;
            string city = txtCity.Text;

            // Create a new user object
            User newUser = new User
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Email = email,
                Country = country,
                City = city
            };

            // Add the user to the Users table
            userDataContext.Users.InsertOnSubmit(newUser);


            try
            {
                // Submit changes to the database
                userDataContext.SubmitChanges();
                MessageBox.Show("Account Created successfully!");
                // Redirect to login form or main application
                // e.g., this.Hide(); new LoginForm().Show();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtCountry.Text = "";
                txtCity.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
