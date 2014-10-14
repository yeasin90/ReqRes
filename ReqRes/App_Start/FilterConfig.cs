using ReqRes.ActionAttribute;
using System.Web;
using System.Web.Mvc;

namespace ReqRes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogAttribute());
        }
    }
}