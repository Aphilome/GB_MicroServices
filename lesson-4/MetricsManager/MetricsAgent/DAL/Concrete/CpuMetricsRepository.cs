using Dapper;
using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;


namespace MetricsAgent.DAL.Concrete
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = @"Data Source=metrics.db; Version=3;Pooling=True;Max Pool Size=100;";

        public CpuMetricsRepository()
        {
            //SqlMapper.AddTypeHandler(new ());
        }

        public void Create(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO cpumetrics(value, dateTime) VALUES(@value, @dateTime)",
                    new
                    {
                        value = item.Value,
                        dateTime = item.DateTime
                    });
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                    new
                    {
                        id = id
                    });
            }
        }

        public IList<CpuMetric> GetAll()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<CpuMetric>("SELECT Id, DateTime, Value FROM cpumetrics").ToList();
            }
        }

        public CpuMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<CpuMetric>("SELECT Id, DateTime, Value FROM cpumetrics WHERE id=@id",
                    new { id = id });
            }
        }

        public void Update(CpuMetric item)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Execute("UPDATE cpumetrics SET value = @value, dateTime = @dateTime WHERE id=@id",
                    new
                    {
                        value = item.Value,
                        dateTime = item.DateTime,
                        id = item.Id
                    });
            }
        }
    }
}
