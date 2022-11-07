using System;

namespace metaproapp.Data
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable < T > GetAll();  
        T Get(long id);  
        int Insert(T entity);  
        void Update(T entity);  
        bool Delete(long id); 
    }
}
