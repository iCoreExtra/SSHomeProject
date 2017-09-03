using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSHomeDataModel;
using SSHomeCommon.Enums;
using System.Linq;

namespace SSHomeProject.Models
{
    public class ReferralMasterViewModel
    {
        public int ReferralId { get; set; }

        [Required(ErrorMessage = "Please Enter Source")]
        public string Source { get; set; }
    }

    public class ReferralListViewModel
    {
       public List<ReferralMaster> referralList { get; set; }
    }
}