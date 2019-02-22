using System.Web;
using System.Web.Mvc;
using DLOA.UI.Models;
namespace DLOA.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //添加自己写的过滤器
           //filters.Add(new ExAttribute());
        }
    }
}
