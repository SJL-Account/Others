using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.Model;
using DLOA.IService;

namespace DLOA.UI.Controllers
{
    public class HomeController :BaseController //Controller
    {
        IActionInfoService actionservice { get; set; }
        
        // GET: Home
        public ActionResult Index()
        {

            // A:用户--角色--权限（可能有被否决的）
            var userinfo=userinfoservice.GetList(m=>m.UserId==CurrentLoginUserInfo.UserId).FirstOrDefault();
            var roleinfo = userinfo.RoleInfo;
            var URactioninfo = (from r in roleinfo
                             from a in r.ActionInfo
                             where a.IsMenu==true&&a.IsDeleted==false
                             select a).ToList();

            // B:用户---权限true
            var actioninfos =from a in userinfo.UserAction //Collections
                             where a.IsAllow==true
                             select a.ActionInfo;//items

            var Uactioninfo = (from a in actioninfos
                              where a.IsMenu==true
                              select a).ToList();

            // A+B
            URactioninfo.AddRange(Uactioninfo);
            // C:用户---权限false（把被否决的干掉）
            var NOTactioninfosId = from a in userinfo.UserAction //Collections
                              where a.IsAllow == false
                              select a.ActionInfo.ActionId;//items
            //D=A+B-C
            var URactionAllow= URactioninfo.Where(ura => !NOTactioninfosId.Contains(ura.ActionId));
            // D:distinct
            var lastActionInfo = (URactionAllow.Distinct(new DLOA.Model.EqualityComparer())).ToList();


            ViewData["UserName"] = CurrentLoginUserInfo.UserName;
            ////权限过滤
            ////1.1查询所有菜单权限
            //List<ActionInfo> ActionListAll = (actionservice.GetList(m => (m.IsDeleted == false) && (m.IsMenu == true))).ToList();
            //List<ActionInfo> actionlist = new List<ActionInfo>();
            ////1.2当前登录的用户对象
            //ViewData["UserName"] = DLOA.UI.Models.Data.userinfo.UserName;
            //UserInfo userinfo = ui;
            ////1.3遍历所有的桌面权限

            ////  List<UserAction> ua= (userinfo.UserAction.Where(m => m.IsAllow ==true)).ToList();
            ////  if (ua.Count != 0)
            //  {
            //    foreach (var item in ua)
            //  {

            //      actionlist .Add(item.ActionInfo);

            //      foreach (var item1 in actionlist)
            //      {
            //          item1.RoleInfo.
            //      }

            //   }
        
    
            //}

            //2查出在否决表中允许的权限

            //3.用户找角色,角色找权限,有就加到集合中

            //4.排除否决表中拒绝的权限

            //var actionlist = 

            //最终要的是一个actionList
             return View(lastActionInfo);
        }
    }
}