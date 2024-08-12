using System.Web;
using System.Web.Mvc;

namespace IZUMUClientes.WebApp2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
