using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;
using System.Web;

namespace SSHomeProject.Models
{
    public class RawItemMasterViewModel
    {
        public Guid ItemId { get; set; }

        [Required(ErrorMessage ="Please Enter Item Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please Enter Material")]
        public string Material { get; set; }

        //[Required(ErrorMessage = "Please Enter Color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        public string Description1 { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }

        public string Description5 { get; set; }

        [Required(ErrorMessage = "Please Select Unit")]
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Please Select Brand")]
        public long BrandId { get; set; }

        [Required(ErrorMessage = "Please Select Item")]
        [Range(1, 100, ErrorMessage = "Item Type Range Should be 1 to 100")]
        public int ItemTypeId { get; set; }

        public PageMode Mode { get; set; }

    }

    public class RawItemListViewModel 
    {
        public List<RawItemMaster> RawItemList { get; set; }
    }
}