using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace HrApi
{
    public class CancellationTokenExceptionFilter: IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        //After
        public void OnActionExecuted(ActionExecutedContext context) 
        { 
            if(context.Exception is TaskCanceledException)
            {
                Console.WriteLine("Got that cancellation");
                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = 500
                };
                context.ExceptionHandled = true;
            }           
        }

        //Before
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Nothing to see here.
            //throw new NotImplementedException();
        }
    }
}
