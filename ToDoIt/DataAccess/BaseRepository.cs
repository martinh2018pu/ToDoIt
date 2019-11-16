using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoIt.Models;

namespace ToDoIt.DataAccess
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected ToDoItDbContext _dbContext;
        protected DbSet<T> DbSet { get; set; }

        public BaseRepository()
        {
            _dbContext = new ToDoItDbContext();
            DbSet = _dbContext.Set<T>();
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public void Delete(int id)
        {
            var model = Get(id);
            DbSet.Remove(model);

            _dbContext.SaveChanges();
        }

        public void Save(T model)
        {
            if (model.Id == 0)
            {
                Create(model);
            }
            else
            {
                Update(model);
            }

            _dbContext.SaveChanges();
        }

        private void Create(T model)
        {
            DbSet.Add(model);
        }

        private void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}