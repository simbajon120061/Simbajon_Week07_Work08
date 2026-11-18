using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simbajon_WEEK06_WORK08
{
    public partial class frmLogin : Form
    {

        public static List<Users> Users = new List<Users>()
        {
            new Users { FullName = "Administrator", Email = "admin@example.com", Username = "admin", Password = "1234" }
        };
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Users matchedUser = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (matchedUser != null)
            {
                MessageBox.Show($"Welcome, {matchedUser.FullName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmInventory inventory = new frmInventory();
                inventory.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            frmSignup signup = new frmSignup();
            signup.Show();
            this.Hide();
        }
    }
}
