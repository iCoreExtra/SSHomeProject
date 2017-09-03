using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class AddressMaster : BaseCatalogue
    {
        public Guid AddressId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public int CityId { get; set; }

        public string Pincode { get; set; }
    }
}
