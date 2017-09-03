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
    public class RawItemController : Controller
    {
        #region class members
        private IRawItemMasterBL _itemService;
        #endregion

        #region Constructors for dependency injections
        public RawItemController(IRawItemMasterBL itemservice)
        {
            _itemService = itemservice;
        }
        #endregion Constructors for dependency injections

        #region Controller Actions
        // GET: RawItem
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            RawItemMasterViewModel model = new RawItemMasterViewModel();
            model.Mode = PageMode.Add;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RawItemMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<RawItemMaster> result = null;

                    model.Mode = PageMode.Add;
                    RawItemMaster rawitemdetails = new RawItemMaster();
                    ConvertViewModelToDomainObject(model, rawitemdetails);
                    result = _itemService.Add(rawitemdetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionRawItemList);
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

        public ActionResult Edit(Guid itemId)
        {
            RawItemMasterViewModel model = new RawItemMasterViewModel();

            try
            {
                RawItemMaster rawItemDetails = _itemService.GetRawItemDetails(itemId);
                ConvertDomainObjectToViewModel(model, rawItemDetails);
                model.Mode = PageMode.Edit;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionRawItemEdit, model);
        }

        [HttpPost]
        public ActionResult Edit(RawItemMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<RawItemMaster> result = null;

                    RawItemMaster rawitemdetails = new RawItemMaster();
                    ConvertViewModelToDomainObject(model, rawitemdetails);
                    rawitemdetails.ItemId = model.ItemId;
                    result = _itemService.RawItemUpdate(rawitemdetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionRawItemList);
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

        public ActionResult RawItemList(RawItemListViewModel rawItemViewDatails)
        {
            try
            {
                IEnumerable<RawItemMaster> rawItemList = _itemService.GetRawItemListAll();
                ConvertDataObjectModelToViewModel(rawItemList, rawItemViewDatails);
                return View(rawItemViewDatails);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        public ActionResult Details(Guid itemId)
        {
            RawItemMasterViewModel model = new RawItemMasterViewModel();

            try
            {
                RawItemMaster rawItemDetails = _itemService.GetRawItemDetails(itemId);
                ConvertDomainObjectToViewModel(model, rawItemDetails);
                model.Mode = PageMode.Details;
            }
            catch(Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionRawItemCreate, model);
        }

        #endregion Controller Action

        #region Conversion Methods
        private void ConvertViewModelToDomainObject(RawItemMasterViewModel model, RawItemMaster rawitemdetails)
        {
            rawitemdetails.ItemName = model.ItemName;
            rawitemdetails.Material = model.Material;
            rawitemdetails.UnitId = model.UnitId;
            rawitemdetails.BrandId = model.BrandId;
            rawitemdetails.Color = model.Color;
            rawitemdetails.ItemTypeId = model.ItemTypeId;
            rawitemdetails.Description1 = model.Description1;
            rawitemdetails.Description2 = model.Description2;
            rawitemdetails.Description3 = model.Description3;
            rawitemdetails.Description4 = model.Description4;
            rawitemdetails.Description5 = model.Description5;
        }

        public void ConvertDomainObjectToViewModel(RawItemMasterViewModel model, RawItemMaster rawitemdetails)
        {
            model.ItemName = rawitemdetails.ItemName;
            model.Material = rawitemdetails.Material;
            model.Color = rawitemdetails.Color;
            model.UnitId = rawitemdetails.UnitId;
            model.BrandId = rawitemdetails.BrandId;
            model.ItemTypeId = rawitemdetails.ItemTypeId;
            model.Description1 = rawitemdetails.Description1;
            model.Description2 = rawitemdetails.Description2;
            model.Description3 = rawitemdetails.Description3;
            model.Description4 = rawitemdetails.Description4;
            model.Description5 = rawitemdetails.Description5; 
        }

        private void ConvertDataObjectModelToViewModel(IEnumerable<RawItemMaster> rawItemList, RawItemListViewModel rawItemViewDatails)
        {
            rawItemViewDatails.RawItemList = rawItemList.Select(x => new RawItemMaster()
            {
                ItemId = x.ItemId,
                ItemName = x.ItemName,
                Material = x.Material,
                Color = x.Color,
                Description1 = x.Description1
            }).ToList();
        }

        #endregion
    }
}