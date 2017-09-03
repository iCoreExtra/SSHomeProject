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
    public class VendorController : Controller
    {
        #region class members
        private IVendorMasterBL _vendorService;
        #endregion

        #region Constructors for dependency injections
        public VendorController(IVendorMasterBL vendorservice)
        {
            _vendorService = vendorservice;
        }
        #endregion Constructors for dependency injections

        #region Controller Actions
        [HttpGet]
        public ActionResult Create()
        {
            VendorMasterViewModel model = new VendorMasterViewModel();
            model.Mode = PageMode.Add;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VendorMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<VendorMaster> result = null;

                    model.Mode = PageMode.Add;
                    VendorMaster vendordetails = new VendorMaster();
                    ConvertViewModelToDomainObject(model, vendordetails);
                    result = _vendorService.Add(vendordetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionVendorList);
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
            model.Mode = PageMode.Add;
            return View(model);
        }

        public ActionResult VendorList(VendorListViewModel vendorViewDatails)
        {
            try
            {
                IEnumerable<VendorMaster> vendorList = _vendorService.GetVendorListAll();
                ConvertDataObjectModelToViewModel(vendorList, vendorViewDatails);
                return View(vendorViewDatails);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        public ActionResult Details(int vendorId)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();
            try
            {
                VendorMaster vendorDetails = _vendorService.GetVendorDetails(vendorId);
                ConvertDomainObjectToViewModel(model, vendorDetails);
                model.Mode = PageMode.Details;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionVendorCreate, model);
        }

        public ActionResult Edit(int vendorId)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();
            try
            {
                VendorMaster vendorDetails = _vendorService.GetVendorDetails(vendorId);

                ConvertDomainObjectToViewModel(model, vendorDetails);
                model.Mode = PageMode.Edit;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionStoreEdit, model);
        }

        [HttpPost]
        public ActionResult Edit(VendorMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<VendorMaster> result = null;

                    VendorMaster vendordetails = new VendorMaster();
                    ConvertViewModelToDomainObject(model, vendordetails);
                    vendordetails.VendorId = model.VendorId;
                    vendordetails.AddressId = model.AddressId;
                    result = _vendorService.VendorUpdate(vendordetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionVendorList);
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
            return View();
        }

        #endregion

        #region Conversion Methods
        private void ConvertViewModelToDomainObject(VendorMasterViewModel model, VendorMaster vendordetails)
        {
            vendordetails.FirstName = model.FirstName;
            vendordetails.LastName = model.LastName;
            vendordetails.CompanyName = model.CompanyName;
            vendordetails.Contact1 = model.Contact1;
            vendordetails.Contact2 = model.Contact2;
            vendordetails.Email1 = model.Email1;
            vendordetails.Email2 = model.Email2;
            vendordetails.GSTNo = model.GSTNo;

            AddressMaster vendorAddress = new AddressMaster();
            vendorAddress.AddressId = model.AddressId;
            vendorAddress.AddressLine1 = model.AddressLine1;
            vendorAddress.AddressLine2 = model.AddressLine2;
            vendorAddress.CityId = model.CityId;
            vendorAddress.Pincode = model.Pincode;

            //Make a List Address
            vendordetails.VendorAddressList = new List<AddressMaster>();
            vendordetails.VendorAddressList.Add(vendorAddress);
        }

        private void ConvertDomainObjectToViewModel(VendorMasterViewModel model, VendorMaster vendorDetails)
        {
            model.VendorId = vendorDetails.VendorId;
            model.FirstName = vendorDetails.FirstName;
            model.LastName = vendorDetails.LastName;
            model.CompanyName = vendorDetails.CompanyName;
            model.Contact1 = vendorDetails.Contact1;
            model.Contact2 = vendorDetails.Contact2;
            model.Email1 = vendorDetails.Email1;
            model.Email2 = vendorDetails.Email2;
            model.GSTNo = vendorDetails.GSTNo;
            model.AddressId = vendorDetails.AddressId;
            model.AddressLine1 = vendorDetails.VendorAddressDetails.AddressLine1;
            model.AddressLine2 = vendorDetails.VendorAddressDetails.AddressLine2;
            model.StateId = vendorDetails.State.StateId;
            model.CityId = vendorDetails.VendorAddressDetails.CityId;
            model.Pincode = vendorDetails.VendorAddressDetails.Pincode;
        }

        private void ConvertDataObjectModelToViewModel(IEnumerable<VendorMaster> vendorList, VendorListViewModel vendorViewDatails)
        {
            vendorViewDatails.VendorList = vendorList.Select(x => new VendorMaster()
            {
                VendorId = x.VendorId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CompanyName = x.CompanyName,
                Contact1 = x.Contact1,
                Email1 = x.Email1
            }).ToList();
        }
        #endregion
    }
}