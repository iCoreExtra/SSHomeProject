using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class StateMaster : BaseCatalogue
    {
        public CountryMaster country { get; set; }

         public int StateId { get; set; }

         public string StateName { get; set; }

         public int CountryId { get; set; }
    }
}
