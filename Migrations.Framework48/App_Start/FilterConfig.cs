using Migrations.Framework48.Filters;
using System.Web.Mvc;

namespace Migrations.Framework48
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new FancyExceptionFilter());
            filters.Add(new FancyAuthenticationFilter());
            filters.Add(new FancyAuthorizationFilter());
            filters.Add(new FancyActionFilter());
        }
    }
}
