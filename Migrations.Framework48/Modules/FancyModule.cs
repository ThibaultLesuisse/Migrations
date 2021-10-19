using System;
using System.Web;

namespace Migrations.Framework48.Modules
{
    public class FancyModule : IHttpModule
    {
        public void Dispose()
        {
            //I Should clean up
        }

        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += (sender, e) => context.Context.Response.Headers.Add("X-AcquireRequestState", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            context.BeginRequest += (sender, e) => context.Context.Response.Headers.Add("X-BeginRequest", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            context.EndRequest += (sender, e) => context.Context.Response.Headers.Add("X-EndRequest", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            context.MapRequestHandler += (sender, e) => context.Context.Response.Headers.Add("X-MapRequestHandler", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
            context.AuthenticateRequest += (sender, e) => context.Context.Response.Headers.Add("X-AutenticateRequest", DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString());
        }
    }
}