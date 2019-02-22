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
using DLOA.IService;

namespace DLOA.Service
{
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {


     //具体实现UserInfo的功能
        //为什么是protected
        //protected override IBaseDal<UserInfo> GetDal()
        //{
        //    return  dbsession.GetUserInfoDal() ;
        //}

        public bool SetRole(string UserId,string[] ids)
        {

            List<int> list = new List<int>();
            foreach (var item in ids)
            {
                list.Add(int.Parse(item));
            }
            ((UserInfoDal)curDal).SetRole(int.Parse(UserId),list.ToArray());
            return dbsession.SaveChanges() > 0;
            
        }

        public bool SetAction(int uid,int aid,int isAllow)
        {
            ((UserInfoDal)curDal).SetAction(uid,aid,isAllow);
            int a;
           return (a= dbsession.SaveChanges()) > 0;
        }

    }
}

