using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLOA.Model;
namespace DLOA.IService
{
    public partial interface IUserInfoService:IBaseService<UserInfo>
    {
        bool SetRole(string UserId, string[] ids);
        bool SetAction(int uid, int aid, int isAllow);
    }
}
