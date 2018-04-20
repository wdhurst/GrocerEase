using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace GrocerEase
{
    public class PromotionListDataBase
    {
        readonly SQLiteAsyncConnection database;

        public PromotionListDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PromotionList>().Wait();
        }

        public Task<List<PromotionList>> GetItemsAsync()
        {
            return database.Table<PromotionList>().ToListAsync();
        }

        public Task<List<PromotionList>> SearchItemsAsync(string Search)
        {
            return database.QueryAsync<PromotionList>("SELECT [ItemName], [Brand], [Price] WHERE [ItemName] = Search");
        }

        public Task<PromotionList> GetItemAsync(int id)
        {
            return database.Table<PromotionList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(PromotionList item)
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

        public Task<int> DeleteItemAsync(PromotionList item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<PromotionList>> DeleteAllAsync()
        {

            database.DropTableAsync<PromotionList>().Wait();
            database.CreateTableAsync<PromotionList>().Wait();
            return database.Table<PromotionList>().ToListAsync();
        }
        public Task<List<PromotionList>> inInventory(string current)
        {
            return database.Table<PromotionList>().Where(i => i.ItemName.Contains(current)).ToListAsync();
        }

        public void checkDate(DateTime date)
        {
            database.ExecuteAsync("DELETE * WHERE [expDate] < ", date);   
        }


    }
}

