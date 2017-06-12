using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSHomeProject.Controllers
{
    public class RawItemController : Controller
    {
        #region class members

        #endregion

        #region Constructors for dependency injections

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
            return View();
        }
        #endregion Controller Action
    }
}