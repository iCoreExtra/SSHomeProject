using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    #region Class Mapps Database Table
    public class ReferralMaster : BaseCatalogue
    {
        public int ReferralId {get; set;}

        public string Source { get; set; }
    }
    #endregion
}
