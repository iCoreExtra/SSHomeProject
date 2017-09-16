using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeDataModel
{
    public class ClientMaster : BaseCatalogue
    {
        public int ClientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime Anniversary { get; set; }
        
        public string Profession { get; set; } 

        public int ReferralId { get; set; }

        public int StoreId { get; set; }

        public int CustomerTypeId { get; set; }

        public string CompanyName { get; set; }

        //Other
        public StateMaster State { get; set; }

        public List<AddressMaster> ClientAddressList { get; set; }
    }
}
