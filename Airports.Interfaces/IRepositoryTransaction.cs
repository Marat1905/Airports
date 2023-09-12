using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airports.Interfaces
{
    /// <summary>Интерфейс управления транзакциями </summary>
    public interface IRepositoryTransaction : IAsyncDisposable
    {

        /// <summary>Сохраняем изменения в БД</summary>
        void Commit();

        /// <summary>Сохраняем изменения в БД асинхронно</summary>
        Task CommitAsync(CancellationToken Cancel = default);

        /// <summary>Откатываем все изменения в БД</summary>
        void Rollback();

        /// <summary>Откатываем все изменения в БД асинхронно</summary>
        Task RollbackAsync();
    }
}
