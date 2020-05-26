using System;
namespace TodoTasks.Services
{
    public interface IDbPath
    {
        string GetConnection(string dbName, string dbFile);
    }
}
