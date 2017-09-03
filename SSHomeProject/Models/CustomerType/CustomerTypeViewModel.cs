using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;
using System.Web;

namespace SSHomeProject.Models
{
    public class CustomerTypeMasterViewModel
    {
        public int CustomerTypeId { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Type")]
        public string CustomerType { get; set; }

    }

    public class CustomerTypeListViewModel
    {
        public List<CustomerTypeMaster> customerTypeList { get; set; }
    }
}