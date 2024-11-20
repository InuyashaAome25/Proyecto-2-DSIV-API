using System.Web;
using System.Web.Mvc;

namespace Proyecto_2_DS_IV_API_REST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
