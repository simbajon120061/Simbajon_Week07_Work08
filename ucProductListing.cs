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
    public partial class ucProductListing : UserControl
    {
        public ucProductListing()
        {
            InitializeComponent();
        }

        private void ucProductListing_Load(object sender, EventArgs e)
        {
            // Setup DataGridView columns if not added in the Designer
            if (dgvItems.Columns.Count == 0)
            {
                dgvItems.Columns.Add("colDescription", "Description");
                dgvItems.Columns.Add("colAmount", "Amount");
                dgvItems.Columns.Add("colUnit", "Unit / Category");
            }

            // Populate ComboBox if empty (adjust items as needed for your activity)
            if (cmbUnit.Items.Count == 0)
            {
                cmbUnit.Items.AddRange(new object[] { "PHP", "USD", "pcs", "box", "kg" });
                cmbUnit.SelectedIndex = 0;
            }

            // Hide or reset the bottom prompt bar initially
            lblPrompt.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string description = txtDescription.Text.Trim();
            string amountText = txtAmount.Text.Trim();
            string unit = cmbUnit.SelectedItem != null ? cmbUnit.SelectedItem.ToString() : "";

            // Validate empty fields
            if (string.IsNullOrEmpty(description) || string.IsNullOrEmpty(amountText) || string.IsNullOrEmpty(unit))
            {
                ShowPrompt("Please fill in Description, Amount, and select an option.", Color.Red);
                return;
            }

            // Validate that Amount is a valid number
            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                ShowPrompt("Please enter a valid positive number for Amount.", Color.Red);
                txtAmount.Focus();
                return;
            }

            // Add row to dgvItems
            dgvItems.Rows.Add(description, amount.ToString("N2"), unit);

            // Clear inputs and show success prompt
            txtDescription.Clear();
            txtAmount.Clear();
            txtDescription.Focus();
            ShowPrompt("Item added successfully!", Color.Green);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItems.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        dgvItems.Rows.Remove(row);
                    }
                }
                ShowPrompt("Selected item deleted.", Color.OrangeRed);
            }
            else if (dgvItems.CurrentRow != null && !dgvItems.CurrentRow.IsNewRow)
            {
                dgvItems.Rows.RemoveAt(dgvItems.CurrentRow.Index);
                ShowPrompt("Item deleted.", Color.OrangeRed);
            }
            else
            {
                ShowPrompt("Please select an item row to delete.", Color.Red);
            }
        }

        // Helper method to update your bottom Prompt bar
        private void ShowPrompt(string message, Color backColor)
        {
            lblPrompt.Text = message;
            lblPrompt.BackColor = backColor;
            lblPrompt.Visible = true;
        }
    }
    }
    
}
