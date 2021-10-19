using System;
using System.Web.Mvc;

namespace Migrations.Framework48.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FancyActionFilter : ActionFilterAttribute, IActionFilter, IResultFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-OnActionExecuted", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-OnActionExecuting", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-OnResultExecuted", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("X-OnResultExecuting", DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
        }
    }
}