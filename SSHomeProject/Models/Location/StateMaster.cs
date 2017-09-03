using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSHomeDataModel;

namespace SSHomeProject.Models
{
    public class StateMasterViewModel
    {
        public CountryMaster state { get; set; }

        public int StateId { get; set; }

        public string StateName { get; set; }

        public int CountryId { get; set; }
    }
}