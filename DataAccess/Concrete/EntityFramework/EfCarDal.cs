﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Car entity)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            return context.Set<Car>().SingleOrDefault(filter);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            return filter == null 
                ? context.Set<Car>().ToList() 
                : context.Set<Car>().Where(filter).ToList();
        }

        public void Update(Car entity)
        {
            using ReCapProject_DB_Context context = new ReCapProject_DB_Context();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}