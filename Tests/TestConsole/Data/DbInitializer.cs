using Airports.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace TestConsole.Data
{
    internal class DbInitializer
    {
        private readonly AirpotsDB _db;
        public DbInitializer(AirpotsDB db)
        {
            _db = db;
        }
        public  async Task InitializeAsync()
        {
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);

             await _db.Database.MigrateAsync().ConfigureAwait(false);

        }
    }
}
