using System.Web.Mvc;
using SSHomeCommon.Helpers;
using SSHomeCommon.Constants;

namespace SSHomeProject.Filters
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            //Log exception
            SSHomeLogger.LogException(filterContext.Exception);

            string viewName = string.Empty;

            // if the request is AJAX return ajax error view  
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                viewName = CommonConstant.ViewErrorAjaxError;
            }
            else
            {

                viewName = CommonConstant.ViewErrorInternalError;
            }

            string controllerName = filterContext.RouteData.Values["controller"] as string;
            string actionName = filterContext.RouteData.Values["action"] as string;

            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult
            {
                ViewName = viewName,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}