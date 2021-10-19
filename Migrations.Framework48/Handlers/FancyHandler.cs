using System;
using System.Web;

namespace Migrations.Framework48.Handlers
{
    public class FancyHandler : IHttpHandler
    {
        static int _count = 0;
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Headers.Add("X-FancyHandler", _count++.ToString());
        }
    }
}