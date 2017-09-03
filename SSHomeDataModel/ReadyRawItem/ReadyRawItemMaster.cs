using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class ReadyRawItemMaster : BaseCatalogue
    {
        public int ReadyRawItemId { get; set; }

        public int ReadyItemId { get; set; }

        public int RawItemId { get; set; }

        public Decimal Quantity { get; set; }
    }
}
