using SQLite;
using System;
namespace GrocerEase
{
    public class ReminderList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string itemName { get; set; }
        public DateTime reminderDate { get; set; }

    }
}