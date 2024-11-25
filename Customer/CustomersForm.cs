using Cafe.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cafe
{
    public partial class CustomersForm : Form
    {
        public CustomersForm()
        {
            InitializeComponent();
        }

        Cafe_DatabaseDataContext db = new Cafe_DatabaseDataContext();


        private void CustomersForm_Load(object sender, EventArgs e)
        {
            GetData();
            BtnEdit.Visible = false;
            BtnDelete.Visible = false;
        }

        private void GetData()
        {
            var cus = db.V_Customers.ToList();
            DgvCustomer.DataSource = cus;

            //Rename columns
            if (DgvCustomer.Columns.Contains("Name"))
            {
                DgvCustomer.Columns["Name"].HeaderText = "Full Name";
            }
            if (DgvCustomer.Columns.Contains("CustomerType"))
            {
                DgvCustomer.Columns["CustomerType"].HeaderText = "Customer Type";
            }
            if (DgvCustomer.Columns.Contains("Cus_Gender"))
            {
                DgvCustomer.Columns["Cus_Gender"].HeaderText = "Gender";
            }

            DgvCustomer.Columns["Gender"].Visible = false;
            DgvCustomer.Columns["id"].Visible = false;
            DgvCustomer.ColumnHeadersHeight = 30;

            // List of column names to hide
            List<string> columnsToHide = new List<string> { "JoinDate", "DeletedAt" };

            foreach (string columnName in columnsToHide)
            {
                if (DgvCustomer.Columns.Contains(columnName))
                {
                    DgvCustomer.Columns[columnName].Visible = false;
                }
            }
        }

        private void BtnUpdateData_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void DgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a row is selected
            if (e.RowIndex >= 0)
            {
                BtnEdit.Visible = true;
                BtnDelete.Visible = true;
            }
            else
            {
                BtnEdit.Visible = false;
                BtnDelete.Visible = false;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (DgvCustomer.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID from the DataGridView
                int selectedCustomerId = Convert.ToInt32(DgvCustomer.SelectedRows[0].Cells["id"].Value);

                // Fetch the customer data from the database
                var customer = db.tblCustomers.FirstOrDefault(c => c.id == selectedCustomerId);

                if (customer != null)
                {
                    // Show the Edit Form, passing the customer object
                    EditCustomerForm editForm = new EditCustomerForm(customer);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the DataGridView after successful edit
                        GetData();
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DgvCustomer.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID from the DataGridView
                int selectedCustomerId = Convert.ToInt32(DgvCustomer.SelectedRows[0].Cells["id"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Find and delete the customer in the database
                    var customerToDelete = db.tblCustomers.FirstOrDefault(c => c.id == selectedCustomerId);
                    if (customerToDelete != null)
                    {
                        db.tblCustomers.DeleteOnSubmit(customerToDelete);
                        db.SubmitChanges();

                        // Refresh the DataGridView after deletion
                        GetData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "តើអ្នកចង់បន្ថែមអតិថិជនថ្មីមែនទេ ? ទាក់ទងមកយើង?",
    "Contact",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Question);
        }
    }


}

