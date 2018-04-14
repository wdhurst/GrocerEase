using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace GrocerEase
{
    public partial class App : Application
    {
        static ShoppingListDataBase database;
        static InventoryListDataBase database2;

        public App()
        {
            InitializeComponent();

            MainPage = new GrocerEasePage();
        }

        public static ShoppingListDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new  ShoppingListDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ShoppingListSQLite.db3"));
                }
                return database;
            }
        }

        public static InventoryListDataBase DataBase2
        {
            get 
            {
                if (database2 == null)
                {
                    database2 = new InventoryListDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("InventoryListSQLite.db3"));
                }
                return database2;
            }
        }

        public int ResumeAtShoppingListId { get; set; }
        public DateTime current = DateTime.Today;


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
