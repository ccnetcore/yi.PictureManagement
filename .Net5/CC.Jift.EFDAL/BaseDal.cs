using CC.Jift.DALFactory;
using CC.Jift.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CC.Jift.EFDAL
{
    /// <summary>
    /// 职责：封装所有Dal层的公共的CRUD
    /// 类的职责一定要单一
    /// </summary>
    /// <typeparam name="T">由子类传递相应的实体类</typeparam>
    public class BaseDal<T> : IBaseDal<T> where T: class ,new()
    {
        public DbContext Db
        {
            get { return DbContentFactory.GetCurrentDbContent(); }
        }
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }


        public IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var pageData = Db.Set<T>().Where(whereLambda)
                              .OrderBy<T, S>(orderByLambda)
                              .Skip(pageSize * (pageIndex - 1))
                              .Take(pageSize).AsQueryable();
                return pageData;
            }
            else
            {
                var pageData = Db.Set<T>().Where(whereLambda)
                                 .OrderByDescending<T, S>(orderByLambda)
                                 .Skip(pageSize * (pageIndex - 1))
                                 .Take(pageSize).AsQueryable();
                return pageData;
            }
        }

        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            //所有字段均修改
            Db.Entry<T>(entity).State = EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }

        public bool Delete(T entity)
        {
            Db.Entry<T>(entity).State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }
        public bool Detete(int id)
        {
            var entity = Db.Set<T>().Find(id);//根据id找到实体
            Db.Set<T>().Remove(entity);//由于这里先Find找到了实体，所以这里可以用Remove标记该实体要移除（删除）。如果不是先Find到实体就需要用System.Data.Entity.EntityState.Deleted
            return true;
        }
    }
}
