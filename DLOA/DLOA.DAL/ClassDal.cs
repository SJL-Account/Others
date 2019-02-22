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
    public partial class ActionInfoDal:BaseDal<ActionInfo>,IActionInfoDal
    {
        

    }
    public partial class RoleInfoDal:BaseDal<RoleInfo>,IRoleInfoDal
    {
        

    }
    public partial class UserActionDal:BaseDal<UserAction>,IUserActionDal
    {
        

    }
    public partial class UserInfoDal:BaseDal<UserInfo>,IUserInfoDal
    {
        

    }
    public partial class WorkFlowInstanceDal:BaseDal<WorkFlowInstance>,IWorkFlowInstanceDal
    {
        

    }
    public partial class WorkFlowModelDal:BaseDal<WorkFlowModel>,IWorkFlowModelDal
    {
        

    }
    public partial class WorkFlowStepDal:BaseDal<WorkFlowStep>,IWorkFlowStepDal
    {
        

    }
}

