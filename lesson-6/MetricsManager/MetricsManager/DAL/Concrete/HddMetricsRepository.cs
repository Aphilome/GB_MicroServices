using Dapper;
using Metrics.Data.Entity;
using MetricsManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsManager.DAL.Concrete
{
    public class HddMetricsRepository : RepositoryBase<HddMetric, int>, IHddMetricsRepository
    {
        protected override string TableName => "hddmetrics";

        public void Create(HddMetric item)
        {
            CreateBase(item);
        }

        public void Delete(int id)
        {
            DeleteBase(id);
        }

        public IList<HddMetric> GetAll()
        {
            return GetAllBase();
        }

        public IList<HddMetric> Get(DateTime fromTime, DateTime toTime)
        {
            return GetBase(fromTime, toTime);
        }

        public HddMetric GetById(int id)
        {
            return GetByIdBase(id);
        }

        public void Update(HddMetric item)
        {
            UpdateBase(item);
        }
    }
}
