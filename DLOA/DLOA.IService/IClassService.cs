 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLOA.Model;


namespace DLOA.IService
{
    public partial interface IActionInfoService:IBaseService<ActionInfo>
    {

	}

    public partial interface IRoleInfoService:IBaseService<RoleInfo>
    {

	}

    public partial interface IUserActionService:IBaseService<UserAction>
    {

	}

    public partial interface IUserInfoService:IBaseService<UserInfo>
    {

	}

    public partial interface IWorkFlowInstanceService:IBaseService<WorkFlowInstance>
    {

	}

    public partial interface IWorkFlowModelService:IBaseService<WorkFlowModel>
    {

	}

    public partial interface IWorkFlowStepService:IBaseService<WorkFlowStep>
    {

	}

}