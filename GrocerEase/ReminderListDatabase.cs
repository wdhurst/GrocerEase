using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GrocerEase
{
    public class ReminderListDataBase
    {
        readonly SQLiteAsyncConnection database;

        public ReminderListDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ReminderList>().Wait();
        }

        public Task<List<ReminderList>> GetItemsAsync()
        {
            return database.Table<ReminderList>().ToListAsync();
        }

        public Task<List<ReminderList>> CheckRemindersAsync()
        {
            return database.QueryAsync<ReminderList>("SELECT * FROM [ItemName] WHERE [reminderDate] = 0");
        }

        public Task<ReminderList> GetItemAsync(int id)
        {
            return database.Table<ReminderList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ReminderList item)
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

        public Task<int> DeleteItemAsync(ReminderList item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<ReminderList>> DeleteAllAsync()
        {

            database.DropTableAsync<ReminderList>().Wait();
            database.CreateTableAsync<ReminderList>().Wait();
            return database.Table<ReminderList>().ToListAsync();
        }

        public Task<List<ReminderList>> timetoBuy(DateTime current)
        {
            return database.Table<ReminderList>().Where(i => i.reminderDate == current).ToListAsync();
        }
    }
}
