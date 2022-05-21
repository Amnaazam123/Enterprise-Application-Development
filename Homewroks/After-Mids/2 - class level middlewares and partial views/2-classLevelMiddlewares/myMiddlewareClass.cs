//projectName->rightclick->add->class

using Microsoft.AspNetCore.Http;          //for RequestDelegate 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lec17
{
    public class myMiddlewareClass
    {
        RequestDelegate next;
        //constructor
        public myMiddlewareClass(RequestDelegate nextDelegate)
        {
            this.next = nextDelegate;
        }
        //what task you wanna perform from this middleware, mention in this function.
        //name of function must be Invoke or InvokeAsync.
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("class level middleware");
            await next(context);         //this line will move you to go to next middleware in startup.cs file 
        }
        
    }
}
