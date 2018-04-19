using SQLite;
namespace GrocerEase
{
    public class InventoryList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", ItemName);
        }
    }
}
