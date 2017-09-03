using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class StoreMaster : BaseCatalogue
    {
        public int StoreId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public Guid AddressId { get; set; }

        //Other
        public AddressMaster StoreAddressDetails { get; set; }

        public StateMaster State { get; set; }

        public List<AddressMaster> StoreAddressList { get; set; }
    }
}
