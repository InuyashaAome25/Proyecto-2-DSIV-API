using System.Web;
using System.Web.Mvc;

namespace Proyecto_2_API_Rest_DSIV
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
