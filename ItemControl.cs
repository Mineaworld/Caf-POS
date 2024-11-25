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
    public partial class ItemControl : UserControl
    {

        // Declare the AddToCartClicked event
        public event EventHandler AddToCartClicked;

        // Folder path where images are stored
        private string imageFolderPath = @"D:\Programming\SETEC\C#\Y2S2\Assets\Cafe\Products";

        public ItemControl()
        {
            InitializeComponent();

        }


        // Properties to bind the product details
        private string item;
        public string Item
        {
            get { return item; }
            set
            {
                item = value;
                lblItemName.Text = item; // Bind the value to the label in the control
            }
        }

        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                lblItemPrice.Text = price; // Bind the value to the label in the control
            }
        }

        // Image file name property (from the database)
        private string itemImageFileName;
        public string ItemImageFileName
        {
            get { return itemImageFileName; }
            set
            {
                itemImageFileName = value;
                LoadImageFromFolder(itemImageFileName); // Load image from folder
            }
        }
        // Method to load image from the folder
        private void LoadImageFromFolder(string imageName)
        {
            string fullImagePath = Path.Combine(imageFolderPath, imageName);

            // Debugging: Check if the image path is correct
            Console.WriteLine($"Full image path: {fullImagePath}");

            if (File.Exists(fullImagePath))
            {
                ProductImg.Image = Image.FromFile(fullImagePath); // Load the image from the folder
                Console.WriteLine("Image loaded successfully.");
            }
            else
            {
                // Optionally, set a default image if the file doesn't exist
                ProductImg.Image = null;
                Console.WriteLine("Image not found.");
            }
        }


        private void BtnAddcart_Click(object sender, EventArgs e)
        {
            OnAddToCartClicked(EventArgs.Empty);

        }
        protected virtual void OnAddToCartClicked(EventArgs e)
        {
            AddToCartClicked?.Invoke(this, e);
        }



        private void BtnDecrease_Click(object sender, EventArgs e)
        {
            DecreaseProductQuantityInPOSForm(Item);
        }
        private void DecreaseProductQuantityInPOSForm(string productName)
        {
            // Find the parent form (POSForm)
            POSForm posForm = this.ParentForm as POSForm;

            if (posForm != null)
            {
                // Call the method in POSForm to decrease the product quantity
                posForm.DecreaseProductQuantity(productName);
            }
        }


    }
}
