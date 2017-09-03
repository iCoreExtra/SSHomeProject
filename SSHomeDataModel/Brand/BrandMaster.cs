using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    #region Class Mapps Database Table
    public class BrandMaster : BaseCatalogue
    {
        public long BrandId { get; set; }

        public string Name { get; set; }
    }
    #endregion
}
