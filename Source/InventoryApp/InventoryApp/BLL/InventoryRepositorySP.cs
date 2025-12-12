using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // Needed for raw SQL connections
using System.Linq;

namespace InventoryApp.BLL
{
    public class InventoryRepositorySP : IInventoryRepository
    {
        // 1. Get All Products (Using SQL since we don't have a specific SP for this)
        public List<Product> GetAllProducts()
        {
            using (var db = new InventoryProjectDBEntities())
            {
      
                return db.Database.SqlQuery<Product>("SELECT * FROM Products").ToList();
            }
        }

        // 2. Add New Product (Calls sp_AddNewProduct)
        public string AddNewProduct(string sku, string name, decimal price, string description, int stock)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                try
                {
                   
                    db.sp_AddNewProduct(sku, name, price, description);

                   
                    string stockSql = @"
                INSERT INTO Inventory (ProductID, WarehouseID, QuantityOnHand)
                SELECT ProductID, 1, @p0 
                FROM Products 
                WHERE SKU = @p1";

                    db.Database.ExecuteSqlCommand(stockSql, stock, sku);

                    return "Success: Product and Stock added via SP.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        // 3. Get  lists
        public List<Customer> GetAllCustomers()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                return db.Database.SqlQuery<Customer>("SELECT * FROM Customers").ToList();
            }
        }

        public List<Warehouse> GetAllWarehouses()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                return db.Database.SqlQuery<Warehouse>("SELECT * FROM Warehouses").ToList();
            }
        }

        // 4. Place Order 
        public string PlaceOrder(int customerId, int productId, int warehouseId, int quantity)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                try
                {
                    
                    db.sp_PlaceOrder(customerId, productId, warehouseId, quantity);
                    return "Success: Order placed via Stored Procedure.";
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.InnerException?.Message ?? ex.Message;
                }
            }
        }

        // 5. Reporting
        public DataTable GetProductSalesSummary()
        {
            return GetDataTableFromQuery("SELECT * FROM vw_ProductSalesSummary");
        }

        public DataTable GetOrderDetails()
        {
            return GetDataTableFromQuery("SELECT * FROM vw_OrderDetails");
        }

        // 6. Functions (Calls SQL Scalar Functions via Query)
        public decimal GetTotalOrderValue(int orderId)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                // We execute a raw SELECT to call the SQL function
                var result = db.Database.SqlQuery<decimal?>("SELECT dbo.fn_GetTotalOrderValue(@p0)", orderId).SingleOrDefault();
                return result ?? 0;
            }
        }

        public int GetStockLevel(int productId, int warehouseId)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                var result = db.Database.SqlQuery<int?>("SELECT dbo.fn_GetStockLevel(@p0, @p1)", productId, warehouseId).SingleOrDefault();
                return result ?? 0;
            }
        }

        // --- Helper for Raw SQL DataTables ---
        private DataTable GetDataTableFromQuery(string sqlQuery)
        {
            DataTable dt = new DataTable();
            
            using (var db = new InventoryProjectDBEntities())
            {
                using (var command = db.Database.Connection.CreateCommand())
                {
                    command.CommandText = sqlQuery;
                    if (db.Database.Connection.State != ConnectionState.Open)
                        db.Database.Connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }


        public DataTable GetTopCustomersReport()
        {
            return GetDataTableFromQuery("EXEC spTopCustomers");
        }
    }
}