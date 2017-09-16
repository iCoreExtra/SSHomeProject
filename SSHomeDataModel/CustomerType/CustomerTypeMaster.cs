using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    #region  Class Mapps With Database Field
    public class CustomerTypeMaster : BaseCatalogue
    {
        public int CustomerTypeId { get; set; }

        public string CustomerType { get; set; }
    }
    #endregion
}
