using Airports.DAL.Context;
using Airports.DAL.Entityes.Base;
using Airports.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Airports.DAL
{
    internal class DBRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly AirpotsDB _db;
        private readonly DbSet<T> _Set;

        public bool AutoSaveChanges { get; set; } = true;

        public DBRepository(AirpotsDB db)
        {
            _db = db;
            _Set = db.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;

        public T Get(int id) => Items.SingleOrDefault(i => i.Id == id);

        public async Task<T> GetAsync(int id, CancellationToken Cancel = default)=> await Items.
            SingleOrDefaultAsync(i=>i.Id== id,Cancel).
            ConfigureAwait(false);

        public T Add(T item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));
            //_db.Add(item);
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                _db.SaveChanges();
            return item;
        }

        public async Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
            return item;
        }

        public void AddRange(IEnumerable<T> item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.AddRange(item);
            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            await _db.AddRangeAsync(item,Cancel).ConfigureAwait(false);
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void Remove(int id)
        {
            var item = _Set.Local.FirstOrDefault(i => i.Id == id) ?? new T { Id = id };
            _db.Remove(item);
            if (AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _db.Remove(new T { Id = id });
            if (AutoSaveChanges)
                await _db.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public void SaveAs()
        {
            if (!AutoSaveChanges)
                _db.SaveChanges();
        }

        public async Task SaveAsAsync()
        {
            if (!AutoSaveChanges)
              await  _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task ClearAsync()
        {
            _db.RemoveRange(Items);
           await  _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public IEnumerable<T> SqlRawQuery(string sql)
        {
            return _Set.FromSqlRaw(sql);
        }
    }
}
