using System;
using System.Collections.Generic;
using System.Data; 

namespace InventoryApp.BLL
{
    
    public interface IInventoryRepository
    {
        // --- Product Management ---
        List<Product> GetAllProducts();
        string AddNewProduct(string sku, string name, decimal price, string description, int stock);
        // --- Order Processing ---
        List<Customer> GetAllCustomers();
        List<Warehouse> GetAllWarehouses();
        string PlaceOrder(int customerId, int productId, int warehouseId, int quantity);

        // --- Reporting (Views & Functions) ---
        DataTable GetProductSalesSummary(); // For vw_ProductSalesSummary
        DataTable GetOrderDetails();        // For vw_OrderDetails

        DataTable GetTopCustomersReport();

        // Scalar Functions
        decimal GetTotalOrderValue(int orderId);
        int GetStockLevel(int productId, int warehouseId);
    }
}