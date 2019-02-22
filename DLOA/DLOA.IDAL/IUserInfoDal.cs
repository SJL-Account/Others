using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.Model;
namespace DLOA.IDAL
{
    public partial interface IUserInfoDal:IBaseDal<UserInfo>
    {
        int SetRole(int UserId, int[] ids);
        int SetAction(int uid, int aid, int isAllow);
    }
}
