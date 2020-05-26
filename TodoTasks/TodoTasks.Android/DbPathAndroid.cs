using System;
using System.IO;
using TodoTasks.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DbPathAndroid))]

namespace TodoTasks.Droid
{
    public class DbPathAndroid
    {
        public string GetConnection(string dbName, string dbFile)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsFolder, dbFile);
            CopyIfNotExist(path,dbName);
            return path;


        }

        private static void CopyIfNotExist(string dbPath,string dbName)
        {
            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }

                }
            }


        }
    }
}
