using MvcContrib.UI.Grid;
using PagedList;
using SSHomeBusinessLayerTypes;
using SSHomeCommon;
using SSHomeCommon.Constants;
using SSHomeCommon.Helpers;
using SSHomeDatalayerCommon;
using SSHomeDataModel;
using SSHomeProject.Content.ResourceFiles;
using SSHomeProject.Helpers;
using SSHomeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSHomeProject.Controllers
{
    public class SpecificationController : Controller
    {
        #region class members
        private ISpecificationCatalogueBL _service;
        #endregion

        #region constructors for dependency injections
        public SpecificationController()
        {

        }
        public SpecificationController(ISpecificationCatalogueBL service)
        {
            _service = service;
        }
        #endregion


        #region controller methods
        // GET: Specification
        public ActionResult Index(int? page, GridSortOptions sortOption, SpecificationCatalogueViewModel model)
        {
            IEnumerable<SpecificationCatalogue> listSpecificationCatalogue = null;
            int totalResult = 0;
            listSpecificationCatalogue = SearchProductCategories(model, page, sortOption, out totalResult);
            model.Specifications = new StaticPagedList<SpecificationCatalogue>(listSpecificationCatalogue, page ?? 1, ConfigHelper.GetPageSize(), totalResult);
            model.ValueType = GetValueType();
            model.GridSortOptions = sortOption;

            if (model.IsPartialView)
            {
                return PartialView(CommonConstant.ViewAdminUCSpecification, model);
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Create()
        {
            SpecificationCatalogueViewModelForAdd model = new SpecificationCatalogueViewModelForAdd();
            model.SpecificationList = GetSpecifications();
            model.ValueTypeList = GetValueType();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(SpecificationCatalogueViewModelForAdd model)
        {
            if (ModelState.IsValid)
            {
                Result<SpecificationCatalogue> result = null;

                SpecificationCatalogue specificationCatalogue = new SpecificationCatalogue();
                ConvertViewModelToDomainObject(model, specificationCatalogue);

                result = _service.Add(specificationCatalogue);

                // return result
                if (result.Status == ResultStatus.Success)
                {
                    model.Id = result.Model.Id;
                    // Remove item from cache since new item has been added
                    CacheHelper.RemoveItem(CommonConstant.CacheSpecification);
                    

                    return RedirectToAction(CommonConstant.ActionSpecificationIndex, CommonConstant.ControllerSpecification);
                }
                else
                {
                    ModelState.AddModelError("", AdminResource.GeneralErrorMessage);
                }
            }

            model.SpecificationList = GetSpecifications();
            model.ValueTypeList = GetValueType();
            return View(model);
        }
        #endregion

        #region private supporting methods
        private IList<SelectListItem> GetSpecifications()
        {
            List<SpecificationCatalogue> lstSpecificationCatalogue = null;

            // Check if Category exist in cache
            bool isAvailableInCache = CacheHelper.TryGet<List<SpecificationCatalogue>>(CommonConstant.CacheSpecification, out lstSpecificationCatalogue);

            if (!isAvailableInCache)
            {
                // Since category data is not in cache make database call to get category
                lstSpecificationCatalogue = _service.GetAll().ToList();

                // Save Category in Cache for future reference
                CacheHelper.Add<List<SpecificationCatalogue>>(CommonConstant.CacheSpecification, lstSpecificationCatalogue);
            }

            IList<SelectListItem> lstSelectListItem = new List<SelectListItem>();

            if (lstSpecificationCatalogue != null && lstSpecificationCatalogue.Count > 0)
            {
                lstSpecificationCatalogue.ForEach(spec => lstSelectListItem.Add(
                    new SelectListItem
                    {
                        Text = spec.Name,
                        Value = Convert.ToString(spec.Id)
                    }
                ));
            }

            return lstSelectListItem;
        }

        private IList<SelectListItem> GetValueType()
        {
            List<ValueTypeMaster> lstValueType = null;

            // Check if Category exist in cache
            bool isAvailableInCache = CacheHelper.TryGet<List<ValueTypeMaster>>(CommonConstant.CacheValue, out lstValueType);

            if (!isAvailableInCache)
            {
                // Since category data is not in cache make database call to get category
                lstValueType = _service.GetAllValueType().ToList();

                // Save Category in Cache for future reference
                CacheHelper.Add<List<ValueTypeMaster>>(CommonConstant.CacheValue, lstValueType);
            }

            IList<SelectListItem> lstSelectListItem = new List<SelectListItem>();

            if (lstValueType != null && lstValueType.Count > 0)
            {
                lstValueType.ForEach(val => lstSelectListItem.Add(
                    new SelectListItem
                    {
                        Text = val.Name,
                        Value = Convert.ToString(val.ValueTypeId)
                    }
                ));
            }

            return lstSelectListItem;
        }

        private void ConvertViewModelToDomainObject(SpecificationCatalogueViewModelForAdd model, SpecificationCatalogue specificationCatalogue)
        {
            specificationCatalogue.Code = model.SpecificationCode;
            specificationCatalogue.Name = model.SpecificationName;
            specificationCatalogue.ParentId = model.ParentSpecificationId;
            specificationCatalogue.ValueTypeId = model.ValueTypeId;
            specificationCatalogue.CreatedBy = 1;
        }

        private IEnumerable<SpecificationCatalogue> SearchProductCategories(SpecificationCatalogueViewModel specificationviewmodel, int? page, GridSortOptions sortOption, out int totalResultCount)
        {
            IEnumerable<SpecificationCatalogue> productCategoryList = null;
            totalResultCount = 0;
            Criteria criteria = GetCriteria(page, specificationviewmodel, sortOption);
            criteria.Parameters.Add(new Parameter { Name = "SpecificationCode", Value = specificationviewmodel.SpecificationCode });
            criteria.Parameters.Add(new Parameter { Name = "SpecificationName", Value = specificationviewmodel.SpecificationName });
            criteria.Parameters.Add(new Parameter { Name = "ValueTypeId", Value = specificationviewmodel.ValueTypeId });
            productCategoryList = _service.GetPage(criteria, out totalResultCount);
            return productCategoryList;
        }

        private Criteria GetCriteria(int? page, SpecificationCatalogueViewModel viewmodel, GridSortOptions sortOption)
        {
            Criteria criteria = CriteriaHelper.New().Add(page);

            return criteria;
        }


        #endregion
    }
}