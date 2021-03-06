using Dapper;
using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using System;
using System.Collections.Generic;


namespace MetricsAgent.DAL.Concrete
{
    public class CpuMetricsRepository : RepositoryBase<CpuMetric, int>, ICpuMetricsRepository
    {
        protected override string TableName => "cpumetrics";

        public void Create(CpuMetric item)
        {
            CreateBase(item);
        }

        public void Delete(int id)
        {
            DeleteBase(id);
        }

        public IList<CpuMetric> GetAll()
        {
            return GetAllBase();
        }

        public IList<CpuMetric> Get(DateTime fromTime, DateTime toTime)
        {
            return GetBase(fromTime, toTime);
        }

        public CpuMetric GetById(int id)
        {
            return GetByIdBase(id);
        }

        public void Update(CpuMetric item)
        {
            UpdateBase(item);
        }
    }
}
