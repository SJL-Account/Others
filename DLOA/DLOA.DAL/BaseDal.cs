using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.Model;
using System.Data.Entity;
using System.Linq.Expressions;



namespace DLOA.DAL
{
    /// <summary>
    /// 所有dal类的实现同样功能的基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class BaseDal<T> where T :class
    {

        //里氏转换原则，子类可以赋值给父类
        DbContext context = ContextFactory.CreateContext();
        
        //Add
        public int Add(T t)
        {
           
            //返回DbSet<T>类型的值
             context.Set<T>().Add(t);
            //返回影响的行数
            //保存全部咋dbsession中进行
            //return context.SaveChanges();
            return 0;
        }

        //Del
        public int Remove(int id)
        {
            T ui = context.Set<T>().Find(id);
            //相当于context.Set<T>().Where(u => u.UserId == id);
            context.Entry<T>(ui).State = EntityState.Deleted;
            //相当于context.Set<T>().Remove(ui);
            //return context.SaveChanges();
            return 0;
        }

        public int Remove(int[] ids)
        {
            int length = ids.Count();
            for (int i = 0; i < length; i++)
            {
                T ui = context.Set<T>().Find(ids[i]);
                context.Entry<T>(ui).State = EntityState.Deleted;
            }
            // return context.SaveChanges();
            return 0;
        }

        public int Remove(T ui)
        {
            context.Entry<T>(ui).State = EntityState.Deleted;

            //return context.SaveChanges();
            return 0;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>

        public int Edit(T t)
        {
            context.Entry<T>(t).State = EntityState.Modified;
            //return context.SaveChanges();
            return 0;
        }
        /// <summary>
        /// Get
        /// </summary>

        public T GetById(int id)
        {

            return context.Set<T>().Find(id);
        }
        /// <summary>
        /// IQueryable区别于IEnumable主要由于Expression可以表达式树进而生成相应的where sql语句
        /// IEnumable是把数据提到内存中进行筛选
        /// IQueryable：IEnumable
        /// 
        /// </summary>
        /// <param name="wherelamada"></param>
        /// <returns></returns>
        public IQueryable<T> GetList(Expression<Func<T, bool>> wherelamada)
        {

            return context.Set<T>().Where(wherelamada);
            //IEnumable select * from T
            //IQueryable select * from T where....
        }
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <typeparam name="TKey">排序类型</typeparam>
        /// <param name="wherelamada">条件表达式</param>
        /// <param name="orderlamada">排序表达式</param>
        /// <param name="PageIndex">当前页</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns></returns>
        public IQueryable<T> GetListByPage<TKey>(Expression<Func<T, bool>> wherelamada, Expression<Func<T, TKey>> orderlamada, int PageIndex, int PageSize,out int counter)
        {
            counter = context.Set<T>().Where(wherelamada).Count();
            return context.Set<T>()
                           .Where(wherelamada)
                           .OrderBy(orderlamada)
                           .Skip((PageIndex - 1) * PageSize)
                           .Take(PageSize);
        }

    }
}
