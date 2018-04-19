using SQLite;
using System;
namespace GrocerEase
{
    public class PromotionList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string SaleName { get; set; }
        public string ItemName { get; set; }
        public DateTime expDate { get; set; }
        public int Percent { get; set; }

        public override string ToString()
        {
            return string.Format("Sale on {0} for {1)% off!", ItemName,Percent);
        }
    }
}
