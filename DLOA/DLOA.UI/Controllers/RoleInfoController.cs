using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.Service;
using DLOA.IService;
using DLOA.Model;
using DLOA.Common;
namespace DLOA.UI.Controllers
{
    public class RoleInfoController : Controller//BaseController// Controller
    {
       
        //
        // GET: /RoleInfo/

        IRoleInfoService service { get; set; }
        IActionInfoService actionService { get; set; }
        //
        // GET: /Role/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            string Result = "no";
            RoleInfo roleinfo = new RoleInfo();
            roleinfo.RoleName=Request.Form["RoleName"];
            if(string.IsNullOrEmpty(Request.Form["Remark"]))
            {
                roleinfo.Remark = "";

            }
            else
            {
                roleinfo.Remark = Request.Form["Remark"];
                
            }
            
            roleinfo.SubBy = 1;
            roleinfo.IsDeleted = false;
            roleinfo.SubTime = DateTime.Now;
            if(service.Add(roleinfo))
            {
                Result = "ok";
                //return RedirectToAction("Index","RoleInfo");

            }
    
                return Content(Result);

        

        }
        [HttpPost]
        public ActionResult GetListByPage(int page,int rows)
        {
            int total=0;
            //从客户端接受数据
            int RoleId=  string.IsNullOrEmpty(Request.Form["RoleId"]) ? 0 : int.Parse(Request.Form["RoleId"]);
            string RoleName = string.IsNullOrEmpty(Request.Form["RoleName"]) ? "" : Request.Form["RoleName"];

            

            WhereHelper<RoleInfo> where = new WhereHelper<RoleInfo> ();
            where.Equal("IsDeleted", false);
            if(RoleId!=0)
            {
                where.Equal("RoleId", RoleId);

            }
            if(RoleName!="")
            {
                where.Contains("RoleName", RoleName);
            }
            IQueryable<RoleInfo> rolelist = service.GetListByPage<int>(where.GetExpression(), m => m.RoleId, page, rows, out total);

            var temp = from r in rolelist
                       select new
                       {
                           RoleId=r.RoleId,
                           RoleName=r.RoleName,
                           Remark=r.Remark
                       };
            return Json(new { total, rows = temp }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            RoleInfo rolelist= service.GetById(id);
            return View(rolelist);
        }
        [HttpPost]
        public ActionResult Edit(RoleInfo roleinfo)
        {
            string Result = "no";
            roleinfo.SubBy = 1;
            roleinfo.SubTime = DateTime.Now;
            roleinfo.IsDeleted = false;
            if(roleinfo.Remark==null)
            {
                roleinfo.Remark = "";
            }
            if(service.Edit(roleinfo))
            {
                Result = "ok";
            }
            
            return Content(Result);
        }
        public ActionResult Remove()
        {
            string Result = "no";
            string a = Request.Form["ids"];
            string[] ids = (a).Split(',');
            List<int> list = new List<int>();
            foreach (var item in ids)
            {
                list.Add(int.Parse(item));
            }
            if(service.Remove(list.ToArray()))
            {
                Result = "ok";
            }
            return Content(Result);
        }
       
        public ActionResult SetAction(int rid)
        {
          IQueryable<ActionInfo> actioninfos=  actionService.GetList(m=>m.IsDeleted==false);
          ViewData["rid"] = rid;
          ViewBag.RoleInfo = service.GetById(rid);
          return View(actioninfos);
        }
        [HttpPost]
        public ActionResult SetAction(string ids, int RoleId)
        {
            string Result = "no";
            if(service.SetAction(RoleId,ids))
            {
                Result = "ok";
            }
            return Content(Result);
        }
    }

    
}