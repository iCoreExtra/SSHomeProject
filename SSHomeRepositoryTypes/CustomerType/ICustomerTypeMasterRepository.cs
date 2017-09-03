using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSHomeCommon;
using SSHomeDataModel;

namespace SSHomeRepositoryTypes
{
    public interface ICustomerTypeMasterRepository : IRepository
    {
        IList<CustomerTypeMaster> GetAll();

        Result<CustomerTypeMaster> Add(CustomerTypeMaster customerTypeDetails);

        Result<CustomerTypeMaster> UpdateCustomerTypeDetails(CustomerTypeMaster customertypeeditdetails);

        CustomerTypeMaster GetCustomerTypeDetails(int customerTypeId);
    }
}
