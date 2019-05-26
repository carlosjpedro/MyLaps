using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MyLaps.DataAccess.IntegrationTests
{
    public abstract class RepositoryTestBase : IDisposable
    {
        protected readonly MyLapsContext _context;
        private readonly SqliteConnection _connection;

        protected RepositoryTestBase()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<MyLapsContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new MyLapsContext(options);
            _context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection?.Close();
            _context?.Dispose();
            _connection?.Dispose();
        }
    }
}