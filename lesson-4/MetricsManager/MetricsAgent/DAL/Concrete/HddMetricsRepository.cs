using Dapper;
using Metrics.Data.Entity;
using MetricsAgent.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DAL.Concrete
{
    public class HddMetricsRepository : RepositoryBase<HddMetric, int>, IHddMetricsRepository
    {
        protected override string TableName => "hddnetmetrics";

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
