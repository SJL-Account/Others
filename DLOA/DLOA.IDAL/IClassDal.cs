
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLOA.Model;

namespace DLOA.IDAL
{
    public partial interface IActionInfoDal:IBaseDal<ActionInfo>
    {
    }

    public partial interface IRoleInfoDal:IBaseDal<RoleInfo>
    {
    }

    public partial interface IUserActionDal:IBaseDal<UserAction>
    {
    }

    public partial interface IUserInfoDal:IBaseDal<UserInfo>
    {
    }

    public partial interface IWorkFlowInstanceDal:IBaseDal<WorkFlowInstance>
    {
    }

    public partial interface IWorkFlowModelDal:IBaseDal<WorkFlowModel>
    {
    }

    public partial interface IWorkFlowStepDal:IBaseDal<WorkFlowStep>
    {
    }

}
