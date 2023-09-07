using Airports.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Airports.TestWpf.Data
{
    public class DbInitializer
    {
        private readonly AirpotsDB _db;
        public DbInitializer(AirpotsDB db)
        {
            _db = db;
        }
        public async Task InitializeAsync()
        {
            //Если он не существует БД, никаких действий не выполняется. Если она существует, база данных удаляется.
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            //Прекращаем отслеживание всех отслеживаемых в настоящее время сущностей.
            _db.ChangeTracker.Clear();
            //Мигрируем БД
            await _db.Database.MigrateAsync().ConfigureAwait(false);
        }
    }
}
