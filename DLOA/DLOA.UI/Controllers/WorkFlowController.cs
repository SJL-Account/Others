using DLOA.IService;
using DLOA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLOA.UI.Controllers
{
    public class WorkFlowController:BaseController
    {


        //
        // GET: /WorkFlow/
        public ActionResult Index()
        {
            IQueryable<WorkFlowModel> WorkFlowModellist = workFlowModelService.GetList(m => m.IsDeleted == false);
            //获取当前用户下所有的实例状态
            ViewBag.Instance = workFlowInstanceService.GetList(m=>m.SubBy==CurrentLoginUserInfo.UserId);
           
            return View(WorkFlowModellist);


        }
        public ActionResult ApplyStart()
        {

            return View();
        }

        public ActionResult Approve()
        {
            return View();
        }
	}
}