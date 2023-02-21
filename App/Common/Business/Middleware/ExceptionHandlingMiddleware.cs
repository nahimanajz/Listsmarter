using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_intro_1.Common.Business.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CSharp_intro_1.Common.Business.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }
            catch(Exception ex) { 
                context.Response.StatusCode = 500;
                context.Response.ContentType= "application/json";
                await context.Response.WriteAsync("{ \"error\": \"" + ex.Message + "\"}");
            }
        }
    }
}

