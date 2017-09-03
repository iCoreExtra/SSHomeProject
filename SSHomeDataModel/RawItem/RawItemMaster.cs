using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    #region Class Mapps Database Table
    public class RawItemMaster : BaseCatalogue
    {
        public Guid ItemId { get; set; }

        public string ItemName { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Description4 { get; set; }
        
        public string Description5 { get; set; }  

        public int UnitId { get; set; }

        public long BrandId { get; set; }

        public int ItemTypeId { get; set; }

    }
    #endregion data model class end
}
