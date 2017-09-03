using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;

namespace SSHomeProject.Models
{
    public class StoreMasterViewModel
    {
        public int StoreId { get; set; }
        
        [Display (Name ="Store Type")]
        [Required (ErrorMessage ="Please Enter Store Type")]
        public string Type { get; set; }

        [Display(Name = "Store Name")]
        [Required(ErrorMessage = "Please Enter Store Name")]
        public string Name { get; set; }

        public Guid AddressId { get; set; }

        [Display(Name = "Address Line 1")]
        [StringLength(145, ErrorMessage = "Please enter some data in Address Line 1")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Display(Name = "Select State")]
        [Range(0, 100, ErrorMessage = "Please Select State")]
        public int StateId { get; set; }

        [Display(Name = "Select City")]
        [Range(0, 100, ErrorMessage = "Please Select City")]
        public int CityId { get; set; }

        [Display(Name = "Pincode")]
        [MinLength(3, ErrorMessage = "Please enter minimum 3 digits for Pincode")]
        public string Pincode { get; set; }

        public PageMode Mode { get; set; }

    }

    public class StoreListViewModel
    {
        public List<StoreMaster> StoreList { get; set; }
    }
}