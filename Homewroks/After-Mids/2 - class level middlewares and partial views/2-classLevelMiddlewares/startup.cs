using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using classLevelMiddlewares;
using Lec17;

namespace classLevelMiddlewares
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        //output=>helloclass level middlewarehello2
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello");
                
            });

            
            //the following line of code will automatically call Invoke Function
            app.UseMiddleware<myMiddlewareClass>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello2");
                
            });

        }
    }
}
