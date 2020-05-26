using System;
using TodoTasks.Models;

namespace TodoTasks.Services
{
    public class Database
    {
        private IRepository<Tasks> _tasks = null;


        private string _connectionString;
        private DatabaseContext _context;

        public Database(string connectionString)
        {

            this._connectionString = connectionString;
            this._context = new DatabaseContext(connectionString);


        }

        public IRepository<Tasks> Tasks
        {
            get
            {
                if (_tasks == null)
                    _tasks = new EntityFrameworkRepo<Tasks>(_context);

                return _tasks;
            }

        }

        public Database()
        {
        }
    }
}
