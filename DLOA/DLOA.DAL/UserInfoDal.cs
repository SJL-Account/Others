using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using DLOA.IDAL;

namespace DLOA.DAL
{
    public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
        public int SetRole(int UserId,int[] ids )
        {
            UserInfo userinfo = GetById(UserId);
            RoleInfoDal roleInfoDal = new RoleInfoDal();
            //add之前剁掉
            userinfo.RoleInfo.Clear();
            //从集合中依次拿出id相应的值与之匹配
            foreach (var item in ids)
	        {

		        userinfo.RoleInfo.Add(roleInfoDal.GetById(item));
	        }
            return 0;
			}
        public int SetAction(int uid, int aid, int isAllow)
        {
          

            //找出User uid
            UserInfo user=GetById(uid);
            //aid
            UserAction ua= user.UserAction.Where(u=>u.ActionId==aid).FirstOrDefault();

            if (ua != null)
            {
                //Edit
                if(isAllow==1)
                {
                    ua.IsAllow = true;
                    Edit(user);
                    
                }
                else if(isAllow==-1)
                {
                    ua.IsAllow = false;
                    Edit(user);
                }
                else if(isAllow==0)
                {
                    user.UserAction.Remove(ua);
                }

            }
            else
            {
                //Add
                if (isAllow == 1)
                {
                    user.UserAction.Add(new UserAction
                    { 
                    ActionId=aid,
                    UserId=uid,
                    IsAllow=true
                    
                    });
                }
                else if (isAllow == -1)
                {
                    user.UserAction.Add(new UserAction
                    {
                        ActionId = aid,
                        UserId = uid,
                        IsAllow = false

                    });
                }

            }
          

            return 0;
        }

            
      }

}


