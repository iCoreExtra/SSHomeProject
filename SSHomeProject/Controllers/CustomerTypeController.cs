using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSHomeProject.Models;
using SSHomeCommon.Helpers;
using SSHomeDataModel;
using SSHomeCommon;
using SSHomeBusinessLayerTypes;
using SSHomeDatalayerCommon;
using SSHomeCommon.Enums;
using SSHomeCommon.Constants;

namespace SSHomeProject.Controllers
{
    public class CustomerTypeController : Controller
    {
        #region class members

        private ICustomerTypeMasterBL _customerTypeService;

        #endregion private

        #region Constructors for dependency injections
        public CustomerTypeController(ICustomerTypeMasterBL customertypeservices)
        {
            _customerTypeService = customertypeservices;
        }
        #endregion Constructors for dependency injections

        // GET: CustomerTypeMaster
        // GET: Unit
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerTypeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<CustomerTypeMaster> result = null;

                    CustomerTypeMaster customerTypeDetails = new CustomerTypeMaster();
                    customerTypeDetails.CustomerType = model.CustomerType;
                    result = _customerTypeService.Add(customerTypeDetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionCustomerTypeList);
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
                catch (Exception ex)
                {
                    SSHomeLogger.LogException(ex);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int customerTypeId)
        {
            CustomerTypeMasterViewModel model = new CustomerTypeMasterViewModel();
            try
            {
                CustomerTypeMaster customertypedeatails = _customerTypeService.GetCustomerTypeDetails(customerTypeId);
                model.CustomerTypeId = customertypedeatails.CustomerTypeId;
                model.CustomerType = customertypedeatails.CustomerType;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Result<CustomerTypeMaster> result = null;

                    CustomerTypeMaster customertypeeditdetails = new CustomerTypeMaster();

                    customertypeeditdetails.CustomerTypeId = model.CustomerTypeId;
                    customertypeeditdetails.CustomerType = model.CustomerType;

                    result = _customerTypeService.UpdateCustomerTypeDetails(customertypeeditdetails);

                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionCustomerTypeList);
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        public ActionResult CustomerTypeList(CustomerTypeListViewModel model)
        {
            try
            {
                IEnumerable<CustomerTypeMaster> customerTypeList = _customerTypeService.GetAll();
                ConvertDataObjectModelToViewModel(customerTypeList, model);
                return View(model);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        #region Conversion Methods
        private void ConvertDataObjectModelToViewModel(IEnumerable<CustomerTypeMaster> customertypeList, CustomerTypeListViewModel model)
        {
            model.customerTypeList = customertypeList.Select(x => new CustomerTypeMaster()
            {
                CustomerTypeId = x.CustomerTypeId,
                CustomerType = x.CustomerType
            }).ToList();
        }
        #endregion
    }
}