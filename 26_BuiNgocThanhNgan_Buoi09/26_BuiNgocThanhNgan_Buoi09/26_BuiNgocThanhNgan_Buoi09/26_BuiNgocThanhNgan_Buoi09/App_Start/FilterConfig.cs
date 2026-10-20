using System.Web;
using System.Web.Mvc;

namespace _26_BuiNgocThanhNgan_Buoi09
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
