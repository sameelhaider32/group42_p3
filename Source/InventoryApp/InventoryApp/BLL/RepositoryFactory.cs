using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.BLL
{
    public static class RepositoryFactory
    {
        // This simple method returns the correct "Brain" based on the user's choice
        public static IInventoryRepository GetRepository(string type)
        {
            if (type == "LINQ")
            {
                return new InventoryRepositoryLINQ();
            }
            else
            {
                return new InventoryRepositorySP();
            }
        }
    }
}