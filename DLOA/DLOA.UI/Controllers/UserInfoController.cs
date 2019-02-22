using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLOA.Service;
using DLOA.Model;
using DLOA.IService;
using DLOA.Common;


namespace DLOA.UI.Controllers
{
    public class UserInfoController : BaseController// Controller
    {

        //service 属性的值通过Spring.Net的IOC创建对象实体并DI赋初始值
        public IUserInfoService service { get; set; }
        public IRoleInfoService roleService { get; set; }
        public IActionInfoService actionService { get; set; }

        // GET: UserInfo
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 参数和表单名一致，将自动填充
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>

        public ActionResult GetListByPage(int page, int rows)
        {
            //接受请求报文
            int UserId = string.IsNullOrEmpty(Request.Form["UserId"]) ? 0 : int.Parse(Request.Form["UserId"]);
            string UserName = string.IsNullOrEmpty(Request.Form["UserName"]) ? "" : Request.Form["UserName"];
            int total = 0;


            //改造前
            //IQueryable<UserInfo> UserInfoList1 = service.GetListByPage<DateTime>(m => (m.IsDeleted==false)
            //   &&(UserId==0?true:m.UserId==UserId)
            //   &&(UserName==""?true:m.UserName.Contains(UserName))
            //,m=>m.SubTime, page,rows,out total);


            //改造后
            //1==1表达式树
            WhereHelper<UserInfo> where = new WhereHelper<UserInfo>();
            //m.IsDeleted==false
            where.Equal("IsDeleted", false);
            //UserId==0?true:m.UserId==UserId
            if (UserId != 0)
            {
                where.Equal("UserId", UserId);

            }
            //UserName==""?true:m.UserName.Contains(UserName
            if (!string.IsNullOrEmpty(UserName))
            {
                where.Contains("UserName", UserName);
            }


            IQueryable<UserInfo> UserInfoList = service.GetListByPage<DateTime>(where.GetExpression(), m => m.SubTime, page, rows, out total);


            //这里避免出现引用重复的错误
            var temp = from u in UserInfoList
                       select new
                       {
                           UserId = u.UserId,
                           UserName = u.UserName,

                           SubTime = u.SubTime
                       };

            return Json(new { total, rows =temp }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add()
        {
            string result = "no";
            UserInfo userinfo = new UserInfo();
            
            userinfo.UserName = Request.Form["UserName"];
            userinfo.UserPwd = MD5Helper.EncryptString(Request.Form["UserPwd"]);
            if (Request.Form["Remark"] == null)
            {
                userinfo.Remark = "";

            }
            else
            {
                userinfo.Remark = Request.Form["Remark"];

            }
            userinfo.IsDeleted = false;
            userinfo.SubBy = 1;
            userinfo.SubTime = DateTime.Now;
            if (service.Add(userinfo))
            {
                result="ok";
            }

            return Content(result);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserInfo u = service.GetById(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult Edit(UserInfo userinfo)
        {
            string result = "no";
            userinfo.SubBy = 1;
            userinfo.SubTime = DateTime.Now;
            userinfo.IsDeleted = false;
            if (Request.Form["UserPwd"].Trim() != "")
            {

                userinfo.UserPwd = MD5Helper.EncryptString( Request.Form["UserPwd"]);
            }
            else
            {
                userinfo.UserPwd = Request.Form["UserPwdHidden"];
            }
            if(userinfo.Remark==null)
            {
                userinfo.Remark = "";
            }
            if (service.Edit(userinfo))
            {
                result = "ok";
            }
            return Content(result);


        }
        [HttpPost]
        public ActionResult Remove()
        {
            string result="no";
            string idList = Request.Form["idList"];
            
            string[] ids = idList.Split(',');           
            List<int> list = new List<int>();
            //字符数组转成int数组
            foreach (var item in ids)
            {
                list.Add(int.Parse(item));
            }

            if(service.Remove(list.ToArray()))
            {
                result = "ok";
            }
            return Content(result);
        }

        public ActionResult SetRole(int id)
        {
            UserInfo userinfo= service.GetById(id);
            ViewBag.UserInfo = userinfo;
            ViewData["id"] = id;

            IQueryable<RoleInfo> rolelist = roleService.GetList(m=>m.IsDeleted==false);

            return View(rolelist);
        }
        [HttpPost]
        public ActionResult SetRole()
        {
            string Result = "no";
            string UserId=Request.Form["UserId"];
            string[] ids =Request.Form["idList"].Split(',');
            if(service.SetRole(UserId,ids))
            {
                Result = "ok";
            }
            
            return Content(Result);
        }

        public ActionResult SetAction(int uid)
        {
            //列出所有权限
            ViewData.Model = (actionService.GetList(m=>m.IsDeleted==false)).ToList();
            //传uid
            ViewData["uid"] = uid;
            return View();
       }
        [HttpPost]
        public ActionResult SetAction(int uid,int aid,int isAllow)
        {
            string Result = "no";
            if(service.SetAction(uid,aid,isAllow))
            {
                Result="ok";
            }
            return Content(Result);
        }
    }
}