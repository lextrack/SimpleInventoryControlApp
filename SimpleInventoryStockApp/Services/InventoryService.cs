
/* Unmerged change from project 'SimpleInventoryStockApp (net7.0-ios)'
Before:
using System;
After:
using SimpleInventoryStockApp.Models;
using SQLite;
using System;
*/

/* Unmerged change from project 'SimpleInventoryStockApp (net7.0-android)'
Before:
using System;
After:
using SimpleInventoryStockApp.Models;
using SQLite;
using System;
*/

/* Unmerged change from project 'SimpleInventoryStockApp (net7.0-windows10.0.19041.0)'
Before:
using System;
After:
using SimpleInventoryStockApp.Models;
using SQLite;
using System;
*/
using SimpleInventoryStockApp.Models;
using
/* Unmerged change from project 'SimpleInventoryStockApp (net7.0-ios)'
Before:
using System.Threading.Tasks;
using SQLite;
using SimpleInventoryStockApp.Models;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'SimpleInventoryStockApp (net7.0-android)'
Before:
using System.Threading.Tasks;
using SQLite;
using SimpleInventoryStockApp.Models;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'SimpleInventoryStockApp (net7.0-windows10.0.19041.0)'
Before:
using System.Threading.Tasks;
using SQLite;
using SimpleInventoryStockApp.Models;
After:
using System.Threading.Tasks;
*/
SQLite;

namespace SimpleInventoryStockApp.Services
{
    public class InventoryService
    {
        SQLiteConnection conn;
        string _dbPath;
        public string StatusMessage;
        int result = 0;
        public InventoryService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Inventory>();
        }

        public List<Inventory> GetInventories()
        {
            try
            {
                Init();
                return conn.Table<Inventory>().ToList();
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return new List<Inventory>();
        }

        public Inventory GetInventory(int id)
        {
            try
            {
                Init();
                return conn.Table<Inventory>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public int DeleteInventory(int id)
        {
            try
            {
                Init();
                return conn.Table<Inventory>().Delete(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data.";
            }

            return 0;
        }

        public void AddInventory(Inventory inventory)
        {
            try
            {
                Init();

                if (inventory == null)
                    throw new Exception("Invalid Inventory Record");

                result = conn.Insert(inventory);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to insert data.";
            }
        }

        public void UpdateInventory(Inventory inventory)
        {
            try
            {
                Init();

                if (inventory == null)
                    throw new Exception("Invalid Inventory Record");

                result = conn.Update(inventory);
                StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
            }
            catch (Exception)
            {
                StatusMessage = "Failed to Update data.";
            }
        }
    }
}