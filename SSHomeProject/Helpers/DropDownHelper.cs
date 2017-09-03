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

        //Get Reference List
        public static IList<SelectListItem> ReferenceList(int selectedId = 0, string defaultString = "-- Select Reference --")
        {
            // declare local variables here            
            List<SelectListItem> list = new List<SelectListItem>();

            IReferralMasterBL bl = BootStrapper.Get<IReferralMasterBL>();

            list.Add(new SelectListItem { Text = defaultString, Value = "0" }); // add default item

            // get Unit            
            bl.GetAll().ToList().ForEach(unt => list.Add(new SelectListItem
            {
                Text = unt.Source,
                Value = unt.ReferralId.ToString(CultureInfo.InvariantCulture),
                Selected = (unt.ReferralId == selectedId)
            }));

            return list;
        }

        //Get Store List
        public static IList<SelectListItem> StoreList(int selectedId = 0, string defaultString = "-- Select Store --")
        {
            // declare local variables here            
            List<SelectListItem> list = new List<SelectListItem>();

            IStoreMasterBL bl = BootStrapper.Get<IStoreMasterBL>();

            list.Add(new SelectListItem { Text = defaultString, Value = "0" }); // add default item

            // get Unit            
            bl.GetStoreListAll().ToList().ForEach(unt => list.Add(new SelectListItem
            {
                Text = unt.Name,
                Value = unt.StoreId.ToString(CultureInfo.InvariantCulture),
                Selected = (unt.StoreId == selectedId)
            }));

            return list;
        }

        //Get Customer Type List
        public static IList<SelectListItem> CustomerTypeList(int selectedId = 0, string defaultString = "-- Select Customer Type --")
        {
            // declare local variables here            
            List<SelectListItem> list = new List<SelectListItem>();

            ICustomerTypeMasterBL bl = BootStrapper.Get<ICustomerTypeMasterBL>();

            list.Add(new SelectListItem { Text = defaultString, Value = "0" }); // add default item

            // get Unit            
            bl.GetAll().ToList().ForEach(unt => list.Add(new SelectListItem
            {
                Text = unt.CustomerType,
                Value = unt.CustomerTypeId.ToString(CultureInfo.InvariantCulture),
                Selected = (unt.CustomerTypeId == selectedId)
            }));

            return list;
        }


        // state by countryid
        public static IList<SelectListItem> StateByCountryList(int countryId = 0, int selectedId = 0, string defaultString = "-- Select State --")
        {
            // declare local variables here            
            List<SelectListItem> list = new List<SelectListItem>();
            int var_pagecount = 0;

            IStateMasterBL bl = BootStrapper.Get<IStateMasterBL>();

            if (countryId > 1)
            {
                defaultString = "-- Select Province --";
            }

            list.Add(new SelectListItem { Text = defaultString, Value = "0" }); // add default item

            if (countryId == 0) return list; // added by chirag against original code

            // get categories            
            bl.GetAll(countryId).ToList().ForEach(cat => list.Add(new SelectListItem
            {
                Text = cat.StateName,
                Value = cat.StateId.ToString(CultureInfo.InvariantCulture),
                Selected = (cat.StateId == selectedId)
            }));

            return list;
        }

        // city by stateid
        public static IList<SelectListItem> CityByStateList(int stateId = 0, int selectedId = 0, string defaultString = "-- Select City --")
        {
            // declare local variables here            
            List<SelectListItem> list = new List<SelectListItem>();
            int var_pagecount = 0;

            ICityMasterBL bl = BootStrapper.Get<ICityMasterBL>();

            list.Add(new SelectListItem { Text = defaultString, Value = "0" }); // add default item

            if (stateId == 0) return list; // added by chirag against original code

            // get categories            
            bl.GetAll(stateId).ToList().ForEach(cat => list.Add(new SelectListItem
            {
                Text = cat.CityName,
                Value = cat.CityId.ToString(CultureInfo.InvariantCulture),
                Selected = (cat.CityId == selectedId)
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

        public static IList<SelectListItem> ItemTypeList(int selectedId =0, string defaultString ="-- Select Item Type--")
        {
            List<SelectListItem> list = new List<SelectListItem>();

            IItemTypeMasterBL bl = BootStrapper.Get<IItemTypeMasterBL>();

            //Add Default Item in the List
            list.Add(new SelectListItem { Text = defaultString, Value = "0" });

            //Get Item Type
            bl.GetAll().ToList().ForEach(itmtyp => list.Add(new SelectListItem
            {
                Text = itmtyp.Name,
                Value = itmtyp.ItemTypeId.ToString(CultureInfo.InstalledUICulture),
                Selected = (itmtyp.ItemTypeId == selectedId)
            }));

            return list;
        }

    }
}