using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeCommon.Constants
{
    public class CommonConstant
    {
        #region Configuration constants

        public const string ConnectionString = "SSHomeConnectionString";
        public const string ErrorLogSource = "ErrorLogSource";

        #endregion

        /// <summary>
        /// Constant variable for controller
        /// Naming convention of variable in this region should be prefix with word Controller followed by controller name
        /// for e.g to create constant for HomeController constant name should be ControllerHome
        /// </summary>
        #region Controller Constants

        public const string ControllerError = "Error";

        #endregion

        /// <summary>
        /// Constant variable for controller action method
        /// Naming convention of variable in this region should be prefix with word Action followed by controller name followed by Action method name
        /// for e.g to create constant for Index method of HomeController constant name should be ActionHomeIndex
        /// </summary>
        #region Action Methods Constants

        public const string ActionErrorInternalError = "InternalError";
        public const string ActionErrorResourceNotFound = "ResourceNotFound";
        public const string ActionErrorBadRequest = "BadRequest";
        public const string ActionErrorUnauthorize = "Unauthorize";
        public const string ActionErrorAjaxError = "AjaxError";

        #endregion Action Methods

        #region Views Constants

        public const string ViewErrorAjaxError = "~/Views/Error/AjaxError.cshtml";
        public const string ViewErrorInternalError = "~/Views/Error/InternalError.cshtml";
        public const string ViewErrorBadRequest = "~/Views/Error/BadRequest.cshtml";
        public const string ViewErrorResourceNotFound = "~/Views/Error/ResourceNotFound.cshtml";
        public const string ViewErrorUnauthorize = "~/Views/Error/Unauthorize.cshtml";

        #endregion

    }
}
