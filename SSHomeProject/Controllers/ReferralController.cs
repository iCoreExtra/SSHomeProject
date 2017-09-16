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
    public class ReferralController : Controller
    {
        #region class members

        private IReferralMasterBL _referralService;

        #endregion private

        #region Constructors for dependency injections
        public ReferralController(IReferralMasterBL referralservices)
        {
            _referralService = referralservices;
        }
        #endregion Constructors for dependency injections

        // GET: Unit
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReferralMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Result<ReferralMaster> result = null;

                    ReferralMaster referralDetails = new ReferralMaster();
                    referralDetails.Source = model.Source;
                    result = _referralService.Add(referralDetails);
                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionReferralList);
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
        public ActionResult Edit(int referralId)
        {
            ReferralMasterViewModel model = new ReferralMasterViewModel();
            try
            {
                ReferralMaster referraldeatails = _referralService.GetReferralDetails(referralId);
                model.ReferralId = referraldeatails.ReferralId;
                model.Source = referraldeatails.Source;
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ReferralMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Result<ReferralMaster> result = null;

                    ReferralMaster referraleditdetails = new ReferralMaster();

                    referraleditdetails.ReferralId = model.ReferralId;
                    referraleditdetails.Source = model.Source;

                    result = _referralService.UpdateReferralDetails(referraleditdetails);

                    if (result.Status == ResultStatus.Success)
                    {
                        return RedirectToAction(CommonConstant.ActionReferralList);
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

        public ActionResult ReferralList(ReferralListViewModel model)
        {
            try
            {
                IEnumerable<ReferralMaster> referralList = _referralService.GetAll();
                ConvertDataObjectModelToViewModel(referralList, model);
                return View(model);
            }
            catch (Exception ex)
            {
                SSHomeLogger.LogException(ex);
            }

            return View();
        }

        #region Conversion Methods
        private void ConvertDataObjectModelToViewModel(IEnumerable<ReferralMaster> referralList, ReferralListViewModel model)
        {
            model.referralList = referralList.Select(x => new ReferralMaster()
            {
                ReferralId = x.ReferralId,
                Source = x.Source
            }).ToList();
        }
        #endregion


    }
}