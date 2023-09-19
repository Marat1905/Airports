using Airports.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Airports.DAL
{
    /// <summary>Реализация интерфейса для управления транзакциями</summary>
    public class EntityDatabaseTransaction : IRepositoryTransaction
    {
        private IDbContextTransaction _Transaction;
        private bool _disposing=true;
        /// <summary>Начинает транзакцию если репозиторий реализует </summary>
        /// <param name="context"> Репозиторий</param>
        public EntityDatabaseTransaction(DbContext context)
        {
            _Transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
           _Transaction.Commit();
           _disposing = false;
        }

        public async Task CommitAsync(CancellationToken Cancel = default)
        {
           await _Transaction.CommitAsync(Cancel);
            _disposing = false;
        }

        public void Rollback()
        {
            _Transaction.Rollback();
        }

        public async Task RollbackAsync()
        {
           await _Transaction.RollbackAsync();
        }

        public void Dispose()
        {
            if (_disposing)
                Dispose(_disposing);
            else
                _Transaction.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposing)
               await DisposeAsync(_disposing);
            else
               await _Transaction.DisposeAsync();
        }

        private void Dispose(bool disposing)
        {
            if (disposing && (_Transaction != null))
            {
                _disposing = true;
                Rollback();
                _Transaction.Dispose();
            }
        }

        private async Task DisposeAsync(bool disposing, CancellationToken Cancel = default)
        {
            if (disposing && (_Transaction != null))
            {
                _disposing = true;
               await RollbackAsync();
                _Transaction.Dispose();
            }
        }

       
    }
}
