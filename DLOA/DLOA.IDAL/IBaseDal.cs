using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLOA.IDAL
{
    //基类接口
     public interface IBaseDal<T> where T :class
    {
        int Add(T t);
        int Edit(T t);

        int Remove(int id);
        int Remove(int[] ids);
        int Remove(T t);
        T GetById(int id);

        IQueryable<T> GetList(Expression<Func<T,bool>> wherelamada);

        IQueryable<T> GetListByPage <TKey>(Expression<Func<T, bool>> wherelamada,Expression<Func<T,TKey>> orderlamada,int PageIndex,int PageCount,out int counter);

    }
}
