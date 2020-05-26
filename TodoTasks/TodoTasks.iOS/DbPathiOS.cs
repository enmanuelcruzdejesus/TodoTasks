using System;
using System.IO;
using Foundation;
using TodoTasks.iOS;
using TodoTasks.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbPathiOS))]

namespace TodoTasks.iOS
{
    public class DbPathiOS: IDbPath
    {
        public string GetConnection(string dbName, string dbFile)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryFolder = Path.Combine(documentsFolder, "..", "Library");
            string dbPath = Path.Combine(libraryFolder, dbFile);
            CopyIfNotExist(dbPath,dbName);
            return dbPath;



        }

        private static void CopyIfNotExist(string dbPath,string dbName)
        {
            if (!File.Exists(dbPath))
            {
                var app = (App)App.Current;
                var sourcePath = NSBundle.MainBundle.PathForResource(dbName, ".db3");
                File.Copy(sourcePath, dbPath);
            }
        }
    }
}
