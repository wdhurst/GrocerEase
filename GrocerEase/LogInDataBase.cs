using System;
using SQLite;
using Xamarin.Forms;

namespace GrocerEase
{
    public class LogInDataBase 
    {
        readonly SQLiteAsyncConnection database;

        public LogInDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LogIn>().Wait();
        }
      /*  public Account<List<LogIn>> GetItemsAsync()
        {
            return database.Table<LogIn>().ToListAsync();
        }

        public Account<List<LogIn>> GetItemsNotDoneAsync()
        {
            //return database.QueryAsync<LogIn>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Account<LogIn> GetItemAsync(int id)
        {
            return database.Table<LogIn>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Account<int> SaveItemAsync(LogIn item)
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

        public Account<int> DeleteItemAsync(LogIn item)
        {
            return database.DeleteAsync(item);
        }*/
    }
}

