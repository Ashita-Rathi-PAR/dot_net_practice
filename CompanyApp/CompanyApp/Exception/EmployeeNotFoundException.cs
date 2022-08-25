using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CompanyApp.Service;

namespace CompanyApp.Exception
{
    public class EmployeeNotFoundException : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            ViewResult view = new ViewResult();
            view.ViewName = "EmployeeNotFoundError";
            filterContext.Result = view;
            filterContext.ExceptionHandled = true;
        }
    }
}
