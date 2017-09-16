using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;
using System.Web;

namespace SSHomeProject.Models
{
    public class UnitMasterViewModel
    {
        public int UnitId { get; set; }

        [Required(ErrorMessage = "Please Enter Unit")]
        public string Unit { get; set; }
    }

    public class UnitListViewModel
    {
        public List<UnitMaster> unitList { get; set; }
    }
}