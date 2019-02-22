using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.IService;
using DLOA.Model;
using DLOA.Service;


namespace DLOA.UI.Controllers
{
    public class ActionInfoController :Controller//BaseController// Controller
    {
        public IActionInfoService service { get; set; }
        //
        // GET: /ActionInfo/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListByPage(int page,int rows)
        {   
            int total;
            var ActionList = service.GetListByPage<int>(u => u.IsDeleted == false, u => u.ActionId, page, rows, out total).Select(m => new 
            {   m.ActionId, 
                m.ActionName, 
                m.ActionTitle, 
                m.IsDeleted, 
                m.MenuIcon, 
                m.Remark, 
                m.ControllerName,
                m.IsMenu 
            });



            return Json(new { total, rows = ActionList }, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public ActionResult Add()
        {
            string Result = "no";
            ActionInfo actioninfo = new ActionInfo();
            actioninfo.ActionName = Request.Form["ActionName"];
            actioninfo.ActionTitle = Request.Form["ActionTitle"];
            actioninfo.ControllerName = Request.Form["ControllerName"];
            actioninfo.Remark = Request.Form["Remark"];
            actioninfo.SubBy = 1;
            actioninfo.SubTime = DateTime.Now;
            actioninfo.MenuIcon = Request.Form["IconUrl"];
            if(string.IsNullOrEmpty(Request.Form["IsMenu"]))
            {
                actioninfo.IsMenu = false;
            }
            else
            {
                actioninfo.IsMenu = true;
            }
            actioninfo.IsDeleted =false;
            if(service.Add(actioninfo))
            {
                Result = "ok";
            }
            return Content(Result); ;
        }
        [HttpPost]
        public ActionResult UpLoadIcon()
        {
            //拼接文件了路径和文件名
            var file = Request.Files["IconName"];
            string Path = "/WebDisk/UpLoadImage/";
            string fileName = Path + Guid.NewGuid().ToString() + file.FileName;
            //保存
            file.SaveAs(Server.MapPath(fileName));
            return Content(fileName);
        }
        public ActionResult Edit(int id)
        {
           ActionInfo actioninfo=  service.GetById(id);
           return View(actioninfo);
        }
        [HttpPost]
        public ActionResult Edit(ActionInfo actionInfo)
        {
            string Result="no";
            
            if (string.IsNullOrEmpty(Request.Form["IconUrl"]))
            {
                actionInfo.MenuIcon = null;
            }
            else
            {
                
                actionInfo.MenuIcon = Request.Form["IconUrl"];
            }
            if(actionInfo.Remark==null)
            {
                actionInfo.Remark = "";
            }
            actionInfo.SubBy = 1;
            actionInfo.SubTime = DateTime.Now;
           if(service.Edit(actionInfo))
            {
               Result="ok";
            }

           return Content(Result);
        }
        public ActionResult Remove()
        {
            string Result = "no";
            string idList = Request.Form["idList"];
            string[] ids = idList.Split(',');
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
	}
}