using System;
using System.Collections.Generic;
using System.Text;

namespace Airports.Interfaces
{
    /// <summary>Интерфейс управления транзакциями </summary>
    public interface IRepositoryTransaction:IDisposable
    {

        /// <summary>Сохраняем изменения в БД</summary>
        void Commit();

        /// <summary>Откатываем все изменения в БД</summary>
        void Rollback();
    }
}
