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
    public class StoreController : Controller
    {
        #region class members
        private IStoreMasterBL _storeService;
        #endregion

        #region Constructors for dependency injections
        public StoreController(IStoreMasterBL storeservice)
        {
            _storeService = storeservice;
        }
        #endregion Constructors for dependency injections

        #region Controller Actions
        [HttpGet]
        public ActionResult Create()
        {
            StoreMasterViewModel model = new StoreMasterViewModel();
            model.Mode = PageMode.Add;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(StoreMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<StoreMaster> result = null;

                    model.Mode = PageMode.Add;
                    StoreMaster storedetails = new StoreMaster();
                    ConvertViewModelToDomainObject(model, storedetails);
                    result = _storeService.Add(storedetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionStoreList);
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

        public ActionResult Details(int storeId)
        {
            StoreMasterViewModel model = new StoreMasterViewModel();
            try
            {
                StoreMaster storeDetails = _storeService.GetStoreDetails(storeId);
                ConvertDomainObjectToViewModel(model, storeDetails);
                model.Mode = PageMode.Details;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionRawItemCreate, model);
        }

        public ActionResult Edit(int storeId)
        {
            StoreMasterViewModel model = new StoreMasterViewModel();
            try
            {
                StoreMaster storeDetails = _storeService.GetStoreDetails(storeId);

                ConvertDomainObjectToViewModel(model, storeDetails);
                model.Mode = PageMode.Edit;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionStoreEdit, model);
        }

        [HttpPost]
        public ActionResult Edit(StoreMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<StoreMaster> result = null;

                    StoreMaster storedetails = new StoreMaster();
                    ConvertViewModelToDomainObject(model, storedetails);
                    storedetails.StoreId = model.StoreId;
                    storedetails.AddressId = model.AddressId;
                    result = _storeService.StoreUpdate(storedetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionStoreList);
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

        public ActionResult StoreList(StoreListViewModel storeViewDatails)
        {
            try
            {
                IEnumerable<StoreMaster> storeList = _storeService.GetStoreListAll();
                ConvertDataObjectModelToViewModel(storeList, storeViewDatails);
                return View(storeViewDatails);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }
        #endregion

        #region Conversion Methods
        private void ConvertViewModelToDomainObject(StoreMasterViewModel model, StoreMaster storedetails)
        {
            storedetails.Type = model.Type;
            storedetails.Name = model.Name;

            AddressMaster storeAddress = new AddressMaster();
            storeAddress.AddressId = model.AddressId;
            storeAddress.AddressLine1 = model.AddressLine1;
            storeAddress.AddressLine2 = model.AddressLine2;
            storeAddress.CityId = model.CityId;
            storeAddress.Pincode = model.Pincode;

            //Make a List Address
            storedetails.StoreAddressList = new List<AddressMaster>();
            storedetails.StoreAddressList.Add(storeAddress);
        }

        private void ConvertDomainObjectToViewModel(StoreMasterViewModel model, StoreMaster storeDetails)
        {
            model.StoreId = storeDetails.StoreId;
            model.Type = storeDetails.Type;
            model.Name = storeDetails.Name;
            model.AddressId = storeDetails.AddressId;
            model.AddressLine1 = storeDetails.StoreAddressDetails.AddressLine1;
            model.AddressLine2 = storeDetails.StoreAddressDetails.AddressLine2;
            model.StateId = storeDetails.State.StateId;
            model.CityId = storeDetails.StoreAddressDetails.CityId;
            model.Pincode = storeDetails.StoreAddressDetails.Pincode;
        }

        private void ConvertDataObjectModelToViewModel(IEnumerable<StoreMaster>  storeList, StoreListViewModel storeViewDatails)
        {
            storeViewDatails.StoreList = storeList.Select(x => new StoreMaster()
            {
                StoreId = x.StoreId,
                Type = x.Type,
                Name = x.Name
            }).ToList();
        }
        #endregion
    }
}