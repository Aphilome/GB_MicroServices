using Dapper;
using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsManager.DAL.Concrete
{
    public class RamMetricsRepository : RepositoryBase<RamMetric, int>, IRamMetricsRepository
    {
        protected override string TableName => "rammetrics";

        public void Create(RamMetric item)
        {
            CreateBase(item);
        }

        public void Delete(int id)
        {
            DeleteBase(id);
        }

        public IList<RamMetric> GetAll()
        {
            return GetAllBase();
        }

        public IList<RamMetric> Get(DateTime fromTime, DateTime toTime)
        {
            return GetBase(fromTime, toTime);
        }

        public RamMetric GetById(int id)
        {
            return GetByIdBase(id);
        }

        public void Update(RamMetric item)
        {
            UpdateBase(item);
        }
    }
}
