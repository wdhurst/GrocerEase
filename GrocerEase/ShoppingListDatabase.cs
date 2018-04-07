using System;
using System.Threading;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GrocerEase
{
    public class ShoppingListDataBase 
    {
        SQLiteAsyncConnection database;

        public ShoppingListDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ShoppingList>().Wait();
        }

       /* public Task<int>SaveItemAsync(ShoppingList account)
        {
            if (account.ID != 0)
                return database.QueryAsync<ShoppingList>();
            else
                return database.InsertAsync(account);
        }


      public Account<List<ShoppingList>> GetItemsAsync()
        {
            return database.Table<ShoppingList>().ToListAsync();
        }

        public Account<List<ShoppingList>> GetItemsNotDoneAsync()
        {
            //return database.QueryAsync<ShoppingList>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Account<ShoppingList> GetItemAsync(int id)
        {
            return database.Table<ShoppingList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Account<int> SaveItemAsync(ShoppingList item)
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

        public Account<int> DeleteItemAsync(ShoppingList item)
        {
            return database.DeleteAsync(item);
        }
*/
    }
}

