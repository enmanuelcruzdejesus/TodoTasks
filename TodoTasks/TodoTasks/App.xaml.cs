using System;
using Acr.UserDialogs;
using TodoTasks.Services;
using TodoTasks.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoTasks
{
    public partial class App : Application
    {
        private Database _db;

        public static string DbName { get { return "Tasksdb"; } }
        public static string DbFileName { get { return "Tasksdb.db3"; } }
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

            MainPage = new NavigationPage(new TaskPage());
        }

        public static void ToastDialogError(string msg, double time = 2000)
        {
            ToastConfig.DefaultBackgroundColor = System.Drawing.Color.Red;
            ToastConfig.DefaultActionTextColor = System.Drawing.Color.White;
            UserDialogs.Instance.Toast(msg, TimeSpan.FromMilliseconds(time));
        }

        public static void ToastDialogAlert(string msg, double time = 2000)
        {
            ToastConfig.DefaultBackgroundColor = System.Drawing.Color.Blue;
            ToastConfig.DefaultActionTextColor = System.Drawing.Color.White;
            UserDialogs.Instance.Toast(msg, TimeSpan.FromMilliseconds(time));
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
