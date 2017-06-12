using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSHomeProject.Unity;
using SSHomeBusinessLayerTypes;

namespace SSHomeProject.Helpers
{
    public static class DropDownHelper
    {

        #region YesNoList

        public static IList<SelectListItem> YesNoList(int selectedId = 0, string defaultString = "-- Select --")
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = defaultString, Value = "0", Selected = (0 == selectedId) },
                new SelectListItem { Text = "Yes", Value = "1", Selected = (1 == selectedId) },
                new SelectListItem { Text = "No", Value = "2", Selected = (2 == selectedId) }
            };
        }

        #endregion YesNoList

        public static IList<SelectListItem> UnitList(int selectedId = 0, string defaultString = "-- Select Unit --")
        {
            // declare local variables here            
            List<SelectListItem> list = new List<SelectListItem>();

            IUnitMasterBL bl = BootStrapper.Get<IUnitMasterBL>();

            list.Add(new SelectListItem { Text = defaultString, Value = "0" }); // add default item

            // get Unit            
            bl.GetAll().ToList().ForEach(unt => list.Add(new SelectListItem
            {
                Text = unt.Unit,
                Value = unt.UnitId.ToString(CultureInfo.InvariantCulture),
                Selected = (unt.UnitId == selectedId)
            }));

            return list;
        }

        public static IList<SelectListItem> BrandList(int selectedId =0, string defaultString ="-- Select Brand --")
        {
            //declare Local variable
            List<SelectListItem> list = new List<SelectListItem>();

            IBrandMasterBL bl = BootStrapper.Get<IBrandMasterBL>();

            //Add Default Item in the List
            list.Add(new SelectListItem { Text = defaultString, Value = "0" });

            //Get Brand
            bl.GetAll().ToList().ForEach(brnd => list.Add(new SelectListItem
            {
                Text = brnd.Name,
                Value = brnd.BrandId.ToString(CultureInfo.InstalledUICulture),
                Selected = (brnd.BrandId == selectedId)
            }));

           return list;
        }

    }
}