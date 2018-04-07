using SQLite;
namespace GrocerEase
{
    public class ShoppingList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public bool Incart { get; set; }

    }
}
