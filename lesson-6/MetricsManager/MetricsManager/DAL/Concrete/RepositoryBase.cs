using Dapper;
using Metrics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsManager.DAL.Concrete
{
    public abstract class RepositoryBase<T, V>
            where T : AMetric<V>
    {
        private const string ConnectionString = @"Data Source=metrics_manager.db; Version=3;Pooling=True;Max Pool Size=100;";
        protected virtual string TableName { get; }

        public void CreateBase(T item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"INSERT INTO {TableName}(value, dateTime) VALUES(@value, @dateTime)",
                    new
                    {
                        value = item.Value,
                        dateTime = item.DateTime
                    });
            }
        }

        public void DeleteBase(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"DELETE FROM {TableName} WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public IList<T> GetAllBase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<T>($"SELECT Id, DateTime, Value FROM {TableName}").ToList();
            }
        }

        public IList<T> GetBase(DateTime from, DateTime to)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<T>($"SELECT Id, DateTime, Value FROM {TableName} WHERE DateTime > @fromTime AND DateTime < @toTime",
                    new
                    {
                        fromTime = from,
                        toTime = to
                    }).ToList();
            }
        }

        public T GetByIdBase(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<T>($"SELECT Id, DateTime, Value FROM {TableName} WHERE id=@id",
                    new { id = id });
            }
        }

        public void UpdateBase(T item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute($"UPDATE {TableName} SET value = @value, dateTime = @dateTime WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        dateTime = item.DateTime,
                        id = item.Id
                    });
            }
        }

        // возвращает последнюю дату из полученных метрик. Если пусто, то берется данные месяц назад
        public DateTime GetLastMetricDateBase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<DateTime?>($"SELECT DateTime FROM {TableName} ORDER BY DateTime DESC LIMIT 1") ?? DateTime.UtcNow.AddMonths(-1);
            }
        }
    }
}
