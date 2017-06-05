using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSHomeProject.Helpers
{
    public static class AjaxExtension
    {
        /// <summary>
        /// Check request header to determine if it is a Ajax request or not
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return (request.Headers["X-Requested-With"] != null &&
                string.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.OrdinalIgnoreCase));
        }
    }
}