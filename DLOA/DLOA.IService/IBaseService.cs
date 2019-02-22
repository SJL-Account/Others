using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using DLOA.IDAL;


namespace DLOA.IService
{
    public partial interface IBaseService<T> where T:class
    {

        
        bool Add(T t);
        bool Edit(T t);
        bool Remove(T t);
        bool Remove(int id);
        bool Remove(int[] ids);
        T GetById(int id);
        IQueryable<T> GetList(Expression<Func<T, bool>> wherelamada);
        IQueryable<T> GetListByPage<TKey>(Expression<Func<T, bool>> wherelamada, Expression<Func<T, TKey>> orderlamada, int PageIndex, int PageSize,out int counter);


    }
}
