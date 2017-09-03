using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class VendorMaster : BaseCatalogue
    {
        public int VendorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string GSTNo { get; set; }

        public Guid AddressId { get; set; }

        //Other
        public AddressMaster VendorAddressDetails { get; set; }

        public StateMaster State { get; set; }

        public List<AddressMaster> VendorAddressList { get; set; }
    }
}
