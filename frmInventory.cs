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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // Load ucHome automatically when frmInventory opens
        private void frmInventory_Load(object sender, EventArgs e)
        {
            LoadUserControl(new ucHome());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucHome());
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucProductListing());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out / exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Close();
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Inventory Management System", "About Us", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information
                );
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}
