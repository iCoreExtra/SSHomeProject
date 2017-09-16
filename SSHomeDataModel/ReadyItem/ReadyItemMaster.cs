using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class ReadyItemMaster : BaseCatalogue
    {
        public int ReadyItemId { get; set; }

        public string ItemName { get; set; }

        public string Description1 { get; set; }

        public string Description2 { get; set; }

        public string Description3 { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public Decimal Size { get; set; }

        public Decimal Amount { get; set; }

        public int PatternId {get; set;}

        public int StoreId { get; set; }

        public string StyleCode { get; set; }
    }
}
