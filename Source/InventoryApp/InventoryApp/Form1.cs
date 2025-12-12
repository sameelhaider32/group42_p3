using System;
using System.Windows.Forms;
using InventoryApp.BLL; // Import our Logic Layer

namespace InventoryApp
{
    public partial class Form1 : Form
    {
        
        private IInventoryRepository _repository;

        public Form1()
        {
            InitializeComponent();
        }

        // Helper Method: Updates the _repository variable based on the Radio Button
        private void RefreshRepository()
        {
            if (rbLINQ.Checked)
            {
                _repository = RepositoryFactory.GetRepository("LINQ");
                this.Text = "Inventory Dashboard (Mode: LINQ)";
            }
            else
            {
                _repository = RepositoryFactory.GetRepository("SP");
                this.Text = "Inventory Dashboard (Mode: Stored Procedures)";
            }
        }

        // Button 1: Load Sales Summary (Uses the View)
        private void btnLoadSales_Click(object sender, EventArgs e)
        {
            RefreshRepository(); // Always check which mode is selected first
            try
            {
                var data = _repository.GetProductSalesSummary();
                dgvReport.DataSource = data;
                MessageBox.Show("Report loaded successfully using " + (rbLINQ.Checked ? "LINQ" : "Stored Procedures"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message);
            }
        }

        // Button 2: Load Top Customers (Uses the CTE)
        private void btnLoadTopCustomers_Click(object sender, EventArgs e)
        {
            RefreshRepository();
            try
            {
                var data = _repository.GetTopCustomersReport();
                dgvReport.DataSource = data;
                MessageBox.Show("CTE Report Loaded via " + (rbLINQ.Checked ? "LINQ" : "SP"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Button 3: Open Order Form
        private void btnOpenOrderForm_Click(object sender, EventArgs e)
        {
            string mode = rbLINQ.Checked ? "LINQ" : "SP";
            OrderForm orderForm = new OrderForm(mode);
            orderForm.ShowDialog();
        }

        // Button 4: Open Product Form
        private void btnOpenProductForm_Click(object sender, EventArgs e)
        {
            // determine which mode is currently selected
            string mode = rbLINQ.Checked ? "LINQ" : "SP";

            // Create the ProductForm and pass the mode to it
            ProductForm productForm = new ProductForm(mode);
            productForm.ShowDialog(); // ShowDialog locks the main window until this one closes
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShowOrderDetails_Click(object sender, EventArgs e)
        {
            RefreshRepository();
            try
            {
                var data = _repository.GetOrderDetails();
                dgvReport.DataSource = data;
                MessageBox.Show("Order details loaded using " + (rbLINQ.Checked ? "LINQ" : "Stored Procedures"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message);
            }
        }

        private void btnCheckOrderTotal_Click(object sender, EventArgs e)
        {
            

            string mode = rbLINQ.Checked ? "LINQ" : "SP";
            OrderTotalForm f = new OrderTotalForm(mode);
            f.ShowDialog();
        }

        
    }
}