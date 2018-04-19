using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace GrocerEase
{
    public partial class App : Application
    {
        static ShoppingListDataBase databaseS;
        static InventoryListDataBase databaseI;
        static ReminderListDataBase databaseR;

        public App()
        {
            InitializeComponent();

            MainPage = new GrocerEasePage();
        }

        public static ShoppingListDataBase DatabaseS
        {
            get
            {
                if (databaseS == null)
                {
                    databaseS = new ShoppingListDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ShoppingListSQLite.db3"));
                }
                return databaseS;
            }
        }

        public static InventoryListDataBase DatabaseI
        {
            get
            {
                if (databaseI == null)
                {
                    databaseI = new InventoryListDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("InventoryListSQLite.db3"));
                }
                return databaseI;
            }
        }
        public static ReminderListDataBase DatabaseR
        {
            get
            {
                if (databaseR == null)
                {
                    databaseR = new ReminderListDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("ReminderListSQLite.db3"));
                }
                return databaseR;
            }
        }

        public int ResumeAtShoppingListId { get; set; }
        public int ResumeAtReminderListId { get; set; }
        public DateTime current { get; set;}


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
