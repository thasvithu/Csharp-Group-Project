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
    public partial class LoginForm : Form
    {
        private readonly UserDataClassDataContext userDataContext;
        public string loggedInUsername;
        public LoginForm()
        {
            InitializeComponent();

            // Prevent the window from being maximized
            this.MaximizeBox = false;

            // Set the form border style to fixed
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Initialize the LINQ to SQL DataContext
            userDataContext = new UserDataClassDataContext();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Query to check if username and password match in database
            var query = from user in userDataContext.Users
                        where user.Username == username && user.Password == password
                        select user;

            // Execute the query
            User matchedUser = query.FirstOrDefault();

            if (matchedUser != null)
            {
                MessageBox.Show("Login Successful!");
                this.Hide();// Hide the login form

                loggedInUsername = matchedUser.Username;

   

                Home home_1 = new Home(loggedInUsername);
                home_1.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect.");
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
