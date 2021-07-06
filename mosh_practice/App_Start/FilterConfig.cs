using System.Web;
using System.Web.Mvc;

namespace mosh_practice
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute()); //只能使用https連線
        }
    }
}
