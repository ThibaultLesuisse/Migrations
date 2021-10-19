using System;
using System.Web.Mvc.Filters;

namespace Migrations.Framework48.Filters
{
    public class FancyAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-OnAuthentication", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //Add logic when Authentication failed, maybe a header? Logging?   
        }
    }
}