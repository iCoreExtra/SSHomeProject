using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeCommon.Constants
{
    public class CommonConstant
    {

        #region Controller

        public const string ControllerError = "Error";
        public const string ControllerSpecification = "Specification";
        public const string ActionSpecificationIndex = "Index";

        #endregion

        #region Action Methods

        public const string ActionErrorInternalError = "InternalError";
        public const string ActionErrorResourceNotFound = "ResourceNotFound";
        public const string ActionErrorBadRequest = "BadRequest";
        public const string ActionErrorUnauthorize = "Unauthorize";
        public const string ActionErrorAjaxError = "AjaxError";


        public const string ActionSpecificationCreate = "Create";
        public const string ViewAdminUCSearchSpecification = "UCSearchSpecification";
        public const string ViewAdminUCSpecification = "UCSpecification";

        #endregion Action Methods

        #region Config Constant
        public const string CacheExpirationTimeInHours = "CacheExpirationTimeInHours";
        #endregion

        #region Cache Constant
        public const string CacheSpecification = "Specification";
        public const string CacheValue = "Value";
        #endregion

    }
}
