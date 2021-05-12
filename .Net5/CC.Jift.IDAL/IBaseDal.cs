using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CC.Jift.IDAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);


        IQueryable<T> GetPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);


        T Add(T entity);


        bool Update(T entity);

        bool Delete(T entity);

        bool Detete(int id);

    }
}
