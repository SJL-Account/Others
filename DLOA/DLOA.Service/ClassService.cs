 

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

    public partial class ActionInfoService:BaseService<ActionInfo>,IActionInfoService
    {
 
        protected override IBaseDal<ActionInfo> GetDal()
        {
            return  dbsession.GetActionInfoDal() ;
        }
    }
    public partial class RoleInfoService:BaseService<RoleInfo>,IRoleInfoService
    {
 
        protected override IBaseDal<RoleInfo> GetDal()
        {
            return  dbsession.GetRoleInfoDal() ;
        }
    }
    public partial class UserActionService:BaseService<UserAction>,IUserActionService
    {
 
        protected override IBaseDal<UserAction> GetDal()
        {
            return  dbsession.GetUserActionDal() ;
        }
    }
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
 
        protected override IBaseDal<UserInfo> GetDal()
        {
            return  dbsession.GetUserInfoDal() ;
        }
    }
    public partial class WorkFlowInstanceService:BaseService<WorkFlowInstance>,IWorkFlowInstanceService
    {
 
        protected override IBaseDal<WorkFlowInstance> GetDal()
        {
            return  dbsession.GetWorkFlowInstanceDal() ;
        }
    }
    public partial class WorkFlowModelService:BaseService<WorkFlowModel>,IWorkFlowModelService
    {
 
        protected override IBaseDal<WorkFlowModel> GetDal()
        {
            return  dbsession.GetWorkFlowModelDal() ;
        }
    }
    public partial class WorkFlowStepService:BaseService<WorkFlowStep>,IWorkFlowStepService
    {
 
        protected override IBaseDal<WorkFlowStep> GetDal()
        {
            return  dbsession.GetWorkFlowStepDal() ;
        }
    }
}

