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

        public const string ControllerRawItem = "RawItem";
        public const string ControllerReadyItem = "ReadyItem";
        public const string ControllerReadyRawItem = "ReadyRawItem";
        public const string ControllerBrand = "Brand";
        public const string ControllerUnit = "Unit";
        public const string ControllerItemType = "ItemType";
        public const string ControllerReferral = "Referral";
        public const string ControllerCustomerType = "CustomerType";
        public const string ControllerStore = "Store";
        public const string ControllerVendor = "Vendor";
        public const string ControllerClient = "Client";
        public const string ControllerSpecification = "Specification";       

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

        public const string ActionRawItemCreate = "Create";
        public const string ActionRawItemEdit = "Edit";
        public const string ActionRawItemDetails = "Details";
        public const string ActionRawItemList = "RawItemList";

        public const string ActionReadyItemCreate = "Create";
        public const string ActionReadyItemEdit = "Edit";
        public const string ActionReadyItemDetails = "Details";
        public const string ActionReadyItemList = "ReadyItemList";

        public const string ActionReadyRawItemCreate = "Create";
        public const string ActionReadyRawItemEdit = "Edit";
        public const string ActionReadyRawItemDetails = "Details";
        public const string ActionReadyRawItemList = "ReadyRawItemList";

        public const string ActionBrandCreate = "Create";
        public const string ActionBrandEdit = "Edit";
        public const string ActionBrandList = "BrandList";

        public const string ActionUnitCreate = "Create";
        public const string ActionUnitEdit = "Edit";
        public const string ActionUnitList = "UnitList";

        public const string ActionItemTypeCreate = "Create";
        public const string ActionItemTypeEdit = "Edit";
        public const string ActionItemTypeList = "ItemTypeList";

        public const string ActionReferralCreate = "Create";
        public const string ActionReferralEdit = "Edit";
        public const string ActionReferralList = "ReferralList";

        public const string ActionCustomerTypeCreate = "Create";
        public const string ActionCustomerTypeEdit = "Edit";
        public const string ActionCustomerTypeList = "CustomerTypeList";

        public const string ActionStoreCreate = "Create";
        public const string ActionStoreDetails = "Details";
        public const string ActionStoreEdit = "Edit";
        public const string ActionStoreList = "StoreList";

        public const string ActionVendorCreate = "Create";
        public const string ActionVendorDetails = "Details";
        public const string ActionVendorEdit = "Edit";
        public const string ActionVendorList = "VendorList";

        public const string ActionClientCreate = "Create";
        public const string ActionClientDetails = "Details";
        public const string ActionClientEdit = "Edit";
        public const string ActionClientList = "ClientList";

        public const string ActionSpecificationCreate = "Create";
        public const string ActionSpecificationIndex = "Index";

        #endregion Action Methods

        #region Views Constants

        public const string ViewRawItemUCRawItemList = "UCRawItemList";

        public const string ViewReadyItemUCRawItemList = "UCReadyItemList";

        public const string ViewReadyRawItemUCRawItemList = "UCReadyRawItemList";

        public const string ViewBrandUCBrandList = "UCBrandList";

        public const string ViewUnitUCUnitList = "UCUnitList";

        public const string ViewItemUCItemTypeList = "UCItemTypeList";

        public const string ViewReferralUCReferralList = "UCReferralList";

        public const string ViewCustomerTypeUCCustomerTypeList = "UCCustomerTypeList";

        public const string ViewStoreUCStoreList = "UCStoreList";

        public const string ViewVendorUCVendorList = "UCVendorList";

        public const string ViewClientUCClientList = "UCClientList";

        public const string ViewAdminUCSearchSpecification = "UCSearchSpecification";
        public const string ViewAdminUCSpecification = "UCSpecification";


        public const string ViewErrorAjaxError = "~/Views/Error/AjaxError.cshtml";
        public const string ViewErrorInternalError = "~/Views/Error/InternalError.cshtml";
        public const string ViewErrorBadRequest = "~/Views/Error/BadRequest.cshtml";
        public const string ViewErrorResourceNotFound = "~/Views/Error/ResourceNotFound.cshtml";
        public const string ViewErrorUnauthorize = "~/Views/Error/Unauthorize.cshtml";
                
        #endregion

        #region Column Constant

        public const string ColumnAddressId = "AddressId";
        public const string ColumnAddressLine1 = "AddressLine1";
        public const string ColumnAddressLine2 = "AddressLine2";
        public const string ColumnPincode = "Pincode";
        public const string ColumnCityId = "CityId";

        #endregion

        #region Cache Constant
        public const string CacheSpecification = "Specification";
        public const string CacheValue = "Value";
        public const string CacheExpirationTimeInHours = "CacheExpirationTimeInHours";
        #endregion    

    }
}
