using System;
using System.Windows.Forms;
using InventoryApp.BLL;

namespace InventoryApp
{
    public partial class ProductForm : Form
    {
        private IInventoryRepository _repository;

        // Modified Constructor: Accepts the "Mode" (LINQ or SP)
        public ProductForm(string mode)
        {
            InitializeComponent();

            // Use the Factory to get the correct brain immediately
            _repository = RepositoryFactory.GetRepository(mode);

            this.Text = "Add Product (Mode: " + mode + ")";
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(txtSKU.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("SKU and Name are required.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Price must be a valid number.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Stock must be a valid positive integer.");
                return;
            }

            // 2. Call the Repository with the new Stock parameter
            try
            {
                string result = _repository.AddNewProduct(
                    txtSKU.Text.Trim(),
                    txtName.Text.Trim(),
                    price,
                    txtDesc.Text.Trim(),
                    stock // <-- Passing the stock here
                );

                MessageBox.Show(result);

                if (result.StartsWith("Success"))
                {
                    txtSKU.Clear();
                    txtName.Clear();
                    txtPrice.Clear();
                    txtDesc.Clear();
                    txtStock.Clear(); // Clear the stock field too
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}