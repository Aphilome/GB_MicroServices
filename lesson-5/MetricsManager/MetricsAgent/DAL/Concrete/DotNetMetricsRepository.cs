using Dapper;
using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace MetricsAgent.DAL.Concrete
{
    public class DotNetMetricsRepository : RepositoryBase<DotNetMetric, int>, IDotNetMetricsRepository
    {
        protected override string TableName => "dotnetmetrics";

        public void Create(DotNetMetric item)
        {
            CreateBase(item);
        }

        public void Delete(int id)
        {
            DeleteBase(id);
        }

        public IList<DotNetMetric> GetAll()
        {
            return GetAllBase();
        }

        public IList<DotNetMetric> Get(DateTime fromTime, DateTime toTime)
        {
            return GetBase(fromTime, toTime);
        }

        public DotNetMetric GetById(int id)
        {
            return GetByIdBase(id);
        }

        public void Update(DotNetMetric item)
        {
            UpdateBase(item);
        }
    }
}
