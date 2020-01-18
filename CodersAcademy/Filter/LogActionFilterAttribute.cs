using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace CodersAcademy.Filter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private Stopwatch reloginho = new Stopwatch();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            reloginho.Start();
            base.OnActionExecuting(context);
            Console.WriteLine("Executando o controle {0} para acao {1}", context.Controller.GetType().Name, context.ActionDescriptor.DisplayName);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            reloginho.Stop();
            Console.WriteLine("Tempinho: " + new DateTime(reloginho.Elapsed.Ticks).ToString("mm.ss.fffff"));
            Console.WriteLine("Terminando o controle {0} para acao {1}", context.Controller.GetType().Name, context.ActionDescriptor.DisplayName);
        }
    }
}
