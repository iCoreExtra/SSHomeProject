using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;
using System.Web;

namespace SSHomeProject.Models
{
    public class BrandMasterViewModel
    {
        public long BrandId { get; set; }

        [Required(ErrorMessage = "Please Enter Brand Name")]
        public string Name { get; set; }

    }

    public class BrandListViewModel
    {
        public List<BrandMaster> brandList { get; set; }
    }
}