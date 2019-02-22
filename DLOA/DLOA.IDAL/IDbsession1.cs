 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLOA.IDAL
{
    public partial  interface IDbSession
    {
		
			IActionInfoDal GetActionInfoDal();
		
			IRoleInfoDal GetRoleInfoDal();
		
			IUserActionDal GetUserActionDal();
		
			IUserInfoDal GetUserInfoDal();
		
			IWorkFlowInstanceDal GetWorkFlowInstanceDal();
		
			IWorkFlowModelDal GetWorkFlowModelDal();
		
			IWorkFlowStepDal GetWorkFlowStepDal();
			}

}