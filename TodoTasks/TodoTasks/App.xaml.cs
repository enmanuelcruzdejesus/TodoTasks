using System;
using TodoTasks.Services;
using TodoTasks.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoTasks
{
    public partial class App : Application
    {
        private Database _db;

        public static string DbName { get { return "taskdb"; } }
        public static string DbFileName { get { return "taskdb.db3"; } }
        public static string DbPath { get { return DependencyService.Get<IDbPath>().GetConnection(DbName,DbFileName); } }


        public Database Db
        {
            get
            {
                if (_db == null)
                    _db = new Database(DbPath);

                return _db;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
