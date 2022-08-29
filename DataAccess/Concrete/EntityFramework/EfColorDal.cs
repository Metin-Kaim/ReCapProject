using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Color entity)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            return context.Set<Color>().SingleOrDefault(filter);
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            return filter == null
                ? context.Set<Color>().ToList()
                : context.Set<Color>().Where(filter).ToList();
        }

        public void Update(Color entity)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
