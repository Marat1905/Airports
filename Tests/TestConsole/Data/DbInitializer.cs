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
        public  void Initialize()
        {
             _db.Database.EnsureDeleted();

             _db.Database.Migrate();

        }
    }
}
