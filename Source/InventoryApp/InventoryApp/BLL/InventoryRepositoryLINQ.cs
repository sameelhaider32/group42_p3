using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryApp.BLL
{
    public class InventoryRepositoryLINQ : IInventoryRepository
    {
        // 1. Get All Products
        public List<Product> GetAllProducts()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                return db.Products.ToList();
            }
        }

        // 2. Add New Product
        public string AddNewProduct(string sku, string name, decimal price, string description, int stock)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                if (db.Products.Any(p => p.SKU == sku)) return "Error: SKU already exists.";

  
                var newProduct = new Product
                {
                    SKU = sku,
                    ProductName = name,
                    BasePrice = price,
                    Description = description
                };
                db.Products.Add(newProduct);
                db.SaveChanges(); 

                // 2. Add Initial Stock (Default Warehouse ID = 1)
                var newInventory = new Inventory
                {
                    ProductID = newProduct.ProductID,
                    WarehouseID = 1, 
                    QuantityOnHand = stock
                };
                db.Inventories.Add(newInventory);
                db.SaveChanges();

                return "Success: Product and Stock added via LINQ.";
            }
        }

        // 3. Get Dropdown Lists
        public List<Customer> GetAllCustomers()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                return db.Customers.ToList();
            }
        }

        public List<Warehouse> GetAllWarehouses()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                return db.Warehouses.ToList();
            }
        }

        public string PlaceOrder(int customerId, int productId, int warehouseId, int quantity)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        // 1. Stock Check (We keep this LINQ because reading is safe)
                        var inventoryItem = db.Inventories
                            .FirstOrDefault(i => i.ProductID == productId && i.WarehouseID == warehouseId);

                        if (inventoryItem == null || inventoryItem.QuantityOnHand < quantity)
                        {
                            return "Error: Insufficient Stock.";
                        }

                        // 2. Insert Header (RAW SQL to bypass Partitioning/Identity bug)
                        // We use "SELECT SCOPE_IDENTITY()" to get the new ID safely
                        string sqlHeader = @"
                    INSERT INTO SalesOrders (CustomerID, OrderDate, Status) 
                    VALUES (@p0, @p1, 'Pending');
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        DateTime orderDate = DateTime.Now;

                        // Execute and get the new OrderID immediately
                        int newOrderId = db.Database.SqlQuery<int>(sqlHeader, customerId, orderDate).Single();

                        // 3. Insert Detail 
                        // We need to fetch the price first
                        var product = db.Products.Find(productId);

                        string sqlDetail = @"
                    INSERT INTO SalesOrderItems (OrderID, OrderDate, ProductID, Quantity, UnitPrice) 
                    VALUES (@p0, @p1, @p2, @p3, @p4)";

                        db.Database.ExecuteSqlCommand(sqlDetail, newOrderId, orderDate, productId, quantity, product.BasePrice);

                        // 4. Update Inventory 
                        string sqlInv = @"
                    UPDATE Inventory 
                    SET QuantityOnHand = QuantityOnHand - @p0 
                    WHERE ProductID = @p1 AND WarehouseID = @p2";

                        db.Database.ExecuteSqlCommand(sqlInv, quantity, productId, warehouseId);

                        // 5. Commit
                        transaction.Commit();
                        return "Success: Order placed.";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // This will tell us the REAL error if one exists
                        return "Error: " + ex.Message;
                    }
                }
            }
        }

        // 5. Reporting (Views)
        public DataTable GetProductSalesSummary()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                var data = db.vw_ProductSalesSummary.ToList();
                return ConvertToDataTable(data);
            }
        }

        public DataTable GetOrderDetails()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                var data = db.vw_OrderDetails.ToList();
                return ConvertToDataTable(data);
            }
        }

        // 6. Functions (Calculations)
        public decimal GetTotalOrderValue(int orderId)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                // LINQ equivalent of your SQL Function
                var total = db.SalesOrderItems
                    .Where(x => x.OrderID == orderId)
                    .Sum(x => (decimal?)(x.Quantity * x.UnitPrice)) ?? 0;
                return total;
            }
        }

        public int GetStockLevel(int productId, int warehouseId)
        {
            using (var db = new InventoryProjectDBEntities())
            {
                var qty = db.Inventories
                    .Where(i => i.ProductID == productId && i.WarehouseID == warehouseId)
                    .Select(i => (int?)i.QuantityOnHand)
                    .FirstOrDefault() ?? 0;
                return qty;
            }
        }

        // Helper: Converts List to DataTable for the UI Grid
        private DataTable ConvertToDataTable<T>(List<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);
            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in props) dataTable.Columns.Add(prop.Name);
            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++) values[i] = props[i].GetValue(item, null);
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }


        public DataTable GetTopCustomersReport()
        {
            using (var db = new InventoryProjectDBEntities())
            {
                // We use .CreateCommand() to run the CTE stored procedure
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = "EXEC spTopCustomers"; // Calls your friend's CTE proc

                if (cmd.Connection.State != System.Data.ConnectionState.Open)
                    cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }
    }
}