using System;
using System.Windows.Forms;
using InventoryApp.BLL;

namespace InventoryApp
{
    public partial class OrderForm : Form
    {
        private IInventoryRepository _repository;

        public OrderForm(string mode)
        {
            InitializeComponent();
            _repository = RepositoryFactory.GetRepository(mode);
            this.Text = "Place New Order (Mode: " + mode + ")";
        }

        // This event runs automatically when the form opens
        private void OrderForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Setup Customer Dropdown
                cmbCustomer.DataSource = _repository.GetAllCustomers();
                cmbCustomer.DisplayMember = "CustomerName"; // Show the Name
                cmbCustomer.ValueMember = "CustomerID";     // Store the ID

                // 2. Setup Product Dropdown
                cmbProduct.DataSource = _repository.GetAllProducts();
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductID";

                // 3. Setup Warehouse Dropdown
                cmbWarehouse.DataSource = _repository.GetAllWarehouses();
                cmbWarehouse.DisplayMember = "WarehouseName";
                cmbWarehouse.ValueMember = "WarehouseID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lists: " + ex.Message);
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Validation
            if (cmbCustomer.SelectedIndex == -1 || cmbProduct.SelectedIndex == -1 || cmbWarehouse.SelectedIndex == -1)
            {
                MessageBox.Show("Please select all fields.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.");
                return;
            }

            // Get the hidden IDs from the dropdowns
            int custId = (int)cmbCustomer.SelectedValue;
            int prodId = (int)cmbProduct.SelectedValue;
            int warehouseId = (int)cmbWarehouse.SelectedValue;

            try
            {
                // Call the logic
                string result = _repository.PlaceOrder(custId, prodId, warehouseId, qty);
                MessageBox.Show(result);

                if (result.StartsWith("Success"))
                {
                    // --- DEMONSTRATION OF SCALAR FUNCTION ---
                    // We fetch the calculated total value of this new order to prove the UDF works.
                    // Note: In a real app, we'd need the new OrderID. 
                    // Since our PlaceOrder returns a string, we'll just show a generic success 
                    // OR we can demonstrate the Stock Level function instead which is easier here.

                    int stockLeft = _repository.GetStockLevel(prodId, warehouseId);

                    MessageBox.Show(result + "\n\n(Remaining Stock verified via SQL Function: " + stockLeft + ")");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Order Failed: " + ex.Message);
            }
        }
    }
}