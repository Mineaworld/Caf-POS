using Cafe.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Cafe
{
    public partial class POSForm : Form
    {
        public POSForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        Cafe_DatabaseDataContext db = new Cafe_DatabaseDataContext();

        private void POSForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            flowLayoutPanelProducts.AutoScroll = true;

            // Remove the first row if it exists and is not a new row
            if (DgvCheckout.Rows.Count > 0 && !DgvCheckout.Rows[0].IsNewRow)
            {
                DgvCheckout.Rows.RemoveAt(0);
            }
            if (DgvCheckout == null)
            {
                MessageBox.Show("DgvCheckout is not initialized!");
            }
        }
        private void InitializeDataGridView()
        {
            // Clear existing columns if necessary
            DgvCheckout.Columns.Clear();

            // Define and add columns
            DgvCheckout.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemName",
                HeaderText = "Item"
            });
            DgvCheckout.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Qty",
                HeaderText = "Quantity"
            });
            DgvCheckout.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                HeaderText = "Price"
            });
            DgvCheckout.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Total"
            });

            // Currency format
            DgvCheckout.Columns["Price"].DefaultCellStyle.Format = "c";
            DgvCheckout.Columns["Total"].DefaultCellStyle.Format = "c";

            // Optionally set column widths
            DgvCheckout.Columns["ItemName"].Width = 150;
            DgvCheckout.Columns["Qty"].Width = 60;
            DgvCheckout.Columns["Price"].Width = 80;
            DgvCheckout.Columns["Total"].Width = 80;

            //set font datagridview
            var kantumruyFont = new Font("Kantumruy Pro", 10, FontStyle.Bold);
            DgvCheckout.ColumnHeadersDefaultCellStyle.Font = kantumruyFont; // Font for header
            DgvCheckout.DefaultCellStyle.Font = kantumruyFont; // Font for rows

            // Handle the CellClick event to detect button clicks
            DgvCheckout.CellClick += DgvCheckout_CellClick;



            var removeButton = new DataGridViewButtonColumn();
            removeButton.Name = "Remove";
            removeButton.HeaderText = "Action";
            removeButton.Text = "Remove";
            removeButton.UseColumnTextForButtonValue = true;
            DgvCheckout.Columns.Add(removeButton);
        }

        private void AddProductToCart(string productName, decimal price)
        {
            // Add a new row with the product data if it is valid
            if (!string.IsNullOrWhiteSpace(productName) && price > 0)
            {
                int index = DgvCheckout.Rows.Add();
                DgvCheckout.Rows[index].Cells["ItemName"].Value = productName;
                DgvCheckout.Rows[index].Cells["Qty"].Value = 1; // Default quantity is 1
                DgvCheckout.Rows[index].Cells["Price"].Value = price; // Price of the product
                DgvCheckout.Rows[index].Cells["Total"].Value = price; // Initially Total is same as Price

            }
        }


        private void DgvCheckout_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure column index is valid and row index is valid
            if (e.RowIndex >= 0 && e.ColumnIndex == DgvCheckout.Columns["Remove"].Index)
            {
                // Get product name from the selected row
                string productName = DgvCheckout.Rows[e.RowIndex].Cells["ItemName"].Value?.ToString();

                if (!string.IsNullOrWhiteSpace(productName))
                {
                    // Remove the selected row from DataGridView
                    DgvCheckout.Rows.RemoveAt(e.RowIndex);

                    // Remove the corresponding row from the database (where SaleID = -2 and ProductID matches)
                    var saleDetail = db.tblSaleDetails.FirstOrDefault(s => s.ProductID == GetProductID(productName) && s.SaleID == -2);
                    if (saleDetail != null)
                    {
                        db.tblSaleDetails.DeleteOnSubmit(saleDetail);
                        db.SubmitChanges();
                    }

                    // Update the grand total after removing the row
                    UpdateGrandTotal();
                }
            }
        }




        //Decrease product qty
        public void DecreaseProductQuantity(string productName)
        {
            // Check if there are no rows in the DataGridView
            if (DgvCheckout.Rows.Count == 0)
            {
                MessageBox.Show("No products in the cart to decrease quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Exit the method early
            }

            // Find the row in the DataGridView (DgvCheckout) that matches the product name
            foreach (DataGridViewRow row in DgvCheckout.Rows)
            {
                // Check if the row is not a new row and has valid cells
                if (!row.IsNewRow && row.Cells["ItemName"].Value != null)
                {
                    // Check for the matching product name
                    if (row.Cells["ItemName"].Value.ToString() == productName)
                    {
                        int currentQty = Convert.ToInt32(row.Cells["Qty"].Value);

                        if (currentQty > 1)
                        {
                            // Decrease the quantity
                            row.Cells["Qty"].Value = currentQty - 1;

                            // Recalculate the total
                            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                            row.Cells["Total"].Value = price * (currentQty - 1);
                        }
                        else
                        {
                            // If the quantity is 1, remove the item from the cart
                            DgvCheckout.Rows.Remove(row);
                        }

                        // Break out of the loop since we've found and updated the item
                        break;
                    }
                }
            }

            // Optionally, you can update the grand total after adjusting the quantity
            UpdateGrandTotal();
        }


        //Load Product

        private void LoadProducts()
        {
            // Query to get all active products
            var products = db.tblProducts.Where(p => p.IsActive == true).ToList();

            // Pass the products to a helper method for populating the controls
            PopulateProducts(products);
        }

        // Method to load products by category
        private void LoadProducts(int categoryId)
        {
            // Query to get active products filtered by category
            var products = (from p in db.tblProducts
                            join c in db.tblCategories on p.CategoryID equals c.CategoryID
                            where p.IsActive == true && c.CategoryID == categoryId
                            select p).ToList();

            // Pass the products to a helper method for populating the controls
            PopulateProducts(products);
        }

        // Update the method to accept List<tblProduct> instead of List<Product>
        private void PopulateProducts(List<tblProduct> products)
        {
            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanelProducts.Controls.Clear();

            // Loop through each product and add it to the FlowLayoutPanel
            foreach (var item in products)
            {
                // Create a new instance of the custom control (ItemControl)
                var productControl = new ItemControl();

                // Set the properties of the control with the product data
                productControl.Item = item.Name;  // Set the item name
                productControl.Price = "$ " + item.Price; // Format the price as currency

                // Set the image file name from the database
                productControl.ItemImageFileName = item.Image; // Assuming `Image` is the file name, e.g., "latte.png"

                // Subscribe to the AddToCartClicked event
                productControl.AddToCartClicked += ProductControl_AddToCartClicked;

                // Add the control to the FlowLayoutPanel
                flowLayoutPanelProducts.Controls.Add(productControl);
            }
        }






        private void BtnCoffee_Click(object sender, EventArgs e)
        {

            LoadProducts(1);
        }

        private void BtnAllmenu_Click(object sender, EventArgs e)
        {

            LoadProducts();
        }

        private void ProductControl_AddToCartClicked(object sender, EventArgs e)
        {
            var productControl = sender as ItemControl;
            if (productControl != null)
            {
                AddProductToCart(productControl.Item, productControl.Price);
            }
        }


        private void AddProductToCart(string productName, string productPrice)
        {
            if (string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(productPrice))
            {
                MessageBox.Show("Product name or price is missing.");
                return;
            }

            productPrice = productPrice.Replace("$", "").Trim();
            if (!decimal.TryParse(productPrice, out decimal price))
            {
                MessageBox.Show("Invalid price format. Please ensure the price is a numeric value.");
                return;
            }

            foreach (DataGridViewRow row in DgvCheckout.Rows)
            {
                if (row.Cells["ItemName"].Value?.ToString() == productName)
                {
                    // Update existing row
                    if (int.TryParse(row.Cells["Qty"].Value?.ToString(), out int qty))
                    {
                        row.Cells["Qty"].Value = qty + 1;
                        UpdateRowTotal(row);
                        UpdateGrandTotal();

                        // Update quantity in the database
                        var saleDetail = db.tblSaleDetails.FirstOrDefault(s => s.ProductID == GetProductID(productName) && s.SaleID == -2);
                        if (saleDetail != null)
                        {
                            saleDetail.Qty += 1;
                            db.SubmitChanges();
                        }
                        return;
                    }
                }
            }

            // Add new row if product not found
            int index = DgvCheckout.Rows.Add();
            DgvCheckout.Rows[index].Cells["ItemName"].Value = productName;
            DgvCheckout.Rows[index].Cells["Qty"].Value = 1;
            DgvCheckout.Rows[index].Cells["Price"].Value = price;
            UpdateRowTotal(DgvCheckout.Rows[index]);

            // Add to database
            tblSaleDetail newSaleDetail = new tblSaleDetail
            {
                ProductID = GetProductID(productName),
                Qty = 1,
                SaleID = -2,  // Assign SaleID = -2
                Status = "temp"  // Assign Status = "temp"
            };

            db.tblSaleDetails.InsertOnSubmit(newSaleDetail);
            db.SubmitChanges();

            UpdateGrandTotal();
        }



        private void UpdateRowTotal(DataGridViewRow row)
        {
            // Recalculate the total for the current row
            if (decimal.TryParse(row.Cells["Price"].Value?.ToString(), out decimal price) &&
                int.TryParse(row.Cells["Qty"].Value?.ToString(), out int qty))
            {
                row.Cells["Total"].Value = price * qty; // Update the total cell
            }
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;

            // Calculate the grand total by summing all row totals
            foreach (DataGridViewRow row in DgvCheckout.Rows)
            {
                if (row.Cells["Total"].Value != null && decimal.TryParse(row.Cells["Total"].Value.ToString(), out decimal rowTotal))
                {
                    grandTotal += rowTotal;
                }
            }
            lblGrandTotal.Visible = true;
            lblGrandTotal.Text = "$ " + grandTotal.ToString("F2"); // Update the grand total label
        }

        private int GetProductID(string productName)
        {
            // Helper function to get the ProductID from the database using the product name
            var product = db.tblProducts.FirstOrDefault(p => p.Name == productName);
            return product != null ? (int)product.ID : 0;
        }
        private int GetCurrentSaleID()
        {
            // Implement this method to return the current SaleID based on your application logic
            // This is a placeholder implementation
            return 1; // Replace with actual logic to get the current SaleID
        }

        public long AutoID()
        {
            string id = DateTime.Now.ToString("yyyyMMddHHmmssff");
            return long.Parse(id);
        }
        public string AutoInvoive()
        {
            int i = 0;
            int CheckSaleID = db.tblSales.Count();
            if (CheckSaleID == 0)
            {
                i = 1;
            }
            else
            {
                string lastInvoice = db.tblSales
                    .OrderByDescending(X => X.Print_Date)
                    .FirstOrDefault().Inv_No;
                i = int.Parse(lastInvoice);
                i++;
            }
            return i.ToString("000000");
        }


        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (DgvCheckout != null && DgvCheckout.Rows.Count > 0)
            {
                InvoiceNo = AutoInvoive();

                long r_id = AutoID();
                tblSale s = new tblSale();
                long sid = r_id;
                s.id = sid;
                s.Inv_No = InvoiceNo;
                s.Print_Date = DateTime.Now;
                s.CusID = int.Parse("-1");
                db.tblSales.InsertOnSubmit(s);

                db.Checkout(r_id);
                db.SubmitChanges();

                DgvCheckout.Rows.Clear();

                PrintReceipt(InvoiceNo);
            }
            else { MessageBox.Show("Please add at least 1 product to a cart !"); }
        }

        private void BtnAllmenu_Click_1(object sender, EventArgs e)
        {

        }


        // Printing


        private System.Drawing.Image imageToPrint;
        private string InvoiceNo;

        public void PrintReceipt(string incNo)
        {
            InvoiceNo = incNo;

            using (PrintDialog printDlg = new PrintDialog())
            {
                PrintDocument printDoc = new PrintDocument
                {
                    DocumentName = "Receipt"
                };

                imageToPrint = Properties.Resources.javakup;
                printDoc.PrintPage += PrintPage;
                printDlg.Document = printDoc;
                printDlg.AllowSelection = false;
                printDlg.AllowSomePages = false;

                try
                {
                    if (printDlg.ShowDialog() == DialogResult.OK)
                    {
                        printDoc.Print();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while printing: {ex.Message}", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define fonts and layout settings
            Font fontNormal = new Font("Arial", 10, FontStyle.Regular);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);
            Font fontKhmer = new Font("Kantumruy Pro", 10, FontStyle.Bold);

            // Margins
            float marginLeft = e.MarginBounds.Left;
            float marginTop = e.MarginBounds.Top;

            // Draw image at the top with better positioning
            if (imageToPrint != null)
            {
                e.Graphics.DrawImage(imageToPrint, marginLeft, marginTop, 120, 100); // Logo size
            }

            // Move y position down for the address
            float y = marginTop + 120; // Space for logo
            string header = "Invoice : " + InvoiceNo;
            string address = "St. 615, Toul Touk, Phnom Penh";
            string phone = "Tell: 096 500 6463";
            string date = $"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

            // Draw header and details
            e.Graphics.DrawString(header, fontBold, Brushes.Black, marginLeft, y);
            y += 22; // Spacing
            e.Graphics.DrawString(address, fontNormal, Brushes.Black, marginLeft, y);
            y += 22;
            e.Graphics.DrawString(phone, fontNormal, Brushes.Black, marginLeft, y);
            y += 30; // Spacing before items

            // Draw table headers
            e.Graphics.DrawLine(Pens.Black, marginLeft, y, marginLeft + 300, y);
            y += 5; // Space above headers
            e.Graphics.DrawString("Item", fontBold, Brushes.Black, marginLeft, y);
            e.Graphics.DrawString("Qty", fontBold, Brushes.Black, marginLeft + 120, y);
            e.Graphics.DrawString("Price", fontBold, Brushes.Black, marginLeft + 180, y);
            e.Graphics.DrawString("Total", fontBold, Brushes.Black, marginLeft + 240, y);
            y += 25;
            e.Graphics.DrawLine(Pens.Black, marginLeft, y, marginLeft + 300, y);
            y += 20; // Space before items

            // Fetch print data
            var printData = db.V_PrintReceipts.ToList();
            if (printData == null || !printData.Any())
            {
                e.Graphics.DrawString("No products found!", fontNormal, Brushes.Red, marginLeft, y);
                return;
            }

            double grandTotal = 0;

            // Draw items
            foreach (var item in printData)
            {
                double price = item.Price;
                double total = item.Total ?? 0;
                grandTotal += total;

                e.Graphics.DrawString(item.Name, fontNormal, Brushes.Black, marginLeft, y);
                e.Graphics.DrawString(item.Qty.ToString(), fontNormal, Brushes.Black, marginLeft + 120, y);
                e.Graphics.DrawString(price.ToString("C2"), fontNormal, Brushes.Black, marginLeft + 180, y); // Format price
                e.Graphics.DrawString(total.ToString("C2"), fontNormal, Brushes.Black, marginLeft + 240, y); // Format total
                y += 20; // Space for next item
            }

            // Draw grand total section
            y += 10; // Space before grand total
            e.Graphics.DrawLine(Pens.Black, marginLeft, y, marginLeft + 300, y); // Separator
            y += 5; // Space above grand total
            e.Graphics.DrawString("Grand Total : ", fontBold, Brushes.Black, marginLeft + 150, y);
            e.Graphics.DrawString(grandTotal.ToString("C2"), fontBold, Brushes.Black, marginLeft + 240, y); // Format grand total
            y += 25;
            e.Graphics.DrawLine(Pens.Black, marginLeft, y, marginLeft + 300, y);


            // Add footer message
            y += 30; // Space before footer
            e.Graphics.DrawString("Thank you for your purchase!", fontNormal, Brushes.Black, marginLeft + 50, y);
            y += 15;
            e.Graphics.DrawString("សូមអរគុណសម្រាប់ការទិញរបស់លោកអ្នក!", fontKhmer, Brushes.Black, marginLeft + 30, y);

        }





        private void POSSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchKeyword = POSSearch.Text.Trim();
            }
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            Cafe frm = new Cafe();
            frm.Show();
            this.Hide();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void CateFood_Click(object sender, EventArgs e)
        {
            LoadProducts(2);
        }

        private void CateSmoothie_Click(object sender, EventArgs e)
        {
            LoadProducts(3);
        }

        private void CateKhDrink_Click(object sender, EventArgs e)
        {
            LoadProducts(6);
        }

        private void Catejuice_Click(object sender, EventArgs e)
        {
            LoadProducts(4);
        }
    }


}

