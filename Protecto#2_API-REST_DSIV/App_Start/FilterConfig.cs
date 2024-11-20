using System.Web;
using System.Web.Mvc;

namespace Protecto_2_API_REST_DSIV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
