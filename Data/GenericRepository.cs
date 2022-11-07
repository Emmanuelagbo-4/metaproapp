using System;
using Microsoft.EntityFrameworkCore;

namespace metaproapp.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> entities;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<T>();
        }


        public T Get(long id)
        {
            var entity = entities!.SingleOrDefault(x => x.Id == id);

            if (entity != null)
            {
                return entity;
            }

            return null;
            // _dbContext.SaveChanges();
            // return entities!.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public int Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
           int count =  _dbContext.SaveChanges();
           return count;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.SaveChanges();
        }


        public bool Delete(long id)
        {
            var entity = entities!.SingleOrDefault(x => x.Id == id);
            // var entity = await _dbContext.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // public void Delete(T entity)
        // {
        //     if (entity == null)
        //     {
        //         throw new ArgumentNullException("entity");
        //     }
        //     entities.Remove(entity);
        //     _dbContext.SaveChanges();
        // }
    }
}
