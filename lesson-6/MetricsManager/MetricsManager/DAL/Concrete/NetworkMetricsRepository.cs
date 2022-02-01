using Dapper;
using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsManager.DAL.Concrete
{
    public class NetworkMetricsRepository : RepositoryBase<NetworkMetric, int>, INetworkMetricsRepository
    {
        protected override string TableName => "networkmetrics";

        public void Create(NetworkMetric item)
        {
            CreateBase(item);
        }

        public void Delete(int id)
        {
            DeleteBase(id);
        }

        public IList<NetworkMetric> GetAll()
        {
            return GetAllBase();
        }

        public IList<NetworkMetric> Get(DateTime fromTime, DateTime toTime)
        {
            return GetBase(fromTime, toTime);
        }

        public NetworkMetric GetById(int id)
        {
            return GetByIdBase(id);
        }

        public void Update(NetworkMetric item)
        {
            UpdateBase(item);
        }

        public DateTime GetLastMetricDate()
        {
            return GetLastMetricDateBase();
        }
    }
}
