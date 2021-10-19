using Migrations.Framework48.Controllers;
using System.Web.Mvc;

namespace Migrations.Framework48.Filters
{
    public class FancyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //Replace the result with the result of the error controller
            filterContext.ExceptionHandled = true;
            var errorController = new ErrorController();
            filterContext.Result = errorController.Index();
        }
    }
}