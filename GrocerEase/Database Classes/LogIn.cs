using SQLite;
namespace GrocerEase
{
    public class LogIn
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool BizAccount { get; set; }

    }
}
