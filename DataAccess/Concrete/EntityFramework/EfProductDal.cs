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
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);// referans nosu yakalama//git veri kaynağından entiy ile eşleştir
                addedEntity.State = EntityState.Added;
                context.SaveChanges();//işlemleri gerçekleştirir
            }
        }

        public void Delete(Product entity)
        { 
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);// referans nosu yakalama//git veri kaynağından entiy ile eşleştir
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();//işlemleri gerçekleştirir
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context =new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);// referans nosu yakalama//git veri kaynağından entiy ile eşleştir
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();//işlemleri gerçekleştirir
            }
        }
    }
}
