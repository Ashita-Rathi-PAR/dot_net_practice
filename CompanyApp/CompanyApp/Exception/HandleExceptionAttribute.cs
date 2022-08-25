using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CompanyApp.Exception
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ViewResult view = new ViewResult();
            view.ViewName = "Error";
            filterContext.Result = view;
            filterContext.ExceptionHandled = true;
        }
    }
}

