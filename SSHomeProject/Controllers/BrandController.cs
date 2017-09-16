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
    public class BrandController : Controller
    {
        #region class members
        private IBrandMasterBL _brandService;
        #endregion

        #region Constructors for dependency injections
        public BrandController(IBrandMasterBL brandservice)
        {
            _brandService = brandservice;
        }
        #endregion Constructors for dependency injections

        #region Controller Actions
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BrandMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<BrandMaster> result = null;

                    BrandMaster branddetails = new BrandMaster();
                    branddetails.Name = model.Name;
                    result = _brandService.Add(branddetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionBrandList);
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
        public ActionResult Edit(int brandId)
        {
            BrandMasterViewModel model = new BrandMasterViewModel();
            
            try
            {
                BrandMaster branddeatails = _brandService.GetbrandDetails(brandId);
                model.BrandId = branddeatails.BrandId;
                model.Name = branddeatails.Name;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(CommonConstant.ActionBrandEdit, model);
        }

        [HttpPost]
        public ActionResult Edit(BrandMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Result<BrandMaster> result = null;

                    BrandMaster brandeditdetails = new BrandMaster();

                    brandeditdetails.BrandId = model.BrandId;
                    brandeditdetails.Name = model.Name;

                    result = _brandService.UpdateBrandDetails(brandeditdetails);

                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionBrandList);
                    }
                    else
                    {
                        ModelState.AddModelError("", "");
                    }
                }
            }
            catch(Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        public ActionResult BrandList(BrandListViewModel model)
        {
            try
            {
                IEnumerable<BrandMaster> brandList = _brandService.GetAll();
                ConvertDataObjectModelToViewModel(brandList, model);
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
        private void ConvertDataObjectModelToViewModel(IEnumerable<BrandMaster> brandlist, BrandListViewModel model)
        {
            model.brandList = brandlist.Select(x => new BrandMaster()
            {
                BrandId = x.BrandId,
                Name = x.Name
            }).ToList();
        }
        #endregion

    }
}