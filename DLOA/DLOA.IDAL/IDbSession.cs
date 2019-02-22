using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLOA.IDAL
{
    public partial  interface IDbSession
    {
         //IUserInfoDal GetUserInfoDal();
         int SaveChanges();

         //IBaseDal<Model.RoleInfo> GetRoleInfoDal();
    }
}
