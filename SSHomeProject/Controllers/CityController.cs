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
using Newtonsoft.Json;

namespace SSHomeProject.Controllers
{
    public class CityController : Controller
    {
        #region class members

        private ICityMasterBL _cityService;

        #endregion private

        #region Constructors for dependency injections
        public CityController(ICityMasterBL cityservices)
        {
            _cityService = cityservices;
        }
        #endregion Constructors for dependency injections

        #region Controller Action Methods
        public string GetAllByStateId(int stateId)
        {
            // declare local variables here            
            IList<CityMaster> var_list = new List<CityMaster>();
            try
            {
                var_list = _cityService.GetAll(stateId);
            }
            catch (Exception ex)
            {
                // possibility of loogin the error using Log4Net
                return null;
                ModelState.AddModelError(string.Empty, ex);
            }
            return JsonConvert.SerializeObject(var_list);
        }
        #endregion

    }
}