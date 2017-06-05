using System;
using System.Web.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SSHomeCommon.Helpers;
using SSHomeProject.Helpers;
using SSHomeCommon.Constants;
using SSHomeProject.Controllers;
using SSHomeProject.Unity;

namespace SSHomeProject
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootStrapper.Initialise();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                HttpContext httpContext = ((MvcApplication)sender).Context;
                Exception ex = Server.GetLastError();

                Controller controller = new ErrorController();
                RouteData routeData = new RouteData();
                string action = string.Empty;
                string currentController = string.Empty;
                string currentAction = string.Empty;
                RouteData currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

                if (currentRouteData != null)
                {
                    if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                    {
                        currentController = currentRouteData.Values["controller"].ToString();
                    }

                    if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                    {
                        currentAction = currentRouteData.Values["action"].ToString();
                    }
                }
                //Log Exception
                SSHomeLogger.LogException(ex);
                // Redirect to error controller
                if (ex is HttpException)
                {
                    var httpEx = ex as HttpException;

                    int exCode = !AjaxExtension.IsAjaxRequest(httpContext.Request) ? httpEx.GetHttpCode() : -999; //-999 :Ajax Request Code

                    switch (exCode)
                    {

                        case 400://Bad Request
                        case 413:// Request Entity Too Large
                        case 414:// Request-URI Too Long
                            action = CommonConstant.ActionErrorBadRequest;
                            break;
                        case 401: //Unauthorized access
                        case 403: //Forbidden
                            action = CommonConstant.ActionErrorUnauthorize;
                            break;
                        case 404: // this error will not come if there is route entry for unknown URL
                            action = CommonConstant.ActionErrorResourceNotFound;
                            break;
                        case -999: //Ajax Request Custom Code
                            action = CommonConstant.ActionErrorAjaxError;
                            break;
                        default://Internal server error
                            action = CommonConstant.ActionErrorInternalError;
                            break;
                    }
                }

                httpContext.ClearError();
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = ex is HttpException ? ((HttpException)ex).GetHttpCode() : 500;
                httpContext.Response.TrySkipIisCustomErrors = true;

                routeData.Values["controller"] = CommonConstant.ControllerError;
                routeData.Values["action"] = action;
                controller.ViewData.Model = new HandleErrorInfo(ex, currentController, currentAction);
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
                Server.ClearError();
            }
            catch (Exception exception)
            {
                SSHomeLogger.LogException(exception);
            }
        }
    }
}
