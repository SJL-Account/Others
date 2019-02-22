using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDiary.Models;

namespace MyDiary.Controllers
{
    public class HomeController : Controller
    {
        DiaryDB db = new DiaryDB();
        //
        // GET: /Home/

        public ActionResult Index()
        {

            int PageNum=db.Diaries.Where(m=>true).Count();
            int PageSize=5;
            int PageCount =Convert.ToInt32( Math.Ceiling((double) PageNum / PageSize));
            //if(PageNum%PageSize==0)
            //{
            //    PageCount=PageNum/PageSize;
            //}
            //else
            //{
            //    PageCount=PageNum/PageSize+1;

            //}
            int PageNow;
            if(!int.TryParse(Request["PageNow"],out PageNow))
            {
                PageNow = 1;
            }

            //PageCount-PageNow
            if(Session["User"]==null)
            {
                return RedirectToAction("Login","Account");
            }
             int id = ((MyDiary.Models.User)Session["User"]).Id;
            
             List<Diary> Daries= (db.Diaries.Where(m=>m.UserId==id).OrderByDescending<Diary,DateTime?>(n=>n.PubDate).Skip<Diary>((PageNow-1)*PageSize).Take<Diary>(PageSize)).ToList();
            //IQueryable<Diary> Daries = db.Diaries.Where(m => m.UserId == id); IQueryable具有延迟加载机制
            //IEnumerable
            ViewData["PageCount"]=PageCount;
            ViewData["PageNow"]=PageNow;
             return View(Daries);
        }

    }
}
