using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.IDAL;
using DLOA.DAL;
using System.Data.Entity;

/// <summary>
/// 数据会话层
/// </summary>
namespace DLOA.DalFactory
{
    public partial class DbSession:IDbSession
    {
        //解耦，dal层改变仅需要改变此处即可
        //public  IUserInfoDal GetUserInfoDal()
        //{
            
        //    return new UserInfoDal();
        //}
        /// <summary>
        /// 一个业务中涉及到多张表的操作 我们希望连接一次数据库就对完成对多张表数据的操作，提高性能
        /// </summary>
        /// <returns></returns>
        public  int SaveChanges()
        {
            DbContext db=  ContextFactory.CreateContext();
            //调用了唯一的DbContext线程 "OAContainer"
            return db.SaveChanges();
        }
    }
}
