//middleware basics

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddleWares
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {

        }
        //this method is used to create middleware.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //after deleting bultin code, creating custom middleware
            //use method is used to create middleware.
            app.Use(
                //will learn for async programming.
                async (context, next) =>              //context parameter is used for response or request.
                {
                    context.Response.ContentType = "text/plain";          //mentioning response type
                    await context.Response.WriteAsync("Aoa! Pakistan");   //modifying response
                    await next();                                         //to go for next middleware.
                    await context.Response.WriteAsync("\nI am first middleware.");

                }
                );

            //creating another middleware
            app.Use(
                async (context, next) =>              
                {      
                    await context.Response.WriteAsync("\nAoa! Pakistan Again");
                    await next();
                    await context.Response.WriteAsync("\nI am second last middleware.");
                }
                );
            //if you want to terminate middlewre, donot add "await next()" line in middleware.
            //or
            app.Run(async (context) =>       //no next parameter becaue it is last middleware.
            {
                await context.Response.WriteAsync("\nI am last middleware.");
            });
        }
    }
}
