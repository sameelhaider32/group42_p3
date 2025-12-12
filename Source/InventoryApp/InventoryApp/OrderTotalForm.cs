using System;
using System.Windows.Forms;
using InventoryApp.BLL;

namespace InventoryApp
{
    public partial class OrderTotalForm : Form
    {
        private readonly IInventoryRepository _repository;

        public OrderTotalForm(string mode)
        {
            InitializeComponent();

            if (mode == "LINQ")
                _repository = new InventoryRepositoryLINQ();
            else
                _repository = new InventoryRepositorySP();

            this.Text = "Check Order Total (" + mode + ")";
        }

        private void btnCheckTotal_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOrderId.Text.Trim(), out int orderId))
            {
                MessageBox.Show("Please enter a valid numeric Order ID.");
                return;
            }

            try
            {
                decimal total = _repository.GetTotalOrderValue(orderId);
                MessageBox.Show("Total value for order " + orderId + " is: " + total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking order total: " + ex.Message);
            }
        }
    }
}

