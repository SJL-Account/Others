using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.DAL;
using DLOA.Model;
using System.Linq.Expressions;
using DLOA.IDAL;
using DLOA.DalFactory;

namespace DLOA.Service
{
    public abstract partial class BaseService<T> where T:class
    {
        //解耦步骤
        //TDal dbsession = new TDal();
        protected IDbSession dbsession = DbSessionFactory.GetDbSession();
        //1.实现只知道方法，不知道具体如何实现的对象：接口层
        //ITDal dbsession = DalFactoryCs.GetTDalAbstract();

        protected IBaseDal<T> curDal;

        protected abstract IBaseDal<T> GetDal();


        public BaseService()
        {
            curDal = GetDal();
        }
        //Add
        public bool Add(T t)
        {
            int a ;
            curDal.Add(t);
            return (a=dbsession.SaveChanges()) > 0;

        }
        //Delete
        public bool Remove(T t)
        {
            curDal.Remove(t);
            return dbsession.SaveChanges() > 0;

        }
        public bool Remove(int id)
        {
            curDal.Remove(id);
            return dbsession.SaveChanges()>0;
        }

        public bool Remove(int [] ids)
        {
            curDal.Remove(ids);
            return dbsession.SaveChanges()>0;
        }
        //Edit
        public bool Edit(T t)
        {
            curDal.Edit(t);
            return dbsession.SaveChanges() > 0;

        }

        //Get
        public T GetById(int id)
        {

            return curDal.GetById(id);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> wherelamada)
        {
            return curDal.GetList(wherelamada);
        }

        public IQueryable<T> GetListByPage<TKey>(Expression<Func<T, bool>> wherelamada, Expression<Func<T, TKey>> orderlamada, int PageIndex, int PageSize,out int counter)
        {
            return curDal.GetListByPage<TKey>(wherelamada, orderlamada, PageIndex, PageSize,out counter);
        }
    }
}
