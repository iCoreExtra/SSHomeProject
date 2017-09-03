using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class CityMaster : BaseCatalogue
    {
         public StateMaster state { get; set; } 

         public int CityId { get; set; }

         public string CityName { get; set; }

         public string StateId { get; set; }
    }
}
