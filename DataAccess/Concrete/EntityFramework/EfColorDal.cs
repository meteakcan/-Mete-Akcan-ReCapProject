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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {

            //IDisposable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {

            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
                //SingleOrDefault : Eğer dizi içinden sadece bir tane sayı seçmek istiyorsak ve seçim şartımız sağlanmıyorsa, bu durumda int tipinin varsayılan değeri olan 0(sıfır) döndürülsün istiyorsak SingleOrDefault seçimini kullanmalıyız.
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
                // arkaplanda SELECT* FROM(veritabanı) yapar ve bu aldığımız veriyi listeye çevirir.
                // : ise verdiğimiz filtre işlemini uygular.
                //ternary operatörü
            }
        }

        public void Update(Color entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
