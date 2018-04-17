using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GrocerEase
{
    public class InventoryListDataBase
    {
        readonly SQLiteAsyncConnection database;

        public InventoryListDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<InventoryList>().Wait();
        }

        public Task<List<InventoryList>> GetItemsAsync()
        {
            return database.Table<InventoryList>().ToListAsync();
        }

        public Task<List<InventoryList>> SearchItemsAsync(string Search)
        {
            return database.QueryAsync<InventoryList>("SELECT [ItemName], [Brand], [Price] WHERE [ItemName] = Search");
        }

        public Task<InventoryList> GetItemAsync(int id)
        {
            return database.Table<InventoryList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(InventoryList item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(InventoryList item)
        {
            return database.DeleteAsync(item);
        }
        public Task<List<InventoryList>> DeleteAllAsync()
        {

            database.DropTableAsync<InventoryList>().Wait();
            database.CreateTableAsync<InventoryList>().Wait();
            return database.Table<InventoryList>().ToListAsync();
        }
        public Task<List<InventoryList>> inInventory(string current)
        {
            return database.Table<InventoryList>().Where(i => i.ItemName.Contains(current)).ToListAsync();
        }
    }
}

