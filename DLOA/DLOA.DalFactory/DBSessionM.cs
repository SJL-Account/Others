 

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


	      public  IActionInfoDal GetActionInfoDal()
        {
            
            return new ActionInfoDal();
        }

	      public  IRoleInfoDal GetRoleInfoDal()
        {
            
            return new RoleInfoDal();
        }

	      public  IUserActionDal GetUserActionDal()
        {
            
            return new UserActionDal();
        }

	      public  IUserInfoDal GetUserInfoDal()
        {
            
            return new UserInfoDal();
        }

	      public  IWorkFlowInstanceDal GetWorkFlowInstanceDal()
        {
            
            return new WorkFlowInstanceDal();
        }

	      public  IWorkFlowModelDal GetWorkFlowModelDal()
        {
            
            return new WorkFlowModelDal();
        }

	      public  IWorkFlowStepDal GetWorkFlowStepDal()
        {
            
            return new WorkFlowStepDal();
        }

	}
}