 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OBS.DAL.Orm.EFCore
{
    public class ObsRepository<T> : IObsRepository<T> where T : class
    {
        private DbContext db;
        private DbSet<T> tables;
        public ObsRepository(ObsContext context)
        {
            db = context;
            tables = db.Set<T>();
        }
        public void Create(T model)
        {
            tables.Add(model);
            db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            T finded = Find(id);
            if (finded == null) return;
            tables.Remove(finded);
            db.SaveChanges();
        }
        public void Edit(T model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T model)
        {
            tables.Remove(model);
            db.SaveChanges();
        }

        public T Find(Guid id)
        {
            return tables.Find(id);
        }

        public List<T> Get()
        {
            return tables.ToList();
        }

        public IQueryable<T> GetQuery()
        {
            return tables;
        }

        public T Update(T model)
        {
            tables.Update(model);
            db.SaveChanges();
            return model;
        }
    }
}
