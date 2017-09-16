using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    #region  Class Mapps With Database Field
    public class ItemTypeMaster : BaseCatalogue
    {
        public int ItemTypeId { get; set; }

        public string Name { get; set; }
    }
    #endregion
}
