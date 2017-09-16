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
    public class ItemTypeController : Controller
    {
        #region class membersy
        private IItemTypeMasterBL _itemTypeService;
        #endregion

        #region Constructors for dependency injections
        public ItemTypeController(IItemTypeMasterBL itemservice)
        {
            _itemTypeService = itemservice;
        }
        #endregion Constructors for dependency injections

        #region controller method
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ItemTypeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<ItemTypeMaster> result = null;

                    ItemTypeMaster itemdetails = new ItemTypeMaster();
                    itemdetails.Name = model.Name;
                    result = _itemTypeService.Add(itemdetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionItemTypeList);
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
        public ActionResult Edit(int itemTypeId)
        {
            ItemTypeMasterViewModel model = new ItemTypeMasterViewModel();

            try
            {
                ItemTypeMaster itemdeatails = _itemTypeService.GetItemTypeDetails(itemTypeId);
                model.ItemTypeId = itemdeatails.ItemTypeId;
                model.Name = itemdeatails.Name;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ItemTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Result<ItemTypeMaster> result = null;

                    ItemTypeMaster itemtypeeditdetails = new ItemTypeMaster();

                    itemtypeeditdetails.ItemTypeId = model.ItemTypeId;
                    itemtypeeditdetails.Name = model.Name;

                    result = _itemTypeService.UpdateItemTypeDetails(itemtypeeditdetails);

                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionItemTypeList);
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

        public ActionResult ItemTypeList(ItemTypeListViewModel model)
        {
            try
            {
                IEnumerable<ItemTypeMaster> itemTypeList = _itemTypeService.GetAll();
                ConvertDataObjectModelToViewModel(itemTypeList, model);
                return View(model);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        #endregion

        #region Conversion Methods
        private void ConvertDataObjectModelToViewModel(IEnumerable<ItemTypeMaster> itemTypeList, ItemTypeListViewModel model)
        {
            model.itemTypeList = itemTypeList.Select(x => new ItemTypeMaster()
            {
                ItemTypeId = x.ItemTypeId,
                Name = x.Name
            }).ToList();
        }
        #endregion

    }
}