using System;
using System.Web.Mvc;

namespace Migrations.Framework48.Filters
{
    public class FancyAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-OnAuthorization", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
        }
    }
}