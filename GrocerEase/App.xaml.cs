using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace GrocerEase
{
    public partial class App : Application
    {
        static LogInDataBase database;

        public App()
        {
            InitializeComponent();

            MainPage = new GrocerEasePage();
		}

        public static LogInDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new LogInDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("LogInSQLite.db3"));
                }
                return database;
            }
        }


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
