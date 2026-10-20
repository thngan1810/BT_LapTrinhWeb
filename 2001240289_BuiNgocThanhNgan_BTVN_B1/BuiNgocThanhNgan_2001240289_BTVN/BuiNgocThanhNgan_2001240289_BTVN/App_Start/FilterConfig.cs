using System.Web;
using System.Web.Mvc;

namespace BuiNgocThanhNgan_2001240289_BTVN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
