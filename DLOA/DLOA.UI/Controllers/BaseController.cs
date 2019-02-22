using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.Model;
using DLOA.Common;
using DLOA.IService;
namespace DLOA.UI.Controllers
{
    public class BaseController : Controller
    {
        public IUserInfoService userinfoservice { get; set; }
        public IActionInfoService actionInfoService { get; set; }
        public IRoleInfoService roleInfoService { get; set; }
        public IWorkFlowInstanceService workFlowInstanceService { get; set; }

        public IWorkFlowStepService workFlowStepService { get; set; }
        public IWorkFlowModelService workFlowModelService { get; set; }

        public UserInfo CurrentLoginUserInfo { get; set; }

        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{

        //    base.OnActionExecuted(filterContext);
        //    //mm+cookie验证
        //    //1.取出cookies中的值
        //    if (Request.Cookies.Get("LoginId") == null)
        //    {
        //        //浏览器给服务器发请求必须返回一个结果，所以执行完过滤器后仍然执行了相应的动作返回一个ActionResult
        //        //filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
        //        //这样在过滤器就已经返回了一个结果给浏览器

        //        filterContext.Result = Redirect("/UserLogin/Index");
        //        return;
        //    }
        //    string key = Request.Cookies.Get("LoginId").Value;
        //    //拿cookies中的值与mm服务器中的值进行校验
        //    MemcachedHelper mm = new MemcachedHelper();
        //   ui = mm.get(key) as UserInfo;
        //    if (ui == null)
        //    {
        //        filterContext.Result = Redirect("/UserLogin/Index");
        //        return;

        //    }
        //    //滑动时间
        //    mm.set(key, ui, DateTime.Now.AddMinutes(20));



        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region 登录验证
            base.OnActionExecuting(filterContext);
            //mm+cookie验证
            //1.取出cookies中的值
            if (Request.Cookies.Get("LoginId") == null)
            {
                //浏览器给服务器发请求必须返回一个结果，所以执行完过滤器后仍然执行了相应的动作返回一个ActionResult
                //filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                //这样在过滤器就已经返回了一个结果给浏览器

                filterContext.Result = Redirect("/UserLogin/Index");
                return;
            }
            string key = Request.Cookies.Get("LoginId").Value;
            //拿cookies中的值与mm服务器中的值进行校验
            MemcachedHelper mm = new MemcachedHelper();
            CurrentLoginUserInfo = mm.get(key) as UserInfo;
            if (CurrentLoginUserInfo == null)
            {
                filterContext.Result = Redirect("/UserLogin/Index");
                return;

            }
            //滑动时间
            mm.set(key, CurrentLoginUserInfo, DateTime.Now.AddMinutes(20));
            #endregion
            #region 权限验证
            if(CurrentLoginUserInfo.UserName=="admin")
            {
                return;
            }
            //用户--否决--行为
            //U--(UID,AID)--A

            //1.判断控制器和行为是否符合
            string controller = RouteData.GetRequiredString("controller");
            string action = RouteData.GetRequiredString("action");
            //lamada表达式
            var actioninfo1 = actionInfoService.GetList(m => 
                (m.ControllerName.ToLower() == controller.ToLower())
                && 
                (m.ActionName.ToLower() == action.ToLower())
                &&
                (m.IsDeleted==false)).FirstOrDefault();

            if (actioninfo1 == null)
            {
                //无权访问
                filterContext.Result = Redirect("/NoActions.html");
                return;
            }
            //2.判断权限
            //2.1 获取否决数据,判断是否为空
            
            var userinfo1 = userinfoservice.GetList(m => m.UserId == CurrentLoginUserInfo.UserId).FirstOrDefault();
            
            //lamada表达式
            //var useraction1=userinfo1.UserAction.Where(ua=>ua.ActionId==actioninfo1.ActionId).FirstOrDefault();
            //linq
            var useraction1 = (from u in userinfo1.UserAction
                              where u.ActionId==actioninfo1.ActionId
                              select u).FirstOrDefault();
        
            //2.2.1如果为空,否则
            if (useraction1 != null)
            {
                //2.2.2是否允许
                if(useraction1.IsAllow==true)
                {

                }
                else
                {
           
         //无权访问
                    filterContext.Result = Redirect("/NoActions.html");
                    return;
                }
            }
            else
            {
                //2.3用户——角色--权限
                var roleinfo1=userinfo1.RoleInfo;
                var actioninfosResult =( from r in roleinfo1
                                  from a in r.ActionInfo
                                  where a.ActionId == actioninfo1.ActionId
                                  select a).ToList();
               // var actioninfosResult1 = roleinfo1.Where(m => m.ActionInfo.Where(a => a.ActionId == actioninfo1.ActionId));
                //2.3.1如果为空,否则
                if(actioninfosResult.Count>0)
                {
                    
                    
                }
                else
                {
                    filterContext.Result = Redirect("/NoActions.html");
                    return;

                }
                
            }
            


            #endregion

        }

        //protected override void OnAuthentication(System.Web.Mvc.Filters.AuthenticationContext filterContext)
        //{
        //    base.OnAuthentication(filterContext);
        //    //mm+cookie验证
        //    //1.取出cookies中的值
        //    if (Request.Cookies.Get("LoginId") == null)
        //    {
        //        //浏览器给服务器发请求必须返回一个结果，所以执行完过滤器后仍然执行了相应的动作返回一个ActionResult
        //        //filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
        //        //这样在过滤器就已经返回了一个结果给浏览器

        //        filterContext.Result = Redirect("/UserLogin/Index");
        //        return;
        //    }
        //    string key = Request.Cookies.Get("LoginId").Value;
        //    //拿cookies中的值与mm服务器中的值进行校验
        //    MemcachedHelper mm = new MemcachedHelper();
        //    ui = mm.get(key) as UserInfo;
        //    if (ui == null)
        //    {
        //        filterContext.Result = Redirect("/UserLogin/Index");
        //        return;

        //    }
        //    //滑动时间
        //    mm.set(key, ui, DateTime.Now.AddMinutes(20));

        //}
	}
}

