using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.IService;
using DLOA.Service;
using DLOA.Model;
namespace DLOA.UI.Controllers
{
    public class WorkFlowModelController : BaseController
    {

        //
        // GET: /WorkFlowModel/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListByPage(int page,int rows)
        {
            int total=0;
           IQueryable<WorkFlowModel> workflowList= workFlowModelService.GetListByPage<int>(m=>m.IsDeleted==false,m=>m.ModelId,page,rows,out total);
           return Json(new { total = total, rows = workflowList },JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add()
        {
            string Result = "no";
            WorkFlowModel workflowmodel = new WorkFlowModel();
            workflowmodel.ModelTitle = Request.Form["ModelTitle"];
            workflowmodel.ControllerName = Request.Form["ControllerName"];
            workflowmodel.ActionName = Request.Form["ActionName"];
            if (Request.Form["Remark"]==null)
            {
                workflowmodel.Remark ="";

            }
            else
            {
                workflowmodel.Remark = Request.Form["Remark"];

            }
            workflowmodel.SubBy = CurrentLoginUserInfo.UserId;
            workflowmodel.SubTime = DateTime.Now;
            workflowmodel.IsDeleted = false;

           if(workFlowModelService.Add(workflowmodel))
            {
                Result="ok";
            }
           return Content(Result);
        }

        
        public ActionResult Edit(int id)
        {
           WorkFlowModel workflowmodel= workFlowModelService.GetList(m=>m.ModelId==id).FirstOrDefault();
           return View(workflowmodel);
        }
        [HttpPost]
        public ActionResult Edit(WorkFlowModel wfm)
        {
            string Result = "no";
            wfm.SubBy = CurrentLoginUserInfo.UserId;
            wfm.SubTime = DateTime.Now;
            wfm.IsDeleted = false;
            wfm.ModelId =Convert.ToInt32( Request.Form["ModelId"]);
            if (string.IsNullOrEmpty(Request.Form["Remark"]))
            {
                wfm.Remark = "";

            }
            if(workFlowModelService.Edit(wfm))
            {
                Result = "ok";
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
            if (workFlowModelService.Remove(list.ToArray()))
            {
                Result = "ok";
            }
            return Content(Result); 
        }
	}
}