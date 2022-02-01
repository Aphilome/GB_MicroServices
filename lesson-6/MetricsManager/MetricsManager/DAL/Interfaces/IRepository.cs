using System;
using System.Collections.Generic;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T> 
        where T : class
    {
        IList<T> GetAll();

        IList<T> Get(DateTime fromTime, DateTime toTime);

        T GetById(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }

}
