using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GrocerEase
{
    public class ShoppingListDataBase 
    {
        readonly SQLiteAsyncConnection database;

        public ShoppingListDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ShoppingList>().Wait();
        }

      public Task<List<ShoppingList>> GetItemsAsync()
        {
            return database.Table<ShoppingList>().ToListAsync();
        }

        public Task<List<ShoppingList>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ShoppingList>("SELECT * FROM [ItemName] WHERE [InCart] = 0");
        }

        public Task<ShoppingList> GetItemAsync(int id)
        {
            return database.Table<ShoppingList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ShoppingList item)
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

        public Task<int> DeleteItemAsync(ShoppingList item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<ShoppingList>> DeleteAllAsync()
        {
            
            database.DropTableAsync<ShoppingList>().Wait();
            database.CreateTableAsync<ShoppingList>().Wait();
            return database.Table<ShoppingList>().ToListAsync();
        }
    }
}

