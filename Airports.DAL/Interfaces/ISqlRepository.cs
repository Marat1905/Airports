using Airports.Interfaces;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Airports.DAL.Interfaces
{
    public interface ISqlRepository<T> : IRepository<T>
        where T : class, IEntity, new()
    {
        /// <summary>Для получения данных вычисленных в БД </summary>
        /// <param name="sql">SQL выражение</param>
        /// <param name="param">Набор параметров в запрос</param>
        /// <returns>Возвращаем список</returns>
        IEnumerable<T> SqlRawQuery(string sql, SqlParameter[] param);

        /// <summary>Для получения данных вычисленных в БД асинхронно </summary>
        /// <param name="sql">SQL выражение</param>
        /// <param name="param">Набор параметров в запрос</param>
        /// <param name="Cancel">Токен отмены операции</param>
        /// <returns>Возвращаем список</returns>
        Task<IEnumerable<T>> SqlRawQueryAsync(string sql, SqlParameter[] param, CancellationToken Cancel = default);
    }
}
