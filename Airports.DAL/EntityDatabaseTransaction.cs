using Airports.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;

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
        public void Rollback()
        {
            _Transaction.Rollback();
        }

        public void Dispose()
        {
            if (_disposing)
                Dispose(_disposing);
            else
                _Transaction.Dispose();
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
    }
}
