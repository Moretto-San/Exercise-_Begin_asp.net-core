using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CodersAcademy.Middleware
{
    public static class LogActionMiddleware
    {

        public static void LogRequest(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Use(async (context, next) =>
            {
                await next.Invoke();
                await Task.Factory.StartNew(() =>
                {
                    var headers = JsonConvert.SerializeObject(context.Request.Headers);
                    var query = JsonConvert.SerializeObject(context.Request.QueryString);
                    Console.WriteLine("Executando o Path: {0}", context.Request.Path);
                    if (context.Request.ContentType != null
                    && context.Request.ContentType != "application/javascript"
                    && context.Request.Method == "POST")
                        Console.WriteLine("Executando o Body: {0}", JsonConvert.SerializeObject(context.Request.Body));
                    Console.WriteLine("Executando o Query: {0}", query);
                    Console.WriteLine("Executando o Headers: {0}", headers);
                });
            });
        }
    }
}
