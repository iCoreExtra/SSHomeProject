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
    public class UnitController : Controller
    {
        #region class members

        private IUnitMasterBL _unitService;

        #endregion private

        #region Constructors for dependency injections
        public UnitController(IUnitMasterBL unitservices)
        {
            _unitService = unitservices;
        }
        #endregion Constructors for dependency injections

        // GET: Unit
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UnitMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<UnitMaster> result = null;

                    UnitMaster unitDetails = new UnitMaster();
                    unitDetails.Unit = model.Unit;
                    result = _unitService.Add(unitDetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionUnitList);
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
        public ActionResult Edit(int unitId)
        {
            UnitMasterViewModel model = new UnitMasterViewModel();
            try
            {
                UnitMaster unitdeatails = _unitService.GetunitDetails(unitId);
                model.UnitId = unitdeatails.UnitId;
                model.Unit = unitdeatails.Unit;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UnitMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Result<UnitMaster> result = null;

                    UnitMaster uniteditdetails = new UnitMaster();

                    uniteditdetails.UnitId = model.UnitId;
                    uniteditdetails.Unit = model.Unit;

                    result = _unitService.UpdateUnitDetails(uniteditdetails);

                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionUnitList);
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

        public ActionResult UnitList(UnitListViewModel model)
        {
            try
            {
                IEnumerable<UnitMaster> unitList = _unitService.GetAll();
                ConvertDataObjectModelToViewModel(unitList, model);
                return View(model);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        #region Conversion Methods
        private void ConvertDataObjectModelToViewModel(IEnumerable<UnitMaster> unitList, UnitListViewModel model)
        {
            model.unitList = unitList.Select(x => new UnitMaster()
            {
                 UnitId= x.UnitId,
                 Unit = x.Unit
            }).ToList();
        }
        #endregion
    }
}