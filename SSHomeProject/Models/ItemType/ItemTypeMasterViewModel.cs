using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;
using System.Web;


namespace SSHomeProject.Models
{
    public class ItemTypeMasterViewModel
    {
        public int ItemTypeId { get; set; }

        [Required(ErrorMessage = "Please Enter Item Type")]
        public string Name { get; set; }
    }

    public class ItemTypeListViewModel
    {
        public List<ItemTypeMaster> itemTypeList { get; set; }
    }
}
