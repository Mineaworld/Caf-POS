using Cafe.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class EditCustomerForm : Form
    {
        private tblCustomer _customer;
        Cafe_DatabaseDataContext db = new Cafe_DatabaseDataContext();


        public EditCustomerForm(tblCustomer customer)
        {
            InitializeComponent();
            _customer = customer;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            if (_customer != null)
            {
                txtName.Text = _customer.Name;
                // Assuming dropdownGender and dropdownCustomerType are ComboBoxes
                dropdownGender.SelectedItem = _customer.Gender;
                txtPhone.Text = _customer.Phone;
                dropdownCustomerType.SelectedItem = _customer.CustomerType;
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            // Update the customer properties
            _customer.Name = txtName.Text;
            _customer.Gender = int.Parse(dropdownGender.SelectedItem.ToString());
            _customer.Phone = txtPhone.Text;
            _customer.CustomerType = dropdownCustomerType.SelectedItem.ToString();

            // Update the customer in the database
            Cafe_DatabaseDataContext db = new Cafe_DatabaseDataContext();
            db.SubmitChanges();

            // Close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
