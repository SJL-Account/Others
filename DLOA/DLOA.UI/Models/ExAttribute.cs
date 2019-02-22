using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLOA.UI.Models
{
    public class ExAttribute:HandleErrorAttribute
    {
        //队列
        public static Queue<Exception> ExQueue = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            //异常出现
            Exception ex = filterContext.Exception;
            //写到队列
            ExQueue.Enqueue(ex);
            //跳到错误页
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}